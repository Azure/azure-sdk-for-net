// Tests for init-eval-git-fixtures.ts — discovery only (the dry-run path that clones nothing).

import assert from "node:assert/strict";
import fs from "node:fs";
import os from "node:os";
import path from "node:path";
import { fileURLToPath } from "node:url";
import { after, before, describe, it } from "node:test";

import { dedupeFixtures, getEvalGitFixtures } from "../init-eval-git-fixtures.ts";

const here = path.dirname(fileURLToPath(import.meta.url));

describe("getEvalGitFixtures discovery", () => {
  let root;

  before(() => {
    // Throwaway eval tree so the tests do not depend on real eval content.
    root = fs.mkdtempSync(path.join(os.tmpdir(), "vally-fixtures-test-"));
    fs.mkdirSync(path.join(root, "tools"), { recursive: true });
    fs.mkdirSync(path.join(root, "workflows/mock"), { recursive: true });

    // A unit eval with NO git fixture.
    fs.writeFileSync(
      path.join(root, "tools/prompt-to-tool-github.eval.yaml"),
      "tags:\n  area: github\nstimuli:\n  - name: x\n"
    );

    // A workflow eval declaring the same azure-rest-api-specs fixture twice
    // (two stimuli) — should collapse to one unique fixture.
    const mock = [
      "stimuli:",
      "  - name: a",
      "    environment:",
      "      git:",
      "        type: worktree",
      "        source: ../../../../../../artifacts/specs-cache/azure-rest-api-specs",
      "        ref: main",
      "  - name: b",
      "    environment:",
      "      git:",
      "        type: worktree",
      "        source: ../../../../../../artifacts/specs-cache/azure-rest-api-specs",
      "        ref: main",
      "",
    ].join("\n");
    fs.writeFileSync(
      path.join(root, "workflows/mock/release-planner-workflows.eval.yaml"),
      mock
    );
  });

  after(() => {
    fs.rmSync(root, { recursive: true, force: true });
  });

  it("discovers the declared git fixture", () => {
    const fixtures = dedupeFixtures(getEvalGitFixtures({ root }));
    assert.equal(fixtures.length, 1);
  });

  it("deduplicates identical fixtures across stimuli", () => {
    const fixtures = dedupeFixtures(getEvalGitFixtures({ root }));
    const specs = fixtures.filter((f) => f.repoName === "azure-rest-api-specs");
    assert.equal(specs.length, 1);
  });

  it("parses the repo name, ref, and resolves an absolute cache path", () => {
    const fixtures = dedupeFixtures(getEvalGitFixtures({ root }));
    const f = fixtures[0];
    assert.equal(f.repoName, "azure-rest-api-specs");
    assert.equal(f.ref, "main");
    assert.match(f.cachePath, /artifacts[\\/]specs-cache[\\/]azure-rest-api-specs$/);
    assert.doesNotMatch(f.cachePath, /\.\./); // '..' segments must be collapsed
    assert.ok(path.isAbsolute(f.cachePath));
  });

  it("is a no-op when the scanned suite declares no git fixtures", () => {
    const fixtures = getEvalGitFixtures({ root, patterns: ["tools/*.eval.yaml"] });
    assert.equal(fixtures.length, 0);
  });

  it("defaults the ref to main when none is declared", () => {
    const noRef = [
      "stimuli:",
      "  - name: a",
      "    environment:",
      "      git:",
      "        type: worktree",
      "        source: ../../../../../../artifacts/specs-cache/some-other-repo",
      "",
    ].join("\n");
    const file = path.join(root, "workflows/mock/no-ref.eval.yaml");
    fs.writeFileSync(file, noRef);
    try {
      const fixtures = dedupeFixtures(getEvalGitFixtures({ root }));
      const other = fixtures.find((f) => f.repoName === "some-other-repo");
      assert.ok(other);
      assert.equal(other.ref, "main");
    } finally {
      fs.rmSync(file, { force: true });
    }
  });
});

// Folder-level invariant guard (runs against the REAL Vally eval tree when present). Because
// Vally resolves `git.source` relative to each eval file's own directory (no repo-root/env
// anchor — see microsoft/vally#562), the only way a single repo-relative path stays correct is
// if every git-fixture eval sits at the same depth and points at the same cache root. These tests
// fail loudly if a new fixture file is dropped at the wrong level. In synced repos that do not
// contain the Vally suite they skip.
describe("Folder-level invariant for real git fixtures", () => {
  const repoRoot = path.resolve(here, "../../../../..");
  const vallyRoot = path.join(repoRoot, "evals");
  const evalRoots = [path.join(vallyRoot, "tools"), path.join(vallyRoot, "workflows")];
  const present = evalRoots.some((root) => fs.existsSync(root));

  const expectedCacheRoot = path
    .join(repoRoot, "artifacts", "specs-cache")
    .replace(/[\\/]+$/, "");

  function collectRealFixtures() {
    const srcRegex = /^\s*source:\s*(\.\.\S+)/gm;
    const results = [];
    const stack = evalRoots.filter((root) => fs.existsSync(root));
    while (stack.length > 0) {
      const dir = stack.pop();
      for (const entry of fs.readdirSync(dir, { withFileTypes: true })) {
        const full = path.join(dir, entry.name);
        if (entry.isDirectory()) {
          stack.push(full);
        } else if (entry.name.endsWith(".eval.yaml")) {
          const content = fs.readFileSync(full, "utf8");
          let m;
          srcRegex.lastIndex = 0;
          while ((m = srcRegex.exec(content)) !== null) {
            const source = m[1];
            const abs = path.resolve(path.dirname(full), source);
            results.push({
              file: full,
              source,
              parent: path.dirname(abs).replace(/[\\/]+$/, ""),
              depth: source.split(/[\\/]/).filter((s) => s === "..").length,
            });
          }
        }
      }
    }
    return results;
  }

  it("every git-fixture source resolves to the canonical artifacts/specs-cache root", { skip: !present }, () => {
    for (const f of collectRealFixtures()) {
      assert.equal(f.parent, expectedCacheRoot, `${f.file} declares source '${f.source}'`);
    }
  });

  it("all git-fixture eval files sit at the same folder depth", { skip: !present }, () => {
    const depths = [...new Set(collectRealFixtures().map((f) => f.depth))];
    assert.ok(depths.length <= 1, "a uniform ../ depth keeps one relative path valid for every fixture file");
  });
});
