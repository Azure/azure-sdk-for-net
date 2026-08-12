// Verdict helpers for the Vally eval shard gate. Reads the `run-summary` record from
// results.jsonl (authoritative) rather than the `vally` exit code, which can be non-zero
// after a teardown flake. A shard passes only if every eval passes: scored evals need
// overallScore >= threshold, unscored evals need their own `passed` true, both need stimuli.

import fs from "node:fs";
import path from "node:path";
import { globFiles } from "./glob.ts";

// Formats a 0..1 ratio as a fixed-1-decimal percentage string (e.g. 97.1).
function pct(ratio) {
  return (ratio * 100).toFixed(1);
}

/**
 * Reads the canonical `run-summary` from the newest results.jsonl under `resultsDir` and
 * decides pass/fail. Returns a plain result object so gating is unit-testable without
 * running `vally`.
 *
 * @param {object} options
 * @param {string} options.resultsDir Directory Vally wrote results into (nested per-run folders).
 * @param {number} [options.threshold] Default pass-rate gate when an eval omits its own.
 * @returns {{found: boolean, passed: boolean, hadExecutionErrors: boolean, lines: string[]}}
 */
export function getVallyShardVerdict({ resultsDir, threshold = 0.8 } = {}) {
  const result = { found: false, passed: false, hadExecutionErrors: false, lines: [] };

  if (!fs.existsSync(resultsDir)) {
    result.lines.push(`No results directory at '${resultsDir}'.`);
    return result;
  }

  // Find the newest results.jsonl beneath resultsDir (Vally nests a per-run timestamp folder).
  const candidates = globFiles(resultsDir, "**/results.jsonl");
  let summaryFile = null;
  let newest = -Infinity;
  for (const file of candidates) {
    const mtime = fs.statSync(file).mtimeMs;
    if (mtime >= newest) {
      newest = mtime;
      summaryFile = file;
    }
  }
  if (!summaryFile) {
    result.lines.push(`No results.jsonl found under '${resultsDir}'.`);
    return result;
  }

  // The last `run-summary` line is the canonical end-of-run verdict.
  let runSummary = null;
  for (const line of fs.readFileSync(summaryFile, "utf8").split(/\r?\n/)) {
    if (!line.trim()) {
      continue;
    }
    let obj;
    try {
      obj = JSON.parse(line);
    } catch {
      continue;
    }
    if (obj && obj.type === "run-summary") {
      runSummary = obj;
    }
  }
  if (!runSummary) {
    result.lines.push(`No run-summary record in '${path.resolve(summaryFile)}'.`);
    return result;
  }

  result.found = true;
  result.hadExecutionErrors = Boolean(runSummary.hadExecutionErrors);

  const evals = Array.isArray(runSummary.evals) ? runSummary.evals : [];
  if (evals.length === 0) {
    result.lines.push("run-summary contains no evals.");
    return result;
  }

  let allPassed = true;
  for (const e of evals) {
    const name = e.name ?? "(unnamed eval)";
    const ran = Number.parseInt(e.stimuliRun ?? 0, 10) || 0;

    if (e.scoringApplied) {
      const score = Number(e.overallScore ?? 0);
      const thr = Number(e.threshold ?? threshold);
      // 1e-9 epsilon so an exact boundary (0.80 >= 0.80) is not dropped by float rounding.
      const pass = ran > 0 && score + 1e-9 >= thr;
      if (pass) {
        result.lines.push(`PASS  ${name} — ${pct(score)}% >= ${pct(thr)}% (${ran} stimuli)`);
      } else {
        result.lines.push(`FAIL  ${name} — ${pct(score)}% < ${pct(thr)}% (${ran} stimuli)`);
        allPassed = false;
      }
    } else {
      const pass = Boolean(e.passed) && ran > 0;
      if (pass) {
        result.lines.push(`PASS  ${name} — graders passed (${ran} stimuli)`);
      } else {
        result.lines.push(`FAIL  ${name} — graders failed (${ran} stimuli)`);
        allPassed = false;
      }
    }
  }

  result.passed = allPassed;
  return result;
}
