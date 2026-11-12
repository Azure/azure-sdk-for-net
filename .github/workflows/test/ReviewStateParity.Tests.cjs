'use strict';
const assert=require('node:assert/strict');
const {test}=require('node:test');
const {spawnSync}=require('node:child_process');
const fs=require('node:fs'),path=require('node:path'),vm=require('node:vm');
const source=fs.readFileSync(path.join(__dirname,'TestSnapshotReference.cjs'),'utf8');
const sandbox={module:{exports:{}},require:name=>{if(name==='./ReviewDelivery.cjs')return {runPowerShell:async()=>({stdout:'{}'})};throw Error(`Unexpected dependency ${name}`);}};
vm.runInNewContext(source+'\nconst originalCaptureReviewState=captureReviewState;captureReviewState=async(...args)=>{const s=await originalCaptureReviewState(...args);module.exports.captured=s;return s;};module.exports.captureReviewState=captureReviewState;',sandbox);
const reference=sandbox.module.exports;
const head='a'.repeat(40),base='b'.repeat(40);
function fixture(n=2){
 const pull={state:'open',draft:false,head:{sha:head,repo:{full_name:'Fork/repo'}},base:{sha:base,repo:{full_name:'Azure/repo'}},changed_files:1};
 const threads=Array.from({length:n},(_,i)=>({id:`thread-${i}`,isResolved:i%2===0,isOutdated:false,isCollapsed:true,comments:{nodes:[{databaseId:i+1,body:'prior',path:'f.cs',publishedAt:'2026-01-02T03:04:05.000Z',author:{login:'reviewer'},pullRequestReview:{submittedAt:'2026-01-03T03:04:05Z'}}],pageInfo:{hasNextPage:false,endCursor:null}}}));
 return {repo:{owner:'Azure',repo:'repo'},files:{pull_number:1,head_sha:head,base_sha:base,changed_files:1,files:[{filename:'f.cs',status:'modified',patch:'diff'}]},pulls:[structuredClone(pull),structuredClone(pull)],threadPages:[{repository:{pullRequest:{reviewThreads:{totalCount:n,nodes:threads,pageInfo:{hasNextPage:false,endCursor:null}}}}}],commentPages:{},reviews:[{id:10,body:'old review',state:'COMMENTED',commit_id:base,user:{login:'reviewer'},submitted_at:'2026-01-02T03:04:05.000Z',html_url:'https://example.test/review',author_association:'MEMBER'}]};
}
const connection=c=>c.threadPages[0].repository.pullRequest.reviewThreads;
async function native(c){let pi=0,ti=0,id=0;const ci=new Map(),effects=[];
 const record=(kind,args,query)=>{effects.push({effect_id:++id,kind,arguments:args,...(query!==undefined?{query}:{})});if(c.failAt===id)throw Error('API unavailable');};
 const github={rest:{pulls:{get:async args=>{record('pull',args);return {data:c.pulls[pi++]};},listReviews:()=>{throw Error('Use paginate')}}},graphql:async(query,args)=>{const kind=query.startsWith('query($id:')?'comments':'threads';record(kind,args,query);if(kind==='threads')return c.threadPages[ti++];const i=ci.get(args.id)||0;ci.set(args.id,i+1);return c.commentPages[args.id][i];},paginate:async(_method,args)=>{record('reviews',args);return c.reviews;}};
 try{let result;if(c.preflight){await reference.assertFresh(github,c.repo,c.files);result=reference.captured;}else result=await reference.captureReviewState(github,c.repo,c.files,{includeReviews:c.includeReviews!==false});return JSON.parse(JSON.stringify({result,effects}));}catch(error){return JSON.parse(JSON.stringify({error:error.message,effects}));}
}
test('PowerShell complete review capture matches original snapshots, failures and API ordering',{timeout:30000},async()=>{
 const cases=[fixture(0),fixture(1),fixture(2)],add=change=>{const c=fixture();change(c);cases.push(c);};
 add(c=>{c.repo={};});
 add(c=>{c.repo={};delete c.pulls[0].head.repo;delete c.pulls[0].base.repo;});
 add(c=>{c.includeReviews=false;});add(c=>{c.preflight=true;c.pulls.unshift(structuredClone(c.pulls[0]));});
 add(c=>{c.preflight=true;c.pulls.unshift(structuredClone(c.pulls[0]));c.pulls[0].head.sha='c'.repeat(40);});
 add(c=>{c.preflight=true;c.pulls.unshift(structuredClone(c.pulls[0]));c.pulls[1].head.sha='c'.repeat(40);});
 add(c=>{c.preflight=true;c.pulls.unshift(structuredClone(c.pulls[0]));c.pulls[0].head.repo.full_name='preflight-only/repo';});
 for(const field of ['id','body','state','commit_id','user','submitted_at','html_url','author_association'])for(const value of ['absent','null'])add(c=>{if(value==='absent')delete c.reviews[0][field];else c.reviews[0][field]=null;});
 for(const field of ['publishedAt','createdAt','updatedAt','author','pullRequestReview','url','line','originalLine','startLine','originalStartLine'])for(const value of ['absent','null'])add(c=>{const row=connection(c).nodes[0].comments.nodes[0];if(value==='absent')delete row[field];else row[field]=null;});
 for(const field of ['isOutdated','isCollapsed'])for(const value of ['absent',null,false,true])add(c=>{const row=connection(c).nodes[0];if(value==='absent')delete row[field];else row[field]=value;});
 add(c=>{const p=connection(c);p.totalCount=1;p.nodes=[p.nodes[0],null];});
 add(c=>{c.files.head_repo='old/head';c.files.base_repo='old/base';c.files.threads=['old'];c.files.reviews=['old'];});
 add(c=>{delete c.pulls[0].head.repo;c.pulls[0].base.repo.full_name='';});
 add(c=>{const page=connection(c);const t=page.nodes[0];t.comments.pageInfo={hasNextPage:true,endCursor:'comment-1'};c.commentPages[t.id]=[{node:{comments:{nodes:[{databaseId:3,body:'reply'}],pageInfo:{hasNextPage:false,endCursor:null}}}}];});
 add(c=>{const page=connection(c),second=structuredClone(page);second.nodes=second.nodes.slice(1);page.nodes=page.nodes.slice(0,1);page.pageInfo={hasNextPage:true,endCursor:'thread-1'};c.threadPages.push({repository:{pullRequest:{reviewThreads:second}}});});
 for(const field of ['head','base'])add(c=>{c.pulls[1][field].sha='c'.repeat(40);});
 add(c=>{c.pulls[0].state='closed';});add(c=>{c.pulls[0].draft=true;});add(c=>{c.pulls[1].changed_files=2;});
 add(c=>{connection(c).totalCount=3;});add(c=>{connection(c).totalCount=null;});add(c=>{connection(c).nodes={};});
 add(c=>{connection(c).nodes[1].id=connection(c).nodes[0].id;});add(c=>{connection(c).nodes[0]=null;});add(c=>{connection(c).nodes[0].isResolved='false';});
 add(c=>{connection(c).nodes[0].comments.nodes=[];});add(c=>{connection(c).nodes[0].comments.nodes.push({...connection(c).nodes[0].comments.nodes[0]});});
 add(c=>{delete connection(c).pageInfo;});add(c=>{delete connection(c).nodes[0].comments.pageInfo;});
 add(c=>{connection(c).nodes[0].comments.pageInfo={hasNextPage:true,endCursor:''};});
 add(c=>{const p=connection(c);p.nodes=[];p.pageInfo={hasNextPage:true,endCursor:'repeat'};c.threadPages.push(structuredClone(c.threadPages[0]));});
 add(c=>{const t=connection(c).nodes[0];t.comments.pageInfo={hasNextPage:true,endCursor:'repeat'};c.commentPages[t.id]=[{node:{comments:{nodes:[],pageInfo:{hasNextPage:true,endCursor:'repeat'}}}}];});
 for(const failAt of [1,2,3,4])add(c=>{c.failAt=failAt;});
 let seed=98765;const rnd=()=>seed=(Math.imul(seed,1664525)+1013904223)>>>0;
 const units=[9,10,34,47,92,0x85,0xe9,0x2028,0xd800,0xd83d,0xde00,0xdfff];
 const str=()=>String.fromCharCode(...Array.from({length:rnd()%30},()=>units[rnd()%units.length]));
 for(let k=0;k<200;k++){const c=fixture(rnd()%8);c.includeReviews=rnd()%2===0;for(const t of connection(c).nodes){t.comments.nodes[0].body=str();t.comments.nodes[0].path=str();if(rnd()%3===0)delete t.isOutdated;if(rnd()%3===0)t.isCollapsed=null;}for(const r of c.reviews){r.body=str();if(rnd()%3===0)delete r.user;if(rnd()%3===0)r.submitted_at=null;}cases.push(c);}
 const expected=[];for(const c of cases)expected.push(await native(c));
 const r=spawnSync(process.env.GH_AW_REVIEW_PWSH||'pwsh',['-NoLogo','-NoProfile','-NonInteractive','-File',path.join(__dirname,'Invoke-ReviewStateCases.ps1')],{input:JSON.stringify(cases),encoding:'utf8',maxBuffer:64*1024*1024});
 assert.equal(r.status,0,r.stderr);const actual=JSON.parse(r.stdout);assert.equal(actual.length,expected.length);
 for(let i=0;i<actual.length;i++){assert.deepEqual(actual[i],expected[i],`case ${i}`);if(actual[i].result)assert.equal(JSON.stringify(actual[i].result),JSON.stringify(expected[i].result),`canonical property order ${i}`);}
});
