'use strict';

const assert = require('node:assert/strict');
const { test } = require('node:test');
const { runQueue, makeWorklist, nextBatch, buildOutputs, assertPublication, workerArguments, parseWorkerResult, workerPrompt } = require('../pr-re-review/ReviewContinuation.cjs');
const crypto = require('node:crypto');
const { requiredInputs, snapshotDigest } = require('../pr-re-review/ReviewDelivery.cjs');

const snapshot = (count = 106) => ({
  pull_number: 64192, head_sha: 'a'.repeat(40), base_sha: 'b'.repeat(40), diff_base_sha: 'b'.repeat(40), changed_files: count,
  files: Array.from({ length: count }, (_, i) => ({ filename: `src/File${i}.cs`, status: 'modified', patch: '@@ -1 +1 @@\n-old\n+new' })),
  threads: [{ id: 'thread-1', isResolved: false, comments: [{ databaseId: 123, body: 'prior finding', path: 'src/File0.cs' }] }],
});
const complete = items => ({ results: items.map(item => ({ id: item.id, status: 'complete', reasoning: 'Read the current patch and related code; no additional finding.', findings: [], action: 'none' })) });

// Original regression: the CLI exits successfully after voluntarily declining a
// 106-file review. A process-success retry is not enough; pending work must drive continuation.
test('continues after a successful early exit on the original 106-file PR', async () => {
  const work = makeWorklist(snapshot());
  let calls = 0;
  const ledger = await runQueue(work, {
    deadline: Date.now() + 60000,
    runBatch: async items => ++calls === 1 ? { results: [], reason: 'Fully verifying all 106 files is too heavy.' } : complete(items),
  });
  assert.equal(ledger.results.length, 107);
  assert.ok(calls > 1);
  assert.equal(new Set(ledger.results.map(x => x.id)).size, 107);
  const outputs = buildOutputs(snapshot(), ledger);
  assert.match(outputs.at(-1).body, /Coverage: 1\/1 threads fetched, 1\/1 unresolved threads verified, 106\/106 changed files reviewed/);
});

test('preserves partial progress and retries only unfinished items', async () => {
  const s = snapshot(3);
  s.threads = [];
  const work = makeWorklist(s);
  const assigned = [];
  const ledger = await runQueue(work, {
    deadline: Date.now() + 60000,
    runBatch: async items => {
      assigned.push(items.map(x => x.id));
      return assigned.length === 1 ? complete(items.slice(0, 1)) : complete(items);
    },
  });
  assert.equal(ledger.results.length, 3);
  assert.ok(!assigned[1].includes(assigned[0][0]));
});

test('normalizes empty optional replies from real CLI results without losing reviewed items', async () => {
  for (const reply of ['', null]) {
    const ledger=await runQueue(makeWorklist(snapshot(0)), { deadline:Date.now()+60000,
      runBatch:async items=>({results:complete(items).results.map(r=>({...r,reply}))}) });
    assert.equal(ledger.results.length,1);
    assert.equal(ledger.results[0].reply,undefined);
  }
});

test('clean no-progress responses do not abandon review while time remains', async () => {
  let calls=0;
  const ledger=await runQueue(makeWorklist(snapshot(1)), {deadline:Date.now()+60000,
    runBatch:async items=>++calls<=5 ? {results:[],reason:'The PR seems too large.'} : complete(items)});
  assert.equal(ledger.results.length,2);
  assert.ok(calls>5);
});

test('continued zero progress ends only at the actual deadline without a review', async t => {
  t.mock.timers.enable({apis:['Date'],now:1000});
  let calls=0;
  await assert.rejects(runQueue(makeWorklist(snapshot()), {deadline:1100,
    runBatch:async()=>{calls++;t.mock.timers.tick(10);return {results:[]};}}),/deadline/i);
  assert.equal(calls,10);
});

test('real worker errors and exhausted deadlines fail without treating items as reviewed', async () => {
  await assert.rejects(runQueue(makeWorklist(snapshot()), {
    deadline: Date.now() + 60000, runBatch: async () => { throw new Error('file read denied'); },
  }), /file read denied/);
  let called = false;
  await assert.rejects(runQueue(makeWorklist(snapshot()), {
    deadline: Date.now() - 1, runBatch: async () => { called = true; },
  }), /deadline/i);
  assert.equal(called, false);
});

test('rejects invented IDs, duplicates and unsupported completion claims', async () => {
  for (const result of [
    { results: [{ ...complete([{ id: 'invented' }]).results[0] }] },
    { results: [complete([{ id: 'file:0' }]).results[0], complete([{ id: 'file:0' }]).results[0]] },
    { results: [{ id: 'file:0', status: 'complete', reasoning: '', findings: [], action: 'none' }] },
  ]) {
    await assert.rejects(runQueue(makeWorklist(snapshot(1)), { deadline: Date.now() + 60000, runBatch: async () => result }), /invalid|duplicate|assigned|reasoning/i);
  }
});

test('batches by patch size as well as file count without dropping oversized files', async () => {
  const s = snapshot(12);
  s.files[0].patch = 'x'.repeat(100000);
  const sizes = [];
  await runQueue(makeWorklist(s), {
    deadline: Date.now() + 60000,
    runBatch: async items => { sizes.push(items.length); return complete(items); },
  });
  assert.equal(sizes[0], 1);
  assert.ok(Math.max(...sizes) <= 8);
});

test('batches at the exact serialized UTF-8 limit and isolates oversized files', () => {
  const item = (index, bytes, multibyte = false) => {
    const value = { id: `file:${index}`, file: { filename: `src/${index}.cs`, status: 'modified', patch: '' } };
    const remaining = bytes - Buffer.byteLength(JSON.stringify(value));
    assert.ok(remaining >= 0);
    value.file.patch = multibyte ? 'é'.repeat(Math.floor(remaining / 2)) + (remaining % 2 ? 'x' : '') : 'x'.repeat(remaining);
    assert.equal(Buffer.byteLength(JSON.stringify(value)), bytes);
    return value;
  };
  const small = item(0, 24000), at = item(1, 24000, true), over = item(1, 24001, true);
  const huge = item(0, 48001), next = item(1, 100);
  assert.deepEqual(nextBatch([small, at]), [small, at]);
  assert.deepEqual(nextBatch([small, over]), [small]);
  assert.deepEqual(nextBatch([huge, next]), [huge]);
  assert.deepEqual(nextBatch([next]), [next]);
});

test('offloading and receipt requirements agree at UTF-8 byte boundaries', () => {
  for (const patch of ['x'.repeat(47999), 'x'.repeat(48000), 'x'.repeat(48001), 'é'.repeat(23999) + 'x', 'é'.repeat(24000), 'é'.repeat(24000) + 'x']) {
    const s = snapshot(1); s.threads = []; s.files[0].patch = patch;
    const item = makeWorklist(s)[0], bytes = Buffer.byteLength(patch);
    const context = JSON.parse(workerPrompt('', s, [item], 'a'.repeat(32)).split('\n').at(-1));
    const assigned = context.assigned[0].file, requirements = requiredInputs(s, item);
    if (bytes <= 48000) {
      assert.equal(assigned.patch, patch);
      assert.equal(assigned.patch_path, undefined);
      assert.deepEqual(requirements, []);
    } else {
      assert.equal(assigned.patch, undefined);
      assert.match(assigned.patch_path, /file-0\.patch$/);
      assert.equal(requirements.length, 1);
      assert.equal(requirements[0].kind, 'patch');
    }
  }
});

test('omitted patches and deleted/renamed files remain explicit work items', () => {
  const s = snapshot(3);
  delete s.files[0].patch;
  s.files[1].status = 'removed';
  s.files[2].status = 'renamed';
  s.files[2].previous_filename = 'src/Old.cs';
  const work = makeWorklist(s);
  assert.equal(work.length, 4);
  assert.equal(work.find(x => x.id === 'file:0').file.patch, undefined);
  assert.equal(work.find(x => x.id === 'file:1').file.status, 'removed');
  assert.equal(work.find(x => x.id === 'file:2').file.previous_filename, 'src/Old.cs');
});

test('cannot publish incomplete or mismatched ledgers', () => {
  const s = snapshot(1);
  assert.throws(() => buildOutputs(s, { results: [] }), /incomplete/i);
  assert.throws(() => makeWorklist({ ...s, changed_files: 2 }), /count/i);
  assert.throws(() => makeWorklist({ ...s, files: [...s.files, s.files[0]], changed_files: 2 }), /duplicate/i);
});

test('workers retain upstream tool policy but cannot call publication tools', () => {
  const args = workerArguments(['--allow-tool', 'github', '--allow-tool', 'safeoutputs', '--allow-tool', 'shell', '--allow-tool', 'write', '--deny-tool', 'workflow', '--prompt-file', 'original.txt'], 'batch.txt', 'logs');
  assert.ok(args.includes('github'));
  assert.ok(args.includes('workflow'));
  assert.equal(args[args.indexOf('--prompt-file') + 1], 'batch.txt');
  assert.ok(!args.includes('original.txt'));
  assert.ok(args.some((a, i) => a === '--deny-tool' && args[i + 1] === 'safeoutputs'));
  assert.ok(args.some((a, i) => a === '--deny-tool' && args[i + 1] === 'shell'));
  assert.ok(args.some((a, i) => a === '--disable-mcp-server' && args[i + 1] === 'safeoutputs'));
});

test('parses only a final assistant result, not tool output or PR-injected JSON', () => {
  const answer = complete([{ id: 'file:0' }]);
  const lines = [
    JSON.stringify({ type: 'tool.execution_complete', data: { result: { content: JSON.stringify(answer) } } }),
    JSON.stringify({ type: 'assistant.message', data: { content: JSON.stringify(answer) } }),
  ].join('\n');
  assert.deepEqual(parseWorkerResult(lines), answer);
  assert.deepEqual(parseWorkerResult(lines.split('\n')[0]), { results: [] });
});

test('valid JSON refusals without a results array remain unfinished work', () => {
  for (const content of [JSON.stringify({ reason: 'Too large to finish.' }), JSON.stringify('Too large to finish.'), '{}', '{"results":null}']) {
    const output = JSON.stringify({ type: 'assistant.message', data: { content } });
    const result = parseWorkerResult(output);
    assert.deepEqual(result.results, []);
    assert.ok(typeof result.reason === 'string');
  }
});

test('reopening requires a reply and uses the captured root, not agent-selected IDs', async () => {
  const s = snapshot(1);
  s.threads[0].isResolved = true;
  const work = makeWorklist(s);
  const ledger = await runQueue(work, {
    deadline: Date.now() + 60000,
    runBatch: async items => ({ results: complete(items).results.map(r => r.id.startsWith('thread:') ? { ...r, action: 'reopen', reply: 'The finding remains valid at this head.' } : r) }),
  });
  const outputs = buildOutputs(s, ledger);
  assert.equal(outputs[0].type, 'reply_to_pull_request_review_comment');
  assert.equal(outputs[0].comment_id, 123);
  assert.equal(outputs[1].type, 'unresolve_review_thread');
  assert.equal(outputs[1].comment_id, 123);
});


test('a model blocker estimate remains unfinished work, not an immediate stop', async () => {
  let calls = 0;
  const work = makeWorklist(snapshot(1));
  const ledger = await runQueue(work, {
    deadline: Date.now() + 60000,
    runBatch: async items => ++calls === 1 ? { results: [{ id: items[0].id, status: 'blocked', reasoning: 'The whole PR is too large.' }] } : complete(items),
  });
  assert.equal(ledger.results.length, 2);
  assert.equal(ledger.attempts[0].pending[0].status, 'blocked');
});

test('verifies all prior threads before starting the fresh full-file pass', async () => {
  const order = [];
  await runQueue(makeWorklist(snapshot(3)), {
    deadline: Date.now() + 60000,
    runBatch: async items => { order.push(items.map(x => x.id)); return complete(items); },
  });
  assert.deepEqual(order[0], ['thread:0']);
  assert.ok(order[1].every(id => id.startsWith('file:')));
});

test('publication identity matches canonical snapshot digest with Unicode and property ordering', () => {
  const s = snapshot(1); s.files[0].filename = 'src/é😀.cs'; s.files[0].patch = 'hé😀\ud83d';
  const progress = { ...complete(makeWorklist(s)), head_sha: s.head_sha, base_sha: s.base_sha,
    snapshot_sha256: crypto.createHash('sha256').update(JSON.stringify(s)).digest('hex') };
  assert.equal(snapshotDigest(s), progress.snapshot_sha256);
  const output = { items: buildOutputs(s, progress), errors: [] };
  assert.doesNotThrow(() => assertPublication(s, progress, output, 'success'));
  const reordered = { base_sha: s.base_sha, ...s };
  assert.notEqual(snapshotDigest(reordered), progress.snapshot_sha256);
  assert.throws(() => assertPublication(reordered, progress, output, 'success'), /captured snapshot/);
});

test('publication rejects every write from a failed or incomplete controller', () => {
  const s = snapshot(1);
  const progress = { ...complete(makeWorklist(s)), head_sha: s.head_sha, base_sha: s.base_sha,
    snapshot_sha256: crypto.createHash('sha256').update(JSON.stringify(s)).digest('hex') };
  const output = { items: buildOutputs(s, progress), errors: [] };
  assertPublication(s, progress, output, 'success');
  for (const status of ['failure', 'cancelled', 'skipped', '']) assert.throws(() => assertPublication(s, progress, output, status), /refusing all publication/);
  assert.throws(() => assertPublication(s, { ...progress, results: [] }, output, 'success'), /incomplete/i);
});

test('publication checks actual buffered outputs against captured complete results', () => {
  const s = snapshot(1);
  const progress = { ...complete(makeWorklist(s)), head_sha: s.head_sha, base_sha: s.base_sha,
    snapshot_sha256: crypto.createHash('sha256').update(JSON.stringify(s)).digest('hex') };
  const output = { items: buildOutputs(s, progress), errors: [] };
  assert.throws(() => assertPublication(s, { ...progress, snapshot_sha256: 'forged' }, output, 'success'), /captured snapshot/);
  assert.throws(() => assertPublication(s, progress, { ...output, items: output.items.map(x => ({ ...x, owner: 'other' })) }, 'success'), /differ/);
  assert.throws(() => assertPublication(s, progress, { ...output, items: [...output.items, { type: 'resolve_pull_request_review_thread', thread_id: 'invented' }] }, 'success'), /do not match/);
  const sanitized={...output,items:output.items.map(item=>({...item,...(item.body?{body:item.body.replace(/No new findings\./,'Sanitized review text.')}:{})}))};
  assert.doesNotThrow(()=>assertPublication(s,progress,sanitized,'success'));
  const wrapped = { ...output, items: output.items.map(item => item.type === 'submit_pull_request_review'
    ? { ...item, body: item.body.replace(/^Coverage: (.*)$/m, '> - **Coverage: $1.**') } : item) };
  assert.doesNotThrow(() => assertPublication(s, progress, wrapped, 'success'));
  for (const body of [
    'Coverage: 0/0 threads fetched, 0/0 unresolved threads verified, 0/0 changed files reviewed',
    'Coverage: 1/1 threads fetched, 1/1 unresolved threads verified, 0/1 changed files reviewed',
    'No coverage line',
    `${output.items.at(-1).body}\nCoverage: 0/0 threads fetched, 0/0 unresolved threads verified, 0/0 changed files reviewed`,
  ]) {
    const altered = { ...output, items: output.items.map(item => item.type === 'submit_pull_request_review' ? { ...item, body } : item) };
    assert.throws(() => assertPublication(s, progress, altered, 'success'), /coverage/i);
  }
  assert.throws(()=>assertPublication(s,progress,{...output,items:output.items.map(item=>({...item,event:'APPROVE'}))},'success'),/routing/);
});

test('surfaces added central ApiCompat suppressions even when the worker reports no findings', () => {
  const s = snapshot(1);
  s.files[0] = { filename: 'eng/apicompatbaselines/Azure.ResourceManager.Compute.Recommender.xml', status: 'added' };
  s.baseline_suppressions = [{ path: s.files[0].filename, fields: { DiagnosticId: 'CP0001', Target: 'T:Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData' }, nearby_comment: 'Intentional Diagnostic-to-PlacementScores API renames for API version 2026-10-05-preview.' }];
  const ledger = complete(makeWorklist(s));
  const output = buildOutputs(s, ledger).at(-1).body;
  assert.match(output, /CP0001/);
  assert.match(output, /ComputeRecommenderDiagnosticData/);
  assert.match(output, /Intentional Diagnostic-to-PlacementScores/);
  const progress = { ...ledger, head_sha: s.head_sha, base_sha: s.base_sha,
    snapshot_sha256: crypto.createHash('sha256').update(JSON.stringify(s)).digest('hex') };
  const buffered = { items: buildOutputs(s, progress), errors: [] };
  assert.doesNotThrow(() => assertPublication(s, progress, buffered, 'success'));
  const altered = { ...buffered, items: buffered.items.map(item => item.type === 'submit_pull_request_review'
    ? { ...item, body: item.body.replace('CP0001', 'CP0002') } : item) };
  assert.throws(() => assertPublication(s, progress, altered, 'success'), /suppression/i);
  const fenced = { ...buffered, items: buffered.items.map(item => item.type === 'submit_pull_request_review'
    ? { ...item, body: item.body.replace('## New ApiCompat suppressions', '```\n## New ApiCompat suppressions').concat('\n```') } : item) };
  assert.throws(() => assertPublication(s, progress, fenced, 'success'), /suppression/i);
  const uncaptured = { ...s }; delete uncaptured.baseline_suppressions;
  assert.throws(() => buildOutputs(uncaptured, ledger), /missing captured baseline/i);
});

test('references a prior review inventory instead of presenting it as fresh feedback', () => {
  const s = snapshot(1);
  s.files[0] = { filename: 'eng/apicompatbaselines/Azure.Test.xml', status: 'added' };
  s.baseline_suppressions = [{ path: s.files[0].filename, fields: { DiagnosticId: 'CP0001', Target: 'T:Test' }, nearby_comment: null }];
  const ledger = complete(makeWorklist(s));
  const old = buildOutputs(s, ledger).at(-1).body;
  s.reviews = [{ id: 555, body: old }];
  s.baseline_suppressions[0].nearby_comment = 'A revised explanation.';
  assert.match(buildOutputs(s, ledger).at(-1).body, /prior review (?:ID )?555/i);
  s.reviews = [];
  s.threads[0].comments[0].path = s.files[0].filename;
  s.threads[0].comments[0].body = 'Existing feedback: CP00010 T:TestMore';
  assert.doesNotMatch(buildOutputs(s, ledger).at(-1).body, /prior review comment ID/i);
  s.threads[0].comments[0].body = 'Existing feedback: `CP0001` and `T:Test`';
  assert.match(buildOutputs(s, ledger).at(-1).body, /prior review comment ID/i);
});

test('suppression inventory survives the pinned gh-aw sanitizer for URL-containing comments', { skip: !process.env.GH_AW_TEST_ACTIONS_DIR }, () => {
  const { sanitizeContent } = require(require('node:path').join(process.env.GH_AW_TEST_ACTIONS_DIR, 'sanitize_content.cjs'));
  global.core = { info() {}, warning() {}, debug() {} };
  const s = snapshot(1);
  s.files[0] = { filename: 'eng/apicompatbaselines/Azure.Test.xml', status: 'added' };
  s.baseline_suppressions = [{ path: s.files[0].filename, fields: { DiagnosticId: 'CP0015', Target: 'T:Azure.ResourceManager.Hci.HciEdgeDeviceData:[T:System.ClientModel.Primitives.PersistableModelProxyAttribute]' }, nearby_comment: 'See https://example.invalid/reason' }];
  const progress = { ...complete(makeWorklist(s)), head_sha: s.head_sha, base_sha: s.base_sha, snapshot_sha256: crypto.createHash('sha256').update(JSON.stringify(s)).digest('hex') };
  const output = { items: buildOutputs(s, progress).map(item => item.body ? { ...item, body: sanitizeContent(item.body) } : item), errors: [] };
  assert.doesNotThrow(() => assertPublication(s, progress, output, 'success'));
});

test('publication rejects matching but invented unresolved counts when no threads are unresolved', () => {
  const s = snapshot(1); s.threads[0].isResolved = true;
  const progress = { ...complete(makeWorklist(s)), head_sha: s.head_sha, base_sha: s.base_sha,
    snapshot_sha256: crypto.createHash('sha256').update(JSON.stringify(s)).digest('hex') };
  const output = { items: buildOutputs(s, progress), errors: [] };
  assert.doesNotThrow(() => assertPublication(s, progress, output, 'success'));
  const altered = { ...output, items: output.items.map(item => item.type === 'submit_pull_request_review'
    ? { ...item, body: item.body.replace('0/0 unresolved', '5/5 unresolved') } : item) };
  assert.throws(() => assertPublication(s, progress, altered, 'success'), /coverage/i);
});

test('deleted-file findings use LEFT rather than an invalid RIGHT anchor', async () => {
  const s = snapshot(1); s.threads = []; s.files[0].status = 'removed';
  const ledger = await runQueue(makeWorklist(s), { deadline: Date.now() + 60000,
    runBatch: async items => ({ results: complete(items).results.map(r => ({ ...r, findings: [{ path: s.files[0].filename, line: 1, body: 'Removed a shipped member.' }] })) }) });
  assert.equal(buildOutputs(s, ledger)[0].side, 'LEFT');
});

test('resolution requires a substantive reply before any thread mutation', async () => {
  const s = snapshot(0);
  await assert.rejects(runQueue(makeWorklist(s), { deadline: Date.now() + 60000,
    runBatch: async items => ({ results: complete(items).results.map(r => ({ ...r, action: 'resolve' })) }) }), /reply/);
});

test('empty review persists a complete progress ledger', async () => {
  const s = snapshot(0); s.threads = [];
  let persisted;
  const ledger = await runQueue(makeWorklist(s), { deadline: Date.now() + 60000, runBatch: async () => { throw new Error('No worker needed'); }, checkpoint: value => { persisted = value; } });
  assert.deepEqual(persisted, ledger);
});

test('workers use captured repository identities and GitHub MCP for source reads', () => {
  const s = snapshot(1);
  s.base_repo = 'Azure/azure-sdk-for-net';
  s.head_repo = 'fork/azure-sdk-for-net';
  s.diff_base_sha = 'c'.repeat(40);
  s.files[0] = { filename: 'new.cs', previous_filename: 'old.cs', status: 'renamed' };
  const prompt = workerPrompt('Trusted rules.', s, makeWorklist(s), 'a'.repeat(32));
  assert.match(prompt, /get_file_contents/);
  assert.match(prompt, /tool's sha parameter/);
  assert.match(prompt, /do not use ref/);
  assert.match(prompt, /head_repo/);
  assert.match(prompt, /base_repo/);
  assert.ok(prompt.includes(s.head_repo) && prompt.includes(s.base_repo));
  assert.match(prompt, /head for additions, diff base for removals, and both diff base and head for modifications and renames/);
  assert.match(prompt, /previous_filename at the diff base for renames/);
  assert.ok(prompt.includes(s.diff_base_sha));
  assert.match(prompt, /base-branch tip.*freshness checks, not the old side/);
  assert.match(prompt, /base repository may be tried only at that same head SHA/);
  assert.match(prompt, /inaccessible resource link/);
  assert.match(prompt, /blocked/i);
  assert.match(prompt, /Source reads are model-attested/);
  assert.match(prompt, /read-review-input/);
  assert.doesNotMatch(prompt, /read-review-source/);
  assert.throws(() => workerPrompt('', { ...s, diff_base_sha: undefined }, makeWorklist(s), 'a'.repeat(32)), /diff base/i);
});

test('workers reuse captured review context without mandatory per-batch refetch', () => {
  const fs = require('node:fs'); const path = require('node:path');
  const workflow = fs.readFileSync(path.join(__dirname, '..', 'pr-re-review.md'), 'utf8');
  const step = workflow.split('## Step 1 - Gather review history\n')[1].split('## Step 2 - Verify every existing thread')[0];
  assert.match(step, /captured context index/i);
  assert.match(step, /captured prior reviews/i);
  assert.match(step, /read-review-input/i);
  assert.match(step, /all captured thread histories before proposing a new finding/i);
  assert.match(step, /author.*timestamps.*is_outdated/i);
  assert.match(step, /publishedAt/);
  assert.match(step, /submittedAt/);
  assert.match(step, /later public timestamp/i);
  assert.match(step, /substantive edits.*updatedAt/i);
  assert.match(step, /get_review_comments/);
  assert.match(step, /`after`/);
  assert.doesNotMatch(step, /^- `get_review_comments`: every review thread/m);
  assert.doesNotMatch(step, /^- `get_reviews`: all prior reviews/m);
  const step4 = workflow.split('## Step 4 - Confirm coverage, then submit one review')[1];
  assert.match(step4, /captured thread count/i);
  assert.doesNotMatch(step4, /`<total>` is the `get_review_comments`/);
});

test('large shared histories and a large patch are not inlined into each bounded prompt', () => {
  const s = snapshot(1); s.threads[0].comments[0].body = 'history'.repeat(200000);
  s.reviews = [{ body: 'prior review'.repeat(200000) }]; s.files[0].patch = 'large patch'.repeat(200000);
  const prompt = workerPrompt('Trusted review rules.', s, makeWorklist(s), []);
  assert.ok(Buffer.byteLength(prompt) < 70000, 'Prompt must refer to paged read-only context instead of loading all history/patch text.');
});

test('trusted helper checkout precedes capture on a clean agent runner', () => {
  const fs = require('node:fs'); const path = require('node:path');
  const workflow = fs.readFileSync(path.join(__dirname, '..', 'pr-re-review.lock.yml'), 'utf8').split('\n  agent:\n')[1].split('\n  check_safe_output_status:')[0];
  const capture = workflow.indexOf('name: Capture all changed-file pages');
  const checkout = workflow.indexOf('name: Checkout trusted review helpers');
  assert.ok(checkout >= 0 && checkout < capture, 'No checkout from another job can supply these helper files.');
});
