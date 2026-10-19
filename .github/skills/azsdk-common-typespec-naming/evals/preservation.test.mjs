import assert from "node:assert/strict";
import fs from "node:fs";
import { test } from "node:test";

const original = fs.readFileSync(
  new URL("fixtures/standalone-apply/existing-client.tsp", import.meta.url),
  "utf8",
);
const lines = original.trimEnd().split(/\r?\n/);
const override = '@@clientName(WidgetProperties.enabled, "IsEnabled", "csharp");';

for (const file of [
  new URL("eval.yaml", import.meta.url),
  new URL("../../azure-typespec-author/evaluate/evals/007004.eval.yaml", import.meta.url),
]) {
  const source = fs.readFileSync(file, "utf8");
  const pattern = source.match(/pattern: '(\(\?sm\).*)'/)?.[1];
  assert.ok(pattern, `Missing preservation assertion in ${file}`);
  const matches = new RegExp(pattern.replace("(?sm)", ""), "sm");

  test(`${file.pathname}: accepts insertions without requiring contiguous originals`, () => {
    for (let position = lines.indexOf("namespace Widget;") + 1; position <= lines.length; position++) {
      const changed = [...lines];
      changed.splice(position, 0, override);
      assert.match(changed.join("\n"), matches, `Insertion at line ${position}`);
    }
  });

  test(`${file.pathname}: rejects deleted, changed, or commented-out originals`, () => {
    for (let position = 0; position < lines.length; position++) {
      if (!lines[position].trim()) continue;
      for (const replacement of ["", lines[position].replace(/[A-Za-z]/, "X"), "// " + lines[position]]) {
        const changed = [...lines, override];
        changed[position] = replacement;
        assert.doesNotMatch(changed.join("\n"), matches, `Changed line ${position}: ${replacement}`);
      }
    }
  });
}
