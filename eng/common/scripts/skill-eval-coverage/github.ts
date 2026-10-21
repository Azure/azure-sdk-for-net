// Reads immutable PR files as data and updates a bot-owned comment from a trusted workflow.
import fs from "node:fs";
import path from "node:path";
import { pathToFileURL } from "node:url";
import {
  CONFIG_PATH, COMMENT_MARKER, MAX_FILE_BYTES, checkCoverage, parseConfig,
  renderReport, repositoryPath,
} from "./coverage.ts";
import type { CoverageConfig, CoverageReport, RepositoryFile, RepositorySnapshot } from "./coverage.ts";
import { writeSummary } from "./check.ts";

export class GitHubApi {
  private readonly apiUrl: string;
  private readonly token: string;
  private readonly fetcher: typeof fetch;

  constructor(
    apiUrl: string,
    token: string,
    fetcher: typeof fetch = fetch,
  ) {
    const url = new URL(apiUrl);
    if (url.protocol !== "https:" || url.username || url.password || url.search || url.hash) {
      throw new Error("Expected a trusted HTTPS GitHub API URL.");
    }
    if (!token) throw new Error("A GitHub token is required.");
    this.apiUrl = apiUrl;
    this.token = token;
    this.fetcher = fetcher;
  }

  async request<T>(route: string, method = "GET", body?: unknown): Promise<T> {
    if (!route.startsWith("/repos/") || route.includes("://") || /[\r\n]/.test(route)) {
      throw new Error("Unexpected GitHub API route.");
    }
    const response = await this.fetcher(this.apiUrl.replace(/\/$/, "") + route, {
      method, redirect: "error", signal: AbortSignal.timeout(30000),
      headers: { Authorization: `Bearer ${this.token}`, Accept: "application/vnd.github+json",
        "X-GitHub-Api-Version": "2022-11-28", "Content-Type": "application/json" },
      ...(body === undefined ? {} : { body: JSON.stringify(body) }),
    });
    if (!response.ok) throw new Error(`GitHub API request failed (${response.status}).`);
    const text = await response.text();
    if (Buffer.byteLength(text) > 16 * 1024 * 1024) throw new Error("GitHub response is too large.");
    return JSON.parse(text) as T;
  }

  async pages<T>(route: string): Promise<T[]> {
    const items: T[] = [];
    for (let page = 1; page <= 30; page++) {
      const batch = await this.request<T[]>(`${route}${route.includes("?") ? "&" : "?"}per_page=100&page=${page}`);
      if (!Array.isArray(batch)) throw new Error("Expected a paginated GitHub list.");
      items.push(...batch);
      if (batch.length < 100) return items;
    }
    throw new Error("GitHub list exceeds the bounded pagination limit.");
  }
}

interface PullRequest {
  number: number;
  state: string;
  changed_files: number;
  head: { sha: string; ref: string; repo: { full_name: string } | null };
  base: { repo: { full_name: string } };
}

interface WorkflowRun {
  id: number;
  run_attempt: number;
  event: string;
  status: string;
  conclusion: string;
  path: string;
  workflow_id: number;
  head_sha: string;
  head_branch: string;
  head_repository: { full_name: string } | null;
  repository: { full_name: string };
  pull_requests: { number: number }[];
}

interface Comment {
  id: number;
  body: string;
  user: { login: string; type: string };
}

function repositoryName(value: string): string {
  if (!/^[A-Za-z0-9_.-]+\/[A-Za-z0-9_.-]+$/.test(value)) throw new Error("Invalid GitHub repository.");
  return value;
}

function positive(value: unknown): value is number {
  return Number.isSafeInteger(value) && Number(value) > 0;
}

function sha(value: unknown): value is string {
  return typeof value === "string" && /^[a-f0-9]{40}$/.test(value);
}

function sameRepository(a: string | undefined, b: string): boolean {
  return typeof a === "string" && a.toLowerCase() === b.toLowerCase();
}

export async function remoteSnapshot(api: GitHubApi, repo: string, head: string): Promise<RepositorySnapshot> {
  if (!sha(head)) throw new Error("Invalid PR head revision.");
  const route = `/repos/${repositoryName(repo)}`;
  const tree = await api.request<{ truncated: boolean; tree: (RepositoryFile & { type: string })[] }>(
    `${route}/git/trees/${head}?recursive=1`);
  if (tree.truncated || !Array.isArray(tree.tree)) throw new Error("Incomplete GitHub file inventory.");
  const files = tree.tree.filter((entry) => entry.type === "blob").map((entry) => ({
    path: repositoryPath(entry.path), mode: entry.mode, sha: entry.sha, size: entry.size,
  }));
  const entries = new Map(files.map((file) => [file.path, file]));
  const cache = new Map<string, Promise<string>>();
  return {
    files,
    async read(file) {
      const entry = entries.get(repositoryPath(file));
      if (!entry) return undefined;
      if (!sha(entry.sha) || (entry.size ?? Infinity) > MAX_FILE_BYTES || entry.mode === "120000") {
        throw new Error("Repository file is a link, too large, or has no immutable blob ID.");
      }
      if (!cache.has(entry.sha)) cache.set(entry.sha, (async () => {
        const blob = await api.request<{ encoding: string; content: string; size: number; sha: string }>(
          `${route}/git/blobs/${entry.sha}`);
        if (blob.sha !== entry.sha || blob.encoding !== "base64" || blob.size > MAX_FILE_BYTES ||
            typeof blob.content !== "string" || blob.content.length > MAX_FILE_BYTES * 2) {
          throw new Error("Unexpected GitHub blob response.");
        }
        const bytes = Buffer.from(blob.content, "base64");
        if (bytes.length !== blob.size || bytes.length > MAX_FILE_BYTES) throw new Error("Invalid blob size.");
        return bytes.toString("utf8");
      })());
      return cache.get(entry.sha)!;
    },
  };
}

async function pull(api: GitHubApi, repo: string, number: number): Promise<PullRequest> {
  if (!positive(number)) throw new Error("Invalid PR number.");
  const value = await api.request<PullRequest>(`/repos/${repo}/pulls/${number}`);
  if (value.number !== number || !sameRepository(value.base?.repo?.full_name, repo) || !sha(value.head?.sha)) {
    throw new Error("Unexpected PR identity.");
  }
  return value;
}

async function getChangedPaths(api: GitHubApi, repo: string, pr: PullRequest): Promise<string[]> {
  if (!Number.isSafeInteger(pr.changed_files) || pr.changed_files < 0 || pr.changed_files >= 3000) {
    throw new Error("PR file inventory exceeds the supported limit.");
  }
  const changed = await api.pages<{ filename: string; previous_filename?: string }>(
    `/repos/${repo}/pulls/${pr.number}/files`);
  if (changed.length !== pr.changed_files) throw new Error("Incomplete PR changed-file inventory.");
  return changed.flatMap((file) => file.previous_filename ?
    [repositoryPath(file.filename), repositoryPath(file.previous_filename)] : [repositoryPath(file.filename)]);
}

export function shouldRunLint(paths: string[]): boolean {
  // The original blocking lint scope must not depend on PR-editable coverage configuration.
  return paths.some((file) => file.startsWith(".github/skills/") ||
    file.startsWith("eng/skill-eval/") || file === ".github/workflows/skill-eval.yml");
}

function affectsCoverage(paths: string[], config: CoverageConfig): boolean {
  return paths.some((file) => file.startsWith(config.skillsRoot + "/") ||
    file === CONFIG_PATH || config.pipelines.includes(file));
}

export async function checkPullRequest(
  api: GitHubApi, repo: string, pr: PullRequest, config: CoverageConfig, changedPaths?: string[],
): Promise<CoverageReport> {
  const paths = changedPaths ?? await getChangedPaths(api, repo, pr);
  if (!affectsCoverage(paths, config)) {
    return { skills: [], configurationIssues: [], fullScan: false };
  }
  return checkCoverage(await remoteSnapshot(api, repo, pr.head.sha), config, paths);
}

export async function upsertComment(
  api: GitHubApi, repo: string, number: number, body: string, createIfMissing = true,
): Promise<boolean> {
  const comments = await api.pages<Comment>(`/repos/${repo}/issues/${number}/comments`);
  const existing = comments.find((comment) => comment.user?.type === "Bot" &&
    comment.user.login === "github-actions[bot]" && comment.body?.startsWith(COMMENT_MARKER));
  if (existing) {
    if (existing.body !== body) await api.request(`/repos/${repo}/issues/comments/${existing.id}`, "PATCH", { body });
  } else if (createIfMissing) {
    await api.request(`/repos/${repo}/issues/${number}/comments`, "POST", { body });
  } else return false;
  return true;
}

export async function reportCompletedRun(
  api: GitHubApi, repo: string, runId: number, config: CoverageConfig, serverUrl: string,
): Promise<"posted" | "unknown" | "skipped"> {
  repositoryName(repo);
  if (!positive(runId)) throw new Error("Invalid source workflow run.");
  const run = await api.request<WorkflowRun>(`/repos/${repo}/actions/runs/${runId}`);
  const workflow = await api.request<{ id: number }>(`/repos/${repo}/actions/workflows/${encodeURIComponent(path.posix.basename(config.workflow))}`);
  if (run.id !== runId || run.workflow_id !== workflow.id || run.path !== config.workflow ||
      !sameRepository(run.repository?.full_name, repo) || run.event !== "pull_request" ||
      run.status !== "completed" || !sha(run.head_sha) || !positive(run.run_attempt) ||
      ["cancelled", "skipped"].includes(run.conclusion)) return "skipped";

  // GitHub can omit pull_requests for fork runs. Only accept one independently matched open PR.
  const numbers = run.pull_requests?.length ? run.pull_requests.map((pr) => pr.number) :
    (await api.pages<{ number: number }>(`/repos/${repo}/commits/${run.head_sha}/pulls`)).map((pr) => pr.number);
  const candidates: PullRequest[] = [];
  for (const number of new Set(numbers)) {
    const pr = await pull(api, repo, number);
    if (pr.state === "open" && pr.head.sha === run.head_sha && pr.head.ref === run.head_branch &&
        sameRepository(pr.head.repo?.full_name, run.head_repository?.full_name ?? "")) candidates.push(pr);
  }
  if (candidates.length !== 1) return "skipped";
  const pr = candidates[0];
  let report: CoverageReport | null = null;
  let relevant = false;
  try {
    const changedPaths = await getChangedPaths(api, repo, pr);
    relevant = affectsCoverage(changedPaths, config);
    report = await checkPullRequest(api, repo, pr, config, changedPaths);
    relevant = report.skills.length > 0 || report.configurationIssues.length > 0;
  }
  catch { console.warn("Coverage could not be determined; the PR comment will not claim a pass."); }
  const sourceUrl = `${serverUrl}/${repo}/blob/${run.head_sha}`;
  const runUrl = `${serverUrl}/${repo}/actions/runs/${run.id}/attempts/${run.run_attempt}`;
  const body = renderReport(report, { config, sourceUrl, runUrl,
    build: { id: run.id, attempt: run.run_attempt, result: run.conclusion, headSha: run.head_sha } });
  writeSummary(report, body);
  // Check again after all reads: an old run cannot overwrite a comment for a newer PR head.
  const current = await pull(api, repo, pr.number);
  if (current.state !== "open" || current.head.sha !== run.head_sha) return "skipped";
  if (!await upsertComment(api, repo, pr.number, body, relevant)) return "skipped";
  return report ? "posted" : "unknown";
}

export async function main(argv: string[]): Promise<void> {
  if (argv.some((arg) => arg !== "--post-comment") || argv.length > 1) throw new Error("Unknown reporting option.");
  const publish = argv.includes("--post-comment");
  const repo = repositoryName(process.env.GITHUB_REPOSITORY ?? "");
  const config = parseConfig(fs.readFileSync(CONFIG_PATH, "utf8"));
  const event = JSON.parse(fs.readFileSync(process.env.GITHUB_EVENT_PATH ?? "", "utf8"));
  const api = new GitHubApi(process.env.GITHUB_API_URL ?? "https://api.github.com", process.env.GITHUB_TOKEN ?? "");
  const serverUrl = process.env.GITHUB_SERVER_URL ?? "https://github.com";
  if (publish) {
    if (process.env.GITHUB_EVENT_NAME !== "workflow_run" || process.env.GITHUB_ACTIONS !== "true") {
      throw new Error("Only a trusted workflow_run reporter may post comments.");
    }
    console.log(`Coverage comment: ${await reportCompletedRun(api, repo, event.workflow_run?.id, config, serverUrl)}`);
  } else {
    if (process.env.GITHUB_EVENT_NAME !== "pull_request") throw new Error("Expected a pull_request event.");
    const pr = await pull(api, repo, event.number);
    if (pr.head.sha !== event.pull_request?.head?.sha || pr.state !== "open") return;
    const changedPaths = await getChangedPaths(api, repo, pr);
    if (process.env.GITHUB_OUTPUT) {
      fs.appendFileSync(process.env.GITHUB_OUTPUT, `run_lint=${shouldRunLint(changedPaths)}\n`);
    }
    const report = await checkPullRequest(api, repo, pr, config, changedPaths);
    const current = await pull(api, repo, pr.number);
    if (current.head.sha !== pr.head.sha || current.state !== "open") return;
    writeSummary(report, renderReport(report, {
      config, sourceUrl: `${serverUrl}/${repo}/blob/${pr.head.sha}`,
      runUrl: `${serverUrl}/${repo}/actions/runs/${process.env.GITHUB_RUN_ID}`,
    }));
  }
}

if (process.argv[1] && import.meta.url === pathToFileURL(process.argv[1]).href) {
  main(process.argv.slice(2)).catch(() => {
    console.error("Skill coverage reporting failed. No passing coverage result should be inferred.");
    process.exitCode = 1;
  });
}
