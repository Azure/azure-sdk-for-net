'use strict';
const {test}=require('node:test'); const assert=require('node:assert/strict');
const fs=require('node:fs'),path=require('node:path');
const {handle}=require('./ReviewSourceServer.cjs');
test('source transport exposes only read-only requests over private stdio',async()=>{
 const init=await handle({jsonrpc:'2.0',id:1,method:'initialize'},()=>{});assert.equal(init.protocolVersion,'2024-11-05');
 const listed=await handle({jsonrpc:'2.0',id:2,method:'tools/list'},()=>{});assert.equal(listed.tools.length,1);
 let args;
 const result=await handle({jsonrpc:'2.0',id:3,method:'tools/call',params:{name:'read-review-source',arguments:{path:'sdk/F.cs'}}},input=>{args=input;return {content:'source'};});
 assert.equal(args.path,'sdk/F.cs');assert.match(result.content[0].text,/source/);
 await assert.rejects(handle({jsonrpc:'2.0',id:4,method:'tools/call',params:{name:'execute',arguments:{}}},()=>{}),/Unsupported/);
 await assert.rejects(handle({jsonrpc:'2.0',id:5,method:'tools/call',params:{name:'read-review-source',arguments:{path:'x',token:'injected'}}},()=>{}),/Unsupported/);
});
test('compiled source backend has no HTTP listener or published port',()=>{
 const lock=fs.readFileSync(path.join(__dirname,'..','pr-re-review.lock.yml'),'utf8');
 const stanza=lock.match(/"reviewsource": \{([\s\S]*?)"guard-policies"/)[1];
 assert.match(stanza,/"type": "stdio"/);assert.ok(!stanza.includes('"url"'));assert.ok(!stanza.includes('"-p"'));
 assert.ok(!lock.includes('name: Start MCP Scripts Server'));
});
