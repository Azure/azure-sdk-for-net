// Checks skill-local Eval presence using repository files as data only.
import path from "node:path";
import { parseDocument } from "yaml";

export const CONFIG_PATH = ".github/skill-eval-coverage.json";
export const COMMENT_MARKER = "<!-- azsdk-skill-eval-coverage -->";
export const MAX_FILE_BYTES = 256 * 1024;

export interface CoverageConfig {
  skillsRoot: string;
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
  issues: string[];
}

export interface CoverageReport {
  skills: SkillCoverage[];
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
  if (!record(value)) throw new Error("Expected coverage configuration.");
  return {
    skillsRoot: repositoryPath(value.skillsRoot),
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

function nonempty(value: unknown): value is string {
  return typeof value === "string" && value.trim().length > 0;
}

function hasStimulus(value: unknown): boolean {
  if (!record(value) || !Array.isArray(value.stimuli)) return false;
  return value.stimuli.some((stimulus: unknown) => record(stimulus) && nonempty(stimulus.name) &&
    (stimulus.turns === undefined ? nonempty(stimulus.prompt) :
      Array.isArray(stimulus.turns) && stimulus.turns.length > 0 && stimulus.turns.every(nonempty) &&
      (stimulus.prompt === undefined || typeof stimulus.prompt === "string")));
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
    changes.has(root + ".vally.yaml");
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

  const skills: SkillCoverage[] = [];
  for (const name of [...names].sort()) {
    const directory = root + name + "/";
    const skillFile = directory + "SKILL.md";
    if (!files.has(skillFile)) {
      if (changes.has(skillFile)) {
        skills.push({ name, skillFile, status: "deleted", evals: [], issues: [] });
      }
      continue; // Shared guides and fixture folders without SKILL.md are not skills.
    }
    const item: SkillCoverage = { name, skillFile, status: "missing", evals: [], issues: [] };
    if (!regular(files.get(skillFile))) {
      item.issues.push("SKILL.md must be a regular file, not a symbolic link.");
      skills.push(item);
      continue;
    }
    const candidates = [...files.keys()].filter((file) => file.startsWith(directory) &&
      /(?:^|\/)(?:eval|[^/]+\.eval)\.ya?ml$/.test(file.slice(directory.length)) &&
      (file === directory + "eval.yaml" || file === directory + "eval.yml" ||
        file.startsWith(directory + "evals/") || file.startsWith(directory + "evaluate/evals/")) &&
      !file.slice(directory.length).split("/").includes("fixtures"));
    for (const file of candidates.sort()) {
      if (!regular(files.get(file)) || (files.get(file)?.size ?? 0) > MAX_FILE_BYTES) {
        item.issues.push(`Eval must be a regular file of at most ${MAX_FILE_BYTES} bytes: ${file}`);
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
      item.evals.push(file);
    }
    if (item.evals.length) item.status = "present";
    else item.issues.push("No associated Eval with a named, nonempty stimulus was found in the skill folder.");
    skills.push(item);
  }
  return { skills, fullScan };
}

export function hasCoverageWarnings(report: CoverageReport): boolean {
  return report.skills.some((skill) => skill.status === "missing");
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
  build?: { id: number; attempt: number; result: string; headSha: string };
}

export function renderReport(report: CoverageReport | null, links: ReportLinks): string {
  const active = report?.skills.filter((skill) => skill.status !== "deleted") ?? [];
  const heading = report === null ? "⚠️ Skill Eval coverage could not be determined" :
    hasCoverageWarnings(report) ? "⚠️ Skill Eval coverage missing" :
      active.length ? "✅ Skill Eval coverage present" : "ℹ️ No remaining affected skills to check";
  const lines = [COMMENT_MARKER, `## ${heading}`, ""];
  if (report && hasCoverageWarnings(report)) {
    lines.push(
      "> **Grace period:** This warning will become a build blocker by **November 9, 2026**.",
      "> For now, missing Eval coverage is warning-only; you may proceed if all other required checks pass.",
      "> Add or fix the affected Evals before the deadline.", "");
  }
  if (links.build) {
    const build = links.build;
    lines.push(`**Coverage/lint build:** ${links.runUrl ? link(`#${build.id}`, links.runUrl) : `#${build.id}`} · ` +
      `**Build result:** ${html(build.result)} · **Attempt:** ${build.attempt}`,
      `**Skill revision:** <code>${html(build.headSha)}</code>`, "");
  }
  if (!report) {
    lines.push("The coverage check could not read all required data. Do not treat this as a coverage pass.");
  } else {
    if (report.fullScan) lines.push("Full inventory: coverage configuration or shared skills configuration changed.", "");
    lines.push("| Skill | Coverage | Associated Eval |", "| --- | --- | --- |");
    for (const skill of report.skills.slice(0, 50)) {
      const status = skill.status === "present" ? "Present" : skill.status === "deleted" ? "Skipped — skill deleted" : "Missing";
      const evals = skill.evals.slice(0, 3).map((file) => links.sourceUrl ?
        link(html(path.posix.basename(file)), `${links.sourceUrl}/${file.split("/").map(encodeURIComponent).join("/")}`) :
        `<code>${html(file)}</code>`).join(", ") || "—";
      lines.push(`| <code>${html(skill.name)}</code> | ${status} | ${evals} |`);
    }
    if (!report.skills.length) lines.push("| — | No skill changes | — |");
    for (const skill of report.skills.filter((item) => item.status === "missing").slice(0, 30)) {
      lines.push("", `**<code>${html(skill.name)}</code>**: ${html(skill.issues.join(" "))}`);
    }
    if (report.skills.length > 50) lines.push("", "Only the first 50 skills are shown; run the local JSON inventory for the complete list.");
  }
  const body = lines.join("\n").slice(0, 50000);
  return body + "\n\n" + [
    `${link("Eval-authoring guide", links.config.authoringGuideUrl)} · ${link("View Eval dashboard", links.config.dashboardUrl)}`,
    "Dashboard access requires corporate access/sign-in. It shows published historical results, not validation of this PR.",
    "This checks associated Eval presence only. Semantic coverage of the skill's capabilities is not assessed.",
    ...(links.runUrl ? [link("Check run", links.runUrl)] : []),
    "Coverage warnings are **nonblocking**. This check does not run Evals or prove behavioral correctness. Existing lint failures remain blocking.",
  ].join("\n\n") + "\n";
}
