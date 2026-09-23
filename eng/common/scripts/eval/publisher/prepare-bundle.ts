import { parseArgs } from "node:util";
import { pipelineManifest, prepareBundle, PublicationError } from "./bundle.ts";

try {
    const { values } = parseArgs({ options: { index: { type: "string" }, summary: { type: "string" }, output: { type: "string" } } });
    if (!values.index || !values.summary || !values.output) throw new PublicationError("invalid_arguments", "Provide --index, --summary and --output.");
    const result = await prepareBundle({ indexPath: values.index, summaryPath: values.summary, outputPath: values.output,
        manifest: pipelineManifest(process.env) });
    console.log(`Prepared one build bundle: ${result.shards} selected shards, ${result.trials} trials, ${result.bytes} bytes.`);
    if (result.skipped) console.log(`${result.skipped} non-executed skipped records are retained in raw shard artifacts and JUnit/Markdown, not imported as executed dashboard outcomes.`);
} catch (error) {
    console.error(error instanceof PublicationError ? error.message : "Bundle preparation failed; inspect the selected result artifacts.");
    process.exitCode = 1;
}