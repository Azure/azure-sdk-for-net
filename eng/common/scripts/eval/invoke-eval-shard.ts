// Runs one Vally eval shard and gates on the eval verdict (from results.jsonl), not the
// `vally` exit code, since vally can exit non-zero on a teardown flake after a pass.

import { spawnSync } from "node:child_process";
import path from "node:path";
import { fileURLToPath, pathToFileURL } from "node:url";
import { getVallyShardVerdict } from "./lib/verdict.ts";

// Invoke the pinned CLI with Node directly so arguments never pass through a shell.
const SCRIPT_DIR = path.dirname(fileURLToPath(import.meta.url));
const VALLY_CLI = path.join(SCRIPT_DIR, "node_modules", "@microsoft", "vally-cli", "dist", "index.js");

export function validateVallyArguments(value) {
  if (!Array.isArray(value) || value.some((arg) =>
    (typeof arg !== "string" && typeof arg !== "number") ||
    (typeof arg === "string" && arg.includes("\0")))) {
    throw new Error("Vally arguments must be an array of strings or numeric count values without null characters.");
  }
  // Deliberately exclude eval selection, plugins, output, JUnit and verdict overrides.
  const allowed = new Set(["--tag", "--runs", "--workers", "--timeout"]);
  const args = [];
  for (let index = 0; index < value.length; index += 2) {
    const option = value[index];
    if (!allowed.has(option)) {
      throw new Error(`Unsupported supplementary Vally option: ${option}`);
    }
    let argument = value[index + 1];
    const isCount = option === "--runs" || option === "--workers";
    // Azure template expansion can serialize even format('{0}', number) as a JSON number.
    if (typeof argument === "number") {
      if (!isCount || !Number.isSafeInteger(argument) || argument < 1) {
        throw new Error("Numeric values are supported only for positive integer --runs and --workers counts.");
      }
      argument = String(argument);
    }
    if (!argument || argument.startsWith("-")) {
      throw new Error(`Missing value for ${option}`);
    }
    if (isCount &&
      (!/^[1-9]\d*$/.test(argument) || !Number.isSafeInteger(Number(argument)))) {
      throw new Error(`${option} must be a positive integer.`);
    }
    args.push(option, argument);
  }
  return args;
}

/**
 * Executes the shard and returns the process exit code (0 pass, 1 fail). Side effects
 * (logging + Azure Pipelines `##vso` issues) go to the console; the verdict drives the code.
 *
 * @param {object} options
 * @param {string} options.evalArgs Whitespace-separated `-e <file>` args, exactly as the matrix emits them.
 * @param {string} options.shardName Shard name (log messages + result folder).
 * @param {string} options.outputDir `--output-dir` Vally writes results into.
 * @param {number} [options.threshold] Pass-rate gate forwarded to `vally eval --threshold`.
 * @param {(string | number)[]} [options.vallyArguments] Allowlisted arguments; numeric trial/worker counts are normalized.
 * @returns {number} 0 when the shard verdict passes, 1 otherwise.
 */
export function runShard({ evalArgs, shardName, outputDir, threshold = 0.8, vallyArguments = [] },
  { spawn = spawnSync } = {}) {
  const evalArgList = evalArgs.split(/\s+/).filter(Boolean);
  const thresholdArg = String(threshold);
  const supplementaryArgs = validateVallyArguments(vallyArguments);

  console.log(
    `Running: vally eval ${evalArgs} --junit --threshold ${thresholdArg} --output-dir "${outputDir}"`
  );

  // Do NOT abort on a non-zero exit — the verdict below is authoritative.
  // Uses spawnSync (not the vendored execFile helper) on purpose: the shard needs vally's output
  // streamed live to the log (stdio: "inherit") and must keep going on a non-zero exit, whereas
  // the exec helper captures output and rejects on failure.
  const proc = spawn(
    process.execPath,
    [
      VALLY_CLI,
      "eval",
      ...evalArgList,
      ...supplementaryArgs,
      "--junit",
      "--threshold",
      thresholdArg,
      "--output-dir",
      outputDir,
    ],
    { stdio: "inherit", shell: false }
  );
  if (proc.error) throw proc.error;
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

export function parseArgs(argv, env = process.env) {
  const options = {
    threshold: 0.8,
    vallyArguments: validateVallyArguments(JSON.parse(env.VALLY_ARGUMENTS_JSON ?? "[]")),
  };
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
