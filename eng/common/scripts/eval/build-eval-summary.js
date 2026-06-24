// Renders a human-readable Markdown rollup from the per-shard Vally JUnit results.
// Port of Build-EvalSummary.ps1.
//
// The Summarize stage already publishes the merged JUnit (which gates the build); this
// script adds a glanceable layer — it reads every shard's JUnit XML, groups results by
// shard, collapses per-trial testcases back to one stimulus, applies the suite threshold,
// and writes a Markdown table plus the list of failing scenarios. Under Azure Pipelines it
// emits `##vso[task.uploadsummary]` so the Markdown renders on the run Summary page. This
// is presentation only and never changes pass/fail.

import fs from "node:fs";
import path from "node:path";
import { pathToFileURL } from "node:url";
import { globFiles } from "./lib/glob.js";

// Maps a JUnit file path back to its shard. Result artifacts download into folders named
// `eval-result-<shardName>`; everything below that is the shard.
export function getShardName(filePath) {
  const segments = filePath.split(/[\\/]/).filter(Boolean);
  for (const segment of segments) {
    if (segment.startsWith("eval-result-")) {
      return segment.replace(/^eval-result-/, "");
    }
  }
  // Fallback: nearest ancestor directory that isn't a Vally timestamp folder, so the shard
  // column shows something diagnostic instead of a useless 'unknown'.
  for (let i = segments.length - 2; i >= 0; i--) {
    if (!/^\d{4}-\d{2}-\d{2}T/.test(segments[i])) {
      return segments[i];
    }
  }
  return "unknown";
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

// Minimal JUnit parse (dependency-free). The eval JUnit is non-nested: testsuites >
// testsuite (with optional properties/property name=threshold) > testcase with optional
// <failure>/<error>/<skipped> children. `\b` after `testsuite` avoids matching `testsuites`.
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

  for (const xmlFile of xmlFiles) {
    const shardName = getShardName(xmlFile);
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

  // Collapse each stimulus's trials into a single pass/fail using the suite threshold. This
  // runs once per shard AFTER every XML file has been read (a shard's artifact folder can
  // hold multiple JUnit files; collapsing per-file would double-count totals).
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
export function formatEvalSummaryMarkdown(shards) {
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
  if (totalTests === 0) {
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
    const next = () => argv[++i];
    switch (argv[i]) {
      case "--results-root":
        options.resultsRoot = next();
        break;
      case "--output-path":
        options.outputPath = next();
        break;
      default:
        throw new Error(`Unknown argument: ${argv[i]}`);
    }
  }
  if (!options.resultsRoot) {
    throw new Error("Missing required argument: --results-root");
  }
  return options;
}

function main(argv) {
  const options = parseArgs(argv);
  const shards = getEvalSummary(options.resultsRoot);
  const markdown = formatEvalSummaryMarkdown(shards);
  fs.writeFileSync(options.outputPath, markdown, "utf8");

  console.log(markdown);

  if (process.env.TF_BUILD) {
    console.log(`##vso[task.uploadsummary]${path.resolve(options.outputPath)}`);
  }

  return shards;
}

if (process.argv[1] && import.meta.url === pathToFileURL(process.argv[1]).href) {
  try {
    main(process.argv.slice(2));
  } catch (error) {
    console.error(error.message);
    process.exit(1);
  }
}
