'use strict';
const {test}=require('node:test'); const assert=require('node:assert/strict');
const fs=require('node:fs'),path=require('node:path'),os=require('node:os');
const {installReplyReceipts}=require('../pr-re-review/ReviewReceipts.cjs');
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
