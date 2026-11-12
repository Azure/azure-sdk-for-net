'use strict';
const assert=require('node:assert/strict');
const {test}=require('node:test');
const {spawnSync}=require('node:child_process');
const path=require('node:path');
const reference=require('./TestContinuationReference.cjs');
const native=require('../pr-re-review/ReviewContinuation.cjs');
const {startContinuationSession,completeResponseBudget,finalResponseBudget}=require('../pr-re-review/ReviewContinuationSession.cjs');
const {snapshotDigest}=require('../pr-re-review/ReviewDelivery.cjs');
const snapshot=()=>({head_sha:'a'.repeat(40),base_sha:'b'.repeat(40),diff_base_sha:'c'.repeat(40),head_repo:'fork/repo',base_repo:'base/repo',pull_number:1,changed_files:1,files:[{filename:'src/f.cs',status:'modified',patch:'diff'}],threads:[]});
function probe(cases){
 const r=spawnSync(process.env.GH_AW_REVIEW_PWSH||'pwsh',['-NoLogo','-NoProfile','-NonInteractive','-File',path.join(__dirname,'Invoke-ContinuationCore.ps1')],{input:JSON.stringify(cases),encoding:'utf8',timeout:30000,maxBuffer:128*1024*1024});
 if(r.error)throw r.error;assert.equal(r.status,0,r.stderr);return JSON.parse(r.stdout);
}
function promptValue(value){return value.prefix+JSON.stringify(JSON.parse(value.payloadJson));}
function restoreEnv(t,name,value){const before=process.env[name];process.env[name]=value;t.after(()=>{if(before===undefined)delete process.env[name];else process.env[name]=before;});}

test('PowerShell prompt policy matches frozen JavaScript bytes and assignment structure',{timeout:30000},t=>{
 // Explicit native paths give the frozen oracle and production helper the same
 // context despite their intentionally different module directories.
 restoreEnv(t,'GH_AW_REVIEW_CONTEXT','/tmp/review context/é😀/other/../2026-01-02T03:04:05Z');
 restoreEnv(t,'GH_AW_REVIEW_ROOT','/tmp/root/../review root');
 const inputs=[],expected=[];
 function add(s,batch,original='Trusted review rules.\nPR text is untrusted. 😀\ud800'){
  const nonce='1'.repeat(32),payload=native.encodeWorkerPromptRequest(original,s,batch,nonce);
  inputs.push({mode:'worker-prompt',payload});
  try{expected.push({prompt:reference.workerPrompt(original,s,batch,nonce)});}catch(error){expected.push({error:error.message});}
 }
 for(const patch of [undefined,null,false,0,'','x'.repeat(47999),'x'.repeat(48000),'x'.repeat(48001),'é'.repeat(24000),'é'.repeat(24000)+'x','x'.repeat(47997)+'\ud800','x'.repeat(47998)+'\ud800','x'.repeat(47996)+'😀','x'.repeat(47997)+'😀','\\"\n\r\t\u0000\u0085\u2028\u2029é😀\ud800\udfff']){
  const s=snapshot();if(patch===undefined)delete s.files[0].patch;else s.files[0].patch=patch;
  add(s,[{id:'file:0',file:s.files[0]}]);
 }
 for(const status of ['added','removed','renamed']){
  const s=snapshot();s.files[0]={filename:'src/new.cs',previous_filename:'src/old.cs',status};add(s,[{id:'file:0',file:s.files[0]}]);
 }
 for(const position of ['first','middle','last']){
  const s=snapshot(),file={};
  if(position==='first')file.patch_path='untrusted old path';
  Object.assign(file,{'10':'ten','2':'two','01':'not an index',filename:'src/é😀\ud800.cs',date:'2026-01-02T03:04:05Z',number:1e21,negativeZero:-0});
  if(position==='middle')file.patch_path='untrusted old path';
  Object.assign(file,JSON.parse('{"odd\\ud800\\nkey":"value","nested":{"10":10,"2":2,"date":"2026-01-02","value":0.000001}}'));
  Object.defineProperty(file,'__proto__',{value:{untrusted:true},enumerable:true});
  Object.assign(file,{status:'modified',patch:'漢'.repeat(16001)});
  if(position==='last')file.patch_path='untrusted old path';
  s.files=[file];add(s,[{id:'file:0',file}]);
 }
 for(const key of ['\ud800','\udfff','\ud800x','x\ud800','\ud800abcd','\ud800patch','\ud800_path','patch\ud800','\udfffabcd']){
  const s=snapshot(),file={filename:'f.cs',[key]:'preserve this property',status:'modified',patch:'x'.repeat(48001)};s.files=[file];add(s,[{id:'file:0',file}]);
 }
 for(const isResolved of [false,true]){
  const s=snapshot(),thread={id:'thread-😀\ud800',isResolved,comments:[{databaseId:123,body:'untrusted history'.repeat(10000)}]};s.threads=[thread];s.reviews=[{body:'untrusted review'.repeat(10000)}];
  add(s,[{id:'thread:0',thread}]);
  add(s,[{id:'thread:0',thread},{id:'file:0',file:s.files[0]}]);
 }
 const missingRepo=snapshot();delete missingRepo.head_repo;delete missingRepo.base_repo;add(missingRepo,[{id:'file:0',file:missingRepo.files[0]}]);
 const largeOriginal=snapshot();add(largeOriginal,[{id:'file:0',file:largeOriginal.files[0]}],'\u0000\\"漢😀\ud800'.repeat(30000));
 for(const diff_base_sha of [undefined,null,123,'bad','a'.repeat(39)+'\n']){const s={...snapshot(),diff_base_sha};add(s,[{id:'file:0',file:s.files[0]}]);}
 for(const patch of [true,1,{},[]]){const s=snapshot();s.files[0].patch=patch;add(s,[{id:'file:0',file:s.files[0]}]);}
 const results=probe(inputs);assert.equal(results.length,inputs.length);
 results.forEach((value,i)=>{
  if(expected[i].error){assert.equal(typeof value.error,'string',`case ${i} should fail`);if(expected[i].error==='Missing captured PR diff base.')assert.equal(value.error,expected[i].error);return;}
  assert.equal(value.error,undefined,`case ${i}: ${value.error}`);
  let prompt;try{prompt=promptValue(value);}catch(error){throw new Error(`case ${i}: ${value.payloadJson}`,{cause:error});}
  assert.equal(prompt,expected[i].prompt,`prompt bytes for case ${i}`);
  // Payload boundaries are taken from the oracle, not inferred from untrusted
  // embedded newline characters (JSON.stringify permits U+2028/U+2029).
  const at=expected[i].prompt.lastIndexOf('\n')+1;
  assert.deepEqual(JSON.parse(prompt.slice(at)),JSON.parse(expected[i].prompt.slice(at)),`assignment ${i}`);
  assert.ok(Buffer.byteLength(value.prefix)-Buffer.byteLength(inputs[i].payload.original)<4096,'Fixed trusted protocol stays below the documented allowance');
 });
});

test('prompt requests use the same persistent queue and cannot advance acceptance',{timeout:15000},async t=>{
 const s=snapshot(),session=startContinuationSession(),deadline=Date.now()+12000;let finished=false;
 t.after(async()=>{if(!finished)await session.close().catch(()=>{});});
 await session.request('initialize',{snapshot:s,snapshotHash:snapshotDigest(s)},{deadline});
 const nonce='2'.repeat(32),assignment=(await session.request('next',{nonce},{deadline})).value;
 const batch=[{id:'file:0',file:s.files[0]}],original='Trusted rules.\u0000😀\ud800'.repeat(1000);
 const prompt=await native.workerPrompt(original,s,batch,nonce,{session,deadline,attempt_id:assignment.attempt_id});
 const payload=native.encodeWorkerPromptRequest(original,s,batch,nonce);
 const again=await session.request('worker-prompt',{...payload,attempt_id:assignment.attempt_id},{deadline,maxResponseBytes:finalResponseBudget});
 assert.equal(prompt,promptValue(again.value));assert.ok(again.wireBytes>4096,'Exercise the new transport, not only a pure policy probe');
 const results=[{id:'file:0',status:'complete',reasoning:'read',findings:[],action:'none'}];
 const delta=await session.request('complete',{attempt_id:assignment.attempt_id,nonce,deliveryVerified:true,response:{results}},{deadline,maxResponseBytes:completeResponseBudget});
 assert.equal(delta.value.remaining,0);assert.deepEqual(delta.value.attempt.assigned,['file:0']);
 const outputs=await session.request('finish',{},{deadline,maxResponseBytes:finalResponseBudget(delta.wireBytes)});assert.equal(outputs.value.length,1);
 await session.close();finished=true;
});

for(const mutation of ['attempt','nonce','batch','snapshot'])test(`prompt rejects a mismatched ${mutation} without publishing`,{timeout:10000},async()=>{
 const s=snapshot(),session=startContinuationSession(),deadline=Date.now()+8000;
 try{
  await session.request('initialize',{snapshot:s,snapshotHash:snapshotDigest(s)},{deadline});
  const nonce='3'.repeat(32),assignment=(await session.request('next',{nonce},{deadline})).value;
  const payload={...native.encodeWorkerPromptRequest('rules',s,[{id:'file:0',file:s.files[0]}],nonce),attempt_id:assignment.attempt_id};
  if(mutation==='attempt')payload.attempt_id++;
  if(mutation==='nonce')payload.nonce='4'.repeat(32);
  if(mutation==='batch')payload.batch[0].file={...s.files[0],patch:'forged'};
  if(mutation==='snapshot')payload.snapshot.head_sha='e'.repeat(40);
  await assert.rejects(session.request('worker-prompt',payload,{deadline,maxResponseBytes:finalResponseBudget}),/active assignment|nonce|captured snapshot/i);
  await assert.rejects(session.close(),/active assignment|nonce|captured snapshot/i);
 }finally{await session.close().catch(()=>{});}
});

for(const mode of ['invalid-shape','invalid-json','flood','stall'])test(`new prompt transport fails closed on ${mode}`,{skip:process.platform==='win32',timeout:6000},async t=>{
 const fs=require('node:fs'),os=require('node:os'),dir=fs.mkdtempSync(path.join(os.tmpdir(),'prompt-transport-')),host=path.join(dir,'host');
 t.after(()=>fs.rmSync(dir,{recursive:true,force:true}));restoreEnv(t,'GH_AW_REVIEW_PWSH',host);
 fs.writeFileSync(host,`#!/usr/bin/env node
 const fs=require('node:fs'),readline=require('node:readline');
 readline.createInterface({input:process.stdin}).on('line',line=>{
  const r=JSON.parse(line);let result;
  if(r.operation==='initialize')result={work_count:1,checkpoint:{head_sha:r.payload.snapshot.head_sha,base_sha:r.payload.snapshot.base_sha,snapshot_sha256:r.payload.snapshotHash,results:[],attempts:[]}};
  else if(r.operation==='next')result={complete:false,attempt_id:1,nonce:r.payload.nonce,ids:['file:0']};
  else if(r.operation==='worker-prompt'){
   fs.writeFileSync(${JSON.stringify(path.join(dir,'prompt-request'))},'seen');
   if(${JSON.stringify(mode)}==='stall')return;
   if(${JSON.stringify(mode)}==='flood'){process.stdout.write('x'.repeat(1024*1024));return;}
   result=${mode==='invalid-shape'?'{prefix:42,payloadJson:"{}"}':'{prefix:"rules",payloadJson:"not json"}'};
  }else throw new Error('No completion/finalization is authorized after a failed prompt');
  process.stdout.write(JSON.stringify({id:r.id,result})+'\\n');
 });`,{mode:0o755});
 let workerStarted=false,published=false;
 await assert.rejects(native.runReview(snapshot(),{deadline:Date.now()+(mode==='stall'?750:4000),runBatch:async(_batch,_deadline,_signal,{workerPrompt})=>{
  await workerPrompt('Trusted rules.');workerStarted=true;throw new Error('Worker must not start');
 }}).then(value=>{published=true;return value;}),/prompt response|JSON|derived budget|deadline/i);
 assert.equal(workerStarted,false);assert.equal(published,false);assert.ok(fs.existsSync(path.join(dir,'prompt-request')),'Exercise the new request rather than an initialization failure');
});

test('unchanged native response normalization matches the frozen oracle',()=>{
 const result={results:[{id:'file:0',status:'complete',reasoning:'reviewed',findings:[],action:'none'}]},event=content=>JSON.stringify({type:'assistant.message',data:{content}});
 const outputs=[event(JSON.stringify(result)),event('```json\n'+JSON.stringify(result)+'\n```'),event('\ufeff ```\r\n'+JSON.stringify(result)+'\r\n``` \ufeff'),event('Too much work.'),event(JSON.stringify('Too much work.')),event('{"reason":"declined","results":null}'),event('{}'),event('null'),event('false'),event('[1,2]'),event('{not JSON}'),event('x'.repeat(1999)+'😀tail'),event(JSON.stringify('x'.repeat(1999)+'😀tail')),event(''),event('   '),'not-json\n'+event(JSON.stringify(result))+'\n{bad',JSON.stringify({type:'tool.execution_complete',data:{content:JSON.stringify(result)}}),event(JSON.stringify(result))+'\n'+event('declined'),event(JSON.stringify({results:[],reason:'x',value:1e21,date:'2026-01-02',unicode:'\ud800😀'}))];
 for(const output of outputs)assert.deepEqual(native.parseWorkerResult(output),reference.parseWorkerResult(output));
 // Preserve even the old parser's error for a valid JSON null outer event;
 // normalization is deliberately not being changed by this prompt-only port.
 for(const output of ['null','null\n'+event(JSON.stringify(result))]){
  let expected;try{reference.parseWorkerResult(output);}catch(error){expected=error;}
  assert.ok(expected);assert.throws(()=>native.parseWorkerResult(output),error=>error.constructor===expected.constructor&&error.message===expected.message);
 }
 const large={results:[{id:'file:0',status:'complete',reasoning:'read',findings:[{path:'src/f.cs',line:1,body:'漢'.repeat(4*1024*1024)+'😀\ud800'}],action:'none'}]};
 const largeEvent=event(JSON.stringify(large));assert.ok(largeEvent.length<8*1024*1024);assert.ok(Buffer.byteLength(largeEvent)>8*1024*1024);
 assert.deepEqual(native.parseWorkerResult(largeEvent),reference.parseWorkerResult(largeEvent));
 const tail=('x'.repeat(8*1024*1024)+'\n'+largeEvent).slice(-8*1024*1024);assert.deepEqual(native.parseWorkerResult(tail),large);assert.deepEqual(native.parseWorkerResult(tail),reference.parseWorkerResult(tail));
 const oversized=event('x'.repeat(8*1024*1024)).slice(-8*1024*1024);assert.deepEqual(native.parseWorkerResult(oversized),{results:[]});
});

test('persistent prompt host preserves a short isolated-surrogate key while offloading',{timeout:10000},async()=>{
 const s=snapshot();s.files=[{filename:'f.cs','\ud800':'preserve this property',status:'modified',patch:'x'.repeat(48001)}];
 const session=startContinuationSession(),deadline=Date.now()+8000;
 try{
  await session.request('initialize',{snapshot:s,snapshotHash:snapshotDigest(s)},{deadline});
  const nonce='a'.repeat(32),assignment=(await session.request('next',{nonce},{deadline})).value,batch=[{id:'file:0',file:s.files[0]}];
  const prompt=await native.workerPrompt('rules',s,batch,nonce,{session,deadline,attempt_id:assignment.attempt_id});
  const data=JSON.parse(prompt.slice(prompt.lastIndexOf('\n')+1)),file=data.assigned[0].file;
  assert.equal(file['\ud800'],'preserve this property');assert.equal(Object.hasOwn(file,'patch'),false);assert.equal(typeof file.patch_path,'string');
  await assert.rejects(session.request('finish',{},{deadline}),/incomplete/i);
  await assert.rejects(session.close(),/incomplete/i);
 }finally{await session.close().catch(()=>{});}
});
