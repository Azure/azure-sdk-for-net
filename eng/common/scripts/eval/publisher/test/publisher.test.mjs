import assert from "node:assert/strict";
import { spawnSync } from "node:child_process";
import { mkdtemp, mkdir, readFile, rm, writeFile } from "node:fs/promises";
import { tmpdir } from "node:os";
import { dirname, join, resolve } from "node:path";
import { test } from "node:test";
import { zipSync, strToU8 } from "fflate";
import { blobName, boundedFile, pipelineManifest, prepareBundle, selectAttempts, sha256, validateBundle } from "../bundle.mjs";
import { containerUrl, publisherIdentity, publishBundle } from "../storage.mjs";
import { notifyDashboard, refreshUrl } from "../notification.mjs";
import { publicationFailure } from "../diagnostics.mjs";

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
    const requests = [], objects = new Map(); let afterStore;
    const client = { getBlockBlobClient(name) { return {
        async uploadData(bytes, options) {
            requests.push({ name, bytes: Buffer.from(bytes), options: structuredClone(options) });
            assert.deepEqual(options.conditions, { ifNoneMatch: "*" });
            if (objects.has(name)) throw Object.assign(new Error("Already exists"), { statusCode: 412 });
            objects.set(name, { bytes: Buffer.from(bytes), metadata: { ...options.metadata }, contentLength: bytes.length });
            await afterStore?.();
        },
        async getProperties() { return objects.get(name); },
    }; } };
    return { root, path, client, requests, objects, failAfterStore(callback) { afterStore = callback; } };
}

function run(script, args, env = {}) {
    const environment = { ...process.env, ...env }; delete environment.NODE_TEST_CONTEXT;
    const child = spawnSync(process.execPath, ["--experimental-strip-types", script, ...args], {
        encoding: "utf8", env: environment, timeout: 30_000, maxBuffer: 2 * 1024 * 1024,
    });
    assert.ifError(child.error); assert.equal(child.status, 0, child.stderr + child.stdout);
    return child;
}

test("full shared shard -> summary -> one schema-v1 ZIP -> immutable Blob flow", async (t) => {
    const f = await fixture(t), scripts = resolve(import.meta.dirname, "../..");
    const downloads = join(f.root, "downloads"); await mkdir(downloads);
    for (const shard of ["smoke_a", "smoke_b"]) {
        const source = join(f.root, shard);
        run(join(scripts, "create-storage-smoke-results.ts"), ["--results-root", source, "--shard", shard], { TF_BUILD: "true", BUILD_REASON: "Manual" });
        run(join(scripts, "stage-eval-results.ts"), ["--results-root", source, "--output-directory", join(downloads, `eval-result-${shard}-1`), "--shard-name", shard, "--attempt", "1"]);
    }
    const summary = join(f.root, "summary", "eval-summary.md");
    const summaryRun = run(join(scripts, "build-eval-summary.ts"), ["--results-root", downloads, "--selected-root", join(f.root, "selected"), "--output-path", summary], {
        TF_BUILD: "true", EVAL_EXPECTED_MATRIX: JSON.stringify({ a: { shardName: "smoke_a" }, b: { shardName: "smoke_b" } }),
    });
    assert.match(summaryRun.stdout, /EvalSummaryComplete\]true/);
    const path = join(f.root, "build.zip");
    const packed = await prepareBundle({ indexPath: join(downloads, "shard-index.json"), summaryPath: summary, outputPath: path, manifest });
    assert.equal(packed.trials, 2); assert.equal(packed.shards, 2);
    const checked = validateBundle(await readFile(path));
    assert.deepEqual(checked.manifest, manifest);
    assert.equal(Object.keys(checked.entries).length, 5);
    assert.doesNotMatch(Buffer.from(checked.entries["results.jsonl"]).toString("utf8"), /run-summary/);
    assert.match(Buffer.from(checked.entries["eval-summary.md"]).toString("utf8"), /FAILED/);
    const saved = await publishBundle({ bundlePath: path, client: f.client, publisherId: "pipeline", verifyRetry: true });
    assert.equal(saved.status, "stored"); assert.equal(saved.retryVerified, true); assert.equal(f.objects.size, 1);
    assert.equal(saved.blobName, "v1/azure-sdk/internal/8255/1001/1/dashboard-bundle.zip");
    assert.equal(saved.notification.status, "not_requested");
    assert.equal(f.requests[0].options.metadata.schema, "1");
    assert.equal(f.requests[0].options.metadata.publisher, sha256(Buffer.from("pipeline")));
    assert.equal(f.requests[0].options.metadata.sha256, sha256(await readFile(path)));
});

test("lost storage response retries the identical saved ZIP and retains original metadata", async (t) => {
    const f = await fixture(t); let calls = 0;
    f.failAfterStore(() => { calls++; throw new Error("Lost response after storing"); });
    const result = await publishBundle({ bundlePath: f.path, client: f.client, publisherId: "pipeline", wait: async () => {} });
    assert.equal(calls, 1); assert.equal(result.duplicate, true); assert.equal(f.objects.size, 1);
    assert.equal(f.requests.length, 2); assert.deepEqual(f.requests[0].bytes, f.requests[1].bytes);
    assert.deepEqual(f.requests[0].options.metadata, f.requests[1].options.metadata);
});

test("skipped executor-incompatible records do not reject a completed mixed-result shard", async (t) => {
    const f = await fixture(t), artifact = join(f.root, "eval-result-a-1");
    await mkdir(join(artifact, "junit"), { recursive: true });
    const skipped = { type: "trial-result", status: "skipped", itemId: "incompatible", skipReason: "Synthetic incompatible executor" };
    await writeFile(join(artifact, "results.jsonl"), [trial, skipped, { type: "run-summary", evals: [{ name: "synthetic" }] }].map(record => JSON.stringify(record)).join("\n"));
    await writeFile(join(artifact, "shard.json"), JSON.stringify({ schemaVersion: 1, shard: "a", attempt: 1, complete: true, trials: 1 }));
    await writeFile(join(artifact, "junit", "0.junit.xml"), '<testsuites><testsuite><testcase name="executed"/><testcase name="incompatible"><skipped/></testcase></testsuite></testsuites>');
    const index = join(f.root, "shard-index.json"), summary = join(f.root, "summary.md"), output = join(f.root, "mixed.zip");
    await writeFile(index, JSON.stringify({ schemaVersion: 1, complete: true, expectedShards: ["a"], attempts: [{ shard: "a", attempt: 1, directory: "eval-result-a-1" }] }));
    await writeFile(summary, "# Mixed result\n1 executed, 1 skipped");
    const result = await prepareBundle({ indexPath: index, summaryPath: summary, outputPath: output, manifest });
    assert.equal(result.trials, 1); assert.equal(result.skipped, 1);
    const checked = validateBundle(await readFile(output)); assert.equal(checked.trials, 1);
    assert.match(Buffer.from(checked.entries["junit/0-0.xml"]).toString(), /<skipped/);
    assert.match(await readFile(join(artifact, "results.jsonl"), "utf8"), /"status":"skipped"/);
});

test("storage result is persisted before notification; failed signal does not fail stored result", async (t) => {
    const f = await fixture(t); let persisted;
    const result = await publishBundle({ bundlePath: f.path, client: f.client, publisherId: "pipeline",
        onStored: async value => { persisted = structuredClone(value); }, notify: async target => {
            assert.equal(persisted.status, "stored"); assert.equal(persisted.notification.status, "pending");
            assert.deepEqual(Object.keys(target).sort(), ["blobName", "sha256"]); assert.equal(f.objects.size, 1);
            throw new Error("Dashboard offline");
        } });
    assert.equal(result.status, "stored"); assert.equal(result.notification.status, "failed");
});

test("transient properties failure after an upload collision stays inside the retry budget", async (t) => {
    const f = await fixture(t); const original = f.client.getBlockBlobClient.bind(f.client);
    await publishBundle({ bundlePath: f.path, client: f.client, publisherId: "pipeline" });
    let reads = 0;
    const client = { getBlockBlobClient(name) { const blob = original(name); return { ...blob, async getProperties() {
        reads++; if (reads === 1) throw Object.assign(new Error("Properties unavailable"), { statusCode: 503 });
        return blob.getProperties();
    } }; } };
    const result = await publishBundle({ bundlePath: f.path, client, publisherId: "pipeline", wait: async () => {} });
    assert.equal(result.duplicate, true); assert.equal(reads, 2); assert.equal(f.objects.size, 1);
});

test("same identity cannot overwrite different content, size or publisher", async (t) => {
    const f = await fixture(t);
    const options = { bundlePath: f.path, client: f.client, publisherId: "pipeline" };
    const result = await publishBundle(options), original = f.objects.get(result.blobName);
    await assert.rejects(publishBundle({ ...options, publisherId: "other" }), { code: "submission_conflict" });
    const changed = join(f.root, "changed.zip"); await writeFile(changed, zip({ "eval-summary.md": strToU8("Different") }));
    await assert.rejects(publishBundle({ ...options, bundlePath: changed }), { code: "submission_conflict" });
    original.contentLength++;
    await assert.rejects(publishBundle(options), { code: "submission_conflict" });
    assert.equal(f.objects.size, 1); assert.deepEqual(original.bytes, await readFile(f.path));
});

test("permanent storage rejection does not retry, persist success or notify", async (t) => {
    const f = await fixture(t); let calls = 0;
    const client = { getBlockBlobClient() { return { async uploadData() { calls++; throw Object.assign(new Error("Forbidden"), { statusCode: 403 }); } }; } };
    await assert.rejects(publishBundle({ bundlePath: f.path, client, publisherId: "pipeline", onStored: () => assert.fail(), notify: () => assert.fail(), wait: () => assert.fail() }), { statusCode: 403 });
    assert.equal(calls, 1);
});

test("latest attempts, missing inputs, duplicate attempts and unsafe paths fail closed", () => {
    const base = { schemaVersion: 1, complete: true, expectedShards: ["a"], attempts: [{ shard: "a", attempt: 1, directory: "eval-result-a-1" }, { shard: "a", attempt: 2, directory: "eval-result-a-2" }] };
    assert.equal(selectAttempts(base)[0].attempt, 2);
    for (const source of [{ ...base, complete: false }, { ...base, expectedShards: ["a", "b"] }, { ...base, expectedShards: ["a", "a"] },
        { ...base, attempts: [base.attempts[0], base.attempts[0]] }, { ...base, attempts: [{ ...base.attempts[0], directory: "../elsewhere" }] }]) {
        assert.throws(() => selectAttempts(source), { code: "invalid_bundle" });
    }
});

test("ZIP allowlist, bounded records, experiments and extraction bombs are rejected", async (t) => {
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
});

test("manifest derives canonical identity from the current build and labels smoke data", () => {
    const env = { SYSTEM_COLLECTIONURI: "https://dev.azure.com/azure-sdk/", SYSTEM_TEAMPROJECT: "internal", BUILD_REPOSITORY_NAME: "Azure/azure-sdk-tools",
        BUILD_DEFINITIONNAME: "Azure-sdk-tools-workflow-eval", SYSTEM_DEFINITIONID: "8255", BUILD_BUILDID: "1001", SYSTEM_JOBATTEMPT: "2",
        BUILD_SOURCEBRANCH: "refs/heads/pilot", BUILD_SOURCEVERSION: "a".repeat(40), EVAL_PUBLISH_SMOKE_TEST: "True" };
    const result = pipelineManifest(env, new Date("2026-09-21T00:00:00Z"));
    assert.match(result.pipeline, /\[synthetic storage smoke\]/); assert.equal(result.summaryAttempt, 2);
    assert.equal(blobName({ ...result, adoProject: "Test Project" }), "v1/azure-sdk/test%20project/8255/1001/2/dashboard-bundle.zip");
    for (const collection of ["http://dev.azure.com/org", "https://example.com/org", "https://dev.azure.com/org?sig=secret"]) assert.throws(() => pipelineManifest({ ...env, SYSTEM_COLLECTIONURI: collection }));
});

test("storage and notification URLs never accept embedded credentials or arbitrary paths", () => {
    assert.equal(containerUrl("https://evaltestsummary.blob.core.windows.net/vally-results"), "https://evaltestsummary.blob.core.windows.net/vally-results");
    for (const value of ["http://evaltestsummary.blob.core.windows.net/vally-results", "https://evaltestsummary.blob.core.windows.net/vally-results?sig=secret", "https://evil.example/container", "https://user:pass@evaltestsummary.blob.core.windows.net/vally-results", "https://evaltestsummary.blob.core.windows.net/"]) assert.throws(() => containerUrl(value));
    for (const value of ["http://dashboard.example/", "https://user:pass@dashboard.example/", "https://dashboard.example/api/refresh", "https://dashboard.example/?token=secret"]) assert.throws(() => refreshUrl(value));
    assert.equal(refreshUrl("https://dashboard.example").pathname, "/api/refresh");
    assert.throws(() => publisherIdentity("invalid"), { code: "storage_identity" });
});

test("notification retries small JSON only, honors backpressure and does not retry forbidden access", async () => {
    const calls = [], waits = [], target = { blobName: blobName(manifest), sha256: "a".repeat(64) };
    await notifyDashboard({ url: "https://dashboard.example", target, getToken: async () => "test-token", wait: async ms => waits.push(ms), fetchImpl: async (url, init) => {
        calls.push(init); assert.equal(url.pathname, "/api/refresh");
        if (calls.length === 1) return new Response("", { status: 429, headers: { "retry-after": "1" } });
        return Response.json({ status: "succeeded", failureCount: 0 });
    } });
    assert.deepEqual(waits, [1000]); assert.equal(calls[0].body, calls[1].body); assert.ok(Buffer.byteLength(calls[0].body) < 2048);
    assert.equal(calls[0].headers.authorization, "Bearer test-token"); assert.equal(calls[0].redirect, "error");
    let forbidden = 0;
    await assert.rejects(notifyDashboard({ url: "https://dashboard.example", target, getToken: async () => "test-token", wait: () => assert.fail(), fetchImpl: async () => { forbidden++; return new Response("", { status: 403 }); } }), { code: "notification_failed" });
    assert.equal(forbidden, 1);
});

test("real CLI blocks PR publication before requesting a credential", () => {
    const script = resolve(import.meta.dirname, "../publish-bundle.mjs"), env = { ...process.env, TF_BUILD: "true", SYSTEM_TEAMPROJECT: "internal", BUILD_REASON: "PullRequest", BUILD_SOURCEBRANCH: "refs/pull/1/merge" };
    delete env.NODE_TEST_CONTEXT;
    const child = spawnSync(process.execPath, [script, "--bundle", "unused.zip", "--result", "unused.json"], { encoding: "utf8", env, timeout: 30_000 });
    assert.equal(child.status, 1); assert.match(child.stderr, /trusted internal, non-PR/);
});

test("failure diagnostics retain operation/code/status but never arbitrary error payloads", () => {
    assert.deepEqual(publicationFailure({ code: "AuthorizationPermissionMismatch", statusCode: 403,
        message: "secret", request: { headers: { Authorization: "Bearer secret" } }, details: { requestId: "11111111-1111-1111-1111-111111111111" } }, "publish_blob"), {
        status: "failed", operation: "publish_blob", errorCode: "AuthorizationPermissionMismatch", httpStatus: 403,
        requestId: "11111111-1111-1111-1111-111111111111",
    });
    const failure = publicationFailure({ code: "https://secret.example?token=secret", statusCode: "403", details: { requestId: "secret" } }, "acquire_storage_token");
    assert.deepEqual(failure, { status: "failed", operation: "acquire_storage_token", errorCode: "publication_failed" });
    assert.doesNotMatch(JSON.stringify(failure), /secret/);
});

test("synthetic producer is manual-only and never imports an evaluator", async () => {
    const script = resolve(import.meta.dirname, "../../create-storage-smoke-results.ts"), env = { ...process.env, TF_BUILD: "true", BUILD_REASON: "IndividualCI" };
    delete env.NODE_TEST_CONTEXT;
    const child = spawnSync(process.execPath, ["--experimental-strip-types", script, "--matrix"], { encoding: "utf8", env, timeout: 30_000 });
    assert.equal(child.status, 1); assert.match(child.stderr, /explicitly queued manually/);
    assert.doesNotMatch(await readFile(script, "utf8"), /from ["']@microsoft|execFile|spawn\(/);
});

test("pipeline keeps publication opt-in, blocks PR credentials and shares the real Summary path", async () => {
    const root = resolve(import.meta.dirname, "../../../..");
    const workflow = await readFile(join(root, "pipelines/workflow-eval.yml"), "utf8");
    const steps = await readFile(join(root, "pipelines/templates/steps/eval-publish-results.yml"), "utf8");
    const summary = await readFile(join(root, "pipelines/templates/jobs/eval-summarize.yml"), "utf8");
    const archetype = await readFile(join(root, "pipelines/templates/stages/archetype-eval.yml"), "utf8");
    assert.match(workflow, /name: publishDashboardResults[\s\S]*?default: false/);
    assert.match(workflow, /name: storageServiceConnection\s+type: string\s+default: eval-dashboard-sc/);
    assert.match(workflow, /if not\(parameters.storageSmokeTest\)/);
    assert.match(steps, /if and\(parameters.publishDashboardResults.*System.TeamProject.*internal.*PullRequest.*refs\/pull\//);
    assert.match(steps, /azureSubscription: \$\{\{ parameters.storageServiceConnection \}\}/);
    assert.match(summary, /dependsOn:|EvalExpectedMatrix:.*stageDependencies.Prepare.generate_eval_matrix/);
    assert.match(archetype, /dependsOn: \[Prepare, Eval\]/);
    assert.ok(summary.indexOf("../steps/eval-publish-results.yml") < summary.indexOf("task: PublishTestResults@2"));
    assert.match(summary, /condition: always\(\)/);
    assert.doesNotMatch(workflow + steps + archetype, /githubenterprise|msft\.ghe\.com|dashboardRepositoryServiceConnection/);
});