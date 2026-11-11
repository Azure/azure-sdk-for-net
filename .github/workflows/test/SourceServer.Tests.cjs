'use strict';
const {test}=require('node:test'); const assert=require('node:assert/strict');
const fs=require('node:fs'),path=require('node:path');
const {handle,createDelivery}=require('../pr-re-review/ReviewSourceServer.cjs');
const {verifyDelivery}=require('../pr-re-review/ReviewDelivery.cjs');
const os=require('node:os');
test('source transport exposes only read-only requests over private stdio',async()=>{
 const init=await handle({jsonrpc:'2.0',id:1,method:'initialize'},()=>{});assert.equal(init.protocolVersion,'2024-11-05');
 const listed=await handle({jsonrpc:'2.0',id:2,method:'tools/list'},()=>{});assert.deepEqual(listed.tools.map(x=>x.name),['read-review-source','read-review-input']);
 let args;
 const result=await handle({jsonrpc:'2.0',id:3,method:'tools/call',params:{name:'read-review-source',arguments:{path:'sdk/F.cs'}}},input=>{args=input;return {content:'source'};});
 assert.equal(args.path,'sdk/F.cs');assert.match(result.content[0].text,/source/);
 await assert.rejects(handle({jsonrpc:'2.0',id:4,method:'tools/call',params:{name:'execute',arguments:{}}},()=>{}),/Unsupported/);
 await assert.rejects(handle({jsonrpc:'2.0',id:5,method:'tools/call',params:{name:'read-review-source',arguments:{path:'x',token:'injected'}}},()=>{}),/Unsupported/);
});
test('trusted reader records only delivered pages for the exact snapshot, assignment and invocation',async t=>{
 const dir=fs.mkdtempSync(path.join(os.tmpdir(),'review-receipts-'));t.after(()=>fs.rmSync(dir,{recursive:true,force:true}));
 const snapshot={head_sha:'a'.repeat(40),base_sha:'b'.repeat(40),files:[{filename:'new.cs',status:'renamed',previous_filename:'old.cs',patch:'diff'}],threads:[{id:'t',comments:[{body:'history'}]}]};
 const delivery=createDelivery(snapshot,dir),nonce='a'.repeat(32);
 const call=(name,args)=>handle({jsonrpc:'2.0',id:1,method:'tools/call',params:{name,arguments:args}},async args=>({path:args.path,ref:args.ref,offset:args.offset||0,total_characters:3,content:'abc'.slice(args.offset||0,(args.offset||0)+(args.limit||4000))}),delivery);
 const items=[{id:'thread:0',thread:snapshot.threads[0]},{id:'file:0',file:snapshot.files[0]}];
 const first=JSON.parse((await call('read-review-input',{item:'thread:0',nonce,kind:'history',limit:5})).content[0].text);
 await assert.rejects(call('read-review-input',{item:'thread:0',nonce,kind:'patch'}),/not required/);
 const second=JSON.parse((await call('read-review-input',{item:'thread:0',nonce,kind:'history',offset:first.next_offset})).content[0].text);
 const base=JSON.parse((await call('read-review-source',{path:'old.cs',ref:snapshot.base_sha,delivery_item:'file:0',delivery_nonce:nonce})).content[0].text);
 const results=[{id:'thread:0',status:'complete',delivery_tokens:[first.delivery_token,second.delivery_token]},{id:'file:0',status:'complete',delivery_tokens:[base.delivery_token]}];
 let rows=fs.readFileSync(path.join(dir,nonce+'.jsonl'),'utf8').trim().split('\n').map(JSON.parse);
 assert.ok(!JSON.stringify(rows).includes(first.delivery_token), 'Receipts must not disclose acknowledgements.');
 await assert.rejects(async()=>verifyDelivery(snapshot,items,results,nonce,rows),/delivery/i);
 const head=JSON.parse((await call('read-review-source',{path:'new.cs',ref:snapshot.head_sha,delivery_item:'file:0',delivery_nonce:nonce})).content[0].text);
 results[1].delivery_tokens.push(head.delivery_token);
 rows=fs.readFileSync(path.join(dir,nonce+'.jsonl'),'utf8').trim().split('\n').map(JSON.parse);
 await assert.doesNotReject(async()=>verifyDelivery(snapshot,items,results,nonce,rows));
 await assert.rejects(call('read-review-source',{path:'old.cs',ref:snapshot.base_sha,delivery_item:'file:0',delivery_nonce:nonce,search:'a'}),/Search/);
 await assert.rejects(call('read-review-source',{path:'other.cs',ref:snapshot.base_sha,delivery_item:'file:0',delivery_nonce:nonce}),/not a valid/);
});
test('a generated page cannot count when its response was dropped', async t => {
 const dir=fs.mkdtempSync(path.join(os.tmpdir(),'review-dropped-'));t.after(()=>fs.rmSync(dir,{recursive:true,force:true}));
 const snapshot={head_sha:'a'.repeat(40),base_sha:'b'.repeat(40),files:[],threads:[{id:'t',comments:[{body:'history'}]}]};
 const nonce='a'.repeat(32), item={id:'thread:0',thread:snapshot.threads[0]};
 createDelivery(snapshot,dir).page({item:item.id,nonce,kind:'history'}); // Simulate a response dropped before it reaches the worker.
 const rows=fs.readFileSync(path.join(dir,nonce+'.jsonl'),'utf8').trim().split('\n').map(JSON.parse);
 await assert.rejects(async()=>verifyDelivery(snapshot,[item],[{id:item.id,status:'complete'}],nonce,rows),/delivery/i);
});
test('compiled source backend has no HTTP listener or published port',()=>{
 const lock=fs.readFileSync(path.join(__dirname,'..','pr-re-review.lock.yml'),'utf8');
 const stanza=lock.match(/"reviewsource": \{([\s\S]*?)"guard-policies"/)[1];
 assert.match(stanza,/"type": "stdio"/);assert.ok(!stanza.includes('"url"'));assert.ok(!stanza.includes('"-p"'));
 assert.ok(stanza.includes('${RUNNER_TEMP}/gh-aw/safeoutputs/review-receipts:/receipts:rw'));
 assert.ok(lock.includes('--mount "${RUNNER_TEMP}/gh-aw:${RUNNER_TEMP}/gh-aw:ro"'));
 assert.ok(!lock.includes('name: Start MCP Scripts Server'));
});
