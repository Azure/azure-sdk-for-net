'use strict';
const assert=require('node:assert/strict');
const {test}=require('node:test');
const {spawnSync}=require('node:child_process');
const path=require('node:path');
const {makeWorklist,buildOutputs}=require('./TestContinuationReference.cjs');
function snapshot(){return {head_sha:'a'.repeat(40),base_sha:'b'.repeat(40),pull_number:1,changed_files:2,files:[{filename:'f.cs',status:'modified',patch:'diff'},{filename:'removed.cs',status:'removed'}],threads:[{id:'open',isResolved:false,comments:[{databaseId:1,path:'f.cs',body:'old'}]},{id:'closed',isResolved:true,comments:[{databaseId:2,path:'f.cs',body:'old'}]}],reviews:[]};}
function ledger(s){return {results:makeWorklist(s).map(item=>({id:item.id,status:'complete',reasoning:'Reviewed 😀\ud800',findings:[],action:'none'}))};}
function inventory(s,comment='Near https://x.example/abc JavaScript:data 😀\ud800'){const p='eng/apicompatbaselines/Azure.Example.xml';s.files[0].filename=p;s.baseline_suppressions=[{path:p,fields:{DiagnosticId:'CP1',Target:'M:Foo',Zulu:'line\n`*',Alpha:'a',Supplementary:'😀\ud800'},nearby_comment:comment}];return p;}

test('PowerShell output construction matches JavaScript findings, actions and inventory', {timeout:30000},()=>{
 const cases=[];const add=(s,l=ledger(s))=>cases.push({mode:'outputs',snapshot:s,ledger:l});
 let s=snapshot();add(s);
 s=snapshot();let l=ledger(s);l.results[0].action='resolve';l.results[0].reply='Fixed now.';l.results[1].action='reopen';l.results[1].reply='Still relevant.';add(s,l);
 s=snapshot();l=ledger(s);l.results[0].findings=[{path:'removed.cs',line:1,body:'one'},{path:'removed.cs',line:1,body:'one',side:'RIGHT'}];l.results[2].findings=[{path:'removed.cs',line:1,body:'one'}];add(s,l);
 s=snapshot();l=ledger(s);l.results[2].findings=[{path:'outside.cs',line:1,body:'outside'}];add(s,l);
 s=snapshot();add(s,{results:[]});
 s=snapshot();const p=inventory(s);s.threads[0].comments.push({databaseId:3,path:p,body:'CP10 M:FooSuffix is not a match'},{databaseId:4,path:p,body:'CP1 and M:Foo remain.'});add(s);
 s=snapshot();inventory(s,'');add(s);
 s=snapshot();inventory(s,null);add(s);
 s=snapshot();inventory(s);delete s.baseline_suppressions[0].nearby_comment;add(s);
 s=snapshot();inventory(s);s.baseline_suppressions[0].fields.Target=' ';add(s);
 s=snapshot();inventory(s);s.baseline_suppressions[0].fields.Target='';add(s);
 s=snapshot();inventory(s);s.baseline_suppressions[0].fields.Bad=1;add(s);
 s=snapshot();inventory(s);s.baseline_suppressions[0].fields={'10':'ten','2':'two',DiagnosticId:'CP1',Target:'M:Foo','é':'composed','e\u0301':'decomposed','😀':'astral'};add(s);
 s=snapshot();inventory(s);const previous=buildOutputs(s,ledger(s)).at(-1).body;s.reviews=[{id:-1,body:previous}];s.baseline_suppressions[0].nearby_comment='revised explanation';add(s);
 for(const blank of ['\ufeff','\u0085',' \t\r\n']){s=snapshot();l=ledger(s);l.results[1].reasoning='Concluded'+blank;add(s,l);}
 s=snapshot();l=ledger(s);l.results[0].reasoning='x'.repeat(11955)+'😀'.repeat(100);add(s,l);
 s=snapshot();l=ledger(s);const prefix='- Thread 1: verified, unchanged. ';l.results[0].reasoning='x'.repeat(12000-prefix.length-1)+'😀z';assert.ok(buildOutputs(s,l).at(-1).body.includes('\ud83d\n\nFurther'));add(s,l);
 s=snapshot();l=ledger(s);l.results.reverse();add(s,l);
 for(const count of [50,51])for(const action of ['none','resolve','reopen']){s=snapshot();s.threads=Array.from({length:count},(_,i)=>({id:`t${i}`,isResolved:action==='reopen',comments:[{databaseId:i+1,path:'f.cs',body:'old'}]}));l=ledger(s);for(const r of l.results)if(r.id.startsWith('thread:')){r.action=action;r.reply='Reply';}add(s,l);}
 s=snapshot();l=ledger(s);l.results[0].findings=Array.from({length:101},(_,i)=>({path:'f.cs',line:i+1,body:`finding ${i}`}));add(s,l);
 s=snapshot();inventory(s,'');l=ledger(s);const size=Buffer.byteLength(buildOutputs(s,l).at(-1).body);s.baseline_suppressions[0].nearby_comment='x'.repeat(60000-size+'none identified'.length);add(s,l);
 s=structuredClone(s);s.baseline_suppressions[0].nearby_comment+='x';add(s,ledger(s));
 let seed=0x5ca7a62;const rnd=()=>seed=(Math.imul(seed,1664525)+1013904223)>>>0;
 const words=['none','Read current code.','😀\ud800','é\u0085\u2028\u2029','quote " \\ slash','\ufeffdone\ufeff'];
 for(let i=0;i<100;i++){s=snapshot();if(rnd()%3===0)inventory(s,words[rnd()%words.length]);l=ledger(s);for(const r of l.results){r.reasoning=words[rnd()%words.length];if(r.id.startsWith('thread:')){const t=s.threads[Number(r.id.split(':')[1])];if(rnd()%2===0){r.action=t.isResolved?'reopen':'resolve';r.reply=words[rnd()%words.length];}}if(rnd()%3===0)r.findings=[{path:s.files[rnd()%2].filename,line:1+(rnd()%20),body:words[rnd()%words.length],...(rnd()%2?{side:'RIGHT'}:{})}];}add(s,l);}
 const normalized=JSON.parse(JSON.stringify(cases));const expected=normalized.map(c=>{try{return {outputs:buildOutputs(c.snapshot,c.ledger)}}catch(e){return {error:e.message}}});
 const result=spawnSync('pwsh',['-NoLogo','-NoProfile','-File',path.join(__dirname,'Invoke-ContinuationCore.ps1')],{input:JSON.stringify(normalized),encoding:'utf8',maxBuffer:16*1024*1024});assert.equal(result.status,0,result.stderr);const actual=JSON.parse(result.stdout);assert.equal(actual.length,expected.length);
 expected.forEach((want,index)=>{if(want.error)assert.ok(actual[index].error,`case ${index}: expected ${want.error}`);else assert.deepEqual(actual[index],want,`case ${index}: ${actual[index].error||''}`)});
});
