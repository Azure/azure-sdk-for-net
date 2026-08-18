import { spawn } from "node:child_process";
import path from "node:path";
import { fileURLToPath } from "node:url";

const [command, ...rawArgs] = process.argv.slice(2);
if (!command) {
  console.error("Usage: mcp-stdio-proxy.ts <command> [args...]");
  process.exit(1);
}

const scriptDirectory = path.dirname(fileURLToPath(import.meta.url));
const repositoryRoot = path.resolve(scriptDirectory, "../../../..");
const args = rawArgs.map((argument) =>
  argument.startsWith("__REPO_ROOT__/")
    ? path.join(repositoryRoot, argument.slice("__REPO_ROOT__/".length))
    : argument
);

const child = spawn(command, args, {
  env: process.env,
  stdio: ["pipe", "pipe", "pipe"],
});

process.stdin.pipe(child.stdin);
child.stdout.pipe(process.stdout);
child.stderr.pipe(process.stderr);

child.on("error", (error) => {
  console.error(`Failed to start MCP server: ${error.message}`);
  process.exitCode = 1;
});

child.on("exit", (code) => {
  process.exit(code ?? 1);
});

for (const signal of ["SIGINT", "SIGTERM"]) {
  process.on(signal, () => child.kill(signal));
}
