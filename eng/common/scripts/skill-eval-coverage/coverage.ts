// Checks skill Eval presence and pipeline discovery using repository files as data only.
import path from "node:path";
import { parseDocument } from "yaml";
import { matchesGlob } from "../eval/lib/glob.ts";

export const CONFIG_PATH = ".github/skill-eval-coverage.json";
export const COMMENT_MARKER = "<!-- azsdk-skill-eval-coverage -->";
export const MAX_FILE_BYTES = 256 * 1024;

export interface CoverageConfig {
  skillsRoot: string;
  pipelines: string[];
  workflow: string;
  dashboardUrl: string;
  authoringGuideUrl: string;
}

export interface RepositoryFile {
  path: string;
  mode: string;
  sha?: string;
  size?: number;
}

export interface RepositorySnapshot {
  files: RepositoryFile[];
  read: (file: string) => Promise<string | undefined>;
}

export interface SkillCoverage {
  name: string;
  skillFile: string;
  status: "present" | "missing" | "deleted";
  evals: string[];
  undiscovered: string[];
  issues: string[];
}

export interface CoverageReport {
  skills: SkillCoverage[];
  configurationIssues: string[];
  fullScan: boolean;
}

export function repositoryPath(value: unknown): string {
  if (typeof value !== "string" || !value || value.length > 4096 ||
      value.includes("\\") || /[\x00-\x1f\x7f]/.test(value) ||
      value.split("/").some((part) => !part || part === "." || part === "..") ||
      /^[A-Za-z]:/.test(value)) {
    throw new Error("Expected a repository-relative path without traversal or control characters.");
  }
  return value;
}

function webUrl(value: unknown): string {
  if (typeof value !== "string") throw new Error("Expected an HTTPS report link.");
  const url = new URL(value);
  if (url.protocol !== "https:" || url.username || url.password || /[\r\n]/.test(value)) {
    throw new Error("Expected an HTTPS report link without credentials.");
  }
  return url.href;
}

export function parseConfig(text: string): CoverageConfig {
  const value = JSON.parse(text);
  if (!value || !Array.isArray(value.pipelines) || value.pipelines.length === 0 ||
      value.pipelines.length > 20) throw new Error("Coverage configuration needs pipeline paths.");
  return {
    skillsRoot: repositoryPath(value.skillsRoot),
    pipelines: [...new Set<string>(value.pipelines.map(repositoryPath))],
    workflow: repositoryPath(value.workflow),
    dashboardUrl: webUrl(value.dashboardUrl),
    authoringGuideUrl: webUrl(value.authoringGuideUrl),
  };
}

function yamlData(text: string): unknown {
  if (Buffer.byteLength(text, "utf8") > MAX_FILE_BYTES) throw new Error("File is too large.");
  const document = parseDocument(text, { version: "1.2", uniqueKeys: true });
  if (document.errors.length) throw new Error("Invalid YAML.");
  return document.toJS({ maxAliasCount: 100 });
}

function record(value: unknown): value is Record<string, unknown> {
  return typeof value === "object" && value !== null && !Array.isArray(value);
}

function regular(file: RepositoryFile | undefined): boolean {
  return file?.mode === "100644" || file?.mode === "100755";
}

interface Discovery {
  root: string;
  patterns: string[];
}

function findDiscovery(value: unknown, result: Discovery[], depth = 0, seen = new WeakSet<object>()): void {
  if (depth > 100) throw new Error("Pipeline nesting is too deep.");
  if (typeof value === "object" && value !== null) {
    if (seen.has(value)) return;
    seen.add(value);
  }
  if (Array.isArray(value)) {
    for (const item of value) findDiscovery(item, result, depth + 1, seen);
  } else if (record(value)) {
    if (typeof value.vallyRoot === "string" && Array.isArray(value.evalGlobs)) {
      const patterns = value.evalGlobs.map((pattern) => repositoryPath(pattern));
      if (!patterns.length) throw new Error("Empty Eval discovery patterns.");
      result.push({ root: repositoryPath(value.vallyRoot), patterns });
    }
    for (const child of Object.values(value)) findDiscovery(child, result, depth + 1, seen);
  }
}

function nonempty(value: unknown): value is string {
  return typeof value === "string" && value.trim().length > 0;
}

function hasStimulus(value: unknown): boolean {
  if (!record(value) || !Array.isArray(value.stimuli)) return false;
  return value.stimuli.some((stimulus: unknown) => record(stimulus) && nonempty(stimulus.name) &&
    (nonempty(stimulus.prompt) || (Array.isArray(stimulus.turns) && stimulus.turns.length > 0 &&
      stimulus.turns.every((turn: unknown) => record(turn) && nonempty(turn.prompt)))));
}

export async function checkCoverage(
  snapshot: RepositorySnapshot,
  config: CoverageConfig,
  changedPaths: string[] | null,
): Promise<CoverageReport> {
  const files = new Map(snapshot.files.map((file) => [repositoryPath(file.path), file]));
  const root = config.skillsRoot + "/";
  const changes = new Set((changedPaths ?? []).map(repositoryPath));
  const fullScan = changedPaths === null || changes.has(CONFIG_PATH) ||
    changes.has(root + ".vally.yaml") || config.pipelines.some((file) => changes.has(file));
  const names = new Set<string>();
  if (fullScan) {
    for (const file of files.keys()) {
      if (file.startsWith(root) && file.slice(root.length).split("/").length === 2 &&
          file.endsWith("/SKILL.md")) names.add(file.slice(root.length).split("/")[0]);
    }
  }
  for (const file of changes) {
    if (file.startsWith(root) && file.slice(root.length).includes("/")) {
      names.add(file.slice(root.length).split("/")[0]);
    }
  }

  const configurationIssues: string[] = [];
  const discovery: Discovery[] = [];
  for (const pipeline of config.pipelines) {
    if (!regular(files.get(pipeline))) {
      configurationIssues.push(`Configured pipeline is missing or is not a regular file: ${pipeline}`);
      continue;
    }
    const text = await snapshot.read(pipeline);
    if (text === undefined) throw new Error("A pipeline file could not be read.");
    try {
      const found: Discovery[] = [];
      findDiscovery(yamlData(text), found);
      if (!found.length) throw new Error("No literal vallyRoot/evalGlobs discovery settings.");
      discovery.push(...found);
    } catch {
      configurationIssues.push(`Cannot read literal vallyRoot/evalGlobs settings from: ${pipeline}`);
    }
  }

  const matchingDiscovery = (file: string) => discovery.filter(({ root: evalRoot, patterns }) =>
    file.startsWith(evalRoot + "/") && patterns.some((pattern) =>
      matchesGlob(file.slice(evalRoot.length + 1), pattern)));
  const skills: SkillCoverage[] = [];
  for (const name of [...names].sort()) {
    const directory = root + name + "/";
    const skillFile = directory + "SKILL.md";
    if (!files.has(skillFile)) {
      if (changes.has(skillFile)) {
        skills.push({ name, skillFile, status: "deleted", evals: [], undiscovered: [], issues: [] });
      }
      continue; // Shared guides and fixture folders without SKILL.md are not skills.
    }
    const item: SkillCoverage = { name, skillFile, status: "missing", evals: [], undiscovered: [], issues: [] };
    if (!regular(files.get(skillFile))) {
      item.issues.push("SKILL.md must be a regular file, not a symbolic link.");
      skills.push(item);
      continue;
    }
    const candidates = [...files.keys()].filter((file) => file.startsWith(directory) &&
      /(?:^|\/)(?:eval|[^/]+\.eval)\.ya?ml$/.test(file.slice(directory.length)) &&
      (file.startsWith(directory + "evals/") || file.startsWith(directory + "evaluate/evals/") || matchingDiscovery(file).length > 0));
    for (const file of candidates.sort()) {
      if (!regular(files.get(file)) || (files.get(file)?.size ?? 0) > MAX_FILE_BYTES) {
        item.issues.push(`Eval must be a regular file of at most ${MAX_FILE_BYTES} bytes: ${file}`);
        continue;
      }
      const matches = matchingDiscovery(file);
      // The collector passes root-relative Eval paths as space-delimited CLI arguments.
      if (matches.length && matches.every(({ root: evalRoot }) => /\s/.test(file.slice(evalRoot.length + 1)))) {
        item.issues.push(`Eval path contains whitespace unsupported by pipeline discovery: ${file}`);
        continue;
      }
      const text = await snapshot.read(file);
      if (text === undefined) throw new Error("An Eval file could not be read.");
      try {
        if (!hasStimulus(yamlData(text))) throw new Error("No nonempty stimulus.");
      } catch {
        item.issues.push(`Invalid Eval YAML or no named, nonempty stimulus: ${file}`);
        continue;
      }
      if (matches.length) item.evals.push(file);
      else item.undiscovered.push(file);
    }
    if (item.evals.length) item.status = "present";
    else if (item.undiscovered.length) item.issues.push("Eval files exist but no configured pipeline discovers them.");
    else item.issues.push("No associated, discoverable Eval with a named stimulus was found.");
    skills.push(item);
  }
  return { skills, configurationIssues, fullScan };
}

export function hasCoverageWarnings(report: CoverageReport): boolean {
  return report.configurationIssues.length > 0 || report.skills.some((skill) => skill.status === "missing");
}

function html(value: string): string {
  return value.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;")
    .replace(/[|\[\]`*_()!@\\]/g, (character) => `&#${character.charCodeAt(0)};`)
    .replace(/\r?\n/g, " ");
}

function link(label: string, value: string): string {
  return `[${label}](${webUrl(value).replace(/\(/g, "%28").replace(/\)/g, "%29")})`;
}

export interface ReportLinks {
  config: CoverageConfig;
  sourceUrl?: string;
  runUrl?: string;
}

export function renderReport(report: CoverageReport | null, links: ReportLinks): string {
  const active = report?.skills.filter((skill) => skill.status !== "deleted") ?? [];
  const heading = report === null ? "⚠️ Skill Eval coverage could not be determined" :
    hasCoverageWarnings(report) ? "⚠️ Skill Eval coverage missing" :
      active.length ? "✅ Skill Eval coverage present" : "ℹ️ No remaining affected skills to check";
  const lines = [COMMENT_MARKER, `## ${heading}`, ""];
  if (!report) {
    lines.push("The coverage check could not read all required data. Do not treat this as a coverage pass.");
  } else {
    if (report.fullScan) lines.push("Full inventory: coverage configuration or shared discovery changed.", "");
    lines.push("| Skill | Coverage | Associated Eval |", "| --- | --- | --- |");
    for (const skill of report.skills.slice(0, 50)) {
      const status = skill.status === "present" ? "Present" : skill.status === "deleted" ? "Skipped — skill deleted" : "Missing";
      const evals = skill.evals.slice(0, 3).map((file) => links.sourceUrl ?
        link(html(path.posix.basename(file)), `${links.sourceUrl}/${file.split("/").map(encodeURIComponent).join("/")}`) :
        `<code>${html(file)}</code>`).join(", ") || "—";
      lines.push(`| <code>${html(skill.name)}</code> | ${status} | ${evals} |`);
    }
    if (!report.skills.length) lines.push("| — | No skill changes | — |");
    for (const issue of report.configurationIssues.slice(0, 10)) lines.push("", `- ${html(issue)}`);
    for (const skill of report.skills.filter((item) => item.status === "missing").slice(0, 30)) {
      lines.push("", `**<code>${html(skill.name)}</code>**: ${html(skill.issues.join(" "))}`);
    }
    if (report.skills.length > 50) lines.push("", "Only the first 50 skills are shown; run the local JSON inventory for the complete list.");
  }
  const body = lines.join("\n").slice(0, 50000);
  return body + "\n\n" + [
    `${link("Eval-authoring guide", links.config.authoringGuideUrl)} · ${link("View Eval dashboard", links.config.dashboardUrl)}`,
    "Dashboard access requires corporate access/sign-in. It shows published historical results, not validation of this PR.",
    ...(links.runUrl ? [link("Check run", links.runUrl)] : []),
    "Coverage warnings are **nonblocking**. This check does not run Evals or prove behavioral correctness. Existing lint failures remain blocking.",
  ].join("\n\n") + "\n";
}
