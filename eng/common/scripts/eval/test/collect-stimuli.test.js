// node:test unit tests for collect-stimuli.js (port of Split-EvalSuite.Tests.ps1).
// Run from eng/common/scripts/eval:  npm test

import assert from "node:assert/strict";
import fs from "node:fs";
import os from "node:os";
import path from "node:path";
import { after, before, describe, it } from "node:test";

import { buildMatrix } from "../collect-stimuli.js";

// Helper: write a file, creating parent directories as needed.
function writeFile(filePath, content) {
  fs.mkdirSync(path.dirname(filePath), { recursive: true });
  fs.writeFileSync(filePath, content);
}

// Collect warnings instead of printing them, so tests can assert on them.
function withWarnings(fn) {
  const warnings = [];
  const result = fn((message) => warnings.push(message));
  return { result, warnings };
}

describe("collect-stimuli (shardBy file, default)", () => {
  let root;

  before(() => {
    root = fs.mkdtempSync(path.join(os.tmpdir(), "vally-matrix-"));
    writeFile(
      path.join(root, "evals/tools/prompt-to-tool-github.eval.yaml"),
      "tags:\n  area: github"
    );
    writeFile(
      path.join(root, "evals/tools/add-arm-resource.eval.yaml"),
      "tags:\n  area: typespec"
    );
    writeFile(
      path.join(root, "evals/workflow-scenarios/mock/rename-client-property.eval.yaml"),
      "tags:\n  area: typespec"
    );
    writeFile(
      path.join(root, "evals/workflow-scenarios/live/release-planner.eval.yaml"),
      "x"
    );
  });

  after(() => fs.rmSync(root, { recursive: true, force: true }));

  it("discovers the hermetic mock-vertical files by default", () => {
    const matrix = buildMatrix({ roots: [root] });
    assert.equal(Object.keys(matrix).length, 3);
  });

  it("excludes the live tier from the default pattern", () => {
    const matrix = buildMatrix({ roots: [root] });
    for (const entry of Object.values(matrix)) {
      assert.doesNotMatch(entry.evalArgs, /live\//);
    }
  });

  it("emits one forward-slashed `-e` arg per file", () => {
    const matrix = buildMatrix({ roots: [root] });
    for (const entry of Object.values(matrix)) {
      assert.doesNotMatch(entry.evalArgs, /\\/);
      assert.match(entry.evalArgs, /^-e evals\//);
    }
  });

  it("produces filesystem-safe shard names from the full relative path", () => {
    const matrix = buildMatrix({ roots: [root] });
    const keys = Object.keys(matrix);
    assert.ok(keys.includes("evals_tools_prompt_to_tool_github"));
    assert.ok(keys.includes("evals_workflow_scenarios_mock_rename_client_property"));
    for (const key of keys) {
      assert.match(key, /^[A-Za-z0-9_]+$/);
    }
  });

  it("keeps shard names unique when the immediate parent folder repeats", () => {
    // Two skills both at `<skill>/evals/trigger.eval.yaml` must not collide on a
    // `evals_trigger` name — the full path disambiguates them.
    const skillRoot = fs.mkdtempSync(path.join(os.tmpdir(), "vally-matrix-skills-"));
    writeFile(path.join(skillRoot, "sensei/evals/trigger.eval.yaml"), "x");
    writeFile(path.join(skillRoot, "skill-authoring/evals/trigger.eval.yaml"), "x");
    try {
      const matrix = buildMatrix({
        roots: [skillRoot],
        patterns: ["*/evals/*.eval.yaml"],
      });
      const keys = Object.keys(matrix);
      assert.equal(keys.length, 2);
      assert.ok(keys.includes("sensei_evals_trigger"));
      assert.ok(keys.includes("skill_authoring_evals_trigger"));
    } finally {
      fs.rmSync(skillRoot, { recursive: true, force: true });
    }
  });

  it("throws when no eval files match", () => {
    assert.throws(() =>
      buildMatrix({ roots: [root], patterns: ["evals/none/*.eval.yaml"] })
    );
  });
});

describe("collect-stimuli (shardBy area)", () => {
  let root;

  before(() => {
    root = fs.mkdtempSync(path.join(os.tmpdir(), "vally-matrix-area-"));
    writeFile(
      path.join(root, "evals/tools/prompt-to-tool-github.eval.yaml"),
      "tags:\n  area: github"
    );
    writeFile(
      path.join(root, "evals/tools/add-arm-resource.eval.yaml"),
      "tags:\n  area: typespec"
    );
    writeFile(
      path.join(root, "evals/workflow-scenarios/mock/rename-client-property.eval.yaml"),
      "tags:\n  area: typespec"
    );
    writeFile(
      path.join(root, "evals/workflow-scenarios/live/release-planner.eval.yaml"),
      "x"
    );
  });

  after(() => fs.rmSync(root, { recursive: true, force: true }));

  it("collapses files into one shard per area tag", () => {
    const matrix = buildMatrix({ roots: [root], shardBy: "area" });
    // github (1 file) + typespec (2 files) = 2 shards from 3 files.
    assert.equal(Object.keys(matrix).length, 2);
    assert.ok("area_github" in matrix);
    assert.ok("area_typespec" in matrix);
  });

  it("groups every file of an area into one shard via repeated -e flags", () => {
    const matrix = buildMatrix({ roots: [root], shardBy: "area" });
    const count = (matrix.area_typespec.evalArgs.match(/-e /g) || []).length;
    assert.equal(count, 2);
  });

  it("keeps the live tier out of area shards", () => {
    const matrix = buildMatrix({ roots: [root], shardBy: "area" });
    for (const entry of Object.values(matrix)) {
      assert.doesNotMatch(entry.evalArgs, /live\//);
    }
  });
});

describe("collect-stimuli (shardBy area with an untagged eval)", () => {
  let root;

  before(() => {
    root = fs.mkdtempSync(path.join(os.tmpdir(), "vally-matrix-ut-"));
    writeFile(path.join(root, "evals/tools/tagged.eval.yaml"), "tags:\n  area: github");
    writeFile(path.join(root, "evals/tools/untagged.eval.yaml"), "no tags here");
  });

  after(() => fs.rmSync(root, { recursive: true, force: true }));

  it("falls back to the parent folder name as the area", () => {
    const { result: matrix } = withWarnings((warn) =>
      buildMatrix({
        roots: [root],
        shardBy: "area",
        patterns: ["evals/tools/*.eval.yaml"],
        warn,
      })
    );
    assert.ok("area_github" in matrix);
    assert.ok("area_tools" in matrix);
    assert.match(matrix.area_tools.evalArgs, /untagged\.eval\.yaml/);
  });

  it("does not lump untagged files into a single untagged bucket", () => {
    const { result: matrix } = withWarnings((warn) =>
      buildMatrix({
        roots: [root],
        shardBy: "area",
        patterns: ["evals/tools/*.eval.yaml"],
        warn,
      })
    );
    assert.ok(!("area_untagged" in matrix));
  });

  it("warns when an eval has no area tag", () => {
    const { warnings } = withWarnings((warn) =>
      buildMatrix({
        roots: [root],
        shardBy: "area",
        patterns: ["evals/tools/*.eval.yaml"],
        warn,
      })
    );
    assert.match(warnings.join("\n"), /untagged\.eval\.yaml/);
  });
});

describe("collect-stimuli (overlapping patterns)", () => {
  let root;

  before(() => {
    root = fs.mkdtempSync(path.join(os.tmpdir(), "vally-matrix-overlap-"));
    writeFile(
      path.join(root, "evals/tools/add-arm-resource.eval.yaml"),
      "tags:\n  area: typespec"
    );
    writeFile(
      path.join(root, "evals/tools/prompt-to-tool-github.eval.yaml"),
      "tags:\n  area: github"
    );
  });

  after(() => fs.rmSync(root, { recursive: true, force: true }));

  it("de-dups a file matched by multiple patterns (file mode does not collide)", () => {
    const matrix = buildMatrix({
      roots: [root],
      patterns: ["evals/tools/*.eval.yaml", "evals/tools/add-arm-resource.eval.yaml"],
    });
    const matches = Object.keys(matrix).filter((k) => k === "evals_tools_add_arm_resource");
    assert.equal(matches.length, 1);
  });

  it("does not emit a duplicate -e flag in area mode", () => {
    const matrix = buildMatrix({
      roots: [root],
      shardBy: "area",
      patterns: ["evals/tools/*.eval.yaml", "evals/tools/add-arm-resource.eval.yaml"],
    });
    const count = (matrix.area_typespec.evalArgs.match(/add-arm-resource/g) || []).length;
    assert.equal(count, 1);
  });
});

describe("collect-stimuli (multiple eval roots: repo + common)", () => {
  let repoRoot;
  let commonRoot;

  before(() => {
    repoRoot = fs.mkdtempSync(path.join(os.tmpdir(), "vally-matrix-repo-"));
    commonRoot = fs.mkdtempSync(path.join(os.tmpdir(), "vally-matrix-common-"));
    writeFile(
      path.join(repoRoot, "evals/tools/repo-specific.eval.yaml"),
      "tags:\n  area: repo"
    );
    writeFile(
      path.join(commonRoot, "evals/tools/shared-scenario.eval.yaml"),
      "tags:\n  area: shared"
    );
  });

  after(() => {
    fs.rmSync(repoRoot, { recursive: true, force: true });
    fs.rmSync(commonRoot, { recursive: true, force: true });
  });

  it("collects evals from both roots into one matrix", () => {
    const matrix = buildMatrix({
      roots: [repoRoot, commonRoot],
      patterns: ["evals/tools/*.eval.yaml"],
    });
    const keys = Object.keys(matrix);
    assert.equal(keys.length, 2);
    assert.ok(keys.includes("evals_tools_repo_specific"));
    assert.ok(keys.includes("evals_tools_shared_scenario"));
  });

  it("computes each file's relative path against its own root", () => {
    const matrix = buildMatrix({
      roots: [repoRoot, commonRoot],
      patterns: ["evals/tools/*.eval.yaml"],
    });
    assert.equal(
      matrix.evals_tools_shared_scenario.evalArgs,
      "-e evals/tools/shared-scenario.eval.yaml"
    );
  });
});

describe("collect-stimuli (pathBase anchors scattered roots to one run root)", () => {
  let parent;
  let runRoot;
  let scatteredRoot;

  before(() => {
    // A common parent so the scattered root is a sibling of the run root, yielding a
    // clean `../` relative path.
    parent = fs.mkdtempSync(path.join(os.tmpdir(), "vally-matrix-base-"));
    runRoot = path.join(parent, "project");
    scatteredRoot = path.join(parent, "extra");
    writeFile(path.join(runRoot, "evals/tools/in-project.eval.yaml"), "x");
    writeFile(path.join(scatteredRoot, "evals/out-of-tree.eval.yaml"), "x");
  });

  after(() => fs.rmSync(parent, { recursive: true, force: true }));

  it("anchors every -e path to pathBase, including roots outside it", () => {
    const matrix = buildMatrix({
      roots: [runRoot, scatteredRoot],
      pathBase: runRoot,
      patterns: ["evals/**/*.eval.yaml", "evals/*.eval.yaml"],
    });
    // The in-project file stays a simple relative path; the scattered one walks up.
    assert.equal(
      matrix.evals_tools_in_project.evalArgs,
      "-e evals/tools/in-project.eval.yaml"
    );
    assert.equal(
      matrix.___extra_evals_out_of_tree.evalArgs,
      "-e ../extra/evals/out-of-tree.eval.yaml"
    );
  });

  it("falls back to per-root relative paths when no pathBase is given", () => {
    const matrix = buildMatrix({
      roots: [scatteredRoot],
      patterns: ["evals/*.eval.yaml"],
    });
    // Without a base, the path is relative to the root it was found under (no `../`).
    assert.equal(
      matrix.evals_out_of_tree.evalArgs,
      "-e evals/out-of-tree.eval.yaml"
    );
  });
});

