// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

"use strict";

const { parseWorkerResult } = require("./ReviewContinuation.cjs");

function requireEvidence(condition, message) {
  if (!condition) throw new Error(`Re-review evidence: ${message}`);
}

function visibleText(value, depth = 0) {
  requireEvidence(depth < 5, "unsupported text envelope nesting.");
  if (typeof value === "string") {
    let parsed;
    try { parsed = JSON.parse(value); } catch { return value; }
    return visibleText(parsed, depth + 1);
  }
  if (Array.isArray(value) && value.length === 1) return visibleText(value[0], depth + 1);
  requireEvidence(value?.isError !== true && !value?.payloadPath, "read returned an error or an unread offload.");
  requireEvidence(Array.isArray(value?.content), "read has no visible text.");
  return value.content.map(part => {
    if (part.type === "resource") return part.resource?.text || "";
    return part.type === "text" ? visibleText(part.text, depth + 1) : "";
  }).join("\n");
}

function workerReads(session) {
  // execution.log also contains stderr. Match the controller's actual final
  // worker decision, not a submit event: read-only workers never submit reviews.
  const events = session.split(/\r?\n/).flatMap(line => {
    try { return [JSON.parse(line)]; } catch { return []; }
  });
  const boundary = events.findLastIndex(event => event.type === "assistant.message" && typeof event.data?.content === "string");
  requireEvidence(boundary >= 0, "worker decision boundary is missing.");
  const decision = parseWorkerResult(session);
  requireEvidence(Array.isArray(decision.results), "worker decision is malformed.");
  const starts = new Map();
  const reads = new Map();
  const coverage = [];
  for (const event of events.slice(0, boundary)) {
    const data = event.data;
    if (event.type === "tool.execution_start") starts.set(data.toolCallId, data);
    if (event.type !== "tool.execution_complete" || data.success !== true || starts.get(data.toolCallId)?.toolName !== "view") continue;
    let content;
    try { content = visibleText(data.result?.content); } catch { continue; }
    if (/^(?:Output too large|File too large|Output truncated)/.test(content) || /\n\[Output truncated[.\]]/.test(content)) continue;
    reads.set(data.toolCallId, content);
    // Reuse the shared read-coverage guard on visible successful read results
    // before the accepted decision, excluding hidden detail and failed reads.
    coverage.push(JSON.stringify({ type: event.type, data: { ...data, result: { content } } }));
  }
  return { decision, reads, session: coverage.join("\n") };
}

function planControllerEvidence({ snapshot, progress, markers, loadSession }) {
  requireEvidence(markers.headSha === snapshot.head_sha, "read markers do not belong to the captured head.");
  const files = new Map(snapshot.files.map((file, index) => [`file:${index}`, file]));
  const exported = new Map(markers.files.map(file => [file.path, file]));
  const plans = new Map();
  for (const result of progress.results) {
    const file = files.get(result.id);
    if (!file) continue;
    const attempts = progress.attempts.filter(attempt => attempt.completed.includes(result.id));
    requireEvidence(attempts.length === 1 && attempts[0].assigned.includes(result.id), `missing unique worker assignment for ${file.filename}.`);
    const worker = attempts[0].worker_session;
    requireEvidence(typeof worker === "string" && /^worker-[1-9]\d*\/execution\.log$/.test(worker), "worker artifact path is invalid.");
    if (!plans.has(worker)) plans.set(worker, { worker, files: [], ...workerReads(loadSession(worker)) });
    const plan = plans.get(worker);
    const actual = plan.decision.results.find(entry => entry.id === result.id);
    requireEvidence(actual?.status === "complete" && actual.reasoning === result.reasoning &&
      typeof result.reasoning === "string" && result.reasoning.trim(), `assessment does not match the worker decision for ${file.filename}.`);
    const evidence = result.evidence;
    requireEvidence(evidence && typeof evidence.readCallId === "string" && typeof evidence.quote === "string" && evidence.quote.trim() &&
      actual.evidence?.readCallId === evidence.readCallId && actual.evidence?.quote === evidence.quote,
    `source-backed assessment is missing for ${file.filename}.`);
    const content = plan.reads.get(evidence.readCallId);
    const marker = exported.get(file.filename);
    requireEvidence(content && marker?.chunks?.some(chunk => chunk.content.includes(evidence.quote) &&
      content.includes(chunk.content.trimEnd())), `assessment is not backed by a successful read of ${file.filename}.`);
    requireEvidence(typeof file.patch !== "string" || file.patch.includes(evidence.quote), `quote is not in the captured patch for ${file.filename}.`);
    plan.files.push(marker);
  }
  return [...plans.values()].map(({ worker, files, session }) => ({ worker, files, session }));
}

module.exports = { planControllerEvidence };

if (require.main === module) {
  try {
    const fs = require("node:fs");
    const path = require("node:path");
    const [snapshotPath, progressPath, markersPath, workerRoot] = process.argv.slice(2);
    const read = file => JSON.parse(fs.readFileSync(file, "utf8"));
    const plans = planControllerEvidence({
      snapshot: read(snapshotPath), progress: read(progressPath), markers: read(markersPath),
      loadSession: worker => fs.readFileSync(path.join(workerRoot, ...worker.split("/")), "utf8")
    });
    console.log(JSON.stringify(plans));
  } catch (error) {
    console.error(error.message);
    process.exitCode = 1;
  }
}
