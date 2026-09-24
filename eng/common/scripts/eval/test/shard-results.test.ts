import assert from "node:assert/strict";
import fs from "node:fs";
import os from "node:os";
import path from "node:path";
import { fileURLToPath } from "node:url";
import { spawnSync } from "node:child_process";
import { test } from "node:test";
import { expectedShardsFromMatrix, selectSummaryResults, stageShardResults } from "../lib/shard-results.ts";
import { getVallyShardVerdict } from "../lib/verdict.ts";

function setup(t) {
    const root = fs.mkdtempSync(path.join(os.tmpdir(), "eval-artifacts-"));
    t.after(() => fs.rmSync(root, { recursive: true, force: true }));
    return root;
}

function invocation(root, name, { failed = false, summary = true, malformed = false, junit = true } = {}) {
    const directory = path.join(root, name);
    fs.mkdirSync(directory, { recursive: true });
    const records = [{ type: "trial-result", status: failed ? "error" : "success", itemId: name }];
    if (summary) records.push({ type: "run-summary", evals: [{ name, stimuliRun: 1, passed: !failed }] });
    fs.writeFileSync(path.join(directory, "results.jsonl"), records.map((entry) => JSON.stringify(entry)).join("\n") + (malformed ? '\n{"type":' : "\n"));
    if (junit) fs.writeFileSync(path.join(directory, "eval-results.junit.xml"),
        `<testsuites><testsuite name="example"><testcase name="${name}" time="1">${failed ? '<failure message="evaluation failed"/>' : ""}</testcase></testsuite></testsuites>`);
    return directory;
}

function artifact(root, shard, attempt, options = {}) {
    const source = invocation(root, `source-${shard}-${attempt}`, options);
    const output = path.join(root, "download", `eval-result-${shard}-${attempt}`);
    stageShardResults({ resultsRoot: source, outputDirectory: output, shardName: shard, attempt });
    const evidence = path.join(root, "job-attempts.json");
    const timeline = fs.existsSync(evidence) ? readJson(evidence) : { schemaVersion: 1, valid: true, attempts: {} };
    if (!timeline.attempts[shard] || timeline.attempts[shard].attempt < attempt) timeline.attempts[shard] = { attempt, complete: true };
    fs.writeFileSync(evidence, JSON.stringify(timeline));
    return output;
}

function readJson(file) {
    return JSON.parse(fs.readFileSync(file, "utf8"));
}

function runCli(scriptName, args, environment = {}, cwd = undefined) {
    const script = fileURLToPath(new URL(`../${scriptName}`, import.meta.url));
    const env = { ...process.env, ...environment };
    delete env.NODE_TEST_CONTEXT;
    for (const key of Object.keys(env)) if (env[key] === undefined) delete env[key];
    const child = spawnSync(process.execPath, ["--experimental-strip-types", script, ...args], {
        encoding: "utf8", env, cwd, timeout: 30_000, maxBuffer: 1024 * 1024,
    });
    assert.ifError(child.error);
    return child;
}

function runSummary(root, shards, options = {}) {
    const output = path.join(root, "summary", "eval-summary.md");
    const matrix = Object.hasOwn(options, "matrix") ? options.matrix :
        JSON.stringify(Object.fromEntries(shards.map((shardName) => [shardName, { shardName }])));
    const child = runCli("build-eval-summary.ts", [
        "--results-root", path.join(root, "download"), "--selected-root", path.join(root, "selected"),
        "--attempts-file", path.join(root, "job-attempts.json"), "--output-path", output,
    ], { TF_BUILD: "true", EVAL_EXPECTED_MATRIX: matrix });
    return {
        child, markdown: fs.readFileSync(output, "utf8"),
        result: readJson(path.join(root, "summary", "eval-summary.json")),
        index: readJson(path.join(root, "download", "shard-index.json")),
    };
}

test("expected shards come from the full Prepare matrix, not arrived artifacts or matrix keys", () => {
    const matrix = { secondJob: { shardName: "area_b", evalArgs: "-e b.eval.yaml" }, firstJob: { shardName: "area_a" } };
    assert.deepEqual(expectedShardsFromMatrix(matrix), ["area_a", "area_b"]);
    assert.deepEqual(expectedShardsFromMatrix(JSON.stringify(matrix)), ["area_a", "area_b"]);
    for (const invalid of [undefined, "not JSON", {}, [], null, true, 1, { a: null }, { a: { shardName: "../escape" } },
        { a: { shardName: "" } }, { a: { shardName: "x".repeat(201) } }, { a: { shardName: "same" }, b: { shardName: "same" } }]) {
        assert.throws(() => expectedShardsFromMatrix(invalid));
    }
});

test("completed failing evaluations stage exact raw bytes and all JUnit, but no unrelated files", (t) => {
    const root = setup(t);
    const source = invocation(root, "source", { failed: true });
    fs.writeFileSync(path.join(source, "debug.log"), "not bundled");
    fs.writeFileSync(path.join(source, "mcp.dll"), "not bundled");
    fs.mkdirSync(path.join(source, "nested"));
    fs.copyFileSync(path.join(source, "eval-results.junit.xml"), path.join(source, "nested", "eval-results.junit.xml"));
    const output = path.join(root, "staged");
    const result = stageShardResults({ resultsRoot: source, outputDirectory: output, shardName: "area_test", attempt: 2 });
    assert.deepEqual(result, { schemaVersion: 1, shard: "area_test", attempt: 2, complete: true, trials: 1, reason: null });
    assert.deepEqual(readJson(path.join(output, "shard.json")), result);
    assert.deepEqual(fs.readdirSync(output).sort(), ["junit", "results.jsonl", "shard.json"]);
    assert.deepEqual(fs.readdirSync(path.join(output, "junit")), ["0.junit.xml", "1.junit.xml"]);
    assert.deepEqual(fs.readFileSync(path.join(output, "results.jsonl")), fs.readFileSync(path.join(source, "results.jsonl")));
});

test("missing, interrupted and corrupt invocations publish incomplete markers", (t) => {
    const root = setup(t);
    for (const [index, options] of [{ summary: false }, { malformed: true }, { junit: false }].entries()) {
        const source = invocation(root, `source-${index}`, options);
        const output = path.join(root, `stage-${index}`);
        const result = stageShardResults({ resultsRoot: source, outputDirectory: output, shardName: "test", attempt: 1 });
        assert.equal(result.complete, false);
        assert.equal(result.trials, 1);
        assert.ok(result.reason);
        assert.deepEqual(readJson(path.join(output, "shard.json")), result);
        assert.deepEqual(fs.readFileSync(path.join(output, "results.jsonl")), fs.readFileSync(path.join(source, "results.jsonl")));
    }
    const output = path.join(root, "empty");
    const empty = stageShardResults({ resultsRoot: path.join(root, "not-created"), outputDirectory: output, shardName: "test", attempt: 1 });
    assert.equal(empty.complete, false);
    assert.equal(empty.trials, 0);
    assert.deepEqual(fs.readdirSync(output).sort(), ["junit", "shard.json"]);
});

test("non-object JSONL and empty final summaries are incomplete, and a trial invalidates an earlier summary", (t) => {
    const root = setup(t);
    const suffixes = ["null", "[]", "42", '{"type":"run-summary","evals":[]}',
        '{"type":"run-summary","evals":null}', '{"type":"trial-result","status":"success"}'];
    for (const [index, suffix] of suffixes.entries()) {
        const source = invocation(root, `source-${index}`);
        fs.appendFileSync(path.join(source, "results.jsonl"), suffix + "\n");
        const result = stageShardResults({ resultsRoot: source, outputDirectory: path.join(root, `staged-${index}`), shardName: "test", attempt: 1 });
        assert.equal(result.complete, false);
    }
});

test("untyped trial records, CRLF and blank lines retain the reference completion semantics", (t) => {
    const root = setup(t);
    const source = invocation(root, "source");
    fs.writeFileSync(path.join(source, "results.jsonl"), '\r\n{"status":"success"}\r\n \r\n{"type":"run-summary","evals":[{"name":"legacy"}]}\r\n');
    const result = stageShardResults({ resultsRoot: source, outputDirectory: path.join(root, "staged"), shardName: "test", attempt: 1 });
    assert.equal(result.complete, true);
    assert.equal(result.trials, 1);
});

test("staging selects the same newest invocation as the shard verdict", (t) => {
    const root = setup(t);
    const old = invocation(root, "runs/old");
    const latest = invocation(root, "runs/new", { failed: true });
    fs.utimesSync(path.join(old, "results.jsonl"), 1, 1);
    fs.utimesSync(path.join(latest, "results.jsonl"), 2, 2);
    const output = path.join(root, "stage");
    assert.equal(getVallyShardVerdict({ resultsDir: path.join(root, "runs") }).passed, false);
    stageShardResults({ resultsRoot: path.join(root, "runs"), outputDirectory: output, shardName: "test", attempt: 1 });
    assert.deepEqual(fs.readFileSync(path.join(output, "results.jsonl")), fs.readFileSync(path.join(latest, "results.jsonl")));
    assert.deepEqual(fs.readFileSync(path.join(output, "junit", "0.junit.xml")), fs.readFileSync(path.join(latest, "eval-results.junit.xml")));
});

test("equal-mtime invocation ties use the verdict's path order, not localeCompare", (t) => {
    const root = setup(t);
    const first = invocation(root, "runs/Z");
    const last = invocation(root, "runs/a", { failed: true });
    for (const directory of [first, last]) fs.utimesSync(path.join(directory, "results.jsonl"), 1, 1);
    const output = path.join(root, "stage");
    assert.equal(getVallyShardVerdict({ resultsDir: path.join(root, "runs") }).passed, false);
    stageShardResults({ resultsRoot: path.join(root, "runs"), outputDirectory: output, shardName: "test", attempt: 1 });
    assert.deepEqual(fs.readFileSync(path.join(output, "results.jsonl")), fs.readFileSync(path.join(last, "results.jsonl")));
});

test("a corrupt newest invocation never falls back to older complete output", (t) => {
    const root = setup(t);
    const old = invocation(root, "runs/old");
    const latest = invocation(root, "runs/new", { malformed: true });
    fs.utimesSync(path.join(old, "results.jsonl"), 1, 1);
    fs.utimesSync(path.join(latest, "results.jsonl"), 2, 2);
    const output = path.join(root, "stage");
    const result = stageShardResults({ resultsRoot: path.join(root, "runs"), outputDirectory: output, shardName: "test", attempt: 1 });
    assert.equal(result.complete, false);
    assert.deepEqual(fs.readFileSync(path.join(output, "results.jsonl")), fs.readFileSync(path.join(latest, "results.jsonl")));
});

test("staging requires an empty destination and does not delete existing contents", (t) => {
    const root = setup(t);
    const source = invocation(root, "source");
    const output = path.join(root, "staged");
    fs.mkdirSync(output);
    fs.writeFileSync(path.join(output, "keep.txt"), "keep me");
    assert.throws(() => stageShardResults({ resultsRoot: source, outputDirectory: output, shardName: "test", attempt: 1 }), /must be empty/);
    assert.deepEqual(fs.readdirSync(output), ["keep.txt"]);
    assert.equal(fs.readFileSync(path.join(output, "keep.txt"), "utf8"), "keep me");
});

test("invalid shard identities or attempts are rejected before creating an output", (t) => {
    const root = setup(t);
    const output = path.join(root, "staged");
    for (const shardName of ["", "../escape", "a/b", "a\\b", "a\n", "x".repeat(201), undefined]) {
        assert.throws(() => stageShardResults({ resultsRoot: root, outputDirectory: output, shardName, attempt: 1 }));
    }
    for (const attempt of [0, -1, 1.5, NaN, Infinity, Number.MAX_SAFE_INTEGER + 1]) {
        assert.throws(() => stageShardResults({ resultsRoot: root, outputDirectory: output, shardName: "test", attempt }));
    }
    assert.equal(fs.existsSync(output), false);
});

test("symbolic-link destinations are not treated as owned empty directories", (t) => {
    const root = setup(t);
    const source = invocation(root, "source");
    const target = path.join(root, "target");
    const output = path.join(root, "link");
    fs.mkdirSync(target);
    fs.symlinkSync(target, output, "junction");
    assert.throws(() => stageShardResults({ resultsRoot: source, outputDirectory: output, shardName: "test", attempt: 1 }), /symbolic link/);
    assert.deepEqual(fs.readdirSync(target), []);
});

test("oversized raw files are not read or copied, but JUnit and an incomplete marker survive", (t) => {
    const root = setup(t);
    const source = invocation(root, "source");
    const fd = fs.openSync(path.join(source, "results.jsonl"), "r+");
    try { fs.ftruncateSync(fd, 128 * 1024 * 1024 + 1); } finally { fs.closeSync(fd); }
    const output = path.join(root, "stage");
    const result = stageShardResults({ resultsRoot: source, outputDirectory: output, shardName: "test", attempt: 1 });
    assert.equal(result.complete, false);
    assert.match(result.reason, /oversized/);
    assert.equal(fs.existsSync(path.join(output, "results.jsonl")), false);
    assert.deepEqual(fs.readdirSync(path.join(output, "junit")), ["0.junit.xml"]);
    assert.equal(readJson(path.join(output, "shard.json")).complete, false);
});

test("summary selects latest expected attempts once; completed failures remain eligible for publication", (t) => {
    const root = setup(t);
    artifact(root, "area_a", 1, { failed: true });
    artifact(root, "area_a", 2);
    artifact(root, "area_b", 1, { failed: true });
    artifact(root, "unrequested", 9);
    const { child, markdown, result, index } = runSummary(root, ["area_b", "area_a"]);
    assert.equal(child.status, 0, child.stderr);
    assert.match(child.stdout, /##vso\[task.setvariable variable=EvalSummaryComplete\]true/);
    assert.deepEqual(result, {
        schemaVersion: 1, complete: true,
        shards: [{ shard: "area_a", attempt: 2, complete: true, reason: null }, { shard: "area_b", attempt: 1, complete: true, reason: null }],
        totals: { scenarios: 2, failed: 1, skipped: 0 },
    });
    assert.match(markdown, /results — FAILED/);
    assert.match(markdown, /\| area_a \| 2 \| Complete \|/);
    assert.deepEqual(fs.readdirSync(path.join(root, "selected")).sort(), ["eval-result-area_a-2", "eval-result-area_b-1"]);
    assert.deepEqual(index, {
        schemaVersion: 1, complete: true, expectedShards: ["area_a", "area_b"],
        attempts: [{ shard: "area_a", attempt: 2, directory: "eval-result-area_a-2" }, { shard: "area_b", attempt: 1, directory: "eval-result-area_b-1" }],
    });
});

test("a later incomplete attempt and a missing shard never fall back to complete older artifacts", (t) => {
    const root = setup(t);
    artifact(root, "area_a", 1);
    artifact(root, "area_a", 2, { junit: false });
    const { child, markdown, result, index } = runSummary(root, ["area_a", "area_missing"]);
    assert.equal(child.status, 1);
    assert.match(child.stdout, /##vso\[task.setvariable variable=EvalSummaryComplete\]false/);
    assert.equal(result.complete, false);
    assert.equal(index.complete, false);
    assert.match(markdown, /results — INCOMPLETE/);
    assert.doesNotMatch(markdown, /results — PASSED/);
    assert.equal(result.shards[0].attempt, 2);
    assert.equal(result.shards[1].attempt, null);
    assert.equal(result.totals.scenarios, 0);
    assert.deepEqual(index.expectedShards, ["area_a", "area_missing"]);
    assert.deepEqual(index.attempts, [{ shard: "area_a", attempt: 2, directory: "eval-result-area_a-2" }]);
});

test("attempt selection is numeric and includes the newest directory even when it is empty", (t) => {
    const root = setup(t);
    artifact(root, "area_a", 9);
    fs.mkdirSync(path.join(root, "download", "eval-result-area_a-10"));
    const { child, result, index } = runSummary(root, ["area_a"]);
    assert.equal(child.status, 1);
    assert.equal(result.shards[0].attempt, 10);
    assert.equal(result.totals.scenarios, 0);
    assert.equal(index.attempts[0].attempt, 10);
    assert.deepEqual(fs.readdirSync(path.join(root, "selected")), ["eval-result-area_a-10"]);
});

test("zero parsed JUnit cases make that shard incomplete even when another shard has results", (t) => {
    const root = setup(t);
    const output = artifact(root, "area_a", 1);
    fs.writeFileSync(path.join(output, "junit", "0.junit.xml"), "<testsuites />");
    artifact(root, "area_b", 1);
    const { child, result, index, markdown } = runSummary(root, ["area_a", "area_b"]);
    assert.equal(child.status, 1);
    assert.equal(result.complete, false);
    assert.equal(index.complete, false);
    assert.equal(result.totals.scenarios, 1);
    assert.match(result.shards[0].reason, /no evaluation testcases/);
    assert.equal(result.shards[1].complete, true);
    assert.match(markdown, /results — INCOMPLETE/);
});

test("bad completion metadata cannot hide available diagnostic JUnit", (t) => {
    const root = setup(t);
    const base = { schemaVersion: 1, shard: "area_a", attempt: 1, complete: true, trials: 1 };
    const markers = ["not JSON", "null", JSON.stringify({}), JSON.stringify({ ...base, schemaVersion: 2 }),
        JSON.stringify({ ...base, shard: "other" }), JSON.stringify({ ...base, attempt: 2 }),
        JSON.stringify({ ...base, complete: "true" }), JSON.stringify({ ...base, trials: 0 }),
        JSON.stringify({ ...base, trials: 1.5 }), JSON.stringify({ ...base, trials: 2 }),
        JSON.stringify({ ...base, padding: " ".repeat(64 * 1024) })];
    for (const [index, marker] of markers.entries()) {
        const directory = path.join(root, `case-${index}`);
        const output = artifact(directory, "area_a", 1);
        fs.writeFileSync(path.join(output, "shard.json"), marker);
        const selection = selectSummaryResults({ resultsRoot: path.join(directory, "download"), selectedRoot: path.join(directory, "selected"), expectedShards: ["area_a"] });
        assert.equal(selection.complete, false);
        assert.deepEqual(fs.readdirSync(path.join(directory, "selected", "eval-result-area_a-1", "junit")), ["0.junit.xml"]);
    }
});

test("missing or corrupted raw results override a complete marker without losing diagnostic cases", (t) => {
    const root = setup(t);
    for (const corrupt of [false, true]) {
        const directory = path.join(root, String(corrupt));
        artifact(directory, "area_a", 1);
        const output = artifact(directory, "area_a", 2);
        if (corrupt) fs.appendFileSync(path.join(output, "results.jsonl"), "not JSON\n");
        else fs.unlinkSync(path.join(output, "results.jsonl"));
        const { child, result, index } = runSummary(directory, ["area_a"]);
        assert.equal(child.status, 1);
        assert.equal(result.complete, false);
        assert.equal(result.shards[0].attempt, 2);
        assert.equal(result.totals.scenarios, 1);
        assert.equal(index.complete, false);
    }
});

test("legacy-layout JUnit is diagnostic only, and never causes fallback to an older attempt", (t) => {
    const root = setup(t);
    artifact(root, "area_a", 1);
    const latest = path.join(root, "download", "eval-result-area_a-2");
    fs.mkdirSync(latest);
    fs.writeFileSync(path.join(latest, "eval-results.junit.xml"), '<testsuite><testcase name="latest"><failure /></testcase></testsuite>');
    const { child, result, index, markdown } = runSummary(root, ["area_a"]);
    assert.equal(child.status, 1);
    assert.equal(result.complete, false);
    assert.deepEqual(result.totals, { scenarios: 1, failed: 1, skipped: 0 });
    assert.equal(index.attempts[0].attempt, 2);
    assert.match(markdown, /latest \(0\/1 runs passed\)/);
    assert.equal(fs.existsSync(path.join(root, "selected", "eval-result-area_a-1")), false);
});

test("failed Prepare retains incomplete summary contracts without inferring expected shards", (t) => {
    const root = setup(t);
    for (const [index, matrix] of [undefined, "", "not JSON", "{}", "[]"].entries()) {
        const directory = path.join(root, `case-${index}`);
        artifact(directory, "arrived", 1);
        const { child, markdown, result, index: shardIndex } = runSummary(directory, [], { matrix });
        assert.equal(child.status, 1);
        assert.equal(result.complete, false);
        assert.equal(result.totals.scenarios, 0);
        assert.match(markdown, /results — INCOMPLETE/);
        assert.match(markdown, /check the Prepare stage/);
        assert.deepEqual(shardIndex, { schemaVersion: 1, complete: false, expectedShards: [], attempts: [] });
        assert.deepEqual(fs.readdirSync(path.join(directory, "selected")), []);
    }
});

test("a missing artifact root reports every expected shard missing", (t) => {
    const root = setup(t);
    const { child, result, index } = runSummary(root, ["area_a", "area_b"]);
    assert.equal(child.status, 1);
    assert.equal(result.complete, false);
    assert.equal(result.totals.scenarios, 0);
    assert.ok(result.shards.every((entry) => entry.attempt === null));
    assert.deepEqual(index.expectedShards, ["area_a", "area_b"]);
    assert.deepEqual(index.attempts, []);
});

test("summary cannot publish when timeline evidence is omitted, missing or corrupt", (t) => {
    const root = setup(t);
    for (const mode of ["omitted", "missing", "corrupt"]) {
        const directory = path.join(root, mode);
        artifact(directory, "area_a", 1);
        const attempts = path.join(directory, "job-attempts.json");
        if (mode === "missing") fs.unlinkSync(attempts);
        if (mode === "corrupt") fs.writeFileSync(attempts, "not JSON");
        const output = path.join(directory, "summary", "eval-summary.md");
        const child = runCli("build-eval-summary.ts", ["--results-root", path.join(directory, "download"),
            "--selected-root", path.join(directory, "selected"), "--output-path", output,
            ...(mode === "omitted" ? [] : ["--attempts-file", attempts])], {
            TF_BUILD: "true", EVAL_EXPECTED_MATRIX: JSON.stringify({ a: { shardName: "area_a" } }),
        });
        assert.equal(child.status, 1); assert.match(child.stdout, /EvalSummaryComplete\]false/);
        assert.equal(readJson(path.join(directory, "download", "shard-index.json")).complete, false);
        assert.equal(readJson(path.join(directory, "summary", "eval-summary.json")).totals.scenarios, 1);
        assert.match(fs.readFileSync(output, "utf8"), /timeline/);
    }
});

test("selection rejects stale destinations and never treats zero expected shards as complete", (t) => {
    const root = setup(t);
    artifact(root, "area_a", 1);
    const selectedRoot = path.join(root, "selected");
    fs.mkdirSync(selectedRoot);
    fs.writeFileSync(path.join(selectedRoot, "keep.txt"), "keep me");
    assert.throws(() => selectSummaryResults({ resultsRoot: path.join(root, "download"), selectedRoot, expectedShards: ["area_a"] }), /must be empty/);
    assert.equal(fs.readFileSync(path.join(selectedRoot, "keep.txt"), "utf8"), "keep me");
    assert.equal(fs.existsSync(path.join(root, "download", "shard-index.json")), false);
    const selection = selectSummaryResults({ resultsRoot: path.join(root, "download"), selectedRoot: path.join(root, "empty-selection"), expectedShards: [] });
    assert.equal(selection.complete, false);
    assert.equal(selection.shardInput.complete, false);
    assert.deepEqual(selection.shardInput.attempts, []);
});

test("ambiguous numeric attempt names and invalid attempts are rejected", (t) => {
    const root = setup(t);
    for (const [index, names] of [["01", "1", "2"], ["0"], ["9007199254740992"]].entries()) {
        const directory = path.join(root, `case-${index}`);
        const resultsRoot = path.join(directory, "download");
        for (const name of names) fs.mkdirSync(path.join(resultsRoot, `eval-result-area_a-${name}`), { recursive: true });
        assert.throws(() => selectSummaryResults({ resultsRoot, selectedRoot: path.join(directory, "selected"), expectedShards: ["area_a"] }), /artifact attempt/i);
    }
});

test("staging CLI logs counts and sanitized warnings, never the raw invalid record", (t) => {
    const root = setup(t);
    const source = invocation(root, "source");
    const privateText = "SYNTHETIC_RAW_RECORD_DO_NOT_LOG";
    fs.appendFileSync(path.join(source, "results.jsonl"), privateText);
    const output = path.join(root, "stage");
    const child = runCli("stage-eval-results.ts", ["--results-root", source, "--output-directory", output, "--shard-name", "area_test", "--attempt", "3"]);
    assert.equal(child.status, 0, child.stderr);
    assert.match(child.stdout, /Staged area_test attempt 3: 1 trials; incomplete/);
    assert.match(child.stdout, /##vso\[task.logissue type=warning\]/);
    assert.ok(!(child.stdout + child.stderr).includes(privateText));
    assert.equal(readJson(path.join(output, "shard.json")).complete, false);
});

test("summary CLI without selected-root preserves legacy JUnit-only behavior and default output", (t) => {
    const root = setup(t);
    const results = path.join(root, "download", "eval-result-legacy");
    fs.mkdirSync(results, { recursive: true });
    fs.writeFileSync(path.join(results, "junit.xml"), '<testsuite><testcase name="ok" /></testsuite>');
    const child = runCli("build-eval-summary.ts", ["--results-root", path.join(root, "download")],
        { TF_BUILD: "true", EVAL_EXPECTED_MATRIX: "invalid matrix is irrelevant in legacy mode" }, root);
    assert.equal(child.status, 0, child.stderr);
    assert.match(fs.readFileSync(path.join(root, "eval-summary.md"), "utf8"), /results — PASSED/);
    assert.match(child.stdout, /##vso\[task.uploadsummary\]/);
    assert.doesNotMatch(child.stdout, /EvalSummaryComplete/);
    assert.equal(fs.existsSync(path.join(root, "eval-summary.json")), false);
    assert.equal(fs.existsSync(path.join(root, "download", "shard-index.json")), false);
});

test("a selected-root flag without a value cannot silently fall back to legacy mode", (t) => {
    const root = setup(t);
    const child = runCli("build-eval-summary.ts", ["--results-root", root, "--selected-root"], { TF_BUILD: "true" }, root);
    assert.equal(child.status, 1);
    assert.match(child.stderr, /Missing value for --selected-root/);
    assert.match(child.stdout, /##vso\[task.setvariable variable=EvalSummaryComplete\]false/);
    assert.equal(fs.existsSync(path.join(root, "eval-summary.md")), false);
});

test("invalid Prepare cannot reuse a stale selected directory", (t) => {
    const root = setup(t);
    const selected = path.join(root, "selected");
    fs.mkdirSync(selected);
    fs.writeFileSync(path.join(selected, "keep.txt"), "keep me");
    const child = runCli("build-eval-summary.ts", ["--results-root", path.join(root, "download"), "--selected-root", selected],
        { TF_BUILD: "true", EVAL_EXPECTED_MATRIX: "{}" }, root);
    assert.equal(child.status, 1);
    assert.match(child.stderr, /must be empty/);
    assert.match(child.stdout, /##vso\[task.setvariable variable=EvalSummaryComplete\]false/);
    assert.deepEqual(fs.readdirSync(selected), ["keep.txt"]);
    assert.equal(fs.readFileSync(path.join(selected, "keep.txt"), "utf8"), "keep me");
});