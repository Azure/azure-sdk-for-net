import assert from "node:assert/strict";
import fs from "node:fs";
import os from "node:os";
import path from "node:path";
import { afterEach, describe, it } from "node:test";

import {
  discoverLiveCleanupCandidates,
  parseAzureSdkPullRequestUrl,
  requireTestReleasePlan,
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
});
