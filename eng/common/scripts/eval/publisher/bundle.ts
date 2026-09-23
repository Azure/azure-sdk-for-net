// Schema-v1 wire contract consumed by the read-only Vally dashboard. This module
// packages existing records only; it never executes an evaluation or calls an LLM.
import { createHash } from "node:crypto";
import { lstat, mkdir, readFile, readdir, realpath, writeFile } from "node:fs/promises";
import { dirname, join, resolve, sep } from "node:path";
import { strToU8, unzipSync, zipSync } from "fflate";

export const MAX_ZIP_BYTES = 32 * 1024 * 1024;
export const MAX_EXPANDED_BYTES = 128 * 1024 * 1024;
const MAX_ENTRIES = 10_000;
const MAX_TRIALS = 100_000;

export class PublicationError extends Error {
    constructor(code, message) { super(message); this.code = code; }
}

function requireValue(condition, message) {
    if (!condition) throw new PublicationError("invalid_bundle", message);
}

function parseJson(bytes) {
    try { return JSON.parse(Buffer.from(bytes).toString("utf8")); }
    catch { throw new PublicationError("invalid_bundle", "Invalid result JSON; raw evaluation content was not logged."); }
}

export const sha256 = (bytes) => createHash("sha256").update(bytes).digest("hex");

export async function boundedFile(path, maximum = MAX_EXPANDED_BYTES) {
    const stat = await lstat(path);
    requireValue(stat.isFile() && stat.size > 0 && stat.size <= maximum, "Result input must be a non-empty regular file within the size limit.");
    const bytes = await readFile(path);
    requireValue(bytes.length === stat.size, "Result input changed while being read.");
    return bytes;
}

export function validateManifest(value) {
    requireValue(value?.schemaVersion === 1 && !Array.isArray(value), "A schema-v1 manifest is required.");
    for (const key of ["adoOrganization", "adoProject", "repo", "pipeline", "runTimestamp"]) {
        requireValue(typeof value[key] === "string" && value[key].trim().length > 0 && value[key].length <= 200 &&
            value[key] === value[key].trim() && !/[\u0000-\u001f\u007f]/.test(value[key]),
        "Manifest identity fields must be bounded, trimmed non-empty strings.");
    }
    // The reader trims identity fields before deriving its canonical Blob name.
    // Reject padding here rather than publishing an archive the reader cannot import.
    requireValue(/^[a-z0-9][a-z0-9-]{0,99}$/.test(value.adoOrganization) &&
        !/[\\/:]/.test(value.adoProject) && !/^\.+$/.test(value.adoProject), "Invalid Azure DevOps organization/project identity.");
    for (const key of ["pipelineDefinitionId", "buildId"]) {
        requireValue(typeof value[key] === "string" && /^[1-9][0-9]{0,19}$/.test(value[key]), "Positive numeric pipeline/build IDs are required.");
    }
    requireValue(Number.isSafeInteger(value.summaryAttempt) && value.summaryAttempt > 0, "A positive Summary attempt is required.");
    requireValue(/^\d{4}-\d{2}-\d{2}T.*Z$/.test(value.runTimestamp) && Number.isFinite(Date.parse(value.runTimestamp)), "A UTC result timestamp is required.");
    if (value.branch !== undefined) requireValue(typeof value.branch === "string" && value.branch.length > 0 &&
        value.branch.length <= 200 && !/[\u0000-\u001f\u007f]/.test(value.branch), "Invalid source branch.");
    if (value.sourceVersion !== undefined) requireValue(typeof value.sourceVersion === "string" && /^[a-fA-F0-9]{40,64}$/.test(value.sourceVersion), "A source commit SHA is required.");
    return value;
}

export function pipelineManifest(env, now = new Date()) {
    const url = new URL(env.SYSTEM_COLLECTIONURI);
    requireValue(url.protocol === "https:" && url.hostname === "dev.azure.com" && !url.username && !url.password &&
        !url.port && !url.search && !url.hash && /^\/[a-z0-9][a-z0-9-]{0,99}\/?$/i.test(url.pathname), "Expected an Azure DevOps organization URL.");
    return validateManifest({ schemaVersion: 1, adoOrganization: url.pathname.split("/")[1].toLowerCase(),
        adoProject: env.SYSTEM_TEAMPROJECT, repo: env.BUILD_REPOSITORY_NAME,
        pipeline: env.BUILD_DEFINITIONNAME,
        pipelineDefinitionId: env.SYSTEM_DEFINITIONID, buildId: env.BUILD_BUILDID,
        summaryAttempt: Number(env.SYSTEM_JOBATTEMPT), branch: env.BUILD_SOURCEBRANCH,
        sourceVersion: env.BUILD_SOURCEVERSION, runTimestamp: now.toISOString() });
}

export function blobName(manifest) {
    validateManifest(manifest);
    return ["v1", manifest.adoOrganization, manifest.adoProject.toLowerCase(), manifest.pipelineDefinitionId,
        manifest.buildId, String(manifest.summaryAttempt)].map(encodeURIComponent).join("/") + "/dashboard-bundle.zip";
}

export function selectAttempts(index) {
    requireValue(index?.schemaVersion === 1 && index.complete === true && Array.isArray(index.expectedShards) &&
        index.expectedShards.length > 0 && Array.isArray(index.attempts), "Only a complete expected-shard index can be published.");
    const expected = new Set(index.expectedShards), selected = new Map(), seen = new Set();
    requireValue(expected.size === index.expectedShards.length && [...expected].every(name => typeof name === "string" &&
        /^[A-Za-z0-9_][A-Za-z0-9_-]{0,199}$/.test(name)), "Expected shard names must be valid and unique.");
    for (const item of index.attempts) {
        requireValue(expected.has(item.shard) && Number.isSafeInteger(item.attempt) && item.attempt > 0 &&
            item.directory === `eval-result-${item.shard}-${item.attempt}`, "Invalid shard directory or attempt.");
        const key = `${item.shard}:${item.attempt}`;
        requireValue(!seen.has(key), "Duplicate shard attempt."); seen.add(key);
        if (!selected.has(item.shard) || selected.get(item.shard).attempt < item.attempt) selected.set(item.shard, item);
    }
    requireValue([...expected].every(name => selected.has(name)), "An expected shard is missing.");
    return [...selected.values()].sort((a, b) => a.shard.localeCompare(b.shard));
}

function trialsFrom(bytes, { onSkipped } = {}) {
    const trials = [];
    for (const [line] of Buffer.from(bytes).toString("utf8").matchAll(/[^\n]+/g)) {
        if (!line.trim()) continue;
        requireValue(Buffer.byteLength(line) <= 8 * 1024 * 1024, "A JSONL record exceeds the size limit.");
        const item = parseJson(Buffer.from(line));
        requireValue(item && typeof item === "object" && !Array.isArray(item), "Invalid trial object.");
        if (["log", "run-summary"].includes(item.type)) continue;
        if (onSkipped && item.status === "skipped" && !item.experiment && [undefined, "trial-result"].includes(item.type)) {
            onSkipped(); continue;
        }
        requireValue((item.type === undefined || item.type === "trial-result") && !item.experiment &&
            ["success", "error"].includes(item.status), "Only plain-eval trial records are supported.");
        trials.push(JSON.stringify(item) + "\n");
        requireValue(trials.length <= MAX_TRIALS, "Too many trial records.");
    }
    requireValue(trials.length > 0, "Every selected shard must contain trial records.");
    return trials;
}

export function validateBundle(bytes) {
    requireValue(bytes.length > 0 && bytes.length <= MAX_ZIP_BYTES, "Bundle exceeds the 32 MiB archive limit.");
    const sizes = new Map(); let expanded = 0;
    try {
        unzipSync(bytes, { filter(file) {
            requireValue(["manifest.json", "results.jsonl", "eval-summary.md"].includes(file.name) || /^junit\/[a-zA-Z0-9_-]+\.xml$/.test(file.name), "Unexpected ZIP entry.");
            requireValue(!sizes.has(file.name.toLowerCase()), "Duplicate ZIP entry.");
            requireValue(Number.isSafeInteger(file.originalSize) && file.originalSize >= 0, "Invalid ZIP entry size.");
            expanded += file.originalSize; sizes.set(file.name.toLowerCase(), file.originalSize);
            requireValue(sizes.size <= MAX_ENTRIES && expanded <= MAX_EXPANDED_BYTES, "Bundle exceeds the extraction budget.");
            return false;
        } });
        const entries = unzipSync(bytes);
        for (const name of ["manifest.json", "results.jsonl", "eval-summary.md"]) requireValue(entries[name]?.length > 0, "Required ZIP entry is missing.");
        requireValue(Object.keys(entries).some(name => name.startsWith("junit/")), "JUnit results are missing.");
        for (const [name, content] of Object.entries(entries)) requireValue(content.length === sizes.get(name.toLowerCase()), "ZIP size mismatch.");
        const manifest = validateManifest(parseJson(entries["manifest.json"]));
        return { manifest, trials: trialsFrom(entries["results.jsonl"]).length, entries };
    } catch (error) {
        if (error instanceof PublicationError) throw error;
        throw new PublicationError("invalid_bundle", "The saved ZIP could not be validated.");
    }
}

export async function prepareBundle({ indexPath, summaryPath, outputPath, manifest }) {
    validateManifest(manifest);
    const root = await realpath(dirname(resolve(indexPath)));
    const selected = selectAttempts(parseJson(await boundedFile(indexPath, 2 * 1024 * 1024)));
    const entries = { "manifest.json": strToU8(JSON.stringify(manifest, null, 2) + "\n") };
    const trials = []; let expanded = entries["manifest.json"].length, skipped = 0;
    const add = (name, bytes) => {
        expanded += bytes.length;
        requireValue(expanded <= MAX_EXPANDED_BYTES && Object.keys(entries).length < MAX_ENTRIES, "Merged results exceed the bundle budget.");
        entries[name] = bytes;
    };
    for (const [number, item] of selected.entries()) {
        const directory = join(root, item.directory), info = await lstat(directory);
        requireValue(info.isDirectory() && (await realpath(directory)).startsWith(root + sep), "Shard directory must remain inside the artifact root.");
        const metadata = parseJson(await boundedFile(join(directory, "shard.json"), 64 * 1024));
        requireValue(metadata.schemaVersion === 1 && metadata.complete === true && metadata.shard === item.shard &&
            metadata.attempt === item.attempt, "Selected shard is incomplete or has mismatched metadata.");
        // The current dashboard imports executed trials (success/error). Vally's
        // executor-incompatible skips remain in raw shard artifacts and JUnit/
        // Markdown, not fabricated as failed executions or silently lost counts.
        const shardTrials = trialsFrom(await boundedFile(join(directory, "results.jsonl")), { onSkipped: () => { skipped++; } });
        requireValue(shardTrials.length === metadata.trials, "Shard trial count differs from its completion marker.");
        for (const text of shardTrials) {
            expanded += Buffer.byteLength(text); trials.push(text);
            requireValue(expanded <= MAX_EXPANDED_BYTES && trials.length <= MAX_TRIALS, "Merged trials exceed the bundle budget.");
        }
        const junitRoot = join(directory, "junit");
        requireValue((await lstat(junitRoot)).isDirectory(), "JUnit path must not be a symbolic link.");
        const files = (await readdir(junitRoot)).filter(name => name.endsWith(".junit.xml")).sort();
        requireValue(files.length > 0, "A selected shard has no JUnit.");
        for (const [fileNumber, name] of files.entries()) add(`junit/${number}-${fileNumber}.xml`, await boundedFile(join(junitRoot, name), MAX_EXPANDED_BYTES - expanded));
    }
    entries["results.jsonl"] = strToU8(trials.join(""));
    add("eval-summary.md", await boundedFile(summaryPath, MAX_EXPANDED_BYTES - expanded));
    // Stable timestamps prevent packaging metadata from changing otherwise equal bytes.
    const bytes = zipSync(entries, { level: 6, mtime: new Date("2020-01-01T00:00:00Z") });
    validateBundle(bytes);
    await mkdir(dirname(resolve(outputPath)), { recursive: true });
    await writeFile(outputPath, bytes, { flag: "wx" });
    return { shards: selected.length, trials: trials.length, skipped, bytes: bytes.length, sha256: sha256(bytes), blobName: blobName(manifest) };
}