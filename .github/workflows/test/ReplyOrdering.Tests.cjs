'use strict';
const {test}=require('node:test'); const assert=require('node:assert/strict'); const path=require('node:path');
const {buildOutputs}=require('./TestContinuationPolicy.cjs');
const actions=process.env.GH_AW_TEST_ACTIONS_DIR;assert.ok(actions,'Pinned handler manager required.');
test('real manager never resolves after a failed reply; resolution is delegated to the applied-reply guard',async()=>{
 global.core={info:()=>{},warning:()=>{},error:()=>{},debug:()=>{},setOutput:()=>{}};
 const previous=process.env.GH_AW_SAFE_OUTPUT_JOBS;
 process.env.GH_AW_SAFE_OUTPUT_JOBS=JSON.stringify({unresolve_review_thread:''});
 const snapshot={pull_number:1,head_sha:'a'.repeat(40),base_sha:'b'.repeat(40),changed_files:0,files:[],threads:[{id:'thread',isResolved:false,comments:[{databaseId:123}]}]};
 const items=buildOutputs(snapshot,{results:[{id:'thread:0',status:'complete',reasoning:'Verified addressed.',findings:[],action:'resolve',reply:'Addressed in the current source.'}]});
 let resolutions=0;
 const handlers=new Map([
  ['reply_to_pull_request_review_comment',async()=>{throw new Error('Simulated reply API failure');}],
  ['resolve_pull_request_review_thread',async()=>{resolutions++;return {success:true};}],
  ['submit_pull_request_review',async()=>({success:true})],
 ]);
 try {
  const {processMessages}=require(path.join(actions,'safe_output_handler_manager.cjs'));
  const result=await processMessages(handlers,items);
  assert.equal(resolutions,0);
  assert.ok(result.results.some(r=>r.type==='unresolve_review_thread'&&r.delegated));
  assert.ok(result.results.some(r=>r.type==='reply_to_pull_request_review_comment'&&!r.success));
 } finally {if(previous===undefined)delete process.env.GH_AW_SAFE_OUTPUT_JOBS;else process.env.GH_AW_SAFE_OUTPUT_JOBS=previous;}
});
