'use strict';

// One private PowerShell policy host per review queue or publication guard.
// Node owns only correlated stdio, deadlines and process groups. PowerShell
// owns policy/state; diagnostic copies never determine pending work.
const path = require('node:path');
const { spawn } = require('node:child_process');
const { TextDecoder } = require('node:util');

function startContinuationSession() {
  const child = spawn(process.env.GH_AW_REVIEW_PWSH || 'pwsh', [
    '-NoLogo', '-NoProfile', '-NonInteractive', '-File', path.join(__dirname, 'ReviewContinuationHost.ps1'),
  ], { stdio: ['pipe', 'pipe', 'pipe'], detached: process.platform !== 'win32' });
  let pending = null, serial = 0, error = null, exitFailure = null, stopping = false, exited = false, closed = false, normalClose = false;
  const failureController = new AbortController();
  let chunks = [], frameBytes = 0, stderr = '', stderrBytes = 0, killTimer, drainTimer, closeTimer;
  const decoder = new TextDecoder('utf-8', { fatal: true, ignoreBOM: true });
  let resolveClosed;
  const closedPromise = new Promise(resolve => { resolveClosed = resolve; });
  function signalChild(signal) {
    try { if (process.platform !== 'win32' && child.pid) process.kill(-child.pid, signal); else child.kill(signal); }
    catch (failure) { if (failure.code !== 'ESRCH') return failure; }
    return null;
  }
  function rejectPending(reason) {
    if (!pending) return;
    const request = pending; pending = null; clearTimeout(request.timer); request.reject(reason);
  }
  function finish() {
    if (closed) return;
    closed = true; clearTimeout(killTimer); clearTimeout(drainTimer); clearTimeout(closeTimer);
    // Keep signal handlers until the queue calls close(): the worker may still
    // be giving the pinned runner time to clean its separately detached CLI.
    if (error) rejectPending(error);
    resolveClosed();
  }
  function setError(reason) {
    if (error) return;
    error = reason;
    chunks = []; frameBytes = 0;
    failureController.abort(reason);
  }
  function stop(reason) {
    setError(reason);
    rejectPending(error);
    if (stopping || closed) return;
    stopping = true;
    if (exited) return;
    const failure = signalChild('SIGTERM');
    if (failure) error = new Error(`${error.message} (unable to send SIGTERM: ${failure.message})`);
    killTimer = setTimeout(() => {
      const failure = signalChild('SIGKILL');
      if (failure) error = new Error(`${error.message} (unable to send SIGKILL: ${failure.message})`);
      drainTimer = setTimeout(() => {
        child.stdin.destroy(); child.stdout.destroy(); child.stderr.destroy(); child.unref(); finish();
      }, 1000);
    }, 1000);
  }
  const onTerm = () => stop(new Error('Continuation host cancelled by SIGTERM.'));
  const onInt = () => stop(new Error('Continuation host cancelled by SIGINT.'));
  process.on('SIGTERM', onTerm); process.on('SIGINT', onInt);
  child.stdout.on('data', data => {
    if (stopping || closed || data.length === 0) return;
    if (!pending) { stop(new Error('Unexpected continuation host output.')); return; }
    if (data.length > pending.maxResponseBytes - frameBytes) { chunks = []; frameBytes = 0; stop(new Error('Continuation response exceeds its derived budget.')); return; }
    frameBytes += data.length;
    const end = data.indexOf(10);
    if (end >= 0 && end !== data.length - 1) { stop(new Error('Unexpected continuation output.')); return; }
    chunks.push(end < 0 ? data : data.subarray(0, end));
    if (end < 0) return;
    let line;
    try { line = decoder.decode(Buffer.concat(chunks)); }
    catch { stop(new Error('Invalid continuation UTF-8 output.')); return; }
    const wireBytes = frameBytes; chunks = []; frameBytes = 0;
    let message; try { message = JSON.parse(line); } catch { stop(new Error('Invalid continuation output.')); return; }
    if (!message || typeof message !== 'object' || Array.isArray(message) || Object.keys(message).length !== 2 || message.id !== pending.id ||
        (!Object.hasOwn(message, 'result') && !Object.hasOwn(message, 'error'))) {
      stop(new Error('Invalid continuation output.')); return;
    }
    if (Object.hasOwn(message, 'error')) {
      stop(new Error(typeof message.error === 'string' ? message.error : 'Invalid continuation error.')); return;
    }
    if (exitFailure) { stop(exitFailure); return; }
    const request = pending; pending = null; clearTimeout(request.timer); request.resolve({ value: message.result, wireBytes });
  });
  child.stdout.on('end', () => {
    if (frameBytes) stop(new Error('Invalid continuation output at EOF.'));
    else if (!normalClose) stop(exitFailure || new Error('Continuation host stdout closed unexpectedly.'));
  });
  child.stdout.on('error', failure => stop(new Error(`Continuation host output failed: ${failure.message}`)));
  child.stderr.on('error', failure => stop(new Error(`Continuation host error stream failed: ${failure.message}`)));
  child.stderr.on('data', data => {
    stderrBytes += data.length;
    if (stderrBytes > 4096) stop(new Error('Continuation host output exceeds limit.'));
    else stderr += data.toString('utf8');
  });
  child.stdin.on('error', failure => stop(new Error(`Continuation host input failed: ${failure.message}`)));
  child.on('error', failure => stop(new Error(`Continuation host failed: ${failure.message}`)));
  child.on('exit', (code, signal) => {
    exited = true;
    clearTimeout(killTimer);
    const failure = signalChild('SIGKILL');
    if (failure) setError(new Error(`Unable to clean continuation host process group: ${failure.message}`));
    if (!normalClose || code !== 0 || signal) {
      exitFailure = new Error(stderr || 'Continuation host exited unexpectedly.');
      // Cancel active runtime effects immediately, but allow a pending request
      // to consume an already-written structured policy error before rejecting.
      failureController.abort(exitFailure);
      if (!pending) setError(exitFailure);
    }
    if (error) rejectPending(error);
    // An escaped descendant can inherit the pipes after the host exits.
    if (!drainTimer) drainTimer = setTimeout(() => {
      setError(exitFailure || new Error('Continuation host output did not close.'));
      child.stdin.destroy(); child.stdout.destroy(); child.stderr.destroy(); child.unref(); finish();
    }, 1000);
  });
  child.on('close', () => {
    if (frameBytes) setError(new Error('Invalid continuation output.'));
    if (exitFailure) setError(exitFailure);
    finish();
  });
  function assertHealthy() { if (error) throw error; if (exitFailure) throw exitFailure; if (normalClose) throw new Error('Continuation host is closing.'); if (closed) throw new Error('Continuation host exited unexpectedly.'); }
  async function request(operation, payload, { deadline = Infinity, maxResponseBytes = 4096 } = {}) {
    assertHealthy();
    if (deadline !== Infinity && !Number.isFinite(deadline)) throw new Error('Invalid continuation deadline.');
    if (pending) throw new Error('Concurrent continuation requests are not supported.');
    const id = ++serial;
    if (!Number.isSafeInteger(id)) throw new Error('Continuation request identity overflow.');
    const encoded = JSON.stringify({ id, operation, payload });
    if (typeof maxResponseBytes === 'function') maxResponseBytes = maxResponseBytes(Buffer.byteLength(encoded) + 1);
    if (!Number.isSafeInteger(maxResponseBytes) || maxResponseBytes <= 0) throw new Error('Invalid continuation response budget.');
    const remaining = deadline - Date.now();
    if (remaining <= 0) throw new Error('Review deadline exhausted during continuation.');
    const packet = await new Promise((resolve, reject) => {
      const timer = setTimeout(() => stop(new Error('Review deadline exhausted during continuation.')), Math.min(22 * 60 * 1000, remaining));
      pending = { id, maxResponseBytes, timer, resolve, reject };
      try { child.stdin.write(encoded + '\n', failure => { if (failure) stop(new Error(`Continuation input failed: ${failure.message}`)); }); }
      catch (failure) { stop(new Error(`Continuation input failed: ${failure.message}`)); }
    });
    assertHealthy();
    if (Date.now() >= deadline) throw new Error('Review deadline exhausted during continuation.');
    return packet;
  }
  async function close() {
    if (exitFailure) setError(exitFailure);
    if (pending) stop(new Error('Continuation host closed during a request.'));
    if (!closed && !error && !normalClose) {
      normalClose = true;
      try { child.stdin.end(); } catch (failure) { stop(new Error(`Continuation host input failed: ${failure.message}`)); }
      if (!error) closeTimer = setTimeout(() => stop(new Error('Continuation host did not stop.')), 5000);
    }
    try {
      await closedPromise;
      if (error) throw error;
    } finally {
      process.removeListener('SIGTERM', onTerm); process.removeListener('SIGINT', onInt);
    }
  }
  return { request, assertHealthy, close, signal: failureController.signal };
}
// Derive bounds from observed bytes plus explicit generated-field cardinality.
// This is transport accounting, not an aggregate ledger/attempt-size policy.
const maxNumber = Number.MAX_SAFE_INTEGER;
const longestId = `thread:${maxNumber}`;
const ids = Array(8).fill(longestId);
const completeOverhead = Buffer.byteLength(JSON.stringify({ id: maxNumber, result: {
  attempt_id: maxNumber,
  accepted: ids.map(id => ({ id, status: 'complete', reasoning: '', findings: [], action: 'none' })),
  attempt: { assigned: ids, completed: ids, reason: '', pending: ids.map(id => ({ id, status: 'blocked', reasoning: '' })) },
  remaining: maxNumber, batch_limit: 8,
} })) + 2;
const finalTemplates = [
  ...Array.from({ length: 100 }, () => ({ type: 'create_pull_request_review_comment', path: '', line: maxNumber, body: '', side: 'RIGHT' })),
  ...Array.from({ length: 50 }, () => ({ type: 'reply_to_pull_request_review_comment', comment_id: maxNumber, body: '' })),
  ...['resolve', 'reopen'].flatMap(operation => Array.from({ length: 50 }, () => ({ type: 'unresolve_review_thread', operation, comment_id: maxNumber, reason: '' }))),
  { type: 'submit_pull_request_review', event: 'COMMENT', body: '' },
];
const finalOverhead = Buffer.byteLength(JSON.stringify({ id: maxNumber, result: finalTemplates })) + 2;
function checkedBudget(bytes, extra) {
  if (!Number.isSafeInteger(bytes) || bytes < 0) throw new Error('Invalid continuation byte accounting.');
  const budget = 6 * bytes + extra;
  if (!Number.isSafeInteger(budget) || budget <= 0) throw new Error('Continuation response budget overflow.');
  return budget;
}
function completeResponseBudget(requestBytes) { return checkedBudget(requestBytes, completeOverhead); }
function finalResponseBudget(completeWireBytes) {
  // The existing 60,000 UTF-8-byte summary limit permits up to six wire bytes
  // per summary byte when JSON escapes control characters/backslashes.
  return checkedBudget(completeWireBytes, 6 * 60000 + finalOverhead);
}
function addCompleteWireBytes(total, next) {
  if (!Number.isSafeInteger(total) || total < 0 || !Number.isSafeInteger(next) || next < 0 || !Number.isSafeInteger(total + next)) throw new Error('Continuation byte accounting overflow.');
  return total + next;
}
module.exports = { startContinuationSession, completeResponseBudget, finalResponseBudget, addCompleteWireBytes };
