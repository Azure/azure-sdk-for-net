'use strict';
const { test } = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const os = require('node:os');
const path = require('node:path');
const { handle, createDelivery } = require('../pr-re-review/ReviewInputServer.cjs');
const { verifyDelivery } = require('../pr-re-review/ReviewDelivery.cjs');

test('private input transport exposes only history and patch delivery', async () => {
  const init = await handle({ jsonrpc: '2.0', id: 1, method: 'initialize' });
  assert.equal(init.protocolVersion, '2024-11-05');
  const listed = await handle({ jsonrpc: '2.0', id: 2, method: 'tools/list' });
  assert.deepEqual(listed.tools.map(tool => tool.name), ['read-review-input']);
  await assert.rejects(handle({ jsonrpc: '2.0', id: 3, method: 'tools/call', params: { name: 'read-review-source', arguments: { path: 'sdk/F.cs' } } }), /Unsupported/);
  await assert.rejects(handle({ jsonrpc: '2.0', id: 4, method: 'tools/call', params: { name: 'execute', arguments: {} } }), /Unsupported/);
  await assert.rejects(handle({ jsonrpc: '2.0', id: 5, method: 'tools/call', params: { name: 'read-review-input', arguments: { token: 'injected' } } }), /Unsupported/);
});

test('trusted reader records only delivered history and patch pages for the exact invocation', async t => {
  const dir = fs.mkdtempSync(path.join(os.tmpdir(), 'review-receipts-'));
  t.after(() => fs.rmSync(dir, { recursive: true, force: true }));
  const snapshot = {
    head_sha: 'a'.repeat(40), base_sha: 'b'.repeat(40),
    files: [{ filename: 'new.cs', status: 'modified', patch: 'x'.repeat(50000) }],
    threads: [{ id: 't', comments: [{ body: 'history' }] }],
  };
  const delivery = createDelivery(snapshot, dir), nonce = 'a'.repeat(32);
  const call = args => handle({ jsonrpc: '2.0', id: 1, method: 'tools/call', params: { name: 'read-review-input', arguments: args } }, delivery);
  const items = [{ id: 'thread:0', thread: snapshot.threads[0] }, { id: 'file:0', file: snapshot.files[0] }];
  const first = JSON.parse((await call({ item: 'thread:0', nonce, kind: 'history', limit: 5 })).content[0].text);
  await assert.rejects(call({ item: 'thread:0', nonce, kind: 'patch' }), /not required/);
  await assert.rejects(call({ item: 'file:9', nonce, kind: 'patch' }), /Unknown/);
  await assert.rejects(call({ item: 'thread:0', nonce: 'invalid', kind: 'history' }), /nonce/i);
  const second = JSON.parse((await call({ item: 'thread:0', nonce, kind: 'history', offset: first.next_offset })).content[0].text);
  const results = [
    { id: 'thread:0', status: 'complete', delivery_tokens: [first.delivery_token, second.delivery_token] },
    { id: 'file:0', status: 'complete', delivery_tokens: [] },
  ];
  let rows = fs.readFileSync(path.join(dir, nonce + '.jsonl'), 'utf8').trim().split('\n').map(JSON.parse);
  assert.ok(!JSON.stringify(rows).includes(first.delivery_token), 'Receipts must not disclose acknowledgements.');
  await assert.rejects(async () => verifyDelivery(snapshot, items, results, nonce, rows), /delivery/i);
  let offset = 0;
  do {
    const page = JSON.parse((await call({ item: 'file:0', nonce, kind: 'patch', offset })).content[0].text);
    results[1].delivery_tokens.push(page.delivery_token);
    offset = page.next_offset;
  } while (offset !== null);
  rows = fs.readFileSync(path.join(dir, nonce + '.jsonl'), 'utf8').trim().split('\n').map(JSON.parse);
  await assert.rejects(async () => verifyDelivery(snapshot, items, results, 'b'.repeat(32), rows), /delivery/i);
  await assert.doesNotReject(async () => verifyDelivery(snapshot, items, results, nonce, rows));
});

test('a generated page cannot count when its response was dropped', async t => {
  const dir = fs.mkdtempSync(path.join(os.tmpdir(), 'review-dropped-'));
  t.after(() => fs.rmSync(dir, { recursive: true, force: true }));
  const snapshot = { head_sha: 'a'.repeat(40), base_sha: 'b'.repeat(40), files: [], threads: [{ id: 't', comments: [{ body: 'history' }] }] };
  const nonce = 'a'.repeat(32), item = { id: 'thread:0', thread: snapshot.threads[0] };
  createDelivery(snapshot, dir).page({ item: item.id, nonce, kind: 'history' }); // The response is dropped before reaching the worker.
  const rows = fs.readFileSync(path.join(dir, nonce + '.jsonl'), 'utf8').trim().split('\n').map(JSON.parse);
  await assert.rejects(async () => verifyDelivery(snapshot, [item], [{ id: item.id, status: 'complete' }], nonce, rows), /delivery/i);
});

function assertNoAgentCredential(execution) {
  const invocation = execution.split('\n').find(line => line.includes('awf --config')) || '';
  for (const name of ['REVIEW_TOKEN', 'GITHUB_TOKEN', 'GITHUB_MCP_SERVER_TOKEN']) {
    assert.ok(!new RegExp(`^ +${name}:`, 'm').test(execution) || invocation.includes(`--exclude-env ${name}`), `${name} must not enter the agent sandbox`);
  }
}

test('compiled input backend is private and GitHub credentials stay outside the agent', () => {
  const lock = fs.readFileSync(path.join(__dirname, '..', 'pr-re-review.lock.yml'), 'utf8');
  const stanza = lock.match(/"reviewinput": \{([\s\S]*?)"guard-policies"/)[1];
  assert.match(stanza, /"type": "stdio"/);
  assert.ok(!stanza.includes('"url"') && !stanza.includes('"-p"'));
  assert.ok(stanza.includes('${RUNNER_TEMP}/gh-aw/safeoutputs/review-receipts:/receipts:rw'));
  assert.ok(!stanza.includes('REVIEW_TOKEN') && !stanza.includes('GITHUB_TOKEN'));
  assert.ok(lock.includes('--mount "${RUNNER_TEMP}/gh-aw:${RUNNER_TEMP}/gh-aw:ro"'));
  assert.ok(!lock.includes('name: Start MCP Scripts Server'));
  const agent = lock.split('\n  agent:\n')[1].split('\n  check_safe_output_status:')[0];
  const execution = agent.split('name: Execute GitHub Copilot CLI')[1].split(/\n      - /)[0];
  assertNoAgentCredential(execution);
  assert.ok(agent.includes('"GITHUB_PERSONAL_ACCESS_TOKEN": "${GITHUB_MCP_SERVER_TOKEN}"'));
  // Preserve the original credential-leak regression after removing the source token.
  assert.throws(() => assertNoAgentCredential('awf --config config --env-all\n          REVIEW_TOKEN: secret'), /sandbox/);
});
