'use strict';
const assert = require('node:assert/strict');
const { test } = require('node:test');
const crypto = require('node:crypto');
const { requiredInputs, verifyDelivery, snapshotDigest } = require('./ReviewDelivery.cjs');

const snapshot = () => ({ head_sha: 'a'.repeat(40), base_sha: 'b'.repeat(40), files: [], threads: [] });
const nonce = '1'.repeat(32);
const receipt = (s, item, req, start, end, total, extra = {}) => {
  const token = crypto.createHash('sha256').update(`${item.id}:${req.key}:${start}:${end}`).digest('hex');
  return { snapshot: snapshotDigest(s), nonce, item: item.id, key: req.key, start, end, total, proof_hash: crypto.createHash('sha256').update(token).digest('hex'), token, ...extra };
};

test('requires complete paged thread and oversized patch delivery for this invocation', () => {
  const s = snapshot();
  const thread = { id: 'thread:0', thread: { id: 't', comments: [{ body: 'history' }] } };
  const file = { id: 'file:0', file: { filename: 'a.cs', status: 'modified', patch: 'x'.repeat(50000) } };
  const items = [thread, file];
  const req = items.map(item => requiredInputs(s, item)[0]);
  const receipts = req.map((r, i) => receipt(s, items[i], r, 0, r.content.length, r.content.length));
  const results = items.map((item, i) => ({ id: item.id, status: 'complete', delivery_tokens: [receipts[i].token] }));
  assert.throws(() => verifyDelivery(s, items, results, nonce, []), /delivery/i);
  assert.throws(() => verifyDelivery(s, items, results, nonce, receipts.slice(0, 1)), /delivery/i);
  assert.throws(() => verifyDelivery(s, items, results, '2'.repeat(32), receipts), /delivery/i);
  assert.throws(() => verifyDelivery({ ...s, base_sha: 'c'.repeat(40) }, items, results, nonce, receipts), /delivery/i);
  assert.throws(() => verifyDelivery(s, items, results, nonce, receipts.map(row => ({ ...row, item: 'file:999' }))), /delivery/i);
  assert.doesNotThrow(() => verifyDelivery(s, items, results, nonce, receipts));
  const broken = [receipt(s, thread, req[0], 0, 2, req[0].content.length), receipt(s, thread, req[0], 3, req[0].content.length, req[0].content.length), receipts[1]];
  const brokenResults = [{ ...results[0], delivery_tokens: broken.slice(0, 2).map(row => row.token) }, results[1]];
  assert.throws(() => verifyDelivery(s, items, brokenResults, nonce, broken), /delivery/i);
});

test('empty source still needs an explicit successful page', () => {
  const s = snapshot();
  const item = { id: 'file:0', file: { filename: 'empty.cs', status: 'added' } };
  const req = requiredInputs(s, item)[0];
  const record = receipt(s, item, req, 0, 0, 0);
  const results = [{ id: item.id, status: 'complete', delivery_tokens: [record.token] }];
  assert.throws(() => verifyDelivery(s, [item], results, nonce, []), /delivery/i);
  assert.doesNotThrow(() => verifyDelivery(s, [item], results, nonce, [record]));
});

test('embedded patches need no receipt; omitted, removed and renamed files require correct source sides', () => {
  const s = snapshot();
  const file = (status, patch, previous_filename) => ({ id: 'file:0', file: { filename: 'new.cs', status, ...(patch === undefined ? {} : { patch }), ...(previous_filename ? { previous_filename } : {}) } });
  assert.deepEqual(requiredInputs(s, file('modified', 'diff')), []);
  assert.deepEqual(requiredInputs(s, file('added', undefined)).map(x => x.key), [`source:${s.head_sha}:new.cs`]);
  assert.deepEqual(requiredInputs(s, file('removed', 'diff')).map(x => x.key), [`source:${s.base_sha}:new.cs`]);
  assert.deepEqual(requiredInputs(s, file('renamed', 'diff', 'old.cs')).map(x => x.key), [`source:${s.base_sha}:old.cs`, `source:${s.head_sha}:new.cs`]);
  assert.deepEqual(requiredInputs(s, file('modified', undefined)).map(x => x.key), [`source:${s.base_sha}:new.cs`, `source:${s.head_sha}:new.cs`]);
});
