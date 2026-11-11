'use strict';
const assert = require('node:assert/strict');
const { test } = require('node:test');
const crypto = require('node:crypto');
const { requiredInputs, verifyDelivery, snapshotDigest } = require('../pr-re-review/ReviewDelivery.cjs');

const snapshot = () => ({ head_sha: 'a'.repeat(40), base_sha: 'b'.repeat(40), files: [], threads: [] });
const nonce = '1'.repeat(32);
const receipt = (s, item, req, start, end, total, extra = {}) => {
  const token = crypto.createHash('sha256').update(`${item.id}:${req.key}:${start}:${end}`).digest('hex');
  return { snapshot: snapshotDigest(s), nonce, item: item.id, key: req.key, start, end, total, proof_hash: crypto.createHash('sha256').update(token).digest('hex'), token, ...extra };
};

test('requires complete paged thread and oversized patch delivery for this invocation', async () => {
  const s = snapshot();
  const thread = { id: 'thread:0', thread: { id: 't', comments: [{ body: 'history' }] } };
  const file = { id: 'file:0', file: { filename: 'a.cs', status: 'modified', patch: 'x'.repeat(50000) } };
  const items = [thread, file];
  const req = items.map(item => requiredInputs(s, item)[0]);
  const receipts = req.map((r, i) => receipt(s, items[i], r, 0, r.content.length, r.content.length));
  const results = items.map((item, i) => ({ id: item.id, status: 'complete', delivery_tokens: [receipts[i].token] }));
  await assert.rejects(async () => verifyDelivery(s, items, results, nonce, []), /delivery/i);
  await assert.rejects(async () => verifyDelivery(s, items, results, nonce, receipts.slice(0, 1)), /delivery/i);
  await assert.rejects(async () => verifyDelivery(s, items, results, '2'.repeat(32), receipts), /delivery/i);
  await assert.rejects(async () => verifyDelivery({ ...s, base_sha: 'c'.repeat(40) }, items, results, nonce, receipts), /delivery/i);
  await assert.rejects(async () => verifyDelivery(s, items, results, nonce, receipts.map(row => ({ ...row, item: 'file:999' }))), /delivery/i);
  await assert.doesNotReject(async () => verifyDelivery(s, items, results, nonce, receipts));
  const broken = [receipt(s, thread, req[0], 0, 2, req[0].content.length), receipt(s, thread, req[0], 3, req[0].content.length, req[0].content.length), receipts[1]];
  const brokenResults = [{ ...results[0], delivery_tokens: broken.slice(0, 2).map(row => row.token) }, results[1]];
  await assert.rejects(async () => verifyDelivery(s, items, brokenResults, nonce, broken), /delivery/i);
});

test('even an empty thread history needs an explicit successful page', async () => {
  const s = snapshot();
  const item = { id: 'thread:0', thread: { id: 'empty', comments: [] } };
  const req = requiredInputs(s, item)[0];
  const record = receipt(s, item, req, 0, req.content.length, req.content.length);
  const results = [{ id: item.id, status: 'complete', delivery_tokens: [record.token] }];
  await assert.rejects(async () => verifyDelivery(s, [item], results, nonce, []), /delivery/i);
  await assert.doesNotReject(async () => verifyDelivery(s, [item], results, nonce, [record]));
});

test('rejects forged, malformed, or incomplete delivery evidence', async () => {
  const s = snapshot();
  const item = { id: 'thread:0', thread: { id: 't', comments: [{ body: '𝄞 history' }] } };
  const req = requiredInputs(s, item)[0];
  const first = receipt(s, item, req, 0, 5, req.content.length);
  const last = receipt(s, item, req, 5, req.content.length, req.content.length);
  const result = [{ id: item.id, status: 'complete', delivery_tokens: [first.token, last.token] }];
  await assert.doesNotReject(async () => verifyDelivery(s, [item], result, nonce, [last, first]));
  for (const bad of [
    { ...last, proof_hash: '0'.repeat(64) },
    { ...last, total: last.total + 1 },
    { ...last, total: String(last.total) },
    { ...last, start: 6 },
    { ...last, start: -1 },
    { ...last, end: 0.5 },
  ]) await assert.rejects(async () => verifyDelivery(s, [item], result, nonce, [first, bad]), /delivery/i);
  await assert.rejects(async () => verifyDelivery(s, [item], [{ ...result[0], delivery_tokens: ['A'.repeat(64)] }], nonce, [first, last]), /delivery/i);
  await assert.rejects(async () => verifyDelivery(s, [item], result, 'A'.repeat(32), [first, last]), /delivery/i);
  await assert.rejects(async () => verifyDelivery(s, [item], result, '0'.repeat(32), [{ ...first, nonce: 0 }, { ...last, nonce: 0 }]), /delivery/i);
});

test('receipt identities compare ordinally, not by Unicode normalization', async () => {
  const s = snapshot();
  const item = { id: 'thread:é', thread: { id: 't', comments: [{ body: 'history' }] } };
  const req = requiredInputs(s, item)[0];
  const row = receipt(s, item, req, 0, req.content.length, req.content.length);
  const result = [{ id: item.id, status: 'complete', delivery_tokens: [row.token] }];
  await assert.doesNotReject(async () => verifyDelivery(s, [item], result, nonce, [row]));
  await assert.rejects(async () => verifyDelivery(s, [item], result, nonce, [{ ...row, item: row.item.replace('é', 'e\u0301') }]), /delivery/i);
});

test('rejects an expired or invalid delivery deadline', async () => {
  const s = snapshot();
  await assert.rejects(verifyDelivery(s, [], [], nonce, [], { deadline: Date.now() - 1 }), /deadline/i);
  await assert.rejects(verifyDelivery(s, [], [], nonce, [], { deadline: NaN }), /deadline/i);
});

test('unrequired delivery tokens preserve the original permissive string behavior', async () => {
  const s = snapshot();
  const item = { id: 'file:0', file: { filename: 'small.cs', status: 'modified', patch: 'diff' } };
  await assert.doesNotReject(async () => verifyDelivery(s, [item], [{ id: item.id, status: 'complete', delivery_tokens: ['not a receipt'] }], nonce, []));
});

test('source reads are model-attested; oversized patches still require delivery', () => {
  const s = snapshot();
  const file = (status, patch, previous_filename) => ({ id: 'file:0', file: { filename: 'new.cs', status, ...(patch === undefined ? {} : { patch }), ...(previous_filename ? { previous_filename } : {}) } });
  for (const item of [file('modified', 'diff'), file('added'), file('modified'), file('removed', 'diff'), file('renamed', 'diff', 'old.cs')]) {
    assert.deepEqual(requiredInputs(s, item), []);
  }
  for (const item of [file('added', 'x'.repeat(50000)), file('removed', 'x'.repeat(50000)), file('renamed', 'x'.repeat(50000), 'old.cs')]) {
    assert.deepEqual(requiredInputs(s, item).map(x => x.kind), ['patch']);
  }
  assert.throws(() => requiredInputs(s, file('renamed', 'diff')), /source path/i);
  assert.throws(() => requiredInputs(s, file('unknown')), /unsupported/i);
});
