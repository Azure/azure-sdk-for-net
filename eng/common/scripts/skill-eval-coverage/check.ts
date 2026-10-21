// Runs the same warning-only coverage check locally against working files or a Git diff.
import { execFileSync } from "node:child_process";
import fs from "node:fs";
import path from "node:path";
import { pathToFileURL } from "node:url";
import { parseArgs } from "node:util";
import {
  CONFIG_PATH, MAX_FILE_BYTES, checkCoverage, hasCoverageWarnings, parseConfig,
  renderReport, repositoryPath,
} from "./coverage.ts";
import type { CoverageReport, RepositoryFile, RepositorySnapshot } from "./coverage.ts";

function git(root: string, args: string[]): string {
  return execFileSync("git", ["--literal-pathspecs", "-C", root, ...args], {
    encoding: "utf8", maxBuffer: 16 * 1024 * 1024, timeout: 30000,
    env: { ...process.env, GIT_TERMINAL_PROMPT: "0" },
  });
}

function commit(root: string, ref: string): string {
  const sha = git(root, ["rev-parse", "--verify", "--end-of-options", `${ref}^{commit}`]).trim();
  if (!/^[a-f0-9]{40}$/.test(sha)) throw new Error("Expected a Git commit.");
  return sha;
}

export function gitSnapshot(root: string, ref: string): RepositorySnapshot {
  const sha = commit(root, ref);
  const files = git(root, ["ls-tree", "-rlz", sha]).split("\0").filter(Boolean).flatMap((line) => {
    const match = /^(\d+) (\w+) ([a-f0-9]+)\s+(\d+|-)\t([\s\S]+)$/.exec(line);
    if (!match || match[2] !== "blob") return [];
    return [{ path: repositoryPath(match[5]), mode: match[1], sha: match[3], size: Number(match[4]) }];
  });
  const entries = new Map(files.map((file) => [file.path, file]));
  return {
    files,
    async read(file) {
      const entry = entries.get(repositoryPath(file));
      if (!entry) return undefined;
      if (entry.size > MAX_FILE_BYTES) throw new Error("Repository file exceeds the read limit.");
      return git(root, ["show", `${sha}:${file}`]);
    },
  };
}

export function workingSnapshot(root: string): RepositorySnapshot {
  const files: RepositoryFile[] = [];
  const names = new Set(git(root, ["ls-files", "--cached", "--others", "--exclude-standard", "-z"])
    .split("\0").filter(Boolean));
  for (const name of names) {
    const file = repositoryPath(name);
    let stat: fs.Stats;
    try { stat = fs.lstatSync(path.join(root, file)); }
    catch (error) {
      if ((error as NodeJS.ErrnoException).code === "ENOENT") continue;
      throw error;
    }
    if (stat.isFile() || stat.isSymbolicLink()) {
      files.push({ path: file, mode: stat.isSymbolicLink() ? "120000" : "100644", size: stat.size });
    }
  }
  const realRoot = fs.realpathSync(root);
  const entries = new Map(files.map((file) => [file.path, file]));
  return {
    files,
    async read(file) {
      const entry = entries.get(repositoryPath(file));
      if (!entry) return undefined;
      if (entry.mode === "120000" || (entry.size ?? 0) > MAX_FILE_BYTES) {
        throw new Error("Repository file is a link or exceeds the read limit.");
      }
      const target = fs.realpathSync(path.join(root, file));
      const relative = path.relative(realRoot, target);
      if (relative.startsWith(".." + path.sep) || relative === ".." || path.isAbsolute(relative)) {
        throw new Error("Repository file resolves outside the checkout.");
      }
      return fs.readFileSync(target, "utf8");
    },
  };
}

export function writeSummary(report: CoverageReport | null, markdown: string): void {
  console.log(markdown);
  if (process.env.GITHUB_ACTIONS === "true") {
    if (process.env.GITHUB_STEP_SUMMARY) fs.appendFileSync(process.env.GITHUB_STEP_SUMMARY, markdown);
    const escape = (value: string) => value.replace(/%/g, "%25").replace(/\r/g, "%0D").replace(/\n/g, "%0A");
    if (report && hasCoverageWarnings(report)) {
      for (const skill of report.skills.filter((item) => item.status === "missing")) {
        console.log(`::warning::${escape(`Skill ${skill.name}: ${skill.issues.join(" ")}`)}`);
      }
      for (const issue of report.configurationIssues) console.log(`::warning::${escape(issue)}`);
    }
  }
}

export async function main(argv: string[]): Promise<void> {
  const { values } = parseArgs({ args: argv, options: {
    "repo-root": { type: "string", default: "." },
    base: { type: "string" }, head: { type: "string", default: "HEAD" },
    all: { type: "boolean", default: false }, json: { type: "boolean", default: false },
  } });
  if (values.all && values.base) throw new Error("Choose --all or --base, not both.");
  const root = path.resolve(values["repo-root"]!);
  const snapshot = values.base ? gitSnapshot(root, values.head!) : workingSnapshot(root);
  const configText = await snapshot.read(CONFIG_PATH);
  if (!configText) throw new Error("Coverage configuration is missing.");
  const config = parseConfig(configText);
  const changed = values.base ? git(root, ["diff", "--no-ext-diff", "--no-textconv", "--no-renames",
    "--name-only", "-z", `${commit(root, values.base)}...${commit(root, values.head!)}`, "--"])
    .split("\0").filter(Boolean) : null;
  const report = await checkCoverage(snapshot, config, changed);
  if (values.json) console.log(JSON.stringify(report, null, 2));
  else writeSummary(report, renderReport(report, { config }));
  // Missing coverage is intentionally not a nonzero exit. Data/transport failures still fail.
}

if (process.argv[1] && import.meta.url === pathToFileURL(process.argv[1]).href) {
  main(process.argv.slice(2)).catch(() => {
    console.error("Skill coverage could not be determined. Check configuration, file access and Git history.");
    process.exitCode = 1;
  });
}
