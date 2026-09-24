import assert from "node:assert/strict";
import { spawnSync } from "node:child_process";
import { mkdtempSync, mkdirSync, readFileSync, writeFileSync, rmSync } from "node:fs";
import { join, resolve } from "node:path";
import { tmpdir } from "node:os";
import { pathToFileURL } from "node:url";
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
        undefined,
        null,
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

test("timeline capture sends the build token only to the canonical Azure DevOps endpoint", t => {
    const root = mkdtempSync(join(tmpdir(), "eval-timeline-cli-")); t.after(() => rmSync(root, { recursive: true, force: true }));
    const mock = join(root, "mock-fetch.mjs");
    writeFileSync(mock, `globalThis.fetch = async (url, options) => {
        console.log("fixture-fetch-called");
        if (url.href !== "https://dev.azure.com/azure-sdk/00000000-0000-4000-8000-000000000001/_apis/build/builds/1001/timeline?api-version=7.1" ||
            options.headers.authorization !== "Bearer fixture-token" || options.redirect !== "error") throw new Error("Unexpected request");
        return { ok: true, json: async () => ({ records: [{ type: "Job", identifier: "Eval.RunShard.a", attempt: 1, state: "completed", result: "failed" }] }) };
    };`);
    for (const [index, collection] of ["https://dev.azure.com/azure-sdk/", "https://dev.azure.com:444/azure-sdk/",
        "https://dev.azure.com.attacker.example/azure-sdk/", "http://dev.azure.com/azure-sdk/",
        "https://user:password@dev.azure.com/azure-sdk/", "https://dev.azure.com/azure-sdk/?extra=1"].entries()) {
        const output = join(root, `attempts-${index}.json`);
        const env = { ...process.env, SYSTEM_COLLECTIONURI: collection, SYSTEM_TEAMPROJECTID: "00000000-0000-4000-8000-000000000001",
            BUILD_BUILDID: "1001", SYSTEM_ACCESSTOKEN: "fixture-token", EVAL_EXPECTED_MATRIX: '{"a":{"shardName":"a"}}' };
        delete env.NODE_TEST_CONTEXT;
        const child = spawnSync(process.execPath, ["--experimental-strip-types", "--import", pathToFileURL(mock).href,
            resolve(import.meta.dirname, "../capture-eval-attempts.ts"), "--output", output], { env, encoding: "utf8", timeout: 30_000 });
        assert.ifError(child.error); assert.equal(child.status, 0, child.stderr);
        assert.equal(JSON.parse(readFileSync(output, "utf8")).valid, index === 0);
        assert.equal(child.stdout.includes("fixture-fetch-called"), index === 0);
        assert.doesNotMatch(child.stdout + child.stderr, /fixture-token|password/);
    }
});