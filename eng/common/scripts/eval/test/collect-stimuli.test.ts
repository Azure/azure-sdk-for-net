// node:test unit tests for collect-stimuli.ts (port of Split-EvalSuite.Tests.ps1).
// Run from eng/common/scripts/eval:  npm test
//
// Sharding is always by `area` tag: one shard per area, each carrying every eval of that
// area via repeated `-e` flags. Untagged evals fall back to their parent folder.

import assert from "node:assert/strict";
import fs from "node:fs";
import os from "node:os";
import path from "node:path";
import { after, before, describe, it } from "node:test";

import { buildMatrix } from "../collect-stimuli.ts";

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

describe("collect-stimuli (default discovery)", () => {
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
      "tags:\n  area: release-plan"
    );
  });

  after(() => fs.rmSync(root, { recursive: true, force: true }));

  it("discovers the hermetic mock-vertical files by default", () => {
    // github (1 file) + typespec (2 files) = 2 area shards from 3 files.
    const matrix = buildMatrix({ roots: [root] });
    assert.equal(Object.keys(matrix).length, 2);
    assert.ok("area_github" in matrix);
    assert.ok("area_typespec" in matrix);
  });

  it("excludes the live tier from the default pattern", () => {
    const matrix = buildMatrix({ roots: [root] });
    for (const entry of Object.values(matrix)) {
      assert.doesNotMatch(entry.evalArgs, /live\//);
    }
    assert.ok(!("area_release_plan" in matrix));
  });

  it("emits forward-slashed `-e` args", () => {
    const matrix = buildMatrix({ roots: [root] });
    for (const entry of Object.values(matrix)) {
      assert.doesNotMatch(entry.evalArgs, /\\/);
      assert.match(entry.evalArgs, /^-e evals\//);
    }
  });

  it("produces filesystem-safe shard names", () => {
    const matrix = buildMatrix({ roots: [root] });
    for (const key of Object.keys(matrix)) {
      assert.match(key, /^[A-Za-z0-9_]+$/);
    }
  });

  it("throws when no eval files match", () => {
    assert.throws(() =>
      buildMatrix({ roots: [root], patterns: ["evals/none/*.eval.yaml"] })
    );
  });
});

describe("collect-stimuli (area grouping)", () => {
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
  });

  after(() => fs.rmSync(root, { recursive: true, force: true }));

  it("collapses files into one shard per area tag", () => {
    const matrix = buildMatrix({ roots: [root] });
    // github (1 file) + typespec (2 files) = 2 shards from 3 files.
    assert.equal(Object.keys(matrix).length, 2);
    assert.ok("area_github" in matrix);
    assert.ok("area_typespec" in matrix);
  });

  it("groups every file of an area into one shard via repeated -e flags", () => {
    const matrix = buildMatrix({ roots: [root] });
    const count = (matrix.area_typespec.evalArgs.match(/-e /g) || []).length;
    assert.equal(count, 2);
  });

  it("throws when two area tags collide after sanitization", () => {
    const collideRoot = fs.mkdtempSync(path.join(os.tmpdir(), "vally-matrix-area-collide-"));
    try {
      writeFile(
        path.join(collideRoot, "evals/tools/a.eval.yaml"),
        "tags:\n  area: release-plan"
      );
      writeFile(
        path.join(collideRoot, "evals/tools/b.eval.yaml"),
        "tags:\n  area: release_plan"
      );
      assert.throws(
        () => buildMatrix({ roots: [collideRoot] }),
        /Duplicate shard name 'area_release_plan'/
      );
    } finally {
      fs.rmSync(collideRoot, { recursive: true, force: true });
    }
  });
});

describe("collect-stimuli (area with an untagged eval)", () => {
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

  it("does not emit a duplicate -e flag for a file matched by multiple patterns", () => {
    const matrix = buildMatrix({
      roots: [root],
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
    assert.ok(keys.includes("area_repo"));
    assert.ok(keys.includes("area_shared"));
  });

  it("computes each file's relative path against its own root", () => {
    const matrix = buildMatrix({
      roots: [repoRoot, commonRoot],
      patterns: ["evals/tools/*.eval.yaml"],
    });
    assert.equal(
      matrix.area_shared.evalArgs,
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
    writeFile(
      path.join(runRoot, "evals/tools/in-project.eval.yaml"),
      "tags:\n  area: inproject"
    );
    writeFile(
      path.join(scatteredRoot, "evals/out-of-tree.eval.yaml"),
      "tags:\n  area: scattered"
    );
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
      matrix.area_inproject.evalArgs,
      "-e evals/tools/in-project.eval.yaml"
    );
    assert.equal(
      matrix.area_scattered.evalArgs,
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
      matrix.area_scattered.evalArgs,
      "-e evals/out-of-tree.eval.yaml"
    );
  });
});
