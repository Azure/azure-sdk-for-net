// Uses real temporary Git histories and saved workflow YAML to verify CLI and permission contracts.
import assert from "node:assert/strict";
import { execFileSync, spawnSync } from "node:child_process";
import fs from "node:fs";
import os from "node:os";
import path from "node:path";
import { fileURLToPath } from "node:url";
import { test } from "node:test";
import { parse } from "yaml";
import { CONFIG_PATH, checkCoverage, parseConfig } from "../coverage.ts";
import type { CoverageReport } from "../coverage.ts";
import { gitSnapshot, workingSnapshot } from "../check.ts";

type WorkflowStep = { run?: string; uses?: string };

const packageRoot = fileURLToPath(new URL("..", import.meta.url));
const repoRoot = path.resolve(packageRoot, "../../../..");
const checker = path.join(packageRoot, "check.ts");
const skill = (name: string) => `.github/skills/${name}/SKILL.md`;
const evaluation = (name: string) => `.github/skills/${name}/evals/eval.yaml`;
const config = { skillsRoot: ".github/skills", workflow: ".github/workflows/skill-eval.yml",
  dashboardUrl: "https://dashboard.example.test/", authoringGuideUrl: "https://github.com/test/repo/guide" };

function write(root: string, file: string, text: string): void {
  fs.mkdirSync(path.dirname(path.join(root, file)), { recursive: true });
  fs.writeFileSync(path.join(root, file), text);
}

function git(root: string, ...args: string[]): string {
  return execFileSync("git", ["-C", root, ...args], { encoding: "utf8", timeout: 30000,
    env: { ...process.env, GIT_CONFIG_NOSYSTEM: "1", GIT_CONFIG_GLOBAL: process.platform === "win32" ? "NUL" : "/dev/null" } });
}

function fixture(): string {
  const root = fs.mkdtempSync(path.join(os.tmpdir(), "skill-coverage-git-"));
  git(root, "init", "--quiet");
  git(root, "config", "user.email", "test@example.test");
  git(root, "config", "user.name", "Coverage Test");
  git(root, "config", "core.autocrlf", "false");
  write(root, CONFIG_PATH, JSON.stringify(config));
  write(root, skill("old"), "# Old skill\n");
  write(root, evaluation("old"), "stimuli: [{name: test, prompt: test}]\n");
  git(root, "add", ".");
  git(root, "commit", "--quiet", "-m", "fixture base");
  return root;
}

function cli(root: string, ...args: string[]) {
  return spawnSync(process.execPath, [checker, "--repo-root", root, ...args], {
    encoding: "utf8", timeout: 30000,
    env: { ...process.env, GITHUB_ACTIONS: "false", GITHUB_STEP_SUMMARY: "" },
  });
}

test("real Git rename reports old deletion and checks the new skill", () => {
  const root = fixture();
  try {
    const base = git(root, "rev-parse", "HEAD").trim();
    fs.renameSync(path.join(root, ".github/skills/old"), path.join(root, ".github/skills/new"));
    git(root, "add", "-A"); git(root, "commit", "--quiet", "-m", "rename skill");
    const result = cli(root, "--base", base, "--json");
    assert.equal(result.status, 0, result.stderr);
    const report = JSON.parse(result.stdout) as CoverageReport;
    assert.deepEqual(report.skills.map((item) => [item.name, item.status]), [["new", "present"], ["old", "deleted"]]);
  } finally { fs.rmSync(root, { recursive: true, force: true }); }
});

test("removing the last Eval exits successfully with a warning and dashboard link", () => {
  const root = fixture();
  try {
    const base = git(root, "rev-parse", "HEAD").trim();
    fs.unlinkSync(path.join(root, evaluation("old")));
    git(root, "add", "-A"); git(root, "commit", "--quiet", "-m", "remove eval");
    const result = cli(root, "--base", base);
    assert.equal(result.status, 0, result.stderr);
    assert.match(result.stdout, /coverage missing/);
    assert.ok(result.stdout.includes(config.dashboardUrl));
    assert.match(result.stdout, /This warning will become a build blocker by \*\*November 9, 2026\*\*/);
    assert.match(result.stdout, /warning-only; you may proceed if all other required checks pass/);
  } finally { fs.rmSync(root, { recursive: true, force: true }); }
});

test("working inventory includes new untracked skill files and no historical commits are needed", async () => {
  const root = fixture();
  try {
    write(root, skill("untracked"), "# New\n");
    const result = cli(root, "--all", "--json");
    assert.equal(result.status, 0, result.stderr);
    const report = JSON.parse(result.stdout) as CoverageReport;
    assert.equal(report.skills.find((item) => item.name === "untracked")?.status, "missing");
    const snapshot = gitSnapshot(root, "HEAD");
    assert.equal((await checkCoverage(snapshot, parseConfig(JSON.stringify(config)), null)).skills[0].status, "present");
    assert.ok(workingSnapshot(root).files.some((file) => file.path === skill("untracked")));
  } finally { fs.rmSync(root, { recursive: true, force: true }); }
});

test("missing Git base is an error, not a false passing empty diff", () => {
  const root = fixture();
  try { assert.notEqual(cli(root, "--base", "not-a-ref").status, 0); }
  finally { fs.rmSync(root, { recursive: true, force: true }); }
});

test("the standalone checker runs in a consumer without Tools pipelines or shared Eval scripts", () => {
  const root = fixture();
  try {
    const consumer = path.join(root, "checker");
    fs.mkdirSync(consumer);
    for (const file of ["coverage.ts", "check.ts", "github.ts", "package.json"]) {
      fs.copyFileSync(path.join(packageRoot, file), path.join(consumer, file));
    }
    fs.symlinkSync(path.join(packageRoot, "node_modules"), path.join(consumer, "node_modules"),
      process.platform === "win32" ? "junction" : "dir");
    const result = spawnSync(process.execPath, [path.join(consumer, "check.ts"), "--repo-root", root, "--all", "--json"], {
      encoding: "utf8", timeout: 30000,
      env: { ...process.env, GITHUB_ACTIONS: "false", GITHUB_STEP_SUMMARY: "" },
    });
    assert.equal(result.status, 0, result.stderr);
    assert.deepEqual(JSON.parse(result.stdout).skills.map((item: { name: string; status: string }) => [item.name, item.status]), [["old", "present"]]);
  } finally { fs.rmSync(root, { recursive: true, force: true }); }
});

test("Eval presence is independent of pipeline availability and collector path restrictions", async () => {
  const root = fixture();
  try {
    fs.unlinkSync(path.join(root, evaluation("old")));
    const file = ".github/skills/old/evals/starter case.eval.yaml";
    write(root, file, "stimuli: [{name: test, prompt: test}]\n");
    const report = await checkCoverage(workingSnapshot(root), parseConfig(JSON.stringify(config)), [skill("old")]);
    assert.equal(report.skills[0].status, "present");
    assert.deepEqual(report.skills[0].evals, [file]);
  } finally { fs.rmSync(root, { recursive: true, force: true }); }
});

test("reporter unit tests do not write fixture summaries or workflow commands in Actions", () => {
  const root = fs.mkdtempSync(path.join(os.tmpdir(), "skill-coverage-test-output-"));
  try {
    const summary = path.join(root, "summary.md");
    const original = "Real workflow summary must remain unchanged.\n";
    fs.writeFileSync(summary, original);
    const env: NodeJS.ProcessEnv = { ...process.env, GITHUB_ACTIONS: "true", GITHUB_STEP_SUMMARY: summary };
    delete env.NODE_TEST_CONTEXT;
    const result = spawnSync(process.execPath, ["--test", "--test-reporter=tap", path.join(packageRoot, "test/github.test.ts")], {
      env, encoding: "utf8", timeout: 30000,
    });
    assert.equal(result.status, 0, result.stderr);
    assert.equal(fs.readFileSync(summary, "utf8"), original);
    assert.doesNotMatch(result.stdout + result.stderr, /::(?:warning|error|notice)::/);
  } finally { fs.rmSync(root, { recursive: true, force: true }); }
});

test("read-only workflow preserves the exact blocking lint job", () => {
  const workflow = parse(fs.readFileSync(path.join(repoRoot, ".github/workflows/skill-eval.yml"), "utf8"));
  assert.deepEqual(workflow.permissions, { contents: "read" });
  assert.equal(workflow.on.pull_request, null, "PR path filters must not suppress reverted-skill comment cleanup");
  const lint = workflow.jobs["check-skills"];
  assert.equal(lint["continue-on-error"], undefined);
  assert.equal(lint.needs, "skill-eval-coverage");
  assert.equal(lint.if, "${{ always() && needs.skill-eval-coverage.outputs.run_lint != 'false' }}");
  assert.deepEqual(lint.steps.filter((step: WorkflowStep) => step.run).map((step: WorkflowStep) => step.run), ["npm ci", "./eng/skill-eval/node_modules/.bin/vally lint ."]);
  const coverage = workflow.jobs["skill-eval-coverage"];
  assert.deepEqual(coverage.permissions, { contents: "read", "pull-requests": "read" });
  assert.equal(coverage["continue-on-error"], undefined);
  assert.equal(coverage.outputs.run_lint, "${{ steps.coverage.outputs.run_lint }}");
  assert.equal(coverage.steps.find((step: WorkflowStep) => step.run?.endsWith("github.ts")).id, "coverage");
  assert.deepEqual(Object.keys(workflow.jobs), ["skill-eval-coverage", "check-skills"]);
  assert.ok(coverage.steps.every((step: WorkflowStep) => !step.run?.includes("--test") && !step.run?.includes("npm test")));
});

test("write-enabled reporter uses only default-branch code, no PR artifacts or code checkout", () => {
  const workflow = parse(fs.readFileSync(path.join(repoRoot, ".github/workflows/skill-eval-coverage-comment.yml"), "utf8"));
  assert.deepEqual(Object.keys(workflow.on), ["workflow_run"]);
  assert.deepEqual(workflow.on.workflow_run, { workflows: ["Skill Evaluations"], types: ["completed"] });
  assert.deepEqual(workflow.permissions, {});
  const job = workflow.jobs.comment;
  assert.deepEqual(job.permissions, { contents: "read", actions: "read", "pull-requests": "write" });
  const checkout = job.steps.find((step: WorkflowStep) => step.uses?.startsWith("actions/checkout@"));
  assert.equal(checkout.with.ref, "${{ github.event.repository.default_branch }}");
  assert.equal(checkout.with["persist-credentials"], false);
  assert.equal(checkout.with["sparse-checkout-cone-mode"], false);
  assert.equal(checkout.with["sparse-checkout"], "/.github/skill-eval-coverage.json\n/eng/common/scripts/skill-eval-coverage/\n");
  assert.equal(workflow.concurrency["cancel-in-progress"], false);
  assert.ok(job.steps.some((step: WorkflowStep) => step.run?.endsWith("github.ts --post-comment")));
  assert.ok(job.steps.every((step: WorkflowStep) => !step.uses?.includes("download-artifact") && !step.run?.includes("vally eval")));
});

test("lint, coverage, script tests and trusted reporting all use Node 24", () => {
  let setupSteps = 0;
  for (const file of ["skill-eval.yml", "skill-eval-coverage-comment.yml", "skill-eval-coverage-tests.yml"]) {
    const workflow = parse(fs.readFileSync(path.join(repoRoot, ".github/workflows", file), "utf8"));
    for (const [name, job] of Object.entries(workflow.jobs) as [string, { steps: (WorkflowStep & { with?: Record<string, unknown> })[] }][]) {
      const setup = job.steps.filter((step) => step.uses?.startsWith("actions/setup-node@"));
      assert.equal(setup.length, 1, `${file}: ${name}`);
      assert.equal(String(setup[0].with?.["node-version"]), "24", `${file}: ${name}`);
      setupSteps += setup.length;
    }
  }
  assert.equal(setupSteps, 4);
});

test("coverage workflows pin actions directly to exact commits", () => {
  const files = [".github/workflows/skill-eval.yml", ".github/workflows/skill-eval-coverage-comment.yml",
    ".github/workflows/skill-eval-coverage-tests.yml"];
  assert.equal(fs.existsSync(path.join(repoRoot, ".github/workflows/actions.lock")), false);
  for (const file of files) {
    const workflow = parse(fs.readFileSync(path.join(repoRoot, file), "utf8"));
    for (const job of Object.values(workflow.jobs) as { steps: WorkflowStep[] }[]) {
      for (const step of job.steps) {
        if (step.uses) assert.match(step.uses, /^[^@\s]+@[a-f0-9]{40}$/, file);
        assert.ok(!step.run?.includes("gh actions-lock"), file);
      }
    }
  }
});

test("script tests have a separate read-only workflow and all checker installs use frozen pnpm", () => {
  const testWorkflow = parse(fs.readFileSync(path.join(repoRoot, ".github/workflows/skill-eval-coverage-tests.yml"), "utf8"));
  assert.deepEqual(testWorkflow.permissions, { contents: "read" });
  assert.deepEqual(Object.keys(testWorkflow.on).sort(), ["pull_request", "push", "workflow_dispatch"]);
  assert.ok(testWorkflow.jobs.test.steps.some((step: WorkflowStep) => step.run === "node --test eng/common/scripts/skill-eval-coverage/test/*.test.ts"));
  assert.equal(testWorkflow.jobs.test["continue-on-error"], undefined);
  for (const [file, name] of [["skill-eval.yml", "skill-eval-coverage"], ["skill-eval-coverage-comment.yml", "comment"],
    ["skill-eval-coverage-tests.yml", "test"]]) {
    const workflow = parse(fs.readFileSync(path.join(repoRoot, ".github/workflows", file), "utf8"));
    const install = workflow.jobs[name].steps.find((step: WorkflowStep) => step.run?.includes("pnpm.mjs"));
    assert.ok(install, file);
    assert.match(install.run, /pnpm@12\.6\.0/);
    assert.match(install.run, /--ignore-workspace install --pm-on-fail=ignore --frozen-lockfile --prod --ignore-scripts/);
    assert.equal(install.env, undefined, "checker dependency installs must not receive the GitHub token");
  }
});

test("checker package has exactly one frozen parser dependency and no local workspace links", () => {
  const manifest = JSON.parse(fs.readFileSync(path.join(packageRoot, "package.json"), "utf8"));
  const lock = parse(fs.readFileSync(path.join(packageRoot, "pnpm-lock.yaml"), "utf8"));
  assert.deepEqual(manifest.dependencies, { yaml: "2.9.1" });
  assert.equal(manifest.packageManager, "pnpm@12.6.0");
  assert.deepEqual(Object.keys(lock.importers), ["."]);
  assert.deepEqual(lock.importers["."].dependencies, { yaml: { specifier: "2.9.1", version: "2.9.1" } });
  assert.deepEqual(Object.keys(lock.packages), ["yaml@2.9.1"]);
  assert.equal(lock.packages["yaml@2.9.1"].resolution.integrity, "sha512-3NxN8+78OdzbT7C/WjGsyfPAtJaN3FNDsWxv7Y7mcDsT/oOmgW8BpyQQFFBnvZE3j9Y2Sdz1ULFLezL7Eb2yFw==");
  assert.equal(fs.existsSync(path.join(packageRoot, "package-lock.json")), false);
});
