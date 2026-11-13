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
  return body
    .split(/\r?\n/)
    .map((line) => (line.startsWith("              ") ? line.slice(14) : line))
    .join("\n");
}

// Runs the extracted actions/github-script body in a fresh vm context that mocks just
// enough of the actions/github-script runtime (core, context, github, require) to reach
// the detection-conclusion guard. The agent-output fixture always reports zero items, so
// a run that gets past the guard stops at the very next check instead of needing a full
// GraphQL/PR mock -- github.rest.pulls.get and github.graphql are wired to throw if the
// guard ever lets a run reach them.
function run(script, { conclusion, reason }) {
  const warnings = [];
  const infos = [];
  let readFileCalled = false;
  const sandbox = {
    process: {
      env: {
        GH_AW_DETECTION_CONCLUSION: conclusion,
        GH_AW_DETECTION_REASON: reason,
        GH_AW_AGENT_OUTPUT: "fixture.json",
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
  vm.createContext(sandbox);
  await vm.runInContext(`(async () => {\n${script}\n})()`, sandbox);
  assert.ok(secondPageRequested, "expected the script to paginate a thread's comments beyond its first page of 100");
  assert.deepEqual(resolvedThreadIds, ["thread-0"], "the thread containing comment 101 should have been reopened");
});
