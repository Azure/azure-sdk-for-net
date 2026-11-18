import { constants } from "node:fs";
import { access, stat } from "node:fs/promises";
import { resolve } from "node:path";
import { pathToFileURL } from "node:url";
import { execFile, isExecError } from "./lib/exec.ts";

const TOKEN_VARIABLES = [
    "AZSDK_COPILOT_GITHUB_TOKEN",
    "COPILOT_GITHUB_TOKEN",
    "GH_TOKEN",
    "GITHUB_TOKEN",
] as const;

interface CopilotAuthStatus {
    isAuthenticated: boolean;
}

interface CopilotProbe {
    start(): Promise<void>;
    getAuthStatus(): Promise<CopilotAuthStatus>;
    forceStop(): Promise<void>;
}

type CreateClient = (options: {
    cliPath: string;
    githubToken: string | undefined;
    useLoggedInUser: boolean;
    environment: NodeJS.ProcessEnv;
}) => Promise<CopilotProbe>;

interface SpecInputsCustomization {
    azsdkPath: string;
    tspProjectPath: string;
    customizationRequest: string;
}

const createDefaultClient: CreateClient = async ({ cliPath, githubToken, useLoggedInUser, environment }) => {
    const { CopilotClient, RuntimeConnection } = await import("@github/copilot-sdk");
    return new CopilotClient({
        connection: RuntimeConnection.forStdio({ path: cliPath }),
        gitHubToken: githubToken,
        useLoggedInUser,
        env: environment,
        logLevel: "none",
    });
};

async function bounded<T>(operation: Promise<T>, stage: string): Promise<T> {
    let timer: ReturnType<typeof setTimeout> | undefined;
    try {
        return await Promise.race([
            operation,
            new Promise<never>((_, reject) => {
                timer = setTimeout(() => reject(new Error(`${stage} timed out after 30 seconds`)), 30_000);
            }),
        ]);
    } finally {
        clearTimeout(timer);
    }
}

/**
 * Checks the configured executable, then starts its stdio runtime and queries authentication.
 * Uses the .NET MCP's token precedence and never prints token values.
 * Optional SpecInputs customization invokes the azsdk tool and can modify TypeSpec files.
 */
export async function checkCopilotCli({
    environment = process.env,
    log = console.log,
    createClient = createDefaultClient,
    customization,
    runCommand = execFile,
}: {
    environment?: NodeJS.ProcessEnv;
    log?: (message: string) => void;
    createClient?: CreateClient;
    customization?: SpecInputsCustomization;
    runCommand?: typeof execFile;
} = {}): Promise<void> {
    const tokens = TOKEN_VARIABLES.map(name => ({ name, value: environment[name]?.trim() }));
    const selected = tokens.find(token => token.value);
    const secrets = tokens.flatMap(({ value }) => value ? [value, JSON.stringify(value).slice(1, -1)] : []);
    const redact = (error: unknown) => {
        let message = error instanceof Error ? error.message : String(error);
        for (const secret of secrets) {
            message = message.replaceAll(secret, "[REDACTED]");
        }
        return message;
    };
    for (const { name, value } of tokens) {
        log(`[Copilot] ${name}: ${value ? "set (value hidden)" : "unset"}`);
    }
    log(`[Copilot] Token source: ${selected?.name ?? "none; checking cached login"}`);

    let stage = "executable";
    let client: CopilotProbe | undefined;
    let failure: Error | undefined;
    try {
        const configuredPath = environment.AZSDK_COPILOT_CLI_PATH?.trim();
        if (!configuredPath) {
            throw new Error("AZSDK_COPILOT_CLI_PATH is unset. Configure the executable path before running live evals.");
        }
        const cliPath = resolve(configuredPath);
        log(`[Copilot] Configured executable: ${cliPath}`);
        if (!(await stat(cliPath)).isFile()) {
            throw new Error("The configured executable path is not a file.");
        }
        await access(cliPath, constants.X_OK);
        log("[Copilot] Executable exists and is accessible.");

        if (selected?.value && /^\$\([^)]+\)$/.test(selected.value)) {
            stage = "authentication";
            throw new Error(`${selected.name} contains an unresolved pipeline variable, not a GitHub token.`);
        }
        stage = "startup";
        // The CLI supports installation tokens through environment auth, not its explicit SDK token validation.
        const installationToken = selected?.value?.startsWith("ghs_") ? selected.value : undefined;
        client = await createClient({
            cliPath,
            githubToken: installationToken ? undefined : selected?.value,
            useLoggedInUser: !!installationToken || !selected?.value,
            environment: installationToken ? { ...environment, COPILOT_GITHUB_TOKEN: installationToken } : environment,
        });
        await bounded(client.start(), "Runtime startup");
        log("[Copilot] Runtime started successfully over stdio.");

        stage = "authentication";
        let status: CopilotAuthStatus;
        try {
            status = await bounded(client.getAuthStatus(), "Authentication query");
        } catch (error) {
            log(`[Copilot] Failed to query authentication status: ${redact(error)}`);
            throw new Error(
                "Could not query GitHub Copilot authentication status after the runtime started. " +
                "Verify that the configured Copilot CLI is installed correctly and compatible with the SDK. " +
                "For installation instructions, see: https://docs.github.com/en/copilot/how-tos/copilot-cli/install-copilot-cli. " +
                "Set AZSDK_COPILOT_CLI_PATH to the path of the Copilot CLI executable (copilot/copilot.exe). " +
                `Underlying error: ${redact(error)}`);
        }
        if (!status.isAuthenticated) {
            const reason = selected
                ? `The runtime started but reports unauthenticated with ${selected.name}. Token presence does not prove validity or access.`
                : "The runtime started but reports unauthenticated. No supported token is set and no authenticated cached login is available.";
            throw new Error(
                "GitHub Copilot is not authenticated. Please authenticate by one of the following methods: " +
                "(1) Run 'copilot login' to authenticate the Copilot CLI, or " +
                "(2) Set one of the following environment variables with a valid GitHub token: " +
                `${TOKEN_VARIABLES.join(", ")}. ${reason}`);
        }
        log("[Copilot] Authentication verified by the runtime.");

    } catch (error) {
        failure = new Error(`[Copilot ${stage} failed] ${redact(error)}`);
    } finally {
        if (client) {
            try {
                await bounded(client.forceStop(), "Runtime cleanup");
            } catch (error) {
                const cleanup = `[Copilot cleanup failed] ${redact(error)}`;
                failure = new Error(failure ? `${failure.message}\n${cleanup}` : cleanup);
            }
        }
    }
    if (failure) {
        log(failure.message);
        throw failure;
    }

    if (customization) {
        try {
            const { azsdkPath, tspProjectPath, customizationRequest } = customization;
            if (!azsdkPath.trim() || !tspProjectPath.trim() || !customizationRequest.trim()) {
                throw new Error("Provide an azsdk executable/DLL path, TypeSpec project path, and customization request.");
            }
            const azsdk = resolve(azsdkPath);
            const project = resolve(tspProjectPath);
            const isDll = azsdk.toLowerCase().endsWith(".dll");
            log("[Copilot] Running azsdk_customized_code_update with editScope SpecInputs; TypeSpec files may be modified.");
            const { stdout, stderr } = await runCommand(isDll ? "dotnet" : azsdk, [
                ...(isDll ? [azsdk] : []),
                "tsp", "client", "customized-update",
                "--tsp-project-path", project,
                "--customization-request", customizationRequest,
                "--edit-scope", "SpecInputs",
                "--output", "json",
            ], {
                cwd: project,
                env: environment,
                onStdoutLine: line => log(`[Copilot customization stdout] ${redact(line)}`),
                onStderrLine: line => log(`[Copilot customization stderr] ${redact(line)}`),
            });
            let response: unknown;
            try {
                response = JSON.parse(stdout);
            } catch (error) {
                throw new Error(`The azsdk command returned invalid JSON: ${redact(error)}\n${stdout}\n${stderr}`);
            }
            if (typeof response !== "object" || response === null ||
                !("success" in response) || response.success !== true ||
                !("operation_status" in response) || response.operation_status !== "Succeeded") {
                throw new Error(`azsdk_customized_code_update failed.\n${stdout}\n${stderr}`);
            }
            log("[Copilot] SpecInputs customization succeeded.");
        } catch (error) {
            const details = isExecError(error)
                ? `${error.message}\n${error.stdout ?? ""}\n${error.stderr ?? ""}`
                : error;
            const failure = new Error(`[Copilot customization failed] ${redact(details)}`);
            log(failure.message);
            throw failure;
        }
    }
}

// Optional CLI arguments: <azsdk-executable-or-dll> <typespec-project-path> <customization-request>.
// Without arguments, only the existing executable/startup/authentication checks run.
// Command stdout/stderr are streamed as token-redacted lines while retaining the JSON response.
if (process.argv[1] && import.meta.url === pathToFileURL(resolve(process.argv[1])).href) {
    const args = process.argv.slice(2);
    const [azsdkPath, tspProjectPath, customizationRequest] = args;
    if (args.length !== 0 &&
        (args.length !== 3 || !azsdkPath?.trim() || !tspProjectPath?.trim() || !customizationRequest?.trim())) {
        console.error("Usage: node check-copilot.ts [<azsdk-executable-or-dll> <typespec-project-path> <customization-request>]");
        process.exitCode = 1;
    } else {
        checkCopilotCli({
            customization: azsdkPath && tspProjectPath && customizationRequest
                ? { azsdkPath, tspProjectPath, customizationRequest }
                : undefined,
        }).catch((error: unknown) => {
            console.error(error instanceof Error ? error.message : "Copilot preflight failed.");
            process.exitCode = 1;
        });
    }
}
