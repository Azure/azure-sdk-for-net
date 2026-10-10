// Dependency-free artifact staging/selection shared by eval pipeline consumers.
// Publish an incomplete marker even when an invocation fails before producing results;
// a later incomplete attempt must never fall back to an older successful attempt.
import fs from "node:fs";
import path from "node:path";
import { setTimeout as delay } from "node:timers/promises";
import { parseArgs } from "node:util";
import { pathToFileURL } from "node:url";
import { globFiles } from "./glob.ts";

// No individual result can exceed the bundle's expanded-size ceiling. Check before
// copying/reading whole files; completion metadata should never approach this size.
const MAX_RESULT_BYTES = 128 * 1024 * 1024;
const MAX_METADATA_BYTES = 64 * 1024;
const MISSING_RESULTS = "The invocation is missing trials, JUnit, or its final run-summary.";

function validShard(name) {
    return typeof name === "string" && /^[A-Za-z0-9_][A-Za-z0-9_-]{0,199}$/.test(name);
}

export function expectedShardsFromMatrix(value) {
    const matrix = typeof value === "string" ? JSON.parse(value) : value;
    if (!matrix || typeof matrix !== "object" || Array.isArray(matrix)) {
        throw new Error("The Prepare stage's eval matrix is required to check result completeness.");
    }
    const names = Object.values(matrix).map((entry) => entry?.shardName);
    if (!names.length || names.some((name) => !validShard(name)) || new Set(names).size !== names.length) {
        throw new Error("The eval matrix must contain unique, non-empty shard names.");
    }
    return names.sort();
}

// The artifact list cannot reveal a newer retry that lost its agent before publishing.
export function latestShardAttempts(timeline, matrix) {
    expectedShardsFromMatrix(matrix);
    if (!Array.isArray(timeline?.records)) throw new Error("The current build timeline is required.");
    const attempts = {};
    for (const [key, entry] of Object.entries(matrix)) {
        if (!validShard(key)) throw new Error("Invalid matrix leg identity.");
        const jobs = timeline.records.filter(record => record?.type === "Job" && record.identifier === `Eval.RunShard.${key}`);
        for (const record of jobs) {
            if (!Number.isSafeInteger(record.attempt) || record.attempt < 1) throw new Error("Invalid timeline attempt.");
            const current = { attempt: record.attempt, complete: record.state === "completed" &&
                ["succeeded", "succeededWithIssues", "failed"].includes(record.result) };
            const previous = attempts[entry.shardName];
            if (previous?.attempt === current.attempt && previous.complete !== current.complete) throw new Error("Ambiguous timeline attempt.");
            if (!previous || previous.attempt < current.attempt) attempts[entry.shardName] = current;
        }
        if (!attempts[entry.shardName]) throw new Error("An expected matrix job is missing from the current build timeline.");
    }
    return { schemaVersion: 1, valid: true, attempts };
}

export async function readShardAttempts(env, { fetchImpl = fetch, wait = delay } = {}) {
    const base = new URL(env.SYSTEM_COLLECTIONURI), matrix = JSON.parse(env.EVAL_EXPECTED_MATRIX);
    expectedShardsFromMatrix(matrix);
    if (base.protocol !== "https:" || base.hostname !== "dev.azure.com" || base.port || base.username || base.password || base.search || base.hash ||
        !/^\/[a-z0-9][a-z0-9-]{0,99}\/$/i.test(base.pathname) || !env.SYSTEM_ACCESSTOKEN ||
        !/^[a-f0-9-]{36}$/i.test(env.SYSTEM_TEAMPROJECTID ?? "") || !/^[1-9][0-9]*$/.test(env.BUILD_BUILDID ?? "")) {
        throw new Error("Current build identity/token missing.");
    }
    const url = new URL(`${env.SYSTEM_TEAMPROJECTID}/_apis/build/builds/${env.BUILD_BUILDID}/timeline?api-version=7.1`, base);
    for (let attempt = 0; attempt < 3; attempt++) {
        let response;
        try {
            response = await fetchImpl(url, { headers: { authorization: `Bearer ${env.SYSTEM_ACCESSTOKEN}` },
                redirect: "error", signal: AbortSignal.timeout(30_000) });
            if (!response.ok) throw new Error("Timeline could not be read.");
            return latestShardAttempts(await response.json(), matrix);
        } catch (error) {
            if ((response && ![408, 429, 500, 502, 503, 504].includes(response.status)) || attempt === 2) throw error;
        } finally { await response?.body?.cancel().catch(() => {}); }
        const header = response?.headers?.get("retry-after"), seconds = Number(header);
        const milliseconds = header && Number.isFinite(seconds) ? seconds * 1000 : header ? Date.parse(header) - Date.now() : NaN;
        await wait(Math.min(30_000, Math.max(0, Number.isFinite(milliseconds) ? milliseconds : 1000 * 2 ** attempt)));
    }
}

function emptyDirectory(directory) {
    fs.mkdirSync(directory, { recursive: true });
    if (!fs.lstatSync(directory).isDirectory() || fs.readdirSync(directory).length) {
        throw new Error(`Output directory must be empty and not a symbolic link: ${directory}`);
    }
}

function checkResultFile(file, limit = MAX_RESULT_BYTES) {
    const stat = fs.lstatSync(file);
    if (!stat.isFile() || stat.size > limit) {
        throw new Error("Result files must be regular files within the size limit.");
    }
}

function readResultFile(file, limit = MAX_RESULT_BYTES) {
    checkResultFile(file, limit);
    return fs.readFileSync(file, "utf8");
}

function copyResultFile(source, destination) {
    checkResultFile(source);
    fs.copyFileSync(source, destination, fs.constants.COPYFILE_EXCL);
}

function inspectInvocation(file) {
    const result = { complete: false, trials: 0, reason: MISSING_RESULTS };
    try {
        let summary;
        // Iterate lines without allocating an array proportional to the newline count.
        for (const [line] of readResultFile(file).matchAll(/[^\n]+/g)) {
            if (!line.trim()) continue;
            const record = JSON.parse(line);
            if (!record || typeof record !== "object" || Array.isArray(record)) {
                throw new Error("Invalid JSONL record.");
            }
            if (record.type === "run-summary") summary = record;
            else if ((record.type === undefined || record.type === "trial-result") && ["success", "error"].includes(record.status)) {
                result.trials++;
                summary = undefined;
            }
        }
        result.complete = Boolean(result.trials && Array.isArray(summary?.evals) && summary.evals.length);
        result.reason = result.complete ? null : MISSING_RESULTS;
    } catch {
        // Do not log JSON.parse errors: they can include raw evaluation content.
        result.reason = "The invocation contains incomplete, invalid, unreadable, or oversized JSONL.";
    }
    return result;
}

export function stageShardResults({ resultsRoot, outputDirectory, shardName, attempt }) {
    if (!validShard(shardName) || !Number.isSafeInteger(attempt) || attempt < 1) {
        throw new Error("A valid shard name and positive job attempt are required.");
    }
    emptyDirectory(outputDirectory);
    fs.mkdirSync(path.join(outputDirectory, "junit"));
    const metadata = {
        schemaVersion: 1, shard: shardName, attempt, complete: false, trials: 0,
        reason: "No results.jsonl was produced.",
    };
    const marker = path.join(outputDirectory, "shard.json");
    fs.writeFileSync(marker, JSON.stringify(metadata, null, 2) + "\n");
    try {
        // Match lib/verdict.ts exactly: globFiles sorts paths, and the last path wins
        // an mtime tie. localeCompare sorting would choose a different invocation.
        let source;
        let newest = -Infinity;
        for (const file of globFiles(resultsRoot, "**/results.jsonl")) {
            const mtime = fs.statSync(file).mtimeMs;
            if (mtime >= newest) {
                newest = mtime;
                source = file;
            }
        }
        if (source) {
            const junit = globFiles(path.dirname(source), "**/*.junit.xml");
            let junitComplete = junit.length > 0;
            for (const [index, file] of junit.entries()) {
                try {
                    copyResultFile(file, path.join(outputDirectory, "junit", `${index}.junit.xml`));
                } catch {
                    junitComplete = false;
                }
            }
            const stagedResults = path.join(outputDirectory, "results.jsonl");
            copyResultFile(source, stagedResults);
            // Inspect the staged snapshot, not a source file that could still change.
            Object.assign(metadata, inspectInvocation(stagedResults));
            if (!junitComplete) {
                metadata.complete = false;
                metadata.reason ??= MISSING_RESULTS;
            }
        }
    } catch {
        metadata.complete = false;
        metadata.reason = "The invocation contains unreadable or oversized result files.";
    }
    fs.writeFileSync(marker, JSON.stringify(metadata, null, 2) + "\n");
    return metadata;
}

export function selectSummaryResults({ resultsRoot, selectedRoot, expectedShards, jobAttempts }) {
    if (!Array.isArray(expectedShards) || expectedShards.some((name) => !validShard(name)) ||
        new Set(expectedShards).size !== expectedShards.length) {
        throw new Error("Expected shards must be unique, valid shard names from Prepare.");
    }
    emptyDirectory(selectedRoot);
    const expected = new Set(expectedShards);
    const selected = new Map();
    const seen = new Set();
    for (const entry of fs.readdirSync(resultsRoot, { withFileTypes: true })) {
        const match = /^eval-result-(.+)-(\d+)$/.exec(entry.name);
        if (!match || !expected.has(match[1])) continue;
        if (!entry.isDirectory()) throw new Error("Shard artifact paths must be directories, not files or symbolic links.");
        const attempt = Number(match[2]);
        if (!Number.isSafeInteger(attempt) || attempt < 1) throw new Error("Invalid shard artifact attempt.");
        const identity = `${match[1]}:${attempt}`;
        if (seen.has(identity)) throw new Error(`Duplicate artifact attempt for ${match[1]}.`);
        seen.add(identity);
        const previous = selected.get(match[1]);
        if (!previous || previous.attempt < attempt) {
            selected.set(match[1], { shard: match[1], attempt, directory: entry.name });
        }
    }
    const status = [];
    for (const shard of expectedShards) {
        const selectedAttempt = selected.get(shard);
        if (!selectedAttempt) {
            status.push({ shard, attempt: null, complete: false, reason: "No artifact was published." });
            continue;
        }
        const directory = path.join(resultsRoot, selectedAttempt.directory);
        const junit = globFiles(directory, "junit/*.junit.xml");
        let complete = false;
        let reason = "The artifact is missing valid completion metadata or result files.";
        try {
            const metadata = JSON.parse(readResultFile(path.join(directory, "shard.json"), MAX_METADATA_BYTES));
            complete = metadata.schemaVersion === 1 && metadata.shard === shard && metadata.attempt === selectedAttempt.attempt &&
                metadata.complete === true && Number.isSafeInteger(metadata.trials) && metadata.trials > 0 && junit.length > 0;
            if (complete) {
                const invocation = inspectInvocation(path.join(directory, "results.jsonl"));
                complete = invocation.complete && invocation.trials === metadata.trials;
            }
            if (!complete && metadata.complete === false) reason = "The latest shard attempt did not produce a complete invocation.";
        } catch { /* Retain available JUnit below, but do not adopt an incomplete artifact for upload. */ }
        if (jobAttempts?.valid !== true || jobAttempts.schemaVersion !== 1 ||
            jobAttempts.attempts?.[shard]?.attempt !== selectedAttempt.attempt || jobAttempts.attempts[shard].complete !== true) {
            complete = false;
            reason = "The latest timeline job attempt has no matching complete artifact, or its status could not be verified.";
        }
        // The Tests tab and Markdown use the SAME selected attempts as the bundle.
        // Old-layout JUnit remains diagnostic; old artifacts are never upload-ready.
        const files = junit.length ? junit : globFiles(directory, "**/*.junit.xml");
        const output = path.join(selectedRoot, selectedAttempt.directory, "junit");
        fs.mkdirSync(output, { recursive: true });
        for (const [index, file] of files.entries()) {
            try {
                copyResultFile(file, path.join(output, `${index}.junit.xml`));
            } catch {
                complete = false;
                reason = "The selected JUnit result files are unreadable or exceed the size limit.";
            }
        }
        status.push({ shard, attempt: selectedAttempt.attempt, complete, reason: complete ? null : reason });
    }
    const complete = status.length > 0 && status.every((entry) => entry.complete);
    const shardInput = {
        schemaVersion: 1, complete, expectedShards,
        attempts: [...selected.values()].sort((a, b) => a.shard.localeCompare(b.shard)),
    };
    fs.writeFileSync(path.join(resultsRoot, "shard-index.json"), JSON.stringify(shardInput, null, 2) + "\n");
    return { complete, status, shardInput };
}

if (process.argv[1] && import.meta.url === pathToFileURL(process.argv[1]).href) {
    try {
        const { values } = parseArgs({ options: { "results-root": { type: "string" }, "output-directory": { type: "string" },
            "shard-name": { type: "string" }, attempt: { type: "string" }, "attempts-output": { type: "string" } } });
        if (values["attempts-output"]) {
            let result = { schemaVersion: 1, valid: false, attempts: {} };
            try { result = await readShardAttempts(process.env); }
            catch { console.log("##vso[task.logissue type=warning]Current build attempts could not be verified; no complete bundle will be published."); }
            fs.mkdirSync(path.dirname(path.resolve(values["attempts-output"])), { recursive: true });
            fs.writeFileSync(values["attempts-output"], JSON.stringify(result, null, 2) + "\n");
        } else {
            if (!values["results-root"] || !values["output-directory"]) throw new Error("Results and output directories are required.");
            const result = stageShardResults({ resultsRoot: values["results-root"], outputDirectory: values["output-directory"],
                shardName: values["shard-name"], attempt: Number(values.attempt) });
            console.log(`Staged ${result.shard} attempt ${result.attempt}: ${result.trials} trials; ${result.complete ? "complete" : "incomplete"}.`);
            if (!result.complete) console.log(`##vso[task.logissue type=warning]${result.reason}`);
        }
    } catch (error) { console.error(error.message); process.exitCode = 1; }
}