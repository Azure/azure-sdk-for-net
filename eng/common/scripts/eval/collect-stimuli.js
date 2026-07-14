// Discovers Vally eval files and emits an Azure Pipelines matrix for fan-out sharding.
// Globs one or more eval-file patterns under one or more roots, de-dups, and shards by the
// `area` tag (one job per area; files with no tag fall back to their parent folder). Each
// matrix leg exposes shardName (result-folder id) and evalArgs (the `-e <file>` flags).

import fs from "node:fs";
import path from "node:path";
import { pathToFileURL } from "node:url";
import { globFiles } from "./lib/glob.js";

// Fallback patterns when run with no --pattern. Mirrors archetype-eval.yml's evalGlobs default.
const DEFAULT_PATTERNS = [
  "evals/tools/*.eval.yaml",
  "evals/workflow-scenarios/mock/*.eval.yaml",
];

const SANITIZE = /[^A-Za-z0-9]/g;

// Discovers eval files across every root, de-duplicated. Each file's `relative` path (handed
// to `vally eval -e`) is computed against `pathBase` when supplied, else against its root.
export function getEvalFiles(roots, patterns, pathBase = null) {
  const seen = new Set(); // case-insensitive
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
        const relative = path.relative(base ?? resolvedRoot, full).split(path.sep).join("/");
        // Eval paths are passed as space-delimited `-e <file>` args, so whitespace would mis-split. Fail fast.
        if (/\s/.test(relative)) {
          throw new Error(`Eval path '${relative}' contains whitespace, which is not supported.`);
        }
        files.push({
          fullName: full,
          relative,
          leaf: path.basename(full).replace(/\.eval\.yaml$/, ""),
          parent: path.basename(path.dirname(full)),
        });
      }
    }
  }

  return files;
}

// Reads the `area` tag from an eval YAML via regex. Returns null when no tag is present.
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
 * @param {(message: string) => void} [options.warn] Sink for non-fatal warnings.
 * @returns {Record<string, {shardName: string, evalArgs: string}>}
 */
export function buildMatrix({
  roots,
  patterns = DEFAULT_PATTERNS,
  pathBase = null,
  warn = (message) => console.warn(message),
} = {}) {
  const files = getEvalFiles(roots, patterns, pathBase);
  if (files.length === 0) {
    throw new Error(
      `No eval files matched any of: ${patterns.join(", ")} under ${roots.join(", ")}.`
    );
  }

  const matrix = {};

  // One shard per `area` tag; every file with that area runs in the same job.
  const byArea = new Map();
  const sorted = [...files].sort((a, b) => a.relative.localeCompare(b.relative));
  for (const file of sorted) {
    let area = getEvalArea(file.fullName);
    if (!area) {
      // No `area:` tag — fall back to the parent folder and warn.
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
    if (Object.prototype.hasOwnProperty.call(matrix, shardName)) {
      throw new Error(
        `Duplicate shard name '${shardName}' (from area '${area}'). Shard names must be unique.`
      );
    }
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

  return options;
}

function main(argv) {
  const options = parseArgs(argv);
  const matrix = buildMatrix({
    roots: options.roots,
    patterns: options.patterns,
    pathBase: options.pathBase,
  });
  const json = JSON.stringify(matrix);

  const keys = Object.keys(matrix);
  console.log(`Discovered ${keys.length} shard(s):`);
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
