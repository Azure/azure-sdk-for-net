// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
"use strict";
const test = require("node:test");
const assert = require("node:assert/strict");
const fs = require("node:fs");
const path = require("node:path");
const vm = require("node:vm");

const workflowPath = path.resolve(__dirname, "../pr-re-review.md");
const lockPath = path.resolve(__dirname, "../pr-re-review.lock.yml");

// GH_AW_SAFE_OUTPUTS_CONFIG is a JSON object embedded as a single-line YAML double-quoted
// scalar in the compiled lock file. Wrapping the captured text in real quotes and running it
// through JSON.parse once unescapes the YAML/JSON-string escaping; a second parse yields the
// actual config object, so this needs no YAML parser dependency.
function extractSafeOutputsConfig(lockYmlSource) {
  const match = /^ +GH_AW_SAFE_OUTPUTS_CONFIG: "(.*)"\r?$/m.exec(lockYmlSource);
  assert.ok(match, "could not find GH_AW_SAFE_OUTPUTS_CONFIG in the compiled lock file");
  return JSON.parse(JSON.parse(`"${match[1]}"`));
}

// The workflow markdown has exactly one `script: |` block (the unresolve-review-thread
// custom safe-output job), indented 12 spaces with a 14-space body. Extracted with a
// targeted regex instead of a full YAML parse so this test needs no npm dependency.
function extractUnresolveScript(markdownSource) {
  const start = /^ {12}script: \|\r?\n/m.exec(markdownSource);
  assert.ok(start, "could not find the unresolve-review-thread job's 'script: |' block");
  const rest = markdownSource.slice(start.index + start[0].length);
  const end = /^ {0,13}\S/m.exec(rest);
  const body = end ? rest.slice(0, end.index) : rest;
  // These original receipt/threat tests isolate the newly added freshness
  // dependency; Snapshot.Tests exercises that dependency with real history data.
  const freshnessStub = `
process.env.GITHUB_WORKSPACE ||= '/workspace'; process.env.GH_AW_REVIEW_INPUT ||= 'captured-fixture';
async function capturedFixture() {
  const threads=[]; let cursor=null;
  do {
    const result=await github.graphql('query reviewThreads', {...context.repo,pr:context.payload.pull_request.number,cursor});
    const page=result.repository.pullRequest.reviewThreads;
    for(const thread of page.nodes) {
      const comments=[...thread.comments.nodes]; let next=thread.comments.pageInfo;
      while(next.hasNextPage) {
        const result=await github.graphql('query PullRequestReviewThread', {threadId:thread.id,cursor:next.endCursor});
        comments.push(...result.node.comments.nodes);next=result.node.comments.pageInfo;
      }
      threads.push({id:thread.id,isResolved:thread.isResolved,comments});
    }
    cursor=page.pageInfo.hasNextPage?page.pageInfo.endCursor:null;
  } while(cursor);
  return {pull_number:context.payload.pull_request.number,head_sha:context.payload.pull_request.head.sha,threads};
}
const originalRequireForFreshness=require;
require=name=>name.endsWith('/ReviewSnapshot.cjs')?{assertMutationFresh:async()=>{
  const pr=(await github.rest.pulls.get({...context.repo,pull_number:context.payload.pull_request.number})).data;
  if(pr.state!=='open'||pr.draft||pr.head.sha!==context.payload.pull_request.head.sha)throw new Error('Stale PR state/head');
}}:originalRequireForFreshness(name);
`;
  const script=body.split(/\r?\n/).map(line=>line.startsWith('              ')?line.slice(14):line).join('\n');
  // Supply an already captured history to the production lookup, preserving
  // the original pagination fixtures without reintroducing discovery in the job.
  return freshnessStub + script.replace("JSON.parse(fs.readFileSync(process.env.GH_AW_REVIEW_INPUT, 'utf8'))", 'await capturedFixture()');
}

// Runs the extracted actions/github-script body in a fresh vm context that mocks just
// enough of the actions/github-script runtime (core, context, github, require) to reach
// the detection-conclusion guard. The agent-output fixture always reports zero items, so
// a run that gets past the guard stops at the very next check instead of needing a full
// GraphQL/PR mock -- github.rest.pulls.get and github.graphql are wired to throw if the
// guard ever lets a run reach them.
function run(script, { conclusion, reason, expectedActions = false }) {
  const warnings = [];
  const infos = [];
  let readFileCalled = false;
  const sandbox = {
    process: {
      env: {
        GH_AW_DETECTION_CONCLUSION: conclusion,
        GH_AW_DETECTION_REASON: reason,
        GH_AW_AGENT_OUTPUT: "fixture.json",
        GH_AW_EXPECTED_THREAD_ACTIONS: expectedActions ? 'true' : 'false',
      },
    },
    core: {
      warning: (message) => warnings.push(message),
      info: (message) => infos.push(message),
    },
    context: {
      repo: { owner: "octo", repo: "widgets" },
      payload: { pull_request: { number: 7, head: { sha: "deadbeef" } } },
    },
    github: {
      rest: { pulls: { get: async () => { throw new Error("github.rest.pulls.get should not be reached"); } } },
      graphql: async () => { throw new Error("github.graphql should not be reached"); },
    },
    require: (name) => {
      if (name === "fs") {
        return { readFileSync: () => { readFileCalled = true; return JSON.stringify({ items: [], errors: [] }); } };
      }
      return require(name);
    },
  };
  vm.createContext(sandbox);
  return Promise.resolve(vm.runInContext(`(async () => {\n${script}\n})()`, sandbox))
    .then(() => ({ warnings, infos, readFileCalled }));
}

const guardMessage = /did not conclude "success"/;

test('a requested mutation blocked by detection fails instead of silently succeeding',async()=>{
  const script=extractUnresolveScript(fs.readFileSync(workflowPath,'utf8'));
  await assert.rejects(run(script,{conclusion:'warning',reason:'',expectedActions:true}),/Requested thread mutations blocked/);
});

test("blocks the reopen when threat detection did not cleanly conclude success", async () => {
  const script = extractUnresolveScript(fs.readFileSync(workflowPath, "utf8"));
  for (const { conclusion, reason, label } of [
    { conclusion: "warning", reason: "", label: "warning" },
    { conclusion: "failure", reason: "agent_failure", label: "tooling failure (agent_failure)" },
    { conclusion: "failure", reason: "parse_error", label: "tooling failure (parse_error)" },
    { conclusion: "failure", reason: "", label: "raw failure, no reason" },
    { conclusion: "", reason: "", label: "missing conclusion" },
  ]) {
    const { warnings, readFileCalled } = await run(script, { conclusion, reason });
    assert.equal(readFileCalled, false, `expected the agent output to never be read for: ${label}`);
    assert.ok(warnings.some((message) => guardMessage.test(message)), `expected a guard warning for: ${label}`);
  }
});

test("allows the reopen to proceed once threat detection concludes success", async () => {
  const script = extractUnresolveScript(fs.readFileSync(workflowPath, "utf8"));
  const { warnings, readFileCalled } = await run(script, { conclusion: "success", reason: "" });
  assert.equal(readFileCalled, true, "expected the agent output to be read once the guard passes");
  assert.ok(!warnings.some((message) => guardMessage.test(message)), "the guard should not warn once detection succeeded");
  assert.ok(warnings.some((message) => /no terminal safe output/.test(message)),
    "execution should reach the next (empty-items) check, proving it got past the guard");
});

test("compiled safe-outputs config gives unresolve-review-thread room for more than one reopening per run", () => {
  const config = extractSafeOutputsConfig(fs.readFileSync(lockPath, "utf8"));
  const jobConfig = config["unresolve-review-thread"];
  assert.ok(jobConfig, "unresolve-review-thread should be present in the compiled safe-outputs config");
  // Absence of a 'max' key here means gh-aw's ingestion collector defaults this custom
  // job to a cardinality of 1, silently truncating a multi-thread reopen and recording an
  // ingestion error that our own error-guard then correctly treats as unsafe to act on.
  assert.ok(typeof jobConfig.max === "number" && jobConfig.max >= 2,
    "unresolve-review-thread needs an explicit max >= 2 so ingestion doesn't truncate multi-thread reopen runs to a single item");
});

test("compiled reply handler is restricted to the triggering PR and repository", () => {
  const lock = fs.readFileSync(lockPath, "utf8");
  const match = /^ +GH_AW_SAFE_OUTPUTS_HANDLER_CONFIG: "(.*)"\r?$/m.exec(lock);
  assert.ok(match, "missing safe-output handler configuration");
  const config = JSON.parse(JSON.parse(`"${match[1]}"`));
  const reply = config.reply_to_pull_request_review_comment;
  assert.ok(reply, "missing reply handler");
  assert.equal(reply.target ?? "triggering", "triggering");
  assert.ok(!reply.allowed_repos || reply.allowed_repos.length === 0, "reply handler must not allow cross-repository replies");
});

test("compiled reopen job downloads the applied safe-output manifest", () => {
  const lock = fs.readFileSync(lockPath, "utf8");
  const job = lock.match(/^  unresolve_review_thread:\n([\s\S]*?)(?=^  [a-zA-Z0-9_-]+:\n|(?![\s\S]))/m)?.[1];
  assert.ok(job, "missing reopen job");
  assert.match(job, /actions: read/);
  assert.match(job, /name: Download applied safe-output manifest/);
  assert.match(job, /name: safe-outputs-items/);
  assert.match(job, /GH_AW_REPLY_MANIFEST:.*safe-output-items\.jsonl/);
});

test("does not reopen a thread when the agent did not request a matching reply", async () => {
  const script = extractUnresolveScript(fs.readFileSync(workflowPath, "utf8"));
  const items = [{ type: "unresolve_review_thread", comment_id: "101", reason: "still open" }];
  const mutations = [];
  const sandbox = {
    process: { env: { GH_AW_DETECTION_CONCLUSION: "success", GH_AW_AGENT_OUTPUT: "fixture.json", GH_AW_REPLY_MANIFEST: "manifest.jsonl" } },
    core: { warning: () => {}, info: () => {} },
    context: { repo: { owner: "octo", repo: "widgets" }, payload: { pull_request: { number: 7, head: { sha: "deadbeef" } } } },
    github: {
      rest: { pulls: { get: async () => ({ data: { state: "open", draft: false, head: { sha: "deadbeef" } } }) } },
      graphql: async (query, vars) => {
        if (query.includes("unresolveReviewThread")) { mutations.push(vars.threadId); return {}; }
        return { repository: { pullRequest: { reviewThreads: { pageInfo: { hasNextPage: false, endCursor: null }, nodes: [
          { id: "thread-0", isResolved: true, comments: { pageInfo: { hasNextPage: false, endCursor: null }, nodes: [{ databaseId: 101 }] } },
        ] } } } };
      },
    },
    require: (name) => name === "fs" ? { readFileSync: () => JSON.stringify({ items, errors: [] }) } : require(name),
  };
  vm.createContext(sandbox);
  await assert.rejects(() => vm.runInContext(`(async () => {\n${script}\n})()`, sandbox), /reply/i);
  assert.deepEqual(mutations, [], "a reopen must not happen without a matching posted reply");
});

async function tryReopenWithEvidence({ manifest, rootId = 101, requestedRoot = rootId, requestedBody = "Still open.", operation = "reopen", isResolved = true, missingThread = false, pullOverride = {} }) {
  const script = extractUnresolveScript(fs.readFileSync(workflowPath, "utf8"));
  const items = [
    { type: "unresolve_review_thread", comment_id: String(rootId), reason: "verified state", operation },
    { type: "reply_to_pull_request_review_comment", comment_id: String(requestedRoot), body: requestedBody },
  ];
  const mutations = [];
  const sandbox = {
    process: { env: { GH_AW_DETECTION_CONCLUSION: "success", GH_AW_AGENT_OUTPUT: "fixture.json", GH_AW_REPLY_MANIFEST: "manifest.jsonl" } },
    core: { warning: () => {}, info: () => {} },
    context: { repo: { owner: "octo", repo: "widgets" }, payload: { pull_request: { number: 7, head: { sha: "deadbeef" } } } },
    github: {
      rest: { pulls: {
        get: async () => ({ data: { state: "open", draft: false, head: { sha: "deadbeef" }, ...pullOverride } }),
      } },
      graphql: async (query, vars) => {
        if (query.includes("unresolveReviewThread") || query.includes("resolveReviewThread")) { mutations.push(vars.threadId); return {}; }
        return { repository: { pullRequest: { reviewThreads: { pageInfo: { hasNextPage: false, endCursor: null }, nodes: [
          ...(!missingThread ? [{ id: "thread-0", isResolved, comments: { pageInfo: { hasNextPage: false, endCursor: null }, nodes: [{ databaseId: rootId }] } }] : []),
        ] } } } };
      },
    },
    require: name => name === "fs" ? {
      readFileSync: file => file === "manifest.jsonl" ? manifest : JSON.stringify({ items, errors: [] }),
    } : require(name),
  };
  vm.createContext(sandbox);
  let error;
  try { await vm.runInContext(`(async () => {\n${script}\n})()`, sandbox); } catch (e) { error = e; }
  return { error, mutations };
}

test('requested resolutions fail visibly when the PR closes or its head moves',async()=>{
  for(const pullOverride of [{state:'closed'},{head:{sha:'moved'}}]) {
    const result=await tryReopenWithEvidence({manifest:JSON.stringify({type:'reply_to_pull_request_review_comment',provider:'github',id:101}),operation:'resolve',isResolved:false,pullOverride});
    assert.ok(result.error,'A stale requested resolution must fail the job');
    assert.deepEqual(result.mutations,[]);
  }
});

test('a missing requested thread fails instead of leaving a green run',async()=>{
  const result=await tryReopenWithEvidence({manifest:JSON.stringify({type:'reply_to_pull_request_review_comment',provider:'github',id:101}),missingThread:true});
  assert.match(result.error.message,/Could not find requested/);assert.deepEqual(result.mutations,[]);
});

test("resolves only after a requested reply was actually applied", async () => {
  const absent = await tryReopenWithEvidence({ manifest: "", operation: "resolve", isResolved: false, requestedBody: "Addressed." });
  assert.match(absent.error.message, /applied reply/i);
  assert.deepEqual(absent.mutations, []);
  const present = await tryReopenWithEvidence({ manifest: JSON.stringify({ type: "reply_to_pull_request_review_comment", provider: "github", id: 101 }), operation: "resolve", isResolved: false, requestedBody: "Addressed." });
  assert.ifError(present.error);
  assert.deepEqual(present.mutations, ["thread-0"]);
});

// Captured from safe-outputs-items in run 41568851809. Its id is the original
// review comment, not the newly-created reply id (4450467376).
test("accepts gh-aw's actual applied-reply manifest format", async () => {
  const manifest = fs.readFileSync(path.join(__dirname, "fixtures/pr-re-review-applied-reply.jsonl"), "utf8");
  const { error, mutations } = await tryReopenWithEvidence({ manifest, rootId: 4365208263 });
  assert.ifError(error);
  assert.deepEqual(mutations, ["thread-0"]);
});

for (const [label, manifest, requestedRoot, requestedBody] of [
  ["no applied reply", "", 101, "Still open."],
  ["a malformed applied-output manifest", "{", 101, "Still open."],
  ["an empty requested reply", JSON.stringify({ type: "reply_to_pull_request_review_comment", provider: "github", id: 101 }), 101, " "],
  ["an unrelated provider", JSON.stringify({ type: "reply_to_pull_request_review_comment", provider: "other", id: 101 }), 101, "Still open."],
  ["a reply on a different thread", JSON.stringify({ type: "reply_to_pull_request_review_comment", provider: "github", id: 202 }), 101, "Still open."],
  ["no reply requested for this thread", JSON.stringify({ type: "reply_to_pull_request_review_comment", provider: "github", id: 101 }), 202, "Still open."],
]) {
  test(`does not reopen with ${label}`, async () => {
    const { error, mutations } = await tryReopenWithEvidence({ manifest, requestedRoot, requestedBody });
    assert.ok(error, "expected the job to fail closed");
    assert.deepEqual(mutations, []);
  });
}

test("validates every reply before reopening any thread", async () => {
  const script = extractUnresolveScript(fs.readFileSync(workflowPath, "utf8"));
  const items = [
    { type: "unresolve_review_thread", comment_id: "101", reason: "still open" },
    { type: "unresolve_review_thread", comment_id: "202", reason: "still open" },
    { type: "reply_to_pull_request_review_comment", comment_id: "101", body: "Still open." },
  ];
  const mutations = [];
  const sandbox = {
    process: { env: { GH_AW_DETECTION_CONCLUSION: "success", GH_AW_AGENT_OUTPUT: "fixture.json", GH_AW_REPLY_MANIFEST: "manifest.jsonl" } },
    core: { warning: () => {}, info: () => {} },
    context: { repo: { owner: "octo", repo: "widgets" }, payload: { pull_request: { number: 7, head: { sha: "deadbeef" } } } },
    github: {
      rest: { pulls: {
        get: async () => ({ data: { state: "open", draft: false, head: { sha: "deadbeef" } } }),
      } },
      graphql: async (query, vars) => {
        if (query.includes("unresolveReviewThread")) { mutations.push(vars.threadId); return {}; }
        const nodes = [101, 202].map(id => ({ id: `thread-${id}`, isResolved: true, comments: { pageInfo: { hasNextPage: false, endCursor: null }, nodes: [{ databaseId: id }] } }));
        return { repository: { pullRequest: { reviewThreads: { pageInfo: { hasNextPage: false, endCursor: null }, nodes } } } };
      },
    },
    require: name => name === "fs" ? {
      readFileSync: file => file === "manifest.jsonl" ? JSON.stringify({ type: "reply_to_pull_request_review_comment", provider: "github", id: 101 }) : JSON.stringify({ items, errors: [] }),
    } : require(name),
  };
  vm.createContext(sandbox);
  await assert.rejects(() => vm.runInContext(`(async () => {\n${script}\n})()`, sandbox), /reply/i);
  assert.deepEqual(mutations, []);
});

// Provide same-thread applied replies while retaining the original reopen regression anchors.
function addPostedReplies(sandbox, items, rootIds) {
  for (const id of rootIds) {
    items.push({ type: "reply_to_pull_request_review_comment", comment_id: String(id), body: "Still open." });
  }
  const manifest = rootIds.map(id => JSON.stringify({ type: "reply_to_pull_request_review_comment", provider: "github", id })).join("\n");
  sandbox.process.env.GH_AW_REPLY_MANIFEST = "manifest.jsonl";
  const oldRequire = sandbox.require;
  sandbox.require = name => name === "fs" ? {
    readFileSync: file => file === "manifest.jsonl" ? manifest : JSON.stringify({ items, errors: [] }),
  } : oldRequire(name);
}

// This test documents already-correct behavior rather than a red/green bug fix: the job
// script's loop was never capped at one item -- only the ingestion-side cardinality was.
// It guards against a future regression in the script itself once ingestion is fixed to
// actually deliver more than one item.
test("reopens every item when multiple unresolve_review_thread entries survive ingestion", async () => {
  const script = extractUnresolveScript(fs.readFileSync(workflowPath, "utf8"));
  const items = [
    { type: "unresolve_review_thread", comment_id: "101", reason: "still open" },
    { type: "unresolve_review_thread", comment_id: "202", reason: "still open" },
  ];
  const threadsByCommentId = new Map(items.map((item, i) => [Number(item.comment_id), `thread-${i}`]));
  const resolvedThreadIds = [];
  const sandbox = {
    process: {
      env: {
        GH_AW_DETECTION_CONCLUSION: "success",
        GH_AW_DETECTION_REASON: "",
        GH_AW_AGENT_OUTPUT: "fixture.json",
      },
    },
    core: { warning: () => {}, info: () => {} },
    context: {
      repo: { owner: "octo", repo: "widgets" },
      payload: { pull_request: { number: 7, head: { sha: "deadbeef" } } },
    },
    github: {
      rest: { pulls: { get: async () => ({ data: { state: "open", draft: false, head: { sha: "deadbeef" } } }) } },
      graphql: async (query, vars) => {
        if (query.includes("unresolveReviewThread")) {
          resolvedThreadIds.push(vars.threadId);
          return { unresolveReviewThread: { thread: { id: vars.threadId, isResolved: false } } };
        }
        const nodes = [...threadsByCommentId.entries()].map(([commentId, threadId]) => ({
          id: threadId,
          isResolved: true,
          comments: { pageInfo: { hasNextPage: false, endCursor: null }, nodes: [{ databaseId: commentId }] },
        }));
        return { repository: { pullRequest: { reviewThreads: { pageInfo: { hasNextPage: false, endCursor: null }, nodes } } } };
      },
    },
    require: (name) => {
      if (name === "fs") return { readFileSync: () => JSON.stringify({ items, errors: [] }) };
      return require(name);
    },
  };
  addPostedReplies(sandbox, items, [101, 202]);
  vm.createContext(sandbox);
  await vm.runInContext(`(async () => {\n${script}\n})()`, sandbox);
  assert.deepEqual(resolvedThreadIds.sort(), ["thread-0", "thread-1"], "both threads should have been reopened, not just the first");
});

// Regression for a 101-comment thread: the target comment is the 101st, so it is absent
// from the thread's first (and, pre-fix, only) page of 100 comments. The outer
// reviewThreads pagination is unaffected -- this is about the inner comments connection.
test("finds a review thread when the target comment is beyond the thread's first page of 100 comments", async () => {
  const script = extractUnresolveScript(fs.readFileSync(workflowPath, "utf8"));
  const items = [{ type: "unresolve_review_thread", comment_id: "101", reason: "still open" }];
  const firstPageComments = Array.from({ length: 100 }, (_, i) => ({ databaseId: i + 1 }));
  let secondPageRequested = false;
  const resolvedThreadIds = [];
  const sandbox = {
    process: {
      env: {
        GH_AW_DETECTION_CONCLUSION: "success",
        GH_AW_DETECTION_REASON: "",
        GH_AW_AGENT_OUTPUT: "fixture.json",
      },
    },
    core: { warning: () => {}, info: () => {} },
    context: {
      repo: { owner: "octo", repo: "widgets" },
      payload: { pull_request: { number: 7, head: { sha: "deadbeef" } } },
    },
    github: {
      rest: { pulls: { get: async () => ({ data: { state: "open", draft: false, head: { sha: "deadbeef" } } }) } },
      graphql: async (query, vars) => {
        if (query.includes("unresolveReviewThread")) {
          resolvedThreadIds.push(vars.threadId);
          return { unresolveReviewThread: { thread: { id: vars.threadId, isResolved: false } } };
        }
        if (query.includes("PullRequestReviewThread")) {
          // Per-thread continuation query for a thread's comments connection alone.
          secondPageRequested = true;
          assert.equal(vars.threadId, "thread-0");
          assert.equal(vars.cursor, "page1-end");
          return { node: { comments: { pageInfo: { hasNextPage: false, endCursor: null }, nodes: [{ databaseId: 101 }] } } };
        }
        return {
          repository: {
            pullRequest: {
              reviewThreads: {
                pageInfo: { hasNextPage: false, endCursor: null },
                nodes: [
                  {
                    id: "thread-0",
                    isResolved: true,
                    comments: { pageInfo: { hasNextPage: true, endCursor: "page1-end" }, nodes: firstPageComments },
                  },
                ],
              },
            },
          },
        };
      },
    },
    require: (name) => {
      if (name === "fs") return { readFileSync: () => JSON.stringify({ items, errors: [] }) };
      return require(name);
    },
  };
  addPostedReplies(sandbox, items, [1]);
  vm.createContext(sandbox);
  await vm.runInContext(`(async () => {\n${script}\n})()`, sandbox);
  assert.ok(secondPageRequested, "expected the script to paginate a thread's comments beyond its first page of 100");
  assert.deepEqual(resolvedThreadIds, ["thread-0"], "the thread containing comment 101 should have been reopened");
});
