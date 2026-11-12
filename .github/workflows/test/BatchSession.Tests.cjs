'use strict';
const assert = require('node:assert/strict');
const { test } = require('node:test');
const fs = require('node:fs');
const os = require('node:os');
const path = require('node:path');
const { spawn } = require('node:child_process');
const { once } = require('node:events');
const { startBatchSession } = require('../pr-re-review/ReviewBatchSession.cjs');

function fixture(t, mode) {
  const dir = fs.mkdtempSync(path.join(os.tmpdir(), 'batch-session-'));
  const script = path.join(dir, 'fake-pwsh'), previous = process.env.GH_AW_REVIEW_PWSH, previousMode = process.env.BATCH_FAKE_MODE, previousDir = process.env.BATCH_FAKE_DIR;
  t.after(() => {
    if (previous === undefined) delete process.env.GH_AW_REVIEW_PWSH; else process.env.GH_AW_REVIEW_PWSH = previous;
    if (previousMode === undefined) delete process.env.BATCH_FAKE_MODE; else process.env.BATCH_FAKE_MODE = previousMode;
    if (previousDir === undefined) delete process.env.BATCH_FAKE_DIR; else process.env.BATCH_FAKE_DIR = previousDir;
    for (const name of ['selector.pid','child.pid','cli.pid','verifier.pid']) {
      const file = path.join(dir,name);
      if (fs.existsSync(file)) { const pid=Number(fs.readFileSync(file,'utf8')); if(Number.isSafeInteger(pid)&&pid>1)try{process.kill(pid,'SIGKILL')}catch{} }
    }
    fs.rmSync(dir, { recursive: true, force: true });
  });
  fs.writeFileSync(script, `#!/usr/bin/env node
    const fs=require('node:fs'),path=require('node:path'),readline=require('node:readline');
    const mode=process.env.BATCH_FAKE_MODE,dir=process.env.BATCH_FAKE_DIR;
    if(mode==='die-during-verifier' && process.argv.some(arg=>arg.endsWith('ReviewVerifyDelivery.ps1'))) {
      process.on('SIGTERM',()=>fs.writeFileSync(path.join(dir,'verifier.term'),'term'));
      fs.writeFileSync(path.join(dir,'verifier.pid.tmp'),String(process.pid));fs.renameSync(path.join(dir,'verifier.pid.tmp'),path.join(dir,'verifier.pid'));
      process.stdin.resume();setInterval(()=>{},1000);return;
    }
    if(['hang','hang-child','ignore-eof','flood-stubborn'].includes(mode)) process.on('SIGTERM',()=>{});
    fs.writeFileSync(path.join(dir,'selector.pid.tmp'),String(process.pid));fs.renameSync(path.join(dir,'selector.pid.tmp'),path.join(dir,'selector.pid'));
    if(mode==='hang') {process.stdin.resume();setInterval(()=>{},1000);return;}
    if(mode==='ignore-eof') setInterval(()=>{},1000);
    if(mode==='hang-child') {
      const {spawn}=require('node:child_process');
      const child=spawn(process.execPath,['-e',"process.on('SIGTERM',()=>{});process.send('ready');setInterval(()=>{},1000)"],{stdio:['ignore','ignore','ignore','ipc']});
      child.once('message',()=>{fs.writeFileSync(path.join(dir,'child.pid.tmp'),String(child.pid));fs.renameSync(path.join(dir,'child.pid.tmp'),path.join(dir,'child.pid'));child.disconnect();});
      process.stdin.resume();setInterval(()=>{},1000);return;
    }
    readline.createInterface({input:process.stdin}).on('line',line=>{
      const req=JSON.parse(line);
      if(mode==='partial-next') {if(req.id===1)process.stdout.write(JSON.stringify({id:1,count:1})+'\\n'+ '{"id":2,');else process.stdout.write('"count":1}\\n');}
      else if(mode==='close-stdout') {fs.writeSync(1,JSON.stringify({id:req.id,count:1})+'\\n');fs.closeSync(1);}
      else if(mode==='malformed') process.stdout.write('not-json\\n');
      else if(mode==='wrong-id') process.stdout.write(JSON.stringify({id:req.id+1,count:1})+'\\n');
      else if(mode==='extra') process.stdout.write(JSON.stringify({id:req.id,count:1,extra:true})+'\\n');
      else if(mode==='flood') process.stdout.write('x'.repeat(5000));
      else if(mode==='flood-stubborn') setInterval(()=>process.stdout.write('x'.repeat(65536)),1);
      else if(mode==='invalid-utf8') process.stdout.write(Buffer.from([0xff,0x0a]));
      else if(mode==='trailing-utf8') {process.stdout.write(JSON.stringify({id:req.id,count:1})+'\\n');process.stdout.write(Buffer.from([0xe2]));}
      else if(mode==='partial') {process.stdout.write('{"id":');process.exit(1);}
      else if(mode==='term-exit-pipe') {
        const {spawn}=require('node:child_process');const escaped=spawn(process.execPath,['-e','setInterval(()=>{},1000)'],{detached:true,stdio:['ignore','inherit','inherit']});
        fs.writeFileSync(path.join(dir,'child.pid.tmp'),String(escaped.pid));fs.renameSync(path.join(dir,'child.pid.tmp'),path.join(dir,'child.pid'));
        process.on('SIGTERM',()=>process.exit(0));process.stdout.write('x'.repeat(5000));
      }
      else if(mode==='escape-pipe') {
        const {spawn}=require('node:child_process');const escaped=spawn(process.execPath,['-e','setInterval(()=>{},1000)'],{detached:true,stdio:['ignore','inherit','inherit']});
        fs.writeFileSync(path.join(dir,'child.pid.tmp'),String(escaped.pid));fs.renameSync(path.join(dir,'child.pid.tmp'),path.join(dir,'child.pid'));process.exit(1);
      }
      else if(mode==='duplicate') process.stdout.write(JSON.stringify({id:req.id,count:1})+'\\n'+JSON.stringify({id:req.id,count:1})+'\\n');
      else if(mode==='split') {const response=JSON.stringify({id:req.id,count:1})+'\\n';process.stdout.write(response.slice(0,5));setTimeout(()=>process.stdout.write(response.slice(5)),20);}
      else {process.stdout.write(JSON.stringify({id:req.id,count:1})+'\\n');if(['die-after-reply','eof-after-reply','die-during-verifier'].includes(mode)){const timer=setInterval(()=>{if(fs.existsSync(path.join(dir,'die'))){clearInterval(timer);if(mode==='eof-after-reply')fs.closeSync(1);else process.exit(1);}},10);}}
    });
  `, { mode: 0o755 });
  process.env.GH_AW_REVIEW_PWSH = script; process.env.BATCH_FAKE_MODE = mode; process.env.BATCH_FAKE_DIR = dir;
  return { dir };
}
async function waitForFile(file, child) {
  const deadline = Date.now() + 5000;
  while (Date.now() < deadline) {
    if (fs.existsSync(file)) return;
    if (child && (child.exitCode !== null || child.signalCode !== null)) throw new Error('Controller exited before readiness');
    await new Promise(resolve => setTimeout(resolve, 10));
  }
  throw new Error('Fixture did not become ready');
}
function alive(pid) {
  try { process.kill(pid, 0); if (process.platform === 'linux') { const stat=fs.readFileSync(`/proc/${pid}/stat`,'utf8'), close=stat.lastIndexOf(')'); if(close>=0 && stat[close+2]==='Z') return false; } return true; }
  catch (error) { if (error.code === 'ESRCH' || error.code === 'ENOENT') return false; throw error; }
}
const work = [{ id:'file:0', file:{ filename:'f.cs', status:'modified', patch:'diff' } }];

for (const mode of ['malformed', 'wrong-id', 'extra', 'flood', 'flood-stubborn', 'invalid-utf8', 'partial']) test(`session rejects ${mode} responses`, { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { dir } = fixture(t, mode);
  const session = startBatchSession({ maxItems:8, maxBytes:48000 });
  await assert.rejects(session.select(work, Date.now()+3000), /batch select/i);
  await assert.rejects(session.close(), /batch select/i);
  fs.rmSync(path.join(dir, 'selector.pid'), { force: true });
});

test('missing selector executable fails closed without hanging', { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { dir } = fixture(t, 'normal');
  process.env.GH_AW_REVIEW_PWSH = path.join(dir,'missing-pwsh');
  const session = startBatchSession({ maxItems:8, maxBytes:48000 });
  await assert.rejects(session.select(work, Date.now()+3000), /ENOENT/i);
  await assert.rejects(session.close(), /ENOENT/i);
});

test('session rejects an unsolicited duplicate response', { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { dir } = fixture(t, 'duplicate');
  const session = startBatchSession({ maxItems:8, maxBytes:48000 });
  try { await session.select(work, Date.now()+3000); } catch { /* Either frame may be processed first. */ }
  if (!session.signal.aborted) await new Promise((resolve, reject) => {
    const timer=setTimeout(()=>reject(new Error('Duplicate response was not rejected')),3000);
    session.signal.addEventListener('abort',()=>{clearTimeout(timer);resolve();},{once:true});
  });
  await assert.rejects(session.close(), /batch select/i);
  fs.rmSync(path.join(dir, 'selector.pid'), { force: true });
});

test('unsolicited partial output cannot become the next request response', { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { dir } = fixture(t, 'partial-next');
  const session = startBatchSession({ maxItems:8, maxBytes:48000 });
  try {
    try { await session.select(work, Date.now()+3000); }
    catch (error) { assert.match(error.message, /unexpected batch selection output/i); }
    await assert.rejects(session.select(work, Date.now()+3000), /unexpected batch selection output/i);
    await assert.rejects(session.close(), /unexpected batch selection output/i);
  } finally { await session.close().catch(()=>{}); }
  fs.rmSync(path.join(dir, 'selector.pid'), { force: true });
});

test('stdout EOF immediately marks the selector failed while it remains alive', { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { dir } = fixture(t, 'close-stdout');
  const session = startBatchSession({ maxItems:8, maxBytes:48000 });
  try {
    await session.select(work, Date.now()+3000).catch(error=>assert.match(error.message,/batch select/i));
    if (!session.signal.aborted) await new Promise(resolve=>setTimeout(resolve,100));
    assert.equal(session.signal.aborted, true, 'An unexpected stdout EOF must immediately fail the session');
    await assert.rejects(session.close(), /batch select/i);
  } finally { await session.close().catch(()=>{}); }
  fs.rmSync(path.join(dir, 'selector.pid'), { force: true });
});

test('session accepts split response frames and closes cleanly', { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { dir } = fixture(t, 'split');
  const session = startBatchSession({ maxItems:8, maxBytes:48000 });
  assert.deepEqual(await session.select(work, Date.now()+3000), work);
  assert.deepEqual(await session.select(work, Date.now()+3000), work);
  await session.close();
  fs.rmSync(path.join(dir, 'selector.pid'), { force: true });
});

test('session rejects an incomplete UTF-8 suffix on orderly shutdown', { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { dir } = fixture(t, 'trailing-utf8');
  const session = startBatchSession({ maxItems:8, maxBytes:48000 });
  await session.select(work, Date.now()+3000).catch(error=>assert.match(error.message,/batch select/i));
  await assert.rejects(session.close(), /batch select/i);
  fs.rmSync(path.join(dir, 'selector.pid'), { force: true });
});

test('session refuses publication when orderly selector shutdown hangs', { skip: process.platform === 'win32', timeout: 10000 }, async t => {
  const { dir } = fixture(t, 'ignore-eof');
  const session = startBatchSession({ maxItems:8, maxBytes:48000 });
  assert.deepEqual(await session.select(work, Date.now()+3000), work);
  const pid=Number(fs.readFileSync(path.join(dir,'selector.pid'),'utf8'));
  await assert.rejects(session.close(), /did not stop/i);
  assert.equal(alive(pid), false); fs.unlinkSync(path.join(dir,'selector.pid'));
});

test('selector exit cancels delayed group escalation while inherited pipes drain', { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { dir } = fixture(t, 'term-exit-pipe');
  const originalKill = process.kill;
  const sent = [];
  process.kill = function(pid, signal) { if (pid < -1) sent.push(signal); return originalKill.call(process, pid, signal); };
  t.after(() => { process.kill = originalKill; });
  const session = startBatchSession({ maxItems:8, maxBytes:48000 });
  await assert.rejects(session.select(work, Date.now()+3000), /output exceeds/i);
  await assert.rejects(session.close(), /output exceeds/i);
  assert.deepEqual(sent, ['SIGTERM', 'SIGKILL'], 'Do not signal an exited selector group again after a delay');
  fs.rmSync(path.join(dir, 'selector.pid'), { force: true });
});

test('escaped pipe holder cannot suppress selector failure indefinitely', { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { dir } = fixture(t, 'escape-pipe');
  const session = startBatchSession({ maxItems:8, maxBytes:48000 });
  const start = Date.now();
  await assert.rejects(session.select(work, Date.now()+3000), /batch select/i);
  await assert.rejects(session.close(), /batch select/i);
  assert.ok(Date.now()-start < 2500, 'pipe draining must be bounded');
  assert.ok(fs.existsSync(path.join(dir,'child.pid')));
});

test('session timeout rejects and terminates a stalled selector', { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { dir } = fixture(t, 'hang'); const session = startBatchSession({ maxItems:8, maxBytes:48000 });
  await waitForFile(path.join(dir, 'selector.pid'));
  const pid = Number(fs.readFileSync(path.join(dir, 'selector.pid'), 'utf8'));
  await assert.rejects(session.select(work, Date.now()+500), /deadline/i);
  await assert.rejects(session.close(), /deadline/i);
  assert.equal(alive(pid), false);
  fs.rmSync(path.join(dir, 'selector.pid'), { force: true });
});

test('session timeout stays bounded when a selector does not read a large request', { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { dir } = fixture(t, 'hang');
  const session = startBatchSession({ maxItems:8, maxBytes:48000 });
  await waitForFile(path.join(dir, 'selector.pid'));
  const pid=Number(fs.readFileSync(path.join(dir, 'selector.pid'),'utf8'));
  const large=[{id:'thread:0',thread:{comments:[{body:'x'.repeat(8*1024*1024)}]}}];
  await assert.rejects(session.select(large, Date.now()+500), /deadline/i);
  await assert.rejects(session.close(), /deadline/i);
  assert.equal(alive(pid), false); fs.unlinkSync(path.join(dir,'selector.pid'));
});

for (const signal of ['SIGTERM', 'SIGINT']) test(`session ${signal} terminates selector and stubborn descendant`, { skip: process.platform === 'win32', timeout: 10000 }, async t => {
  const { dir } = fixture(t, 'hang-child');
  const entry = path.join(dir, 'session.cjs'), sessionPath = path.join(__dirname, '../pr-re-review/ReviewBatchSession.cjs');
  fs.writeFileSync(entry, `const {startBatchSession}=require(${JSON.stringify(sessionPath)});const s=startBatchSession({maxItems:8,maxBytes:48000});s.select(${JSON.stringify(work)},Date.now()+10000).then(()=>process.exitCode=2,async error=>{try{await s.close()}catch{}console.error(error.message);process.exitCode=1;});`);
  const controller = spawn(process.execPath, [entry], { env: process.env, stdio:['ignore','ignore','pipe'] });
  const selectorPidFile = path.join(dir, 'selector.pid'), childPidFile = path.join(dir, 'child.pid');
  t.after(() => { try { controller.kill('SIGKILL'); } catch { /* exited */ } for(const file of [selectorPidFile,childPidFile])if(fs.existsSync(file)){const pid=Number(fs.readFileSync(file,'utf8'));if(Number.isSafeInteger(pid)&&pid>1)try{process.kill(pid,'SIGKILL')}catch{}} });
  let stderr='';controller.stderr.on('data',d=>{stderr+=d;});const closed=once(controller,'close');
  await waitForFile(childPidFile,controller);const pids=[selectorPidFile,childPidFile].map(file=>Number(fs.readFileSync(file,'utf8')));controller.kill(signal);
  let timer;const [code]=await Promise.race([closed,new Promise((_,reject)=>{timer=setTimeout(()=>reject(new Error('Selector session did not stop')),3500);})]).finally(()=>clearTimeout(timer));
  assert.equal(code,1);assert.match(stderr,new RegExp(`cancelled by ${signal}`,'i'));for(const pid of pids)assert.equal(alive(pid),false);
  fs.unlinkSync(childPidFile);fs.unlinkSync(selectorPidFile);
});

for (const signal of ['SIGTERM', 'SIGINT']) test(`controller ${signal} cancels both idle selector and pinned harness`, { skip: process.platform === 'win32', timeout: 20000 }, async t => {
  const actions = process.env.GH_AW_TEST_ACTIONS_DIR; assert.ok(actions, 'Pinned process runner required.');
  const { dir } = fixture(t, 'normal');
  const cli = path.join(dir, 'cli.cjs'), harness = path.join(dir, 'harness.cjs');
  const cliPidFile = path.join(dir, 'cli.pid'), selectorPidFile = path.join(dir, 'selector.pid'), termFile = path.join(dir, 'cli.term');
  fs.writeFileSync(cli, `const fs=require('node:fs');process.on('SIGTERM',()=>{fs.writeFileSync(${JSON.stringify(termFile)},'term');});fs.writeFileSync(${JSON.stringify(cliPidFile + '.tmp')},String(process.pid));fs.renameSync(${JSON.stringify(cliPidFile + '.tmp')},${JSON.stringify(cliPidFile)});setInterval(()=>{},1000);`);
  fs.writeFileSync(harness, `const {runProcess}=require(${JSON.stringify(path.join(actions,'process_runner.cjs'))});runProcess({command:process.execPath,args:[${JSON.stringify(cli)}],attempt:0,log:()=>{}}).then(result=>{process.exitCode=result.exitCode;});`);
  const entry = path.join(dir, 'controller.cjs'), modulePath = path.join(__dirname, '../pr-re-review/ReviewContinuation.cjs');
  fs.writeFileSync(entry, `const {runQueue,runProcess}=require(${JSON.stringify(modulePath)});runQueue(${JSON.stringify(work)},{deadline:Date.now()+15000,runBatch:async(_batch,deadline,signal)=>{await runProcess(process.execPath,[${JSON.stringify(harness)}],{deadline,signal,outputFile:${JSON.stringify(path.join(dir,'execution.log'))}});return {results:[]}}}).then(()=>process.exitCode=2,error=>{console.error(error.message);process.exitCode=1;});`);
  const controller = spawn(process.execPath, [entry], { env: process.env, stdio:['ignore','ignore','pipe'] });
  t.after(() => { try { controller.kill('SIGKILL'); } catch { /* exited */ } if (fs.existsSync(cliPidFile)) { const pid=Number(fs.readFileSync(cliPidFile,'utf8')); if(Number.isSafeInteger(pid)&&pid>1)try{process.kill(-pid,'SIGKILL')}catch{} } });
  let stderr='';controller.stderr.on('data',d=>{stderr+=d;});const closed=once(controller,'close');
  await waitForFile(cliPidFile,controller);const cliPid=Number(fs.readFileSync(cliPidFile,'utf8')),selectorPid=Number(fs.readFileSync(selectorPidFile,'utf8'));assert.ok(alive(cliPid));assert.ok(alive(selectorPid));
  controller.kill(signal);
  const stoppedDeadline = Date.now()+3000;
  while (alive(selectorPid) && Date.now()<stoppedDeadline) await new Promise(resolve=>setTimeout(resolve,10));
  assert.equal(alive(selectorPid), false);
  controller.kill(signal); // Repeated cancellation must not bypass pinned-runner cleanup.
  controller.kill(signal === 'SIGTERM' ? 'SIGINT' : 'SIGTERM');
  let timer;const [code]=await Promise.race([closed,new Promise((_,reject)=>{timer=setTimeout(()=>reject(new Error('Controller did not stop after cancellation')),12000);})]).finally(()=>clearTimeout(timer));
  assert.equal(code,1);assert.match(stderr,new RegExp(`cancelled by ${signal}`,'i'));assert.equal(fs.readFileSync(termFile,'utf8'),'term');assert.equal(alive(cliPid),false);assert.equal(alive(selectorPid),false);
  fs.unlinkSync(cliPidFile); fs.unlinkSync(selectorPidFile);
});

test('worker errors remain visible when the selector also fails', { skip: process.platform === 'win32', timeout: 6000 }, async t => {
  const { dir } = fixture(t, 'die-after-reply');
  const { runQueue } = require('../pr-re-review/ReviewContinuation.cjs');
  await assert.rejects(runQueue(work, {
    deadline:Date.now()+5000,
    runBatch:async(_batch,_deadline,signal)=>{
      fs.writeFileSync(path.join(dir,'die'),'exit');
      if(!signal.aborted) await new Promise((resolve,reject)=>{
        const timer=setTimeout(()=>reject(new Error('Selector failure was not observed')),3000);
        signal.addEventListener('abort',()=>{clearTimeout(timer);resolve();},{once:true});
      });
      throw new Error('Original worker I/O failure');
    },
  }), error=>{
    assert.ok(error instanceof AggregateError);
    assert.match(error.message,/Original worker I\/O failure/);
    assert.match(error.message,/selector.*unexpected/i);
    assert.equal(error.errors.length,2);
    return true;
  });
  fs.rmSync(path.join(dir,'selector.pid'),{force:true});
});

test('unexpected selector failure cancels an active delivery verifier', { skip: process.platform === 'win32', timeout: 10000 }, async t => {
  const { dir } = fixture(t, 'die-during-verifier');
  const entry = path.join(dir,'controller.cjs'), controllerModule = path.join(__dirname,'../pr-re-review/ReviewContinuation.cjs'), deliveryModule = path.join(__dirname,'../pr-re-review/ReviewDelivery.cjs');
  fs.writeFileSync(entry, `const {runQueue}=require(${JSON.stringify(controllerModule)}),{verifyDelivery}=require(${JSON.stringify(deliveryModule)});const snapshot={files:[],threads:[]};runQueue(${JSON.stringify(work)},{deadline:Date.now()+10000,runBatch:async(batch,deadline,signal)=>{const results=batch.map(item=>({id:item.id,status:'complete',delivery_tokens:[],reasoning:'read',findings:[],action:'none'}));await verifyDelivery(snapshot,batch,results,'1'.repeat(32),[],{deadline,signal});return {results};}}).then(()=>process.exitCode=2,error=>{console.error(error.message);process.exitCode=1;});`);
  const controller=spawn(process.execPath,[entry],{env:process.env,stdio:['ignore','ignore','pipe']});
  t.after(()=>{try{controller.kill('SIGKILL')}catch{}});let stderr='';controller.stderr.on('data',d=>{stderr+=d;});const closed=once(controller,'close');
  const verifierPidFile=path.join(dir,'verifier.pid');await waitForFile(verifierPidFile,controller);const pid=Number(fs.readFileSync(verifierPidFile,'utf8'));assert.ok(alive(pid));fs.writeFileSync(path.join(dir,'die'),'exit');
  let timer;const [code]=await Promise.race([closed,new Promise((_,reject)=>{timer=setTimeout(()=>reject(new Error('Verifier did not stop after selector failure')),3500);})]).finally(()=>clearTimeout(timer));
  assert.equal(code,1);assert.match(stderr,/selector.*unexpected/i);assert.equal(fs.readFileSync(path.join(dir,'verifier.term'),'utf8'),'term');assert.equal(alive(pid),false);
  fs.unlinkSync(verifierPidFile);fs.unlinkSync(path.join(dir,'selector.pid'));
});

for (const mode of ['die-after-reply', 'eof-after-reply']) test(`selector ${mode} cancels a running pinned harness and detached CLI`, { skip: process.platform === 'win32', timeout: 20000 }, async t => {
  const actions = process.env.GH_AW_TEST_ACTIONS_DIR; assert.ok(actions, 'Pinned process runner required.');
  const { dir } = fixture(t, mode);
  const cli = path.join(dir, 'cli.cjs'), harness = path.join(dir, 'harness.cjs');
  const cliPidFile = path.join(dir, 'cli.pid'), termFile = path.join(dir, 'cli.term');
  fs.writeFileSync(cli, `const fs=require('node:fs');process.on('SIGTERM',()=>{fs.writeFileSync(${JSON.stringify(termFile)},'term');process.exit(0)});fs.writeFileSync(${JSON.stringify(cliPidFile + '.tmp')},String(process.pid));fs.renameSync(${JSON.stringify(cliPidFile + '.tmp')},${JSON.stringify(cliPidFile)});setInterval(()=>{},1000);`);
  fs.writeFileSync(harness, `const {runProcess}=require(${JSON.stringify(path.join(actions,'process_runner.cjs'))});runProcess({command:process.execPath,args:[${JSON.stringify(cli)}],attempt:0,log:()=>{}}).then(result=>{process.exitCode=result.exitCode;});`);
  const entry = path.join(dir, 'controller.cjs'), modulePath = path.join(__dirname, '../pr-re-review/ReviewContinuation.cjs');
  fs.writeFileSync(entry, `const {runQueue,runProcess}=require(${JSON.stringify(modulePath)});runQueue(${JSON.stringify(work)},{deadline:Date.now()+15000,runBatch:async(_batch,deadline,signal)=>{await runProcess(process.execPath,[${JSON.stringify(harness)}],{deadline,signal,outputFile:${JSON.stringify(path.join(dir,'execution.log'))}});return {results:[]}}}).then(()=>process.exitCode=2,error=>{console.error(error.message);process.exitCode=1;});`);
  const controller = spawn(process.execPath, [entry], { env: process.env, stdio:['ignore','ignore','pipe'] });
  t.after(() => { try { controller.kill('SIGKILL'); } catch { /* exited */ } if (fs.existsSync(cliPidFile)) { const pid=Number(fs.readFileSync(cliPidFile,'utf8')); if(Number.isSafeInteger(pid)&&pid>1)try{process.kill(-pid,'SIGKILL')}catch{} } });
  let stderr='';controller.stderr.on('data',d=>{stderr+=d;});const closed=once(controller,'close');
  await waitForFile(cliPidFile,controller);const pid=Number(fs.readFileSync(cliPidFile,'utf8'));assert.ok(alive(pid));
  fs.writeFileSync(path.join(dir,'die'),'exit');
  let timer;const [code]=await Promise.race([closed,new Promise((_,reject)=>{timer=setTimeout(()=>reject(new Error('Controller did not stop after selector failure')),12000);})]).finally(()=>clearTimeout(timer));
  assert.equal(code,1);assert.match(stderr,/selector.*unexpected/i);assert.equal(fs.readFileSync(termFile,'utf8'),'term');assert.equal(alive(pid),false);
  fs.unlinkSync(cliPidFile); fs.unlinkSync(path.join(dir,'selector.pid'));
});
