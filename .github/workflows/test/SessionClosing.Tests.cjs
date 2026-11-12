'use strict';
const assert=require('node:assert/strict');
const {test}=require('node:test');
const fs=require('node:fs'),path=require('node:path'),os=require('node:os');
const {startContinuationSession}=require('../pr-re-review/ReviewContinuationSession.cjs');
test('request after close starts is rejected without poisoning orderly shutdown',{timeout:10000},async t=>{
 const dir=fs.mkdtempSync(path.join(os.tmpdir(),'core-close-')),exe=path.join(dir,'host');
 fs.writeFileSync(exe,'#!/usr/bin/env node\nconst rl=require("node:readline").createInterface({input:process.stdin});rl.on("line",line=>{const r=JSON.parse(line);process.stdout.write(JSON.stringify({id:r.id,result:true})+"\\n")});rl.on("close",()=>setTimeout(()=>process.exit(0),100));',{mode:0o755});
 const prior=process.env.GH_AW_REVIEW_PWSH;process.env.GH_AW_REVIEW_PWSH=exe;
 t.after(()=>{if(prior===undefined)delete process.env.GH_AW_REVIEW_PWSH;else process.env.GH_AW_REVIEW_PWSH=prior;fs.rmSync(dir,{recursive:true,force:true});});
 const session=startContinuationSession();await session.request('probe',{});
 const closing=session.close();
 const late=session.request('probe',{});
 const outcomes=await Promise.allSettled([late,closing]);
 assert.equal(outcomes[0].status,'rejected');assert.match(outcomes[0].reason.message,/closing|closed/i);
 assert.equal(outcomes[1].status,'fulfilled');assert.equal(session.signal.aborted,false);
});
