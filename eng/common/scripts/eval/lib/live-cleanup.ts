import fs from "node:fs";
import path from "node:path";

const MUTATING_RELEASE_PLAN_TOOLS = new Set([
  "azsdk_create_release_plan",
  "azsdk_link_namespace_approval_issue",
  "azsdk_link_sdk_pull_request_to_release_plan",
  "azsdk_run_generate_sdk",
  "azsdk_update_api_spec_pull_request_in_release_plan",
  "azsdk_update_release_plan",
  "azsdk_update_sdk_details_in_release_plan",
]);

function findEventFiles(root) {
  if (!fs.existsSync(root)) {
    return [];
  }

  const files = [];
  const pending = [root];
  while (pending.length > 0) {
    const current = pending.pop();
    for (const entry of fs.readdirSync(current, { withFileTypes: true })) {
      const fullPath = path.join(current, entry.name);
      if (entry.isDirectory()) {
        pending.push(fullPath);
      } else if (entry.name === "events.jsonl") {
        files.push(fullPath);
      }
    }
  }
  return files;
}

function getToolName(toolName) {
  return toolName?.match(/azsdk_[a-z0-9_]+$/)?.[0] ?? "";
}

function positiveInteger(value) {
  const number = Number(value);
  return Number.isInteger(number) && number > 0 ? number : 0;
}

function getProperty(object, name) {
  if (!object || typeof object !== "object") {
    return undefined;
  }
  const key = Object.keys(object).find((candidate) => candidate.toLowerCase() === name.toLowerCase());
  return key ? object[key] : undefined;
}

function parseResultContent(result) {
  for (const value of [result?.content, result?.detailedContent]) {
    if (typeof value !== "string" || value.trim() === "") {
      continue;
    }
    try {
      return JSON.parse(value);
    } catch {
      // Some tool results are plain text and do not contain cleanup identifiers.
    }
  }
  return undefined;
}

function addPlan(plans, kind, id) {
  const numericId = positiveInteger(id);
  if (!numericId) {
    return undefined;
  }
  const key = `${kind}:${numericId}`;
  if (!plans.has(key)) {
    plans.set(key, { kind, id: numericId, pullRequestUrls: new Set() });
  }
  return plans.get(key);
}

function addPlanFromArguments(plans, argumentsValue) {
  return (
    addPlan(plans, "workItemId", getProperty(argumentsValue, "workItemId")) ??
    addPlan(plans, "releasePlanId", getProperty(argumentsValue, "releasePlanId"))
  );
}

function addPlanFromResult(plans, result) {
  const details = getProperty(result, "release_plan_details");
  if (!details) {
    return;
  }
  addPlan(plans, "workItemId", getProperty(details, "workItemId")) ??
    addPlan(plans, "releasePlanId", getProperty(details, "releasePlanId"));
}

export function discoverLiveCleanupCandidates(resultsDir) {
  const plans = new Map();
  const eventFiles = findEventFiles(resultsDir);

  for (const eventFile of eventFiles) {
    const starts = new Map();
    const lines = fs.readFileSync(eventFile, "utf8").split(/\r?\n/).filter(Boolean);
    for (const [index, line] of lines.entries()) {
      let event;
      try {
        event = JSON.parse(line);
      } catch (error) {
        throw new Error(`Invalid JSON in ${eventFile}:${index + 1}: ${error.message}`);
      }

      if (event.type === "tool.execution_start") {
        starts.set(event.data?.toolCallId, event.data);
        const toolName = getToolName(event.data?.toolName);
        if (!MUTATING_RELEASE_PLAN_TOOLS.has(toolName)) {
          continue;
        }

        const plan = addPlanFromArguments(plans, event.data?.arguments);
        const pullRequestUrl = getProperty(event.data?.arguments, "pullRequestUrl");
        if (plan && typeof pullRequestUrl === "string") {
          plan.pullRequestUrls.add(pullRequestUrl);
        }
        continue;
      }

      if (event.type !== "tool.execution_complete") {
        continue;
      }

      const start = starts.get(event.data?.toolCallId);
      const toolName = getToolName(start?.toolName);
      if (toolName !== "azsdk_create_release_plan") {
        continue;
      }
      addPlanFromResult(plans, parseResultContent(event.data?.result));
    }
  }

  return {
    eventFiles,
    plans: [...plans.values()].map((plan) => ({
      ...plan,
      pullRequestUrls: [...plan.pullRequestUrls],
    })),
  };
}

export function parseAzureSdkPullRequestUrl(url) {
  if (typeof url !== "string") {
    return undefined;
  }
  const match = url.match(
    /^https:\/\/github\.com\/Azure\/(azure-sdk-for-[a-z0-9-]+)\/pull\/([1-9][0-9]*)\/?$/i
  );
  if (!match) {
    return undefined;
  }
  return {
    owner: "Azure",
    repo: match[1],
    number: Number(match[2]),
    url: `https://github.com/Azure/${match[1]}/pull/${match[2]}`,
  };
}

export function getCaseInsensitiveProperty(object, name) {
  return getProperty(object, name);
}

export function requireTestReleasePlan(response, candidate) {
  const details = getProperty(response, "release_plan_details");
  if (!details) {
    throw new Error(`Release plan candidate ${candidate.kind}=${candidate.id} could not be verified.`);
  }
  if (getProperty(details, "isTestReleasePlan") !== true) {
    throw new Error(`Refusing to clean non-test release plan ${candidate.kind}=${candidate.id}.`);
  }
  return details;
}
