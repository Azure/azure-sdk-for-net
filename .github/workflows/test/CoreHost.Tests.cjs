'use strict';
const assert=require('node:assert/strict');
const {test}=require('node:test');
const {startContinuationSession,completeResponseBudget,finalResponseBudget,addCompleteWireBytes}=require('../pr-re-review/ReviewContinuationSession.cjs');
const {buildOutputs}=require('./TestContinuationReference.cjs');
const {snapshotDigest}=require('./ReviewDelivery.cjs');
const snapshot=()=>({head_sha:'a'.repeat(40),base_sha:'b'.repeat(40),pull_number:1,changed_files:1,files:[{filename:'f.cs',status:'modified',patch:'diff'}],threads:[],reviews:[]});
async function initialize(session,s,deadline){return (await session.request('initialize',{snapshot:s,snapshotHash:snapshotDigest(s)},{deadline})).value;}

test('one host owns state across document disposal and revalidates final outputs', {timeout:30000},async()=>{
 const s=snapshot(),session=startContinuationSession(),deadline=Date.now()+25000;let bytes=0;
 try {
  const init=await initialize(session,s,deadline);assert.equal(init.work_count,1);assert.deepEqual(init.checkpoint.results,[]);
  const nonce='1'.repeat(32),assignment=(await session.request('next',{nonce},{deadline})).value;
  const results=[{id:assignment.ids[0],status:'complete',reasoning:'read',findings:[],action:'none'}];
  const delta=await session.request('complete',{attempt_id:assignment.attempt_id,nonce,deliveryVerified:true,response:{results}},{deadline,maxResponseBytes:completeResponseBudget});
  assert.equal(delta.value.remaining,0);assert.equal(delta.value.accepted.length,1);assert.equal(Object.hasOwn(delta.value,'results'),false);
  bytes=addCompleteWireBytes(bytes,delta.wireBytes);
  delta.value.accepted[0].reasoning='invented diagnostic copy';
  const final=(await session.request('finish',{},{deadline,maxResponseBytes:finalResponseBudget(bytes)})).value;
  assert.deepEqual(final,buildOutputs(s,{results}));
 } finally {await session.close();}
});

test('unverified delivery fails the host without committing or allowing finalization', {timeout:10000},async()=>{
 const s=snapshot(),session=startContinuationSession(),deadline=Date.now()+8000;
 await initialize(session,s,deadline);const nonce='1'.repeat(32),assignment=(await session.request('next',{nonce},{deadline})).value;
 await assert.rejects(session.request('complete',{attempt_id:assignment.attempt_id,nonce,deliveryVerified:false,response:{results:[]}},{deadline,maxResponseBytes:completeResponseBudget}),/verified delivery/i);
 await assert.rejects(session.close(),/verified delivery/i);
});

test('closing an unfinished queue cannot masquerade as clean finalization', {timeout:10000},async()=>{
 const session=startContinuationSession();await initialize(session,snapshot(),Date.now()+8000);
 await assert.rejects(session.close(),/closed before verified finalization|unexpected/i);
});

test('large UTF-16 worker content is not constrained by the former 4-KiB reply cap', {timeout:90000},async()=>{
 const s=snapshot(),session=startContinuationSession(),deadline=Date.now()+85000;
 const body='漢'.repeat(4*1024*1024)+'😀\ud800';
 const results=[{id:'file:0',status:'complete',reasoning:'read',findings:[{path:'f.cs',line:1,body}],action:'none'}];
 const event=JSON.stringify({type:'assistant.message',data:{content:JSON.stringify({results})}});
 assert.ok(event.length < 8*1024*1024,'Fixture must fit the original UTF-16 parsing tail');
 assert.ok(Buffer.byteLength(event)>8*1024*1024,'Fixture must exceed a naive UTF-8 8-MiB limit');
 try {
  await initialize(session,s,deadline);const nonce='1'.repeat(32),assignment=(await session.request('next',{nonce},{deadline})).value;
  const delta=await session.request('complete',{attempt_id:assignment.attempt_id,nonce,deliveryVerified:true,response:{results}},{deadline,maxResponseBytes:completeResponseBudget});
  assert.equal(delta.value.accepted[0].findings[0].body,body);
  assert.ok(delta.wireBytes>8*1024*1024);
  const final=(await session.request('finish',{},{deadline,maxResponseBytes:finalResponseBudget(delta.wireBytes)})).value;
  assert.deepEqual(final,buildOutputs(s,{results}));
 } finally {await session.close();}
});

test('attempt deltas stay bounded by each request as diagnostic history grows', {timeout:30000},async()=>{
 const s=snapshot(),session=startContinuationSession(),deadline=Date.now()+25000,reason='r'.repeat(40000);let bytes=0;
 try {
  await initialize(session,s,deadline);
  for(let i=0;i<20;i++){
   const nonce=(i+1).toString(16).padStart(32,'0'),assignment=(await session.request('next',{nonce},{deadline})).value;
   const delta=await session.request('complete',{attempt_id:assignment.attempt_id,nonce,deliveryVerified:true,response:{results:[],reason}},{deadline,maxResponseBytes:completeResponseBudget});
   assert.equal(delta.value.remaining,1);assert.equal(delta.value.attempt.reason,reason);assert.ok(delta.wireBytes<reason.length+1000,'Do not resend the accumulated checkpoint');bytes=addCompleteWireBytes(bytes,delta.wireBytes);
  }
  const nonce='f'.repeat(32),assignment=(await session.request('next',{nonce},{deadline})).value;
  const results=[{id:'file:0',status:'complete',reasoning:'done',findings:[],action:'none'}];
  const delta=await session.request('complete',{attempt_id:assignment.attempt_id,nonce,deliveryVerified:true,response:{results}},{deadline,maxResponseBytes:completeResponseBudget});bytes=addCompleteWireBytes(bytes,delta.wireBytes);
  const final=(await session.request('finish',{},{deadline,maxResponseBytes:finalResponseBudget(bytes)})).value;assert.deepEqual(final,buildOutputs(s,{results}));
 } finally {await session.close();}
});

test('byte accounting rejects overflow instead of silently rounding or imposing a hidden aggregate cap',()=>{
 assert.throws(()=>completeResponseBudget(Number.MAX_SAFE_INTEGER),/overflow/i);
 assert.throws(()=>finalResponseBudget(Infinity),/accounting/i);
 assert.throws(()=>addCompleteWireBytes(Number.MAX_SAFE_INTEGER,1),/overflow/i);
 assert.ok(completeResponseBudget(32*1024*1024)>32*1024*1024);
 assert.ok(finalResponseBudget(128*1024*1024)>128*1024*1024);
});

test('final response budget includes substantial accepted findings and replies from multiple completes',{timeout:60000},async()=>{
 const s=snapshot();s.files=Array.from({length:10},(_,i)=>({filename:`f${i}.cs`,status:'modified',patch:'diff'}));s.changed_files=10;
 s.threads=Array.from({length:10},(_,i)=>({id:`t${i}`,isResolved:false,comments:[{databaseId:i+1,path:'f.cs',body:'old'}]}));
 const session=startContinuationSession(),deadline=Date.now()+55000,body='漢'.repeat(256*1024)+'😀';let bytes=0,calls=0;const accepted=[];
 try {
  await initialize(session,s,deadline);
  while(true){
   const nonce=(calls+1).toString(16).padStart(32,'0'),assignment=(await session.request('next',{nonce},{deadline})).value;
   if(assignment.complete)break;
   const results=assignment.ids.map(id=>({id,status:'complete',reasoning:'read',findings:id.startsWith('file:')?[{path:s.files[Number(id.slice(5))].filename,line:1,body}]:[],action:'none',...(id.startsWith('thread:')?{reply:body}:{})}));
   const delta=await session.request('complete',{attempt_id:assignment.attempt_id,nonce,deliveryVerified:true,response:{results}},{deadline,maxResponseBytes:completeResponseBudget});
   bytes=addCompleteWireBytes(bytes,delta.wireBytes);accepted.push(...delta.value.accepted);calls++;
  }
  assert.equal(calls,4);assert.ok(bytes>15*1024*1024);
  const final=(await session.request('finish',{},{deadline,maxResponseBytes:finalResponseBudget(bytes)})).value;
  assert.equal(final.length,21);assert.deepEqual(final,buildOutputs(s,{results:accepted}));
 } finally {await session.close();}
});
