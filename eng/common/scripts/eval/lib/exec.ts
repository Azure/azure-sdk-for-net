// Secure process/exec primitives (execFile wrapper with logging + a larger default maxBuffer).
//
// PROVENANCE: Copied from azure-rest-api-specs .github/shared/src/exec.js
//   @ ef7dd74c13aa9ca12b67b33b9dc4b5d1419a46f0 and ported to TypeScript (erasable syntax only,
//   run via Node native type stripping). See azure-sdk-tools#16296 for the plan to share these
//   primitives properly instead of copying. Kept under eng/common/scripts/eval/lib so it travels
//   with the eng/common sync into the language repos (unlike .github/shared, which does not sync);
//   this is why the folder path differs from the specs repo.

import child_process from "node:child_process";
import { dirname, join } from "node:path";
import { promisify } from "node:util";

const execFileImpl = promisify(child_process.execFile);

// Minimal logger contract used by the exec helpers (subset of the specs repo ILogger).
export interface ILogger {
  info(message: string): void;
  debug(message: string): void;
}

export interface ExecOptions {
  /** Current working directory. Default: process.cwd(). */
  cwd?: string;
  logger?: ILogger;
  /** Max bytes allowed on stdout or stderr. Default: 16 * 1024 * 1024. */
  maxBuffer?: number;
}

export interface NpmPrefixOptions {
  /** Prefix to pass to npm via "--prefix". */
  prefix?: string;
}

export type ExecNpmOptions = ExecOptions & NpmPrefixOptions;

export interface ExecResult {
  stdout: string;
  stderr: string;
}

export type ExecError = Error & { stdout?: string; stderr?: string; code?: number };

/**
 * Checks whether an unknown error object is an ExecError.
 */
export function isExecError(error: unknown): error is ExecError {
  if (!(error instanceof Error)) return false;

  const e = error as ExecError;
  return typeof e.stdout === "string" || typeof e.stderr === "string";
}

/**
 * Wraps `child_process.execFile()`, adding logging and a larger default maxBuffer.
 *
 * @throws {ExecError}
 */
export async function execFile(
  file: string,
  args?: string[],
  options: ExecOptions = {},
): Promise<ExecResult> {
  const {
    cwd,
    logger,
    // Node default is 1024 * 1024, which is too small for some git commands returning many
    // entities or large file content. To support "git show", should be larger than the largest
    // swagger file in the repo (2.5 MB as of 2/28/2025).
    maxBuffer = 16 * 1024 * 1024,
  } = options;

  logger?.info(`execFile("${file}", ${JSON.stringify(args)})`);

  try {
    // execFile(file, args) is more secure than exec(cmd), since the latter is vulnerable to
    // shell injection.
    const result = await execFileImpl(file, args, {
      cwd,
      maxBuffer,
    });

    logger?.debug(`stdout: '${result.stdout}'`);
    logger?.debug(`stderr: '${result.stderr}'`);

    return result;
  } catch (error) {
    /* v8 ignore next */
    logger?.debug(`error: '${JSON.stringify(error)}'`);

    throw error;
  }
}

/**
 * Calls `execFile()` with appropriate arguments to run `npm` on all platforms.
 *
 * @throws {ExecError}
 */
export async function execNpm(args: string[], options: ExecNpmOptions = {}): Promise<ExecResult> {
  const { prefix } = options;

  // Exclude platform-specific code from coverage
  /* v8 ignore start */
  const { file, defaultArgs } =
    process.platform === "win32"
      ? {
          // Only way I could find to run "npm" on Windows, without using the shell (e.g.
          // "cmd /c npm ...")
          //
          // "node.exe", ["--", "npm-cli.js", ...args]
          //
          // The "--" MUST come BEFORE "npm-cli.js", to ensure args are sent to the script
          // unchanged. If the "--" comes after "npm-cli.js", the args sent to the script will be
          // ["--", ...args], which is NOT equivalent, and can break if args itself contains
          // another "--".

          // example: "C:\Program Files\nodejs\node.exe"
          file: process.execPath,

          // example: "C:\Program Files\nodejs\node_modules\npm\bin\npm-cli.js"
          defaultArgs: ["--", join(dirname(process.execPath), "node_modules", "npm", "bin", "npm-cli.js")],
        }
      : { file: "npm", defaultArgs: [] as string[] };
  /* v8 ignore stop */

  const prefixArgs = prefix ? ["--prefix", prefix] : [];

  return await execFile(file, [...defaultArgs, ...prefixArgs, ...args], options);
}

/**
 * Calls `execNpm()` with arguments ["exec", "--no", "--"] prepended.
 *
 * @throws {ExecError}
 */
export async function execNpmExec(args: string[], options: ExecNpmOptions = {}): Promise<ExecResult> {
  return await execNpm(["exec", "--no", "--", ...args], options);
}
