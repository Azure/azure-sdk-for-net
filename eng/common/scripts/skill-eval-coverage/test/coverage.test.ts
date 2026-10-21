// Covers coverage scope, alternate suites, malformed inputs, and safe PR Markdown.
import assert from "node:assert/strict";
import { test } from "node:test";
import {
  CONFIG_PATH, MAX_FILE_BYTES, checkCoverage, hasCoverageWarnings, parseConfig,
  renderReport, repositoryPath,
} from "../coverage.ts";
import type { CoverageConfig, RepositorySnapshot } from "../coverage.ts";

const config: CoverageConfig = {
  skillsRoot: ".github/skills",
  pipelines: ["eng/common/pipelines/skill-eval.yml", "eng/pipelines/benchmark.yml"],
  workflow: ".github/workflows/skill-eval.yml",
  dashboardUrl: "https://dashboard.example.test/",
  authoringGuideUrl: "https://github.com/test/repo/blob/main/guide.md",
};
const pipeline = "parameters:\n  vallyRoot: .github/skills\n  evalGlobs:\n    - '*/evals/*.eval.yaml'\n    - '*/evals/eval.yaml'\n";
const benchmark = "jobs:\n  - parameters:\n      vallyRoot: .github/skills/alternate/evaluate\n      evalGlobs: ['evals/*.eval.yaml']\n";
const stimulus = "name: example\nstimuli:\n  - name: trigger-example\n    prompt: Test the skill\n    graders: [{type: skill-invocation}]\n";
const skill = (name: string) => `.github/skills/${name}/SKILL.md`;
const evaluation = (name: string) => `.github/skills/${name}/evals/eval.yaml`;

function snapshot(extra: Record<string, string>, modes: Record<string, string> = {}): RepositorySnapshot {
  const contents = { [config.pipelines[0]]: pipeline, [config.pipelines[1]]: benchmark, ...extra };
  return {
    files: Object.entries(contents).map(([file, text]) => ({
      path: file, mode: modes[file] ?? "100644", size: Buffer.byteLength(text),
    })),
    async read(file) { return contents[file]; },
  };
}

test("new uncovered skill warns; an unchanged existing Eval covers a skill-only edit", async () => {
  const report = await checkCoverage(snapshot({
    [skill("missing")]: "# Skill", [skill("present")]: "# Skill", [evaluation("present")]: stimulus,
    [skill("unrelated")]: "# Skill",
  }), config, [skill("missing"), skill("present")]);
  assert.deepEqual(report.skills.map((item) => [item.name, item.status]), [["missing", "missing"], ["present", "present"]]);
  assert.equal(hasCoverageWarnings(report), true);
  assert.equal(report.fullScan, false);
});

test("reference-only and Eval deletion changes check the owning skill", async () => {
  const report = await checkCoverage(snapshot({ [skill("example")]: "# Skill" }), config,
    [".github/skills/example/references/guide.md", evaluation("example")]);
  assert.equal(report.skills.length, 1);
  assert.equal(report.skills[0].status, "missing");
});

test("deleted skills are skipped; renamed skills check old and new paths", async () => {
  const report = await checkCoverage(snapshot({ [skill("new")]: "# Skill", [evaluation("new")]: stimulus }),
    config, [skill("old"), evaluation("old"), skill("new"), evaluation("new")]);
  assert.deepEqual(report.skills.map((item) => [item.name, item.status]), [["new", "present"], ["old", "deleted"]]);
  assert.equal(hasCoverageWarnings(report), false);
});

test("guides and fixture directories without SKILL.md do not invent skills", async () => {
  const report = await checkCoverage(snapshot({}), config, [".github/skills/eval-authoring/README.md"]);
  assert.deepEqual(report.skills, []);
});

test("alternate benchmark is covered using the pipeline's actual discovery configuration", async () => {
  const file = ".github/skills/alternate/evaluate/evals/001001.eval.yaml";
  const report = await checkCoverage(snapshot({ [skill("alternate")]: "# Skill", [file]: stimulus }), config, [skill("alternate")]);
  assert.equal(report.skills[0].status, "present");
  assert.deepEqual(report.skills[0].evals, [file]);
});

test("an existing Eval outside the pipeline glob is reported as undiscovered", async () => {
  const file = ".github/skills/example/evals/nested/behavior.eval.yaml";
  const report = await checkCoverage(snapshot({ [skill("example")]: "# Skill", [file]: stimulus }), config, [skill("example")]);
  assert.equal(report.skills[0].status, "missing");
  assert.deepEqual(report.skills[0].undiscovered, [file]);
  assert.match(report.skills[0].issues.join(" "), /no configured pipeline discovers/);
});

test("fixing discovery clears the missing-coverage result without historical state", async () => {
  const file = ".github/skills/example/evals/nested/behavior.eval.yaml";
  const source = snapshot({ [skill("example")]: "# Skill", [file]: stimulus,
    [config.pipelines[0]]: "vallyRoot: .github/skills\nevalGlobs: ['*/evals/**/*.eval.yaml']\n" });
  const report = await checkCoverage(source, config, [config.pipelines[0]]);
  assert.equal(report.skills[0].status, "present");
  assert.deepEqual(report.skills[0].undiscovered, []);
  assert.equal(hasCoverageWarnings(report), false);
});

test("discovery uses the shared pipeline glob rules for dots and literal metacharacters", async () => {
  const file = ".github/skills/example/evals/.hidden.eval.yaml";
  const report = await checkCoverage(snapshot({ [skill("example")]: "# Skill", [file]: stimulus }), config, [skill("example")]);
  assert.equal(report.skills[0].status, "present");
  const literal = await checkCoverage(snapshot({ [skill("example")]: "# Skill", [evaluation("example")]: stimulus,
    [config.pipelines[0]]: "vallyRoot: .github/skills\nevalGlobs: ['*/evals/{eval,trigger}.yaml']\n" }), config, [skill("example")]);
  assert.equal(literal.skills[0].status, "missing");
});

for (const [name, file] of [
  ["example", ".github/skills/example/evals/starter case.eval.yaml"],
  ["example", ".github/skills/example/evals/starter\u00a0case.eval.yaml"],
  ["example skill", ".github/skills/example skill/evals/starter.eval.yaml"],
]) {
  test(`collector-incompatible whitespace cannot count as coverage: ${file}`, async () => {
    const report = await checkCoverage(snapshot({ [skill(name)]: "# Skill", [file]: stimulus }), config, [skill(name)]);
    assert.equal(report.skills[0].status, "missing");
    assert.deepEqual(report.skills[0].evals, []);
    assert.match(report.skills[0].issues.join(" "), /whitespace/);
  });
}

test("whitespace in a benchmark root is not part of its collector-relative Eval path", async () => {
  const name = "alternate suite";
  const file = `.github/skills/${name}/evaluate/evals/starter.eval.yaml`;
  const report = await checkCoverage(snapshot({ [skill(name)]: "# Skill", [file]: stimulus,
    [config.pipelines[1]]: `vallyRoot: .github/skills/${name}/evaluate\nevalGlobs: ['evals/*.eval.yaml']\n`,
  }), config, [skill(name)]);
  assert.equal(report.skills[0].status, "present");
  assert.deepEqual(report.skills[0].evals, [file]);
});

for (const [label, text] of Object.entries({
  empty: "", comment: "# placeholder", malformed: "stimuli: [", duplicate: "stimuli: []\nstimuli: []",
  noStimuli: "name: placeholder", blankPrompt: "stimuli: [{name: example, prompt: ' '}]",
  noName: "stimuli: [{prompt: hello}]", wrongShape: "stimuli: hello",
})) {
  test(`${label} Eval is not coverage`, async () => {
    const report = await checkCoverage(snapshot({ [skill("example")]: "# Skill", [evaluation("example")]: text }), config, [skill("example")]);
    assert.equal(report.skills[0].status, "missing");
    assert.match(report.skills[0].issues.join(" "), /Invalid Eval YAML/);
  });
}

test("YAML anchors and multi-turn stimuli are accepted without running commands", async () => {
  const text = "shared: &shared 'hello'\nstimuli:\n  - name: turns\n    turns: [*shared, *shared]\n";
  const report = await checkCoverage(snapshot({ [skill("example")]: "# Skill", [evaluation("example")]: text }), config, [skill("example")]);
  assert.equal(report.skills[0].status, "present");
});

test("a discoverable Eval with nonempty string turns provides coverage without a prompt", async () => {
  const text = "stimuli: [{name: conversation, turns: ['Inspect the input', 'Now continue']}]\n";
  const report = await checkCoverage(snapshot({ [skill("example")]: "# Skill", [evaluation("example")]: text }), config, [skill("example")]);
  assert.equal(report.skills[0].status, "present");
  assert.deepEqual(report.skills[0].evals, [evaluation("example")]);
});

for (const turns of ["[{prompt: first}, {prompt: second}]", "['first', {prompt: second}]", "['first', ' ']", "[]", "first"]) {
  for (const prompt of ["", "prompt: 'A standalone prompt cannot repair invalid turns', "]) {
    test(`invalid multi-turn shape cannot provide coverage: ${prompt}${turns}`, async () => {
      const text = `stimuli: [{name: conversation, ${prompt}turns: ${turns}}]\n`;
      const report = await checkCoverage(snapshot({ [skill("example")]: "# Skill", [evaluation("example")]: text }), config, [skill("example")]);
      assert.equal(report.skills[0].status, "missing");
      assert.deepEqual(report.skills[0].evals, []);
    });
  }
}

test("normal repeated grading aliases do not falsely invalidate an Eval", async () => {
  const text = "grader: &g {type: output-contains, config: {value: yes}}\nstimuli:\n" +
    Array.from({ length: 40 }, (_, index) => `  - name: case-${index}\n    prompt: test\n    graders: [*g]\n`).join("");
  const report = await checkCoverage(snapshot({ [skill("example")]: "# Skill", [evaluation("example")]: text }), config, [skill("example")]);
  assert.equal(report.skills[0].status, "present");
});

test("unrelated YAML fixtures and symlink Evals cannot claim coverage", async () => {
  const report = await checkCoverage(snapshot({ [skill("example")]: "# Skill", [evaluation("example")]: stimulus,
    ".github/skills/example/evals/fixtures/tspconfig.yaml": stimulus,
  }, { [evaluation("example")]: "120000" }), config, [skill("example")]);
  assert.equal(report.skills[0].status, "missing");
  assert.deepEqual(report.skills[0].evals, []);
});

test("oversized Evals and symlink skill definitions warn without following links", async () => {
  const report = await checkCoverage(snapshot({
    [skill("large")]: "# Skill", [evaluation("large")]: "x".repeat(MAX_FILE_BYTES + 1),
    [skill("link")]: "outside/skill", [evaluation("link")]: stimulus,
  }, { [skill("link")]: "120000" }), config, [skill("large"), skill("link")]);
  assert.ok(report.skills.every((item) => item.status === "missing"));
});

for (const change of [CONFIG_PATH, config.pipelines[0], ".github/skills/.vally.yaml"]) {
  test(`shared configuration change inventories all skills: ${change}`, async () => {
    const report = await checkCoverage(snapshot({ [skill("first")]: "# Skill", [skill("second")]: "# Skill" }), config, [change]);
    assert.equal(report.fullScan, true);
    assert.equal(report.skills.length, 2);
  });
}

test("broken discovery configuration warns instead of claiming a pass", async () => {
  const report = await checkCoverage(snapshot({ [config.pipelines[0]]: "not: discovery", [skill("example")]: "# Skill",
    [evaluation("example")]: stimulus }), config, [skill("example")]);
  assert.equal(hasCoverageWarnings(report), true);
  assert.match(report.configurationIssues[0], /Cannot read literal/);
});

test("transport errors propagate rather than treating an unread Eval as covered", async () => {
  const source = snapshot({ [skill("example")]: "# Skill", [evaluation("example")]: stimulus });
  const original = source.read;
  source.read = async (file) => { if (file === evaluation("example")) throw new Error("network"); return original(file); };
  await assert.rejects(checkCoverage(source, config, [skill("example")]), /network/);
});

test("both coverage outcomes, deleted-only, and unknown results keep dashboard and guide links", async () => {
  for (const text of [stimulus, ""]) {
    const report = await checkCoverage(snapshot({ [skill("example")]: "# Skill", [evaluation("example")]: text }), config, [skill("example")]);
    const markdown = renderReport(report, { config, sourceUrl: "https://github.com/test/repo/blob/head", runUrl: "https://github.com/test/repo/actions/runs/1" });
    assert.ok(markdown.includes(config.dashboardUrl));
    assert.ok(markdown.includes(config.authoringGuideUrl));
    assert.match(markdown, text ? /coverage present/ : /coverage missing/);
    assert.match(markdown, /does not run Evals/);
    assert.doesNotMatch(markdown, /Evals passed/);
  }
  const unknown = renderReport(null, { config });
  assert.match(unknown, /could not be determined/);
  assert.ok(unknown.includes(config.dashboardUrl));
});

test("untrusted paths are escaped in Markdown, including mentions and image syntax", async () => {
  const name = "bad![x](@team)|<tag>";
  const report = await checkCoverage(snapshot({ [skill(name)]: "# Skill" }), config, [skill(name)]);
  const markdown = renderReport(report, { config });
  assert.doesNotMatch(markdown, /@team|!\[x\]|<tag>/);
  assert.match(markdown, /&#64;team/);
});

test("configuration and repository paths reject traversal, commands and insecure links", () => {
  for (const invalid of ["../outside", "/absolute", "a//b", "a\\b", "a\nb", "C:/file"]) {
    assert.throws(() => repositoryPath(invalid));
  }
  assert.deepEqual(parseConfig(JSON.stringify(config)), config);
  assert.throws(() => parseConfig(JSON.stringify({ ...config, dashboardUrl: "http://host/" })));
  assert.throws(() => parseConfig(JSON.stringify({ ...config, pipelines: [] })));
});
