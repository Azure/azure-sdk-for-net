// Ensures a shallow + sparse cache clone of a git repo exists and is reasonably fresh.
// First run: shallow blobless cone-sparse clone. Within maxAgeHours: no-op. Past that:
// fetch + checkout. Primes the cache Vally's `environment.git` fixtures point at; FETCH_HEAD
// is landed on a local branch named <ref> so `git worktree add --detach <tmp> <ref>` resolves.

import { spawnSync } from "node:child_process";
import fs from "node:fs";
import path from "node:path";
import { pathToFileURL } from "node:url";

// Throws on non-zero git exit so a failed clone stops immediately.
function invokeGit(args) {
  const proc = spawnSync("git", args, { stdio: ["ignore", "ignore", "inherit"] });
  if (proc.status !== 0) {
    throw new Error(`git ${args.join(" ")} failed (exit ${proc.status})`);
  }
}

/**
 * Clones or refreshes the cache and returns its path.
 *
 * @param {object} options
 * @param {string} [options.cacheRoot] Cache root dir (default <cwd>/artifacts/specs-cache).
 * @param {string} [options.repoUrl] Clone URL.
 * @param {string} [options.repoName] Cache sub-folder name.
 * @param {string} [options.ref] Branch/ref to check out.
 * @param {string[]} [options.sparseCheckoutPaths] Cone-sparse paths (pass [] for full tree).
 * @param {number} [options.maxAgeHours] Skip the refresh fetch if cached within this window.
 * @returns {string} The cache path.
 */
export function syncRepo({
  cacheRoot,
  repoUrl = "https://github.com/Azure/azure-rest-api-specs.git",
  repoName = "azure-rest-api-specs",
  ref = "main",
  sparseCheckoutPaths = ["specification/contosowidgetmanager", "specification/ai/Face"],
  maxAgeHours = 24,
} = {}) {
  if (!cacheRoot) {
    cacheRoot = path.join(process.cwd(), "artifacts", "specs-cache");
  }
  const cache = path.join(cacheRoot, repoName);
  const stamp = path.join(cache, ".vally-last-fetch");

  if (!fs.existsSync(path.join(cache, ".git"))) {
    console.log(`[sync-eval-git-repo] Cloning ${repoName} (${ref}) into cache: ${cache}`);
    fs.mkdirSync(cache, { recursive: true });
    // init + fetch <ref> (not clone --depth 1) so any branch/tag/SHA is pinned on a cold cache.
    invokeGit(["-C", cache, "init", "--quiet"]);
    invokeGit(["-C", cache, "remote", "add", "origin", repoUrl]);
    if (sparseCheckoutPaths.length > 0) {
      invokeGit(["-C", cache, "sparse-checkout", "init", "--cone"]);
      invokeGit(["-C", cache, "sparse-checkout", "set", ...sparseCheckoutPaths]);
    }
    invokeGit(["-C", cache, "fetch", "--depth", "1", "--filter=blob:none", "origin", ref]);
    // Land FETCH_HEAD on a real local branch named <ref> (not detached) so Vally's worktree
    // fixtures can resolve `git worktree add --detach <tmp> <ref>`.
    invokeGit(["-C", cache, "checkout", "-B", ref, "FETCH_HEAD"]);
    fs.writeFileSync(stamp, new Date().toISOString());
  } else {
    let stale = true;
    if (fs.existsSync(stamp)) {
      const ageHours = (Date.now() - fs.statSync(stamp).mtimeMs) / 3_600_000;
      stale = ageHours > maxAgeHours;
    }
    if (stale) {
      console.log(`[sync-eval-git-repo] Refreshing cache (>${maxAgeHours}h old): ${cache}`);
      invokeGit(["-C", cache, "fetch", "--depth", "1", "origin", ref]);
      // Re-point the local <ref> branch at FETCH_HEAD (also repairs a previously detached cache)
      // so the worktree fixtures keep resolving.
      invokeGit(["-C", cache, "checkout", "-B", ref, "FETCH_HEAD"]);
      fs.writeFileSync(stamp, new Date().toISOString());
    } else {
      console.log(`[sync-eval-git-repo] Cache is fresh (<${maxAgeHours}h): ${cache}`);
    }
  }

  return cache;
}

// ----- CLI -----

function parseArgs(argv) {
  const options = { sparseCheckoutPaths: [], maxAgeHours: 24 };
  let sparseGiven = false;
  for (let i = 0; i < argv.length; i++) {
    const next = () => argv[++i];
    switch (argv[i]) {
      case "--cache-root":
        options.cacheRoot = next();
        break;
      case "--repo-url":
        options.repoUrl = next();
        break;
      case "--repo-name":
        options.repoName = next();
        break;
      case "--ref":
        options.ref = next();
        break;
      case "--sparse":
        options.sparseCheckoutPaths.push(next());
        sparseGiven = true;
        break;
      case "--max-age-hours":
        options.maxAgeHours = Number(next());
        break;
      default:
        throw new Error(`Unknown argument: ${argv[i]}`);
    }
  }
  // Only override the default sparse paths when --sparse was actually passed.
  if (!sparseGiven) {
    delete options.sparseCheckoutPaths;
  }
  return options;
}

if (process.argv[1] && import.meta.url === pathToFileURL(process.argv[1]).href) {
  try {
    const cache = syncRepo(parseArgs(process.argv.slice(2)));
    console.log(cache); // echo the cache path so a wrapper can capture it
  } catch (error) {
    console.error(error.message);
    process.exit(1);
  }
}
