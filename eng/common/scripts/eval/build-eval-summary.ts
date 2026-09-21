// Renders a Markdown rollup from the per-shard Vally JUnit results: groups by shard,
// collapses per-trial testcases to one stimulus, applies the threshold, and lists failing
// scenarios. Presentation only — never changes pass/fail.

import fs from "node:fs";
import path from "node:path";
import { pathToFileURL } from "node:url";
import { globFiles } from "./lib/glob.ts";
import { expectedShardsFromMatrix, selectSummaryResults } from "./lib/shard-results.ts";

// Maps a JUnit file path back to its shard and job attempt. Result artifacts download into
// folders named `eval-result-<shardName>-<attempt>` (the attempt suffix keeps "Rerun failed
// jobs" from colliding on the artifact name); everything below that is the shard's JUnit.
export function getShardArtifact(filePath) {
  const segments = filePath.split(/[\\/]/).filter(Boolean);
  for (const segment of segments) {
    if (segment.startsWith("eval-result-")) {
      const raw = segment.replace(/^eval-result-/, "");
      // Strip a trailing `-<digits>` job-attempt suffix (absent in older single-attempt runs).
      const match = raw.match(/^(.*)-(\d+)$/);
      if (match) {
        return { shardName: match[1], attempt: Number(match[2]) };
      }
      return { shardName: raw, attempt: 1 };
    }
  }
  // Fallback: nearest ancestor dir that isn't a Vally timestamp folder.
  for (let i = segments.length - 2; i >= 0; i--) {
    if (!/^\d{4}-\d{2}-\d{2}T/.test(segments[i])) {
      return { shardName: segments[i], attempt: 1 };
    }
  }
  return { shardName: "unknown", attempt: 1 };
}

// Back-compat: return just the shard name (attempt suffix stripped).
export function getShardName(filePath) {
  return getShardArtifact(filePath).shardName;
}

// Strips Vally's ' (trial N)' suffix so every trial of a stimulus collapses to one stimulus.
export function getStimulusName(name) {
  if (!name || !name.trim()) {
    return "(unnamed scenario)";
  }
  return name.replace(/\s*\(trial\s+\d+\)\s*$/, "").trim();
}

// Formats a 0..1 ratio as a percentage, dropping a trailing '.0' so whole numbers read as
// '100%' while fractional rates keep one decimal ('93.5%').
export function formatPct(ratio) {
  const value = ratio * 100;
  if (Math.abs(value - Math.round(value)) < 0.05) {
    return `${Math.round(value)}%`;
  }
  return `${value.toFixed(1)}%`;
}

function getAttr(attrs, name) {
  const match = attrs.match(new RegExp(`\\b${name}=["']([^"']*)["']`));
  return match ? match[1] : undefined;
}

// Minimal dependency-free JUnit parse: testsuite (optional threshold property) > testcase
// with optional <failure>/<error>/<skipped> children. `\b` avoids matching `testsuites`.
// NOTE: coupled to Vally's JUnit output shape; if that XML changes, update these regexes
// (or swap in a real XML parser).
function parseSuites(content) {
  const suites = [];
  const suiteRe = /<testsuite\b([^>]*?)(\/>|>([\s\S]*?)<\/testsuite>)/g;
  let suiteMatch;
  while ((suiteMatch = suiteRe.exec(content))) {
    const inner = suiteMatch[2].startsWith("/>") ? "" : suiteMatch[3];

    let threshold;
    const thresholdMatch = inner.match(
      /<property\b[^>]*\bname=["']threshold["'][^>]*\bvalue=["']([^"']+)["']/
    );
    if (thresholdMatch) {
      const parsed = Number(thresholdMatch[1]);
      if (!Number.isNaN(parsed)) {
        threshold = parsed;
      }
    }

    const testcases = [];
    const caseRe = /<testcase\b([^>]*?)(\/>|>([\s\S]*?)<\/testcase>)/g;
    let caseMatch;
    while ((caseMatch = caseRe.exec(inner))) {
      const attrs = caseMatch[1];
      const body = caseMatch[2].startsWith("/>") ? "" : caseMatch[3];
      const timeStr = getAttr(attrs, "time");
      testcases.push({
        name: getAttr(attrs, "name") ?? "",
        time: timeStr ? Number(timeStr) || 0 : 0,
        failure: /<failure\b/.test(body) || /<error\b/.test(body),
        skipped: /<skipped\b/.test(body),
      });
    }

    suites.push({ threshold, testcases });
  }
  return suites;
}

/**
 * Reads every JUnit XML under `resultsRoot`, grouped by shard, and returns an object keyed
 * by shard name with aggregated totals and failing-scenario names.
 *
 * @param {string} resultsRoot Folder containing the downloaded per-shard result artifacts.
 * @returns {Record<string, {shardName: string, total: number, failed: number, skipped: number, durationS: number, failures: string[]}>}
 */
export function getEvalSummary(resultsRoot) {
  const root = path.resolve(resultsRoot);
  const xmlFiles = globFiles(root, "**/*.xml");
  const shards = {};

  // A "Rerun failed jobs" retry publishes a higher-attempt artifact for the same shard.
  // Resolve each file's shard + attempt up front, then only aggregate the highest attempt
  // per shard so a retry supersedes the earlier one instead of double-counting.
  const parsedFiles = xmlFiles.map((xmlFile) => ({ xmlFile, ...getShardArtifact(xmlFile) }));
  const maxAttempt = {};
  for (const { shardName, attempt } of parsedFiles) {
    maxAttempt[shardName] = Math.max(maxAttempt[shardName] ?? 0, attempt);
  }

  for (const { xmlFile, shardName, attempt } of parsedFiles) {
    if (attempt !== maxAttempt[shardName]) {
      continue; // superseded by a later rerun attempt of this shard
    }
    if (!shards[shardName]) {
      shards[shardName] = {
        shardName,
        total: 0,
        failed: 0,
        skipped: 0,
        durationS: 0,
        failures: [],
        // stimulus name -> { trials, passed, skipped, threshold }
        stimuli: new Map(),
      };
    }
    const shard = shards[shardName];

    const content = fs.readFileSync(xmlFile, "utf8");
    // Read each <testsuite>'s threshold and aggregate its trials back up to the stimulus,
    // mirroring exactly what `vally eval` gates on.
    for (const suite of parseSuites(content)) {
      const threshold = suite.threshold ?? 0.8;
      for (const testcase of suite.testcases) {
        const stimulus = getStimulusName(testcase.name);
        if (!shard.stimuli.has(stimulus)) {
          shard.stimuli.set(stimulus, { trials: 0, passed: 0, skipped: 0, threshold });
        }
        const entry = shard.stimuli.get(stimulus);
        entry.threshold = threshold;
        shard.durationS += testcase.time;

        if (testcase.skipped) {
          entry.skipped++;
        } else {
          entry.trials++;
          if (!testcase.failure) {
            entry.passed++;
          }
        }
      }
    }
  }

  // Collapse each stimulus's trials into one pass/fail, once per shard after all XML is read.
  for (const shardName of Object.keys(shards)) {
    const shard = shards[shardName];
    for (const [stimulus, entry] of shard.stimuli) {
      shard.total++;
      if (entry.trials === 0) {
        shard.skipped++;
        continue;
      }
      const passRate = entry.passed / entry.trials;
      // 1e-9 epsilon guards float rounding so 4/5 = 0.8 is not dropped below an 0.8 gate.
      if (passRate + 1e-9 < entry.threshold) {
        shard.failed++;
        shard.failures.push(`${stimulus} (${entry.passed}/${entry.trials} runs passed)`);
      }
    }
  }

  return shards;
}

/**
 * Renders the Markdown summary for the given shard map.
 *
 * @param {Record<string, object>} shards Output of getEvalSummary.
 * @returns {string} Markdown.
 */
export function formatEvalSummaryMarkdown(shards, incompleteShards = []) {
  const all = Object.values(shards);
  const shardCount = all.length;

  let totalTests = 0;
  let totalFailed = 0;
  let totalSkipped = 0;
  for (const shard of all) {
    totalTests += shard.total;
    totalFailed += shard.failed;
    totalSkipped += shard.skipped;
  }
  const totalPassed = totalTests - totalFailed - totalSkipped;

  const lines = [];

  // A run that parsed zero testcases is NOT a pass — surface it as a loud NO RESULTS state.
  let overall;
  let overallIcon;
  if (incompleteShards.length) {
    overall = "INCOMPLETE";
    overallIcon = "⚠️";
  } else if (totalTests === 0) {
    overall = "NO RESULTS";
    overallIcon = "⚠️";
  } else if (totalFailed === 0) {
    overall = "PASSED";
    overallIcon = "✅";
  } else {
    overall = "FAILED";
    overallIcon = "❌";
  }

  // Pass rate is measured over scenarios that actually ran (skips excluded).
  const nonSkipped = totalPassed + totalFailed;
  const overallRatio = nonSkipped > 0 ? totalPassed / nonSkipped : 0;

  lines.push(`## ${overallIcon} Vally eval results — ${overall}`);
  lines.push("");

  if (incompleteShards.length) {
    lines.push("> Some expected shards are missing or incomplete. The available results below are **not** a complete build result; no dashboard bundle will be uploaded.");
    lines.push("");
    for (const shard of incompleteShards) lines.push(`- **${shard.shard}**: ${shard.reason}`);
    lines.push("");
  }

  if (totalTests === 0) {
    lines.push(`No scenarios were found across ${shardCount} shard(s).`);
    lines.push("");
    lines.push("> ⚠️ No eval testcases were found in the downloaded results. This usually means the");
    lines.push("> eval shards did not publish JUnit — the shard jobs failed before running, or the");
    lines.push("> `eval-result-*` artifacts were empty. Check the Eval stage shard logs.");
    return lines.join("\n") + "\n";
  }

  // Glanceable one-liner.
  const scenarioWord = totalTests === 1 ? "scenario" : "scenarios";
  const shardWord = shardCount === 1 ? "shard" : "shards";
  const tallies = [`✅ **${totalPassed} passed**`];
  if (totalFailed > 0) {
    tallies.push(`❌ **${totalFailed} failed**`);
  }
  if (totalSkipped > 0) {
    tallies.push(`⏭️ ${totalSkipped} skipped`);
  }
  tallies.push(`**${formatPct(overallRatio)}** pass rate`);
  lines.push(
    `**${totalTests} ${scenarioWord}** across **${shardCount} ${shardWord}** — ${tallies.join(" · ")}`
  );
  lines.push("");

  // Red shards first (then alphabetical) so a reader's eye lands on failures.
  const ordered = [...all].sort((a, b) => {
    const aClean = a.failed === 0 ? 1 : 0;
    const bClean = b.failed === 0 ? 1 : 0;
    if (aClean !== bClean) {
      return aClean - bClean;
    }
    return a.shardName.localeCompare(b.shardName);
  });

  lines.push("| Shard | Result | Pass rate | Passed | Failed | Skipped | Time (s) |");
  lines.push("| --- | :---: | ---: | ---: | ---: | ---: | ---: |");
  for (const shard of ordered) {
    const passed = shard.total - shard.failed - shard.skipped;
    const icon = shard.failed === 0 ? "✅" : "❌";
    const ran = passed + shard.failed;
    const shardPct = ran > 0 ? formatPct(passed / ran) : "—";
    lines.push(
      `| ${shard.shardName} | ${icon} | ${shardPct} | ${passed} | ${shard.failed} | ${shard.skipped} | ${shard.durationS.toFixed(1)} |`
    );
  }
  // Totals row.
  const totalIcon = totalFailed === 0 ? "✅" : "❌";
  let totalDuration = 0;
  for (const shard of all) {
    totalDuration += shard.durationS;
  }
  lines.push(
    `| **Total** | ${totalIcon} | **${formatPct(overallRatio)}** | **${totalPassed}** | **${totalFailed}** | **${totalSkipped}** | **${totalDuration.toFixed(1)}** |`
  );

  if (totalFailed > 0) {
    const failWord = totalFailed === 1 ? "scenario" : "scenarios";
    lines.push("");
    lines.push(`<details open><summary><strong>❌ ${totalFailed} failing ${failWord}</strong></summary>`);
    lines.push("");
    for (const shard of ordered) {
      if (shard.failed === 0) {
        continue;
      }
      lines.push(`- **${shard.shardName}**`);
      for (const name of shard.failures) {
        lines.push(`  - ❌ ${name}`);
      }
    }
    lines.push("");
    lines.push("</details>");
  }

  return lines.join("\n") + "\n";
}

// ----- CLI -----

function parseArgs(argv) {
  const options = { outputPath: "eval-summary.md" };
  for (let i = 0; i < argv.length; i++) {
    const arg = argv[i];
    const next = () => {
      const value = argv[++i];
      if (!value || value.startsWith("--")) throw new Error(`Missing value for ${arg}`);
      return value;
    };
    switch (arg) {
      case "--results-root":
        options.resultsRoot = next();
        break;
      case "--output-path":
        options.outputPath = next();
        break;
      case "--selected-root":
        options.selectedRoot = next();
        break;
      case "--attempts-file":
        options.attemptsFile = next();
        break;
      default:
        throw new Error(`Unknown argument: ${arg}`);
    }
  }
  if (!options.resultsRoot) {
    throw new Error("Missing required argument: --results-root");
  }
  return options;
}

function main(argv) {
  const options = parseArgs(argv);
  fs.mkdirSync(path.dirname(path.resolve(options.outputPath)), { recursive: true });
  fs.mkdirSync(options.resultsRoot, { recursive: true });
  let selection = null;
  if (options.selectedRoot) {
    let expectedShards = [];
    let matrixValid = true;
    try {
      expectedShards = expectedShardsFromMatrix(process.env.EVAL_EXPECTED_MATRIX);
    } catch {
      matrixValid = false;
    }
    // Even a failed Prepare must use an empty destination, not stale selected results.
    let jobAttempts;
    if (options.attemptsFile) {
      try { jobAttempts = JSON.parse(fs.readFileSync(options.attemptsFile, "utf8")); }
      catch { jobAttempts = { valid: false }; }
    }
    selection = selectSummaryResults({ resultsRoot: options.resultsRoot,
      selectedRoot: options.selectedRoot, expectedShards, jobAttempts });
    if (!matrixValid) {
      selection.status.push({ shard: "Prepare", attempt: null, complete: false,
        reason: "The expected shard matrix is unavailable or invalid; check the Prepare stage." });
    }
  }
  const shards = getEvalSummary(options.selectedRoot ?? options.resultsRoot);
  if (selection) {
    for (const entry of selection.status) {
      if (entry.complete && !shards[entry.shard]?.total) {
        entry.complete = false;
        entry.reason = "The selected JUnit contains no evaluation testcases.";
      }
    }
    selection.complete = selection.status.every((entry) => entry.complete);
    selection.shardInput.complete = selection.complete;
    fs.writeFileSync(path.join(options.resultsRoot, "shard-index.json"), JSON.stringify(selection.shardInput, null, 2) + "\n");
  }
  let markdown = formatEvalSummaryMarkdown(shards, selection?.status.filter((entry) => !entry.complete) ?? []);
  if (selection) {
    markdown += "\n### Selected shard attempts\n\n| Shard | Attempt | Result data |\n| --- | ---: | --- |\n";
    for (const entry of selection.status) markdown += `| ${entry.shard} | ${entry.attempt ?? "—"} | ${entry.complete ? "Complete" : "Incomplete"} |\n`;
    fs.writeFileSync(path.join(path.dirname(options.outputPath), "eval-summary.json"), JSON.stringify({
      schemaVersion: 1, complete: selection.complete, shards: selection.status,
      totals: Object.values(shards).reduce((totals, shard) => ({ scenarios: totals.scenarios + shard.total,
        failed: totals.failed + shard.failed, skipped: totals.skipped + shard.skipped }), { scenarios: 0, failed: 0, skipped: 0 }),
    }, null, 2) + "\n");
  }
  fs.writeFileSync(options.outputPath, markdown, "utf8");

  console.log(markdown);

  if (process.env.TF_BUILD) {
    console.log(`##vso[task.uploadsummary]${path.resolve(options.outputPath)}`);
    if (selection) console.log(`##vso[task.setvariable variable=EvalSummaryComplete]${selection.complete}`);
  }

  // Completed evaluation failures remain governed by failOnFailedTests. Missing result
  // data is an infrastructure failure, reported after retaining a diagnostic summary.
  if (selection && !selection.complete) process.exitCode = 1;

  return shards;
}

if (process.argv[1] && import.meta.url === pathToFileURL(process.argv[1]).href) {
  try {
    main(process.argv.slice(2));
  } catch (error) {
    if (process.env.TF_BUILD && process.argv.includes("--selected-root")) {
      console.log("##vso[task.setvariable variable=EvalSummaryComplete]false");
    }
    console.error(error.message);
    process.exit(1);
  }
}
