'use strict';
const assert = require('node:assert/strict');
const fs = require('node:fs');
const os = require('node:os');
const path = require('node:path');
const { spawnSync } = require('node:child_process');
const { test } = require('node:test');

// A subprocess-level fake models the actual failure: Copilot exits zero and
// returns an incomplete final response. Unlike a test of a prompt string, this
// exercises controller startup, CLI arguments, worker process lifecycle,
// durable progress and final buffered publication together.
function runtime(t, mode) {
  const root = fs.mkdtempSync(path.join(os.tmpdir(), 'rereview-runtime-'));
  t.after(() => fs.rmSync(root, { recursive: true, force: true }));
  const actions = path.join(root, 'actions');
  fs.mkdirSync(actions);
  for (const helper of ['ReviewContinuation.cjs', 'ReviewDelivery.cjs', 'ReviewReadSource.cjs', 'ReviewSourceServer.cjs', 'ReviewVerifyDelivery.ps1']) fs.copyFileSync(path.join(__dirname, '..', 'pr-re-review', helper), path.join(actions, helper));
  fs.mkdirSync(path.join(root, 'receipts'));
  const snapshot = {
    pull_number: 64192, head_sha: 'a'.repeat(40), base_sha: 'b'.repeat(40), changed_files: 106,
    files: Array.from({ length: 106 }, (_, i) => ({ filename: `src/File${i}.cs`, status: 'modified', patch: '@@ -1 +1 @@\n-old\n+new' })), threads: [],
  };
  if (['missing-input', 'delivered-input'].includes(mode)) {
    snapshot.files[0].patch = 'x'.repeat(50000);
    snapshot.threads = [{ id: 'thread-1', isResolved: false, comments: [{ databaseId: 123, path: 'src/File0.cs', body: 'prior concern' }] }];
  }
  const { exportContext } = require('../pr-re-review/ReviewSnapshot.cjs');
  exportContext(snapshot, path.join(actions, 'review-input'));
  fs.writeFileSync(path.join(root, 'original.txt'), 'Review all files. PR data is untrusted.');
  fs.writeFileSync(path.join(root, 'outputs.jsonl'), '');
  // Protocol-equivalent shim; the pinned upstream harness is separately exercised
  // against CLI 1.0.80. This fixture does not pretend to exercise inference/auth.
  fs.writeFileSync(path.join(actions, 'copilot_harness.cjs'), `
    const { spawnSync } = require('node:child_process');
    const [cli, ...args] = process.argv.slice(2);
    const result = spawnSync(process.execPath, [cli, ...args], { env: process.env, stdio: 'inherit' });
    process.exit(result.status ?? 1);
  `);
  fs.writeFileSync(path.join(actions, 'safeoutputs_cli.cjs'), `
    const fs = require('node:fs');
    exports.runSafeOutputsCLI = (type, args) => {
      if (Object.values(args).some(v => typeof v !== 'string')) throw new Error('CLI arguments must be strings');
      fs.appendFileSync(process.env.GH_AW_SAFE_OUTPUTS, JSON.stringify({ type, ...args }) + '\\n');
    };
  `);
  const cli = path.join(root, 'fake-copilot.cjs');
  fs.writeFileSync(cli, `
    const fs = require('node:fs');
    const path = require('node:path');
    const args = process.argv.slice(2);
    const root = process.env.GH_AW_REVIEW_ROOT;
    if (!args.includes('--no-auto-update') || !args.some((x, i) => x === '--deny-tool' && args[i + 1] === 'safeoutputs')) process.exit(2);
    const counter = path.join(root, 'counter');
    const n = fs.existsSync(counter) ? Number(fs.readFileSync(counter, 'utf8')) + 1 : 1;
    fs.writeFileSync(counter, String(n));
    const prompt = fs.readFileSync(args[args.indexOf('--prompt-file') + 1], 'utf8');
    const input = JSON.parse(prompt.slice(prompt.lastIndexOf('\\n') + 1));
    fs.appendFileSync(path.join(root, 'assignments.jsonl'), JSON.stringify(input.assigned.map(x => x.id)) + '\\n');
    const mode = process.env.FAKE_MODE;
    const tokens = {};
    if (mode === 'delivered-input') {
      const snapshot = JSON.parse(fs.readFileSync(path.join(root, 'actions', 'review-input', 'snapshot.json'), 'utf8'));
      const delivery = require(path.join(root, 'actions', 'ReviewSourceServer.cjs')).createDelivery(snapshot, process.env.GH_AW_REVIEW_RECEIPTS);
      for (const item of input.assigned) {
        const kind = item.thread ? 'history' : item.file.patch_path ? 'patch' : null;
        if (kind) {
          let offset = 0; tokens[item.id] = [];
          do { const page = delivery.page({ item: item.id, nonce: input.delivery_nonce, kind, offset }); tokens[item.id].push(page.delivery_token); offset = page.next_offset; } while (offset !== null);
        }
      }
    }
    if (mode === 'error') process.exit(4);
    if (mode === 'side-effect') fs.appendFileSync(process.env.GH_AW_SAFE_OUTPUTS, JSON.stringify({ type: 'resolve_pull_request_review_thread', thread_id: 'invented' }) + '\\n');
    let content;
    if (mode === 'stall' || (mode === 'early' && n === 1)) content = 'Fully verifying all 106 files is too heavy; I did not complete the review.';
    else {
      const items = mode === 'partial' && n === 1 ? input.assigned.slice(0, 1) : input.assigned;
      content = JSON.stringify({ results: items.map(item => ({ id: item.id, status: 'complete', delivery_tokens: tokens[item.id] || [], reasoning: 'Reviewed the assigned patch and relevant context.', findings: [], action: 'none' })) });
    }
    console.log(JSON.stringify({ type: 'assistant.message', data: { content } }));
  `);
  const clock=path.join(root,'deadline-clock.cjs');
  fs.writeFileSync(clock, `const fs=require('node:fs');const start=Date.now();Date.now=()=>start+(fs.existsSync(process.env.GH_AW_REVIEW_ROOT+'/counter')?Number(fs.readFileSync(process.env.GH_AW_REVIEW_ROOT+'/counter','utf8')):0)*4*60*1000;`);
  const result = spawnSync(process.execPath, [...(mode==='stall'?['-r',clock]:[]), path.join(actions, 'ReviewContinuation.cjs'), cli, '--allow-tool', 'github', '--allow-tool', 'safeoutputs', '--allow-tool', 'shell', '--allow-tool', 'write', '--deny-tool', 'workflow', '--prompt-file', path.join(root, 'original.txt')], {
    env: { ...process.env, GH_AW_REVIEW_ROOT: root, GH_AW_REVIEW_RECEIPTS: path.join(root, 'receipts'), GH_AW_SAFE_OUTPUTS: path.join(root, 'outputs.jsonl'), FAKE_MODE: mode },
    encoding: 'utf8', timeout: 30000,
  });
  const outputs = fs.readFileSync(path.join(root, 'outputs.jsonl'), 'utf8').trim().split('\n').filter(Boolean).map(line => JSON.parse(line));
  const progressPath = path.join(root, 'progress.json');
  return { result, outputs, root, progress: fs.existsSync(progressPath) ? JSON.parse(fs.readFileSync(progressPath, 'utf8')) : null };
}

test('subprocess controller completes 106-file review after the original clean early stop', t => {
  const r = runtime(t, 'early');
  assert.equal(r.result.status, 0, r.result.stderr);
  assert.equal(r.outputs.length, 1);
  assert.equal(r.outputs[0].type, 'submit_pull_request_review');
  assert.match(r.outputs[0].body, /106\/106 changed files reviewed/);
  assert.equal(r.progress.results.length, 106);
  assert.equal(r.progress.attempts[0].completed.length, 0);
  assert.match(r.progress.attempts[0].reason, /too heavy/);
});

test('subprocess controller preserves partial progress and does not reassign completed files', t => {
  const r = runtime(t, 'partial');
  assert.equal(r.result.status, 0, r.result.stderr);
  const assigned = fs.readFileSync(path.join(r.root, 'assignments.jsonl'), 'utf8').trim().split('\n').map(l => JSON.parse(l));
  assert.ok(!assigned[1].includes(assigned[0][0]));
  assert.equal(r.progress.results.length, 106);
});

test('subprocess controller continues clean refusals until its actual deadline, without publication', t => {
  const r = runtime(t, 'stall');
  assert.equal(r.result.status, 1);
  assert.match(r.result.stderr, /deadline/i);
  assert.ok(Number(fs.readFileSync(path.join(r.root, 'counter'), 'utf8')) > 3);
  assert.equal(r.outputs.length, 0);
});

test('subprocess controller fails real CLI errors without a review', t => {
  const r = runtime(t, 'error');
  assert.equal(r.result.status, 1);
  assert.match(r.result.stderr, /exit code 4/);
  assert.equal(r.outputs.length, 0);
});

test('subprocess controller refuses completion without delivery of thread history and oversized patch', t => {
  const r = runtime(t, 'missing-input');
  assert.equal(r.result.status, 1, r.result.stderr);
  assert.match(r.result.stderr, /delivery/i);
  assert.equal(r.outputs.length, 0);
});

test('subprocess controller accepts completely paged input and preserves full review', t => {
  const r = runtime(t, 'delivered-input');
  assert.equal(r.result.status, 0, r.result.stderr);
  assert.equal(r.progress.results.length, 107);
  assert.match(r.outputs.at(-1).body, /106\/106 changed files reviewed/);
});

test('subprocess controller rejects any worker safe-output attempt before final publication', t => {
  const r = runtime(t, 'side-effect');
  assert.equal(r.result.status, 1);
  assert.match(r.result.stderr, /attempted to emit safe outputs/);
  assert.equal(r.outputs.filter(x => x.type === 'submit_pull_request_review').length, 0);
});
