// node:test unit tests for lib/verdict.js (port of Invoke-EvalShard.Tests.ps1, which
// exercised the verdict helpers). Run from eng/common/scripts/eval:  npm test

import assert from "node:assert/strict";
import fs from "node:fs";
import os from "node:os";
import path from "node:path";
import { after, before, describe, it } from "node:test";

import { getVallyShardVerdict } from "../lib/verdict.js";

describe("getVallyShardVerdict", () => {
  let root;

  before(() => {
    root = fs.mkdtempSync(path.join(os.tmpdir(), "vally-shard-"));
  });

  after(() => fs.rmSync(root, { recursive: true, force: true }));

  // Mimic Vally's nested per-run timestamp folder under the shard output dir.
  function newRunSummary(shard, jsonl, timestamp = "2026-06-18T04-27-19-656Z") {
    const dir = path.join(root, shard, timestamp);
    fs.mkdirSync(dir, { recursive: true });
    fs.writeFileSync(path.join(dir, "results.jsonl"), jsonl);
    return path.join(root, shard);
  }

  it("passes a scored eval above the threshold", () => {
    const dir = newRunSummary(
      "above",
      '{"type":"run-summary","passed":true,"hadExecutionErrors":false,"evals":[{"name":"e","passed":true,"scoringApplied":true,"overallScore":0.971,"threshold":0.8,"stimuliRun":7,"stimuliTotal":7}]}'
    );
    const v = getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 });
    assert.equal(v.found, true);
    assert.equal(v.passed, true);
  });

  it("passes a scored eval exactly on the threshold boundary", () => {
    const dir = newRunSummary(
      "boundary",
      '{"type":"run-summary","passed":true,"hadExecutionErrors":false,"evals":[{"name":"e","passed":true,"scoringApplied":true,"overallScore":0.8,"threshold":0.8,"stimuliRun":5,"stimuliTotal":5}]}'
    );
    assert.equal(getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 }).passed, true);
  });

  it("passes when the verdict cleared the threshold but the run had execution errors", () => {
    const dir = newRunSummary(
      "execerrors",
      '{"type":"run-summary","passed":false,"hadExecutionErrors":true,"evals":[{"name":"e","passed":false,"scoringApplied":true,"overallScore":0.971,"threshold":0.8,"stimuliRun":7,"stimuliTotal":7}]}'
    );
    const v = getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 });
    assert.equal(v.passed, true);
    assert.equal(v.hadExecutionErrors, true);
  });

  it("fails a scored eval below the threshold", () => {
    const dir = newRunSummary(
      "below",
      '{"type":"run-summary","passed":false,"hadExecutionErrors":false,"evals":[{"name":"e","passed":false,"scoringApplied":true,"overallScore":0.6,"threshold":0.8,"stimuliRun":5,"stimuliTotal":5}]}'
    );
    assert.equal(getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 }).passed, false);
  });

  it("fails a scored eval that cleared the threshold but ran zero stimuli (no vacuous pass)", () => {
    const dir = newRunSummary(
      "norun",
      '{"type":"run-summary","passed":false,"hadExecutionErrors":false,"evals":[{"name":"e","passed":false,"scoringApplied":true,"overallScore":1.0,"threshold":0.8,"stimuliRun":0,"stimuliTotal":3}]}'
    );
    assert.equal(getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 }).passed, false);
  });

  it("honours a binary (unscored) eval verdict", () => {
    const dir = newRunSummary(
      "binary",
      '{"type":"run-summary","passed":true,"hadExecutionErrors":false,"evals":[{"name":"e","passed":true,"scoringApplied":false,"stimuliRun":2,"stimuliTotal":2}]}'
    );
    assert.equal(getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 }).passed, true);
  });

  it("fails the shard when any eval in a multi-eval shard is below threshold", () => {
    const dir = newRunSummary(
      "mixed",
      '{"type":"run-summary","passed":false,"hadExecutionErrors":false,"evals":[{"name":"ok","passed":true,"scoringApplied":true,"overallScore":1.0,"threshold":0.8,"stimuliRun":3,"stimuliTotal":3},{"name":"bad","passed":false,"scoringApplied":true,"overallScore":0.5,"threshold":0.8,"stimuliRun":4,"stimuliTotal":4}]}'
    );
    assert.equal(getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 }).passed, false);
  });

  it("reports not-found when there is no results.jsonl", () => {
    const dir = path.join(root, "empty");
    fs.mkdirSync(dir, { recursive: true });
    const v = getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 });
    assert.equal(v.found, false);
    assert.equal(v.passed, false);
  });

  it("reports not-found when results.jsonl has no run-summary record", () => {
    const dir = newRunSummary("nosummary", '{"type":"trial","name":"x"}');
    assert.equal(getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 }).found, false);
  });

  it("uses the newest results.jsonl when several runs exist", () => {
    const shardDir = newRunSummary(
      "multi",
      '{"type":"run-summary","passed":false,"hadExecutionErrors":false,"evals":[{"name":"e","passed":false,"scoringApplied":true,"overallScore":0.5,"threshold":0.8,"stimuliRun":4,"stimuliTotal":4}]}',
      "2026-06-18T04-27-19-656Z"
    );
    const newerDir = path.join(shardDir, "2026-06-18T05-00-00-000Z");
    fs.mkdirSync(newerDir, { recursive: true });
    const newerFile = path.join(newerDir, "results.jsonl");
    fs.writeFileSync(
      newerFile,
      '{"type":"run-summary","passed":true,"hadExecutionErrors":false,"evals":[{"name":"e","passed":true,"scoringApplied":true,"overallScore":1.0,"threshold":0.8,"stimuliRun":4,"stimuliTotal":4}]}'
    );
    // Make the newer file unambiguously newer (avoid same-millisecond ties on fast disks).
    const older = path.join(shardDir, "2026-06-18T04-27-19-656Z", "results.jsonl");
    const past = new Date(Date.now() - 60_000);
    fs.utimesSync(older, past, past);

    assert.equal(getVallyShardVerdict({ resultsDir: shardDir, threshold: 0.8 }).passed, true);
  });
});
