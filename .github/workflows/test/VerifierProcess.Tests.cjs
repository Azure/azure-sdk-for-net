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
  const pidFile = path.join(root, 'pid'), termFile = path.join(root, 'term'), releaseFile = path.join(root, 'release'), ownerFile = path.join(root, 'owner'), startFile = path.join(root, 'start');
  const fake = path.join(root, 'fake-pwsh');
  fs.writeFileSync(fake, `#!/usr/bin/env node
    const fs = require('node:fs');
    if (['slow-pid', 'slow-owner'].includes(process.env.FAKE_MODE)) {
      const parent = Number(process.env.CONTROLLER_PID);
      if (!Number.isSafeInteger(parent) || parent <= 1) process.exit(1);
      const watchdog = setInterval(() => {
        try { process.kill(parent, 0); } catch (error) { if (error.code === 'ESRCH') process.exit(0); else throw error; }
      }, 10);
      watchdog.unref();
    }
    if (process.env.FAKE_MODE === 'slow-owner') {
      fs.writeFileSync(process.env.START_FILE + '.tmp', String(process.pid));
      fs.renameSync(process.env.START_FILE + '.tmp', process.env.START_FILE);
      process.stdin.resume(); setInterval(() => {}, 1000);
      return;
    }
    if (process.env.FAKE_MODE === 'slow-pid') {
      fs.writeFileSync(process.env.OWNER_FILE + '.tmp', String(process.pid));
      fs.renameSync(process.env.OWNER_FILE + '.tmp', process.env.OWNER_FILE);
    }
    function publishPid(pid) {
      const tmp = process.env.PID_FILE + '.tmp';
      fs.writeFileSync(tmp, '');
      const finish = () => { fs.writeFileSync(tmp, String(pid)); fs.renameSync(tmp, process.env.PID_FILE); };
      if (process.env.FAKE_MODE === 'slow-pid') {
        const timer = setInterval(() => { if (fs.existsSync(process.env.RELEASE_FILE)) { clearInterval(timer); finish(); } }, 10);
      } else finish();
    }
    if (process.env.FAKE_MODE === 'invalid') { process.stdout.write('invalid'); process.exit(0); }
    if (process.env.FAKE_MODE === 'error') { process.stderr.write('verifier failure'); process.exit(3); }
    if (process.env.FAKE_MODE === 'no-input') {
      process.on('SIGTERM', () => { fs.writeFileSync(process.env.TERM_FILE, 'term'); process.exit(0); });
      publishPid(process.pid); setInterval(() => {}, 1000);
      return;
    }
    if (process.env.FAKE_MODE === 'flood') {
      process.on('SIGTERM', () => {}); process.stdin.resume();
      setInterval(() => process.stdout.write('x'.repeat(8192)), 1);
      return;
    }
    if (['silent-success', 'silent-error'].includes(process.env.FAKE_MODE)) {
      const { spawn } = require('node:child_process');
      const descendant = spawn(process.execPath, ['-e', "process.send('ready');setInterval(()=>{},1000)"], { stdio: ['ignore', 'ignore', 'ignore', 'ipc'] });
      descendant.once('message', () => {
        publishPid(descendant.pid); descendant.disconnect();
        if (process.env.FAKE_MODE === 'silent-success') { process.stdout.write('{}'); process.exit(0); }
        else { process.stderr.write('verifier failure'); process.exit(3); }
      });
      return;
    }
    if (process.env.FAKE_MODE === 'silent-descendant') {
      const { spawn } = require('node:child_process');
      process.on('SIGTERM', () => process.exit(0));
      const descendant = spawn(process.execPath, ['-e', "process.on('SIGTERM',()=>{});process.send('ready');setInterval(()=>{},1000)"], { stdio: ['ignore', 'ignore', 'ignore', 'ipc'] });
      descendant.once('message', () => { publishPid(descendant.pid); descendant.disconnect(); });
      process.stdin.resume(); setInterval(() => {}, 1000);
      return;
    }
    if (['descendant', 'escaped'].includes(process.env.FAKE_MODE)) {
      const { spawn } = require('node:child_process');
      const descendant = spawn(process.execPath, ['-e', "process.on('SIGTERM',()=>{});setInterval(()=>{},1000)"], { detached: process.env.FAKE_MODE === 'escaped', stdio: ['ignore', 'inherit', 'inherit'] });
      publishPid(descendant.pid);
      process.exit(0);
    }
    process.on('SIGTERM', () => { fs.writeFileSync(process.env.TERM_FILE, 'term'); if (!['stubborn', 'timeout-stubborn'].includes(process.env.FAKE_MODE)) process.exit(0); });
    publishPid(process.pid);
    process.stdin.resume(); setInterval(() => {}, 1000);
  `, { mode: 0o755 });
  const entry = path.join(root, 'entry.cjs');
  fs.writeFileSync(entry, `
    process.env.CONTROLLER_PID = String(process.pid);
    if (process.env.FAKE_MODE === 'timeout-stubborn') {
      const originalTimeout = global.setTimeout;
      global.setTimeout = (fn, delay, ...args) => originalTimeout(fn, delay === 30000 ? 1000 : delay, ...args);
    }
    const { verifyDelivery } = require(${JSON.stringify(deliveryModule)});
    const snapshot = { head_sha: 'a'.repeat(40), base_sha: 'b'.repeat(40), ...(process.env.FAKE_MODE === 'no-input' ? { large: 'x'.repeat(8 * 1024 * 1024) } : {}) };
    verifyDelivery(snapshot, [], [], '1'.repeat(32), [], process.env.FAKE_MODE === 'short-deadline' ? { deadline: Date.now() + 500 } : undefined)
      .then(() => { if (process.env.FAKE_MODE === 'silent-success') { console.log('accepted'); process.exitCode = 0; } else { console.error('Unexpected success'); process.exitCode = 2; } })
      .catch(error => { console.log(error.message); process.exitCode = 1; });
  `);
  const child = spawn(process.execPath, [entry], {
    env: { ...process.env, GH_AW_REVIEW_PWSH: mode === 'missing' ? `${fake}-missing` : fake, FAKE_MODE: mode, PID_FILE: pidFile, TERM_FILE: termFile, RELEASE_FILE: releaseFile, OWNER_FILE: ownerFile, START_FILE: startFile },
    stdio: ['ignore', 'pipe', 'pipe'],
  });
  let cleanupPromise;
  const cleanup = () => cleanupPromise ??= (async () => {
    if (mode === 'slow-pid' && !fs.existsSync(releaseFile)) fs.writeFileSync(releaseFile, 'release');
    if (child.exitCode === null && child.signalCode === null) {
      const closed = once(child, 'close').catch(() => {});
      child.kill('SIGTERM');
      let timer;
      try { await Promise.race([closed, new Promise(resolve => { timer = setTimeout(resolve, 2500); })]); }
      finally { clearTimeout(timer); }
    }
    if (!['slow-pid', 'slow-owner'].includes(mode) && fs.existsSync(pidFile)) {
      const pid = Number(fs.readFileSync(pidFile, 'utf8'));
      if (Number.isSafeInteger(pid) && pid > 1) { try { process.kill(pid, 'SIGKILL'); } catch { /* exited */ } }
    }
    try { child.kill('SIGKILL'); } catch { /* exited */ }
    const marker = mode === 'slow-pid' ? ownerFile : mode === 'slow-owner' ? startFile : null;
    try {
      if (marker && fs.existsSync(marker)) {
        const pid = Number(fs.readFileSync(marker, 'utf8'));
        if (!Number.isSafeInteger(pid) || pid <= 1) throw new Error('Invalid verifier PID');
        await waitForProcessExit(pid);
      }
    } finally { fs.rmSync(root, { recursive: true, force: true }); }
  })();
  t.after(cleanup);
  return { child, pidFile, termFile, releaseFile, ownerFile, startFile, cleanup };
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

function linuxProcessState(stat) {
  const close = stat.lastIndexOf(')');
  if (close < 0 || !/^ [A-Za-z] /.test(stat.slice(close + 1))) throw new Error('Invalid process status');
  return stat[close + 2];
}

async function waitForProcessExit(pid) {
  const deadline = Date.now() + 2000;
  while (Date.now() < deadline) {
    try { process.kill(pid, 0); } catch (error) { if (error.code === 'ESRCH') return; throw error; }
    if (process.platform === 'linux') {
      try { if (linuxProcessState(fs.readFileSync(`/proc/${pid}/stat`, 'utf8')) === 'Z') return; }
      catch (error) {
        if (error.code !== 'ENOENT') throw error;
        try { process.kill(pid, 0); } catch (retry) { if (retry.code === 'ESRCH') return; throw retry; }
        throw error;
      }
    }
    await new Promise(resolve => setTimeout(resolve, 10));
  }
  throw new Error('A verifier process survived cleanup');
}

test('Linux process status uses the actual state, not the command name', () => {
  assert.equal(linuxProcessState('123 (odd) Z name) S 1 2 3'), 'S');
  assert.equal(linuxProcessState('123 (odd) Z name) Z 1 2 3'), 'Z');
  assert.throws(() => linuxProcessState('invalid'), /Invalid process status/);
});

test('PID readiness waits for a complete verifier PID', { skip: process.platform === 'win32', timeout: 12000 }, async t => {
  const { child, pidFile, releaseFile } = fixture(t, 'slow-pid');
  const closed = once(child, 'close');
  let settled = false, exitResult;
  const readiness = waitForFile(pidFile, child).then(() => { settled = true; });
  readiness.catch(() => {});
  try {
    await waitForFile(pidFile + '.tmp', child);
    await new Promise(resolve => setImmediate(resolve));
    assert.equal(fs.readFileSync(pidFile + '.tmp', 'utf8'), '');
    assert.equal(fs.existsSync(pidFile), false);
    assert.equal(settled, false);
    fs.writeFileSync(releaseFile, 'release');
    await readiness;
    assert.match(fs.readFileSync(pidFile, 'utf8'), /^[1-9][0-9]*$/);
  } finally {
    if (!fs.existsSync(releaseFile)) fs.writeFileSync(releaseFile, 'release');
    child.kill('SIGTERM');
    let timer;
    try { exitResult = await Promise.race([closed, new Promise((_, reject) => { timer = setTimeout(() => reject(new Error('Verifier did not stop')), 2500); })]); }
    finally { clearTimeout(timer); }
  }
  assert.equal(exitResult[0], 1);
});

test('cleanup terminates an unpublished verifier after the controller exits', { skip: process.platform === 'win32', timeout: 5000 }, async t => {
  const { child, pidFile, ownerFile, cleanup } = fixture(t, 'slow-pid');
  const closed = once(child, 'close');
  await waitForFile(pidFile + '.tmp', child);
  const ownerPid = Number(fs.readFileSync(ownerFile, 'utf8'));
  assert.ok(Number.isSafeInteger(ownerPid) && ownerPid > 1);
  child.kill('SIGKILL');
  await closed;
  await cleanup();
  await waitForProcessExit(ownerPid);
});

test('an unpublished verifier exits if its controller dies before PID ownership is recorded', { skip: process.platform === 'win32', timeout: 5000 }, async t => {
  const { child, ownerFile, startFile, cleanup } = fixture(t, 'slow-owner');
  const closed = once(child, 'close');
  await waitForFile(startFile, child);
  const pid = Number(fs.readFileSync(startFile, 'utf8'));
  assert.ok(Number.isSafeInteger(pid) && pid > 1);
  assert.equal(fs.existsSync(ownerFile), false);
  child.kill('SIGKILL');
  await closed;
  await waitForProcessExit(pid);
  await cleanup();
});

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

test('cancellation stays bounded when the verifier does not read a large input', { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { child, pidFile, termFile } = fixture(t, 'no-input');
  const closed = once(child, 'close');
  await waitForFile(pidFile, child);
  const pid = Number(fs.readFileSync(pidFile, 'utf8'));
  child.kill('SIGTERM');
  let timer;
  const [code] = await Promise.race([closed, new Promise((_, reject) => { timer = setTimeout(() => reject(new Error('Large-input cancellation did not finish promptly')), 2500); })]).finally(() => clearTimeout(timer));
  assert.equal(code, 1);
  assert.equal(fs.readFileSync(termFile, 'utf8'), 'term');
  assert.throws(() => process.kill(pid, 0), { code: 'ESRCH' });
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
