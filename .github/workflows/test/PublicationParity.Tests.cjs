'use strict';
const assert=require('node:assert/strict');
const {test}=require('node:test');
const {spawnSync}=require('node:child_process');
const path=require('node:path');
const {makeWorklist,buildOutputs,assertPublication}=require('./TestContinuationReference.cjs');
const {snapshotDigest}=require('./ReviewDelivery.cjs');
const clone=x=>structuredClone(x);
function fixture(inventory=false){const s={head_sha:'a'.repeat(40),base_sha:'b'.repeat(40),pull_number:1,changed_files:1,files:[{filename:'f.cs',status:'modified',patch:'diff'}],threads:[{id:'one',isResolved:false,comments:[{databaseId:1,path:'f.cs',body:'old'}]}],reviews:[]};if(inventory){const p='eng/apicompatbaselines/Azure.Example.xml';s.files[0].filename=p;s.baseline_suppressions=[{path:p,fields:{DiagnosticId:'CP1',Target:'M:Foo'},nearby_comment:'justified'}];}const results=makeWorklist(s).map(item=>({id:item.id,status:'complete',reasoning:'read',findings:item.file?[{path:s.files[0].filename,line:1,body:'finding'}]:[],action:'none'}));const progress={head_sha:s.head_sha,base_sha:s.base_sha,snapshot_sha256:snapshotDigest(s),results,attempts:[]};return {snapshot:s,progress,output:{items:buildOutputs(s,progress),errors:[]},agentResult:'success'};}
// Native compatibility boundary only: preserve the old JavaScript String and
// JSON encoding rather than substituting PowerShell conversion rules.
function encode(input){const {encodePublicationRequest}=require('../pr-re-review/ReviewContinuation.cjs');return {name:input.name,mode:'publication',...encodePublicationRequest(input.snapshot,input.progress,input.output,input.agentResult)};}
function category(message){if(/did not complete successfully/.test(message))return 'controller';if(/does not belong/.test(message))return 'snapshot';if(/Buffered outputs do not match/.test(message))return 'shape';if(/routing differs/.test(message))return 'routing';if(/review coverage|Missing review coverage/i.test(message))return 'coverage';if(/omits or hides/.test(message))return 'inventory';if(/convert object to primitive/i.test(message))return 'coercion';return 'policy';}

test('shared PowerShell publication policy matches the original ordered guard', {timeout:30000},()=>{
 const cases=[];const add=(name,edit,withInventory=false)=>{const c=fixture(withInventory);if(edit)edit(c);cases.push({name,...c});};
 add('unchanged');add('agent failed',c=>{c.agentResult='failure';c.progress.snapshot_sha256='wrong';});add('digest mismatch',c=>{c.progress.snapshot_sha256='wrong';});add('head mismatch',c=>{c.progress.head_sha='c'.repeat(40);});add('incomplete ledger',c=>{c.progress.results=[];});add('buffered errors',c=>{c.output.errors=['failed'];});add('missing output item',c=>{c.output.items.pop();});add('reordered items',c=>{c.output.items.reverse();});add('sanitized prose',c=>{c.output.items[0].body='sanitized';});add('routing mismatch',c=>{c.output.items[0].line=2;});
 for(const value of ['1',[1],null,{}, {toString:null}])add('coercion '+JSON.stringify(value),c=>{c.output.items[0].line=value;});
 add('submit type array',c=>{c.output.items.at(-1).type=['submit_pull_request_review'];});
 add('ignored deeply nested data does not become a new serialization constraint',c=>{let deep={leaf:'ignored'};for(let i=0;i<10000;i++)deep={nested:deep};c.progress.ignored=deep;c.progress.attempts=deep;c.output.ignored=deep;c.output.items[0].body=deep;c.output.items[0].reason=deep;c.progress.results[0].ignored=deep;c.progress.results[1].findings[0].ignored=deep;});
 add('routing multiplicity is not a set',c=>{c.progress.results[1].findings.push({path:'f.cs',line:2,body:'second'});c.output.items=buildOutputs(c.snapshot,c.progress);c.output.items[1]=clone(c.output.items[0]);});
 add('worker metadata cannot spoof native routing',c=>{c.output.actualRouting=c.output.items.map(item=>JSON.stringify(Object.fromEntries(Object.keys(item).filter(key=>!['body','reason'].includes(key)).sort().map(key=>[key,String(item[key])]))));c.output.items[0].line=999;});
 add('routing error follows job failure',c=>{c.agentResult='failure';c.output.items[0].line={toString:null};});
 add('routing error follows snapshot failure',c=>{c.progress.snapshot_sha256='bad';c.output.items[0].line={toString:null};});
 for(const mark of ['**Coverage:**','> Coverage:','> - Coverage:','_Coverage:_','COVERAGE:'])add('coverage markup '+mark,c=>{c.output.items.at(-1).body=c.output.items.at(-1).body.replace('Coverage:',mark);});
 for(const white of ['\ufeff','\u0085','\u00a0'])add('coverage whitespace '+white.charCodeAt(0),c=>{c.output.items.at(-1).body=c.output.items.at(-1).body.replace('Coverage: 1/1',`Coverage:${white}1/1`);});
 add('unicode digits not ASCII',c=>{c.output.items.at(-1).body=c.output.items.at(-1).body.replace('Coverage: 1/1','Coverage: ١/١');});
 add('duplicate coverage claim',c=>{c.output.items.at(-1).body+='\nCoverage: 1/1 threads fetched, 1/1 unresolved threads verified, 1/1 changed files reviewed';});
 add('wrong coverage counts',c=>{c.output.items.at(-1).body=c.output.items.at(-1).body.replace('1/1 changed','0/1 changed');});
 add('missing body',c=>{delete c.output.items.at(-1).body;});
 add('inventory unchanged',null,true);
 add('inventory CRLF',c=>{c.output.items.at(-1).body=c.output.items.at(-1).body.replace(/\n/g,'\r\n');},true);
 add('inventory omitted',c=>{c.output.items.at(-1).body=c.output.items.at(-1).body.replace(/## New ApiCompat suppressions[\s\S]*?\n\n- Thread/,'- Thread');},true);
 add('inventory duplicated',c=>{const b=c.output.items.at(-1).body;const section=b.slice(b.indexOf('## New ApiCompat'),b.indexOf('\n\n- Thread'));c.output.items.at(-1).body+='\n'+section;},true);
 add('inventory fenced',c=>{c.output.items.at(-1).body=c.output.items.at(-1).body.replace('## New ApiCompat','```\n## New ApiCompat');},true);
 add('inventory trailing text',c=>{c.output.items.at(-1).body=c.output.items.at(-1).body.replace('justified`','justified` hidden');},true);
 add('inventory conflicts with no-findings prose',c=>{c.output.items.at(-1).body=c.output.items.at(-1).body.replace('## New ApiCompat','No new findings.\n\n## New ApiCompat');},true);
 // Nonfinite routing must retain native String coercion, not become JSON null.
 for(const name of ['Infinity','null','[object Object]'])add('special routing filename '+name,c=>{c.snapshot.files[0].filename=name;c.progress.results[1].findings[0].path=name;c.progress.snapshot_sha256=snapshotDigest(c.snapshot);c.output.items=buildOutputs(c.snapshot,c.progress);c.output.items[0].path=name==='[object Object]'?{nested:Infinity}:Infinity;});
 const expected=cases.map(c=>{try{assertPublication(c.snapshot,c.progress,c.output,c.agentResult);return 'ok';}catch(error){return category(error.message);}});
 const result=spawnSync('pwsh',['-NoLogo','-NoProfile','-File',path.join(__dirname,'Invoke-ContinuationCore.ps1')],{input:JSON.stringify(cases.map(encode)),encoding:'utf8',maxBuffer:16*1024*1024});assert.equal(result.status,0,result.stderr);const actual=JSON.parse(result.stdout);assert.equal(actual.length,expected.length);
 actual.forEach((value,i)=>assert.equal(value.verified?'ok':category(value.error||''),expected[i],`${cases[i].name}: ${value.error||''}`));
});
