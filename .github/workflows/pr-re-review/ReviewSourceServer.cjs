'use strict';
// Private stdio transport only: no TCP listener, HTTP route or unauthenticated
// token-backed endpoint. The authenticated MCP gateway owns the process pipes.
const fs = require('node:fs');
const readline = require('node:readline');
const { readSource } = require('./ReviewReadSource.cjs');
const tool = { name:'read-review-source', description:'Read bounded plain source at captured head/base or a matching package GA baseline candidate. A tag is not proof of publication.', inputSchema:{type:'object',properties:{path:{type:'string'},ref:{type:'string'},offset:{type:'integer'},limit:{type:'integer'},search:{type:'string'}},required:['path'],additionalProperties:false} };

async function handle(request, read) {
  if (!request || request.jsonrpc !== '2.0' || typeof request.method !== 'string') throw new Error('Invalid JSON-RPC request.');
  if (request.method === 'initialize') return {protocolVersion:'2024-11-05',capabilities:{tools:{}},serverInfo:{name:'review-source',version:'1'}};
  if (request.method === 'ping') return {};
  if (request.method === 'tools/list') return {tools:[tool]};
  if (request.method !== 'tools/call' || request.params?.name !== tool.name) throw new Error('Unsupported read-only MCP method or tool.');
  const args = request.params.arguments || {};
  if (Object.keys(args).some(key => !Object.hasOwn(tool.inputSchema.properties,key))) throw new Error('Unsupported source input.');
  return {content:[{type:'text',text:JSON.stringify(await read(args))}]};
}

async function main() {
  const snapshot = JSON.parse(fs.readFileSync(process.env.REVIEW_SNAPSHOT,'utf8'));
  if (!process.env.REVIEW_TOKEN || !process.env.REVIEW_REPOSITORY) throw new Error('Missing private source-reader configuration.');
  const lines=readline.createInterface({input:process.stdin,crlfDelay:Infinity});
  lines.on('line',async line=>{
    let request;
    try {
      if (Buffer.byteLength(line)>65536) throw new Error('MCP request exceeds the bounded input limit.');
      request=JSON.parse(line);
      if (request.id===undefined) return; // Notifications have no response.
      const result=await handle(request,args=>readSource(args,snapshot,process.env.REVIEW_REPOSITORY,process.env.REVIEW_TOKEN,undefined,process.env.REVIEW_API_URL));
      process.stdout.write(JSON.stringify({jsonrpc:'2.0',id:request.id,result})+'\n');
    } catch(error) {
      process.stdout.write(JSON.stringify({jsonrpc:'2.0',id:request?.id ?? null,error:{code:-32602,message:error.message}})+'\n');
    }
  });
}
module.exports={handle,tool};
if(require.main===module)main().catch(error=>{console.error(error.message);process.exitCode=1;});
