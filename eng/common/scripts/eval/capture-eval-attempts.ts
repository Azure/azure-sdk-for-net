// Records the current build's latest shard attempts; failed verification prevents publication.
import { mkdir, writeFile } from "node:fs/promises";
import { dirname, resolve } from "node:path";
import { parseArgs } from "node:util";
import { latestShardAttempts } from "./lib/job-attempts.ts";

const { values } = parseArgs({ options: { output: { type: "string" } } });
if (!values.output) throw new Error("Provide --output.");
const path = resolve(values.output); await mkdir(dirname(path), { recursive: true });
let result = { schemaVersion: 1, valid: false, attempts: {} };
try {
    const base = new URL(process.env.SYSTEM_COLLECTIONURI);
    if (base.protocol !== "https:" || base.hostname !== "dev.azure.com" || base.port || base.username || base.password || base.search || base.hash ||
        !/^\/[a-z0-9][a-z0-9-]{0,99}\/$/i.test(base.pathname) || !process.env.SYSTEM_ACCESSTOKEN ||
        !/^[a-f0-9-]{36}$/i.test(process.env.SYSTEM_TEAMPROJECTID ?? "") || !/^[1-9][0-9]*$/.test(process.env.BUILD_BUILDID ?? "")) {
        throw new Error("Current build identity/token missing.");
    }
    const url = new URL(`${process.env.SYSTEM_TEAMPROJECTID}/_apis/build/builds/${process.env.BUILD_BUILDID}/timeline?api-version=7.1`, base);
    const response = await fetch(url, { headers: { authorization: `Bearer ${process.env.SYSTEM_ACCESSTOKEN}` },
        redirect: "error", signal: AbortSignal.timeout(30_000) });
    if (!response.ok) throw new Error("Timeline could not be read.");
    result = latestShardAttempts(await response.json(), JSON.parse(process.env.EVAL_EXPECTED_MATRIX));
    console.log(`Verified current build attempts for ${Object.keys(result.attempts).length} expected shards.`);
} catch {
    console.warn("##vso[task.logissue type=warning]Latest shard attempts could not be verified; Summary will retain diagnostics but refuse publication.");
}
await writeFile(path, JSON.stringify(result, null, 2) + "\n");