'use strict';
// Private stdio transport only: no TCP listener, HTTP route or unauthenticated
// token-backed endpoint. The authenticated MCP gateway owns the process pipes.
const fs = require('node:fs');
const path = require('node:path');
const crypto = require('node:crypto');
const readline = require('node:readline');
const { readSource } = require('./ReviewReadSource.cjs');
const { snapshotDigest, requiredInputs } = require('./ReviewDelivery.cjs');
const tool = { name:'read-review-source', description:'Read bounded plain source at captured head/base or a matching package GA baseline candidate. A tag is not proof of publication. Include delivery_nonce and delivery_item when delivering required assigned source.', inputSchema:{type:'object',properties:{path:{type:'string'},ref:{type:'string'},offset:{type:'integer'},limit:{type:'integer'},search:{type:'string'},delivery_nonce:{type:'string'},delivery_item:{type:'string'}},required:['path'],additionalProperties:false} };
const inputTool = { name:'read-review-input', description:'Deliver one page of an assigned captured thread history or oversized patch, with a trusted receipt.', inputSchema:{type:'object',properties:{item:{type:'string'},nonce:{type:'string'},kind:{type:'string',enum:['history','patch']},offset:{type:'integer'},limit:{type:'integer'}},required:['item','nonce','kind'],additionalProperties:false} };

function createDelivery(snapshot, directory) {
  const hash = snapshotDigest(snapshot);
  function assignment(id) {
    const match = /^(file|thread):(0|[1-9][0-9]*)$/.exec(id || '');
    if (!match) throw new Error('Invalid delivery assignment.');
    const index = Number(match[2]);
    const value = (match[1] === 'file' ? snapshot.files : snapshot.threads)[index];
    if (!value) throw new Error('Unknown delivery assignment.');
    return match[1] === 'file' ? { id, file: value } : { id, thread: value };
  }
  function record(nonce, item, req, start, end, total) {
    if (!/^[a-f0-9]{32}$/.test(nonce || '')) throw new Error('Invalid delivery nonce.');
    const token = crypto.randomBytes(32).toString('hex');
    const proof_hash = crypto.createHash('sha256').update(token).digest('hex');
    const row = { snapshot: hash, nonce, item, key: req.key, start, end, total, proof_hash };
    fs.appendFileSync(path.join(directory, `${nonce}.jsonl`), JSON.stringify(row) + '\n', { mode: 0o644 });
    return token;
  }
  function page({ item, nonce, kind, offset = 0, limit = 4000 }) {
    if (!Number.isSafeInteger(offset) || offset < 0 || !Number.isSafeInteger(limit) || limit < 1 || limit > 4000) throw new Error('Invalid input page.');
    const req = requiredInputs(snapshot, assignment(item)).find(value => value.kind === kind && value.content !== undefined);
    if (!req || offset > req.content.length) throw new Error('Input is not required for this assignment.');
    const end = Math.min(req.content.length, offset + limit);
    const response = { item, kind, offset, total_characters: req.content.length, next_offset: end < req.content.length ? end : null, content: req.content.slice(offset, end) };
    response.delivery_token = record(nonce, item, req, offset, end, req.content.length);
    return response;
  }
  function source(args, result) {
    if (!args.delivery_nonce && !args.delivery_item) return;
    if (args.search !== undefined) throw new Error('Search results are not delivery pages.');
    const ref = args.ref || snapshot.head_sha;
    const req = requiredInputs(snapshot, assignment(args.delivery_item)).find(value => value.kind === 'source' && value.path === args.path && value.ref === ref);
    const offset = args.offset ?? 0;
    if (!req || result.path !== req.path || result.ref !== req.ref || result.offset !== offset || typeof result.content !== 'string' ||
        !Number.isSafeInteger(result.total_characters) || offset > result.total_characters || offset + result.content.length > result.total_characters) throw new Error('Source is not a valid required delivery page.');
    result.delivery_token = record(args.delivery_nonce, args.delivery_item, req, offset, offset + result.content.length, result.total_characters);
  }
  return { page, source };
}

async function handle(request, read, delivery) {
  if (!request || request.jsonrpc !== '2.0' || typeof request.method !== 'string') throw new Error('Invalid JSON-RPC request.');
  if (request.method === 'initialize') return {protocolVersion:'2024-11-05',capabilities:{tools:{}},serverInfo:{name:'review-source',version:'1'}};
  if (request.method === 'ping') return {};
  if (request.method === 'tools/list') return {tools:[tool,inputTool]};
  if (request.method !== 'tools/call' || ![tool.name,inputTool.name].includes(request.params?.name)) throw new Error('Unsupported read-only MCP method or tool.');
  const args = request.params.arguments || {};
  const schema = request.params.name === tool.name ? tool.inputSchema : inputTool.inputSchema;
  if (Object.keys(args).some(key => !Object.hasOwn(schema.properties,key))) throw new Error('Unsupported source input.');
  let result;
  if (request.params.name === inputTool.name) {
    if (!delivery) throw new Error('Delivery recorder unavailable.');
    result = delivery.page(args);
  } else {
    result = await read(args);
    if (args.delivery_nonce || args.delivery_item) {
      if (!delivery) throw new Error('Delivery recorder unavailable.');
      delivery.source(args, result);
    }
  }
  return {content:[{type:'text',text:JSON.stringify(result)}]};
}

async function main() {
  const snapshot = JSON.parse(fs.readFileSync(process.env.REVIEW_SNAPSHOT,'utf8'));
  if (!process.env.REVIEW_TOKEN || !process.env.REVIEW_REPOSITORY || !process.env.REVIEW_RECEIPTS) throw new Error('Missing private source-reader configuration.');
  const delivery = createDelivery(snapshot, process.env.REVIEW_RECEIPTS);
  const cache = new Map();
  const lines=readline.createInterface({input:process.stdin,crlfDelay:Infinity});
  lines.on('line',async line=>{
    let request;
    try {
      if (Buffer.byteLength(line)>65536) throw new Error('MCP request exceeds the bounded input limit.');
      request=JSON.parse(line);
      if (request.id===undefined) return; // Notifications have no response.
      const result=await handle(request,args=>readSource(args,snapshot,process.env.REVIEW_REPOSITORY,process.env.REVIEW_TOKEN,undefined,process.env.REVIEW_API_URL,cache),delivery);
      process.stdout.write(JSON.stringify({jsonrpc:'2.0',id:request.id,result})+'\n');
    } catch(error) {
      process.stdout.write(JSON.stringify({jsonrpc:'2.0',id:request?.id ?? null,error:{code:-32602,message:error.message}})+'\n');
    }
  });
}
module.exports={handle,tool,inputTool,createDelivery};
if(require.main===module)main().catch(error=>{console.error(error.message);process.exitCode=1;});
