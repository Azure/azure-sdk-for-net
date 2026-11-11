'use strict';
const assert = require('node:assert/strict');
const { test } = require('node:test');
const fs = require('node:fs');
const os = require('node:os');
const path = require('node:path');
const { captureContext, exportContext } = require('../pr-re-review/ReviewSnapshot.cjs');

async function waitForFile(file) {
  const deadline = Date.now() + 5000;
  while (Date.now() < deadline) { if (fs.existsSync(file)) return; await new Promise(resolve => setTimeout(resolve, 10)); }
  throw new Error('Capture fixture did not become ready');
}
async function waitForExit(pid) {
  const deadline = Date.now() + 2000;
  while (Date.now() < deadline) {
    try { process.kill(pid, 0); } catch (error) { if (error.code === 'ESRCH') return; throw error; }
    if (process.platform === 'linux') {
      try { const stat = fs.readFileSync(`/proc/${pid}/stat`, 'utf8'); const close = stat.lastIndexOf(')'); if (close >= 0 && stat[close + 2] === 'Z') return; }
      catch (error) { if (error.code !== 'ENOENT') throw error; }
    }
    await new Promise(resolve => setTimeout(resolve, 10));
  }
  throw new Error('Capture fixture survived cancellation');
}

function fixture(t) {
  const dir = fs.mkdtempSync(path.join(os.tmpdir(), 'delivery-capture-'));
  const executable = path.join(dir, 'fake-pwsh'), pidsFile = path.join(dir, 'pids'), termFile = path.join(dir, 'term');
  const previous = process.env.GH_AW_REVIEW_PWSH;
  t.after(() => {
    if (previous === undefined) delete process.env.GH_AW_REVIEW_PWSH; else process.env.GH_AW_REVIEW_PWSH = previous;
    if (fs.existsSync(pidsFile)) for (const pid of JSON.parse(fs.readFileSync(pidsFile, 'utf8'))) if (Number.isSafeInteger(pid) && pid > 1) { try { process.kill(pid, 'SIGKILL'); } catch { /* exited */ } }
    fs.rmSync(dir, { recursive: true, force: true });
  });
  fs.writeFileSync(executable, `#!/usr/bin/env node\nconst fs=require('node:fs'),{spawn}=require('node:child_process');process.on('SIGTERM',()=>fs.writeFileSync(${JSON.stringify(termFile)},'term'));const child=spawn(process.execPath,['-e',"process.on('SIGTERM',()=>{});process.send('ready');setInterval(()=>{},1000)"],{stdio:['ignore','ignore','ignore','ipc']});child.once('message',()=>{fs.writeFileSync(${JSON.stringify(pidsFile + '.tmp')},JSON.stringify([process.pid,child.pid]));fs.renameSync(${JSON.stringify(pidsFile + '.tmp')},${JSON.stringify(pidsFile)});child.disconnect();});process.stdin.resume();setInterval(()=>{},1000);`, { mode: 0o755 });
  process.env.GH_AW_REVIEW_PWSH = executable;
  return { dir, pidsFile, termFile };
}

test('capture timeout terminates a stubborn exporter and its process group', { skip: process.platform === 'win32', timeout: 10000 }, async t => {
  const { dir, pidsFile, termFile } = fixture(t);
  const start = Date.now();
  const capture = exportContext({ files: [], threads: [], reviews: [] }, path.join(dir, 'input'), { timeoutMs: 3000 });
  await waitForFile(pidsFile);
  const pids = JSON.parse(fs.readFileSync(pidsFile, 'utf8'));
  await assert.rejects(capture, /capture timed out/i);
  assert.ok(Date.now() - start < 6000, 'capture cancellation must be bounded');
  assert.equal(fs.readFileSync(termFile, 'utf8'), 'term');
  for (const pid of pids) await waitForExit(pid);
  fs.unlinkSync(pidsFile);
  assert.equal(fs.existsSync(path.join(dir, 'input', 'delivery-index.json')), false);
});

test('baseline capture timeout terminates a stubborn exporter and its process group', { skip: process.platform === 'win32', timeout: 10000 }, async t => {
  const { dir, pidsFile, termFile } = fixture(t);
  const head = 'a'.repeat(40), base = 'b'.repeat(40);
  const pull = { state:'open', draft:false, head:{sha:head,repo:{full_name:'A/B'}}, base:{sha:base,repo:{full_name:'A/B'}}, changed_files:0 };
  const github = {
    request: async () => ({ data:{base_commit:{sha:base},merge_base_commit:{sha:base}} }),
    rest: { pulls:{ get:async()=>({data:pull}), listReviews:()=>{} } },
    paginate: async()=>[], graphql: async()=>({repository:{pullRequest:{reviewThreads:{totalCount:0,nodes:[],pageInfo:{hasNextPage:false,endCursor:null}}}}}),
  };
  const started = Date.now();
  const capture = captureContext(github, {owner:'A',repo:'B'}, {pull_number:1,head_sha:head,base_sha:base,changed_files:0,files:[]}, {timeoutMs:3000});
  await waitForFile(pidsFile);
  const pids = JSON.parse(fs.readFileSync(pidsFile, 'utf8'));
  await assert.rejects(capture, /baseline capture timed out/i);
  assert.ok(Date.now() - started < 6000, 'baseline capture cancellation must be bounded');
  assert.equal(fs.readFileSync(termFile, 'utf8'), 'term');
  for (const pid of pids) await waitForExit(pid);
  fs.unlinkSync(pidsFile);
});

test('capture SIGTERM terminates a stubborn exporter and its process group', { skip: process.platform === 'win32', timeout: 10000 }, async t => {
  const { spawn } = require('node:child_process'); const { once } = require('node:events');
  const { dir, pidsFile, termFile } = fixture(t);
  const script = path.join(dir, 'capture.cjs');
  fs.writeFileSync(script, `const {exportContext}=require(${JSON.stringify(path.join(__dirname, '../pr-re-review/ReviewSnapshot.cjs'))});exportContext({files:[],threads:[],reviews:[]},${JSON.stringify(path.join(dir, 'input'))},{timeoutMs:10000}).then(()=>process.exitCode=2,error=>{console.error(error.message);process.exitCode=1;});`);
  const controller = spawn(process.execPath, [script], { env: process.env, stdio: ['ignore', 'ignore', 'pipe'] });
  t.after(() => { try { controller.kill('SIGKILL'); } catch { /* exited */ } });
  let stderr = ''; controller.stderr.on('data', chunk => { stderr += chunk; });
  const closed = once(controller, 'close');
  await waitForFile(pidsFile);
  const pids = JSON.parse(fs.readFileSync(pidsFile, 'utf8'));
  controller.kill('SIGTERM');
  let timer;
  const [code] = await Promise.race([closed, new Promise((_, reject) => { timer = setTimeout(() => reject(new Error('Capture cancellation did not finish promptly')), 3500); })]).finally(() => clearTimeout(timer));
  assert.equal(code, 1);
  assert.match(stderr, /capture cancelled by SIGTERM/i);
  assert.equal(fs.readFileSync(termFile, 'utf8'), 'term');
  for (const pid of pids) await waitForExit(pid);
  fs.unlinkSync(pidsFile);
  assert.equal(fs.existsSync(path.join(dir, 'input', 'delivery-index.json')), false);
});
