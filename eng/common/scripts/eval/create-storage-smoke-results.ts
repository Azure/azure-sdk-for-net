// Synthetic pipeline storage test only: no evaluator, MCP, model token, or LLM call.
import { mkdir, writeFile } from "node:fs/promises";
import { join } from "node:path";
import { parseArgs } from "node:util";

const { values } = parseArgs({ options: { matrix: { type: "boolean", default: false },
    "results-root": { type: "string" }, shard: { type: "string" } } });
if (process.env.TF_BUILD && process.env.BUILD_REASON !== "Manual") {
    throw new Error("Synthetic storage smoke tests must be explicitly queued manually.");
}
if (values.matrix) {
    const matrix = { smoke_a: { shardName: "smoke_a" }, smoke_b: { shardName: "smoke_b" } };
    console.log(`##vso[task.setvariable variable=matrix;isOutput=true]${JSON.stringify(matrix)}`);
} else {
    if (!values["results-root"] || !["smoke_a", "smoke_b"].includes(values.shard)) throw new Error("Provide a smoke shard and results root.");
    const root = join(values["results-root"], "synthetic-invocation");
    await mkdir(root, { recursive: true });
    // Complete failing results must be retained/published too. Error trials are
    // valid Vally records and avoid fabricating scores, tokens, or trajectories.
    const trial = { type: "trial-result", itemId: `synthetic-${values.shard}`, evalName: "synthetic-storage-smoke",
        evalFilePath: "synthetic-storage-smoke.eval.yaml", variant: "default", stimulus: `[synthetic] ${values.shard}`,
        model: "synthetic-no-llm", status: "error", durationMs: 1, trajectory: null, gradeResult: null,
        error: "Intentional synthetic result for storage validation; no evaluation was executed." };
    const summary = { type: "run-summary", evals: [{ name: "synthetic-storage-smoke", stimuliRun: 1, passed: false }] };
    await writeFile(join(root, "results.jsonl"), [trial, summary].map(item => JSON.stringify(item)).join("\n") + "\n", { flag: "wx" });
    await writeFile(join(root, "eval-results.junit.xml"),
        `<testsuites><testsuite name="synthetic-storage-smoke"><testcase name="${values.shard}" time="0.001"><failure message="Intentional synthetic trial; no LLM call"/></testcase></testsuite></testsuites>`, { flag: "wx" });
    console.log(`Created one explicitly synthetic, complete trial for ${values.shard}; no evaluation was run.`);
}