// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

"use strict";

function requireEvidence(condition, message) {
  if (!condition) throw new Error(`Re-review evidence: ${message}`);
}

function truncated(text) {
  return /^(?:Output too large|File too large|Output truncated)/.test(text) ||
    /\n\[Output truncated[.\]]/.test(text);
}

function parseSession(session) {
  const pending = new Map();
  const calls = new Map();
  let submitted = false;
  for (const line of session.split(/\r?\n/).filter(line => line.trim())) {
    const event = JSON.parse(line);
    const data = event.data;
    if (event.type === "tool.execution_start") {
      // Only reads completed before submission can support that review.
      if (data.mcpServerName === "safeoutputs" && data.mcpToolName === "submit_pull_request_review") {
        submitted = true;
        break;
      }
      pending.set(data.toolCallId, data);
    } else if (event.type === "tool.execution_complete" && data.success === true) {
      const start = pending.get(data.toolCallId);
      if (start) calls.set(data.toolCallId, { ...start, result: data.result, order: calls.size });
    }
  }
  requireEvidence(submitted, "transcript has no recognized review submission boundary.");
  return calls;
}

function visiblePayload(call, calls, depth = 0) {
  requireEvidence(depth < 5, "payload nesting is unsupported.");
  const text = call.result?.content;
  requireEvidence(typeof text === "string", "successful tool result has no visible content.");
  let value;
  try { value = JSON.parse(text); } catch { value = text; }
  value = decodeVisibleText(value);
  const payloadPath = value?.payloadPath ||
    (typeof value === "string" && value.match(/Saved to: ([^\r\n]+)/)?.[1]);
  if (payloadPath) {
    const read = [...calls.values()].find(candidate => {
      const args = candidate.arguments;
      return candidate.toolName === "view" && args?.path === payloadPath &&
        candidate.order > call.order &&
        (!args.view_range || (args.view_range[0] === 1 && args.view_range[1] === -1)) &&
        typeof candidate.result?.content === "string" &&
        !truncated(candidate.result.content);
    });
    requireEvidence(read, `offloaded payload was not fully read: ${call.toolCallId}. Retry with smaller pages.`);
    return visiblePayload(read, calls, depth + 1);
  }
  requireEvidence(!truncated(text) && !(typeof value === "string" && truncated(value)), "tool output is truncated.");
  return value;
}

function filePage(value) {
  if (Array.isArray(value) && value.every(file => typeof file?.filename === "string")) return value;
  // MCP responses may be wrapped in an array of content envelopes. Only visible text
  // counts; detailedContent/structuredContent can include data omitted from the prompt.
  if (Array.isArray(value) && value.length === 1) return filePage(value[0]);
  if (Array.isArray(value?.content)) {
    const text = value.content.filter(part => part.type === "text").map(part => part.text).join("\n");
    requireEvidence(value.isError !== true && text, "file page is not a successful text response.");
    return filePage(JSON.parse(text));
  }
  throw new Error("Re-review evidence: file page has no file payload.");
}

function decodeVisibleText(value, depth = 0) {
  requireEvidence(depth < 5, "visible text envelope nesting is unsupported.");
  if (Array.isArray(value) && value.length === 1 && Array.isArray(value[0]?.content)) return decodeVisibleText(value[0], depth + 1);
  requireEvidence(value?.isError !== true, "tool read returned an MCP error.");
  if (Array.isArray(value?.content) && value.content.every(part => part.type === "text")) {
    const text = value.content.map(part => part.text).join("\n");
    let decoded;
    try { decoded = JSON.parse(text); } catch { decoded = text; }
    return decodeVisibleText(decoded, depth + 1);
  }
  return value;
}

function fileText(value) {
  if (Array.isArray(value) && value.length === 1) return fileText(value[0]);
  requireEvidence(value?.isError !== true, "file read returned an MCP error.");
  const resources = value?.content?.filter(part => part.type === "resource" && typeof part.resource?.text === "string");
  requireEvidence(resources?.length === 1, "context read must return file content, not a directory or metadata.");
  return resources[0].resource.text;
}

function sameTarget(call, target) {
  const args = call.arguments;
  return call.mcpServerName === "github" && args?.owner?.toLowerCase() === target.owner.toLowerCase() &&
    args?.repo?.toLowerCase() === target.repo.toLowerCase() && args?.pullNumber === target.number;
}

function validateEvidence({ output, session, inventory, target }) {
  const reviews = output.items.filter(item => item.type === "submit_pull_request_review");
  requireEvidence(reviews.length === 1, "exactly one review is required.");
  const blocks = [...reviews[0].body.matchAll(/^```review-evidence\r?\n([\s\S]*?)^```[ \t]*$/gm)];
  requireEvidence(blocks.length === 1, "exactly one review-evidence JSON block is required.");
  const evidence = JSON.parse(blocks[0][1]);
  requireEvidence(evidence.head === target.head, "assessment head does not match the event head.");
  requireEvidence(Array.isArray(evidence.files), "per-file assessments are missing.");
  const calls = parseSession(session);
  const historyCalls = [...calls.values()].filter(call => sameTarget(call, target) && call.mcpToolName === "pull_request_read");
  const threadPages = new Map();
  const readReviews = new Set();
  let fetchedReviews = false;
  for (const call of historyCalls) {
    if (!["get_review_comments", "get_reviews"].includes(call.arguments.method)) continue;
    let payload;
    try { payload = visiblePayload(call, calls); } catch { continue; }
    if (call.arguments.method === "get_reviews" && Array.isArray(payload)) {
      fetchedReviews = true;
      payload.forEach(review => readReviews.add(review.id));
    } else if (Array.isArray(payload?.review_threads) && payload.totalCount === inventory.threads &&
      typeof payload.pageInfo?.hasNextPage === "boolean" &&
      payload.review_threads.every(thread => Array.isArray(thread.comments) && Number.isInteger(thread.total_count) &&
        thread.total_count === thread.comments.length)) {
      threadPages.set(call.arguments.after ?? "", payload);
    }
  }
  const readThreads = new Set();
  const visited = new Set();
  let cursor = "";
  do {
    requireEvidence(!visited.has(cursor), "review-thread pagination did not advance.");
    visited.add(cursor);
    const page = threadPages.get(cursor);
    requireEvidence(page, "review history pagination/payload consumption is incomplete.");
    page.review_threads.forEach(thread => readThreads.add(thread.id));
    cursor = page.pageInfo.hasNextPage ? page.pageInfo.endCursor : null;
    requireEvidence(cursor !== undefined && cursor !== "", "review-thread continuation cursor is missing.");
  } while (cursor !== null);
  requireEvidence(readThreads.size === inventory.threadIds.length &&
    inventory.threadIds.every(id => readThreads.has(id)), "read thread IDs disagree with the trusted inventory.");
  requireEvidence(fetchedReviews && inventory.reviewIds.every(id => readReviews.has(id)), "prior reviews were not fully read.");
  const pageGroups = new Map();
  const readable = new Map();
  const listed = new Set();
  for (const [id, call] of calls) {
    if (!sameTarget(call, target) || call.mcpToolName !== "pull_request_read" || call.arguments.method !== "get_files") continue;
    const size = call.arguments.perPage ?? 30;
    const page = call.arguments.page ?? 1;
    if (!Number.isInteger(size) || size < 1 || size > 100 || !Number.isInteger(page) || page < 1) continue;
    listed.add(`${size}:${page}`);
    let files;
    try { files = filePage(visiblePayload(call, calls)); } catch { continue; }
    const expected = inventory.files.slice((page - 1) * size, page * size);
    if (!expected.length || files.length !== expected.length ||
      files.some((file, index) => file.filename !== expected[index].filename || file.status !== expected[index].status ||
        (file.patch ?? null) !== (expected[index].patch ?? null))) continue;
    if (!pageGroups.has(size)) pageGroups.set(size, new Set());
    pageGroups.get(size).add(page);
    readable.set(id, new Map(files.map(file => [file.filename, file])));
  }
  requireEvidence([...pageGroups].some(([size, pages]) =>
    Array.from({ length: Math.ceil(inventory.files.length / size) }, (_, index) => index + 1).every(page => pages.has(page))),
  `changed-file pagination/payload consumption is incomplete (${listed.size} page requests; ${readable.size} readable pages).`);

  const assessments = new Map();
  for (const entry of evidence.files) {
    requireEvidence(typeof entry.path === "string" && !assessments.has(entry.path), "duplicate or invalid assessment path.");
    const file = readable.get(entry.readCallId)?.get(entry.path);
    requireEvidence(file, `no consumed changed-file payload for ${entry.path}.`);
    requireEvidence(typeof entry.assessment === "string" && entry.assessment.trim(), `missing assessment for ${entry.path}.`);
    let text = file.patch;
    if (typeof text !== "string" || !text.trim()) {
      const call = calls.get(entry.contentCallId);
      const args = call?.arguments;
      const sha = file.status === "removed" ? target.base : target.head;
      requireEvidence(call?.mcpServerName === "github" && call.mcpToolName === "get_file_contents" &&
        args.owner === target.owner && args.repo === target.repo && args.path === entry.path &&
        sha && (args.sha ?? args.ref) === sha, `missing pinned content read for patchless file ${entry.path}.`);
      text = fileText(visiblePayload(call, calls));
    }
    requireEvidence(typeof entry.quote === "string" && entry.quote.trim() &&
      text.includes(entry.quote), `assessment quote is not in the read patch/content for ${entry.path}.`);
    assessments.set(entry.path, entry);
  }
  requireEvidence(assessments.size === inventory.files.length &&
    inventory.files.every(file => assessments.has(file.filename)), "assessed paths do not match the trusted inventory.");

  const contexts = evidence.context ?? [];
  requireEvidence(Array.isArray(contexts), "context evidence must be an array.");
  for (const entry of contexts) {
    const call = calls.get(entry.readCallId);
    const args = call?.arguments;
    requireEvidence(call?.mcpServerName === "github" && call.mcpToolName === "get_file_contents" &&
      args.owner === entry.owner && args.repo === entry.repo && args.path === entry.path &&
      /^[0-9a-f]{40}$/.test(entry.sha) && (args.sha ?? args.ref) === entry.sha,
    `context is not pinned to its successful file read: ${entry.path}.`);
    const text = fileText(visiblePayload(call, calls));
    requireEvidence(typeof entry.quote === "string" && entry.quote.trim() && text.includes(entry.quote) &&
      typeof entry.assessment === "string" && entry.assessment.trim(), `missing source-backed context assessment: ${entry.path}.`);
  }
  if (inventory.files.some(file => file.status === "added" && /^sdk\/[^/]+\/[^/]+\/src\/[^/]+\.csproj$/.test(file.filename))) {
    requireEvidence(contexts.some(entry => entry.owner === target.owner && entry.repo === target.repo &&
      entry.path === ".github/CODEOWNERS" && entry.sha === target.head), "new-library ownership requires reading CODEOWNERS at the target head.");
  }
  const coverage = reviews[0].body.match(/Coverage:\s*(\d+)\/(\d+) threads fetched,\s*(\d+)\/(\d+) unresolved threads verified,\s*(\d+)\/(\d+) changed files reviewed/i);
  requireEvidence(coverage && coverage.slice(1).map(Number).every((count, index) =>
    count === [inventory.threads, inventory.threads, inventory.unresolved, inventory.unresolved, inventory.files.length, inventory.files.length][index]),
  "coverage totals disagree with the trusted inventory.");
  return `Read ${inventory.files.length} changed-file payloads; ${assessments.size} source-backed file assessments; ${contexts.length} context assessments. Access/assessment evidence does not prove semantic review quality.`;
}

async function validatePublication({ github, context, output, session }) {
  // Incomplete-only runs retain the existing terminal-validation failure path.
  if (!output.items.some(item => item.type === "submit_pull_request_review")) return;
  const target = { ...context.repo, number: context.payload.pull_request.number, head: context.payload.pull_request.head.sha };
  const parameters = { ...context.repo, pull_number: target.number };
  const before = (await github.rest.pulls.get(parameters)).data;
  requireEvidence(before.head.sha === target.head && before.state === "open" && !before.draft, "PR is stale, closed, or draft.");
  target.base = before.base.sha;
  const files = await github.paginate(github.rest.pulls.listFiles, { ...parameters, per_page: 100 });
  requireEvidence(files.length > 0 && files.length === before.changed_files &&
    new Set(files.map(file => file.filename)).size === files.length, "trusted changed-file inventory is incomplete.");
  let cursor = null;
  let threads = 0;
  let unresolved = 0;
  const threadIds = [];
  const cursors = new Set();
  do {
    const result = await github.graphql(`query($owner: String!, $repo: String!, $number: Int!, $cursor: String) {
      repository(owner: $owner, name: $repo) { pullRequest(number: $number) {
        reviewThreads(first: 100, after: $cursor) {
          totalCount pageInfo { hasNextPage endCursor } nodes { id isResolved }
        }
      } }
    }`, { owner: target.owner, repo: target.repo, number: target.number, cursor });
    const connection = result.repository.pullRequest.reviewThreads;
    threads += connection.nodes.length;
    threadIds.push(...connection.nodes.map(thread => thread.id));
    unresolved += connection.nodes.filter(thread => !thread.isResolved).length;
    cursor = connection.pageInfo.hasNextPage ? connection.pageInfo.endCursor : null;
    requireEvidence(!cursor || !cursors.has(cursor), "trusted thread cursor did not advance.");
    cursors.add(cursor);
    if (!cursor) requireEvidence(threads === connection.totalCount, "trusted thread inventory is incomplete.");
  } while (cursor);
  requireEvidence(new Set(threadIds).size === threadIds.length, "trusted thread inventory contains duplicates.");
  const reviews = await github.paginate(github.rest.pulls.listReviews, { ...parameters, per_page: 100 });
  const message = validateEvidence({ output, session, inventory: {
    files, threads, unresolved, threadIds, reviewIds: reviews.map(review => review.id)
  }, target });
  const after = (await github.rest.pulls.get(parameters)).data;
  requireEvidence(after.head.sha === target.head && after.base.sha === before.base.sha &&
    after.changed_files === files.length && after.state === "open" && !after.draft, "PR moved during evidence validation.");
  return message;
}

module.exports = { validateEvidence, validatePublication };
