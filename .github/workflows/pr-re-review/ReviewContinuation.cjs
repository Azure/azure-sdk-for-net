'use strict';

// Native gh-aw runtime bridge. Review policy and the authoritative queue live
// only in the persistent PowerShell host; Node performs asynchronous effects.
const fs = require('node:fs');
const path = require('node:path');
const { spawn } = require('node:child_process');
const crypto = require('node:crypto');
const { StringDecoder } = require('node:string_decoder');
const { verifyDelivery, snapshotDigest, MAX_BATCH_BYTES } = require('./ReviewDelivery.cjs');
const { startContinuationSession, completeResponseBudget, finalResponseBudget, addCompleteWireBytes } = require('./ReviewContinuationSession.cjs');
const WORKER_SHUTDOWN_GRACE_MS = 10000;

function checkRuntime(session, deadline) {
  session.assertHealthy();
  if (Date.now() >= deadline) throw new Error('Review deadline exhausted.');
}
function validateAssignment(value, nonce, items) {
  if (!value || typeof value.complete !== 'boolean' || !Array.isArray(value.ids)) throw new Error('Invalid continuation assignment.');
  if (value.complete) {
    if (value.ids.length || Object.keys(value).length !== 2) throw new Error('Invalid completed continuation assignment.');
  } else if (Object.keys(value).length !== 4 || !Number.isSafeInteger(value.attempt_id) || value.attempt_id <= 0 || value.nonce !== nonce ||
      !value.ids.length || value.ids.length > 8 || new Set(value.ids).size !== value.ids.length || value.ids.some(id => typeof id !== 'string' || !items.has(id))) {
    throw new Error('Invalid continuation assignment.');
  }
}
function validateDelta(value, assignment, total) {
  if (!value || value.attempt_id !== assignment.attempt_id || !Array.isArray(value.accepted) || value.accepted.length > assignment.ids.length ||
      !Number.isSafeInteger(value.remaining) || value.remaining < 0 || value.remaining > total || !Number.isSafeInteger(value.batch_limit) || value.batch_limit < 1 || value.batch_limit > 8 ||
      !value.attempt || !Array.isArray(value.attempt.assigned) || !Array.isArray(value.attempt.completed) || !Array.isArray(value.attempt.pending) || typeof value.attempt.reason !== 'string') {
    throw new Error('Invalid continuation checkpoint delta.');
  }
  const ids=value.accepted.map(item=>item?.id);
  if (new Set(ids).size !== ids.length || ids.some(id=>!assignment.ids.includes(id)) || JSON.stringify(value.attempt.assigned) !== JSON.stringify(assignment.ids) ||
      JSON.stringify(value.attempt.completed) !== JSON.stringify(ids)) throw new Error('Invalid continuation checkpoint identities.');
}
async function closeRuntime(session, failure) {
  try { await session.close(); }
  catch (error) {
    if (!failure) throw error;
    if (error !== failure && !(failure instanceof AggregateError && failure.errors.includes(error))) throw new AggregateError([failure,error],`${failure.message}; continuation cleanup failed: ${error.message}`);
  }
}
async function runReview(snapshot, {runBatch,deadline,checkpoint=()=>{}}) {
  if (!Number.isFinite(deadline)) throw new Error('Invalid review deadline.');
  if (Date.now() >= deadline) throw new Error('Review deadline exhausted.');
  const session=startContinuationSession(); let failure, diagnostics, outputs, completeBytes=0;
  try {
    const digest=snapshotDigest(snapshot);
    const init=(await session.request('initialize',{snapshot,snapshotHash:digest},{deadline})).value;
    checkRuntime(session,deadline);
    // Mechanical immutable ID bindings only; validation and ordering policy are
    // in PowerShell, not a second pending queue in the native bridge.
    const items=new Map([...snapshot.threads.map((thread,i)=>[`thread:${i}`,{id:`thread:${i}`,thread}]),...snapshot.files.map((file,i)=>[`file:${i}`,{id:`file:${i}`,file}])]);
    const initial=init?.checkpoint;
    if (init?.work_count !== items.size || !initial || initial.snapshot_sha256 !== digest || initial.head_sha !== snapshot.head_sha || initial.base_sha !== snapshot.base_sha ||
        !Array.isArray(initial.results) || initial.results.length || !Array.isArray(initial.attempts) || initial.attempts.length) throw new Error('Invalid initial continuation checkpoint.');
    diagnostics=initial;
    checkpoint(structuredClone(diagnostics),items.size);
    while (true) {
      checkRuntime(session,deadline);
      const nonce=crypto.randomBytes(16).toString('hex');
      const assignment=(await session.request('next',{nonce},{deadline})).value;
      validateAssignment(assignment,nonce,items); checkRuntime(session,deadline);
      if (assignment.complete) break;
      const batch=assignment.ids.map(id=>items.get(id));
      let returned;
      try {
        returned=await runBatch(batch,deadline,session.signal,{nonce,attempt_id:assignment.attempt_id,
          workerPrompt: original => workerPrompt(original,snapshot,batch,nonce,{session,deadline,attempt_id:assignment.attempt_id})});
        checkRuntime(session,deadline);
        if (!returned || !returned.response || !Array.isArray(returned.receipts)) throw new Error('Invalid worker effect response.');
        await verifyDelivery(snapshot,batch,returned.response.results,nonce,returned.receipts,{deadline,signal:session.signal});
      } catch (error) {
        try { session.assertHealthy(); } catch (hostError) { if (hostError !== error) throw new AggregateError([error,hostError],`${error.message}; ${hostError.message}`); }
        throw error;
      }
      checkRuntime(session,deadline);
      // This flag is a trusted runtime assertion constructed only after the
      // independent verifier succeeds. Never copy it from worker JSON.
      const response={results:returned.response.results,...(typeof returned.response.reason==='string'?{reason:returned.response.reason}:{})};
      const packet=await session.request('complete',{attempt_id:assignment.attempt_id,nonce,deliveryVerified:true,response},{deadline,maxResponseBytes:completeResponseBudget});
      checkRuntime(session,deadline); validateDelta(packet.value,assignment,items.size);
      completeBytes=addCompleteWireBytes(completeBytes,packet.wireBytes);
      diagnostics.results.push(...packet.value.accepted); diagnostics.attempts.push(packet.value.attempt);
      checkpoint(structuredClone(diagnostics),items.size);
    }
    outputs=(await session.request('finish',{},{deadline,maxResponseBytes:finalResponseBudget(completeBytes)})).value;
    checkRuntime(session,deadline);
    if (!Array.isArray(outputs) || !outputs.length || outputs.some(item=>!item || typeof item.type !== 'string') || outputs.at(-1).type !== 'submit_pull_request_review') throw new Error('Invalid finalized review outputs.');
  } catch (error) { failure=error; throw error; }
  finally { await closeRuntime(session,failure); }
  if (Date.now() >= deadline) throw new Error('Review deadline exhausted before publication.');
  return {ledger:diagnostics,outputs};
}

// Preserve original native String(value)/JSON.stringify compatibility without
// duplicating review acceptance, output construction or publication policy.
function encodeActualRouting(output) {
  let actualRouting,routingError;
  try {
    if (Array.isArray(output?.items)) actualRouting=output.items.map(item=>JSON.stringify(Object.fromEntries(Object.keys(item).filter(key=>!['body','reason'].includes(key)).sort().map(key=>[key,String(item[key])]))));
  } catch (error) { routingError=error.message; }
  return {actualRouting,routingError};
}
function encodeGuardData(progress,output) {
  // Project only consumed fields, without accepting or validating them here.
  // This avoids serializing ignored diagnostic/opaque fields that the native
  // guard never traversed, while PowerShell still validates every known field.
  const pick=(value,keys)=>value && typeof value==='object' && !Array.isArray(value)?Object.fromEntries(keys.filter(key=>Object.hasOwn(value,key)).map(key=>[key,value[key]])):value;
  const projected=pick(progress,['snapshot_sha256','head_sha','base_sha','results']);
  if(Array.isArray(projected?.results))projected.results=projected.results.map(result=>{
    const entry=pick(result,['id','status','reasoning','findings','action','reply']);
    if(Array.isArray(entry?.findings))entry.findings=entry.findings.map(finding=>pick(finding,['path','line','body','side']));
    return entry;
  });
  const buffered=pick(output,['items','errors']);
  if(Array.isArray(buffered?.items))buffered.items=buffered.items.map(item=>({
    type:typeof item?.type==='string'?item.type:null,
    body:typeof item?.body==='string'?item.body:null,
  }));
  return {progress:projected,output:buffered};
}
function encodePublicationRequest(snapshot,progress,output,agentResult) {
  const routing=encodeActualRouting(output);
  return {snapshot,...encodeGuardData(progress,output),agentResult,snapshotHash:snapshotDigest(snapshot),...routing};
}
async function assertPublication(snapshot,progress,output,agentResult) {
  const session=startContinuationSession();let failure;
  try {
    const payload=encodePublicationRequest(snapshot,progress,output,agentResult);
    const result=(await session.request('assert-publication',payload,{deadline:Date.now()+22*60*1000})).value;
    if (!result || result.verified !== true || Object.keys(result).length !== 1) throw new Error('Invalid publication verification result.');
  } catch (error) { failure=error;throw error; }
  finally { await closeRuntime(session,failure); }
}

function workerArguments(args, promptFile, logDir) {
  const result = [];
  for (let i = 0; i < args.length; i++) {
    const arg = args[i];
    if (['--prompt-file', '--prompt', '-p', '--log-dir', '--output-format', '--stream'].includes(arg)) { i++; continue; }
    if (arg === '--allow-tool' && ['safeoutputs', 'write', 'shell'].includes(args[i + 1])) { i++; continue; }
    if (arg.startsWith('--prompt=') || arg.startsWith('--prompt-file=') || arg.startsWith('--log-dir=') || arg.startsWith('--output-format=') || arg.startsWith('--stream=')) continue;
    if (['--continue', '--resume'].includes(arg) || arg.startsWith('--resume=')) throw new Error('The controller requires fresh, bounded worker sessions.');
    result.push(arg);
  }
  return [...result, '--prompt-file', promptFile, '--log-dir', logDir, '--output-format', 'json', '--stream', 'off', '--no-auto-update', '--disable-mcp-server', 'safeoutputs', '--excluded-tools', 'task', '--allow-tool', 'read', '--deny-tool', 'safeoutputs', '--deny-tool', 'shell', '--deny-tool', 'write'];
}

function parseWorkerResult(output) {
  let last;
  for (const line of output.split(/\r?\n/)) {
    let event;
    try { event = JSON.parse(line); } catch { continue; }
    if (event.type === 'assistant.message' && typeof event.data?.content === 'string') last = event.data.content;
  }
  if (!last) return { results: [] };
  const cleaned = last.trim().replace(/^```(?:json)?\s*\n/, '').replace(/\n```$/, '');
  try {
    const response = JSON.parse(cleaned);
    if (response && typeof response === 'object' && !Array.isArray(response) && Array.isArray(response.results)) return response;
    const reason = typeof response === 'string' ? response : typeof response?.reason === 'string' ? response.reason : last;
    return { results: [], reason: reason.slice(0, 2000) };
  } catch { return { results: [], reason: last.slice(0, 2000) }; }
}

function runProcess(command, args, { deadline, env = process.env, outputFile, signal }) {
  return new Promise((resolve, reject) => {
    if (Date.now() >= deadline) return reject(new Error('Review deadline exhausted.'));
    if (signal?.aborted) return reject(new Error('Review worker cancelled after batch selector failure.'));
    const output = fs.createWriteStream(outputFile, { flags: 'wx', mode: 0o600 });
    const child = spawn(command, args, { env, stdio: ['ignore', 'pipe', 'pipe'], detached: true });
    let stdout = '';
    const decoder = new StringDecoder('utf8');
    let interrupted;
    let timedOut = false;
    const signalGroup = signal => { if (child.pid) { try { process.kill(-child.pid, signal); } catch { /* already exited */ } } };
    const killGroup = () => signalGroup('SIGKILL');
    let shutdownTimer;
    const stopGroup = () => {
      if (shutdownTimer) return;
      // Do not bypass the upstream runner's cancellation handlers: its CLI
      // is in a different process group and cannot be killed by our PGID.
      signalGroup('SIGTERM');
      shutdownTimer = setTimeout(killGroup, WORKER_SHUTDOWN_GRACE_MS);
    };
    const onTerm = () => { interrupted = 'SIGTERM'; stopGroup(); };
    const onInt = () => { interrupted = 'SIGINT'; stopGroup(); };
    const onAbort = () => { interrupted = interrupted || 'batch selector failure'; stopGroup(); };
    process.once('SIGTERM', onTerm);
    process.once('SIGINT', onInt);
    signal?.addEventListener('abort', onAbort, { once: true });
    if (signal?.aborted) onAbort();
    output.on('error', error => { stopGroup(); reject(error); });
    child.on('exit', killGroup); // Also reap descendants on normal completion.
    const timeout = setTimeout(() => {
      timedOut = true;
      stopGroup();
    }, Math.max(1, deadline - Date.now()));
    child.stdout.on('data', data => {
      output.write(data);
      // Keep a bounded parsing tail without terminating useful work because
      // tool logs are large. The complete transcript is still streamed to disk.
      stdout = (stdout + decoder.write(data)).slice(-8 * 1024 * 1024);
      // Preserve native CLI events for gh-aw's normal session-log collection
      // and threat detection, rather than hiding worker sessions in private logs.
      process.stdout.write(data);
    });
    child.stderr.on('data', data => { output.write(data); process.stderr.write(data); });
    child.on('error', error => { clearTimeout(timeout); clearTimeout(shutdownTimer); output.end(); reject(error); });
    child.on('close', code => {
      clearTimeout(timeout);
      clearTimeout(shutdownTimer);
      process.removeListener('SIGTERM', onTerm);
      process.removeListener('SIGINT', onInt);
      signal?.removeEventListener('abort', onAbort);
      output.end();
      if (interrupted) reject(new Error(`Review worker cancelled by ${interrupted}.`));
      else if (timedOut) reject(new Error('Review deadline exhausted during worker execution.'));
      else if (code !== 0) reject(new Error(`Worker failed with exit code ${code}; see its preserved log.`));
      else resolve(stdout + decoder.end());
    });
  });
}

function encodeWorkerPromptRequest(original, snapshot, batch, nonce) {
  // Native path/JSON bindings only. Projection, offloading and protocol policy
  // are constructed by the same private PowerShell host that owns the queue.
  const contextRoot = process.env.GH_AW_REVIEW_CONTEXT || path.join(__dirname, 'review-input');
  return { original, snapshot: Object.fromEntries(['head_sha','base_sha','diff_base_sha','head_repo','base_repo'].filter(key=>Object.hasOwn(snapshot,key)).map(key=>[key,snapshot[key]])),
    batch, nonce, maxPatchBytes: MAX_BATCH_BYTES,
    context_index: path.join(contextRoot,'index.json'),
    prior_results_path: path.join(process.env.GH_AW_REVIEW_ROOT || '/tmp/gh-aw/pr-re-review','progress.json'),
    input_paths: Object.fromEntries(batch.map(item=>[item.id,{history:path.join(contextRoot,`${item.id.replace(':','-')}.json`),patch:path.join(contextRoot,`${item.id.replace(':','-')}.patch`)}])) };
}
async function workerPrompt(original, snapshot, batch, nonce, {session,deadline,attempt_id}) {
  const payload={...encodeWorkerPromptRequest(original,snapshot,batch,nonce),attempt_id};
  // Reuse the existing native request-derived budget, including its generated
  // text allowance (60,000 bytes). The fixed protocol is <4 KiB; copied input
  // can expand at most sixfold. No helper-supplied size estimate is trusted.
  const value=(await session.request('worker-prompt',payload,{deadline,maxResponseBytes:finalResponseBudget})).value;
  if (!value || Object.keys(value).length!==2 || typeof value.prefix!=='string' || typeof value.payloadJson!=='string') throw new Error('Invalid worker prompt response.');
  // Keep exact JSON.stringify number/property/Unicode semantics at the native
  // boundary. PowerShell preserves canonical captured JSON as raw data.
  return value.prefix+JSON.stringify(JSON.parse(value.payloadJson));
}

async function main() {
  const [copilot,...args]=process.argv.slice(2);
  if (!copilot) throw new Error('Missing compiler-provided Copilot command.');
  const promptIndex=args.indexOf('--prompt-file');
  if (promptIndex<0 || !args[promptIndex+1]) throw new Error('Missing compiler-provided prompt file.');
  const original=fs.readFileSync(args[promptIndex+1],'utf8');
  const root=process.env.GH_AW_REVIEW_ROOT||'/tmp/gh-aw/pr-re-review';
  const contextRoot=process.env.GH_AW_REVIEW_CONTEXT||path.join(__dirname,'review-input');
  const snapshot=JSON.parse(fs.readFileSync(path.join(contextRoot,'snapshot.json'),'utf8'));
  const harness=path.join(__dirname,'copilot_harness.cjs');
  const softDeadline=Date.now()+22*60*1000;let invocation=0;
  const safeOutputsPath=process.env.GH_AW_SAFE_OUTPUTS;
  if (!safeOutputsPath) throw new Error('Missing safe-output path.');
  const beforeOutputs=fs.existsSync(safeOutputsPath)?fs.readFileSync(safeOutputsPath,'utf8'):'';
  const unchangedOutputs=()=>{
    const after=fs.existsSync(safeOutputsPath)?fs.readFileSync(safeOutputsPath,'utf8'):'';
    if(beforeOutputs!==after)throw new Error('A read-only review worker attempted to emit safe outputs.');
  };
  const {outputs}=await runReview(snapshot,{
    deadline:softDeadline,
    checkpoint:(diagnostic,total)=>{
      unchangedOutputs();
      // Diagnostic output only. Never reload this artifact into host authority.
      fs.writeFileSync(path.join(root,'progress.json'),JSON.stringify(diagnostic,null,2),{mode:0o600});
      console.error(`[review-continuation] ${diagnostic.results.length}/${total} assigned items completed.`);
    },
    runBatch:async(batch,deadline,signal,{nonce,workerPrompt})=>{
      const directory=path.join(root,`worker-${++invocation}`);fs.mkdirSync(directory,{recursive:false});
      const promptFile=path.join(directory,'prompt.txt');
      const prompt=await workerPrompt(original);
      fs.writeFileSync(promptFile,prompt,{mode:0o600});
      const env={...process.env,GITHUB_OUTPUT:path.join(directory,'runtime-outputs.txt'),GH_AW_HARNESS_MAX_RETRIES:'0'};
      const output=await runProcess(process.execPath,[harness,copilot,...workerArguments(args,promptFile,path.join(directory,'logs'))],{deadline,env,signal,outputFile:path.join(directory,'execution.log')});
      unchangedOutputs();
      const response=parseWorkerResult(output);
      const receiptDir=process.env.GH_AW_REVIEW_RECEIPTS||path.join(process.env.RUNNER_TEMP||'','gh-aw','safeoutputs','review-receipts');
      const receiptFile=path.join(receiptDir,`${nonce}.jsonl`);
      const contents=fs.existsSync(receiptFile)?fs.readFileSync(receiptFile,'utf8'):'';
      if(Buffer.byteLength(contents)>16*1024*1024)throw new Error('Delivery receipt limit exceeded.');
      const receipts=contents.split('\n').filter(Boolean).map(line=>JSON.parse(line));
      return {response,receipts};
    },
  });
  unchangedOutputs();
  // Final outputs were constructed by PowerShell and held until verified clean
  // host shutdown. Preserve gh-aw's ordinary collector/threat-detection path.
  const {runSafeOutputsCLI}=require(path.join(__dirname,'safeoutputs_cli.cjs'));
  for(const item of outputs){const {type,...payload}=item;runSafeOutputsCLI(type,Object.fromEntries(Object.entries(payload).map(([key,value])=>[key,String(value)])));}
}
module.exports={runReview,assertPublication,encodePublicationRequest,workerArguments,parseWorkerResult,encodeWorkerPromptRequest,workerPrompt,runProcess};
if(require.main===module)main().catch(error=>{console.error(`[review-continuation] ${error.stack||error}`);process.exitCode=1;});
