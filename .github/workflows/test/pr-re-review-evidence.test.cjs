// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

"use strict";

const assert = require("node:assert/strict");
const { test } = require("node:test");
const { validateEvidence, validatePublication } = require("../pr-re-review/ReviewEvidence.cjs");

const head = "d15865062777ca8867177d221331e4f9c272fb5d";
const target = { owner: "Azure", repo: "azure-sdk-for-net", number: 64532, head };

function fixture(count = 2) {
  const files = Array.from({ length: count }, (_, index) => ({
    filename: `src/Model${index}.cs`, status: "added", patch: `+public class Model${index} {}`
  }));
  const events = [];
  const evidence = {
    head,
    files: files.map(file => ({
      path: file.filename, readCallId: "page1", quote: file.patch,
      assessment: `Checked the declaration of ${file.filename} against the naming and compatibility rules.`
    })),
    context: []
  };
  const state = { files, events, evidence };
  addHistory(state);
  addCall(state, "page1", { method: "get_files", perPage: 100 }, files);
  return state;
}

function addHistory(state) {
  addCall(state, "threads", { method: "get_review_comments" }, {
    totalCount: 9, pageInfo: { hasNextPage: false },
    review_threads: Array.from({ length: 9 }, (_, index) => ({
      id: `thread${index}`, comments: [{ body: "Existing feedback." }], total_count: 1
    }))
  });
  addCall(state, "reviews", { method: "get_reviews" }, [{ id: 123 }]);
}

function pageCompletion(state) {
  return state.events.find(event => event.type === "tool.execution_complete" && event.data.toolCallId === "page1").data;
}

function addCall(state, id, args, payload, options = {}) {
  const data = {
    toolCallId: id, toolName: "github-pull_request_read",
    mcpServerName: "github", mcpToolName: "pull_request_read",
    arguments: { owner: target.owner, repo: target.repo, pullNumber: target.number, ...args },
    ...options.start
  };
  state.events.push({ type: "tool.execution_start", data });
  state.events.push({
    type: "tool.execution_complete",
    data: { toolCallId: id, success: options.success ?? true, result: { content: JSON.stringify(payload) } }
  });
}

function input(state) {
  return {
    target,
    inventory: { files: state.files, threads: 9, unresolved: 2,
      threadIds: Array.from({ length: 9 }, (_, index) => `thread${index}`), reviewIds: [123] },
    session: [...state.events, {
      type: "tool.execution_start",
      data: { toolCallId: "submit", mcpServerName: "safeoutputs", mcpToolName: "submit_pull_request_review" }
    }].map(event => JSON.stringify(event)).join("\n"),
    output: { errors: [], items: [{
      type: "submit_pull_request_review",
      body: `Coverage: 9/9 threads fetched, 2/2 unresolved threads verified, ${state.files.length}/${state.files.length} changed files reviewed\n` +
        "```review-evidence\n" + JSON.stringify(state.evidence) + "\n```"
    }] }
  };
}

test("accepts consumed inline MCP pages and preserves individual assessments", () => {
  const state = fixture();
  pageCompletion(state).result.content = JSON.stringify([{
    content: [{ type: "text", text: JSON.stringify(state.files) }],
    structuredContent: state.files
  }]);
  assert.match(validateEvidence(input(state)), /2 source-backed file assessments/);
});

test("run 41962130473: unread first-page offload cannot publish fabricated 139/139", () => {
  const state = fixture(139);
  state.events = [];
  addHistory(state);
  addCall(state, "page1", { method: "get_files", perPage: 100 }, {
    payloadPath: "/tmp/gh-aw/mcp-payloads/fixture/payload.json",
    originalSize: 1262577, payloadSchema: { structuredContent: [{ filename: "string", patch: "string" }] }
  });
  // The actual run only listed tests and read the tests csproj after its local SDK read failed.
  addCall(state, "directory", { path: "tests", sha: head }, [{ name: "Client.Tests.csproj", type: "file" }], {
    start: { toolName: "github-get_file_contents", mcpToolName: "get_file_contents" }
  });
  assert.throws(() => validateEvidence(input(state)), /pagination\/payload consumption is incomplete/);
});

test("run 41923964948: page 2 alone cannot publish fabricated 139/139", () => {
  const state = fixture(139);
  state.events = [];
  addHistory(state);
  addCall(state, "page2", { method: "get_files", page: 2, perPage: 100 }, state.files.slice(100));
  assert.throws(() => validateEvidence(input(state)), /pagination\/payload consumption is incomplete/);
});

test("accepts all pages, including the final partial page", () => {
  const state = fixture(139);
  state.events = [];
  addHistory(state);
  addCall(state, "page1", { method: "get_files", perPage: 100 }, state.files.slice(0, 100));
  addCall(state, "page2", { method: "get_files", page: 2, perPage: 100 }, state.files.slice(100));
  state.evidence.files.slice(100).forEach(entry => { entry.readCallId = "page2"; });
  assert.doesNotThrow(() => validateEvidence(input(state)));
});

test("an offload is consumed only by a full successful view, not a path mention or partial read", () => {
  for (const range of [undefined, [1, -1], [1, 10]]) {
    const state = fixture();
    pageCompletion(state).result.content = JSON.stringify({ payloadPath: "/tmp/page.json" });
    addCall(state, "view", {}, state.files, {
      start: { toolName: "view", mcpServerName: undefined, mcpToolName: undefined,
        arguments: { path: "/tmp/page.json", ...(range ? { view_range: range } : {}) } }
    });
    if (range?.[1] === 10) assert.throws(() => validateEvidence(input(state)), /pagination/);
    else assert.doesNotThrow(() => validateEvidence(input(state)));
  }
});

function textEnvelope(value) {
  return { content: [{ type: "text", text: JSON.stringify(value) }] };
}

test("wrapped offload metadata is consumed after a successful full view", () => {
  const metadata = { payloadPath: "/tmp/page.json" };
  for (const payload of [textEnvelope(metadata), [textEnvelope(metadata)], textEnvelope([textEnvelope(metadata)])]) {
    const state = fixture();
    pageCompletion(state).result.content = JSON.stringify(payload);
    addCall(state, "view", {}, [textEnvelope(state.files)], {
      start: { toolName: "view", mcpServerName: undefined, mcpToolName: undefined,
        arguments: { path: metadata.payloadPath, view_range: [1, -1] } }
    });
    assert.doesNotThrow(() => validateEvidence(input(state)));
  }
});

test("wrapped offloads still require a full successful read and reject MCP errors or truncation", () => {
  for (const change of ["missing view", "failed view", "partial view", "MCP error", "truncated view"]) {
    const state = fixture();
    const payload = textEnvelope({ payloadPath: "/tmp/page.json" });
    if (change === "MCP error") payload.isError = true;
    pageCompletion(state).result.content = JSON.stringify([payload]);
    if (change !== "missing view") {
      addCall(state, "view", {}, textEnvelope(change === "truncated view" ? "Output truncated." : state.files), {
        success: change !== "failed view",
        start: { toolName: "view", mcpServerName: undefined, mcpToolName: undefined,
          arguments: { path: "/tmp/page.json", view_range: [1, change === "partial view" ? 2 : -1] } }
      });
    }
    assert.throws(() => validateEvidence(input(state)), /pagination/);
  }
});

test("hidden detailed content cannot turn an unread offload into a consumed page", () => {
  const state = fixture();
  pageCompletion(state).result = {
    content: "Output too large to read at once. Saved to: /tmp/page.json",
    detailedContent: JSON.stringify(state.files)
  };
  assert.throws(() => validateEvidence(input(state)), /pagination/);
});

test("source text mentioning truncation is data, but a truncated full-view result is not consumed", () => {
  const state = fixture(1);
  state.files[0].patch = '+const message = "Output too large; payloadPath";';
  state.evidence.files[0].quote = state.files[0].patch;
  pageCompletion(state).result.content = JSON.stringify({ payloadPath: "/tmp/page.json" });
  addCall(state, "view", {}, state.files, {
    start: { toolName: "view", mcpServerName: undefined, mcpToolName: undefined,
      arguments: { path: "/tmp/page.json", view_range: [1, -1] } }
  });
  assert.doesNotThrow(() => validateEvidence(input(state)));
  state.events.at(-1).data.result.content = "Output truncated. " + JSON.stringify(state.files);
  assert.throws(() => validateEvidence(input(state)), /pagination/);
});

test("a missing patch requires actual file content pinned to the correct revision", () => {
  const state = fixture(1);
  delete state.files[0].patch;
  pageCompletion(state).result.content = JSON.stringify(state.files);
  assert.throws(() => validateEvidence(input(state)), /missing pinned content read/);
  state.evidence.files[0].contentCallId = "content";
  addCall(state, "content", {}, [{
    content: [
      { type: "text", text: "successfully downloaded text file" },
      { type: "resource", resource: { text: state.evidence.files[0].quote } }
    ]
  }], {
    start: { toolName: "github-get_file_contents", mcpToolName: "get_file_contents",
      arguments: { owner: target.owner, repo: target.repo, path: state.files[0].filename, sha: head } }
  });
  assert.doesNotThrow(() => validateEvidence(input(state)));
  state.events.at(-2).data.arguments.sha = "main";
  assert.throws(() => validateEvidence(input(state)), /missing pinned content read/);
});

test("rejects unsuccessful calls, foreign PRs, metadata-only responses and inconsistent inventories", () => {
  const mutations = [
    state => { pageCompletion(state).success = false; },
    state => { state.events.find(event => event.type === "tool.execution_start" && event.data.toolCallId === "page1").data.arguments.pullNumber++; },
    state => { state.events.find(event => event.type === "tool.execution_start" && event.data.toolCallId === "page1").data.arguments.repo = "other"; },
    state => { pageCompletion(state).result.content = JSON.stringify([{ name: "src", type: "dir" }]); },
    state => { pageCompletion(state).result.content = JSON.stringify(state.files.slice().reverse()); },
    state => { pageCompletion(state).result.content = JSON.stringify(state.files.map(file => ({ ...file, patch: "+stale code" }))); },
    state => { pageCompletion(state).result.content = JSON.stringify({ isError: true, content: [{ type: "text", text: JSON.stringify(state.files) }] }); }
  ];
  for (const mutate of mutations) {
    const state = fixture();
    mutate(state);
    assert.throws(() => validateEvidence(input(state)), /pagination/);
  }
});

test("rejects omitted, duplicated, stale, fabricated and unassessed evidence", () => {
  const mutations = [
    state => { state.evidence.files.pop(); },
    state => { state.evidence.files[1] = state.evidence.files[0]; },
    state => { state.evidence.head = "a".repeat(40); },
    state => { state.evidence.files[0].quote = "not in the source"; },
    state => { state.evidence.files[0].assessment = ""; },
    state => { state.evidence.files[0].readCallId = "directory"; }
  ];
  for (const mutate of mutations) {
    const state = fixture();
    mutate(state);
    assert.throws(() => validateEvidence(input(state)), /Re-review evidence/);
  }
});

test("reads performed after submitting the review cannot retroactively support it", () => {
  const state = fixture();
  state.events.unshift({
    type: "tool.execution_start",
    data: { mcpServerName: "safeoutputs", mcpToolName: "submit_pull_request_review" }
  });
  assert.throws(() => validateEvidence(input(state)), /pagination/);
});

test("a complete-looking transcript without a recognized submission event is rejected", () => {
  for (const change of ["missing", "wrong server", "wrong tool"]) {
    const value = input(fixture());
    const events = value.session.split("\n").map(JSON.parse);
    if (change === "missing") events.pop();
    if (change === "wrong server") events.at(-1).data.mcpServerName = "github";
    if (change === "wrong tool") events.at(-1).data.mcpToolName = "get_files";
    value.session = events.map(event => JSON.stringify(event)).join("\n");
    assert.throws(() => validateEvidence(value), /no recognized review submission boundary/);
  }
});

test("rejects invented coverage totals even with complete file evidence", () => {
  const value = input(fixture());
  value.inventory.unresolved = 3;
  assert.throws(() => validateEvidence(value), /totals disagree/);
});

test("review history must be consumed to its end, including each thread's comments", () => {
  for (const change of ["missing reviews", "unread threads", "missing comments", "missing thread", "missing cursor"]) {
    const state = fixture();
    const threadResult = state.events.find(event => event.type === "tool.execution_complete" && event.data.toolCallId === "threads");
    const page = JSON.parse(threadResult.data.result.content);
    if (change === "missing reviews") state.events = state.events.filter(event => event.data.toolCallId !== "reviews");
    if (change === "unread threads") threadResult.data.result.content = JSON.stringify({ payloadPath: "/tmp/threads.json" });
    if (change === "missing comments") page.review_threads[0].total_count = 2;
    if (change === "missing thread") page.review_threads.pop();
    if (change === "missing cursor") page.pageInfo.hasNextPage = true;
    if (change !== "unread threads") threadResult.data.result.content = JSON.stringify(page);
    assert.throws(() => validateEvidence(input(state)), /Re-review evidence/);
  }
});

test("new library requires source-backed ownership context, not a directory listing", () => {
  const state = fixture(1);
  state.files[0].filename = "sdk/example/Azure.ResourceManager.Example/src/Azure.ResourceManager.Example.csproj";
  state.evidence.files[0].path = state.files[0].filename;
  pageCompletion(state).result.content = JSON.stringify(state.files);
  assert.throws(() => validateEvidence(input(state)), /ownership requires reading CODEOWNERS/);
  state.evidence.context.push({
    owner: target.owner, repo: target.repo, path: ".github/CODEOWNERS", sha: head,
    readCallId: "owners", quote: "/sdk/example/ @example-team", assessment: "The service-specific ownership entry covers the new package."
  });
  addCall(state, "owners", {}, [{
    content: [{ type: "resource", resource: { text: "/sdk/example/ @example-team" } }]
  }], {
    start: { toolName: "github-get_file_contents", mcpToolName: "get_file_contents",
      arguments: { owner: target.owner, repo: target.repo, path: ".github/CODEOWNERS", sha: head } }
  });
  assert.doesNotThrow(() => validateEvidence(input(state)));
  state.events.at(-1).data.result.content = JSON.stringify([{ name: "CODEOWNERS", type: "file" }]);
  assert.throws(() => validateEvidence(input(state)), /not a directory or metadata/);
});

function publicationFixture(state) {
  const value = input(state);
  let gets = 0;
  const pr = { head: { sha: head }, base: { sha: "b".repeat(40) }, state: "open", draft: false, changed_files: state.files.length };
  const github = {
    rest: { pulls: { get: async () => ({ data: { ...pr, ...(gets++ ? github.after : {}) } }),
      listFiles: Symbol("listFiles"), listReviews: Symbol("listReviews") } },
    paginate: async (method, args) => {
      assert.equal(args.per_page, 100);
      return method === github.rest.pulls.listFiles ? state.files : [{ id: 123 }];
    },
    graphql: async () => ({
      repository: { pullRequest: { reviewThreads: {
        totalCount: 9, pageInfo: { hasNextPage: false },
        nodes: Array.from({ length: 9 }, (_, index) => ({ id: `thread${index}`, isResolved: index >= 2 }))
      } } }
    })
  };
  return { github, context: { repo: { owner: target.owner, repo: target.repo }, payload: { pull_request: { number: target.number, head: { sha: head } } } }, output: value.output, session: value.session };
}

test("publication fetches trusted inventory and rechecks the head after validation", async () => {
  const args = publicationFixture(fixture());
  assert.match(await validatePublication(args), /2 source-backed/);
  const moved = publicationFixture(fixture());
  moved.github.after = { head: { sha: "c".repeat(40) } };
  await assert.rejects(validatePublication(moved), /PR moved/);
});

test("publication rejects incomplete trusted pagination and repeated thread cursors", async () => {
  const args = publicationFixture(fixture());
  args.github.paginate = async () => [];
  await assert.rejects(validatePublication(args), /trusted changed-file inventory is incomplete/);
  args.github.paginate = async () => fixture().files;
  args.github.graphql = async () => ({ repository: { pullRequest: { reviewThreads: {
    totalCount: 9, nodes: [], pageInfo: { hasNextPage: true, endCursor: "same" }
  } } } });
  await assert.rejects(validatePublication(args), /cursor did not advance/);
});
