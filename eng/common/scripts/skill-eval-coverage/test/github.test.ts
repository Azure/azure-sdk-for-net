// Exercises the real API adapter and trusted comment lifecycle with fully fake HTTP transport.
import assert from "node:assert/strict";
import { createHash } from "node:crypto";
import { after, before, test } from "node:test";
import { COMMENT_MARKER, parseConfig } from "../coverage.ts";
import type { CoverageConfig } from "../coverage.ts";
import { GitHubApi, checkPullRequest, remoteSnapshot, reportCompletedRun, shouldRunLint, upsertComment } from "../github.ts";

const reportingEnvironment = {
  GITHUB_ACTIONS: process.env.GITHUB_ACTIONS,
  GITHUB_STEP_SUMMARY: process.env.GITHUB_STEP_SUMMARY,
};
before(() => {
  // Fake API scenarios must never annotate or append reports to the real Actions job.
  process.env.GITHUB_ACTIONS = "false";
  delete process.env.GITHUB_STEP_SUMMARY;
});
after(() => {
  for (const [name, value] of Object.entries(reportingEnvironment)) {
    if (value === undefined) delete process.env[name];
    else process.env[name] = value;
  }
});

const repo = "test/repo";
const head = "a".repeat(40);
const config: CoverageConfig = {
  skillsRoot: ".github/skills", pipelines: ["pipeline.yml"], workflow: ".github/workflows/skill-eval.yml",
  dashboardUrl: "https://dashboard.example.test/", authoringGuideUrl: "https://github.com/test/repo/blob/main/guide.md",
};
const skillFile = ".github/skills/example/SKILL.md";
const evalFile = ".github/skills/example/evals/eval.yaml";
const stimulus = "stimuli: [{name: trigger-example, prompt: test}]\n";

function fixture(covered = true) {
  const files = new Map<string, string>([
    ["pipeline.yml", "vallyRoot: .github/skills\nevalGlobs: ['*/evals/eval.yaml']\n"],
    [skillFile, "# Example"], ...(covered ? [[evalFile, stimulus] as [string, string]] : []),
  ]);
  const entries = () => [...files.entries()].map(([file, text]) => ({
    path: file, mode: "100644", type: "blob", size: Buffer.byteLength(text),
    sha: createHash("sha1").update(text).digest("hex"),
  }));
  const pr = { number: 7, state: "open", changed_files: 1,
    head: { sha: head, ref: "feature", repo: { full_name: "contributor/repo" } },
    base: { repo: { full_name: repo } } };
  const run = { id: 42, run_attempt: 1, event: "pull_request", status: "completed", conclusion: "success",
    path: config.workflow, workflow_id: 12, head_sha: head, head_branch: "feature",
    repository: { full_name: repo }, head_repository: { full_name: "contributor/repo" }, pull_requests: [{ number: 7 }] };
  const comments: { id: number; body: string; user: { login: string; type: string } }[] = [];
  const writes: { route: string; method: string; body: { body: string } }[] = [];
  const calls: string[] = [];
  const changed: { filename: string; previous_filename?: string }[] = [{ filename: skillFile }];
  let prReads = 0;
  let failBlob = false;
  let failChanges = false;
  let truncated = false;
  let staleBeforeWrite = false;
  const api = new GitHubApi("https://api.github.test", "fake-token-not-real", (async (url, init) => {
    assert.equal(new URL(String(url)).origin, "https://api.github.test");
    assert.equal(init?.redirect, "error");
    assert.ok(init?.signal);
    assert.equal((init?.headers as Record<string, string>).Authorization, "Bearer fake-token-not-real");
    const route = decodeURIComponent(new URL(String(url)).pathname);
    calls.push(route);
    if (init?.method !== "GET") {
      assert.match(route, /^\/repos\/test\/repo\/issues\/(7\/comments|comments\/\d+)$/);
      writes.push({ route, method: init!.method!, body: JSON.parse(String(init!.body)) });
      return Response.json({ id: 99 });
    }
    if (route === "/repos/test/repo/actions/runs/42") return Response.json(run);
    if (route === "/repos/test/repo/actions/workflows/skill-eval.yml") return Response.json({ id: 12 });
    if (route === "/repos/test/repo/pulls/7") {
      prReads++;
      return Response.json(staleBeforeWrite && prReads > 1 ? { ...pr, head: { ...pr.head, sha: "b".repeat(40) } } : pr);
    }
    if (route === "/repos/test/repo/pulls/7/files") {
      return failChanges ? new Response("private changed-file response", { status: 503 }) : Response.json(changed);
    }
    if (route === "/repos/test/repo/commits/" + head + "/pulls") return Response.json([{ number: 7 }]);
    if (route === "/repos/test/repo/git/trees/" + head) return Response.json({ truncated, tree: entries() });
    if (route.startsWith("/repos/test/repo/git/blobs/")) {
      if (failBlob) return new Response("secret server response must not be logged", { status: 503 });
      const entry = entries().find((item) => route.endsWith(item.sha));
      assert.ok(entry, "Only immutable, inventoried blob IDs may be read");
      const bytes = Buffer.from(files.get(entry.path)!);
      return Response.json({ sha: entry.sha, size: bytes.length, encoding: "base64", content: bytes.toString("base64") });
    }
    if (route === "/repos/test/repo/issues/7/comments") return Response.json(comments);
    assert.fail("Unexpected API route: " + route);
  }) as typeof fetch);
  return { api, run, pr, files, comments, calls, writes, changed,
    failBlob: () => { failBlob = true; }, failChanges: () => { failChanges = true; },
    truncate: () => { truncated = true; },
    makeStale: () => { staleBeforeWrite = true; } };
}

for (const covered of [true, false]) {
  test(`${covered ? "covered" : "missing"} fork skill creates a comment containing the dashboard and authoring links`, async () => {
    const f = fixture(covered);
    assert.equal(await reportCompletedRun(f.api, repo, 42, config, "https://github.com"), "posted");
    assert.equal(f.writes.length, 1);
    assert.equal(f.writes[0].method, "POST");
    const body = f.writes[0].body.body;
    assert.ok(body.startsWith(COMMENT_MARKER));
    assert.ok(body.includes(config.dashboardUrl));
    assert.ok(body.includes(config.authoringGuideUrl));
    assert.match(body, covered ? /coverage present/ : /coverage missing/);
    assert.match(body, /published historical results/);
    assert.match(body, /actions\/runs\/42\/attempts\/1/);
    assert.match(body, /Coverage\/lint build.*42/);
    assert.match(body, /Build result.*success/);
    assert.match(body, /Attempt.*1/);
    assert.ok(body.includes(head));
    assert.ok(f.calls.some((route) => route.includes("/git/blobs/")));
    if (covered) assert.doesNotMatch(body, /This warning will become|you may proceed/);
    else {
      assert.match(body, /This warning will become a build blocker by \*\*November 9, 2026\*\*/);
      assert.match(body, /warning-only; you may proceed if all other required checks pass/);
    }
  });
}

test("a failing lint source run still gets the independent coverage comment", async () => {
  const f = fixture();
  f.run.conclusion = "failure";
  assert.equal(await reportCompletedRun(f.api, repo, 42, config, "https://github.com"), "posted");
  assert.equal(f.writes.length, 1);
  assert.match(f.writes[0].body.body, /Build result.*failure/);
});

test("warning becomes covered by updating the same bot-owned comment", async () => {
  const f = fixture();
  f.comments.push({ id: 21, body: COMMENT_MARKER + "\ncoverage missing", user: { login: "github-actions[bot]", type: "Bot" } });
  await reportCompletedRun(f.api, repo, 42, config, "https://github.com");
  assert.equal(f.writes.length, 1);
  assert.equal(f.writes[0].method, "PATCH");
  assert.equal(f.writes[0].route, "/repos/test/repo/issues/comments/21");
  assert.match(f.writes[0].body.body, /coverage present/);
  assert.doesNotMatch(f.writes[0].body.body, /This warning will become|you may proceed/);
});

test("a later push reverting all skill changes clears the existing comment and retains dashboard links", async () => {
  const f = fixture();
  f.changed.splice(0, 1, { filename: "README.md" });
  f.comments.push({ id: 21, body: COMMENT_MARKER + "\ncoverage missing", user: { login: "github-actions[bot]", type: "Bot" } });
  assert.equal(await reportCompletedRun(f.api, repo, 42, config, "https://github.com"), "posted");
  assert.equal(f.writes.length, 1);
  assert.equal(f.writes[0].method, "PATCH");
  assert.match(f.writes[0].body.body, /No remaining affected skills/);
  assert.ok(f.writes[0].body.body.includes(config.dashboardUrl));
  assert.ok(f.writes[0].body.body.includes(config.authoringGuideUrl));
});

for (const empty of [false, true]) {
  test(`${empty ? "empty" : "unrelated"} diff does not create a new coverage comment`, async () => {
    const f = fixture();
    f.changed.splice(0, 1, ...(empty ? [] : [{ filename: "README.md" }]));
    f.pr.changed_files = f.changed.length;
    assert.equal(await reportCompletedRun(f.api, repo, 42, config, "https://github.com"), "skipped");
    assert.equal(f.writes.length, 0);
    assert.ok(f.calls.every((route) => !route.includes("/git/")));
  });
}

test("lint selection preserves original paths even when skill coverage is missing", () => {
  for (const file of [skillFile, evalFile, ".github/skills/example/references/guide.md",
    "eng/skill-eval/package-lock.json", config.workflow]) {
    assert.equal(shouldRunLint([file]), true, file);
  }
  for (const file of ["README.md", "tools/example/file.ts", "eng/common/scripts/skill-eval-coverage/check.ts"]) {
    assert.equal(shouldRunLint([file]), false, file);
  }
  assert.equal(shouldRunLint([]), false);
});

test("nondefault coverage configuration cannot disable the original blocking lint selectors", async () => {
  const alternate = parseConfig(JSON.stringify({ ...config,
    skillsRoot: ".github/other-skills", workflow: ".github/workflows/other-coverage.yml" }));
  const f = fixture();
  const originalPaths = [skillFile, "eng/skill-eval/package-lock.json", ".github/workflows/skill-eval.yml"];
  assert.deepEqual((await checkPullRequest(f.api, repo, f.pr, alternate, [skillFile])).skills, []);
  for (const file of originalPaths) {
    assert.equal(shouldRunLint([file, ".github/skill-eval-coverage.json"]), true, file);
  }
  assert.equal(shouldRunLint([".github/other-skills/example/SKILL.md"]), false);
  assert.equal(shouldRunLint([alternate.workflow]), false);
});

test("human and unrelated bot comments with a copied marker are not overwritten", async () => {
  const f = fixture();
  f.comments.push({ id: 20, body: COMMENT_MARKER, user: { login: "person", type: "User" } },
    { id: 21, body: COMMENT_MARKER, user: { login: "other-bot[bot]", type: "Bot" } });
  await upsertComment(f.api, repo, 7, COMMENT_MARKER + "\nnew report");
  assert.equal(f.writes[0].method, "POST");
});

test("identical comment body is not rewritten", async () => {
  const f = fixture();
  f.comments.push({ id: 21, body: COMMENT_MARKER, user: { login: "github-actions[bot]", type: "Bot" } });
  await upsertComment(f.api, repo, 7, COMMENT_MARKER);
  assert.equal(f.writes.length, 0);
});

test("fork runs with empty pull_requests resolve via commit association and independently verified head", async () => {
  const f = fixture();
  f.run.pull_requests = [];
  assert.equal(await reportCompletedRun(f.api, repo, 42, config, "https://github.com"), "posted");
  assert.ok(f.calls.some((route) => route.includes("/commits/")));
});

for (const [label, mutate] of [
  ["wrong workflow ID", (f: ReturnType<typeof fixture>) => { f.run.workflow_id = 33; }],
  ["wrong workflow path", (f: ReturnType<typeof fixture>) => { f.run.path = ".github/workflows/other.yml"; }],
  ["wrong repository", (f: ReturnType<typeof fixture>) => { f.run.repository.full_name = "other/repo"; }],
  ["non-PR run", (f: ReturnType<typeof fixture>) => { f.run.event = "push"; }],
  ["cancelled run", (f: ReturnType<typeof fixture>) => { f.run.conclusion = "cancelled"; }],
  ["unfinished run", (f: ReturnType<typeof fixture>) => { f.run.status = "in_progress"; }],
  ["closed PR", (f: ReturnType<typeof fixture>) => { f.pr.state = "closed"; }],
  ["old PR head", (f: ReturnType<typeof fixture>) => { f.pr.head.sha = "b".repeat(40); }],
  ["foreign fork", (f: ReturnType<typeof fixture>) => { f.pr.head.repo.full_name = "foreign/repo"; }],
  ["foreign branch", (f: ReturnType<typeof fixture>) => { f.pr.head.ref = "different"; }],
] as const) {
  test(`${label} cannot write a PR comment`, async () => {
    const f = fixture();
    mutate(f);
    assert.equal(await reportCompletedRun(f.api, repo, 42, config, "https://github.com"), "skipped");
    assert.equal(f.writes.length, 0);
  });
}

test("a push during checking prevents an obsolete comment update", async () => {
  const f = fixture();
  f.makeStale();
  assert.equal(await reportCompletedRun(f.api, repo, 42, config, "https://github.com"), "skipped");
  assert.equal(f.writes.length, 0);
});

for (const reason of ["blob failure", "truncated tree"]) {
  test(`${reason} produces an unknown result with dashboard, never a pass`, async () => {
    const f = fixture();
    if (reason === "blob failure") f.failBlob();
    else f.truncate();
    assert.equal(await reportCompletedRun(f.api, repo, 42, config, "https://github.com"), "unknown");
    assert.equal(f.writes.length, 1);
    assert.match(f.writes[0].body.body, /could not be determined/);
    assert.doesNotMatch(f.writes[0].body.body, /coverage present|secret server response/);
    assert.ok(f.writes[0].body.body.includes(config.dashboardUrl));
  });
}

for (const reason of ["changed-file failure", "incomplete PR file list", "3000-file PR"]) {
  for (const existing of [false, true]) {
    test(`${reason} with unknown scope ${existing ? "updates only the existing comment" : "cannot create a comment"}`, async () => {
      const f = fixture();
      f.changed.splice(0, 1, { filename: "README.md" });
      if (reason === "changed-file failure") f.failChanges();
      else f.pr.changed_files = reason === "3000-file PR" ? 3000 : 2;
      if (existing) f.comments.push({ id: 21, body: COMMENT_MARKER + "\ncoverage missing",
        user: { login: "github-actions[bot]", type: "Bot" } });
      assert.equal(await reportCompletedRun(f.api, repo, 42, config, "https://github.com"), existing ? "unknown" : "skipped");
      assert.equal(f.writes.length, existing ? 1 : 0);
      assert.ok(f.calls.every((route) => !route.includes("/git/")));
      if (existing) {
        assert.equal(f.writes[0].method, "PATCH");
        assert.equal(f.writes[0].route, "/repos/test/repo/issues/comments/21");
        assert.match(f.writes[0].body.body, /could not be determined/);
        assert.doesNotMatch(f.writes[0].body.body, /coverage present|private changed-file response/);
        assert.ok(f.writes[0].body.body.includes(config.dashboardUrl));
      }
    });
  }
}

test("API errors expose status only and never raw response or credentials", async () => {
  const api = new GitHubApi("https://api.github.test", "private-test-token", (async () =>
    new Response("private-test-token secret response", { status: 403 })) as typeof fetch);
  await assert.rejects(api.request("/repos/test/repo/pulls/7"), (error: Error) => {
    assert.equal(error.message, "GitHub API request failed (403).");
    return true;
  });
  await assert.rejects(api.request("https://attacker.test/"), /Unexpected/);
  assert.throws(() => new GitHubApi("http://api.github.test", "token"));
});

test("API list pagination retrieves a later bot comment", async () => {
  const calls: string[] = [];
  const api = new GitHubApi("https://api.github.test", "fake", (async (url) => {
    calls.push(String(url));
    const page = new URL(String(url)).searchParams.get("page");
    return Response.json(page === "1" ? Array.from({ length: 100 }, (_, id) => ({ id })) : [{ id: 101 }]);
  }) as typeof fetch);
  assert.equal((await api.pages("/repos/test/repo/issues/7/comments")).length, 101);
  assert.equal(calls.length, 2);
});

test("remote files are read only from immutable blob IDs and reject links", async () => {
  const f = fixture();
  const source = await remoteSnapshot(f.api, repo, head);
  assert.equal(await source.read(skillFile), "# Example");
  assert.equal(await source.read(skillFile), "# Example");
  assert.equal(f.calls.filter((route) => route.includes("/git/blobs/")).length, 1);
  await assert.rejects(remoteSnapshot(f.api, repo, "main"), /revision/);
});
