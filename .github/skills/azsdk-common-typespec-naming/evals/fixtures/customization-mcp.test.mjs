import assert from "node:assert/strict";
import fs from "node:fs";
import os from "node:os";
import path from "node:path";
import { spawnSync } from "node:child_process";
import { fileURLToPath } from "node:url";
import { test } from "node:test";
import { handleRequest } from "./customization-mcp.mjs";

const validationCall = (typeSpecProjectRootPath) => ({
  jsonrpc: "2.0",
  id: 3,
  method: "tools/call",
  params: {
    name: "azsdk_run_typespec_validation",
    arguments: { typeSpecProjectRootPath },
  },
});

test("fixture exposes customization as a trap and validation with production arguments", () => {
  const result = handleRequest({ id: 1, method: "tools/list" }).result;
  assert.deepEqual(result.tools.map((tool) => tool.name), [
    "azsdk_customized_code_update",
    "azsdk_run_typespec_validation",
  ]);
  assert.deepEqual(result.tools[1].inputSchema.required, [
    "typeSpecProjectRootPath",
  ]);
});

test("customization calls fail explicitly instead of pretending to edit", () => {
  const result = handleRequest({
    id: 2,
    method: "tools/call",
    params: {
      name: "azsdk_customized_code_update",
      arguments: { editScope: "SpecInputs", tspProjectPath: "/fixtures/Widget" },
    },
  }).result;
  assert.equal(result.isError, true);
  assert.match(result.content[0].text, /Unexpected customization call/);
});

test("validation requires a project root", () => {
  assert.equal(handleRequest(validationCall("")).result.isError, true);
});

test("validation requires an applied override and entrypoint loading", (t) => {
  const root = fs.mkdtempSync(path.join(os.tmpdir(), "naming-fixture-"));
  t.after(() => fs.rmSync(root, { recursive: true }));
  const validate = () => handleRequest(validationCall(root)).result;
  assert.equal(validate().isError, true);
  fs.writeFileSync(path.join(root, "main.tsp"), "namespace Widget;");
  fs.writeFileSync(
    path.join(root, "client.tsp"),
    '@@clientName(Widget.WidgetProperties.enabled, "IsEnabled", "csharp");',
  );
  assert.equal(validate().isError, true);
  fs.writeFileSync(
    path.join(root, "main.tsp"),
    'import "./client.tsp";\nnamespace Widget;',
  );
  const result = JSON.parse(validate().content[0].text);
  assert.equal(result.Success, true);
  assert.match(result.Message, /compile command next/);
  fs.writeFileSync(
    path.join(root, "client.tsp"),
    '@@clientName(Widget.WidgetProperties.enabled, "IsEnabled", "java");',
  );
  assert.equal(validate().isError, true);
});

test("unknown tools and methods fail explicitly; notifications need no response", () => {
  assert.equal(handleRequest({ method: "notifications/initialized" }), null);
  assert.equal(handleRequest({ id: 1, method: "missing" }).error.code, -32601);
  const request = validationCall("");
  request.params.name = "missing";
  assert.equal(handleRequest(request).error.code, -32602);
});

test("stdio handshake advertises tools without dependencies or file writes", () => {
  const messages = [
    {
      id: 0,
      method: "initialize",
      params: { protocolVersion: "2024-11-05" },
    },
    { method: "notifications/initialized" },
    { id: 1, method: "tools/list" },
    validationCall(""),
  ];
  const result = spawnSync(
    process.execPath,
    [fileURLToPath(new URL("./customization-mcp.mjs", import.meta.url))],
    {
      input: messages.map(JSON.stringify).join("\n") + "\n",
      encoding: "utf8",
    },
  );
  assert.equal(result.status, 0, result.stderr);
  const responses = result.stdout.trim().split("\n").map(JSON.parse);
  assert.equal(responses.length, 3);
  assert.equal(responses[0].result.protocolVersion, "2024-11-05");
  assert.equal(responses[1].result.tools.length, 2);
  assert.equal(responses[2].result.isError, true);
});
