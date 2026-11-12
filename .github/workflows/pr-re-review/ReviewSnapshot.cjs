'use strict';
const fs=require('node:fs'),path=require('node:path');
const {snapshotDigest,MAX_BATCH_BYTES}=require('./ReviewDelivery.cjs');
function encodeScalar(value){
 if(value===null)return {kind:'null'};
 const kind=typeof value;
 if(kind==='undefined')return {kind};
 if(kind==='number'&&Number.isNaN(value))return {kind:'nan'};
 if(['string','number','boolean'].includes(kind))return {kind,value:String(value)};
 return {kind};
}
function encodeReviewProof(review){
 // The original validator checks the actual entry/path before dereferencing
 // the expected review. Defer that native error until PowerShell reaches it.
 if(review==null)return {expectedReadError:review===null?'null':'undefined',expectedCanonical:JSON.stringify(review)};
 return {expectedId:encodeScalar(review.id),expectedState:encodeScalar(review.state),expectedCanonical:JSON.stringify(review)};
}
function encodeExportOptions(snapshot,directory,{timeoutMs=22*60*1000}={}){
 if(!Number.isSafeInteger(timeoutMs)||timeoutMs<=0)throw Error('Invalid delivery capture deadline.');
 if(!directory)throw Error('Invalid review context directory.');
 const marker='__REVIEW_BASENAME__';
 return {directory:path.normalize(directory),pathPrefix:path.join(directory,marker).slice(0,-marker.length),timeoutMs,reviews:snapshot.reviews||[]};
}
async function runContextExporter(snapshot,settings,signal,runner){
 const run=runner||require('./ReviewDelivery.cjs').runPowerShell;
 const result=await run('Export-ReviewContext.ps1',JSON.stringify({snapshot,maxBatchBytes:MAX_BATCH_BYTES,directory:settings.directory,pathPrefix:settings.pathPrefix}),{timeoutMs:settings.timeoutMs,timeoutReason:'Delivery index capture timed out.',label:'Delivery index capture',maxOutputBytes:Math.max(16*1024*1024,(snapshot.files.length+snapshot.threads.length)*256+1024*1024),signal});
 let delivery;try{delivery=JSON.parse(result.stdout);}catch{throw Error('Invalid captured delivery index.');}
 return {delivery,snapshotHash:snapshotDigest(snapshot),indexCanonical:JSON.stringify(delivery)};
}
function readExportedContext(settings){
 try{
  const snapshot=JSON.parse(fs.readFileSync(path.join(settings.directory,'snapshot.json'),'utf8'));
  const index=JSON.parse(fs.readFileSync(path.join(settings.directory,'delivery-index.json'),'utf8'));
  const context=JSON.parse(fs.readFileSync(path.join(settings.directory,'index.json'),'utf8'));
  return {snapshotHash:snapshotDigest(snapshot),indexCanonical:JSON.stringify(index),context};
 }catch{return {readError:true};}
}
function readExportedReview(settings,context,index){
 const expectedPath=path.join(settings.directory,`review-${index}.json`);
 let history;try{history=JSON.parse(fs.readFileSync(expectedPath,'utf8'));}catch{return {readError:true};}
 const entry=context.reviews[index],expected=encodeReviewProof(settings.reviews[index]);
 return {expectedPath,actualCanonical:JSON.stringify(history),...expected,actualId:encodeScalar(entry?.id),actualState:encodeScalar(entry?.state)};
}

// Native boundary only: execute read-only effects with the caller's
// existing injected client. PowerShell owns capture order and acceptance.
const {startContinuationSession}=require('./ReviewContinuationSession.cjs');
function add(a,b){if(!Number.isSafeInteger(a)||a<0||!Number.isSafeInteger(b)||b<0||!Number.isSafeInteger(a+b))throw Error('Capture byte accounting overflow.');return a+b;}
function budget(bytes,generated){const value=6*bytes+generated+32768;if(!Number.isSafeInteger(value)||value<=0)throw Error('Capture response budget overflow.');return value;}
async function effectResult(github,effect,signal,options){
 if(signal.aborted)throw signal.reason||Error('Capture host failed.');
 let cancel;
 const aborted=new Promise((_,reject)=>{cancel=()=>reject(signal.reason||Error('Capture host failed.'));if(signal.aborted)cancel();else signal.addEventListener('abort',cancel,{once:true});});
 const action=async()=>{
  switch(effect.kind){
   case 'pull':return (await github.rest.pulls.get(effect.arguments)).data;
   case 'files':return (await github.rest.pulls.listFiles(effect.arguments)).data;
   case 'threads':case 'comments':return await github.graphql(effect.query,effect.arguments);
   case 'reviews':return await github.paginate(github.rest.pulls.listReviews,effect.arguments);
   case 'compare':return (await github.request('GET /repos/{owner}/{repo}/compare/{basehead}',effect.arguments)).data;
   case 'manifest':
    if(typeof options.onManifest!=='function')throw Error('Missing manifest checkpoint writer.');
    await options.onManifest(effect.arguments.manifest);return true;
   case 'baseline': {
    const timeoutMs=options.timeoutMs===undefined?22*60*1000:options.timeoutMs;
    if(!Number.isSafeInteger(timeoutMs)||timeoutMs<=0)throw Error('Invalid baseline capture deadline.');
    let result;
    try{const run=options.runBaseline||require('./ReviewDelivery.cjs').runPowerShell;result=await run('ReviewBaselines.ps1',JSON.stringify(effect.arguments),{scriptArgs:['-Capture'],timeoutMs,timeoutReason:'Baseline capture timed out.',label:'Baseline capture',maxOutputBytes:16*1024*1024,signal});}
    catch(error){throw Error(`Cannot capture baselines: ${error.message}`);}
    return JSON.parse(result.stdout);
   }
   case 'export': {
    if(typeof options.onSnapshot==='function')await options.onSnapshot(structuredClone(effect.arguments.snapshot));
    options._exportSettings=options.exportSettings||encodeExportOptions(effect.arguments.snapshot,options.exportDirectory,{timeoutMs:options.exportTimeoutMs});
    return await runContextExporter(effect.arguments.snapshot,options._exportSettings,signal,options.runExporter);
   }
   case 'export-base': {
    const value=readExportedContext(options._exportSettings);options._exportContext=value.context;return value;
   }
   case 'export-history': {
    const index=effect.arguments.index;
    if(!Number.isSafeInteger(index)||index<0||index>=options._exportSettings.reviews.length)throw Error('Invalid exported history read.');
    return readExportedReview(options._exportSettings,options._exportContext,index);
   }
   default:throw Error('Invalid capture transport effect.');
  }
 };
 const running=action();
 try{return await Promise.race([running,aborted]);}
 catch(error){
  // HTTP effects retain their existing non-abortable client semantics. A
  // supervised child is different: do not return while its bounded teardown
  // is still in flight, especially while it retains capture credentials.
  if(['baseline','export'].includes(effect.kind)&&signal.aborted){
   try{await running;}catch(cleanupError){if(cleanupError!==error)throw new AggregateError([error,cleanupError],`${error.message}; ${cleanupError.message}`);}
  }
  throw error;
 }finally{signal.removeEventListener('abort',cancel);}
}
async function capture(github,input,options={}){
 const env=Object.fromEntries(Object.entries(process.env).filter(([name])=>!/(?:TOKEN|SECRET|PASSWORD|CREDENTIAL)/i.test(name)&&!['SSH_AUTH_SOCK','GIT_ASKPASS','SSH_ASKPASS'].includes(name)));
 const session=startContinuationSession({script:'ReviewCaptureHost.ps1',env});let failure,result,totalBytes=0,generated=0,lastEffect=0;
 const account=bytes=>{totalBytes=add(totalBytes,bytes);return 4096;};
 const responseBudget=bytes=>{totalBytes=add(totalBytes,bytes);return budget(totalBytes,generated);};
 try{
  const init=(await session.request('initialize',input,{maxResponseBytes:account})).value;
  if(!init||init.initialized!==true||Object.keys(init).length!==1)throw Error('Invalid capture initialization.');
  while(true){
   const next=(await session.request('next',{},{maxResponseBytes:responseBudget})).value;
   if(!next||typeof next.done!=='boolean')throw Error('Invalid capture response.');
   if(next.done){if(Object.keys(next).length!==1)throw Error('Invalid completed capture response.');break;}
   const effect=next.effect;
   if(Object.keys(next).length!==2||!effect||!Number.isSafeInteger(effect.effect_id)||effect.effect_id!==lastEffect+1||!effect.arguments||typeof effect.arguments!=='object'||Array.isArray(effect.arguments)||
      !['pull','files','threads','comments','reviews','compare','manifest','baseline','export','export-base','export-history'].includes(effect.kind)||(['threads','comments'].includes(effect.kind)&&typeof effect.query!=='string'))throw Error('Invalid capture effect.');
   if(input.mode==='files'&&!['pull','files'].includes(effect.kind))throw Error('Invalid changed-file effect.');
   lastEffect=effect.effect_id;
   const response=await effectResult(github,effect,session.signal,options);session.assertHealthy();
   // These are actual API-array lengths, not helper/model size estimates. Review
   // projection can generate fixed nullable fields even for tiny input rows.
   if(effect.kind==='reviews'&&Array.isArray(response))generated=add(generated,256*response.length);
   const accepted=(await session.request('accept',{effect_id:effect.effect_id,response},{maxResponseBytes:account})).value;
   if(!accepted||accepted.accepted!==true||Object.keys(accepted).length!==1)throw Error('Invalid capture acceptance response.');
  }
  result=(await session.request('finish',{},{maxResponseBytes:responseBudget})).value;
  if(!result||typeof result!=='object'||Array.isArray(result))throw Error('Invalid finalized capture.');
 }catch(error){failure=error;throw error;}
 finally{
  try{await session.close();}catch(error){if(!failure)throw error;if(error!==failure&&!(failure instanceof AggregateError&&failure.errors.includes(error)))throw new AggregateError([failure,error],`${failure.message}; capture cleanup failed: ${error.message}`);}
 }
 return result;
}
const captureChangedFiles=(github,identity)=>capture(github,{mode:'files',identity});
const captureReviewState=(github,repo,files,{includeReviews=true,preflight=false}={})=>capture(github,{mode:'review',repo,files,includeReviews,preflight});
const captureContext=(github,repo,files,options={})=>capture(github,{mode:'context',repo,files},options);
const captureWorkflowInputs=(github,identity,options={})=>capture(github,{mode:'full',identity,exportEnabled:options.exportDirectory!==undefined},options);
async function exportContext(snapshot,directory,options={}){
 const exportSettings=encodeExportOptions(snapshot,directory,options);
 const result=await capture(null,{mode:'export',snapshot},{exportSettings,runExporter:options.runExporter});
 if(result.exported!==true||Object.keys(result).length!==1)throw Error('Invalid export finalization.');
}

async function compareFreshness(input) {
 const {runPowerShell}=require('./ReviewDelivery.cjs');
 const result=await runPowerShell('ReviewFreshness.ps1',JSON.stringify(input),{timeoutMs:22*60*1000,timeoutReason:'Freshness verification timed out.',label:'Freshness verification',maxOutputBytes:4096});
 if(result.stdout!=='{}')throw Error(result.stderr||'Freshness verification failed.');
}
async function assertFresh(github,repo,snapshot){
 const input=await capture(github,{mode:'review',repo,files:snapshot,includeReviews:true,preflight:true,freshnessMode:'publication',extra:{}});
 await compareFreshness(input);
}
async function assertMutationFresh(github,repo,snapshot,rootIds,receipts){
 const input=await capture(github,{mode:'review',repo,files:snapshot,includeReviews:false,freshnessMode:'mutation',extra:{rootIds,receipts}});
 await compareFreshness(input);
}
module.exports={captureChangedFiles,captureReviewState,captureContext,captureWorkflowInputs,assertFresh,assertMutationFresh,exportContext};
