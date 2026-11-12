'use strict';

// A single trusted PowerShell selector remains alive for one review queue.
// This Node adapter owns process groups, cancellation and bounded stdio; no
// checkpoint or worker output is trusted as queue state.
const path = require('node:path');
const { spawn } = require('node:child_process');
const { TextDecoder } = require('node:util');

function startBatchSession({ maxItems, maxBytes }) {
  const child = spawn(process.env.GH_AW_REVIEW_PWSH || 'pwsh', [
    '-NoLogo', '-NoProfile', '-NonInteractive', '-File', path.join(__dirname, 'Select-ReviewBatch.ps1'), '-Stream',
  ], { stdio: ['pipe', 'pipe', 'pipe'], detached: process.platform !== 'win32' });
  let pending = null, serial = 0, error = null, stopping = false, exited = false, closed = false, normalClose = false;
  const failureController = new AbortController();
  let buffer = Buffer.alloc(0), stderr = '', stderrBytes = 0, killTimer, drainTimer, closeTimer;
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
  const onTerm = () => stop(new Error('Batch selection cancelled by SIGTERM.'));
  const onInt = () => stop(new Error('Batch selection cancelled by SIGINT.'));
  process.on('SIGTERM', onTerm); process.on('SIGINT', onInt);
  child.stdout.on('data', data => {
    if (stopping || closed || data.length === 0) return;
    if (!pending) { stop(new Error('Unexpected batch selection output.')); return; }
    if (data.length > 4096 - buffer.length) { buffer = Buffer.alloc(0); stop(new Error('Batch selection output exceeds limit.')); return; }
    buffer = Buffer.concat([buffer, data]);
    const end = buffer.indexOf(10);
    if (end < 0) return;
    // There is only one outstanding request. Even a partial second frame is
    // unsolicited and must not be reinterpreted after the next request starts.
    if (end !== buffer.length - 1) { stop(new Error('Unexpected batch selection output.')); return; }
    let line;
    try { line = decoder.decode(buffer.subarray(0, end)); }
    catch { stop(new Error('Invalid batch selection UTF-8 output.')); return; }
    buffer = Buffer.alloc(0);
    let message; try { message = JSON.parse(line); } catch { stop(new Error('Invalid batch selection output.')); return; }
    const count = message?.count;
    if (!message || typeof message !== 'object' || Array.isArray(message) || Object.keys(message).length !== 2 || message.id !== pending.id ||
        !Number.isSafeInteger(count) || count < (pending.length ? 1 : 0) || count > Math.min(maxItems, pending.length)) {
      stop(new Error('Invalid batch selection output.')); return;
    }
    const request = pending; pending = null; clearTimeout(request.timer); request.resolve(count);
  });
  child.stdout.on('end', () => {
    if (buffer.length) stop(new Error('Invalid batch selection output at EOF.'));
    else if (!normalClose) stop(new Error('Batch selector stdout closed unexpectedly.'));
  });
  child.stdout.on('error', failure => stop(new Error(`Batch selection output failed: ${failure.message}`)));
  child.stderr.on('error', failure => stop(new Error(`Batch selection error stream failed: ${failure.message}`)));
  child.stderr.on('data', data => {
    stderrBytes += data.length;
    if (stderrBytes > 4096) stop(new Error('Batch selection output exceeds limit.'));
    else stderr += data.toString('utf8');
  });
  child.stdin.on('error', failure => stop(new Error(`Batch selection input failed: ${failure.message}`)));
  child.on('error', failure => stop(new Error(`Batch selection failed: ${failure.message}`)));
  child.on('exit', (code, signal) => {
    exited = true;
    clearTimeout(killTimer);
    const failure = signalChild('SIGKILL');
    if (failure) setError(new Error(`Unable to clean batch selector process group: ${failure.message}`));
    if (!normalClose || code !== 0 || signal) setError(new Error(stderr || 'Batch selector exited unexpectedly.'));
    if (error) rejectPending(error);
    // An escaped descendant can inherit the pipes after the selector exits.
    if (!drainTimer) drainTimer = setTimeout(() => {
      setError(new Error('Batch selector output did not close.'));
      child.stdin.destroy(); child.stdout.destroy(); child.stderr.destroy(); child.unref(); finish();
    }, 1000);
  });
  child.on('close', () => {
    if (buffer.length) setError(new Error('Invalid batch selection output.'));
    finish();
  });
  function assertHealthy() { if (error) throw error; if (closed) throw new Error('Batch selector exited unexpectedly.'); }
  async function select(work, deadline = Infinity) {
    assertHealthy();
    if (!Array.isArray(work)) throw new Error('Invalid batch worklist.');
    if (deadline !== Infinity && !Number.isFinite(deadline)) throw new Error('Invalid batch selection deadline.');
    if (pending) throw new Error('Concurrent batch selection is not supported.');
    const id = ++serial;
    const payload = JSON.stringify({ id, work: work.slice(0, maxItems + 1), maxItems, maxBytes });
    const remaining = deadline - Date.now();
    if (remaining <= 0) throw new Error('Review deadline exhausted during batch selection.');
    const count = await new Promise((resolve, reject) => {
      const timer = setTimeout(() => stop(new Error('Review deadline exhausted during batch selection.')), Math.min(22 * 60 * 1000, remaining));
      pending = { id, length: work.length, timer, resolve, reject };
      try { child.stdin.write(payload + '\n', failure => { if (failure) stop(new Error(`Batch selection input failed: ${failure.message}`)); }); }
      catch (failure) { stop(new Error(`Batch selection input failed: ${failure.message}`)); }
    });
    assertHealthy();
    if (Date.now() >= deadline) throw new Error('Review deadline exhausted during batch selection.');
    return work.slice(0, count);
  }
  async function close() {
    if (pending) stop(new Error('Batch selector closed during a request.'));
    if (!closed && !error && !normalClose) {
      normalClose = true;
      try { child.stdin.end(); } catch (failure) { stop(new Error(`Batch selection input failed: ${failure.message}`)); }
      if (!error) closeTimer = setTimeout(() => stop(new Error('Batch selector did not stop.')), 5000);
    }
    try {
      await closedPromise;
      if (error) throw error;
    } finally {
      process.removeListener('SIGTERM', onTerm); process.removeListener('SIGINT', onInt);
    }
  }
  return { select, assertHealthy, close, signal: failureController.signal };
}
module.exports = { startBatchSession };
