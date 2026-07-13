// Discovers `environment.git` worktree fixtures across an eval suite and primes a shallow +
// sparse cache clone for each unique one (Vally runs `git worktree add` and won't clone them).
// The discovery logic is exported and unit-tested; --list-only dry-runs without cloning.

import fs from "node:fs";
import path from "node:path";
import { pathToFileURL } from "node:url";
import { globFiles } from "./lib/glob.ts";
import { syncRepo } from "./sync-eval-git-repo.ts";

export const DEFAULT_PATTERNS = [
  "evals/tools/*.eval.yaml",
  "evals/workflow-scenarios/mock/*.eval.yaml",
];

// Repos we know how to clone efficiently (cone-sparse to the spec folders the fixtures touch).
// Unknown repos fall back to a full shallow clone under the --default-org owner.
export const KNOWN_REPOS = {
  "azure-rest-api-specs": {
    url: "https://github.com/Azure/azure-rest-api-specs.git",
    sparse: ["specification/contosowidgetmanager", "specification/ai/Face"],
  },
};

/**
 * Scans an eval suite for `environment.git` worktree fixtures.
 *
 * @param {object} options
 * @param {string} options.root Suite root the patterns are resolved against.
 * @param {string[]} [options.patterns] Glob patterns of eval files to scan.
 * @returns {Array<{evalFile:string, source:string, ref:string, cachePath:string, repoName:string}>}
 */
export function getEvalGitFixtures({ root, patterns = DEFAULT_PATTERNS }) {
  // Match a `git:` mapping plus the indented block beneath it. \k<indent> ties the body lines to
  // a deeper indent than `git:` itself, so a sibling key at the same level ends the block.
  const blockRegex = /^(?<indent>[ \t]*)git:[ \t]*\r?\n(?<body>(?:\k<indent>[ \t]+\S.*(?:\r?\n|$))+)/gm;
  const fixtures = [];

  for (const pattern of patterns) {
    for (const file of globFiles(root, pattern)) {
      const content = fs.readFileSync(file, "utf8");
      blockRegex.lastIndex = 0;
      let match;
      while ((match = blockRegex.exec(content)) !== null) {
        const body = match.groups.body;
        const sourceMatch = body.match(/^\s*source:\s*(\S+)/m);
        if (!sourceMatch) {
          continue; // a git block without a source is not a worktree fixture we can prime
        }
        const source = sourceMatch[1];
        const refMatch = body.match(/^\s*ref:\s*(\S+)/m);
        const ref = refMatch ? refMatch[1] : "main";
        const cachePath = path.resolve(path.dirname(file), source);
        fixtures.push({ evalFile: file, source, ref, cachePath, repoName: path.basename(cachePath) });
      }
    }
  }

  return fixtures;
}

/**
 * Collapses fixtures that point at the same cache path + ref, sorted for stable output.
 *
 * @param {ReturnType<typeof getEvalGitFixtures>} fixtures
 */
export function dedupeFixtures(fixtures) {
  const seen = new Set();
  const unique = [];
  const sorted = [...fixtures].sort(
    (a, b) => a.cachePath.localeCompare(b.cachePath) || a.ref.localeCompare(b.ref)
  );
  for (const fixture of sorted) {
    const key = `${fixture.cachePath}|${fixture.ref}`;
    if (seen.has(key)) {
      continue;
    }
    seen.add(key);
    unique.push(fixture);
  }
  return unique;
}

// ----- CLI -----

function parseArgs(argv) {
  const options = { evalRoot: ".", patterns: [], maxAgeHours: 24, defaultOrg: "Azure", listOnly: false };
  for (let i = 0; i < argv.length; i++) {
    const next = () => argv[++i];
    switch (argv[i]) {
      case "--eval-root":
        options.evalRoot = next();
        break;
      case "--pattern":
        options.patterns.push(next());
        break;
      case "--max-age-hours":
        options.maxAgeHours = Number(next());
        break;
      case "--default-org":
        options.defaultOrg = next();
        break;
      case "--list-only":
        options.listOnly = true;
        break;
      default:
        throw new Error(`Unknown argument: ${argv[i]}`);
    }
  }
  if (options.patterns.length === 0) {
    options.patterns = DEFAULT_PATTERNS;
  }
  return options;
}

function main(argv) {
  const options = parseArgs(argv);
  const root = path.resolve(options.evalRoot);

  const fixtures = getEvalGitFixtures({ root, patterns: options.patterns });
  if (fixtures.length === 0) {
    console.log("[prime-fixtures] No git fixtures declared in the scanned suite. Nothing to do.");
    return [];
  }

  const unique = dedupeFixtures(fixtures);
  console.log(`[prime-fixtures] Discovered ${unique.length} unique git fixture(s):`);
  for (const fixture of unique) {
    console.log(`  - ${fixture.repoName} @ ${fixture.ref}  ->  ${fixture.cachePath}`);
  }

  if (options.listOnly) {
    return unique;
  }

  for (const fixture of unique) {
    const known = KNOWN_REPOS[fixture.repoName];
    const repoUrl = known ? known.url : `https://github.com/${options.defaultOrg}/${fixture.repoName}.git`;
    const sparseCheckoutPaths = known ? known.sparse : [];
    const cacheRoot = path.dirname(fixture.cachePath);
    console.log(`[prime-fixtures] Priming ${fixture.repoName} @ ${fixture.ref} from ${repoUrl}`);
    syncRepo({
      cacheRoot,
      repoUrl,
      repoName: fixture.repoName,
      ref: fixture.ref,
      sparseCheckoutPaths,
      maxAgeHours: options.maxAgeHours,
    });
  }

  console.log("[prime-fixtures] Done.");
  return unique;
}

if (process.argv[1] && import.meta.url === pathToFileURL(process.argv[1]).href) {
  try {
    main(process.argv.slice(2));
  } catch (error) {
    console.error(error.message);
    process.exit(1);
  }
}
