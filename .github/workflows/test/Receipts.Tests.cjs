'use strict';
const {test}=require('node:test'); const assert=require('node:assert/strict');
const fs=require('node:fs'),path=require('node:path'),os=require('node:os');
const {spawnSync}=require('node:child_process');
function installReplyReceipts(directory) {
 const script=path.join(__dirname,'..','pr-re-review','Install-ReviewReceipts.ps1');
 const result=spawnSync('pwsh',['-NoLogo','-NoProfile','-NonInteractive','-File',script,'-ActionsDirectory',directory],{encoding:'utf8'});
 if(result.error||result.status!==0)throw new Error(result.error?.message||result.stderr||'Reply receipt installer failed.');
}
test('installer is idempotent and preserves unsuccessful reply results',async t=>{
 const dir=fs.mkdtempSync(path.join(os.tmpdir(),'rereview-receipt-'));t.after(()=>fs.rmSync(dir,{recursive:true,force:true}));
 const original="exports.HANDLER_TYPE='reply_to_pull_request_review_comment';exports.main=async()=>async()=>({success:false,comment_id:123,reply_id:456,error:'failed'});";
 fs.writeFileSync(path.join(dir,'reply_to_pr_review_comment.cjs'),original);
 installReplyReceipts(dir);installReplyReceipts(dir);
 assert.equal(fs.readFileSync(path.join(dir,'reply_to_pr_review_comment_impl.cjs'),'utf8'),original);
 const module=require(path.join(dir,'reply_to_pr_review_comment.cjs'));
 assert.deepEqual(await (await module.main())(),{success:false,comment_id:123,reply_id:456,error:'failed'});
});
test('only successful replies with a positive integer ID acquire receipt metadata',async t=>{
 for(const replyId of [0,-1,1.5,'456',null]) {
  const dir=fs.mkdtempSync(path.join(os.tmpdir(),'rereview-receipt-'));t.after(()=>fs.rmSync(dir,{recursive:true,force:true}));
  const result={success:true,comment_id:123,reply_id:replyId};
  fs.writeFileSync(path.join(dir,'reply_to_pr_review_comment.cjs'),`exports.main=async()=>async()=>(${JSON.stringify(result)});`);
  installReplyReceipts(dir);
  const handler=await require(path.join(dir,'reply_to_pr_review_comment.cjs')).main();
  assert.deepEqual(await handler(),result);
 }
});
test('installer fails closed when the pinned reply handler is missing',t=>{
 const dir=fs.mkdtempSync(path.join(os.tmpdir(),'rereview-receipt-'));t.after(()=>fs.rmSync(dir,{recursive:true,force:true}));
 assert.throws(()=>installReplyReceipts(dir));
});
test('successful reply IDs survive the real pinned manifest extraction and serialization',async t=>{
 const dir=fs.mkdtempSync(path.join(os.tmpdir(),'rereview-receipt-'));t.after(()=>fs.rmSync(dir,{recursive:true,force:true}));
 fs.writeFileSync(path.join(dir,'reply_to_pr_review_comment.cjs'),"exports.HANDLER_TYPE='reply_to_pull_request_review_comment';exports.main=async()=>async()=>({success:true,comment_id:123,reply_id:456});");
 installReplyReceipts(dir);
 const module=require(path.join(dir,'reply_to_pr_review_comment.cjs'));assert.equal(module.HANDLER_TYPE,'reply_to_pull_request_review_comment');
 const result=await (await module.main())();
 const actions=process.env.GH_AW_TEST_ACTIONS_DIR;assert.ok(actions);
 const {extractCreatedItemFromResult,createManifestLogger}=require(path.join(actions,'safe_output_manifest.cjs'));
 const item=extractCreatedItemFromResult('reply_to_pull_request_review_comment',result);
 const filename=path.join(dir,'manifest.jsonl');createManifestLogger(filename)(item);
 const receipt=JSON.parse(fs.readFileSync(filename,'utf8').trim());
 assert.equal(receipt.id,123);assert.equal(receipt.metadata.reply_id,456);
});
