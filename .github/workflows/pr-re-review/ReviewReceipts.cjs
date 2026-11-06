'use strict';
const fs = require('node:fs');
const path = require('node:path');

// Preserve the actual new reply ID in gh-aw's applied-item manifest so the
// delayed mutation can distinguish this run's replies from external changes.
function installReplyReceipts(actionsDirectory) {
  const original=path.join(actionsDirectory,'reply_to_pr_review_comment.cjs');
  const implementation=path.join(actionsDirectory,'reply_to_pr_review_comment_impl.cjs');
  if(!fs.existsSync(implementation))fs.copyFileSync(original,implementation);
  fs.writeFileSync(original, `'use strict';\nconst impl=require('./reply_to_pr_review_comment_impl.cjs');\nmodule.exports={...impl,main:async(...args)=>{\n const handler=await impl.main(...args);\n return async(...args)=>{const result=await handler(...args);\n  return result?.success && Number.isSafeInteger(result.reply_id) && result.reply_id>0\n   ? {...result,metadata:{...result.metadata,reply_id:result.reply_id}} : result;\n };\n}};\n`);
}
module.exports={installReplyReceipts};
