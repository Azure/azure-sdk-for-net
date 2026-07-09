// Runs one Vally eval shard and gates on the eval verdict (from results.jsonl), not the
// `vally` exit code, since vally can exit non-zero on a teardown flake after a pass.

import { spawnSync } from "node:child_process";
import path from "node:path";
import { fileURLToPath, pathToFileURL } from "node:url";
import { getVallyShardVerdict } from "./lib/verdict.js";

// The pinned Vally CLI is installed next to this script (package.json + node_modules live here),
// so the npm --prefix is just this file's own directory.
const SCRIPT_DIR = path.dirname(fileURLToPath(import.meta.url));

/**
 * Executes the shard and returns the process exit code (0 pass, 1 fail). Side effects
 * (logging + Azure Pipelines `##vso` issues) go to the console; the verdict drives the code.
 *
 * @param {object} options
 * @param {string} options.evalArgs Whitespace-separated `-e <file>` args, exactly as the matrix emits them.
 * @param {string} options.shardName Shard name (log messages + result folder).
 * @param {string} options.outputDir `--output-dir` Vally writes results into.
 * @param {number} [options.threshold] Pass-rate gate forwarded to `vally eval --threshold`.
 * @returns {number} 0 when the shard verdict passes, 1 otherwise.
 */
export function runShard({ evalArgs, shardName, outputDir, threshold = 0.8 }) {
  const evalArgList = evalArgs.split(/\s+/).filter(Boolean);
  const thresholdArg = String(threshold);

  console.log(
    `Running: vally eval ${evalArgs} --junit --threshold ${thresholdArg} --output-dir "${outputDir}"`
  );

  // Do NOT abort on a non-zero exit — the verdict below is authoritative.
  const proc = spawnSync(
    "npm",
    [
      "exec",
      "--no",
      "--prefix",
      SCRIPT_DIR,
      "--",
      "vally",
      "eval",
      ...evalArgList,
      "--junit",
      "--threshold",
      thresholdArg,
      "--output-dir",
      outputDir,
    ],
    { stdio: "inherit", shell: process.platform === "win32" }
  );
  const vallyExit = proc.status ?? 1;

  const verdict = getVallyShardVerdict({ resultsDir: outputDir, threshold });
  for (const line of verdict.lines) {
    console.log(`  ${line}`);
  }

  if (!verdict.found) {
    console.log(
      `##vso[task.logissue type=error]Shard '${shardName}' produced no usable verdict (vally exit ${vallyExit}). Treating as failure.`
    );
    return 1;
  }

  if (verdict.passed) {
    if (verdict.hadExecutionErrors) {
      // Post-run teardown noise, not a mid-eval failure — verdict already passed; just log.
      console.log(
        `Shard '${shardName}' passed the pass-rate threshold; vally flagged execution errors (post-run teardown noise, not blocking).`
      );
    }
    if (vallyExit !== 0) {
      // vally's teardown can exit non-zero after the verdict is written — log, don't fail.
      console.log(
        `vally exited ${vallyExit} during post-run shutdown; shard '${shardName}' is PASSED per results.jsonl (exit code ignored).`
      );
    }
    console.log(`##[section]Shard '${shardName}' PASSED (verdict from results.jsonl).`);
    return 0;
  }

  console.log(
    `##vso[task.logissue type=error]Shard '${shardName}' FAILED - one or more evals are below the pass-rate threshold.`
  );
  return 1;
}

// ----- CLI -----

function parseArgs(argv) {
  const options = { threshold: 0.8 };
  for (let i = 0; i < argv.length; i++) {
    const next = () => argv[++i];
    switch (argv[i]) {
      case "--eval-args":
        options.evalArgs = next();
        break;
      case "--shard-name":
        options.shardName = next();
        break;
      case "--output-dir":
        options.outputDir = next();
        break;
      case "--threshold":
        options.threshold = Number(next());
        break;
      default:
        throw new Error(`Unknown argument: ${argv[i]}`);
    }
  }
  for (const required of ["evalArgs", "shardName", "outputDir"]) {
    if (!options[required]) {
      throw new Error(`Missing required argument for ${required}.`);
    }
  }
  return options;
}

if (process.argv[1] && import.meta.url === pathToFileURL(process.argv[1]).href) {
  try {
    process.exit(runShard(parseArgs(process.argv.slice(2))));
  } catch (error) {
    console.error(error.message);
    process.exit(1);
  }
}
