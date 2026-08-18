import { spawnSync } from "node:child_process";
import path from "node:path";
import { pathToFileURL } from "node:url";

import {
  discoverLiveCleanupCandidates,
  getCaseInsensitiveProperty,
  parseAzureSdkPullRequestUrl,
  requireTestReleasePlan,
} from "./lib/live-cleanup.ts";

function parseArgs(argv) {
  const options = {};
  for (let i = 0; i < argv.length; i++) {
    const next = () => argv[++i];
    switch (argv[i]) {
      case "--results-dir":
        options.resultsDir = next();
        break;
      case "--azsdk":
        options.azsdk = next();
        break;
      default:
        throw new Error(`Unknown argument: ${argv[i]}`);
    }
  }
  for (const required of ["resultsDir", "azsdk"]) {
    if (!options[required]) {
      throw new Error(`Missing required argument: --${required.replace(/[A-Z]/g, (x) => `-${x.toLowerCase()}`)}`);
    }
  }
  return options;
}

function runAzSdk(azsdk, command) {
  const result = spawnSync("dotnet", [azsdk, ...command, "--output", "json"], {
    encoding: "utf8",
    env: { ...process.env, AZSDKTOOLS_AGENT_TESTING: "true" },
  });
  if (result.status !== 0) {
    throw new Error(
      `azsdk ${command.join(" ")} failed (${result.status}): ${result.stderr || result.stdout}`
    );
  }
  try {
    return JSON.parse(result.stdout);
  } catch (error) {
    throw new Error(`azsdk ${command.join(" ")} returned invalid JSON: ${error.message}`);
  }
}

function planIdentifierArgs(plan) {
  return plan.kind === "workItemId"
    ? ["--work-item-id", String(plan.id)]
    : ["--release-plan-id", String(plan.id)];
}

function collectPullRequestUrls(plan, details) {
  const urls = new Set(plan.pullRequestUrls);
  const sdkInfo = getCaseInsensitiveProperty(details, "sdkInfo");
  if (Array.isArray(sdkInfo)) {
    for (const sdk of sdkInfo) {
      const url = getCaseInsensitiveProperty(sdk, "sdkPullRequestUrl");
      if (url) {
        urls.add(url);
      }
    }
  }
  return [...urls];
}

async function githubRequest(pathname, options = {}) {
  const token = process.env.GITHUB_TOKEN;
  if (!token) {
    throw new Error("GITHUB_TOKEN is required to clean up generated SDK pull requests.");
  }
  const response = await fetch(`https://api.github.com${pathname}`, {
    ...options,
    headers: {
      Accept: "application/vnd.github+json",
      Authorization: `Bearer ${token}`,
      "X-GitHub-Api-Version": "2022-11-28",
      ...options.headers,
    },
  });
  if (!response.ok) {
    throw new Error(`GitHub ${options.method ?? "GET"} ${pathname} failed: ${response.status} ${await response.text()}`);
  }
  return response.json();
}

async function closePullRequest(url) {
  const pullRequest = parseAzureSdkPullRequestUrl(url);
  if (!pullRequest) {
    throw new Error(`Refusing to close non-Azure-SDK pull request URL: ${url}`);
  }

  const apiPath = `/repos/${pullRequest.owner}/${pullRequest.repo}/pulls/${pullRequest.number}`;
  const current = await githubRequest(apiPath);
  if (current.state === "closed") {
    console.log(`SDK pull request already closed: ${pullRequest.url}`);
    return;
  }
  await githubRequest(apiPath, {
    method: "PATCH",
    body: JSON.stringify({ state: "closed" }),
    headers: { "Content-Type": "application/json" },
  });
  console.log(`Closed SDK pull request: ${pullRequest.url}`);
}

export async function cleanupLiveEval({ resultsDir, azsdk }) {
  const candidates = discoverLiveCleanupCandidates(resultsDir);
  const errors = [];
  console.log(
    `Found ${candidates.plans.length} release plan candidate(s) in ${candidates.eventFiles.length} trajectory file(s).`
  );

  const verifiedPlans = new Map();
  for (const candidate of candidates.plans) {
    try {
      const response = runAzSdk(azsdk, ["release-plan", "get", ...planIdentifierArgs(candidate)]);
      const details = requireTestReleasePlan(response, candidate);

      const workItemId = Number(getCaseInsensitiveProperty(details, "workItemId"));
      if (!Number.isInteger(workItemId) || workItemId <= 0) {
        throw new Error(`Verified test release plan has no valid work item ID: ${candidate.id}.`);
      }

      const existing = verifiedPlans.get(workItemId) ?? {
        details,
        pullRequestUrls: new Set(),
      };
      for (const url of collectPullRequestUrls(candidate, details)) {
        existing.pullRequestUrls.add(url);
      }
      verifiedPlans.set(workItemId, existing);
    } catch (error) {
      errors.push(error.message);
    }
  }

  for (const [workItemId, plan] of verifiedPlans) {
    for (const url of plan.pullRequestUrls) {
      try {
        await closePullRequest(url);
      } catch (error) {
        errors.push(error.message);
      }
    }

    const status = getCaseInsensitiveProperty(plan.details, "status");
    if (typeof status === "string" && status.toLowerCase() === "abandoned") {
      console.log(`Release plan already abandoned: ${workItemId}`);
      continue;
    }
    try {
      runAzSdk(azsdk, ["release-plan", "abandon", "--work-item-id", String(workItemId)]);
      console.log(`Abandoned test release plan: ${workItemId}`);
    } catch (error) {
      errors.push(error.message);
    }
  }

  if (errors.length > 0) {
    throw new Error(`Live eval cleanup encountered ${errors.length} error(s):\n- ${errors.join("\n- ")}`);
  }
}

if (process.argv[1] && import.meta.url === pathToFileURL(path.resolve(process.argv[1])).href) {
  cleanupLiveEval(parseArgs(process.argv.slice(2))).catch((error) => {
    console.error(error.message);
    process.exitCode = 1;
  });
}
