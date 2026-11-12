'use strict';
const assert=require('node:assert/strict');
const {test}=require('node:test');
const {spawnSync}=require('node:child_process');
const path=require('node:path');
const {captureChangedFiles:reference}=require('./TestChangedFilesReference.cjs');
const identity={owner:'Azure',repo:'azure-sdk-for-net',pullNumber:64192,headSha:'a'.repeat(40)};
function fixture(n){const pull={state:'open',draft:false,head:{sha:identity.headSha},base:{sha:'b'.repeat(40)},changed_files:n};const files=Array.from({length:n},(_,i)=>({filename:`f${i}.cs`,status:'modified',patch:'diff'}));const pages=[];for(let i=0;i<files.length;i+=100)pages.push(files.slice(i,i+100));if(n%100===0&&n!==3000)pages.push([]);return {identity:{...identity},pulls:[structuredClone(pull),structuredClone(pull)],pages};}
async function native(c){let pulls=0,id=0;const effects=[];const github={rest:{pulls:{get:async args=>{effects.push({effect_id:++id,kind:'pull',arguments:args});return {data:c.pulls[pulls++]};},listFiles:async args=>{effects.push({effect_id:++id,kind:'files',arguments:args});return {data:c.pages[args.page-1]};}}}};try{return {result:await reference(github,c.identity),effects};}catch(error){return {error:error.message,effects};}}
test('PowerShell changed-file capture matches original decisions and read ordering',{timeout:30000},async()=>{
 const cases=[0,1,99,100,106,200,201,3000].map(fixture);
 const add=(n,change)=>{const c=fixture(n);change(c);cases.push(c);};
 add(106,c=>{delete c.pages[0][0].patch;c.pages[0][1].status='removed';c.pages[1][0].status='renamed';c.pages[1][0].previous_filename='old.cs';});
 for(const field of ['head','base'])add(1,c=>{c.pulls[1][field].sha='c'.repeat(40);});
 add(1,c=>{c.pulls[1].changed_files=2;});add(1,c=>{c.pulls[0].state='closed';});add(1,c=>{c.pulls[0].draft=true;});
 add(101,c=>{c.pages[1][0]=c.pages[0][0];});add(101,c=>{c.pages[1]=[];});add(1,c=>{c.pages[0][0].filename='';});
 add(1,c=>{c.pages[0]={};});add(1,c=>{c.pages[0]=Array.from({length:101},(_,i)=>({filename:`extra${i}`}));});
 for(const n of [-1,3001,1.5,null,'1'])add(1,c=>{c.pulls[0].changed_files=n;});
 for(const invalid of ['',null,'not-sha'])add(0,c=>{c.identity.headSha=invalid;});
 let seed=12345;const rnd=()=>seed=(Math.imul(seed,1664525)+1013904223)>>>0;
 const units=[9,10,34,47,92,0x85,0xe9,0x2028,0xd800,0xd83d,0xde00,0xdfff];
 for(let k=0;k<200;k++){const c=fixture(rnd()%220);for(const page of c.pages)for(const f of page){f.filename+='-'+String.fromCharCode(...Array.from({length:rnd()%12},()=>units[rnd()%units.length]));if(rnd()%3===0)delete f.patch;else f.patch=String.fromCharCode(...Array.from({length:rnd()%20},()=>units[rnd()%units.length]));if(rnd()%4===0)f.previous_filename=null;}cases.push(c);}
 const expected=[];for(const c of cases)expected.push(await native(c));
 const r=spawnSync(process.env.GH_AW_REVIEW_PWSH||'pwsh',['-NoLogo','-NoProfile','-NonInteractive','-File',path.join(__dirname,'Invoke-ChangedFileCases.ps1')],{input:JSON.stringify(cases),encoding:'utf8',maxBuffer:64*1024*1024});
 assert.equal(r.status,0,r.stderr);const actual=JSON.parse(r.stdout);assert.equal(actual.length,expected.length);
 for(let i=0;i<actual.length;i++)assert.deepEqual(actual[i],expected[i],`case ${i}`);
});
