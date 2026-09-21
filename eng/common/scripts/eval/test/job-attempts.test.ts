import assert from "node:assert/strict";
import { mkdtempSync, mkdirSync, writeFileSync, rmSync } from "node:fs";
import { join } from "node:path";
import { tmpdir } from "node:os";
import { test } from "node:test";
import { latestShardAttempts } from "../lib/job-attempts.ts";
import { selectSummaryResults, stageShardResults } from "../lib/shard-results.ts";

test("timeline uses matrix identifiers, highest attempts and completed job state", () => {
    const matrix = { matrix_key: { shardName: "a" } };
    const records = [1, 2].map(attempt => ({ type: "Job", identifier: "Eval.RunShard.matrix_key", attempt, state: "completed", result: "failed" }));
    assert.deepEqual(latestShardAttempts({ records }, matrix).attempts.a, { attempt: 2, complete: true });
    records[1].result = "canceled";
    assert.equal(latestShardAttempts({ records }, matrix).attempts.a.complete, false);
    assert.throws(() => latestShardAttempts({ records: [] }, matrix));
    assert.throws(() => latestShardAttempts({ records }, {}));
});

test("newer failed attempt with NO artifact never adopts the older complete artifact", t => {
    const root = mkdtempSync(join(tmpdir(), "eval-attempts-")); t.after(() => rmSync(root, { recursive: true, force: true }));
    const source = join(root, "source"); mkdirSync(source);
    writeFileSync(join(source, "results.jsonl"), JSON.stringify({ type: "trial-result", status: "error" }) + "\n" +
        JSON.stringify({ type: "run-summary", evals: [{ name: "a" }] }) + "\n");
    writeFileSync(join(source, "results.junit.xml"), '<testsuites><testsuite><testcase name="a"/></testsuite></testsuites>');
    const downloads = join(root, "artifacts");
    stageShardResults({ resultsRoot: source, outputDirectory: join(downloads, "eval-result-a-1"), shardName: "a", attempt: 1 });
    for (const [index, jobAttempts] of [
        { schemaVersion: 1, valid: true, attempts: { a: { attempt: 2, complete: true } } },
        { schemaVersion: 1, valid: true, attempts: { a: { attempt: 1, complete: false } } },
        { schemaVersion: 1, valid: false, attempts: {} },
    ].entries()) {
        const selected = selectSummaryResults({ resultsRoot: downloads, selectedRoot: join(root, `selected-${index}`), expectedShards: ["a"], jobAttempts });
        assert.equal(selected.complete, false); assert.match(selected.status[0].reason, /timeline/);
    }
    const current = selectSummaryResults({ resultsRoot: downloads, selectedRoot: join(root, "current"), expectedShards: ["a"],
        jobAttempts: { schemaVersion: 1, valid: true, attempts: { a: { attempt: 1, complete: true } } } });
    assert.equal(current.complete, true);
});