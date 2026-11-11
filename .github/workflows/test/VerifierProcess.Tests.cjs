'use strict';
const assert = require('node:assert/strict');
const { test } = require('node:test');
const fs = require('node:fs');
const os = require('node:os');
const path = require('node:path');
const { spawn } = require('node:child_process');
const { once } = require('node:events');

const deliveryModule = path.join(__dirname, '..', 'pr-re-review', 'ReviewDelivery.cjs');

function fixture(t, mode) {
  const root = fs.mkdtempSync(path.join(os.tmpdir(), 'review-verifier-'));
  const pidFile = path.join(root, 'pid'), termFile = path.join(root, 'term');
  const fake = path.join(root, 'fake-pwsh');
  fs.writeFileSync(fake, `#!/usr/bin/env node
    const fs = require('node:fs');
    if (process.env.FAKE_MODE === 'invalid') { process.stdout.write('invalid'); process.exit(0); }
    if (process.env.FAKE_MODE === 'error') { process.stderr.write('verifier failure'); process.exit(3); }
    if (process.env.FAKE_MODE === 'flood') {
      process.on('SIGTERM', () => {}); process.stdin.resume();
      setInterval(() => process.stdout.write('x'.repeat(8192)), 1);
      return;
    }
    if (['silent-success', 'silent-error'].includes(process.env.FAKE_MODE)) {
      const { spawn } = require('node:child_process');
      const descendant = spawn(process.execPath, ['-e', "process.send('ready');setInterval(()=>{},1000)"], { stdio: ['ignore', 'ignore', 'ignore', 'ipc'] });
      descendant.once('message', () => {
        fs.writeFileSync(process.env.PID_FILE, String(descendant.pid)); descendant.disconnect();
        if (process.env.FAKE_MODE === 'silent-success') { process.stdout.write('{}'); process.exit(0); }
        else { process.stderr.write('verifier failure'); process.exit(3); }
      });
      return;
    }
    if (process.env.FAKE_MODE === 'silent-descendant') {
      const { spawn } = require('node:child_process');
      process.on('SIGTERM', () => process.exit(0));
      const descendant = spawn(process.execPath, ['-e', "process.on('SIGTERM',()=>{});process.send('ready');setInterval(()=>{},1000)"], { stdio: ['ignore', 'ignore', 'ignore', 'ipc'] });
      descendant.once('message', () => { fs.writeFileSync(process.env.PID_FILE, String(descendant.pid)); descendant.disconnect(); });
      process.stdin.resume(); setInterval(() => {}, 1000);
      return;
    }
    if (['descendant', 'escaped'].includes(process.env.FAKE_MODE)) {
      const { spawn } = require('node:child_process');
      const descendant = spawn(process.execPath, ['-e', "process.on('SIGTERM',()=>{});setInterval(()=>{},1000)"], { detached: process.env.FAKE_MODE === 'escaped', stdio: ['ignore', 'inherit', 'inherit'] });
      fs.writeFileSync(process.env.PID_FILE, String(descendant.pid));
      process.exit(0);
    }
    process.on('SIGTERM', () => { fs.writeFileSync(process.env.TERM_FILE, 'term'); if (!['stubborn', 'timeout-stubborn'].includes(process.env.FAKE_MODE)) process.exit(0); });
    fs.writeFileSync(process.env.PID_FILE, String(process.pid));
    process.stdin.resume(); setInterval(() => {}, 1000);
  `, { mode: 0o755 });
  const entry = path.join(root, 'entry.cjs');
  fs.writeFileSync(entry, `
    if (process.env.FAKE_MODE === 'timeout-stubborn') {
      const originalTimeout = global.setTimeout;
      global.setTimeout = (fn, delay, ...args) => originalTimeout(fn, delay === 30000 ? 1000 : delay, ...args);
    }
    const { verifyDelivery } = require(${JSON.stringify(deliveryModule)});
    verifyDelivery({ head_sha: 'a'.repeat(40), base_sha: 'b'.repeat(40) }, [], [], '1'.repeat(32), [], process.env.FAKE_MODE === 'short-deadline' ? { deadline: Date.now() + 500 } : undefined)
      .then(() => { if (process.env.FAKE_MODE === 'silent-success') { console.log('accepted'); process.exitCode = 0; } else { console.error('Unexpected success'); process.exitCode = 2; } })
      .catch(error => { console.log(error.message); process.exitCode = 1; });
  `);
  const child = spawn(process.execPath, [entry], {
    env: { ...process.env, GH_AW_REVIEW_PWSH: mode === 'missing' ? `${fake}-missing` : fake, FAKE_MODE: mode, PID_FILE: pidFile, TERM_FILE: termFile },
    stdio: ['ignore', 'pipe', 'pipe'],
  });
  t.after(() => {
    if (fs.existsSync(pidFile)) { try { process.kill(Number(fs.readFileSync(pidFile, 'utf8')), 'SIGKILL'); } catch { /* exited */ } }
    try { child.kill('SIGKILL'); } catch { /* exited */ }
    fs.rmSync(root, { recursive: true, force: true });
  });
  return { child, pidFile, termFile };
}

async function waitForFile(filename, child) {
  if (fs.existsSync(filename)) return;
  await new Promise((resolve, reject) => {
    const watcher = fs.watch(path.dirname(filename), () => { if (fs.existsSync(filename)) finish(); });
    const timer = setTimeout(() => finish(new Error('Verifier did not start')), 5000);
    const onExit = () => finish(new Error('Controller exited before verifier startup'));
    function finish(error) { watcher.close(); clearTimeout(timer); child.removeListener('exit', onExit); error ? reject(error) : resolve(); }
    child.once('exit', onExit);
    if (fs.existsSync(filename)) finish();
  });
}

async function waitForProcessExit(pid) {
  const deadline = Date.now() + 2000;
  while (Date.now() < deadline) {
    try {
      process.kill(pid, 0);
      if (process.platform === 'linux' && /\) Z /.test(fs.readFileSync(`/proc/${pid}/stat`, 'utf8'))) return;
    } catch { return; }
    await new Promise(resolve => setTimeout(resolve, 10));
  }
  throw new Error('A same-group descendant survived verifier exit');
}

for (const mode of ['normal', 'stubborn']) {
  for (const signal of ['SIGTERM', 'SIGINT']) {
    test(`verifier ${signal} terminates ${mode} child and fails closed`, { skip: process.platform === 'win32', timeout: 10000 }, async t => {
      const { child, pidFile, termFile } = fixture(t, mode);
      let stdout = '';
      child.stdout.on('data', data => { stdout += data; });
      const closed = once(child, 'close');
      await waitForFile(pidFile, child);
      const pid = Number(fs.readFileSync(pidFile, 'utf8'));
      child.kill(signal);
      const [code] = await closed;
      assert.equal(code, 1);
      assert.match(stdout, new RegExp(`cancelled by ${signal}`));
      assert.equal(fs.readFileSync(termFile, 'utf8'), 'term');
      assert.throws(() => process.kill(pid, 0), { code: 'ESRCH' });
    });
  }
}

for (const mode of ['descendant', 'escaped']) test(`cancellation remains bounded when a ${mode} inherits verifier pipes`, { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { child, pidFile } = fixture(t, mode);
  let stdout = '';
  child.stdout.on('data', data => { stdout += data; });
  const closed = once(child, 'close');
  await waitForFile(pidFile, child);
  child.kill('SIGTERM');
  let timer;
  const result = await Promise.race([
    closed,
    new Promise((_, reject) => { timer = setTimeout(() => reject(new Error('Verifier cancellation did not finish promptly')), 2500); }),
  ]).finally(() => clearTimeout(timer));
  assert.equal(result[0], 1);
  assert.match(stdout, /cancelled by SIGTERM/);
});

test('verifier timeout terminates a stubborn subprocess and fails closed', { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { child, pidFile, termFile } = fixture(t, 'timeout-stubborn');
  let stdout = '';
  child.stdout.on('data', data => { stdout += data; });
  const closed = once(child, 'close');
  await waitForFile(pidFile, child);
  const pid = Number(fs.readFileSync(pidFile, 'utf8'));
  const [code] = await closed;
  assert.equal(code, 1);
  assert.match(stdout, /verifier timed out/i);
  assert.equal(fs.readFileSync(termFile, 'utf8'), 'term');
  assert.throws(() => process.kill(pid, 0), { code: 'ESRCH' });
});

test('verifier respects the caller deadline', { skip: process.platform === 'win32', timeout: 5000 }, async t => {
  const { child, pidFile } = fixture(t, 'short-deadline');
  let stdout = '';
  child.stdout.on('data', data => { stdout += data; });
  const closed = once(child, 'close');
  await waitForFile(pidFile, child);
  let timer;
  const [code] = await Promise.race([closed, new Promise((_, reject) => { timer = setTimeout(() => reject(new Error('Verifier ignored caller deadline')), 2500); })]).finally(() => clearTimeout(timer));
  assert.equal(code, 1);
  assert.match(stdout, /deadline/i);
});

test('cancellation cleans a silent same-group descendant', { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { child, pidFile } = fixture(t, 'silent-descendant');
  const closed = once(child, 'close');
  await waitForFile(pidFile, child);
  const pid = Number(fs.readFileSync(pidFile, 'utf8'));
  child.kill('SIGTERM');
  const [code] = await closed;
  assert.equal(code, 1);
  await waitForProcessExit(pid);
  fs.unlinkSync(pidFile);
});

for (const mode of ['silent-success', 'silent-error']) test(`verifier ${mode} cleans silent descendants`, { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { child, pidFile } = fixture(t, mode);
  const closed = once(child, 'close');
  await waitForFile(pidFile, child);
  const pid = Number(fs.readFileSync(pidFile, 'utf8'));
  const [code] = await closed;
  assert.equal(code, mode === 'silent-success' ? 0 : 1);
  await waitForProcessExit(pid);
  fs.unlinkSync(pidFile);
});

for (const mode of ['invalid', 'error', 'missing', 'flood']) {
  test(`verifier rejects ${mode} subprocess output`, { skip: process.platform === 'win32', timeout: 10000 }, async t => {
    const { child } = fixture(t, mode);
    let stdout = '';
    child.stdout.on('data', data => { stdout += data; });
    const [code] = await once(child, 'close');
    assert.equal(code, 1);
    assert.match(stdout, mode === 'invalid' ? /verifier failed/i : mode === 'missing' ? /ENOENT/ : mode === 'flood' ? /output exceeds limit/i : /verifier failure/i);
  });
}
