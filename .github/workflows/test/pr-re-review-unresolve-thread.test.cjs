// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
"use strict";
const test = require("node:test");
const assert = require("node:assert/strict");
const fs = require("node:fs");
const path = require("node:path");
const vm = require("node:vm");

const workflowPath = path.resolve(__dirname, "../pr-re-review.md");

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
