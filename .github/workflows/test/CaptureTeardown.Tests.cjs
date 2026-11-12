'use strict';
const assert=require('node:assert/strict');
const {test}=require('node:test');
const fs=require('node:fs'),path=require('node:path'),os=require('node:os');
const {captureContext,exportContext}=require('../pr-re-review/ReviewSnapshot.cjs');
function alive(pid){try{process.kill(pid,0);if(process.platform==='linux'){const stat=fs.readFileSync(`/proc/${pid}/stat`,'utf8'),end=stat.lastIndexOf(')');if(stat[end+2]==='Z')return false;}return true;}catch(error){if(['ESRCH','ENOENT'].includes(error.code))return false;throw error;}}
async function ready(file){const deadline=Date.now()+6000;while(!fs.existsSync(file)){if(Date.now()>=deadline)throw Error('Helper readiness timed out');await new Promise(resolve=>setTimeout(resolve,10));}}
for(const phase of ['baseline','export'])test(`capture does not settle before bounded ${phase} group teardown after host failure`,{skip:process.platform==='win32',timeout:15000},async t=>{
 const dir=fs.mkdtempSync(path.join(os.tmpdir(),'capture-teardown-')),exe=path.join(dir,'pwsh');
 const prior={exe:process.env.GH_AW_REVIEW_PWSH,dir:process.env.CAPTURE_TEARDOWN_DIR,token:process.env.GH_TOKEN};
 const real=prior.exe||'pwsh';
 fs.writeFileSync(exe,'#!/usr/bin/env node\n'+`
 const fs=require('node:fs'),path=require('node:path'),{spawn}=require('node:child_process'),dir=process.env.CAPTURE_TEARDOWN_DIR;
 if(process.argv.some(arg=>arg.endsWith(${JSON.stringify(phase==='baseline'?'ReviewBaselines.ps1':'Export-ReviewContext.ps1')}))){
  process.on('SIGTERM',()=>fs.writeFileSync(path.join(dir,'term'),'term'));
  const child=spawn(process.execPath,['-e',"process.on('SIGTERM',()=>{});process.send('ready');setInterval(()=>{},1000)"],{stdio:['ignore','ignore','ignore','ipc']});
  child.once('message',()=>{fs.writeFileSync(path.join(dir,'pids.tmp'),JSON.stringify({parent:process.pid,child:child.pid,tokenPresent:!!process.env.GH_TOKEN}));fs.renameSync(path.join(dir,'pids.tmp'),path.join(dir,'pids'));child.disconnect();});
  process.stdin.resume();setInterval(()=>{},1000);
 }else{
  const child=spawn(${JSON.stringify(real)},process.argv.slice(2),{stdio:'inherit'});
  const timer=setInterval(()=>{if(fs.existsSync(path.join(dir,'die'))){process.stderr.write('Capture test host failed.');process.exit(1);}},10);
  child.on('error',error=>{console.error(error);process.exitCode=1;clearInterval(timer);});child.on('exit',(code,signal)=>{clearInterval(timer);process.exitCode=signal?1:code;});
 }
 `,{mode:0o755});
 process.env.GH_AW_REVIEW_PWSH=exe;process.env.CAPTURE_TEARDOWN_DIR=dir;process.env.GH_TOKEN='synthetic-baseline-token';
 let ids;
 t.after(()=>{if(ids)for(const pid of [ids.parent,ids.child])if(Number.isSafeInteger(pid)&&pid>1)try{process.kill(pid,'SIGKILL')}catch{};for(const [name,value]of [['GH_AW_REVIEW_PWSH',prior.exe],['CAPTURE_TEARDOWN_DIR',prior.dir],['GH_TOKEN',prior.token]])if(value===undefined)delete process.env[name];else process.env[name]=value;fs.rmSync(dir,{recursive:true,force:true});});
 const head='a'.repeat(40),base='b'.repeat(40),pull={state:'open',draft:false,head:{sha:head},base:{sha:base},changed_files:0};
 const github={rest:{pulls:{get:async()=>({data:pull}),listReviews:()=>{}}},paginate:async()=>[],graphql:async()=>({repository:{pullRequest:{reviewThreads:{totalCount:0,nodes:[],pageInfo:{hasNextPage:false}}}}}),request:async()=>({data:{base_commit:{sha:base},merge_base_commit:{sha:'c'.repeat(40)}}})};
 const captured=phase==='baseline'
  ?captureContext(github,{owner:'Azure',repo:'repo'},{pull_number:1,head_sha:head,base_sha:base,changed_files:0,files:[]},{timeoutMs:10000})
  :exportContext({files:[],threads:[],reviews:[]},path.join(dir,'input'),{timeoutMs:10000});
 captured.catch(()=>{});
 await ready(path.join(dir,'pids'));ids=JSON.parse(fs.readFileSync(path.join(dir,'pids'),'utf8'));assert.equal(ids.tokenPresent,true);assert.ok(alive(ids.parent));assert.ok(alive(ids.child));
 fs.writeFileSync(path.join(dir,'die'),'exit');
 await assert.rejects(captured,/capture test host failed|host.*unexpected/i);
 assert.equal(alive(ids.parent),false,'Capture must join the supervised helper, not just initiate cancellation');
 assert.equal(alive(ids.child),false,'Capture must join owned process-group cleanup');
 assert.equal(fs.readFileSync(path.join(dir,'term'),'utf8'),'term');
});
