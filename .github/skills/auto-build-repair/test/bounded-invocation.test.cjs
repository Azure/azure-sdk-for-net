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
const configRead = (overrides = {}, toolName = "grep") => ({ type: "tool_call", data: {
  toolName, arguments: { pattern: "maxIterations:", paths: ["auto-build-repair"],
    glob: "repair-config.yml", output_mode: "content", ...overrides },
} });
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
  grade([configRead(), call(args)]);
  const shell = (command) => ({ type: "tool_call", data: { toolName: "powershell", arguments: { command } } });
  grade([shell("Get-Content 'auto-build-repair\\repair-config.yml'"), configRead(), call(args)]);
  for (const command of ["dotnet build", "git push", "echo fabricated", "cat repair-config.yml; dotnet build"]) {
    assert.throws(() => grade([configRead(), shell(command), call(args)]),
      /Only reading the repair configuration is allowed/);
  }
  for (const events of [[], [call(args), call(args)], [call({ ...args, maxAttempts: "3" })],
    [call({ ...args, maxAttempts: 4 })], [call({ ...args, editScope: "All" })],
    [call({ ...args, tspProjectPath: "spec" })], [call({ ...args, customizationRequest: "" })]]) {
    assert.throws(() => grade([configRead(), ...events]),
      /Expected exactly one engine invocation|Invalid configured CustomCode invocation/);
  }
});
test("the capability grader requires the requested config read before the engine invocation", () => {
  grade([configRead(), call(args)]);
  for (const events of [
    [call(args)],
    [call(args), configRead()],
    [{ ...configRead(), type: "tool_result" }, call(args)],
    [configRead({}, "view"), call(args)],
    [configRead({ pattern: "description:" }), call(args)],
    [configRead({ paths: ["auto-build-repair/evals"] }), call(args)],
    [configRead({ paths: ["auto-build-repair", "unrelated"] }), call(args)],
    [configRead({ paths: [] }), call(args)],
    [configRead({ paths: null }), call(args)],
    [configRead({ paths: "auto-build-repair" }), call(args)],
    [configRead({ glob: "SKILL.md" }), call(args)],
    [configRead({ output_mode: "files_with_matches" }), call(args)],
    [configRead({ pattern: "description:" }), call(args), configRead()],
  ]) {
    assert.throws(() => grade(events), /Read the skill repair configuration before invoking the engine/);
  }
});
test("the capability grader requires the exact workspace package path", () => {
  assert.equal(spec.environment.files[0].dest, args.packagePath);
  for (const stimulus of spec.stimuli.slice(0, 3)) {
    assert.equal(stimulus.graders[0].config.args[1], grader);
  }
  grade([configRead(), call(args)]);
  for (const packagePath of [
    "/tmp/Azure.Contoso.Widgets",
    "auto-build-repair/evals/fixtures/package",
    "auto-build-repair/evals/fixtures/sdk/contoso/Azure.Contoso.Widgets",
    "sdk/other/Azure.Contoso.Widgets",
    "sdk/contoso/Azure.Contoso.Widgets-copy",
    "sdk/contoso/Azure.Contoso.Widgets/../Other",
    "", null, undefined, 3, ["sdk/contoso/Azure.Contoso.Widgets"],
  ]) {
    assert.throws(() => grade([configRead(), call({ ...args, packagePath })]),
      /Invalid configured CustomCode invocation/, `reject packagePath ${JSON.stringify(packagePath)}`);
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
test("posted command code preserves URLs without changing the network allowlist", () => {
  const frontmatter = evalRequire("yaml").parse(/^---\r?\n([\s\S]*?)\r?\n---/.exec(workflow)[1]);
  assert.equal(frontmatter["safe-outputs"].urls, "allowed-or-code-region");
  assert.deepEqual(frontmatter.network.allowed, ["defaults", "dotnet", "github", "registry.npmjs.org", "api.githubcopilot.com"]);
  const lock = fs.readFileSync(path.resolve(__dirname, "../../../workflows/sdk-build-repair.lock.yml"), "utf8");
  assert.equal((lock.match(/GH_AW_SAFE_OUTPUTS_URLS: "allowed-or-code-region"/g) || []).length, 2);
});
const invocation = /```bash\r?\n(mkdir -p "\$RUNNER_TEMP\/repair-results"[\s\S]*?)```/.exec(workflow)[1].replace(/\r\n/g, "\n");
const bash = process.env.BASH || "bash";
let sanitizeContent;
test.before(async () => {
  const lock = fs.readFileSync(path.resolve(__dirname, "../../../workflows/sdk-build-repair.lock.yml"), "utf8");
  assert.equal(JSON.parse(/^# gh-aw-metadata: (.+)/.exec(lock)[1]).compiler_version, "v0.88.7");
  // Fetch the real sanitizer at the immutable v0.88.7 commit, not a local approximation.
  const sourceRoot = "https://raw.githubusercontent.com/github/gh-aw/bde367913adeb3132f0a171594c88a17f4b7d08c/actions/setup/js/";
  const sources = new Map(await Promise.all([
    "sanitize_content.cjs", "sanitize_content_core.cjs", "repo_helpers.cjs",
    "slash_command_matcher.cjs", "markdown_code_region_balancer.cjs",
    "glob_pattern_helpers.cjs", "error_codes.cjs",
  ].map(async (name) => {
    const response = await fetch(sourceRoot + name, { signal: AbortSignal.timeout(30000) });
    assert(response.ok, `fetch pinned sanitizer ${name}: HTTP ${response.status}`);
    return [name, await response.text()];
  })));
  const modules = new Map();
  function load(name) {
    if (modules.has(name)) return modules.get(name).exports;
    assert(sources.has(name), `missing pinned sanitizer dependency: ${name}`);
    const module = { exports: {} };
    modules.set(name, module);
    vm.runInNewContext(sources.get(name), {
      module, exports: module.exports,
      require: (dependency) => dependency.startsWith("./") ? load(dependency.slice(2)) : require(dependency),
      process: { env: { GH_AW_SAFE_OUTPUTS_URLS: "allowed-or-code-region", GITHUB_REPOSITORY: "Azure/azure-sdk-for-net" } },
      core: { info() {} }, URL,
    }, { filename: name });
    return module.exports;
  }
  sanitizeContent = load("sanitize_content.cjs").sanitizeContent;
  assert.match(sanitizeContent("```text\n&lt;T&gt;\n```"), /<T>/, "the real sanitizer decodes entities inside code regions");
});
for (const [bound, mode, expected, quoted = false] of [[1, "success", 0], [3, "success", 0], [10, "success", 0],
  [3, "success", 0, true], [3, "failed", 1, true],
  [3, "success", 0, "entities"], [3, "failed", 1, "entities"],
  [3, "success", 0, "entities-ascii"], [3, "failed", 1, "entities-ascii"],
  [3, "success", 0, "entities-unicode"], [3, "failed", 1, "entities-unicode"],
  [3, "success", 0, "oversized"], [3, "failed", 1, "oversized"],
  [3, "failed", 1], [3, "failed-stderr", 1], [3, "failed-stderr-upgrade", 1], [3, "failed-stderr-array", 1],
  [3, "invalid-result", 1], [3, "invalid-array-result", 1],
  [3, "contradictory-result", 1], [3, "old-cli", 1], [3, "help-failed", 1]]) {
  test(`workflow invokes the engine once with bound ${bound}: ${mode}${quoted ? ` (${quoted === true ? "quoted arguments" : quoted})` : ""}`, (t) => {
    const root = fs.mkdtempSync(path.join(os.tmpdir(), "bounded-invocation-"));
    t.after(() => fs.rmSync(root, { recursive: true, force: true }));
    fs.mkdirSync(path.join(root, "repair-results"));
    fs.writeFileSync(path.join(root, "repair-results", "engine-command.txt"), "stale invocation\n");
    const fake = `
azsdk() {
  if [[ "$*" == *"--help" ]]; then
    if [[ "$MODE" == "help-failed" ]]; then echo "CLI unavailable" >&2; return 1; fi
    if [[ "$MODE" == "old-cli" ]]; then echo "--edit-scope"; else echo "--max-attempts"; fi
    return 0
  fi
  printf '%s\\n' "$*" >> "$RUNNER_TEMP/calls"
  printf '%s\\0' "$@" >> "$RUNNER_TEMP/calls-argv"
  printf '%s\\n' "$LC_ALL" > "$RUNNER_TEMP/engine-locale"
  if [[ "$MODE" == "invalid-result" ]]; then echo "not JSON"; return 0; fi
  if [[ "$MODE" == "invalid-array-result" ]]; then
    printf '[\\n {"success":true,"attemptsUsed":%s}\\n]\\n' "$BOUND"; return 0
  fi
  if [[ "$MODE" == "failed-stderr" || "$MODE" == "failed-stderr-upgrade" || "$MODE" == "failed-stderr-array" ]]; then
    echo "[npm-tsp-client] npm error E403" >&2
    if [[ "$MODE" == "failed-stderr-array" ]]; then
      printf '[\\n {"success":false,"attemptsUsed":%s}\\n]\\n' "$BOUND" >&2; return 1
    fi
    printf '{"success":false,"attemptsUsed":%s,"errorCode":"PatchesFailed"}\\n' "$BOUND" >&2
    if [[ "$MODE" == "failed-stderr-upgrade" ]]; then echo "A new version of azsdk is available. Run azsdk upgrade to update." >&2; fi
    return 1
  fi
  if [[ "$MODE" == "failed" ]]; then value=false; else value=true; fi
  printf '{"success":%s,"attemptsUsed":%s}\\n' "$value" "$BOUND"
  if [[ "$MODE" == "failed" || "$MODE" == "contradictory-result" ]]; then echo "Actual engine diagnostic" >&2; return 1; fi
}
`;
    const unicode = "caf\u00e9 e\u0301 \uff21\uff22\uff23 \u0430\u0441 \ud83d\ude80";
    const entities = "Preserve &lt;T&gt; &amp; &quot; &apos; &#60; &#x3E; &amp;lt;T&amp;gt; \\&lt;escaped&gt; \\x26";
    const packagePath = quoted === "entities-ascii" ? "sdk/contoso &lt;T&gt; Azure.Widgets"
      : quoted ? `sdk/${unicode} widgets/'[x] &lt;T&gt; & $HOME; Azure.Widgets` : "sdk/contoso/Azure.Contoso.Widgets";
    const request = quoted === "oversized" ? "x".repeat(70000)
      : quoted === "entities" ? `${entities}\nNext line`
      : quoted === "entities-ascii" ? entities
      : quoted === "entities-unicode" ? `${entities} ${unicode}`
      : quoted ? `Fix ${unicode} 'X' | \`Y\` <Z> & $HOME; $(touch "$RUNNER_TEMP/injected")\nnext line\r\n\`\`\`bash\nhttp://example.test/error https://example.test/error @contoso/types #42` : "Fix CS1061 in custom code";
    const requestFile = path.join(root, "request.txt");
    fs.writeFileSync(requestFile, request);
    const environment = { ...process.env, RUNNER_TEMP: root.replace(/\\/g, "/"),
      GITHUB_WORKSPACE: path.resolve(__dirname, "../../../..").replace(/\\/g, "/"), MODE: mode, BOUND: String(bound),
      TEST_PACKAGE_PATH: packagePath, TEST_CUSTOMIZATION_REQUEST_FILE: requestFile.replace(/\\/g, "/"), LC_ALL: "C.UTF-8" };
    const command = invocation.replaceAll("<maxIterations from repair-config.yml>", String(bound))
      .replace('"<failing SDK package dir>"', '"$TEST_PACKAGE_PATH"')
      .replace('"<the build errors / failure context>"', '"$(cat "$TEST_CUSTOMIZATION_REQUEST_FILE")"');
    const run = spawnSync(bash, ["--noprofile", "--norc", "-c", fake + command], {
      env: environment,
      encoding: "utf8", timeout: 30000,
    });
    assert.ifError(run.error);
    assert.equal(run.status, expected, run.stderr);
    const calls = path.join(root, "calls");
    if (mode === "old-cli" || mode === "help-failed") {
      assert.equal(fs.existsSync(calls), false);
      assert.equal(fs.existsSync(path.join(root, "repair-results", "engine-command.txt")), false);
      assert.match(fs.readFileSync(path.join(root, "repair-results", "engine-errors.txt"), "utf8"),
        /does not support --max-attempts|CLI unavailable/);
    } else {
      const expectedArgs = ["-o", "json", "tsp", "client", "customized-update", "--edit-scope", "CustomCode",
        "--package-path", packagePath, "--customization-request", request, "--max-attempts", String(bound)];
      const readArgs = (directory) => fs.readFileSync(path.join(directory, "calls-argv"), "utf8").split("\0").slice(0, -1);
      assert.deepEqual(readArgs(root), expectedArgs);
      assert.equal(fs.readFileSync(path.join(root, "engine-locale"), "utf8").trim(), "C.UTF-8", "serialization does not change the engine locale");
      const recordedCommand = fs.readFileSync(path.join(root, "repair-results", "engine-command.txt"), "utf8");
      assert.match(recordedCommand, /^[\x00-\x7f]*$/, "Unicode argv is recorded using ASCII byte escapes");
      assert.match(recordedCommand, /^azsdk -o json tsp client customized-update /);
      assert.match(recordedCommand, new RegExp("--max-attempts " + bound + "\\n$"));
      function replayCommand(text, name) {
        const replayRoot = path.join(root, name);
        fs.mkdirSync(replayRoot);
        const commandFile = path.join(replayRoot, "engine-command.txt");
        fs.writeFileSync(commandFile, text);
        const replay = spawnSync(bash, ["--noprofile", "--norc", "-c", fake + '\nsource "$RECORDED_COMMAND_FILE"'], {
          env: { ...environment, RUNNER_TEMP: replayRoot.replace(/\\/g, "/"),
            RECORDED_COMMAND_FILE: commandFile.replace(/\\/g, "/") },
          encoding: "utf8", timeout: 10000,
        });
        assert.ifError(replay.error);
        assert.deepEqual(readArgs(replayRoot), expectedArgs, `${name} preserves every executed argument`);
        assert.equal(fs.existsSync(path.join(replayRoot, "injected")), false);
      }
      replayCommand(recordedCommand, "replay");
      assert.equal(fs.existsSync(path.join(root, "injected")), false);
      const reportPath = path.join(root, "report.md");
      const artifactDir = path.join(root, "agent-logs");
      fs.mkdirSync(artifactDir);
      const emit = spawnSync("pwsh", ["-NoProfile", "-File",
        path.resolve(__dirname, "../emit-repair-report.ps1"),
        "-ResultsDir", path.join(root, "repair-results"), "-CommandArtifactDir", artifactDir,
        "-RepoRoot", root, "-Repo", "Azure/azure-sdk-for-net", "-Pr", "123", "-RunId", "gha-12345-1",
        "-OutFile", reportPath], { encoding: "utf8", timeout: 30000 });
      assert.ifError(emit.error);
      assert.equal(emit.status, 0, emit.stderr);
      const report = fs.readFileSync(reportPath, "utf8");
      assert(report.length <= 65000, "report fits the actual add_comment.body limit");
      if (quoted === "oversized") {
        assert.match(report, /No command or engine argument was truncated/);
        assert.equal(fs.readFileSync(path.join(artifactDir, "engine-command.txt"), "utf8"), recordedCommand.trimEnd());
        assert(fs.readFileSync(path.join(artifactDir, "repair-report-full.md"), "utf8").includes(recordedCommand.trimEnd()));
      } else {
        assert(report.includes(recordedCommand.trimEnd()), "comment includes the complete executed command");
        let sanitized = report;
        for (let pass = 1; pass <= 2; pass++) {
          sanitized = sanitizeContent(sanitized);
          const commandBlock = /^(`{3,})bash\n([\s\S]*?)\n\1$/m.exec(sanitized);
          assert(commandBlock, `sanitizer pass ${pass} preserves the command code block`);
          replayCommand(commandBlock[2], `sanitized-replay-${pass}`);
        }
      }
      const resultPath = path.join(root, "repair-results", "result.json");
      assert.equal(fs.readFileSync(path.join(root, "repair-results", "engine-exit-code.txt"), "utf8").trim(),
        mode.startsWith("failed") || mode === "contradictory-result" ? "1" : "0");
      if (mode === "invalid-result" || mode === "invalid-array-result" ||
        mode === "contradictory-result" || mode === "failed-stderr-array") {
        assert.equal(fs.existsSync(resultPath), false);
        assert.match(fs.readFileSync(path.join(root, "repair-results", "engine-errors.txt"), "utf8"), /Engine response capture failed/);
        if (mode === "failed-stderr-array") {
          assert.equal(fs.readFileSync(path.join(root, "repair-results", "engine-stdout.txt"), "utf8"), "");
          const raw = fs.readFileSync(path.join(root, "repair-results", "engine-stderr.txt"), "utf8");
          assert.match(raw, /npm error E403/);
          assert.match(raw, /\[\n \{"success":false,"attemptsUsed":3\}\n\]/);
        }
        return;
      }
      const result = JSON.parse(fs.readFileSync(resultPath, "utf8"));
      assert.equal(result.attemptsUsed, bound);
      assert.equal(result.success, !mode.startsWith("failed"));
      if (mode === "failed") assert.match(fs.readFileSync(path.join(root, "repair-results", "engine-errors.txt"), "utf8"), /Actual engine diagnostic/);
      if (mode.startsWith("failed-stderr")) {
        assert.match(fs.readFileSync(path.join(root, "repair-results", "engine-errors.txt"), "utf8"), /npm error E403/);
        assert.equal(fs.readFileSync(path.join(root, "repair-results", "engine-stdout.txt"), "utf8"), "");
        if (mode === "failed-stderr-upgrade") {
          assert.match(fs.readFileSync(path.join(root, "repair-results", "engine-errors.txt"), "utf8"), /Run azsdk upgrade/);
          assert.equal(result.errorCode, "PatchesFailed");
        }
      }
    }
  });
}
