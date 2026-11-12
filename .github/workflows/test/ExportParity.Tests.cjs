'use strict';
const assert=require('node:assert/strict');
const {test}=require('node:test');
const fs=require('node:fs'),path=require('node:path'),os=require('node:os'),vm=require('node:vm');
const candidate=require('../pr-re-review/ReviewSnapshot.cjs');
const {snapshotDigest,MAX_BATCH_BYTES}=require('../pr-re-review/ReviewDelivery.cjs');
const frozen=fs.readFileSync(path.join(__dirname,'TestSnapshotReference.cjs'),'utf8');
const base=()=>({head_sha:'a'.repeat(40),base_sha:'b'.repeat(40),pull_number:1,changed_files:0,files:[],threads:[],reviews:[{id:1,state:'COMMENTED',body:'review 😀\ud800',submittedAt:'2026-01-02T03:04:05.000Z'}]});
async function attempt(fixture,isCandidate){
 const directory=fs.mkdtempSync(path.join(os.tmpdir(),'export-parity-')),snapshot=fixture.snapshot?fixture.snapshot():base(),reads=[];
 const runner=async()=>{
  const delivery={snapshot:snapshotDigest(snapshot),items:Object.fromEntries([...snapshot.files.map((_,i)=>[`file:${i}`,[]]),...snapshot.threads.map((_,i)=>[`thread:${i}`,[{kind:'history',key:'history:'+'a'.repeat(64)}]])])};
  const context={files:snapshot.files.map(()=>({})),threads:snapshot.threads.map(()=>({})),reviews:(snapshot.reviews||[]).map((review,i)=>({id:review?.id,state:review?.state,history_path:path.join(directory,`review-${i}.json`)}))};
  const data={snapshot,delivery,context,histories:[...(snapshot.reviews||[])]};
  fixture.change?.(data,directory);
  fs.writeFileSync(path.join(directory,'snapshot.json'),data.snapshotText??JSON.stringify(data.snapshot));
  fs.writeFileSync(path.join(directory,'delivery-index.json'),data.indexText??JSON.stringify(data.delivery));
  fs.writeFileSync(path.join(directory,'index.json'),data.contextText??JSON.stringify(data.context));
  for(const [i,history]of data.histories.entries())if(history!==undefined)fs.writeFileSync(path.join(directory,`review-${i}.json`),JSON.stringify(history));
  return {stdout:JSON.stringify(data.delivery),stderr:''};
 };
 let implementation;
 if(isCandidate)implementation=(s,d)=>candidate.exportContext(s,d,{runExporter:runner});
 else{const box={module:{exports:{}},require:name=>name==='./ReviewDelivery.cjs'?{MAX_BATCH_BYTES,snapshotDigest,runPowerShell:runner}:require(name)};vm.runInNewContext(frozen,box);implementation=box.module.exports.exportContext;}
 const read=fs.readFileSync;
 fs.readFileSync=function(file,...args){if(typeof file==='string'&&file.startsWith(directory+path.sep))reads.push(path.basename(file));return read.call(this,file,...args);};
 try{await implementation(snapshot,directory);return {ok:true,reads};}catch(error){return {error:error.message,reads};}
 finally{fs.readFileSync=read;fs.rmSync(directory,{recursive:true,force:true});}
}
test('export preserves null-review entry/path short-circuit ordering',{timeout:15000},async()=>{
 const fixture={snapshot:()=>({...base(),reviews:[null]}),change:data=>{data.context.reviews[0]=null;}};
 const expected=await attempt(fixture,false),actual=await attempt(fixture,true);
 assert.equal(expected.error,'Exported review history does not match the captured snapshot.');assert.deepEqual(actual,expected);
});
test('independent export validation matches native identities, canonicalization and read ordering',{timeout:90000},async()=>{
 const fixtures=[{name:'valid'},
  {name:'invalid assignments before reads',change:d=>{d.delivery.items.extra=[];}},
  {name:'base mismatch before history',change:d=>{d.snapshotText=JSON.stringify({...d.snapshot,head_sha:'c'.repeat(40)});}},
  {name:'reordered index',change:d=>{d.indexText=JSON.stringify({items:d.delivery.items,snapshot:d.delivery.snapshot});}},
  {name:'reordered history',change:d=>{const r=d.histories[0];d.histories[0]={state:r.state,id:r.id,body:r.body,submittedAt:r.submittedAt};}},
  {name:'first path mismatch before missing second history',snapshot:()=>({...base(),reviews:[base().reviews[0],{id:2,state:'COMMENTED',body:'second'}]}),change:d=>{d.context.reviews[0].history_path='wrong';d.histories[1]=undefined;}},
  {name:'late history changed',snapshot:()=>({...base(),reviews:[base().reviews[0],{id:2,state:'COMMENTED',body:'second'}]}),change:d=>{d.histories[1]={...d.histories[1],body:'changed'};}},
  {name:'null review correct path',snapshot:()=>({...base(),reviews:[null]})},
  {name:'null review wrong path',snapshot:()=>({...base(),reviews:[null]}),change:d=>{d.context.reviews[0].history_path='wrong';}},
 ];
 for(const suffix of ['\n','\r','\r\n','\u2028','\u2029'])fixtures.push({name:'terminal key '+JSON.stringify(suffix),snapshot:()=>({...base(),threads:[{id:'one'}]}),change:d=>{d.delivery.items['thread:0'][0].key+=suffix;}});
 for(const value of [undefined,null,1,'1',false,true,-0,NaN,Infinity,-Infinity,{},[]])fixtures.push({name:'native id '+String(value),snapshot:()=>{const s=base();if(value===undefined)delete s.reviews[0].id;else s.reviews[0].id=value;return s;},change:d=>{if(value===Infinity||value===-Infinity){d.contextText=JSON.stringify(d.context).replace('"id":null','"id":'+(value<0?'-1e400':'1e400'));}}});
 fixtures.push({name:'string number mismatch',change:d=>{d.context.reviews[0].id='1';}});
 fixtures.push({name:'absent versus null',snapshot:()=>{const s=base();delete s.reviews[0].id;return s;},change:d=>{d.context.reviews[0].id=null;}});
 for(const fixture of fixtures){const expected=await attempt(fixture,false),actual=await attempt(fixture,true);assert.deepEqual(actual,expected,fixture.name);}
});
