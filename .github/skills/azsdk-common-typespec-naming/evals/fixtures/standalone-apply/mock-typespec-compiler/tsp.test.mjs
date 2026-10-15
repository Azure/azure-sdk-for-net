import assert from "node:assert/strict";
import fs from "node:fs";
import os from "node:os";
import path from "node:path";
import { spawnSync } from "node:child_process";
import { afterEach, beforeEach, test } from "node:test";
import { fileURLToPath } from "node:url";

const compilerPath = fileURLToPath(new URL("./tsp.mjs", import.meta.url));
const fixtureRoot = path.resolve(path.dirname(compilerPath), "..");

let projectRoot;

beforeEach(() => {
  projectRoot = fs.mkdtempSync(path.join(os.tmpdir(), "typespec-naming-"));
  for (const file of ["main.tsp", "client.tsp", "tspconfig.yaml"]) {
    fs.copyFileSync(path.join(fixtureRoot, file), path.join(projectRoot, file));
  }
});

afterEach(() => {
  fs.rmSync(projectRoot, { recursive: true, force: true });
});

function compile() {
  return spawnSync(process.execPath, [compilerPath, "compile", "."], {
    cwd: projectRoot,
    encoding: "utf8",
  });
}

function appendCsharpOverride() {
  fs.appendFileSync(
    path.join(projectRoot, "client.tsp"),
    '\n@@clientName(WidgetProperties.enabled, "IsEnabled", "csharp");\n',
  );
}

test("accepts the scoped C# override while preserving existing languages", () => {
  appendCsharpOverride();

  const result = compile();

  assert.equal(result.status, 0, result.stderr);
  assert.match(result.stdout, /TypeSpec compilation succeeded/);
});

test("rejects a missing C# override", () => {
  const result = compile();

  assert.notEqual(result.status, 0);
  assert.match(result.stderr, /C# WidgetProperties\.enabled -> IsEnabled/);
});

test("rejects removal of the existing Java override", () => {
  appendCsharpOverride();
  const clientPath = path.join(projectRoot, "client.tsp");
  fs.writeFileSync(
    clientPath,
    fs.readFileSync(clientPath, "utf8").replace("EnabledForJava", "Changed"),
  );

  const result = compile();

  assert.notEqual(result.status, 0);
  assert.match(result.stderr, /existing Java override/);
});

test("rejects removal of the existing Python override", () => {
  appendCsharpOverride();
  const clientPath = path.join(projectRoot, "client.tsp");
  fs.writeFileSync(
    clientPath,
    fs
      .readFileSync(clientPath, "utf8")
      .replace("enabled_for_python", "changed"),
  );

  const result = compile();

  assert.notEqual(result.status, 0);
  assert.match(result.stderr, /existing Python override/);
});

test("rejects naming customization in main.tsp", () => {
  appendCsharpOverride();
  fs.appendFileSync(
    path.join(projectRoot, "main.tsp"),
    '\n@@clientName(WidgetProperties.enabled, "WrongFile", "csharp");\n',
  );

  const result = compile();

  assert.notEqual(result.status, 0);
  assert.match(result.stderr, /must not modify main\.tsp/);
});
