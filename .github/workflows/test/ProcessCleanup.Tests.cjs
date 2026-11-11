'use strict';
const assert = require('node:assert/strict');
const { test } = require('node:test');
const fs = require('node:fs');
const os = require('node:os');
const path = require('node:path');
const { spawn } = require('node:child_process');
const { once, EventEmitter } = require('node:events');

const actions = process.env.GH_AW_TEST_ACTIONS_DIR;
assert.ok(actions, 'Pinned process runner required.');
const controllerModule = path.join(__dirname, '..', 'pr-re-review', 'ReviewContinuation.cjs');
const { runProcess } = require(controllerModule);

function alive(pid) {
  try {
    process.kill(pid, 0);
    // An orphan killed by test cleanup can briefly remain as a zombie under
    // PID 1; it is not an executing CLI.
    if (process.platform === 'linux' && /\) Z /.test(fs.readFileSync(`/proc/${pid}/stat`, 'utf8'))) return false;
    return true;
  } catch { return false; }
}
function kill(pid) { if (pid) { try { process.kill(-pid, 'SIGKILL'); } catch { /* already stopped */ } } }
async function waitForFile(filename, child) {
  const ready = () => {
    try {
      const value = fs.readFileSync(filename, 'utf8');
      return /^[1-9][0-9]*$/.test(value) && Number.isSafeInteger(Number(value));
    } catch (error) {
      if (error.code === 'ENOENT') return false;
      throw error;
    }
  };
  if (ready()) return;
  await new Promise((resolve, reject) => {
    let finished = false;
    const watcher = fs.watch(path.dirname(filename), () => { try { if (ready()) finish(); } catch (error) { finish(error); } });
    const timer = setTimeout(() => finish(new Error('CLI did not become ready')), 10000);
    const onExit = () => finish(new Error('Controller exited before CLI startup'));
    function finish(error) {
      if (finished) return;
      finished = true; watcher.close(); clearTimeout(timer); child.removeListener('exit', onExit);
      error ? reject(error) : resolve();
    }
    child.once('exit', onExit);
    try { if (ready()) finish(); } catch (error) { finish(error); }
  });
}

test('does not treat an empty PID file as a ready CLI', { skip: process.platform === 'win32', timeout: 10000 }, async t => {
  const root = fs.mkdtempSync(path.join(os.tmpdir(), 'review-ready-'));
  const pidFile = path.join(root, 'pid');
  const child = new EventEmitter();
  t.after(() => { child.emit('exit'); fs.rmSync(root, { recursive: true, force: true }); });
  fs.writeFileSync(pidFile, '');
  let settled = false;
  const ready = waitForFile(pidFile, child).then(() => { settled = true; });
  await new Promise(resolve => setImmediate(resolve));
  assert.equal(settled, false, 'An empty PID file must not signal readiness');
  fs.writeFileSync(pidFile, String(process.pid));
  await ready;
});

test('escalates to SIGKILL after bounded grace when the owned harness ignores TERM', { skip: process.platform === 'win32', timeout: 20000 }, async t => {
  const root=fs.mkdtempSync(path.join(os.tmpdir(),'review-escalation-'));
  t.after(()=>{if(fs.existsSync(path.join(root,'pid')))kill(Number(fs.readFileSync(path.join(root,'pid'),'utf8')));fs.rmSync(root,{recursive:true,force:true});});
  const harness=path.join(root,'stubborn.cjs');
  fs.writeFileSync(harness, `const fs=require('node:fs');fs.writeFileSync(${JSON.stringify(path.join(root,'pid'))},String(process.pid));process.on('SIGTERM',()=>fs.writeFileSync(${JSON.stringify(path.join(root,'term'))},'seen'));setInterval(()=>{},1000);`);
  await assert.rejects(runProcess(process.execPath,[harness],{deadline:Date.now()+1000,outputFile:path.join(root,'execution.log')}),/deadline/);
  assert.ok(fs.existsSync(path.join(root,'term')),'TERM must precede forced termination');
  assert.equal(alive(Number(fs.readFileSync(path.join(root,'pid'),'utf8'))),false);
});

for (const mode of ['deadline', 'SIGTERM', 'SIGINT']) {
  test(`controller ${mode} lets the pinned runner clean its separately detached CLI`, { skip: process.platform === 'win32', timeout: 20000 }, async t => {
    const root = fs.mkdtempSync(path.join(os.tmpdir(), 'review-cleanup-'));
    let controller;
    t.after(() => {
      for (const name of ['cli.pid', 'harness.pid']) if (fs.existsSync(path.join(root, name))) kill(Number(fs.readFileSync(path.join(root, name), 'utf8')));
      kill(controller?.pid);
      fs.rmSync(root, { recursive: true, force: true });
    });
    const cli = path.join(root, 'fake-cli.cjs');
    fs.writeFileSync(cli, `const fs=require('node:fs');const pidFile=${JSON.stringify(path.join(root, 'cli.pid'))};process.on('SIGTERM',()=>{fs.writeFileSync(${JSON.stringify(path.join(root, 'term.receipt'))},'SIGTERM');process.exit(0)});fs.writeFileSync(pidFile+'.tmp',String(process.pid));fs.renameSync(pidFile+'.tmp',pidFile);setInterval(()=>{},1000);`);
    const harness = path.join(root, 'harness.cjs');
    fs.writeFileSync(harness, `const fs=require('node:fs');fs.writeFileSync(${JSON.stringify(path.join(root, 'harness.pid'))},String(process.pid));const {runProcess}=require(${JSON.stringify(path.join(actions, 'process_runner.cjs'))});runProcess({command:process.execPath,args:[${JSON.stringify(cli)}],attempt:0,log:()=>{}}).then(result=>{process.exitCode=result.exitCode;});`);
    const entry = path.join(root, 'controller.cjs');
    fs.writeFileSync(entry, `const fs=require('node:fs');const {runProcess}=require(${JSON.stringify(controllerModule)});runProcess(process.execPath,[${JSON.stringify(harness)}],{deadline:Date.now()+${mode === 'deadline' ? 2000 : 15000},outputFile:${JSON.stringify(path.join(root, 'execution.log'))}}).then(()=>{throw new Error('Unexpected successful run')}).catch(error=>{fs.writeFileSync(${JSON.stringify(path.join(root, 'result.json'))},JSON.stringify({error:error.message}));});`);
    controller = spawn(process.execPath, [entry], { detached: true, stdio: ['ignore', 'pipe', 'pipe'] });
    const closed = once(controller, 'close');
    await waitForFile(path.join(root, 'cli.pid'), controller);
    const cliPid = Number(fs.readFileSync(path.join(root, 'cli.pid'), 'utf8'));
    assert.ok(alive(cliPid), 'Fake CLI must actually start');
    if (mode !== 'deadline') controller.kill(mode);
    await closed;
    const result = JSON.parse(fs.readFileSync(path.join(root, 'result.json'), 'utf8'));
    assert.match(result.error, mode === 'deadline' ? /deadline/ : /cancelled/);
    assert.equal(alive(cliPid), false, 'Controller returned while the separately detached CLI was still executing');
    assert.equal(fs.readFileSync(path.join(root, 'term.receipt'), 'utf8'), 'SIGTERM', 'Upstream cancellation handler must forward TERM to its CLI');
  });
}
