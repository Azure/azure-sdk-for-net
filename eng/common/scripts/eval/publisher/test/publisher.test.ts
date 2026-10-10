// Verifies the saved archive contract and pipeline-owned publication policy, without Azure requests.
import assert from "node:assert/strict";
import { spawnSync } from "node:child_process";
import { mkdtemp, mkdir, readFile, rm, writeFile } from "node:fs/promises";
import { tmpdir } from "node:os";
import { join, resolve } from "node:path";
import { pathToFileURL } from "node:url";
import { test } from "node:test";
import { runInNewContext } from "node:vm";
import { zipSync, strToU8 } from "fflate";
import { blobName, boundedFile, isUtcTimestamp, prepareBundle, selectAttempts, sha256, validateBundle, validateManifest } from "../bundle.ts";

const manifest = { schemaVersion: 1, adoOrganization: "azure-sdk", adoProject: "internal", repo: "Azure/azure-sdk-tools",
    pipeline: "synthetic", pipelineDefinitionId: "8255", buildId: "1001", summaryAttempt: 1, runTimestamp: "2026-09-21T00:00:00.000Z" };
const trial = { type: "trial-result", itemId: "synthetic", evalName: "synthetic", stimulus: "synthetic", model: "no-llm", status: "error", error: "Synthetic", durationMs: 1, trajectory: null, gradeResult: null };
const entries = (extra = {}) => ({ "manifest.json": strToU8(JSON.stringify(manifest)), "results.jsonl": strToU8(JSON.stringify(trial)),
    "eval-summary.md": strToU8("# Synthetic test"), "junit/0.xml": strToU8('<testsuites><testsuite><testcase name="synthetic"/></testsuite></testsuites>'), ...extra });
const zip = (extra) => zipSync(entries(extra), { mtime: new Date("2020-01-01T00:00:00Z") });

async function fixture(t) {
    const root = await mkdtemp(join(tmpdir(), "eval-publisher-"));
    t.after(() => rm(root, { recursive: true, force: true }));
    const path = join(root, "saved.zip"); await writeFile(path, zip());
    return { root, path };
}

function run(script, args, env = {}, preload = []) {
    const environment = { ...process.env, ...env }; delete environment.NODE_TEST_CONTEXT;
    const child = spawnSync(process.execPath, ["--experimental-strip-types", ...preload, script, ...args], {
        encoding: "utf8", env: environment, timeout: 30_000, maxBuffer: 2 * 1024 * 1024,
    });
    assert.ifError(child.error); assert.equal(child.status, 0, child.stderr + child.stdout);
    return child;
}

test("shared shards -> saved timeline evidence -> token-free summary -> one schema-v1 ZIP", async (t) => {
    const f = await fixture(t), scripts = resolve(import.meta.dirname, "../..");
    const downloads = join(f.root, "downloads"); await mkdir(downloads);
    for (const shard of ["shard_a", "shard_b"]) {
        const source = join(f.root, shard), invocation = join(source, "invocation");
        await mkdir(invocation, { recursive: true });
        await writeFile(join(invocation, "results.jsonl"), [
            { ...trial, itemId: shard }, { type: "run-summary", evals: [{ name: trial.evalName, stimuliRun: 1, passed: false }] },
        ].map(record => JSON.stringify(record)).join("\n") + "\n");
        await writeFile(join(invocation, "eval-results.junit.xml"),
            `<testsuites><testsuite><testcase name="${shard}"><failure message="Unit test result"/></testcase></testsuite></testsuites>`);
        run(join(scripts, "lib/shard-results.ts"), ["--results-root", source, "--output-directory", join(downloads, `eval-result-${shard}-1`), "--shard-name", shard, "--attempt", "1"]);
    }
    const summary = join(f.root, "summary", "eval-summary.md"), attempts = join(f.root, "summary", "job-attempts.json");
    const mock = join(f.root, "timeline-fetch.mjs");
    await writeFile(mock, `import { Socket } from "node:net";
        Socket.prototype.connect = function() { throw new Error("Network disabled"); };
        globalThis.fetch = async (url, options) => {
            if (url.origin !== "https://dev.azure.com" || options.headers.authorization !== "Bearer fixture-token" || options.redirect !== "error") throw new Error("Unexpected timeline request");
            return Response.json({ records: ["a", "b"].map(key => ({ type: "Job", identifier: "Eval.RunShard." + key,
                attempt: 1, state: "completed", result: "failed" })) });
        };`);
    const matrix = JSON.stringify({ a: { shardName: "shard_a" }, b: { shardName: "shard_b" } });
    run(join(scripts, "lib/shard-results.ts"), ["--attempts-output", attempts], {
        EVAL_EXPECTED_MATRIX: matrix, SYSTEM_COLLECTIONURI: "https://dev.azure.com/azure-sdk/",
        SYSTEM_TEAMPROJECTID: "00000000-0000-4000-8000-000000000001", BUILD_BUILDID: "1001", SYSTEM_ACCESSTOKEN: "fixture-token",
    }, ["--import", pathToFileURL(mock).href]);
    assert.equal(JSON.parse(await readFile(attempts, "utf8")).valid, true);
    const offline = join(f.root, "no-network.mjs");
    await writeFile(offline, `globalThis.fetch = () => { throw new Error("Rendering cannot fetch"); }; delete process.env.SYSTEM_ACCESSTOKEN;`);
    const result = run(join(scripts, "build-eval-summary.ts"), ["--results-root", downloads, "--selected-root", join(f.root, "selected"),
        "--attempts-file", attempts, "--output-path", summary], { TF_BUILD: "true", EVAL_EXPECTED_MATRIX: matrix }, ["--import", pathToFileURL(offline).href]);
    assert.match(result.stdout, /EvalSummaryComplete\]true/);
    const output = join(f.root, "build.zip");
    const packed = await prepareBundle({ indexPath: join(downloads, "shard-index.json"), summaryPath: summary, outputPath: output, manifest });
    assert.equal(packed.trials, 2); assert.equal(packed.shards, 2);
    assert.equal(packed.sha256, sha256(await readFile(output)));
    assert.equal(packed.blobName, "v1/azure-sdk/internal/8255/1001/1/dashboard-bundle.zip");
    const checked = validateBundle(await readFile(output)); assert.deepEqual(checked.manifest, manifest);
    assert.equal(Object.keys(checked.entries).length, 5);
    assert.doesNotMatch(Buffer.from(checked.entries["results.jsonl"]).toString("utf8"), /run-summary/);
    assert.match(Buffer.from(checked.entries["eval-summary.md"]).toString("utf8"), /FAILED/);
    await assert.rejects(prepareBundle({ indexPath: join(downloads, "shard-index.json"), summaryPath: summary, outputPath: output, manifest }), { code: "EEXIST" });
});

test("bundle CLI takes explicit metadata, preserves the real pipeline name and saves transport identity", async (t) => {
    const f = await fixture(t), artifact = join(f.root, "eval-result-a-1");
    await mkdir(join(artifact, "junit"), { recursive: true });
    await writeFile(join(artifact, "results.jsonl"), JSON.stringify(trial));
    await writeFile(join(artifact, "shard.json"), JSON.stringify({ schemaVersion: 1, shard: "a", attempt: 1, complete: true, trials: 1 }));
    await writeFile(join(artifact, "junit", "0.junit.xml"), '<testsuite><testcase name="a"/></testsuite>');
    const index = join(f.root, "shard-index.json"), summary = join(f.root, "summary.md"), output = join(f.root, "explicit.zip");
    await writeFile(index, JSON.stringify({ schemaVersion: 1, complete: true, expectedShards: ["a"], attempts: [{ shard: "a", attempt: 1, directory: "eval-result-a-1" }] }));
    await writeFile(summary, "# Saved summary");
    run(resolve(import.meta.dirname, "../bundle.ts"), ["--index", index, "--summary", summary, "--output", output,
        "--organization", "azure-sdk", "--project", "Test Project", "--repository", "Azure/azure-sdk-tools", "--pipeline", "Real Pipeline Name",
        "--definition-id", "9999", "--build-id", "1001", "--attempt", "2", "--branch", "refs/heads/main", "--source-version", "a".repeat(40)], {
        SYSTEM_COLLECTIONURI: "https://attacker.example", SYSTEM_DEFINITIONID: "bad", BUILD_DEFINITIONNAME: "wrong",
    });
    const bytes = await readFile(output), checked = validateBundle(bytes), prepared = JSON.parse(await readFile(`${output}.json`, "utf8"));
    assert.equal(checked.manifest.pipeline, "Real Pipeline Name"); assert.equal(checked.manifest.pipelineDefinitionId, "9999");
    assert.equal(prepared.blobName, "v1/azure-sdk/test%20project/9999/1001/2/dashboard-bundle.zip");
    assert.equal(prepared.sha256, sha256(bytes)); assert.equal(prepared.bytes, bytes.length);
    assert.doesNotMatch(await readFile(resolve(import.meta.dirname, "../bundle.ts"), "utf8"), /process\.env|SYSTEM_|BUILD_|TF_BUILD/);
});

test("skips remain in raw artifacts/JUnit, not fabricated as dashboard executions", async (t) => {
    const f = await fixture(t), artifact = join(f.root, "eval-result-a-1");
    await mkdir(join(artifact, "junit"), { recursive: true });
    const skipped = { type: "trial-result", status: "skipped", itemId: "incompatible", skipReason: "Synthetic incompatible executor" };
    await writeFile(join(artifact, "results.jsonl"), [trial, skipped, { type: "run-summary", evals: [{ name: "synthetic" }] }].map(record => JSON.stringify(record)).join("\n"));
    await writeFile(join(artifact, "shard.json"), JSON.stringify({ schemaVersion: 1, shard: "a", attempt: 1, complete: true, trials: 1 }));
    await writeFile(join(artifact, "junit", "0.junit.xml"), '<testsuite><testcase name="executed"/><testcase name="incompatible"><skipped/></testcase></testsuite>');
    const index = join(f.root, "shard-index.json"), summary = join(f.root, "summary.md"), output = join(f.root, "mixed.zip");
    await writeFile(index, JSON.stringify({ schemaVersion: 1, complete: true, expectedShards: ["a"], attempts: [{ shard: "a", attempt: 1, directory: "eval-result-a-1" }] }));
    await writeFile(summary, "# Mixed result\n1 executed, 1 skipped");
    const result = await prepareBundle({ indexPath: index, summaryPath: summary, outputPath: output, manifest });
    assert.equal(result.trials, 1); assert.equal(result.skipped, 1);
    const checked = validateBundle(await readFile(output)); assert.equal(checked.trials, 1);
    assert.match(Buffer.from(checked.entries["junit/0-0.xml"]).toString(), /<skipped/);
    assert.match(await readFile(join(artifact, "results.jsonl"), "utf8"), /"status":"skipped"/);
});

test("latest attempts, missing inputs, duplicate attempts and unsafe paths fail closed", () => {
    const base = { schemaVersion: 1, complete: true, expectedShards: ["a"], attempts: [{ shard: "a", attempt: 1, directory: "eval-result-a-1" }, { shard: "a", attempt: 2, directory: "eval-result-a-2" }] };
    assert.equal(selectAttempts(base)[0].attempt, 2);
    for (const source of [{ ...base, complete: false }, { ...base, expectedShards: ["a", "b"] }, { ...base, expectedShards: ["a", "a"] },
        { ...base, attempts: [base.attempts[0], base.attempts[0]] }, { ...base, attempts: [{ ...base.attempts[0], directory: "../elsewhere" }] }]) {
        assert.throws(() => selectAttempts(source), { code: "invalid_bundle" });
    }
});

test("ZIP allowlist, corrupt records, experiments and extraction bombs are rejected without logging content", async (t) => {
    const f = await fixture(t);
    for (const extra of [{ "../escape": strToU8("no") }, { "manifest.JSON": strToU8("no") }, { "bin/mcp.dll": strToU8("no") },
        { "results.jsonl": strToU8('{"secret":"do not log"') }, { "results.jsonl": strToU8(JSON.stringify({ ...trial, experiment: { runId: "x" } })) },
        { "results.jsonl": new Uint8Array() }, { "manifest.json": strToU8(JSON.stringify({ ...manifest, buildId: "0" })) }]) {
        assert.throws(() => validateBundle(zip(extra)), { code: "invalid_bundle" });
    }
    const bomb = Buffer.from(zip()), start = bomb.indexOf(Buffer.from([0x50, 0x4b, 0x01, 0x02]));
    bomb.writeUInt32LE(128 * 1024 * 1024 + 1, start + 24);
    assert.throws(() => validateBundle(bomb), { code: "invalid_bundle" });
    await assert.rejects(boundedFile(f.path, 1), { code: "invalid_bundle" });
    assert.throws(() => validateBundle(zip({ "results.jsonl": strToU8('{"secret":"do not log"') })), error => !error.message.includes("secret"));
    assert.equal(validateBundle(zip({ "results.jsonl": strToU8(JSON.stringify(trial) + "\r\n") })).trials, 1);
});

test("canonical identity and UTC calendar validation match the reader", () => {
    assert.equal(blobName({ ...manifest, adoProject: "Test Project" }), "v1/azure-sdk/test%20project/8255/1001/1/dashboard-bundle.zip");
    for (const key of ["adoOrganization", "adoProject", "repo", "pipeline", "runTimestamp"]) for (const padded of [` ${manifest[key]}`, `${manifest[key]} `]) {
        assert.throws(() => validateManifest({ ...manifest, [key]: padded }), { code: "invalid_bundle" });
    }
    for (const branch of [" ", " refs/heads/main", "refs/heads/main "]) assert.throws(() => validateManifest({ ...manifest, branch }), { code: "invalid_bundle" });
    assert.throws(() => blobName({ ...manifest, adoProject: "\u754c".repeat(200) }), { code: "invalid_bundle" });
    for (const timestamp of ["2024-02-29T23:59:59Z", "2026-09-24T12:34:56.1234567Z", "2026-01-01T00:00:00Z"]) assert.equal(isUtcTimestamp(timestamp), true);
    for (const timestamp of ["2026-02-30T00:00:00Z", "2026-02-29T00:00:00Z", "2026-04-31T00:00:00Z", "2026-01-01T24:00:00Z", "2026-01-01T00:00:00+00:00", "2026-01-01T00:00:00", "not a date", null]) {
        assert.equal(isUtcTimestamp(timestamp), false);
        assert.throws(() => validateManifest({ ...manifest, runTimestamp: timestamp }), { code: "invalid_bundle" });
    }
});

test("the archive package has one locked public dependency, not an Azure SDK transport", async () => {
    const packageJson = JSON.parse(await readFile(resolve(import.meta.dirname, "../package.json"), "utf8"));
    const lock = JSON.parse(await readFile(resolve(import.meta.dirname, "../package-lock.json"), "utf8"));
    assert.deepEqual(packageJson.dependencies, { fflate: "0.8.3" });
    assert.deepEqual(Object.keys(lock.packages), ["", "node_modules/fflate"]);
    assert.equal(lock.packages["node_modules/fflate"].resolved, "https://registry.npmjs.org/fflate/-/fflate-0.8.3.tgz");
    assert.match(lock.packages["node_modules/fflate"].integrity, /^sha512-[A-Za-z0-9+/]{86}==$/);
});

test("PR CI runs every lightweight Node suite and discovers tagged publisher PowerShell tests", async () => {
    const root = resolve(import.meta.dirname, "../../../../..");
    const ci = await readFile(join(root, "common-tests/ci.yml"), "utf8");
    assert.match(ci, /TargetDirectory: eng\/common-tests/);
    assert.match(ci, /TargetTags: UnitTest,IntegrationTest/);
    assert.match(ci, /CustomTestSteps:[\s\S]*config.Filter.Tag = @\('UnitTest', 'IntegrationTest'\)/);
    assert.match(ci, /if \(\$result.FailedCount -gt 0\) \{ throw/);
    assert.match(ci, /node --experimental-strip-types --test test\/\*\.test\.ts publisher\/test\/\*\.test\.ts/);
    assert.match(ci, /npm ci --prefix publisher --omit=dev --ignore-scripts/);
    assert.doesNotMatch(ci, /vally eval|azureSubscription:|npm ci --userconfig/);
    const pester = await readFile(join(root, "common-tests/eval/Publish-EvalResults.Tests.ps1"), "utf8");
    assert.match(pester, /Describe 'Azure CLI evaluation publication' -Tag 'UnitTest'/);
    assert.match(pester, /Microsoft.PowerShell.Utility\\Invoke-WebRequest/);
    assert.match(pester, /server\.listen\(0,'127\.0\.0\.1'/);
    const publisher = JSON.parse(await readFile(resolve(import.meta.dirname, "../package.json"), "utf8"));
    assert.match(publisher.scripts.test, /common-tests\/eval\/Publish-EvalResults.Tests.ps1/);
});

test("pipeline separates token-bearing attempt verification from rendering and uploads before the score gate", async () => {
    const root = resolve(import.meta.dirname, "../../../..");
    const summary = await readFile(join(root, "pipelines/templates/jobs/eval-summarize.yml"), "utf8");
    const verification = summary.slice(summary.indexOf("# Only attempt verification"), summary.indexOf('"$(Build.SourcesDirectory)/eng/common/scripts/eval/build-eval-summary.ts"'));
    assert.match(verification, /--attempts-output/); assert.match(verification, /SYSTEM_ACCESSTOKEN: \$\(System.AccessToken\)/);
    const rendering = summary.slice(summary.indexOf('"$(Build.SourcesDirectory)/eng/common/scripts/eval/build-eval-summary.ts"'));
    assert.match(rendering, /--attempts-file/); assert.doesNotMatch(rendering, /SYSTEM_ACCESSTOKEN/);
    assert.ok(summary.indexOf("../steps/eval-publish-results.yml") < summary.indexOf("task: PublishTestResults@2"));
    const steps = await readFile(join(root, "pipelines/templates/steps/eval-publish-results.yml"), "utf8");
    assert.doesNotMatch(steps, /registryUrl:|azure-sdk-tools\/npm\/registry/);
    assert.match(steps, /scriptType: pscore[\s\S]*scriptLocation: scriptPath[\s\S]*Publish-EvalResults\.ps1/);
    assert.match(steps, /azureSubscription: eval-dashboard-sc/);
    assert.match(steps, /-StorageAccountName "\$\(EvalStorageAccountName\)"/);
    assert.doesNotMatch(await readFile(resolve(import.meta.dirname, "../Publish-EvalResults.ps1"), "utf8"), /TF_BUILD|SYSTEM_|BUILD_|System\.DefinitionId/);
});

test("one checkbox gates trusted-run egress; owner configuration additionally gates runtime upload", async () => {
    const root = resolve(import.meta.dirname, "../../../..");
    const archetype = await readFile(join(root, "pipelines/templates/stages/archetype-eval.yml"), "utf8");
    const steps = await readFile(join(root, "pipelines/templates/steps/eval-publish-results.yml"), "utf8");
    const gate = source => source.match(/\$\{\{ if (and\(parameters\.publishDashboardResults, .+\)) \}\}:/)?.[1];
    const networkGate = gate(archetype), uploadGate = gate(steps);
    assert.ok(networkGate); assert.equal(networkGate, uploadGate);
    assert.doesNotMatch(networkGate, /System.DefinitionId|EvalStorageAccountName/);
    const runtime = steps.match(/      condition: (and\(.+\))/)?.[1]; assert.ok(runtime);
    const evaluate = (expression, variables, enabled = true, succeeds = true) => runInNewContext(expression.replace(/\bin\(/g, "oneOf("), {
        variables, parameters: { publishDashboardResults: enabled }, succeeded: () => succeeds,
        and: (...values) => values.every(Boolean), eq: (a, b) => String(a ?? "").toLowerCase() === String(b ?? "").toLowerCase(),
        ne: (a, b) => String(a ?? "").toLowerCase() !== String(b ?? "").toLowerCase(),
        oneOf: (value, ...items) => items.some(item => String(value ?? "").toLowerCase() === String(item).toLowerCase()),
    });
    const base = { "System.CollectionUri": "https://dev.azure.com/azure-sdk/", "System.TeamProject": "internal", "Build.Repository.Name": "Azure/azure-sdk-tools",
        "Build.SourceBranch": "refs/heads/main", "Build.Reason": "Manual", "EvalSummaryComplete": "true", "EvalStorageAccountName": "evaltestsummary" };
    assert.equal(evaluate(networkGate, base), true); assert.equal(evaluate(runtime, base), true);
    assert.equal(evaluate(networkGate, base, false), false); assert.equal(evaluate(runtime, base, true, false), false);
    for (const account of [undefined, ""]) assert.equal(evaluate(runtime, { ...base, EvalStorageAccountName: account }), false);
    assert.equal(evaluate(runtime, { ...base, EvalSummaryComplete: "false" }), false);
    for (const [key, value] of [["System.CollectionUri", "https://dev.azure.com/other/"], ["System.TeamProject", "public"],
        ["Build.Repository.Name", "Azure/azure-rest-api-specs"], ["Build.Reason", "PullRequest"], ["Build.Reason", "ResourceTrigger"],
        ...["refs/pull/1/merge", "refs/heads/feature", "refs/heads/feature/main", "refs/tags/main", ""].map(branch => ["Build.SourceBranch", branch])]) {
        const variables = { ...base, [key]: value };
        assert.equal(evaluate(networkGate, variables), false); assert.equal(evaluate(runtime, variables), false);
    }
    for (const id of ["8255", "9999"]) assert.equal(evaluate(networkGate, { ...base, "System.DefinitionId": id }), true, "Definition IDs are archive identity, not shared policy");
});

test("redirect retains Default Deny/CFS and shared publication defaults stay off", async () => {
    const root = resolve(import.meta.dirname, "../../../..");
    const redirect = await readFile(join(root, "../pipelines/templates/stages/1es-redirect.yml"), "utf8");
    assert.match(redirect, /networkIsolationPolicy: DefaultDeny, CFSClean, CFSClean2, CFSClean3, AzureStorage/);
    assert.match(redirect, /parameters.AllowAzureStorage.*parameters.Use1ESOfficial.*System.TeamProject.*PullRequest.*refs\/pull\//);
    for (const path of ["templates/steps/eval-publish-results.yml", "templates/jobs/eval-summarize.yml", "templates/stages/archetype-eval.yml"]) {
        assert.match(await readFile(join(root, "pipelines", path), "utf8"), /name: publishDashboardResults\s+type: boolean\s+default: false/);
    }
});

for (const tier of ["workflow", "skill", "live"]) test(`${tier} forwards only the checkbox and preserves its evaluation tier`, async () => {
    const root = resolve(import.meta.dirname, "../../../.."), content = await readFile(join(root, `pipelines/${tier}-eval.yml`), "utf8");
    assert.match(content, /createDashboardBundle: true/); assert.match(content, /name: publishDashboardResults[\s\S]*default: true/);
    assert.ok(content.includes("publishDashboardResults: ${{ parameters.publishDashboardResults }}"));
    assert.doesNotMatch(content, /eval-dashboard\.yml|EvalDashboardPublicationEnabled|System.DefinitionId|autoPublishDashboardResults|allowAzureStorageNetworkAccess/);
    const inputs = content.slice(content.indexOf("\nparameters:\n"), content.indexOf("\nvariables:\n"));
    assert.deepEqual([...inputs.matchAll(/- name: (\w+)/g)].map(match => match[1]), ["publishDashboardResults"]);
    assert.match(content, /group: AzSDK_Eval_Variable_group/); assert.match(content, new RegExp(`TestType: ${tier === "live" ? "live" : "mock"}`));
    if (tier === "live") { assert.match(content, /UseAzSdkAuthentication: true/); assert.match(content, /failOnFailedTests: true/); }
    if (tier === "skill") assert.match(content, /vallyRoot: \.github\/skills/);
});