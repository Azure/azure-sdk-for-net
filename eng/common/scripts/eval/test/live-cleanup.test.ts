import assert from "node:assert/strict";
import fs from "node:fs";
import os from "node:os";
import path from "node:path";
import { afterEach, describe, it } from "node:test";

import { cleanupLiveEval } from "../cleanup-live-eval.ts";
import {
  discoverLiveCleanupCandidates,
  parseAzureSdkPullRequestUrl,
  requireTestReleasePlan,
  wasPullRequestCreatedDuringEval,
} from "../lib/live-cleanup.ts";

const roots = [];

function writeEvents(events) {
  const root = fs.mkdtempSync(path.join(os.tmpdir(), "live-cleanup-"));
  roots.push(root);
  const directory = path.join(root, "executor-session-logs", "trial-0");
  fs.mkdirSync(directory, { recursive: true });
  fs.writeFileSync(
    path.join(directory, "events.jsonl"),
    events.map((event) => JSON.stringify(event)).join("\n")
  );
  return root;
}

function start(toolCallId, toolName, argumentsValue) {
  return {
    type: "tool.execution_start",
    timestamp: "2026-08-18T08:00:00Z",
    data: { toolCallId, toolName, arguments: argumentsValue },
  };
}

function complete(toolCallId, content) {
  return {
    type: "tool.execution_complete",
    data: {
      toolCallId,
      success: true,
      result: { content: JSON.stringify(content) },
    },
  };
}

afterEach(() => {
  while (roots.length > 0) {
    fs.rmSync(roots.pop(), { recursive: true, force: true });
  }
});

describe("discoverLiveCleanupCandidates", () => {
  it("discovers a plan created during the eval", () => {
    const root = writeEvents([
      start("1", "azure-sdk-mcp-azsdk_create_release_plan", {}),
      complete("1", {
        release_plan_details: { workItemId: 36111, releasePlanId: 36111 },
      }),
    ]);

    const result = discoverLiveCleanupCandidates(root);
    assert.deepEqual(result.plans, [
      { kind: "workItemId", id: 36111, pullRequestUrls: [] },
    ]);
  });

  it("discovers a reused plan and its linked SDK pull request", () => {
    const pullRequestUrl = "https://github.com/Azure/azure-sdk-for-java/pull/50170";
    const root = writeEvents([
      start("1", "azure-sdk-mcp-azsdk_run_generate_sdk", {
        workItemId: 36111,
        language: "Java",
      }),
      start("2", "azure-sdk-mcp-azsdk_link_sdk_pull_request_to_release_plan", {
        workItemId: 36111,
        language: "Java",
        pullRequestUrl,
      }),
    ]);

    const result = discoverLiveCleanupCandidates(root);
    assert.deepEqual(result.plans, [
      { kind: "workItemId", id: 36111, pullRequestUrls: [pullRequestUrl] },
    ]);
  });

  it("ignores read-only release plan lookups", () => {
    const root = writeEvents([
      start("1", "azure-sdk-mcp-azsdk_get_release_plan", { workItemId: 12345 }),
      complete("1", { release_plan_details: { workItemId: 12345 } }),
    ]);

    assert.deepEqual(discoverLiveCleanupCandidates(root).plans, []);
  });

  it("discovers SDK detail updates using the current work-item argument", () => {
    const root = writeEvents([
      start("1", "azure-sdk-mcp-azsdk_update_sdk_details_in_release_plan", {
        releasePlanWorkItemId: 36111,
      }),
    ]);

    assert.deepEqual(discoverLiveCleanupCandidates(root).plans, [
      { kind: "workItemId", id: 36111, pullRequestUrls: [] },
    ]);
  });
});

describe("parseAzureSdkPullRequestUrl", () => {
  it("accepts Azure SDK language repository pull requests", () => {
    assert.deepEqual(
      parseAzureSdkPullRequestUrl("https://github.com/Azure/azure-sdk-for-python/pull/48616"),
      {
        owner: "Azure",
        repo: "azure-sdk-for-python",
        number: 48616,
        url: "https://github.com/Azure/azure-sdk-for-python/pull/48616",
      }
    );
  });

  it("rejects unrelated pull requests", () => {
    assert.equal(
      parseAzureSdkPullRequestUrl("https://github.com/Azure/azure-rest-api-specs/pull/45567"),
      undefined
    );
    assert.equal(
      parseAzureSdkPullRequestUrl("https://github.com/other/azure-sdk-for-java/pull/1"),
      undefined
    );
  });
});

describe("requireTestReleasePlan", () => {
  it("accepts only plans explicitly marked as test plans", () => {
    const candidate = { kind: "workItemId", id: 36111 };
    const details = { WorkItemId: 36111, IsTestReleasePlan: true };
    assert.equal(requireTestReleasePlan({ Release_Plan_Details: details }, candidate), details);
  });

  it("refuses non-test plans", () => {
    assert.throws(
      () =>
        requireTestReleasePlan(
          { release_plan_details: { workItemId: 12345, isTestReleasePlan: false } },
          { kind: "workItemId", id: 12345 }
        ),
      /Refusing to clean non-test release plan/
    );
  });

  it("refuses a response for a different plan", () => {
    assert.throws(
      () => requireTestReleasePlan(
        { release_plan_details: { workItemId: 99999, isTestReleasePlan: true } },
        { kind: "workItemId", id: 36111 }
      ),
      /does not match/
    );
  });
});

describe("cleanupLiveEval", () => {
  const project = "specification/contosowidgetmanager/Contoso.WidgetManager";
  const prUrl = "https://github.com/Azure/azure-sdk-for-java/pull/50170";

  function fixture(overrides = {}) {
    return {
      workItemId: 36111,
      releasePlanId: 1600,
      isTestReleasePlan: true,
      apiSpecProjectPath: project,
      sdkInfo: [],
      ...overrides,
    };
  }

  it("pre-cleans only verified project test plans using Release Plan IDs", async () => {
    const calls = [];
    await cleanupLiveEval({
      azsdk: "azsdk.dll",
      typeSpecProject: project,
      queryPlans: (requestedProject) => {
        assert.equal(requestedProject, project);
        return [{ kind: "workItemId", id: 36111, pullRequestUrls: [] }];
      },
      runCli: (_, args) => {
        calls.push(args);
        return args[1] === "get"
          ? { release_plan_details: fixture({ sdkInfo: [{ sdkPullRequestUrl: prUrl }] }) }
          : {};
      },
      getPullRequest: async () => ({ state: "open", created_at: "2026-01-01T00:00:00Z" }),
    });

    assert.deepEqual(calls.at(-1), [
      "release-plan", "abandon", "--release-plan-id", "1600",
    ]);
  });

  it("refuses non-test or wrong-project plans before any mutation", async () => {
    for (const overrides of [
      { isTestReleasePlan: false },
      { apiSpecProjectPath: "specification/another-project" },
    ]) {
      await assert.rejects(cleanupLiveEval({
        azsdk: "azsdk.dll",
        typeSpecProject: project,
        queryPlans: () => [{ kind: "workItemId", id: 36111, pullRequestUrls: [] }],
        runCli: (_, args) => {
          assert.equal(args[1], "get");
          return { release_plan_details: fixture(overrides) };
        },
      }), /Refusing to clean/);
    }
  });

  it("post-cleans a new plan and its Java PR through the abandonment CLI", async () => {
    const root = writeEvents([
      start("1", "azsdk_create_release_plan", {}),
      complete("1", { release_plan_details: fixture() }),
    ]);
    const calls = [];
    await cleanupLiveEval({
      resultsDir: root,
      azsdk: "azsdk.dll",
      runCli: (_, args) => {
        calls.push(args);
        return args[1] === "get"
          ? { release_plan_details: fixture({ sdkInfo: [{ sdkPullRequestUrl: prUrl }] }) }
          : {};
      },
      getPullRequest: async () => ({ state: "open", created_at: "2026-08-18T08:05:00Z" }),
    });

    assert.equal(calls.at(-1)[1], "abandon");
  });

  it("does not let post-eval abandonment close a pre-existing open PR", async () => {
    const root = writeEvents([
      start("1", "azsdk_run_generate_sdk", { workItemId: 36111 }),
    ]);
    await assert.rejects(cleanupLiveEval({
      resultsDir: root,
      azsdk: "azsdk.dll",
      runCli: (_, args) => {
        assert.equal(args[1], "get");
        return { release_plan_details: fixture({ sdkInfo: [{ sdkPullRequestUrl: prUrl }] }) };
      },
      getPullRequest: async () => ({ state: "open", created_at: "2026-01-01T00:00:00Z" }),
    }), /Refusing to close pre-existing/);
  });

  it("reports active generation without abandoning it and still cleans other plans", async () => {
    const pipelineUrl = "https://dev.azure.com/azure-sdk/internal/_build/results?buildId=123";
    const abandoned = [];
    await assert.rejects(cleanupLiveEval({
      azsdk: "azsdk.dll",
      typeSpecProject: project,
      queryPlans: () => [36111, 36112].map((id) => ({
        kind: "workItemId", id, pullRequestUrls: [],
      })),
      runCli: (_, args) => {
        if (args[0] === "ci") {
          return { result: [{ status: "in_progress" }] };
        }
        if (args[1] === "get") {
          return {
            release_plan_details: fixture({
              workItemId: Number(args[3]),
              sdkInfo: args[3] === "36111" ? [{ generationPipelineUrl: pipelineUrl }] : [],
            }),
          };
        }
        abandoned.push(args);
        return {};
      },
    }), /not confirmed complete/);
    assert.equal(abandoned.length, 1);
  });

  it("reports CLI cleanup warnings instead of claiming complete cleanup", async () => {
    await assert.rejects(cleanupLiveEval({
      azsdk: "azsdk.dll",
      typeSpecProject: project,
      queryPlans: () => [{ kind: "workItemId", id: 36111, pullRequestUrls: [] }],
      runCli: (_, args) => args[1] === "get"
        ? { release_plan_details: fixture() }
        : { warnings: ["PR closure failed"] },
    }), /PR closure failed/);
  });
});

describe("wasPullRequestCreatedDuringEval", () => {
  it("accepts pull requests created during the eval", () => {
    assert.equal(
      wasPullRequestCreatedDuringEval(
        { created_at: "2026-08-18T08:05:00Z" },
        "2026-08-18T08:00:00Z"
      ),
      true
    );
  });

  it("rejects pre-existing pull requests and missing timestamps", () => {
    assert.equal(
      wasPullRequestCreatedDuringEval(
        { created_at: "2026-07-01T08:00:00Z" },
        "2026-08-18T08:00:00Z"
      ),
      false
    );
    assert.equal(wasPullRequestCreatedDuringEval({}, "2026-08-18T08:00:00Z"), false);
  });
});
