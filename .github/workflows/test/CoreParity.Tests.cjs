'use strict';
const assert = require('node:assert/strict');
const { test } = require('node:test');
const { spawnSync } = require('node:child_process');
const path = require('node:path');
const { makeWorklist, acceptResults } = require('./TestContinuationReference.cjs');
const { snapshotDigest } = require('./ReviewDelivery.cjs');
const snapshot = () => ({ head_sha:'a'.repeat(40), base_sha:'b'.repeat(40), pull_number:1, changed_files:1, files:[{filename:'f.cs',status:'modified',patch:'diff'}], threads:[
  {id:'open',isResolved:false,comments:[{databaseId:1,body:'old'}]},
  {id:'closed',isResolved:true,comments:[{databaseId:2,body:'old'}]},
] });
const complete = (id='file:0') => ({id,status:'complete',reasoning:'read',findings:[],action:'none'});

test('Node parse/stringify boundary preserves pretty-artifact hash and batch size', t => {
  const fs=require('node:fs'),os=require('node:os');
  const directory=fs.mkdtempSync(path.join(os.tmpdir(),'core-capture-'));
  t.after(()=>fs.rmSync(directory,{recursive:true,force:true}));
  const s=snapshot();s.threads=[];
  s.files=Array.from({length:2},(_,i)=>{const item={id:`file:${i}`,file:{filename:`f${i}.cs`,status:'modified',patch:''}};item.file.patch='x'.repeat(24000-Buffer.byteLength(JSON.stringify(item)));return item.file;});s.changed_files=2;
  const artifact=path.join(directory,'snapshot.json');
  fs.writeFileSync(artifact,JSON.stringify(s,null,2).replace('"pull_number": 1','"pull_number": 1.00'));
  const parsed=JSON.parse(fs.readFileSync(artifact,'utf8')),hash=snapshotDigest(parsed);
  const result=spawnSync('pwsh',['-NoLogo','-NoProfile','-File',path.join(__dirname,'Invoke-ContinuationCore.ps1')],{input:JSON.stringify([{mode:'state',snapshot:parsed,snapshotHash:hash}]),encoding:'utf8',maxBuffer:1024*1024});
  assert.equal(result.status,0,result.stderr);const [actual]=JSON.parse(result.stdout);
  assert.equal(actual.checkpoint.snapshot_sha256,hash);
  assert.deepEqual(actual.assignment.ids,['file:0','file:1']);
});

test('shared PowerShell worklist/result policy matches original JavaScript', () => {
  const cases=[];
  const addSnapshot = edit => {const s=snapshot();if(edit)edit(s);cases.push({snapshot:s});};
  addSnapshot();
  for(const name of ['head_sha','base_sha']) for(const value of [null,'a'.repeat(39),'a'.repeat(40)+'\n','A'.repeat(40),false]) addSnapshot(s=>{s[name]=value;});
  for(const value of [0,-1,'1',true,1.5,9007199254740991,9007199254740992]) addSnapshot(s=>{s.pull_number=value;});
  for(const value of ['1',null,2,1.5]) addSnapshot(s=>{s.changed_files=value;});
  for(const value of ['', ' \ufeff', '\u0085', '\u0000', 'é😀\ud800']) addSnapshot(s=>{s.files[0].filename=value;});
  addSnapshot(s=>{s.files.push(s.files[0]);s.changed_files=2;});
  addSnapshot(s=>{s.files=[{filename:'A.cs'},{filename:'a.cs'}];s.changed_files=2;});
  addSnapshot(s=>{s.threads[1].id=s.threads[0].id;});
  addSnapshot(s=>{s.threads[0].isResolved='false';});
  addSnapshot(s=>{s.threads[0].comments=[];});
  for(const value of ['1',0,1.5,9007199254740992,null]) addSnapshot(s=>{s.threads[0].comments[0].databaseId=value;});
  addSnapshot(s=>{s.files=[];s.changed_files=0;s.threads=[];});
  const addResult=(results)=>cases.push({snapshot:snapshot(),response:{results}});
  for(const id of ['file:0','thread:0','thread:1','invented']) addResult([complete(id)]);
  addResult([complete(),complete()]);
  addResult([complete(),null]);
  addResult([complete(),{id:'thread:0',status:'pending',reasoning:1,reply:{bad:true}}]);
  for(const status of ['pending','blocked','complete','Complete','complete\u0000',null,false]) addResult([{...complete(),status}]);
  for(const reasoning of ['', '\ufeff', ' \t\r\n', '\u0085', '\u0000', '😀\ud800',null,5]) addResult([{...complete(),reasoning}]);
  for(const action of ['none','resolve','reopen','NONE','none\u0000',null]) for(const id of ['file:0','thread:0','thread:1']) addResult([{...complete(id),action,reply:'still relevant'}]);
  for(const reply of ['',null,'\ufeff','\u0085',{},true,1,'résumé😀\ud800']) addResult([{...complete('thread:0'),reply}]);
  for(const side of ['LEFT','RIGHT','left','',null,false]) addResult([{...complete(),findings:[{path:'f.cs',line:1,body:'finding',side}]}]);
  for(const line of [1,1.5,'1',true,0,-1,9007199254740991,9007199254740992]) addResult([{...complete(),findings:[{path:'f.cs',line,body:'finding'}]}]);
  let seed=0x1af07ef1;
  const rnd=()=>seed=(Math.imul(seed,1664525)+1013904223)>>>0;
  const values=[null,false,1,1.5,'', 'read','\ufeff','\u0085','😀\ud800',[],{}];
  for(let i=0;i<1000;i++) {
    const result=complete(['file:0','thread:0','thread:1','foreign'][rnd()%4]);
    const key=['status','reasoning','action','reply','findings'][rnd()%5];
    result[key]=key==='status'?['complete','pending','blocked','invalid'][rnd()%4]:key==='action'?['none','resolve','reopen','bad'][rnd()%4]:values[rnd()%values.length];
    addResult([result]);
  }
  const normalized=JSON.parse(JSON.stringify(cases));
  const expected=normalized.map(item=>{try{const work=makeWorklist(item.snapshot);return item.response?{accepted:acceptResults(work,item.response)}:{work};}catch(error){return {error:error.message};}});
  const result=spawnSync('pwsh',['-NoLogo','-NoProfile','-File',path.join(__dirname,'Invoke-ContinuationCore.ps1')],{input:JSON.stringify(normalized),encoding:'utf8',maxBuffer:16*1024*1024});
  assert.equal(result.status,0,result.stderr);
  const actual=JSON.parse(result.stdout);assert.equal(actual.length,expected.length);
  expected.forEach((want,index)=>{if(want.error)assert.ok(actual[index].error,`case ${index}: expected rejection ${want.error}`);else assert.deepEqual(actual[index],want,`case ${index}`);});
});
