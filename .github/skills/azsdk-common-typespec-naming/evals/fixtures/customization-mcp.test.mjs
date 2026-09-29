import assert from "node:assert/strict";
import { spawnSync } from "node:child_process";
import { fileURLToPath } from "node:url";
import { test } from "node:test";
import { handleRequest } from "./customization-mcp.mjs";

const args = {
  customizationRequest:
    "For csharp ARM, rename WidgetProperties.enabled to IsEnabled; preserve wire names.",
  tspProjectPath: "/fixtures/Widget",
  editScope: "SpecInputs",
};
const call = (argumentsValue = args) => ({
  jsonrpc: "2.0",
  id: 2,
  method: "tools/call",
  params: {
    name: "azsdk_customized_code_update",
    arguments: argumentsValue,
  },
});

test("fixture advertises the customization tool and edit scopes", () => {
  const result = handleRequest({ id: 1, method: "tools/list" }).result;
  assert.equal(result.tools.length, 1);
  assert.equal(result.tools[0].name, "azsdk_customized_code_update");
  assert.deepEqual(result.tools[0].inputSchema.properties.editScope.enum, [
    "SpecInputs",
    "CustomCode",
    "All",
  ]);
});

test("successful spec-only response does not claim SDK or TypeSpec validation", () => {
  const result = JSON.parse(handleRequest(call()).result.content[0].text);
  assert.equal(result.Success, true);
  assert.match(result.Message, /validation were not run/);
  assert.match(result.TypeSpecChangesSummary[0], /csharp-scoped/);
});

test("customization failures remain failures", () => {
  const result = JSON.parse(handleRequest(call(), true).result.content[0].text);
  assert.equal(result.Success, false);
  assert.equal(result.ErrorCode, "CustomizationFailed");
});

for (const invalid of [
  { ...args, editScope: undefined },
  { ...args, editScope: "All" },
  { ...args, editScope: "CustomCode" },
  { ...args, tspProjectPath: "" },
  { ...args, customizationRequest: "" },
  { ...args, packagePath: "/sdk/Widget" },
]) {
  test(`fixture rejects invalid apply contract ${JSON.stringify(invalid)}`, () => {
    assert.equal(handleRequest(call(invalid)).result.isError, true);
  });
}

test("unknown tools and methods fail explicitly; notifications need no response", () => {
  assert.equal(handleRequest({ method: "notifications/initialized" }), null);
  assert.equal(handleRequest({ id: 1, method: "missing" }).error.code, -32601);
  const request = call();
  request.params.name = "missing";
  assert.equal(handleRequest(request).error.code, -32602);
});

test("stdio handshake and customization work without dependencies or file writes", () => {
  const messages = [
    {
      id: 0,
      method: "initialize",
      params: { protocolVersion: "2024-11-05" },
    },
    { method: "notifications/initialized" },
    { id: 1, method: "tools/list" },
    call(),
  ];
  const process = spawnSync(
    globalThis.process.execPath,
    [fileURLToPath(new URL("./customization-mcp.mjs", import.meta.url))],
    {
      input:
        messages.map((message) => JSON.stringify(message)).join("\n") + "\n",
      encoding: "utf8",
      env: { ...globalThis.process.env, NAMING_EVAL_FAIL: "false" },
    },
  );
  assert.equal(process.status, 0, process.stderr);
  const responses = process.stdout.trim().split("\n").map(JSON.parse);
  assert.equal(responses.length, 3);
  assert.equal(responses[0].result.protocolVersion, "2024-11-05");
  assert.equal(JSON.parse(responses[2].result.content[0].text).Success, true);
});
