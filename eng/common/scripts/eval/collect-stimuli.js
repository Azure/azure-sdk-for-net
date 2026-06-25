// Discovers Vally eval files and emits an Azure Pipelines matrix for fan-out sharding.
//
// Port of Split-EvalSuite.ps1. Vally has no `list` command, so scenario discovery is a
// filesystem glob of the same paths the suite uses. This script globs one or more
// eval-file patterns (relative to one or more eval roots) and emits the result as an
// Azure Pipelines matrix object on an output variable so a downstream stage can fan out
// one job per shard.
//
// Multiple eval roots are supported so the pipeline can collect evals scattered across
// several folders in a single matrix — pass `--eval-root` once per root. Pass `--path-base`
// to anchor every emitted `-e` path to one base (the run root the shard executes from), so
// the paths resolve even when a root sits outside that base. Custom suites are selected via
// repeated `--pattern`.
//
// Granularity is a dial controlled by --shard-by:
//   - file : one shard per eval file (finest; default).
//   - area : one shard per `area` tag (coarser; collapses many files into a handful of
//            jobs once job-startup overhead dominates). No pipeline edits needed to switch.
//
// Each shard leg exposes two variables to the matrix job:
//   - shardName : a filesystem-safe identifier (used for per-shard result folders)
//   - evalArgs  : the `-e <file>` argument string passed verbatim to `vally eval`
//                 (one file in 'file' mode, every file of an area in 'area' mode)

import fs from "node:fs";
import path from "node:path";
import { pathToFileURL } from "node:url";
import { globFiles } from "./lib/glob.js";

// Default "mock vertical": unit tools + mock workflow scenarios. The live tier is
// deliberately excluded so the default matrix stays hermetic.
const DEFAULT_PATTERNS = [
  "evals/tools/*.eval.yaml",
  "evals/workflow-scenarios/mock/*.eval.yaml",
];

const SANITIZE = /[^A-Za-z0-9]/g;

// Discover eval files across every root, de-duplicated. Overlapping globs (a broad and a
// narrow pattern that both match a file) would otherwise yield the same eval twice, which
// in 'area' mode emits a duplicate `-e <file>` and in 'file' mode collides on shard name.
//
// Each file's `relative` (the value handed to `vally eval -e`) is computed against
// `pathBase` when supplied, otherwise against the root it was found under. The shard runs
// `vally eval` from a single working directory, so anchoring every path to that one base
// (the run root) keeps `-e` resolvable even when evals are scattered across roots that are
// NOT the working dir — the path may then legitimately start with `../`.
export function getEvalFiles(roots, patterns, pathBase = null) {
  const seen = new Set(); // case-insensitive, matching the PowerShell OrdinalIgnoreCase set
  const files = [];
  const base = pathBase ? path.resolve(pathBase) : null;

  for (const root of roots) {
    const resolvedRoot = path.resolve(root);
    for (const glob of patterns) {
      for (const full of globFiles(resolvedRoot, glob)) {
        const key = full.toLowerCase();
        if (seen.has(key)) {
          continue;
        }
        seen.add(key);
        files.push({
          fullName: full,
          relative: path.relative(base ?? resolvedRoot, full).split(path.sep).join("/"),
          leaf: path.basename(full).replace(/\.eval\.yaml$/, ""),
          parent: path.basename(path.dirname(full)),
        });
      }
    }
  }

  return files;
}

// Reads the `area` tag from an eval YAML. Targeted regex (not a full YAML parse) so the
// script has no module dependency on the build agent. The eval files use a flat `tags:`
// block, e.g. `  area: github`. Returns null when no tag is present so the caller can fall
// back to the file's folder.
export function getEvalArea(filePath) {
  const content = fs.readFileSync(filePath, "utf8");
  const match = content.match(/^\s*area:\s*["']?([A-Za-z0-9._-]+)/m);
  return match ? match[1] : null;
}

/**
 * Builds the Azure Pipelines matrix object from the discovered eval files.
 *
 * @param {object} options
 * @param {string[]} options.roots Eval roots to glob from (repo-specific and/or scattered).
 * @param {string[]} [options.patterns] Forward-slashed globs relative to each root.
 * @param {string|null} [options.pathBase] Anchor for emitted `-e` paths (the run root). When
 *   null, each file's path is relative to the root it was found under.
 * @param {"file"|"area"} [options.shardBy] Sharding granularity.
 * @param {(message: string) => void} [options.warn] Sink for non-fatal warnings.
 * @returns {Record<string, {shardName: string, evalArgs: string}>}
 */
export function buildMatrix({
  roots,
  patterns = DEFAULT_PATTERNS,
  pathBase = null,
  shardBy = "file",
  warn = (message) => console.warn(message),
} = {}) {
  const files = getEvalFiles(roots, patterns, pathBase);
  if (files.length === 0) {
    throw new Error(
      `No eval files matched any of: ${patterns.join(", ")} under ${roots.join(", ")}.`
    );
  }

  const matrix = {};

  if (shardBy === "file") {
    // One shard per file. Shard name = the file's full relative path (sans the
    // .eval.yaml extension), sanitized. Deriving from the whole path — not just
    // parent+leaf — guarantees global uniqueness across layouts where the immediate
    // parent repeats: the Vally tree distinguishes by parent (tools/ vs mock/), but the
    // skills tree puts every eval under `<skill>/evals/`, so `evals_trigger` would
    // collide across all skills. The full path keeps each shard name unique and stable.
    for (const file of files) {
      const shardName = file.relative.replace(/\.eval\.yaml$/i, "").replace(SANITIZE, "_");
      if (Object.prototype.hasOwnProperty.call(matrix, shardName)) {
        throw new Error(
          `Duplicate shard name '${shardName}' (from '${file.relative}'). Shard names must be unique.`
        );
      }
      matrix[shardName] = { shardName, evalArgs: `-e ${file.relative}` };
    }
    return matrix;
  }

  // area mode: one shard per `area` tag. Every file carrying that area is run in the same
  // job via repeated `-e` flags (keeps the live tier out, unlike `--suite <area>`).
  const byArea = new Map();
  const sorted = [...files].sort((a, b) => a.relative.localeCompare(b.relative));
  for (const file of sorted) {
    let area = getEvalArea(file.fullName);
    if (!area) {
      // No `area:` tag. Fall back to the eval's parent folder so the file still groups
      // with its neighbours instead of all untagged evals piling into one bucket. Warn so
      // the missing tag stays visible.
      area = file.parent;
      warn(`No 'area' tag in '${file.relative}'; falling back to folder '${area}'.`);
    }
    if (!byArea.has(area)) {
      byArea.set(area, []);
    }
    byArea.get(area).push(file.relative);
  }

  for (const area of [...byArea.keys()].sort()) {
    const shardName = `area_${area}`.replace(SANITIZE, "_");
    const evalArgs = byArea.get(area).map((relative) => `-e ${relative}`).join(" ");
    matrix[shardName] = { shardName, evalArgs };
  }

  return matrix;
}

// ----- CLI -----

function parseArgs(argv) {
  const options = {
    roots: [],
    patterns: [],
    pathBase: null,
    shardBy: "file",
    outputVariable: "matrix",
  };

  for (let i = 0; i < argv.length; i++) {
    const arg = argv[i];
    const next = () => argv[++i];
    switch (arg) {
      case "--eval-root":
        options.roots.push(next());
        break;
      case "--path-base":
        options.pathBase = next();
        break;
      case "--pattern":
        options.patterns.push(next());
        break;
      case "--shard-by":
        options.shardBy = next();
        break;
      case "--output-variable":
        options.outputVariable = next();
        break;
      default:
        throw new Error(`Unknown argument: ${arg}`);
    }
  }

  if (options.roots.length === 0) {
    options.roots = ["."];
  }
  if (options.patterns.length === 0) {
    options.patterns = DEFAULT_PATTERNS;
  }
  if (options.shardBy !== "file" && options.shardBy !== "area") {
    throw new Error(`--shard-by must be 'file' or 'area' (got '${options.shardBy}').`);
  }

  return options;
}

function main(argv) {
  const options = parseArgs(argv);
  const matrix = buildMatrix({
    roots: options.roots,
    patterns: options.patterns,
    pathBase: options.pathBase,
    shardBy: options.shardBy,
  });
  const json = JSON.stringify(matrix);

  const keys = Object.keys(matrix);
  console.log(`Discovered ${keys.length} shard(s) (shardBy=${options.shardBy}):`);
  for (const key of keys) {
    console.log(`  - ${key} -> ${matrix[key].evalArgs}`);
  }

  // Emit for Azure Pipelines (a harmless log line when run locally outside a pipeline).
  console.log(
    `##vso[task.setVariable variable=${options.outputVariable};isOutput=true]${json}`
  );

  return matrix;
}

// Run as a CLI only when invoked directly (not when imported by the tests).
if (process.argv[1] && import.meta.url === pathToFileURL(process.argv[1]).href) {
  try {
    main(process.argv.slice(2));
  } catch (error) {
    console.error(error.message);
    process.exit(1);
  }
}
