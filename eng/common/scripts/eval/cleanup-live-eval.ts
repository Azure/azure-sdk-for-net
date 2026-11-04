import { spawnSync } from "node:child_process";
import path from "node:path";
import { pathToFileURL } from "node:url";

import {
  discoverLiveCleanupCandidates,
  getCaseInsensitiveProperty,
  parseAzureSdkPullRequestUrl,
  requireTestReleasePlan,
  wasPullRequestCreatedDuringEval,
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
      case "--typespec-project":
        options.typeSpecProject = next();
        break;
      default:
        throw new Error(`Unknown argument: ${argv[i]}`);
    }
  }
  for (const required of ["azsdk"]) {
    if (!options[required]) {
      throw new Error(`Missing required argument: --${required.replace(/[A-Z]/g, (x) => `-${x.toLowerCase()}`)}`);
    }
  }
  if (Boolean(options.resultsDir) === Boolean(options.typeSpecProject)) {
    throw new Error("Specify exactly one of --results-dir or --typespec-project.");
  }
  return options;
}

function runJson(executable, args) {
  const result = spawnSync(executable, args, {
    encoding: "utf8",
    env: { ...process.env, AZSDKTOOLS_AGENT_TESTING: "true" },
  });
  if (result.status !== 0) {
    throw new Error(
      `${executable} ${args.join(" ")} failed (${result.status}): ${result.stderr || result.stdout}`
    );
  }
  let response;
  try {
    response = JSON.parse(result.stdout);
  } catch (error) {
    throw new Error(`${executable} returned invalid JSON: ${error.message}`);
  }
  const errors = getCaseInsensitiveProperty(response, "response_errors");
  if (errors?.length || getCaseInsensitiveProperty(response, "operation_status") === "Failed") {
    throw new Error(`Command failed: ${JSON.stringify(response)}`);
  }
  return response;
}

function runAzSdk(azsdk, command) {
  return runJson("dotnet", [azsdk, ...command, "--output", "json"]);
}

export async function findProjectPlans(typeSpecProject, { runCommand = runJson, request = fetch } = {}) {
  const escapedPath = typeSpecProject.replaceAll("'", "''");
  const query = "SELECT [System.Id] FROM WorkItems WHERE [System.TeamProject] = 'release'"
    + ` AND [Custom.ApiSpecProjectPath] = '${escapedPath}'`
    + " AND [System.WorkItemType] = 'Release Plan'"
    + " AND [System.State] NOT IN ('Closed','Duplicate','Finished')"
    + " AND [System.Tags] CONTAINS 'Release Planner App Test'";
  const { accessToken } = runCommand("az", [
    "account", "get-access-token", "--resource", "499b84ac-1321-427f-aa17-267ca6975798",
    "--output", "json",
  ]);
  const response = await request("https://dev.azure.com/azure-sdk/release/_apis/wit/wiql?api-version=7.1", {
    method: "POST",
    headers: { Authorization: `Bearer ${accessToken}`, "Content-Type": "application/json" },
    body: JSON.stringify({ query }),
  });
  if (!response.ok) {
    throw new Error(`Test release-plan query failed: ${response.status}`);
  }
  const result = await response.json();
  return result.workItems.map((item) => ({ kind: "workItemId", id: item.id, pullRequestUrls: [] }));
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

async function checkPullRequest(url, evalStartedAt, includePreexisting, getPullRequest) {
  const pullRequest = parseAzureSdkPullRequestUrl(url);
  if (!pullRequest) {
    throw new Error(`Refusing to close non-Azure-SDK pull request URL: ${url}`);
  }

  const apiPath = `/repos/${pullRequest.owner}/${pullRequest.repo}/pulls/${pullRequest.number}`;
  const current = await getPullRequest(apiPath);
  if (!["open", "closed"].includes(current.state)) {
    throw new Error(`Could not verify SDK pull request state: ${url}`);
  }
  if (current.merged_at) {
    throw new Error(`Refusing to clean a plan with a merged SDK pull request: ${url}`);
  }
  if (current.state !== "closed"
    && !includePreexisting
    && !wasPullRequestCreatedDuringEval(current, evalStartedAt)) {
    throw new Error(`Refusing to close pre-existing SDK pull request: ${url}`);
  }
  return { apiPath, state: current.state };
}

export async function cleanupLiveEval({
  resultsDir, azsdk, typeSpecProject,
  runCli = runAzSdk, queryPlans = findProjectPlans, getPullRequest = githubRequest,
}) {
  const candidates = typeSpecProject
    ? { plans: await queryPlans(typeSpecProject), eventFiles: [] }
    : discoverLiveCleanupCandidates(resultsDir);
  const errors = [];
  console.log(
    `Found ${candidates.plans.length} release plan candidate(s) in ${candidates.eventFiles.length} trajectory file(s).`
  );

  const verifiedPlans = new Map();
  for (const candidate of candidates.plans) {
    try {
      const response = runCli(azsdk, ["release-plan", "get", ...planIdentifierArgs(candidate)]);
      const details = requireTestReleasePlan(response, candidate);
      if (typeSpecProject && getCaseInsensitiveProperty(details, "apiSpecProjectPath") !== typeSpecProject) {
        throw new Error(`Refusing to clean a plan for a different TypeSpec project: ${candidate.id}.`);
      }

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
    try {
      const pullRequests = [];
      for (const url of plan.pullRequestUrls) {
        const checked = await checkPullRequest(url, candidates.startedAt, Boolean(typeSpecProject), getPullRequest);
        pullRequests.push({ url, ...checked });
      }
      if (getCaseInsensitiveProperty(plan.details, "status") === "Abandoned"
        && pullRequests.every((pr) => pr.state === "closed")) {
        continue;
      }
      const sdks = getCaseInsensitiveProperty(plan.details, "sdkInfo") ?? [];
      for (const sdk of sdks) {
        const pipelineUrl = getCaseInsensitiveProperty(sdk, "generationPipelineUrl");
        const generationStatus = getCaseInsensitiveProperty(sdk, "generationStatus");
        if (pipelineUrl) {
          const response = runCli(azsdk, ["ci", "status", pipelineUrl]);
          const builds = getCaseInsensitiveProperty(response, "result");
          if (!Array.isArray(builds) || builds.length === 0
            || builds.some((build) => getCaseInsensitiveProperty(build, "status") !== "completed")) {
            throw new Error(`Generation is not confirmed complete for test plan ${workItemId}: ${pipelineUrl}`);
          }
        } else if (/^(pending|in progress)$/i.test(generationStatus ?? "")) {
          throw new Error(`Generation is still pending for test plan ${workItemId}.`);
        }
      }
      const releasePlanId = Number(getCaseInsensitiveProperty(plan.details, "releasePlanId"));
      if (!Number.isInteger(releasePlanId) || releasePlanId <= 0) {
        throw new Error(`Verified test plan ${workItemId} has no valid Release Plan ID.`);
      }
      // The CLI abandons the plan and closes its linked, unmerged SDK PRs.
      const response = runCli(azsdk, ["release-plan", "abandon", "--release-plan-id", String(releasePlanId)]);
      const details = getCaseInsensitiveProperty(response, "details") ?? [];
      const warnings = details.filter((detail) => /^Warning:/i.test(detail));
      for (const pr of pullRequests) {
        try {
          const current = await getPullRequest(pr.apiPath);
          if (current.state !== "closed") {
            warnings.push(`SDK PR is not confirmed closed; manual follow-up required: ${pr.url}`);
          }
        } catch (error) {
          warnings.push(`Could not verify SDK PR cleanup at ${pr.url}: ${error.message}`);
        }
      }
      if (warnings.length) {
        throw new Error(`Test plan ${workItemId} cleanup needs follow-up: ${warnings.join("; ")}`);
      }
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
