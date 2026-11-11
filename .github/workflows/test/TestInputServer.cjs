'use strict';
// Exercise the actual PowerShell stdio backend from Node-based workflow tests.
const fs = require('node:fs');
const path = require('node:path');
const readline = require('node:readline');
const { spawn } = require('node:child_process');
const { exportContext } = require('../pr-re-review/ReviewSnapshot.cjs');

function createDelivery(t, snapshot, directory, { beforeStart = () => {} } = {}) {
  const context = path.join(directory, 'input');
  exportContext(snapshot, context);
  beforeStart(context);
  const child = spawn(process.env.GH_AW_REVIEW_PWSH || 'pwsh', ['-NoLogo', '-NoProfile', '-NonInteractive', '-File', path.join(__dirname, '..', 'pr-re-review', 'ReviewInputServer.ps1')], {
    env: { ...process.env, REVIEW_SNAPSHOT: path.join(context, 'snapshot.json'), REVIEW_RECEIPTS: directory }, stdio: ['pipe', 'pipe', 'pipe'],
  });
  const pending = new Map(), unexpected = []; let id = 0, stderr = '';
  child.stderr.on('data', chunk => { stderr += chunk; });
  readline.createInterface({ input: child.stdout }).on('line', line => {
    let message; try { message = JSON.parse(line); } catch (error) { for (const p of pending.values()) p.reject(error); pending.clear(); return; }
    const request = pending.get(message.id); if (!request) { unexpected.push(message); return; }
    pending.delete(message.id);
    if (message.error) request.reject(new Error(message.error.message)); else request.resolve(message.result);
  });
  child.on('error', error => { for (const p of pending.values()) p.reject(error); pending.clear(); });
  child.on('close', code => { for (const p of pending.values()) p.reject(new Error(`Input server exited ${code}: ${stderr}`)); pending.clear(); });
  t.after(() => child.kill());
  function raw(line, requestId, timeoutMs = 10000) {
    return new Promise((resolve, reject) => {
      const timeout = setTimeout(() => { pending.delete(requestId); child.kill(); reject(new Error('Input server request timed out.')); }, timeoutMs);
      pending.set(requestId, { resolve: value => { clearTimeout(timeout); resolve(value); }, reject: error => { clearTimeout(timeout); reject(error); } });
      child.stdin.write(line + '\n', error => { if (error) { const request = pending.get(requestId); pending.delete(requestId); if (request) request.reject(error); } });
    });
  }
  function handle(request) { const requestId = ++id; return raw(JSON.stringify({ ...request, id: requestId }), requestId); }
  function notify(request) { child.stdin.write(JSON.stringify(request) + '\n'); }
  return { handle, raw, notify, unexpected, page: async arguments_ => JSON.parse((await handle({ jsonrpc: '2.0', method: 'tools/call', params: { name: 'read-review-input', arguments: arguments_ } })).content[0].text) };
}
module.exports = { createDelivery };
