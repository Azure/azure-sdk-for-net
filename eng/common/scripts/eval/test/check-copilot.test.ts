import assert from "node:assert/strict";
import { mkdtemp, mkdir, rm, writeFile } from "node:fs/promises";
import { tmpdir } from "node:os";
import { join } from "node:path";
import { test } from "node:test";
import { checkCopilotCli } from "../check-copilot.ts";
import { execFile } from "../lib/exec.ts";

const scenarios = [
    "authenticated token", "cached login", "missing token", "invalid token",
    "missing configuration", "missing executable", "directory",
    "startup failure", "auth query failure", "unresolved variable",
    "cleanup failure", "startup and cleanup failure", "token precedence",
    "whitespace token", "SDK initialization failure",
    "installation token", "installation token override", "installation token fallback",
    "installation token rejected",
] as const;

for (const scenario of scenarios) {
    test(`checkCopilotCli: ${scenario}`, async () => {
        const workspace = await mkdtemp(join(tmpdir(), "copilot-preflight with spaces-"));
        try {
            const executable = join(workspace, "copilot");
            if (scenario === "directory") {
                await mkdir(executable);
            } else if (scenario !== "missing executable") {
                await writeFile(executable, "", { mode: 0o755 });
            }
            const token = scenario.startsWith("installation token")
                ? "ghs_test-token-never-log-this" : "test-token-never-log-this";
            const environment: NodeJS.ProcessEnv = {
                AZSDK_COPILOT_CLI_PATH: scenario === "missing configuration" ? "" : executable,
            };
            if (scenario !== "cached login" && scenario !== "missing token") {
                environment.COPILOT_GITHUB_TOKEN = scenario === "unresolved variable"
                    ? "$(COPILOT_GITHUB_TOKEN)" : scenario === "whitespace token" ? "  " : token;
            }
            if (scenario === "token precedence") {
                environment.AZSDK_COPILOT_GITHUB_TOKEN = `  ${token}  `;
                environment.COPILOT_GITHUB_TOKEN = "lower-priority-test-token";
                environment.GH_TOKEN = "third-priority-test-token";
                environment.GITHUB_TOKEN = "fourth-priority-test-token";
            }
            if (scenario === "installation token override") {
                environment.AZSDK_COPILOT_GITHUB_TOKEN = `  ${token}  `;
                environment.COPILOT_GITHUB_TOKEN = "lower-priority-test-token";
            }
            if (scenario === "installation token fallback") {
                delete environment.COPILOT_GITHUB_TOKEN;
                environment.GH_TOKEN = `  ${token}  `;
            }
            const originalEnvironment = { ...environment };
            const logs: string[] = [];
            const calls: string[] = [];
            const client = {
                async start() {
                    calls.push("start");
                    if (scenario === "startup failure" || scenario === "startup and cleanup failure") {
                        throw new Error(`Cannot start runtime with ${token}`);
                    }
                },
                async getAuthStatus() {
                    calls.push("auth");
                    if (scenario === "auth query failure") {
                        throw new Error(`Authentication query failed with ${token}`);
                    }
                    return { isAuthenticated: !["missing token", "invalid token", "whitespace token", "installation token rejected"].includes(scenario) };
                },
                async forceStop() {
                    calls.push("stop");
                    if (scenario === "cleanup failure" || scenario === "startup and cleanup failure") {
                        throw new Error(`Cannot stop runtime with ${token}`);
                    }
                },
            };
            const failures: Partial<Record<typeof scenarios[number], RegExp>> = {
                "missing token": /authentication failed.*No supported token/,
                "invalid token": /authentication failed.*reports unauthenticated with COPILOT_GITHUB_TOKEN/,
                "whitespace token": /authentication failed.*No supported token/,
                "missing configuration": /executable failed.*AZSDK_COPILOT_CLI_PATH is unset/,
                "missing executable": /executable failed.*ENOENT/,
                directory: /executable failed.*not a file/,
                "startup failure": /startup failed.*Cannot start runtime/,
                "auth query failure": /authentication failed.*Authentication query failed/,
                "unresolved variable": /authentication failed.*unresolved pipeline variable/,
                "cleanup failure": /cleanup failed.*Cannot stop runtime/,
                "startup and cleanup failure": /startup failed[\s\S]*cleanup failed/,
                "SDK initialization failure": /startup failed.*SDK unavailable/,
                "installation token rejected": /authentication failed.*reports unauthenticated with COPILOT_GITHUB_TOKEN/,
            };
            const check = () => checkCopilotCli({
                environment,
                log: message => logs.push(message),
                createClient: async options => {
                    calls.push("create");
                    assert.equal(options.cliPath, executable);
                    const selectedToken = environment.AZSDK_COPILOT_GITHUB_TOKEN?.trim()
                        || environment.COPILOT_GITHUB_TOKEN?.trim() || environment.GH_TOKEN?.trim() || undefined;
                    if (scenario.startsWith("installation token")) {
                        assert.equal(options.githubToken, undefined);
                        assert.equal(options.useLoggedInUser, true);
                        assert.deepEqual(options.environment, { ...environment, COPILOT_GITHUB_TOKEN: selectedToken });
                        assert.notEqual(options.environment, environment);
                    } else {
                        assert.equal(options.environment, environment);
                        assert.equal(options.githubToken, selectedToken);
                        assert.equal(options.useLoggedInUser, !selectedToken);
                    }
                    if (scenario === "SDK initialization failure") {
                        throw new Error("SDK unavailable");
                    }
                    return client;
                },
            });
            const expectedFailure = failures[scenario];
            if (expectedFailure) {
                await assert.rejects(check(), (error: unknown) => {
                    assert.ok(error instanceof Error);
                    assert.match(error.message, expectedFailure);
                    assert.ok(!error.message.includes(token));
                    if (["missing token", "invalid token", "whitespace token", "installation token rejected"].includes(scenario)) {
                        assert.match(error.message, /GitHub Copilot is not authenticated/);
                        assert.match(error.message, /copilot login/);
                        for (const name of ["AZSDK_COPILOT_GITHUB_TOKEN", "COPILOT_GITHUB_TOKEN", "GH_TOKEN", "GITHUB_TOKEN"]) {
                            assert.ok(error.message.includes(name));
                        }
                    }
                    if (scenario === "auth query failure") {
                        assert.match(error.message, /Could not query GitHub Copilot authentication status after the runtime started/);
                        assert.match(error.message, /https:\/\/docs\.github\.com\/en\/copilot\/how-tos\/copilot-cli\/install-copilot-cli/);
                        assert.match(error.message, /Set AZSDK_COPILOT_CLI_PATH/);
                        assert.match(error.message, /Underlying error: Authentication query failed with \[REDACTED\]/);
                        assert.doesNotMatch(error.message, /GitHub Copilot is not authenticated/);
                    }
                    return true;
                });
            } else {
                await check();
                assert.ok(logs.some(message => message.includes("Authentication verified")));
            }
            assert.ok(logs.every(message => !message.includes(token) && !message.includes("lower-priority-test-token")));
            assert.deepEqual(environment, originalEnvironment);
            if (["missing configuration", "missing executable", "directory", "unresolved variable"].includes(scenario)) {
                assert.deepEqual(calls, []);
            } else if (scenario === "SDK initialization failure") {
                assert.deepEqual(calls, ["create"]);
            } else if (scenario === "startup failure" || scenario === "startup and cleanup failure") {
                assert.deepEqual(calls, ["create", "start", "stop"]);
            } else {
                assert.deepEqual(calls, ["create", "start", "auth", "stop"]);
            }
            if (scenario === "cached login") {
                assert.ok(logs.some(message => message.includes("none; checking cached login")));
            }
        } finally {
            await rm(workspace, { recursive: true, force: true });
        }
    });
}

for (const scenario of ["executable", "DLL", "command failure", "failed result", "invalid JSON", "authentication failure"] as const) {
    test(`checkCopilotCli SpecInputs customization: ${scenario}`, async () => {
        const workspace = await mkdtemp(join(tmpdir(), "copilot-spec-inputs-"));
        try {
            const executable = join(workspace, "copilot");
            await writeFile(executable, "", { mode: 0o755 });
            const azsdkPath = join(workspace, scenario === "DLL" ? "azsdk.dll" : "azsdk");
            const request = 'Rename the client to "SampleClient"; $(not-a-shell-command)';
            const token = "test-token-never-log-this";
            const environment = { AZSDK_COPILOT_CLI_PATH: executable, COPILOT_GITHUB_TOKEN: token };
            const calls: string[] = [];
            const logs: string[] = [];
            const check = () => checkCopilotCli({
                environment,
                log: message => logs.push(message),
                customization: { azsdkPath, tspProjectPath: workspace, customizationRequest: request },
                createClient: async () => ({
                    async start() { calls.push("start"); },
                    async getAuthStatus() {
                        calls.push("auth");
                        return { isAuthenticated: scenario !== "authentication failure" };
                    },
                    async forceStop() { calls.push("stop"); },
                }),
                runCommand: async (command, args, options) => {
                    calls.push("command");
                    assert.equal(command, scenario === "DLL" ? "dotnet" : azsdkPath);
                    assert.deepEqual(args, [
                        ...(scenario === "DLL" ? [azsdkPath] : []),
                        "tsp", "client", "customized-update",
                        "--tsp-project-path", workspace,
                        "--customization-request", request,
                        "--edit-scope", "SpecInputs",
                        "--output", "json",
                    ]);
                    assert.equal(options?.cwd, workspace);
                    assert.equal(options?.env, environment);
                    assert.equal(typeof options?.onStdoutLine, "function");
                    assert.equal(typeof options?.onStderrLine, "function");
                    options?.onStdoutLine?.(`Tool progress: ${token}`);
                    options?.onStderrLine?.(`Tool diagnostic: ${token}`);
                    assert.ok(logs.includes("[Copilot customization stdout] Tool progress: [REDACTED]"));
                    assert.ok(logs.includes("[Copilot customization stderr] Tool diagnostic: [REDACTED]"));
                    if (scenario === "command failure") {
                        throw Object.assign(new Error(`Command failed: ${token}`), {
                            stdout: `Tool failure: ${token}`,
                            stderr: `Runtime failure: ${token}`,
                        });
                    }
                    return {
                        stdout: scenario === "invalid JSON" ? `not JSON: ${token}`
                            : JSON.stringify({
                                success: scenario !== "failed result",
                                operation_status: scenario === "failed result" ? "Failed" : "Succeeded",
                                response_error: scenario === "failed result" ? token : undefined,
                            }),
                        stderr: "",
                    };
                },
            });
            const errors: Partial<Record<typeof scenario, RegExp>> = {
                "command failure": /customization failed[\s\S]*Tool failure: \[REDACTED\][\s\S]*Runtime failure: \[REDACTED\]/,
                "failed result": /customization failed.*azsdk_customized_code_update failed/,
                "invalid JSON": /customization failed.*invalid JSON/,
                "authentication failure": /authentication failed/,
            };
            const expectedError = errors[scenario];
            if (expectedError) {
                await assert.rejects(check(), (error: unknown) => {
                    assert.ok(error instanceof Error);
                    assert.match(error.message, expectedError);
                    assert.ok(!error.message.includes(token));
                    assert.ok(logs.includes(error.message));
                    return true;
                });
            } else {
                await check();
                assert.ok(logs.some(message => message.includes("SpecInputs customization succeeded")));
            }
            assert.deepEqual(calls, [
                "start", "auth", "stop",
                ...(scenario === "authentication failure" ? [] : ["command"]),
            ]);
            assert.ok(logs.every(message => !message.includes(token)));
        } finally {
            await rm(workspace, { recursive: true, force: true });
        }
    });
}

for (const exitCode of [0, 1]) {
    test(`execFile streams complete lines and retains output on exit ${exitCode}`, async () => {
        const stdoutLines: string[] = [];
        const stderrLines: string[] = [];
        const execution = execFile(process.execPath, ["-e", `
            process.stdout.write("par");
            setTimeout(() => {
                process.stdout.write("tial\\nlast");
                process.stderr.write("diagnostic");
                process.exitCode = ${exitCode};
            }, 10);
        `], {
            onStdoutLine: line => stdoutLines.push(line),
            onStderrLine: line => stderrLines.push(line),
        });
        if (exitCode === 0) {
            const result = await execution;
            assert.deepEqual(result, { stdout: "partial\nlast", stderr: "diagnostic" });
        } else {
            await assert.rejects(execution, (error: unknown) => {
                assert.ok(error instanceof Error);
                assert.ok("stdout" in error && error.stdout === "partial\nlast");
                assert.ok("stderr" in error && error.stderr === "diagnostic");
                return true;
            });
        }
        assert.deepEqual(stdoutLines, ["partial", "last"]);
        assert.deepEqual(stderrLines, ["diagnostic"]);
    });
}
