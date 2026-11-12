'use strict';
// Unit-test adapter only: synchronous pure-policy probes preserve the original
// regression assertions. Production uses one persistent host, not these probes.
const {spawnSync}=require('node:child_process');
const path=require('node:path'),crypto=require('node:crypto');
const native=require('../pr-re-review/ReviewContinuation.cjs');
const {snapshotDigest}=require('../pr-re-review/ReviewDelivery.cjs');
const {startContinuationSession,completeResponseBudget,finalResponseBudget,addCompleteWireBytes}=require('../pr-re-review/ReviewContinuationSession.cjs');
const snapshots=new WeakMap(),policyExecutable=process.env.GH_AW_REVIEW_PWSH||'pwsh';
function probe(input,useRuntimeExecutable=false){
 const r=spawnSync(useRuntimeExecutable?(process.env.GH_AW_REVIEW_PWSH||'pwsh'):policyExecutable,['-NoLogo','-NoProfile','-NonInteractive','-File',path.join(__dirname,'Invoke-ContinuationCore.ps1')],{input:JSON.stringify([input]),encoding:'utf8',timeout:30000,maxBuffer:128*1024*1024});
 if(r.error)throw r.error;if(r.status!==0)throw Error(r.stderr||'Policy probe failed.');
 const values=JSON.parse(r.stdout);if(!Array.isArray(values)||values.length!==1)throw Error('Invalid batch selection output.');
 if(values[0].error)throw Error(values[0].error);return values[0];
}
function makeWorklist(snapshot){const work=probe({snapshot}).work;snapshots.set(work,snapshot);return work;}
function buildOutputs(snapshot,ledger){return probe({mode:'outputs',snapshot,ledger}).outputs;}
function assertPublication(snapshot,progress,output,agentResult){return probe({mode:'publication',...native.encodePublicationRequest(snapshot,progress,output,agentResult)});}
async function nextBatch(work,{maxItems=8,maxBytes=48000}={}){
 try {const value=probe({mode:'batch',work,maxItems,maxBytes},true);if(!Number.isInteger(value.count)||value.count<0||value.count>Math.min(work.length,maxItems)||(work.length&&value.count===0))throw Error('Invalid batch selection output.');return work.slice(0,value.count);}
 catch(error){throw Error(`Invalid batch selection output: ${error.message}`);}
}
async function runQueue(work,{deadline,runBatch,checkpoint=()=>{}}){
 // This is a policy-unit driver, not a production effects implementation. It
 // supplies verified=true deliberately; Runtime.Tests/RuntimeBridge.Tests test
 // real receipt verification before the production bridge may supply it.
 const snapshot=snapshots.get(work);if(!snapshot)throw Error('Missing test snapshot binding.');
 if(Date.now()>=deadline)throw Error('Review deadline exhausted.');
 const session=startContinuationSession(),items=new Map(work.map(item=>[item.id,item]));let failure,bytes=0;
 const ledger={results:[],attempts:[]};
 try {
  await session.request('initialize',{snapshot,snapshotHash:snapshotDigest(snapshot)},{deadline});checkpoint(structuredClone(ledger));
  while(true){
   if(Date.now()>=deadline)throw Error('Review deadline exhausted.');
   const nonce=crypto.randomBytes(16).toString('hex'),assignment=(await session.request('next',{nonce},{deadline})).value;
   if(assignment.complete)break;
   const response=await runBatch(assignment.ids.map(id=>items.get(id)),deadline,session.signal);
   if(Date.now()>=deadline)throw Error('Review deadline exhausted.');
   const delta=await session.request('complete',{attempt_id:assignment.attempt_id,nonce,deliveryVerified:true,response},{deadline,maxResponseBytes:completeResponseBudget});
   bytes=addCompleteWireBytes(bytes,delta.wireBytes);ledger.results.push(...delta.value.accepted);ledger.attempts.push(delta.value.attempt);checkpoint(structuredClone(ledger));
  }
  await session.request('finish',{},{deadline,maxResponseBytes:finalResponseBudget(bytes)});
 }catch(error){failure=error;throw error;}
 finally{try{await session.close();}catch(error){if(!failure)throw error;}}
 return ledger;
}
module.exports={...native,makeWorklist,buildOutputs,assertPublication,nextBatch,runQueue};
