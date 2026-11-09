'use strict';
const assert = require('node:assert/strict');
const { test } = require('node:test');
const { readSource } = require('./ReviewReadSource.cjs');
const snapshot = { head_sha:'a'.repeat(40),base_sha:'b'.repeat(40),head_repo:'Azure/azure-sdk-for-net',base_repo:'Azure/azure-sdk-for-net' };
const repo = 'Azure/azure-sdk-for-net';
const raw = text => new Response(text, {status:200});

test('reads bounded plain text without agent shell or base64 decoding', async () => {
  const content = 'public class Model {}\n'.repeat(1000);
  let calls = 0;
  const fetcher = async (url, options) => {
    calls++;
    assert.equal(new URL(url).origin,'https://api.github.com');
    assert.equal(options.method,'GET'); assert.equal(options.redirect,'error');
    assert.equal(options.headers.Accept,'application/vnd.github.raw+json');
    return raw(content);
  };
  const first = await readSource({path:'sdk/Model.cs'},snapshot,repo,'test-token',fetcher);
  assert.equal(first.content,content.slice(0,4000)); assert.equal(first.next_offset,4000);
  const second = await readSource({path:'sdk/Model.cs',offset:first.next_offset},snapshot,repo,'test-token',fetcher);
  assert.equal(second.content,content.slice(4000,8000)); assert.equal(calls,2);
});

test('immutable source pages reuse a bounded backend cache', async () => {
  const cache = new Map(); let calls = 0;
  const fetcher = async () => { calls++; return raw('x'.repeat(8000)); };
  await readSource({path:'sdk/Model.cs',offset:0},snapshot,repo,'test-token',fetcher,undefined,cache);
  await readSource({path:'sdk/Model.cs',offset:4000},snapshot,repo,'test-token',fetcher,undefined,cache);
  assert.equal(calls,1);
});

test('source search is literal and source refs are pinned to head/base', async () => {
  const result=await readSource({path:'sdk/Model.cs',ref:snapshot.base_sha,search:'Target'},snapshot,repo,'test-token',async()=>raw('prefix\nTarget method\n'));
  assert.match(result.content,/Target method/);
  let calls=0;
  for(const args of [{path:'../secrets'},{path:'/etc/passwd'},{path:'sdk/F.cs',ref:'c'.repeat(40)},{path:'sdk/F.cs',offset:-1},{path:'sdk/F.cs',limit:100000},{path:'sdk/F.cs\n'}])
    await assert.rejects(readSource(args,snapshot,repo,'test-token',async()=>{calls++;return raw('');}),/Invalid|outside/i);
  assert.equal(calls,0);
});

test('related GA-shaped baseline tags match the package and never use a fork release tag', async () => {
  const path='sdk/monitor/Azure.ResourceManager.Monitor/src/Models/M.cs';
  const ref='Azure.ResourceManager.Monitor_1.3.0';
  const result=await readSource({path,ref},{...snapshot,head_repo:'live1206/azure-sdk-for-net'},repo,'test-token',async url=>{
    assert.match(url,/repos\/Azure\/azure-sdk-for-net\//); return raw('baseline candidate');
  });
  assert.equal(result.reference_kind,'ga-baseline-candidate');
  for(const bad of ['Azure.ResourceManager.Monitor_1.3.0-beta.1','Azure.ResourceManager.Other_1.3.0'])
    await assert.rejects(readSource({path,ref:bad},snapshot,repo,'test-token',async()=>raw('')),/outside/);
});

test('fork source falls back to the exact shared PR SHA without unauthenticated writes', async () => {
  const urls=[];
  const result=await readSource({path:'sdk/F.cs'},{...snapshot,head_repo:'live1206/azure-sdk-for-net'},repo,'test-token',async(url,options)=>{
    urls.push(url); assert.equal(options.method,'GET');
    return urls.length===1?new Response('',{status:403}):raw('source');
  });
  assert.equal(result.content,'source');
  assert.match(urls[0],/live1206\/azure-sdk-for-net/); assert.match(urls[1],/Azure\/azure-sdk-for-net/);
  assert.ok(urls.every(url=>url.endsWith(snapshot.head_sha)));
});

test('uses the trusted enterprise API endpoint rather than sending its token to public GitHub', async () => {
  const result=await readSource({path:'sdk/F.cs'},snapshot,repo,'test-token',async url=>{
    assert.match(url,/^https:\/\/ghe\.example\/api\/v3\/repos\/Azure\//); return raw('source');
  },'https://ghe.example/api/v3');
  assert.equal(result.content,'source');
  await assert.rejects(readSource({path:'sdk/F.cs'},snapshot,repo,'test-token',async()=>raw(''),'http://ghe.example/api/v3'),/endpoint/);
});

test('binary or invalid UTF-8 source cannot satisfy required delivery', async () => {
  for (const bytes of [Uint8Array.from([0x61, 0, 0x62]), Uint8Array.from([0xff])]) {
    await assert.rejects(readSource({path:'sdk/F.cs'},snapshot,repo,'test-token',async()=>new Response(bytes)), /binary|utf-8/i);
  }
});

test('read failures and excessive responses fail honestly without leaking credentials', async () => {
  await assert.rejects(readSource({path:'sdk/F.cs'},snapshot,repo,'secret-token',async()=>new Response('',{status:404})),error=>/HTTP 404/.test(error.message)&&!error.message.includes('secret-token'));
  await assert.rejects(readSource({path:'sdk/F.cs'},snapshot,repo,'test-token',async()=>raw('x'.repeat(4*1024*1024+1))),/helper limit/);
});

function assertNoAgentCredential(execution) {
  const invocation=execution.split('\n').find(line=>line.includes('awf --config')) || '';
  for(const name of ['REVIEW_TOKEN','GITHUB_TOKEN'])
    assert.ok(!new RegExp(`^ +${name}:`,'m').test(execution) || invocation.includes(`--exclude-env ${name}`), `${name} must not enter the agent sandbox`);
}

test('compiled stdio source credentials remain in the gateway, not agent execution', () => {
  const fs=require('node:fs'); const path=require('node:path');
  const lock=fs.readFileSync(path.join(__dirname,'..','pr-re-review.lock.yml'),'utf8');
  const agent=lock.split('\n  agent:\n')[1].split('\n  check_safe_output_status:')[0];
  const execution=agent.split('name: Execute GitHub Copilot CLI')[1].split(/\n      - /)[0];
  assertNoAgentCredential(execution);
  assert.ok(agent.includes('"REVIEW_TOKEN": "\\${GITHUB_TOKEN}"'), 'The gateway config must reference its private token variable, not expose a value');
  // Preserve the original credential-leak regression even though the stdio
  // design no longer injects REVIEW_TOKEN into agent execution at all.
  assert.throws(()=>assertNoAgentCredential('awf --config config --env-all\n          REVIEW_TOKEN: secret'),/sandbox/);
});
