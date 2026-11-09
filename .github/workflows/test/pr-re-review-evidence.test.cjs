// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

"use strict";

const assert = require("node:assert/strict");
const crypto = require("node:crypto");
const fs = require("node:fs");
const os = require("node:os");
const path = require("node:path");
const { spawnSync } = require("node:child_process");
const { test } = require("node:test");
const directory = path.resolve(__dirname, "../pr-re-review");
const { makeWorklist, runQueue, buildOutputs, assertPublication } = require("../pr-re-review/ReviewContinuation.cjs");
const { planControllerEvidence } = require("../pr-re-review/ReviewEvidence.cjs");
const pwsh = process.env.REVIEW_PWSH || "pwsh";

async function fixture(t, mode = "complete", patchless) {
  const root = fs.mkdtempSync(path.join(os.tmpdir(), "rereview-evidence-"));
  t.after(() => fs.rmSync(root, { recursive: true, force: true }));
  const input = path.join(root, "review-input");
  const workers = path.join(root, "review-progress");
  fs.mkdirSync(input);
  fs.mkdirSync(workers);
  const patch = mode === "partial" ? "+first-change\n" + "+additional-change\n".repeat(500) : "+first-change\n+last-change";
  const snapshot = {
    pull_number: 64532, head_sha: "a".repeat(40), base_sha: "b".repeat(40), changed_files: 2, threads: [],
    files: [
      { filename: "src/First.cs", status: "modified", patch },
      { filename: "src/Second.cs", status: "modified", patch: "+second-change" }
    ]
  };
  if (patchless) {
    delete snapshot.files[0].patch;
    snapshot.files[0].status = patchless.status || "modified";
    fs.writeFileSync(path.join(root, "source.json"), JSON.stringify(patchless));
  }
  fs.writeFileSync(path.join(input, "snapshot.json"), JSON.stringify(snapshot));
  // The actual #64557 exporter creates the markers/chunks; no alternate capture
  // or read-coverage implementation is substituted by this integration fixture.
  const exported = spawnSync(pwsh, ["-NoProfile", "-Command", `
    Import-Module $env:REVIEW_INPUT_MODULE
    $snapshot = Get-Content (Join-Path $env:REVIEW_TEST_ROOT 'review-input/snapshot.json') -Raw | ConvertFrom-Json
    if (Test-Path (Join-Path $env:REVIEW_TEST_ROOT 'source.json')) {
      $source = Get-Content (Join-Path $env:REVIEW_TEST_ROOT 'source.json') -Raw | ConvertFrom-Json
      & (Get-Module PrReReviewInput) {
        param($Source)
        $script:TestSource = $Source
        function script:Invoke-PrReReviewGhApi {
          param([string[]]$Arguments)
          if ($Arguments[-1] -ceq ('repos/Azure/azure-sdk-for-net/contents/src/First.cs?ref=' + ('a' * 40))) { return $script:TestSource.head }
          if ($Arguments[-1] -ceq ('repos/Azure/azure-sdk-for-net/contents/src/First.cs?ref=' + ('b' * 40))) { return $script:TestSource.base }
          throw 'Unexpected source request.'
        }
      } $source
    }
    Export-PrReReviewInput -Files @($snapshot.files) -Repository Azure/azure-sdk-for-net -HeadSha $snapshot.head_sha -MergeBaseSha $snapshot.base_sha -InputDirectory (Join-Path $env:REVIEW_TEST_ROOT 'visible') -MarkersPath (Join-Path $env:REVIEW_TEST_ROOT 'review-input/markers.json')
  `], { encoding: "utf8", env: { ...process.env, REVIEW_TEST_ROOT: root, REVIEW_INPUT_MODULE: path.join(directory, "PrReReviewInput.psm1") } });
  assert.equal(exported.status, 0, exported.stderr);
  const markers = JSON.parse(fs.readFileSync(path.join(input, "markers.json"), "utf8"));
  let invocation = 0;
  const ledger = await runQueue(makeWorklist(snapshot), {
    deadline: Date.now() + 60000,
    runBatch: async batch => {
      const item = batch[0];
      const marker = markers.files.find(file => file.path === item.file.filename);
      const events = [];
      for (const [index, chunk] of marker.chunks.entries()) {
        if (mode === "unread" || (mode === "partial" && index > 0)) continue;
        events.push({ type: "tool.execution_start", data: { toolCallId: `read-${index}`, toolName: "view" } });
        const content = mode === "wrapped" ? JSON.stringify([{ content: [{ type: "text", text: chunk.content }] }]) : chunk.content;
        events.push({ type: "tool.execution_complete", data: { toolCallId: `read-${index}`, success: mode !== "failed", result: { content } } });
      }
      const result = {
        id: item.id, status: "complete", reasoning: `Checked the changes and interactions in ${item.file.filename}.`,
        findings: [], action: "none", ...(mode === "completion-only" ? {} : {
          evidence: { readCallId: "read-0", quote: patchless && item.id === "file:0" ? patchless.quote : item.file.patch.split("\n")[0] }
        })
      };
      const response = { results: [result] };
      const decision = { type: "assistant.message", data: { content: JSON.stringify(response) } };
      if (mode === "late") events.unshift(decision); else events.push(decision);
      const worker = `worker-${++invocation}/execution.log`;
      fs.mkdirSync(path.join(workers, `worker-${invocation}`));
      fs.writeFileSync(path.join(workers, ...worker.split("/")), events.map(event => JSON.stringify(event)).join("\n"));
      return { ...response, worker_session: worker };
    }
  });
  const progress = { ...ledger, head_sha: snapshot.head_sha, base_sha: snapshot.base_sha,
    snapshot_sha256: crypto.createHash("sha256").update(JSON.stringify(snapshot)).digest("hex") };
  const output = { items: buildOutputs(snapshot, progress), errors: [] };
  assertPublication(snapshot, progress, output, "success");
  fs.writeFileSync(path.join(workers, "progress.json"), JSON.stringify(progress));
  fs.writeFileSync(path.join(root, "agent-output.json"), JSON.stringify(output));
  const arguments_ = { snapshot, progress, markers, loadSession: worker => fs.readFileSync(path.join(workers, ...worker.split("/")), "utf8") };
  return { root, output, arguments_ };
}

function guard(f) {
  return spawnSync(pwsh, ["-NoProfile", "-File", path.join(directory, "Invoke-PrReReviewEvidenceGuard.ps1")], {
    encoding: "utf8", maxBuffer: 8 * 1024 * 1024,
    env: { ...process.env, RUNNER_TEMP: f.root, AGENT_OUTPUT: path.join(f.root, "agent-output.json") }
  });
}

test("combined controller/shared-helper path accepts separate read-only worker sessions", async t => {
  const f = await fixture(t);
  const plans = planControllerEvidence(f.arguments_);
  assert.equal(plans.length, 2);
  for (const plan of plans) assert.ok(!f.arguments_.loadSession(plan.worker).includes("submit_pull_request_review"));
  assert.equal(f.output.items.at(-1).type, "submit_pull_request_review");
  const validated = guard(f);
  assert.equal(validated.status, 0, validated.stderr);
  assert.match(validated.stdout, /shared read coverage from 2 worker sessions/);
});

test("wrapped visible read results work through the shared coverage guard", async t => {
  const f = await fixture(t, "wrapped");
  const validated = guard(f);
  assert.equal(validated.status, 0, validated.stderr);
});

test("patchless assessments quote actual base or head source, including an emptied head", async t => {
  for (const source of [
    { base: "// old declaration", head: "// new declaration", quote: "// old declaration" },
    { base: "// old declaration", head: "// new declaration", quote: "// new declaration" },
    { base: "// old declaration", head: "", quote: "// old declaration" },
    { base: "// old declaration", head: "binary\0content", quote: "// old declaration" },
    { status: "added", head: "# Review input is also legitimate source text", quote: "# Review input" }
  ]) {
    const f = await fixture(t, "complete", source);
    const validated = guard(f);
    assert.equal(validated.status, 0, validated.stderr);
  }
});

test("patchless wrapper-only quotes cannot become source-backed assessments", async t => {
  for (const quote of ["# Review input", "GitHub returned no patch", "# End of review input"]) {
    const f = await fixture(t, "complete", { base: "// old declaration", head: "// new declaration", quote });
    const validated = guard(f);
    assert.notEqual(validated.status, 0);
    assert.match(validated.stderr + validated.stdout, /quote is not in the captured base or head content/);
  }
});

test("empty, whitespace-only and non-text patchless inputs cannot complete using a wrapper quote", async t => {
  for (const source of [
    { status: "added", head: "" },
    { base: "", head: " \r\n\t" },
    { base: "old\0binary", head: "new\0binary" }
  ]) {
    const f = await fixture(t, "complete", { ...source, quote: "# Review input" });
    const validated = guard(f);
    assert.notEqual(validated.status, 0);
    assert.match(validated.stderr + validated.stdout, /no quotable source text/);
  }
});

test("patchless evidence fails closed when captured source metadata is missing", async t => {
  const f = await fixture(t, "complete", { status: "added", head: "// new declaration", quote: "// new declaration" });
  delete f.arguments_.markers.files[0].sourceContents;
  assert.throws(() => planControllerEvidence(f.arguments_), /captured patchless source content is missing/);
});

test("a completed controller ledger and fabricated complete totals are not proof of a read", async t => {
  for (const mode of ["unread", "failed", "completion-only", "late"]) {
    const f = await fixture(t, mode);
    assert.match(f.output.items.at(-1).body, /2\/2 changed files reviewed/);
    assert.throws(() => planControllerEvidence(f.arguments_), /source-backed assessment|successful read/);
  }
});

test("the shared guard rejects an unread remaining part despite a source-backed first-part quote", async t => {
  const f = await fixture(t, "partial");
  assert.equal(planControllerEvidence(f.arguments_).length, 2);
  const validated = guard(f);
  assert.notEqual(validated.status, 0);
  assert.match(validated.stderr + validated.stdout, /missing: src\/First\.cs/);
});

test("assessment evidence is bound to the actual worker decision and its own session", async t => {
  const f = await fixture(t);
  const result = f.arguments_.progress.results[0];
  const reasoning = result.reasoning;
  result.reasoning = "A fabricated assessment";
  assert.throws(() => planControllerEvidence(f.arguments_), /worker decision/);
  result.reasoning = reasoning;
  result.evidence.quote = "+second-change";
  assert.throws(() => planControllerEvidence(f.arguments_), /source-backed assessment/);
});

test("worker artifact paths cannot escape the controller artifact directory", async t => {
  const f = await fixture(t);
  f.arguments_.progress.attempts[0].worker_session = "../other/execution.log";
  assert.throws(() => planControllerEvidence(f.arguments_), /artifact path is invalid/);
});

test("the existing controller still owns completion, snapshot identity and routing", async t => {
  const f = await fixture(t);
  assert.throws(() => assertPublication(f.arguments_.snapshot, f.arguments_.progress, f.output, "failure"), /controller did not complete/);
  assert.throws(() => assertPublication(f.arguments_.snapshot, { ...f.arguments_.progress, results: [] }, f.output, "success"), /Incomplete review ledger/);
  assert.throws(() => assertPublication(f.arguments_.snapshot, { ...f.arguments_.progress, snapshot_sha256: "forged" }, f.output, "success"), /captured snapshot/);
});
