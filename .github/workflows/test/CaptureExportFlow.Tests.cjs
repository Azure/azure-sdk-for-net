'use strict';
const assert=require('node:assert/strict');
const {test}=require('node:test');
const fs=require('node:fs'),path=require('node:path'),os=require('node:os');
const {captureWorkflowInputs}=require('../pr-re-review/ReviewSnapshot.cjs');
test('one capture-policy session preserves manifest and snapshot writes before real export',{skip:process.platform==='win32',timeout:20000},async t=>{
 const dir=fs.mkdtempSync(path.join(os.tmpdir(),'capture-export-')),wrapper=path.join(dir,'pwsh'),log=path.join(dir,'processes');
 const prior=process.env.GH_AW_REVIEW_PWSH,real=prior||'pwsh';
 fs.writeFileSync(wrapper,'#!/usr/bin/env node\n'+`const fs=require('node:fs'),path=require('node:path'),{spawn}=require('node:child_process');const script=process.argv.find(a=>a.endsWith('.ps1'));fs.appendFileSync(${JSON.stringify(log)},path.basename(script)+'\\n');const child=spawn(${JSON.stringify(real)},process.argv.slice(2),{stdio:'inherit'});child.on('error',e=>{console.error(e);process.exitCode=1;});child.on('exit',(code,signal)=>{process.exitCode=signal?1:code;});`,{mode:0o755});
 process.env.GH_AW_REVIEW_PWSH=wrapper;
 t.after(()=>{if(prior===undefined)delete process.env.GH_AW_REVIEW_PWSH;else process.env.GH_AW_REVIEW_PWSH=prior;fs.rmSync(dir,{recursive:true,force:true});});
 const head='a'.repeat(40),base='b'.repeat(40),merge='c'.repeat(40),calls=[];
 const files=[{filename:'f.cs',status:'modified',patch:'diff 😀\ud800'}];
 const pr={state:'open',draft:false,head:{sha:head,repo:{full_name:'Fork/repo'}},base:{sha:base,repo:{full_name:'Azure/repo'}},changed_files:1};
 const github={rest:{pulls:{get:async()=>{calls.push('pull');return {data:pr};},listFiles:async()=>{calls.push('files');return {data:files};},listReviews:()=>{}}},graphql:async()=>{calls.push('threads');return {repository:{pullRequest:{reviewThreads:{totalCount:1,nodes:[{id:'one',isResolved:false,comments:{nodes:[{databaseId:1,body:'prior'}],pageInfo:{hasNextPage:false}}}],pageInfo:{hasNextPage:false}}}}};},paginate:async()=>{calls.push('reviews');return [{id:1,state:'COMMENTED',body:'review'}];},request:async()=>{calls.push('compare');return {data:{base_commit:{sha:base},merge_base_commit:{sha:merge}}};}};
 const root=path.join(dir,'snapshot.json'),manifestFile=path.join(dir,'files.json'),context=path.join(dir,'review-input');
 const result=await captureWorkflowInputs(github,{owner:'Azure',repo:'repo',pullNumber:1,headSha:head},{
  onManifest:copy=>{calls.push('manifest');fs.writeFileSync(manifestFile,JSON.stringify(copy));copy.files[0].filename='mutated-manifest-copy';},
  onSnapshot:copy=>{calls.push('snapshot');assert.equal(fs.existsSync(path.join(context,'snapshot.json')),false,'Snapshot checkpoint must precede export');fs.writeFileSync(root,JSON.stringify(copy));copy.files[0].filename='mutated-snapshot-copy';},
  runBaseline:async()=>{calls.push('baseline');return {stdout:'[]'};},exportDirectory:context,
 });
 assert.deepEqual(calls,['pull','files','pull','manifest','pull','threads','reviews','pull','compare','baseline','snapshot']);
 assert.equal(result.snapshot.files[0].filename,'f.cs');assert.equal(fs.readFileSync(root,'utf8'),JSON.stringify(result.snapshot));assert.equal(fs.readFileSync(manifestFile,'utf8'),JSON.stringify(result.manifest));
 assert.deepEqual(JSON.parse(fs.readFileSync(path.join(context,'snapshot.json'),'utf8')),result.snapshot);
 assert.deepEqual(fs.readFileSync(log,'utf8').trim().split('\n'),['ReviewCaptureHost.ps1','Export-ReviewContext.ps1'],'One policy host plus the existing bounded exporter, never a new policy process per phase');
});
