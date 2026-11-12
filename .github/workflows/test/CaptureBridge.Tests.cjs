'use strict';
const assert=require('node:assert/strict');
const {test}=require('node:test');
const fs=require('node:fs'),path=require('node:path'),os=require('node:os');
const {captureChangedFiles,captureReviewState}=require('../pr-re-review/ReviewSnapshot.cjs');
const head='a'.repeat(40),base='b'.repeat(40);
function monitor(t){
 const directory=fs.mkdtempSync(path.join(os.tmpdir(),'capture-host-')),wrapper=path.join(directory,'pwsh'),log=path.join(directory,'spawn.jsonl');
 const previous=process.env.GH_AW_REVIEW_PWSH,token=process.env.GH_TOKEN,secret=process.env.CAPTURE_TEST_SECRET;
 fs.writeFileSync(wrapper,'#!/usr/bin/env node\n'+`const fs=require('node:fs'),{spawn}=require('node:child_process');fs.appendFileSync(${JSON.stringify(log)},JSON.stringify({tokenPresent:!!process.env.GH_TOKEN,secretPresent:!!process.env.CAPTURE_TEST_SECRET})+'\\n');const c=spawn(${JSON.stringify(previous||'pwsh')},process.argv.slice(2),{stdio:'inherit'});c.on('error',e=>{console.error(e);process.exitCode=1;});c.on('exit',(code,signal)=>{process.exitCode=signal?1:code;});`,{mode:0o755});
 process.env.GH_AW_REVIEW_PWSH=wrapper;process.env.GH_TOKEN='synthetic-test-token';process.env.CAPTURE_TEST_SECRET='synthetic-test-secret';
 t.after(()=>{for(const [name,value]of [['GH_AW_REVIEW_PWSH',previous],['GH_TOKEN',token],['CAPTURE_TEST_SECRET',secret]])if(value===undefined)delete process.env[name];else process.env[name]=value;fs.rmSync(directory,{recursive:true,force:true});});
 return ()=>{const rows=fs.readFileSync(log,'utf8').trim().split('\n').map(JSON.parse);assert.equal(rows.length,1,'One persistent policy process, not a process per page');assert.deepEqual(rows[0],{tokenPresent:false,secretPresent:false});};
}
function pull(){return {state:'open',draft:false,head:{sha:head,repo:{full_name:'Fork/repo'}},base:{sha:base,repo:{full_name:'Azure/repo'}},changed_files:1};}
function client(){
 const calls=[],threads=Array.from({length:106},(_,i)=>({id:`thread-${i}`,isResolved:false,comments:{nodes:[{databaseId:1000+i,body:'prior 😀\ud800',publishedAt:'2026-01-02T03:04:05.000Z'}],pageInfo:{hasNextPage:false,endCursor:null}}}));
 threads[0].comments={nodes:Array.from({length:100},(_,i)=>({databaseId:10000+i,body:'prior'})),pageInfo:{hasNextPage:true,endCursor:'next-comments'}};
 const listReviews=()=>{throw Error('Use original paginate helper');};
 const github={rest:{pulls:{get:async()=>{calls.push('pull');return {data:pull()};},listReviews}},graphql:async(query,args)=>{
  if(query.startsWith('query($id:')){calls.push('comments');assert.equal(args.id,'thread-0');return {node:{comments:{nodes:Array.from({length:6},(_,i)=>({databaseId:10100+i,body:'reply'})),pageInfo:{hasNextPage:false,endCursor:null}}}};}
  calls.push('threads');const next=args.after!==null;return {repository:{pullRequest:{reviewThreads:{totalCount:106,nodes:next?threads.slice(100):threads.slice(0,100),pageInfo:{hasNextPage:!next,endCursor:next?null:'next-threads'}}}}};
 },paginate:async(method,args)=>{calls.push('reviews');assert.equal(method,listReviews);assert.equal(args.per_page,100);return Array.from({length:150},(_,i)=>({id:i+1,state:'COMMENTED',body:'old',submitted_at:'2026-01-02T03:04:05.000Z',user:{login:'reviewer'}}));}};
 return {github,calls};
}
for(const options of [{},{includeReviews:false},{preflight:true}])test(`one private host captures complete histories ${JSON.stringify(options)}`,{skip:process.platform==='win32',timeout:15000},async t=>{
 const verify=monitor(t),{github,calls}=client();
 const files={pull_number:1,head_sha:head,base_sha:base,changed_files:1,files:[{filename:'f.cs',patch:'diff'}]};
 const result=await captureReviewState(github,{owner:'Azure',repo:'repo'},files,options);
 assert.equal(result.threads.length,106);assert.equal(result.threads[0].comments.length,106);assert.equal(result.reviews.length,options.includeReviews===false?0:150);assert.equal(result.head_repo,'Fork/repo');
 assert.equal(result.threads[105].comments[0].body,'prior 😀\ud800');
 assert.deepEqual(calls,[...(options.preflight?['pull']:[]),'pull','threads','comments','threads',...(options.includeReviews===false?[]:['reviews']),'pull']);verify();
});
test('one private host captures changed-file pages without inferring omitted patches',{skip:process.platform==='win32',timeout:15000},async t=>{
 const verify=monitor(t),calls=[],files=Array.from({length:106},(_,i)=>({filename:`f${i}.cs`,status:i===105?'renamed':'modified',...(i?{patch:'diff'}:{}),...(i===105?{previous_filename:'old.cs'}:{})}));
 const github={rest:{pulls:{get:async()=>{calls.push('pull');return {data:{...pull(),changed_files:106}};},listFiles:async args=>{calls.push(args.page);return {data:files.slice((args.page-1)*100,args.page*100)};}}}};
 const result=await captureChangedFiles(github,{owner:'Azure',repo:'repo',pullNumber:1,headSha:head});assert.deepEqual(result.files,files);assert.equal(Object.hasOwn(result.files[0],'patch'),false);assert.deepEqual(calls,['pull',1,2,'pull']);verify();
});

test('a policy drain error permanently rejects its private session',{timeout:10000},async()=>{
 const {startContinuationSession}=require('../pr-re-review/ReviewContinuationSession.cjs');
 const session=startContinuationSession({script:'ReviewCaptureHost.ps1'});
 try{
  const files={pull_number:1,head_sha:head,base_sha:base,changed_files:1,files:[]};
  await session.request('initialize',{mode:'review',repo:{owner:'Azure',repo:'repo'},files});
  let e=(await session.request('next',{})).value.effect;
  await session.request('accept',{effect_id:e.effect_id,response:pull()});
  e=(await session.request('next',{})).value.effect;
  const valid={id:'one',isResolved:false,comments:{nodes:[{databaseId:1}],pageInfo:{hasNextPage:false}}};
  await session.request('accept',{effect_id:e.effect_id,response:{repository:{pullRequest:{reviewThreads:{totalCount:1,nodes:[valid,null],pageInfo:{hasNextPage:false}}}}}});
  await assert.rejects(session.request('next',{}),/invalid or duplicate thread/i);
  await assert.rejects(session.request('next',{}),/invalid or duplicate thread/i);
  await assert.rejects(session.request('finish',{}),/invalid or duplicate thread/i);
  await assert.rejects(session.close(),/invalid or duplicate thread/i);
 }finally{await session.close().catch(()=>{});}
});

test('whole workflow capture keeps one policy host across manifest, history, merge base and inventory',{skip:process.platform==='win32',timeout:15000},async t=>{
 const verify=monitor(t),{captureWorkflowInputs}=require('../pr-re-review/ReviewSnapshot.cjs'),calls=[];
 const files=Array.from({length:106},(_,i)=>({filename:`f${i}.cs`,status:i===0?'renamed':'modified',...(i===0?{previous_filename:'old.cs'}:{}),patch:'diff'}));
 const github={rest:{pulls:{
  get:async()=>{calls.push('pull');return {data:{...pull(),changed_files:106}};},
  listFiles:async args=>{calls.push('files:'+args.page);return {data:files.slice((args.page-1)*100,args.page*100)};},
  listReviews:()=>{},
 }},graphql:async()=>{calls.push('threads');return {repository:{pullRequest:{reviewThreads:{totalCount:0,nodes:[],pageInfo:{hasNextPage:false}}}}};},
 paginate:async()=>{calls.push('reviews');return [];},
 request:async(route,args)=>{calls.push('compare');assert.equal(route,'GET /repos/{owner}/{repo}/compare/{basehead}');assert.equal(args.basehead,base+'...'+head);return {data:{base_commit:{sha:base},merge_base_commit:{sha:'c'.repeat(40)}}};}};
 let checkpoint;
 const inventory=[{filename:'Directory.Build.props',head_sha:head,added:[]}];
 const result=await captureWorkflowInputs(github,{owner:'Azure',repo:'repo',pullNumber:1,headSha:head},{
  onManifest:async manifest=>{calls.push('manifest');checkpoint=manifest;},
  runBaseline:async(script,input,options)=>{calls.push('baseline');assert.equal(script,'ReviewBaselines.ps1');assert.deepEqual(options.scriptArgs,['-Capture']);const value=JSON.parse(input);assert.equal(value.snapshot.diff_base_sha,'c'.repeat(40));assert.deepEqual(value.snapshot.files[0],{filename:'f0.cs',previous_filename:'old.cs',status:'renamed'});assert.equal(Object.hasOwn(value.snapshot.files[0],'patch'),false);assert.equal(Object.hasOwn(value.snapshot,'threads'),false);return {stdout:JSON.stringify(inventory)};},
 });
 assert.deepEqual(result.manifest,checkpoint);assert.equal(result.snapshot.files.length,106);assert.equal(result.snapshot.diff_base_sha,'c'.repeat(40));assert.deepEqual(result.snapshot.baseline_suppressions,inventory);
 assert.deepEqual(calls,['pull','files:1','files:2','pull','manifest','pull','threads','reviews','pull','compare','baseline']);verify();
});
