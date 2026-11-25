// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
"use strict";
const test = require("node:test");
const assert = require("node:assert/strict");
const fs = require("node:fs");
const path = require("node:path");
const vm = require("node:vm");

const source = fs.readFileSync(path.resolve(__dirname, "../pr-re-review.md"), "utf8");
const lock = fs.readFileSync(path.resolve(__dirname, "../pr-re-review.lock.yml"), "utf8");

function job(name, text = source) {
  const match = new RegExp(`^  ${name}:\\n([\\s\\S]*?)(?=^  [a-z_]+:|^[^ #\\n])`, "m").exec(text);
  assert.ok(match, `missing ${name} job`);
  return match[1];
}

function script(text = source, name = "notify_manual_review") {
  const match = /^ {10}script: \|\r?\n((?: {12}.*\r?\n|\r?\n)+)/m.exec(job(name, text));
  assert.ok(match, "missing notification script");
  return match[1].split(/\r?\n/).map(line => line.startsWith("            ") ? line.slice(12) : line).join("\n");
}

async function run({ oversized = false, output = { items: [{ type: "report_incomplete" }], errors: [] }, outputTypes = "report_incomplete", artifactFails = false, completed = false, pr = { state: "open", draft: false, head: { sha: "a".repeat(40) }, base: { sha: "b".repeat(40) } }, previous = [], failComment = false } = {}) {
  const comments = [];
  const updates = [];
  const infos = [];
  const env = { REVIEW_OVERSIZED: String(oversized), REVIEW_COMPLETED: String(completed), REVIEW_OUTPUT_TYPES: outputTypes, REVIEW_CHARACTERS: "700001", REVIEW_LIMIT: "700000", RUNNER_TEMP: "/tmp", GITHUB_SERVER_URL: "https://github.com", GITHUB_REPOSITORY: "Azure/azure-sdk-for-net", GITHUB_RUN_ID: "123", GITHUB_RUN_ATTEMPT: "2" };
  const sandbox = {
    process: { env },
    require: name => name === "fs" ? { readFileSync: () => { if (artifactFails) throw new Error("artifact unavailable"); return JSON.stringify(output); } } : require(name),
    context: { repo: { owner: "Azure", repo: "azure-sdk-for-net" }, payload: { pull_request: { number: 42, head: { sha: "a".repeat(40) }, base: { sha: "b".repeat(40) } } } },
    core: { info: message => infos.push(message), warning: message => infos.push(message) },
    github: {
      rest: { pulls: { get: async () => ({ data: pr }) }, actions: { getWorkflowRunAttempt: async () => ({ data: { run_started_at: "2026-01-02T00:00:00Z" } }) }, issues: { listComments: () => {}, createComment: async args => { if (failComment) throw new Error("comment API failed"); comments.push(args); }, updateComment: async args => updates.push(args) } },
      paginate: async () => previous,
    },
  };
  vm.createContext(sandbox);
  await vm.runInContext(`(async () => {\n${script(source, completed ? "update_manual_review" : "notify_manual_review")}\n})()`, sandbox);
  return { comments, updates, infos };
}

test("notifies for each incomplete agent outcome without publishing a review", async () => {
  for (const type of ["report_incomplete", "missing_tool", "missing_data"]) {
    const { comments } = await run({ outputTypes: type, output: { items: [{ type }], errors: [] } });
    assert.equal(comments.length, 1);
    assert.match(comments[0].body, /manual review/i);
    assert.match(comments[0].body, /did not complete/i);
    assert.match(comments[0].body, /actions\/runs\/123/);
    assert.match(comments[0].body, /&#45; by copilot$/);
  }
});

test("notifies for size skips with measured size and limit", async () => {
  const { comments } = await run({ oversized: true });
  assert.equal(comments.length, 1);
  assert.match(comments[0].body, /700,001/);
  assert.match(comments[0].body, /700,000/);
  assert.match(comments[0].body, /manual review/i);
});

test("does not mislabel a complete or malformed agent output", async () => {
  for (const output of [{ items: [{ type: "submit_pull_request_review" }], errors: [] }, { items: [], errors: [] }]) {
    assert.equal((await run({ outputTypes: "", output })).comments.length, 0);
  }
});

test("does not post for a closed, draft, or superseded pull request", async () => {
  for (const pr of [
    { state: "closed", draft: false, head: { sha: "a".repeat(40) }, base: { sha: "b".repeat(40) } },
    { state: "open", draft: true, head: { sha: "a".repeat(40) }, base: { sha: "b".repeat(40) } },
    { state: "open", draft: false, head: { sha: "b".repeat(40) }, base: { sha: "b".repeat(40) } },
  ]) assert.equal((await run({ pr })).comments.length, 0);
});

test("notifies against the current base when only the base advanced", async () => {
  const pr = { state: "open", draft: false, head: { sha: "a".repeat(40) }, base: { sha: "c".repeat(40) } };
  for (const oversized of [false, true]) {
    const { comments } = await run({ oversized, pr });
    assert.equal(comments.length, 1);
    assert.ok(comments[0].body.includes("b".repeat(40)));
    assert.match(comments[0].body, /base has changed/i);
    assert.match(comments[0].body, /current base/i);
    assert.match(comments[0].body, /manual review/i);
  }
});

test("does not duplicate a comment from this run", async () => {
  const previous = [{ body: "<!-- pr-re-review-manual-review:123 -->", user: { login: "github-actions[bot]" } }];
  assert.equal((await run({ previous })).comments.length, 0);
});

test("notifies from collected output types even when the artifact is unavailable", async () => {
  const { comments } = await run({ outputTypes: "report_incomplete", artifactFails: true });
  assert.equal(comments.length, 1);
});

test("updates this run's notification after a successful rerun", async () => {
  const previous = [{ id: 22, body: "<!-- pr-re-review-manual-review:123 -->\nPlease request a manual review.", updated_at: "2026-01-01T00:00:00Z", user: { login: "github-actions[bot]" } }];
  const { comments, updates } = await run({ completed: true, previous });
  assert.equal(comments.length, 0);
  assert.equal(updates.length, 1);
  assert.equal(updates[0].comment_id, 22);
  assert.match(updates[0].body, /completed/i);
  assert.doesNotMatch(updates[0].body, /please request a manual review/i);
});

test("a later successful run clears older warnings, but not newer or unrelated comments", async () => {
  const previous = [
    { id: 21, body: "<!-- pr-re-review-manual-review:122 -->\nPlease request a manual review.", updated_at: "2026-01-01T00:00:00Z", user: { login: "github-actions[bot]" } },
    { id: 22, body: "<!-- pr-re-review-manual-review:124 -->\nPlease request a manual review.", updated_at: "2026-01-03T00:00:00Z", user: { login: "github-actions[bot]" } },
    { id: 23, body: "<!-- pr-re-review-manual-review:121 -->\nPlease request a manual review.", updated_at: "2026-01-01T00:00:00Z", user: { login: "someone-else" } },
  ];
  const { updates } = await run({ completed: true, previous });
  assert.deepEqual(updates.map(item => item.comment_id), [21]);
  assert.match(updates[0].body, /completed/i);
});

test("a later incomplete attempt reactivates a previously updated notification", async () => {
  const previous = [{ id: 22, body: "<!-- pr-re-review-manual-review:123 -->\nThe automated re-review completed.", user: { login: "github-actions[bot]" } }];
  const { comments, updates } = await run({ previous });
  assert.equal(comments.length, 0);
  assert.equal(updates.length, 1);
  assert.match(updates[0].body, /please request a manual review/i);
});

test("does not hide comment API failures", async () => {
  await assert.rejects(run({ failComment: true }), /comment API failed/);
});

test("the compiled live-only job handles failed and skipped dependencies and fails oversized runs", () => {
  for (const text of [source, lock]) {
    const body = job("notify_manual_review", text);
    assert.match(body, /github\.event_name != 'workflow_dispatch'/);
    assert.match(body, /always\(\)/);
    assert.match(body, /!cancelled\(\)/);
    assert.match(body, /needs\.size_gate\.outputs\.within_cap == 'false'/);
    assert.match(body, /needs\.validate_agent_output\.result == 'failure'/);
    assert.match(body, /issues: write/);
    assert.match(body, /actions: read/);
    assert.match(body, /pull-requests: read/);
    assert.match(body, /Fail oversized re-review[\s\S]*always\(\)[\s\S]*exit 1/);
    assert.match(body, /Download terminal agent output[\s\S]*needs\.size_gate\.outputs\.within_cap != 'false'/);
  }
  assert.equal(script(lock), script(source));
  for (const text of [source, lock]) {
    const update = job("update_manual_review", text);
    assert.match(update, /github\.event_name != 'workflow_dispatch'/);
    assert.match(update, /needs\.validate_agent_output\.result == 'success'/);
    assert.match(update, /!contains\(needs\.agent\.outputs\.output_types, 'unresolve_review_thread'\)/);
    assert.match(update, /needs\.unresolve_review_thread\.result == 'skipped'/);
    assert.doesNotMatch(update, /needs\.unresolve_review_thread\.result == 'success'/);
    assert.match(update, /needs\.detection\.outputs\.detection_conclusion == 'success'/);
    assert.match(update, /needs\.safe_outputs\.result == 'success'/);
    assert.match(update, /needs\.safe_outputs\.outputs\.process_safe_outputs_status == 'success'/);
  }
  assert.equal(script(lock, "update_manual_review").trimEnd(), script(source, "update_manual_review").trimEnd());
});

test("the size-gate workflow reports the same limit it passes to the helper", () => {
  for (const text of [source, lock]) {
    const gate = job("size_gate", text);
    assert.match(gate, /MAX_CHARACTERS: ['"]?700000/);
    assert.match(gate, /& \$gate -MaxCharacters \(\[long\]\$env:MAX_CHARACTERS\)/);
    assert.match(gate, /max_characters=\$env:MAX_CHARACTERS/);
    assert.match(gate, /max_characters: \$\{\{ steps\.measure\.outputs\.max_characters \}\}/);
  }
});
