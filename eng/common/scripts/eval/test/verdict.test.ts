// node:test unit tests for lib/verdict.ts (port of Invoke-EvalShard.Tests.ps1, which
// exercised the verdict helpers). Run from eng/common/scripts/eval:  npm test

import assert from "node:assert/strict";
import fs from "node:fs";
import os from "node:os";
import path from "node:path";
import { fileURLToPath } from "node:url";
import { after, before, describe, it } from "node:test";

import { getVallyShardVerdict, parseFailedTestsGate } from "../lib/verdict.ts";
import { parseArgs, runShard, validateVallyArguments } from "../invoke-eval-shard.ts";
import { spawnSync } from "node:child_process";

describe("eval template authentication source contract", () => {
  const load = (relative: string) => fs.readFileSync(new URL(relative, import.meta.url), "utf8");
  const invoke = load("../../../pipelines/templates/steps/eval-invoke.yml");
  const branches = invoke.split(/(?=^  - \$\{\{ )/m).slice(1);

  it("keeps the service connection optional and empty in every common template layer", () => {
    for (const template of [invoke,
      load("../../../pipelines/templates/jobs/eval-shard.yml"),
      load("../../../pipelines/templates/stages/archetype-eval.yml")]) {
      assert.match(template, /^  - name: azureSubscription\r?\n(?:    #[^\r\n]*\r?\n)*    type: string\r?\n    default: ''\r?$/m);
      assert.match(template, /^  - name: UseAzSdkAuthentication\r?\n(?:    #[^\r\n]*\r?\n)*    type: boolean\r?\n    default: false\r?$/m);
    }
  });

  it("keeps the missing-connection error in the first branch without an AzureCLI task", () => {
    assert.equal(branches.length, 3);
    const configuration = branches[0];
    assert.equal(configuration.split(/\r?\n/, 1)[0],
      "  - ${{ if and(parameters.UseAzSdkAuthentication, eq(trim(parameters.azureSubscription), '')) }}:");
    assert.equal(configuration.match(/^    - /gm)?.length, 1);
    assert.match(configuration, /^    - script: \|\r?$/m);
    assert.doesNotMatch(configuration, /^\s*- task:/m);
    assert.match(configuration, /##vso\[task\.logissue type=error\].*azureSubscription.*UseAzSdkAuthentication/);
    assert.match(configuration, /^        exit 1\r?$/m);
  });

  it("references the caller's connection only in the authenticated branch", () => {
    const authenticated = branches[1];
    assert.equal(authenticated.split(/\r?\n/, 1)[0], "  - ${{ elseif parameters.UseAzSdkAuthentication }}:");
    assert.equal(authenticated.match(/^    - /gm)?.length, 1);
    assert.match(authenticated, /^    - task: AzureCLI@2\r?$/m);
    assert.match(authenticated, /^        azureSubscription: \$\{\{ parameters\.azureSubscription \}\}\r?$/m);
    const unauthenticated = branches[2];
    assert.equal(unauthenticated.split(/\r?\n/, 1)[0], "  - ${{ else }}:");
    assert.equal(unauthenticated.match(/^    - /gm)?.length, 1);
    assert.match(unauthenticated, /^    - script: \|\r?$/m);
    assert.match(unauthenticated, /invoke-eval-shard\.ts/);
    assert.doesNotMatch(unauthenticated, /^\s*(?:- task|azureSubscription):/m);
    for (const branch of [authenticated, unauthenticated]) {
      assert.equal(branch.match(/^        VALLY_ARGUMENTS_JSON: (.+)\r?$/m)?.[1].trim(),
        "${{ replace(convertToJson(parameters.vallyArguments), '$', '\\u0024') }}");
      assert.match(branch, /^        COPILOT_GITHUB_TOKEN: \$\(COPILOT_GITHUB_TOKEN\)\r?$/m);
    }
  });

  it("keeps the existing live entrypoint's connection explicit and forwards caller configuration", () => {
    const live = load("../../../pipelines/live-eval.yml");
    assert.match(live, /^    UseAzSdkAuthentication: true\r?$/m);
    assert.match(live, /^    azureSubscription: opensource-api-connection\r?$/m);
    const stage = load("../../../pipelines/templates/stages/archetype-eval.yml");
    const evalStage = stage.split(/^      - stage: /m).find(section => section.split(/\r?\n/, 1)[0] === "Eval");
    assert.ok(evalStage);
    assert.match(evalStage, /^          - template: \/eng\/common\/pipelines\/templates\/jobs\/eval-shard\.yml\r?$/m);
    assert.match(evalStage, /^              azureSubscription: \$\{\{ parameters\.azureSubscription \}\}\r?$/m);
    const shard = load("../../../pipelines/templates/jobs/eval-shard.yml");
    const invokeStep = shard.split(/^      - template: /m).find(section =>
      section.split(/\r?\n/, 1)[0] === "${{ parameters.evalInvokeTemplate }}");
    assert.ok(invokeStep);
    assert.match(invokeStep, /^          \$\{\{ if eq\(parameters\.evalInvokeTemplate, '\/eng\/common\/pipelines\/templates\/steps\/eval-invoke\.yml'\) \}\}:\r?\n            azureSubscription: \$\{\{ parameters\.azureSubscription \}\}\r?$/m);
  });

  it("preflights common shard arguments before setup and forwards the gate to both jobs", () => {
    const shard = load("../../../pipelines/templates/jobs/eval-shard.yml");
    const preflight = shard.indexOf("displayName: 'Validate eval run configuration'");
    assert.ok(preflight >= 0 && preflight < shard.indexOf("displayName: 'Install Vally CLI"));
    assert.match(shard, /^      - \$\{\{ if eq\(parameters\.evalInvokeTemplate, '\/eng\/common\/pipelines\/templates\/steps\/eval-invoke\.yml'\) \}\}:\r?\n        - script: \|/m);
    assert.match(shard, /invoke-eval-shard\.ts" --validate-only/);
    assert.match(shard, /^            EVAL_FAIL_ON_FAILED_TESTS: \$\{\{ parameters\.failOnFailedTests \}\}\r?$/m);
    assert.equal(shard.match(/^            VALLY_ARGUMENTS_JSON: (.+)\r?$/m)?.[1].trim(),
      "${{ replace(convertToJson(parameters.vallyArguments), '$', '\\u0024') }}");
    const stage = load("../../../pipelines/templates/stages/archetype-eval.yml");
    for (const name of ["Eval", "Summary"]) {
      const section = stage.split(/^      - stage: /m).find(value => value.split(/\r?\n/, 1)[0] === name);
      assert.ok(section);
      assert.match(section, /^              failOnFailedTests: \$\{\{ parameters\.failOnFailedTests \}\}\r?$/m);
    }
    const summary = load("../../../pipelines/templates/jobs/eval-summarize.yml");
    assert.doesNotMatch(summary, /EVAL_FAIL_ON_FAILED_TESTS/);
    assert.match(summary, /^          failTaskOnFailedTests: \$\{\{ parameters\.failOnFailedTests \}\}\r?$/m);
  });
});

describe("supplementary Vally arguments", () => {
  it("rejects only multi-run gating, preserving single-run gates and multi-run observations", () => {
    for (const runs of [1, "1"]) {
      assert.deepEqual(validateVallyArguments(["--runs", runs], { failOnFailedTests: true }), ["--runs", "1"]);
    }
    for (const runs of [2, "2", 5, "5"]) {
      assert.throws(() => validateVallyArguments(["--runs", runs], { failOnFailedTests: true }),
        /not currently supported.*failOnFailedTests=true/);
      assert.deepEqual(validateVallyArguments(["--runs", runs], { failOnFailedTests: false }), ["--runs", String(runs)]);
    }
    assert.deepEqual(validateVallyArguments([], { failOnFailedTests: true }), []);
    assert.deepEqual(validateVallyArguments(["--workers", 5], { failOnFailedTests: true }), ["--workers", "5"]);
    for (const value of ["true", "True", "TRUE"]) assert.equal(parseFailedTestsGate(value), true);
    for (const value of [undefined, "false", "False"]) assert.equal(parseFailedTestsGate(value), false);
    for (const value of ["", "yes", "1", null, true]) assert.throws(() => parseFailedTestsGate(value), /must be true or false/);
  });

  it("validates the configuration through the CLI without starting an evaluation", () => {
    for (const [runs, gate, expected] of [[5, "true", 1], ["5", "True", 1], [1, "true", 0], ["1", "True", 0], [5, "false", 0]] as const) {
      const env = { ...process.env, EVAL_FAIL_ON_FAILED_TESTS: gate, VALLY_ARGUMENTS_JSON: JSON.stringify(["--runs", runs]) };
      delete env.NODE_TEST_CONTEXT;
      const child = spawnSync(process.execPath, ["--experimental-strip-types",
        fileURLToPath(new URL("../invoke-eval-shard.ts", import.meta.url)), "--validate-only"], {
        encoding: "utf8", timeout: 30_000, env,
      });
      assert.ifError(child.error);
      assert.equal(child.status, expected, child.stderr);
      assert.doesNotMatch(child.stdout, /Running: vally eval/);
      if (expected) assert.match(child.stderr, /not currently supported.*failOnFailedTests=true/);
      else assert.match(child.stdout, /configuration is supported/);
    }
  });

  it("preserves defined pipeline macros through simulated agent expansion and JSON decoding", () => {
    const variables: Record<string, string> = { "Build.BuildId": "12345", DefinedValue: 'quoted "value"\nand newline' };
    const expand = (value: string) => value.replace(/\$\(([^)]+)\)/g, (macro, name) => variables[name] ?? macro);
    const args = ["--tag", "build=$(Build.BuildId)", "--tag", "label=$(DefinedValue)",
      "--tag", String.raw`literal=\u0024; $5; $(undefined-variable)`];
    assert.equal(expand(args[1]), "build=12345");
    const json = JSON.stringify(args);
    assert.throws(() => JSON.parse(expand(json)), SyntaxError);
    const escaped = json.replaceAll("$", "\\u0024");
    assert.doesNotMatch(escaped, /\$\(/);
    assert.equal(expand(escaped), escaped);
    const options = parseArgs(["--eval-args", "-e example.eval.yaml", "--shard-name", "example", "--output-dir", "out"],
      { VALLY_ARGUMENTS_JSON: expand(escaped) });
    assert.deepEqual(options.vallyArguments, args);
  });

  it("accepts only supported option/value pairs without splitting values", () => {
    const args = ["--tag", "label=two words; $(not-a-command) & \"quoted\"", "--runs", "3", "--workers", "1", "--timeout", "5m"];
    assert.deepEqual(validateVallyArguments(args), args);
    const options = parseArgs(["--eval-args", "-e example.eval.yaml", "--shard-name", "example", "--output-dir", "out"],
      { VALLY_ARGUMENTS_JSON: JSON.stringify(args) });
    assert.deepEqual(options.vallyArguments, args);
  });

  it("normalizes numeric trial and worker counts produced by Azure template expansion", () => {
    for (const mode of ["forced", "trigger", "no-skill"]) {
      for (const runs of [1, 3]) {
        const args = ["--tag", `mode=${mode}`, "--runs", runs, "--workers", 2];
        const expected = ["--tag", `mode=${mode}`, "--runs", String(runs), "--workers", "2"];
        assert.deepEqual(validateVallyArguments(args), expected);
        assert.equal(args[3], runs);
        const options = parseArgs(["--eval-args", "-e example.eval.yaml", "--shard-name", "example", "--output-dir", "out"],
          { VALLY_ARGUMENTS_JSON: JSON.stringify(args) });
        assert.deepEqual(options.vallyArguments, expected);
      }
    }
  });

  it("rejects output, verdict, discovery and plugin overrides, including aliases and equals syntax", () => {
    for (const option of ["--output-dir", "--output-dir=elsewhere", "--junit", "--no-junit", "--threshold",
      "--require-pass", "--skip-grade", "--skip-validate", "-e", "--eval-spec", "--suite", "--work-dir",
      "--reporter-plugin", "--executor-plugin", "--grader-plugin", "--runs=3", "--", "-r"]) {
      assert.throws(() => validateVallyArguments([option, "value"]), /Unsupported/);
    }
    for (const args of [null, {}, " --runs 3", [3], ["--runs"], ["--runs", "0"], ["--runs", "-1"],
      ["--workers", "1.5"], ["--tag", "--threshold"], ["--tag", "value\0"],
      ["--runs", null], ["--runs", true], ["--runs", {}], ["--runs", []],
      ["--runs", 0], ["--runs", -1], ["--runs", 1.5], ["--runs", NaN],
      ["--workers", Infinity], ["--workers", Number.MAX_SAFE_INTEGER + 1],
      ["--tag", 1], ["--timeout", 5], [1, "value"]]) {
      assert.throws(() => validateVallyArguments(args));
    }
    assert.throws(() => parseArgs([], { VALLY_ARGUMENTS_JSON: "not JSON" }));
    assert.deepEqual(validateVallyArguments([]), []);
  });

  it("passes literal arguments through a real Node process, retaining framework-owned settings", (t) => {
    const root = fs.mkdtempSync(path.join(os.tmpdir(), "vally-arguments-"));
    t.after(() => fs.rmSync(root, { recursive: true, force: true }));
    const capture = path.join(root, "capture.json");
    const fakeCli = path.join(root, "fake-cli.mjs");
    const outputDir = path.join(root, "results with spaces");
    fs.writeFileSync(fakeCli, `
      import fs from "node:fs";
      import path from "node:path";
      const args = process.argv.slice(2);
      fs.writeFileSync(${JSON.stringify(capture)}, JSON.stringify(args));
      const output = args[args.indexOf("--output-dir") + 1];
      fs.mkdirSync(output, { recursive: true });
      fs.writeFileSync(path.join(output, "results.jsonl"), JSON.stringify({
        type: "run-summary", evals: [{ name: "test", passed: true, stimuliRun: 1 }]
      }));
    `);
    const args = ["--tag", "label=a b; $(echo bad) & \"quotes\" %PATH%", "--tag", "build=$(Build.BuildId)", "--runs", 3];
    const options = parseArgs(["--eval-args", "-e test.eval.yaml", "--shard-name", "test", "--output-dir", outputDir],
      { VALLY_ARGUMENTS_JSON: JSON.stringify(args).replaceAll("$", "\\u0024") });
    const exit = runShard(options, {
      spawn(command, commandArgs, options) {
        assert.equal(command, process.execPath);
        assert.equal(options.shell, false);
        assert.match(commandArgs[0], /vally-cli[\\/]dist[\\/]index\.js$/);
        return spawnSync(command, [fakeCli, ...commandArgs.slice(1)], options);
      },
    });
    assert.equal(exit, 0);
    const actual = JSON.parse(fs.readFileSync(capture, "utf8"));
    assert.deepEqual(actual, ["eval", "-e", "test.eval.yaml", ...validateVallyArguments(args),
      "--junit", "--threshold", "0.8", "--output-dir", outputDir]);
  });

  it("surfaces process launch failures instead of reading stale results", () => {
    assert.throws(() => runShard({ evalArgs: "-e x", shardName: "x", outputDir: "unused" },
      { spawn: () => ({ error: new Error("failed to launch") }) }), /failed to launch/);
  });
});

describe("getVallyShardVerdict", () => {
  let root;

  before(() => {
    root = fs.mkdtempSync(path.join(os.tmpdir(), "vally-shard-"));
  });

  after(() => fs.rmSync(root, { recursive: true, force: true }));

  // Mimic Vally's nested per-run timestamp folder under the shard output dir.
  function newRunSummary(shard, jsonl, timestamp = "2026-06-18T04-27-19-656Z") {
    const dir = path.join(root, shard, timestamp);
    fs.mkdirSync(dir, { recursive: true });
    fs.writeFileSync(path.join(dir, "results.jsonl"), jsonl);
    return path.join(root, shard);
  }

  it("passes a scored eval above the threshold", () => {
    const dir = newRunSummary(
      "above",
      '{"type":"run-summary","passed":true,"hadExecutionErrors":false,"evals":[{"name":"e","passed":true,"scoringApplied":true,"overallScore":0.971,"threshold":0.8,"stimuliRun":7,"stimuliTotal":7}]}'
    );
    const v = getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 });
    assert.equal(v.found, true);
    assert.equal(v.passed, true);
  });

  it("passes a scored eval exactly on the threshold boundary", () => {
    const dir = newRunSummary(
      "boundary",
      '{"type":"run-summary","passed":true,"hadExecutionErrors":false,"evals":[{"name":"e","passed":true,"scoringApplied":true,"overallScore":0.8,"threshold":0.8,"stimuliRun":5,"stimuliTotal":5}]}'
    );
    assert.equal(getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 }).passed, true);
  });

  it("passes when the verdict cleared the threshold but the run had execution errors", () => {
    const dir = newRunSummary(
      "execerrors",
      '{"type":"run-summary","passed":false,"hadExecutionErrors":true,"evals":[{"name":"e","passed":false,"scoringApplied":true,"overallScore":0.971,"threshold":0.8,"stimuliRun":7,"stimuliTotal":7}]}'
    );
    const v = getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 });
    assert.equal(v.passed, true);
    assert.equal(v.hadExecutionErrors, true);
  });

  it("fails a scored eval below the threshold", () => {
    const dir = newRunSummary(
      "below",
      '{"type":"run-summary","passed":false,"hadExecutionErrors":false,"evals":[{"name":"e","passed":false,"scoringApplied":true,"overallScore":0.6,"threshold":0.8,"stimuliRun":5,"stimuliTotal":5}]}'
    );
    assert.equal(getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 }).passed, false);
  });

  it("fails a scored eval that cleared the threshold but ran zero stimuli (no vacuous pass)", () => {
    const dir = newRunSummary(
      "norun",
      '{"type":"run-summary","passed":false,"hadExecutionErrors":false,"evals":[{"name":"e","passed":false,"scoringApplied":true,"overallScore":1.0,"threshold":0.8,"stimuliRun":0,"stimuliTotal":3}]}'
    );
    assert.equal(getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 }).passed, false);
  });

  it("honours a binary (unscored) eval verdict", () => {
    const dir = newRunSummary(
      "binary",
      '{"type":"run-summary","passed":true,"hadExecutionErrors":false,"evals":[{"name":"e","passed":true,"scoringApplied":false,"stimuliRun":2,"stimuliTotal":2}]}'
    );
    assert.equal(getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 }).passed, true);
  });

  it("fails the shard when any eval in a multi-eval shard is below threshold", () => {
    const dir = newRunSummary(
      "mixed",
      '{"type":"run-summary","passed":false,"hadExecutionErrors":false,"evals":[{"name":"ok","passed":true,"scoringApplied":true,"overallScore":1.0,"threshold":0.8,"stimuliRun":3,"stimuliTotal":3},{"name":"bad","passed":false,"scoringApplied":true,"overallScore":0.5,"threshold":0.8,"stimuliRun":4,"stimuliTotal":4}]}'
    );
    assert.equal(getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 }).passed, false);
  });

  it("reports not-found when there is no results.jsonl", () => {
    const dir = path.join(root, "empty");
    fs.mkdirSync(dir, { recursive: true });
    const v = getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 });
    assert.equal(v.found, false);
    assert.equal(v.passed, false);
  });

  it("reports not-found when results.jsonl has no run-summary record", () => {
    const dir = newRunSummary("nosummary", '{"type":"trial","name":"x"}');
    assert.equal(getVallyShardVerdict({ resultsDir: dir, threshold: 0.8 }).found, false);
  });

  it("uses the newest results.jsonl when several runs exist", () => {
    const shardDir = newRunSummary(
      "multi",
      '{"type":"run-summary","passed":false,"hadExecutionErrors":false,"evals":[{"name":"e","passed":false,"scoringApplied":true,"overallScore":0.5,"threshold":0.8,"stimuliRun":4,"stimuliTotal":4}]}',
      "2026-06-18T04-27-19-656Z"
    );
    const newerDir = path.join(shardDir, "2026-06-18T05-00-00-000Z");
    fs.mkdirSync(newerDir, { recursive: true });
    const newerFile = path.join(newerDir, "results.jsonl");
    fs.writeFileSync(
      newerFile,
      '{"type":"run-summary","passed":true,"hadExecutionErrors":false,"evals":[{"name":"e","passed":true,"scoringApplied":true,"overallScore":1.0,"threshold":0.8,"stimuliRun":4,"stimuliTotal":4}]}'
    );
    // Make the newer file unambiguously newer (avoid same-millisecond ties on fast disks).
    const older = path.join(shardDir, "2026-06-18T04-27-19-656Z", "results.jsonl");
    const past = new Date(Date.now() - 60_000);
    fs.utimesSync(older, past, past);

    assert.equal(getVallyShardVerdict({ resultsDir: shardDir, threshold: 0.8 }).passed, true);
  });
});
