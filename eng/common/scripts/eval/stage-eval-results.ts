// Stage only the raw Vally stream, JUnit, and completion metadata; never include MCP
// binaries, workspace contents, or unrelated transcripts in evaluation result data.
import { parseArgs } from "node:util";
import { stageShardResults } from "./lib/shard-results.ts";

const { values } = parseArgs({
    options: {
        "results-root": { type: "string" },
        "output-directory": { type: "string" },
        "shard-name": { type: "string" },
        attempt: { type: "string" },
    },
});
if (!values["results-root"] || !values["output-directory"]) {
    throw new Error("Results and output directories are required.");
}
const result = stageShardResults({
    resultsRoot: values["results-root"],
    outputDirectory: values["output-directory"],
    shardName: values["shard-name"],
    attempt: Number(values.attempt),
});
console.log(`Staged ${result.shard} attempt ${result.attempt}: ${result.trials} trials; ${result.complete ? "complete" : "incomplete"}.`);
if (!result.complete) console.log(`##vso[task.logissue type=warning]${result.reason}`);