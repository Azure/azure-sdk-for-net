'use strict';
const assert=require('node:assert/strict');
const {test}=require('node:test');
const {runReview,assertPublication}=require('../pr-re-review/ReviewContinuation.cjs');
const {buildOutputs}=require('./TestContinuationReference.cjs');
function snapshot(){return {head_sha:'a'.repeat(40),base_sha:'b'.repeat(40),pull_number:1,changed_files:1,files:[{filename:'f.cs',status:'modified',patch:'diff'}],threads:[]};}
const completion=id=>({id,status:'complete',reasoning:'read',findings:[],action:'none'});

test('native bridge keeps ignored response data out of policy transport', {timeout:15000},async()=>{
 const s=snapshot();let deep={leaf:'ignored'};for(let i=0;i<10000;i++)deep={nested:deep};
 const r=await runReview(s,{deadline:Date.now()+10000,runBatch:async batch=>({response:{results:batch.map(item=>completion(item.id)),reason:deep,ignored:deep},receipts:[]})});
 assert.equal(r.ledger.attempts[0].reason,'');assert.equal(r.ledger.results.length,1);assert.deepEqual(r.outputs,buildOutputs(s,r.ledger));
 await assert.doesNotReject(assertPublication(s,r.ledger,{items:r.outputs,errors:[]},'success'));
});

test('diagnostic checkpoints cannot advance the private host queue', {timeout:15000},async()=>{
 const s=snapshot();s.files.push({filename:'other.cs',status:'modified',patch:'diff'});s.changed_files=2;
 let calls=0;
 const r=await runReview(s,{deadline:Date.now()+10000,checkpoint:copy=>{copy.results.push(completion('invented'));copy.attempts.length=0;},runBatch:async batch=>{calls++;return {response:{results:batch.map(item=>completion(item.id))},receipts:[]};}});
 assert.equal(calls,1);assert.deepEqual(r.ledger.results.map(item=>item.id),['file:0','file:1']);assert.equal(r.ledger.attempts.length,1);
});

test('unverified thread input cannot be authorized by worker verification fields', {timeout:15000},async()=>{
 const s=snapshot();s.threads=[{id:'one',isResolved:false,comments:[{databaseId:1,body:'prior concern',path:'f.cs'}]}];
 await assert.rejects(runReview(s,{deadline:Date.now()+10000,runBatch:async batch=>({response:{results:batch.map(item=>({...completion(item.id),deliveryVerified:true})),deliveryVerified:true,operation:'complete'},receipts:[]})}),/delivery/i);
});
