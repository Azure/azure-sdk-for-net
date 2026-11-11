'use strict';

// Define required history/patch inputs using the reader's JavaScript encoding,
// then invoke the PowerShell receipt verifier with bounded process supervision.
// The receipt directory is read-only to workers; each invocation has a fresh nonce.
const crypto = require('node:crypto');
const MAX_BATCH_BYTES = 48000;
const digest = value => crypto.createHash('sha256').update(value).digest('hex');
const snapshotDigest = snapshot => digest(JSON.stringify(snapshot));

function requiredInputs(snapshot, item) {
  if (item.thread) {
    const content = JSON.stringify(item.thread, null, 2);
    return [{ key: `history:${digest(content)}`, kind: 'history', content }];
  }
  const file = item.file;
  if (!file || typeof file.filename !== 'string') throw new Error('Invalid delivery assignment.');
  const result = [];
  if (file.patch !== undefined) {
    if (typeof file.patch !== 'string') throw new Error('Invalid captured patch.');
    if (Buffer.byteLength(file.patch) > MAX_BATCH_BYTES) result.push({ key: `patch:${digest(file.patch)}`, kind: 'patch', content: file.patch });
    // Otherwise the exact patch is embedded in the prompt by the controller.
  }
  // Source is read through GitHub MCP and is model-attested, not receipted.
  // Preserve malformed-rename and unsupported-omitted-patch validation.
  if (file.status === 'renamed' && (typeof file.previous_filename !== 'string' || !file.previous_filename)) throw new Error('Missing source path for delivery.');
  if (file.patch === undefined && !['added', 'modified', 'removed', 'renamed'].includes(file.status)) throw new Error('Unsupported file status for omitted patch delivery.');
  return result;
}

async function verifyDelivery(snapshot, batch, results, nonce, receipts, { deadline = Infinity } = {}) {
  if (!/^[a-f0-9]{32}$/.test(nonce) || !Array.isArray(receipts)) throw new Error('Invalid delivery evidence.');
  const completed = new Map(results.filter(result => result.status === 'complete').map(result => [result.id, result]));
  // Preserve the reader's JSON-derived hashes and JavaScript UTF-16 lengths.
  const items = batch.filter(item => completed.has(item.id)).map(item => ({
    id: item.id,
    required: requiredInputs(snapshot, item).map(req => ({ key: req.key, expectedLength: req.content !== undefined ? req.content.length : null })),
    tokens: completed.get(item.id).delivery_tokens || [],
  }));
  const payload = JSON.stringify({ nonce, snapshotHash: snapshotDigest(snapshot), items, receipts });
  if (deadline !== Infinity && !Number.isFinite(deadline)) throw new Error('Invalid delivery deadline.');
  const remaining = deadline - Date.now();
  if (remaining <= 0) throw new Error('Review deadline exhausted during delivery verification.');
  const timeoutMs = Math.min(30000, remaining);
  const timeoutReason = remaining <= 30000 ? 'Review deadline exhausted during delivery verification.' : 'Delivery verifier timed out.';
  await new Promise((resolve, reject) => {
    const { spawn } = require('node:child_process');
    const path = require('node:path');
    const child = spawn(process.env.GH_AW_REVIEW_PWSH || 'pwsh', [
      '-NoLogo', '-NoProfile', '-NonInteractive', '-File', path.join(__dirname, 'ReviewVerifyDelivery.ps1'),
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
    const onTerm = () => stop('Delivery verifier cancelled by SIGTERM.');
    const onInt = () => stop('Delivery verifier cancelled by SIGINT.');
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
      if (error) reject(error); else resolve();
    }
    child.stdout.on('data', data => {
      stdoutBytes += data.length;
      if (stdoutBytes > 4096) stop('Delivery verifier output exceeds limit.');
      else stdout.push(data);
    });
    child.stderr.on('data', data => {
      stderrBytes += data.length;
      if (stderrBytes > 4096) stop('Delivery verifier output exceeds limit.');
      else stderr.push(data);
    });
    child.stdin.on('error', () => {}); // The child may fail closed before consuming input.
    child.on('error', error => finish(error));
    child.on('close', (code, signal) => {
      // A verifier can exit with silent same-group descendants still alive,
      // even on success. Never leave the owned process group behind.
      const cleanupError = signalChild('SIGKILL');
      if (cleanupError) finish(new Error(`Unable to clean delivery verifier process group: ${cleanupError.message}`));
      else if (cancelled) finish(new Error(cancelled));
      else if (code !== 0 || signal || Buffer.concat(stdout).toString('utf8') !== '{}') finish(new Error(Buffer.concat(stderr).toString('utf8') || 'Delivery verifier failed.'));
      else finish();
    });
    child.stdin.end(payload);
  });
}
module.exports = { snapshotDigest, requiredInputs, verifyDelivery };
