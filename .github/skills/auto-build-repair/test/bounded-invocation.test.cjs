// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
"use strict";
const test = require("node:test");
const assert = require("node:assert/strict");
const fs = require("node:fs");
const os = require("node:os");
const path = require("node:path");
const vm = require("node:vm");
const { spawnSync } = require("node:child_process");
const { createRequire } = require("node:module");
const evalRequire = createRequire(path.resolve(__dirname, "../../../../eng/common/scripts/eval/package.json"));
const spec = evalRequire("yaml").parse(fs.readFileSync(path.join(__dirname, "../evals/repair.eval.yaml"), "utf8"));
const config = evalRequire("yaml").parse(fs.readFileSync(path.join(__dirname, "../repair-config.yml"), "utf8"));
const server = spec.environment.mcpServers["azure-sdk-mcp"];
const grader = spec.stimuli[0].graders[0].config.args[1];
const args = { editScope: "CustomCode", maxAttempts: config.maxIterations,
  packagePath: "sdk/contoso/Azure.Contoso.Widgets", customizationRequest: "Fix CS1061 in custom code" };
const call = (arguments_) => ({ type: "tool_call", data: { toolName: "azure-sdk-mcp-azsdk_customized_code_update", arguments: arguments_ } });
function grade(events) {
  vm.runInNewContext(grader, {
    require: () => ({ readFileSync: () => JSON.stringify({ trajectory: { events } }) }),
    process: { env: { EVALUATE_GRADER_INPUT: "fixture" } },
  });
}
function rpc(requests) {
  const run = spawnSync(process.execPath, server.args, {
    input: requests.map((request, id) => JSON.stringify({ jsonrpc: "2.0", id, ...request })).join("\n") + "\n",
    encoding: "utf8", timeout: 10000,
  });
  assert.ifError(run.error);
  assert.equal(run.status, 0, run.stderr);
  return run.stdout.trim().split("\n").map(JSON.parse);
}

test("the hermetic eval uses the real executor, configured model, and typed local MCP fixture", () => {
  assert.equal(spec.defaults.executor, "copilot-sdk");
  assert.equal(spec.defaults.model, undefined);
  assert.equal(server.type, "stdio");
  const [init, tools] = rpc([
    { method: "initialize", params: { protocolVersion: "2024-11-05" } },
    { method: "tools/list" },
  ]);
  assert.equal(init.result.protocolVersion, "2024-11-05");
  assert.equal(tools.result.tools[0].inputSchema.properties.maxAttempts.type, "integer");
  grade([call(args)]);
  const shell = (command) => ({ type: "tool_call", data: { toolName: "powershell", arguments: { command } } });
  grade([shell("Get-Content 'auto-build-repair\\repair-config.yml'"), call(args)]);
  for (const command of ["dotnet build", "git push", "echo fabricated", "cat repair-config.yml; dotnet build"]) {
    assert.throws(() => grade([shell(command), call(args)]));
  }
  for (const events of [[], [call(args), call(args)], [call({ ...args, maxAttempts: "3" })],
    [call({ ...args, maxAttempts: 4 })], [call({ ...args, editScope: "All" })],
    [call({ ...args, tspProjectPath: "spec" })], [call({ ...args, customizationRequest: "" })]]) {
    assert.throws(() => grade(events));
  }
});
for (const [request, code, attempts] of [
  ["Fix CS1061", "BuildAfterPatchesFailed", 3],
  ["Fix AZC0030", "SpecChangeRequired", 0],
]) {
  test(`MCP fixture returns structured ${code} diagnostics without real SDK work`, () => {
    const [response] = rpc([{ method: "tools/call", params: {
      name: "azsdk_customized_code_update", arguments: { ...args, customizationRequest: request },
    } }]);
    const result = JSON.parse(response.result.content[0].text);
    assert.equal(result.success, false);
    assert.equal(result.attemptsUsed, attempts);
    assert.equal(result.errorCode, code);
    assert.match(result.buildResult, /error (CS1061|AZC0030)/);
    assert(result.next_steps.length);
    assert.match(result.message, /Simulated/);
  });
}
test("MCP fixture rejects an invalid bound rather than simulating success", () => {
  for (const maxAttempts of [0, 11, 1.5, "3"]) {
    const [response] = rpc([{ method: "tools/call", params: {
      name: "azsdk_customized_code_update", arguments: { ...args, maxAttempts },
    } }]);
    assert.equal(response.error.code, -32602);
  }
});

const workflow = fs.readFileSync(path.resolve(__dirname, "../../../workflows/sdk-build-repair.md"), "utf8");
const invocation = /```bash\r?\n(mkdir -p "\$RUNNER_TEMP\/repair-results"[\s\S]*?)```/.exec(workflow)[1].replace(/\r\n/g, "\n");
const bash = process.env.BASH || "bash";
for (const [bound, mode, expected] of [[1, "success", 0], [3, "success", 0], [10, "success", 0],
  [3, "failed", 1], [3, "old-cli", 1], [3, "help-failed", 1]]) {
  test(`workflow invokes the engine once with bound ${bound}: ${mode}`, (t) => {
    const root = fs.mkdtempSync(path.join(os.tmpdir(), "bounded-invocation-"));
    t.after(() => fs.rmSync(root, { recursive: true, force: true }));
    const fake = `
azsdk() {
  if [[ "$*" == *"--help" ]]; then
    if [[ "$MODE" == "help-failed" ]]; then echo "CLI unavailable" >&2; return 1; fi
    if [[ "$MODE" == "old-cli" ]]; then echo "--edit-scope"; else echo "--max-attempts"; fi
    return 0
  fi
  printf '%s\\n' "$*" >> "$RUNNER_TEMP/calls"
  if [[ "$MODE" == "failed" ]]; then value=false; else value=true; fi
  printf '{"success":%s,"attemptsUsed":%s}\\n' "$value" "$BOUND"
  if [[ "$MODE" == "failed" ]]; then echo "Actual engine diagnostic" >&2; return 1; fi
}
`;
    const run = spawnSync(bash, ["--noprofile", "--norc", "-c",
      fake + invocation.replace("<maxIterations from repair-config.yml>", String(bound))], {
      env: { ...process.env, RUNNER_TEMP: root.replace(/\\/g, "/"), MODE: mode, BOUND: String(bound) },
      encoding: "utf8", timeout: 15000,
    });
    assert.ifError(run.error);
    assert.equal(run.status, expected, run.stderr);
    const calls = path.join(root, "calls");
    if (mode === "old-cli" || mode === "help-failed") {
      assert.equal(fs.existsSync(calls), false);
      assert.match(fs.readFileSync(path.join(root, "repair-results", "engine-errors.txt"), "utf8"),
        /does not support --max-attempts|CLI unavailable/);
    } else {
      const lines = fs.readFileSync(calls, "utf8").trim().split("\n");
      assert.equal(lines.length, 1);
      assert.match(lines[0], new RegExp("--max-attempts " + bound + "$"));
      assert.match(lines[0], /--edit-scope CustomCode/);
      const result = JSON.parse(fs.readFileSync(path.join(root, "repair-results", "result.json"), "utf8"));
      assert.equal(result.attemptsUsed, bound);
      assert.equal(result.success, mode !== "failed");
      if (mode === "failed") assert.match(fs.readFileSync(path.join(root, "repair-results", "engine-errors.txt"), "utf8"), /Actual engine diagnostic/);
    }
  });
}
