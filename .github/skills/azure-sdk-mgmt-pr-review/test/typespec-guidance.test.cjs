// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
"use strict";
const test = require("node:test");
const assert = require("node:assert/strict");
const fs = require("node:fs");
const path = require("node:path");
const workflow = fs.readFileSync(path.resolve(__dirname, "../../../workflows/mgmt-review.md"), "utf8");
const marker = "<!-- mgmt-review-typespec-guidance -->";
const findingsMarker = "> [!IMPORTANT]\n> **TypeSpec changes required.** Follow the resolution checklist.";
const statusStart = "<!-- mgmt-review-typespec-status:start -->";
const statusEnd = "<!-- mgmt-review-typespec-status:end -->";
const runUrl = "https://github.com/Azure/azure-sdk-for-net/actions/runs/123";
const head = "abcdef123456";
const author = { login: "github-actions[bot]" };
const review = {
  id: 10, user: author, state: "COMMENTED", commit_id: head,
  submitted_at: "2026-10-16T01:00:00Z", html_url: "https://github.com/Azure/azure-sdk-for-net/pull/42#pullrequestreview-10",
  body: `${findingsMarker}\n### Management SDK Review Summary\n> Analyzed by Azure .NET Management SDK PR Review: ${runUrl}`,
};
function getScript() {
  const job = workflow.split("    update_typespec_guidance:\n")[1]?.split("\n    dismiss_stale_change_requests:")[0];
  assert.ok(job, "a dedicated guidance safe-output job must exist");
  const script = job.split("            script: |\n")[1];
  assert.ok(script, "the guidance handler must be testable without running a live workflow");
  return script.split("\n").filter(line => line.startsWith("              ") || !line.trim())
    .map(line => line.slice(14)).join("\n");
}
async function run({ reviews = [review], comments = [], output, prHead = head, prNumber = "42" } = {}) {
  const calls = [];
  const methods = Object.fromEntries(["get", "listReviews", "listComments", "createComment", "updateComment"]
    .map(name => [name, Symbol(name)]));
  const github = {
    rest: {
      pulls: { get: async args => { calls.push(["get", args]); return { data: { head: { sha: prHead }, user: { login: "sdk-author" } } }; },
        listReviews: methods.listReviews },
      issues: { listComments: methods.listComments,
        createComment: async args => calls.push(["create", args]),
        updateComment: async args => calls.push(["update", args]) },
    },
    paginate: async (method, args) => {
      calls.push([method === methods.listReviews ? "reviews" : "comments", args]);
      if (method === methods.listReviews) return reviews;
      assert.equal(method, methods.listComments);
      return comments;
    },
  };
  const AsyncFunction = Object.getPrototypeOf(async function () {}).constructor;
  await new AsyncFunction("github", "context", "core", "require", "process", getScript())(
    github, { repo: { owner: "Azure", repo: "azure-sdk-for-net" }, runId: 123 },
    { info() {}, warning() {} },
    name => { assert.equal(name, "fs"); return { readFileSync: () => JSON.stringify(output ?? {
      items: [{ type: "submit_pull_request_review" }], errors: [],
    }) }; },
    { env: { TARGET_PR_NUMBER: prNumber, REVIEW_WORKFLOW_NAME: "Azure .NET Management SDK PR Review",
      GITHUB_SERVER_URL: "https://github.com", GH_AW_AGENT_OUTPUT: "output.json" } },
  );
  return calls.filter(([name]) => ["create", "update"].includes(name));
}

// Regression anchor: the original workflow appended the process beneath all review details.
test("guidance is separate from review details, with an alert before the summary", () => {
  assert.match(workflow, /Before .*Management SDK Review Summary/);
  assert.match(workflow, /update_typespec_guidance/);
  assert.match(workflow, /\[!IMPORTANT\]/);
  assert.ok(!workflow.includes("append this process guidance"));
});
test("the compiled workflow retains the visible alert and the exact tested handler", () => {
  const lock = fs.readFileSync(path.resolve(__dirname, "../../../workflows/mgmt-review.lock.yml"), "utf8");
  const prompt = [...lock.matchAll(/GH_AW_PROMPT_CONTENT_\d+: (".*")/g)]
    .map(match => JSON.parse(match[1])).join("\n");
  assert.ok(prompt.includes("> **TypeSpec changes required.**"));
  assert.ok(prompt.includes("request the `update_typespec_guidance` custom safe-output tool"));
  assert.ok(prompt.includes("link to that comment in the alert"));
  const job = lock.split("\n  update_typespec_guidance:\n")[1].split("\n  validate_agent_output:")[0];
  const script = job.split("          script: |\n")[1].split("\n")
    .filter(line => line.startsWith("            ") || !line.trim()).map(line => line.slice(12)).join("\n");
  assert.equal(script.trimEnd(), getScript().trimEnd());
});
test("creates a separate author-addressed checklist even for duplicate-suppressed COMMENT reviews", async () => {
  const [[action, args]] = await run();
  assert.equal(action, "create");
  assert.equal(args.issue_number, 42);
  assert.ok(args.body.startsWith(marker));
  assert.match(args.body, /@sdk-author/);
  assert.match(args.body, /\[!IMPORTANT\]/);
  assert.match(args.body, /Do not merge the spec PR/);
  assert.equal((args.body.match(/^- \[ \]/gm) || []).length, 5);
  assert.ok(args.body.includes(review.html_url));
  assert.ok(args.body.endsWith("\n\n&#45; by copilot"));
});
test("creates guidance after gh-aw strips HTML comments from the outgoing review", async () => {
  const strippedBody = (`<!-- outgoing comments are stripped -->\n${review.body}`).replace(/<!--.*?-->/g, "");
  assert.equal((await run({ reviews: [{ ...review, body: strippedBody }] }))[0]?.[0], "create");
});
test("also creates guidance for a blocking review", async () => {
  assert.equal((await run({ reviews: [{ ...review, state: "CHANGES_REQUESTED" }] }))[0][0], "create");
});
test("reuses the marked bot comment and preserves checked boxes and author edits", async () => {
  const [[, first]] = await run();
  const body = first.body.replace("- [ ]", "- [x]") + "\nAuthor note: spec PR #12345.";
  const [[action, args]] = await run({ comments: [{ id: 77, user: author, body }],
    reviews: [{ ...review, id: 11, html_url: review.html_url.replace("-10", "-11") }] });
  assert.equal(action, "update");
  assert.equal(args.comment_id, 77);
  assert.ok(args.body.includes("pullrequestreview-11"));
  assert.ok(args.body.includes("- [x]"));
  assert.ok(args.body.includes("Author note: spec PR #12345."));
  assert.ok(args.body.endsWith("\n\n&#45; by copilot"));
  assert.equal((args.body.match(/&#45; by copilot/g) || []).length, 1);
  assert.equal((args.body.match(/@sdk-author/g) || []).length, 1);
});
test("does not update or duplicate an already current checklist", async () => {
  const [[, args]] = await run();
  assert.deepEqual(await run({ comments: [{ id: 77, user: author, body: args.body }] }), []);
});
test("ignores human copies, other bot comments, and activation comments", async () => {
  const [[, args]] = await run();
  const comments = [
    { id: 1, user: { login: "sdk-author" }, body: args.body },
    { id: 2, user: { login: "copilot[bot]" }, body: args.body },
    { id: 3, user: author, body: "Azure .NET Management SDK PR Review is reviewing this PR" },
  ];
  assert.equal((await run({ comments }))[0][0], "create");
});
test("does not create guidance on a clean or non-TypeSpec review", async () => {
  assert.deepEqual(await run({ reviews: [{ ...review, body: review.body.replace(findingsMarker, "") }] }), []);
});
test("updates existing guidance on a clean review without claiming final regeneration happened", async () => {
  const [[, first]] = await run();
  const [[action, args]] = await run({ comments: [{ id: 77, user: author, body: first.body }],
    reviews: [{ ...review, body: review.body.replace(findingsMarker, "") }] });
  assert.equal(action, "update");
  assert.match(args.body, /No outstanding TypeSpec review findings/);
  assert.doesNotMatch(args.body, /Action required/);
  assert.match(args.body, /does not confirm/);
  assert.equal(args.body.slice(args.body.indexOf(statusEnd)), first.body.slice(first.body.indexOf(statusEnd)));
});
test("reopens the action notice if a later review reports TypeSpec findings again", async () => {
  const [[, first]] = await run();
  const [[, clean]] = await run({ comments: [{ id: 77, user: author, body: first.body }],
    reviews: [{ ...review, body: review.body.replace(findingsMarker, "") }] });
  const [[action, args]] = await run({ comments: [{ id: 77, user: author, body: clean.body }] });
  assert.equal(action, "update");
  assert.match(args.body, /Action required/);
});
for (const [label, overrides] of Object.entries({
  "old head": { commit_id: "old" }, "different run": { body: review.body.replace("runs/123", "runs/456") },
  "human review": { user: { login: "sdk-author" } }, "other bot": { user: { login: "copilot[bot]" } },
  "dismissed review": { state: "DISMISSED" }, "pending review": { state: "PENDING" },
  "different workflow": { body: review.body.replace("Azure .NET Management SDK PR Review", "Other Review") },
})) {
  test(`does not mutate comments for a ${label}`, async () => {
    assert.deepEqual(await run({ reviews: [{ ...review, ...overrides }] }), []);
  });
}
test("uses the newest workflow review and refuses a stale run", async () => {
  assert.deepEqual(await run({ reviews: [review, { ...review, id: 11, submitted_at: "2026-10-16T02:00:00Z",
    body: review.body.replace("runs/123", "runs/456") }] }), []);
});
for (const output of [
  { items: [], errors: [] }, { items: [{ type: "submit_pull_request_review" }], errors: ["failed"] },
  ...["report_incomplete", "missing_tool", "missing_data"].map(type => ({
    items: [{ type: "submit_pull_request_review" }, { type }], errors: [],
  })),
]) {
  test(`rejects incomplete or failed agent output: ${JSON.stringify(output)}`, async () => {
    await assert.rejects(run({ output }), /incomplete or invalid agent output/);
  });
}
test("fails safely if the managed status boundaries were removed", async () => {
  const [[, args]] = await run();
  await assert.rejects(run({ comments: [{ id: 77, user: author, body: args.body.replace(statusStart, "") }] }),
    /status markers/);
});
test("rejects invalid target PR numbers", async () => {
  for (const prNumber of ["42oops", "0", "-1", "", "42.0", " 42", "4.2e1", "0x2a", "9007199254740992"]) {
    await assert.rejects(run({ prNumber }), /pull request number/);
  }
});
