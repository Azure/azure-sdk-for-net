'use strict';

// Supply the canonical snapshot hash and shared batch limit, then invoke the
// PowerShell receipt verifier with bounded process supervision.
// The receipt directory is read-only to workers; each invocation has a fresh nonce.
const crypto = require('node:crypto');
// Keep batch sizing and the threshold for receipt-backed offloading aligned.
const MAX_BATCH_BYTES = 48000;
const digest = value => crypto.createHash('sha256').update(value).digest('hex');
const snapshotDigest = snapshot => digest(JSON.stringify(snapshot));

async function verifyDelivery(snapshot, batch, results, nonce, receipts, { deadline = Infinity } = {}) {
  if (!/^[a-f0-9]{32}$/.test(nonce) || !Array.isArray(receipts)) throw new Error('Invalid delivery evidence.');
  // Preserve the compact JSON.stringify representation for independent
  // PowerShell recomputation of snapshot and required-input identities.
  const payload = JSON.stringify({ snapshot, batch, results, nonce, receipts, maxBatchBytes: MAX_BATCH_BYTES });
  if (deadline !== Infinity && !Number.isFinite(deadline)) throw new Error('Invalid delivery deadline.');
  const remaining = deadline - Date.now();
  if (remaining <= 0) throw new Error('Review deadline exhausted during delivery verification.');
  const timeoutMs = Math.min(30000, remaining);
  const timeoutReason = remaining <= 30000 ? 'Review deadline exhausted during delivery verification.' : 'Delivery verifier timed out.';
  const result = await runPowerShell('ReviewVerifyDelivery.ps1', payload, { timeoutMs, timeoutReason, maxOutputBytes: 4096, label: 'Delivery verifier' });
  if (result.stdout !== '{}') throw new Error(result.stderr || 'Delivery verifier failed.');
}

// The pinned gh-aw integration requires Node. Share one process supervisor for
// capture and verification so cancellation, limits, and process-group cleanup
// do not depend on PowerShell signal callbacks.
async function runPowerShell(script, payload, { timeoutMs, timeoutReason, maxOutputBytes, label, scriptArgs = [] }) {
  return await new Promise((resolve, reject) => {
    const { spawn } = require('node:child_process');
    const path = require('node:path');
    const child = spawn(process.env.GH_AW_REVIEW_PWSH || 'pwsh', [
      '-NoLogo', '-NoProfile', '-NonInteractive', '-File', path.join(__dirname, script), ...scriptArgs,
    ], { stdio: ['pipe', 'pipe', 'pipe'], detached: process.platform !== 'win32' });
    const stdout = [], stderr = [];
    let stdoutBytes = 0, stderrBytes = 0, cancelled, finished = false, killTimer, drainTimer;
    const timeout = setTimeout(() => stop(timeoutReason), timeoutMs);
    function signalChild(signal) {
      try {
        if (process.platform !== 'win32' && child.pid) process.kill(-child.pid, signal);
        else child.kill(signal);
      } catch (error) {
        if (error.code !== 'ESRCH') return error;
      }
      return null;
    }
    function stop(reason) {
      if (cancelled) return;
      cancelled = reason;
      const termError = signalChild('SIGTERM');
      if (termError) cancelled += ` (unable to send SIGTERM: ${termError.message})`;
      killTimer = setTimeout(() => {
        const killError = signalChild('SIGKILL');
        if (killError) cancelled += ` (unable to send SIGKILL: ${killError.message})`;
        // A descendant can escape the group and keep a pipe open. Do not let
        // that suppress cancellation or a deadline indefinitely.
        drainTimer = setTimeout(() => {
          child.stdin.destroy(); child.stdout.destroy(); child.stderr.destroy();
          child.unref();
          finish(new Error(cancelled));
        }, 1000);
      }, 1000);
    }
    const onTerm = () => stop(`${label} cancelled by SIGTERM.`);
    const onInt = () => stop(`${label} cancelled by SIGINT.`);
    process.on('SIGTERM', onTerm);
    process.on('SIGINT', onInt);
    function finish(error) {
      if (finished) return;
      finished = true;
      clearTimeout(timeout);
      clearTimeout(killTimer);
      clearTimeout(drainTimer);
      process.removeListener('SIGTERM', onTerm);
      process.removeListener('SIGINT', onInt);
      if (error) reject(error); else resolve({ stdout: Buffer.concat(stdout).toString('utf8'), stderr: Buffer.concat(stderr).toString('utf8') });
    }
    child.stdout.on('data', data => {
      stdoutBytes += data.length;
      if (stdoutBytes > maxOutputBytes) stop(`${label} output exceeds limit.`);
      else stdout.push(data);
    });
    child.stderr.on('data', data => {
      stderrBytes += data.length;
      if (stderrBytes > maxOutputBytes) stop(`${label} output exceeds limit.`);
      else stderr.push(data);
    });
    child.stdin.on('error', () => {}); // The child may fail closed before consuming input.
    child.on('error', error => finish(error));
    child.on('close', (code, signal) => {
      // The child can exit with silent same-group descendants still alive,
      // even on success. Never leave the owned process group behind.
      const cleanupError = signalChild('SIGKILL');
      if (cleanupError) finish(new Error(`Unable to clean ${label.toLowerCase()} process group: ${cleanupError.message}`));
      else if (cancelled) finish(new Error(cancelled));
      else if (code !== 0 || signal) finish(new Error(Buffer.concat(stderr).toString('utf8') || `${label} failed.`));
      else finish();
    });
    child.stdin.end(payload);
  });
}
module.exports = { MAX_BATCH_BYTES, snapshotDigest, verifyDelivery, runPowerShell };
