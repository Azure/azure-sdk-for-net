'use strict';
const { test } = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const os = require('node:os');
const path = require('node:path');
const { createDelivery } = require('./TestInputServer.cjs');
const { verifyDelivery } = require('../pr-re-review/ReviewDelivery.cjs');

test('rejects JSON-RPC coercion, unknown-key collisions and invalid page types', async t => {
  const dir = fs.mkdtempSync(path.join(os.tmpdir(), 'input-protocol-'));
  t.after(() => fs.rmSync(dir, { recursive: true, force: true }));
  const snapshot = { files: [], threads: [{ id: 't', comments: [{ path: 'a.cs', body: 'history' }] }] };
  const delivery = await createDelivery(t, snapshot, dir);
  const nonce = 'a'.repeat(32), args = { item: 'thread:0', kind: 'history', nonce };
  await assert.rejects(delivery.handle({ jsonrpc: true, method: 'ping' }), /Invalid JSON-RPC/);
  await assert.rejects(delivery.handle({ jsonrpc: '2.0', method: 'tools/call', params: { name: [], arguments: args } }), /Unsupported/);
  const call = arguments_ => delivery.handle({ jsonrpc: '2.0', method: 'tools/call', params: { name: 'read-review-input', arguments: arguments_ } });
  await assert.rejects(call({ ...args, Keys: 'item' }), /Unsupported/);
  await assert.rejects(call({ ...args, nonce: nonce + '\n' }), /nonce/i);
  for (const bad of [[1], [], true, false, '1', null, {}, 1.5, 9007199254740992]) {
    await assert.rejects(call({ ...args, offset: bad }), /Invalid input page/);
    await assert.rejects(call({ ...args, limit: bad }), /Invalid input page/);
  }
  await assert.rejects(call({ ...args, item: 'thread:0\n' }), /Invalid delivery assignment/);
  const page = JSON.parse((await call(args)).content[0].text);
  assert.equal(page.content, JSON.stringify(snapshot.threads[0], null, 2));
  const floatRequest = `{"jsonrpc":"2.0","id":901,"method":"tools/call","params":{"name":"read-review-input","arguments":{"item":"thread:0","kind":"history","nonce":"${nonce}","offset":1.0,"limit":2.0}}}`;
  const text = (await delivery.raw(floatRequest, 901)).content[0].text;
  assert.match(text, /"offset":1,/);
  assert.equal(text, JSON.stringify(JSON.parse(text)));
});

test('stdio handles notifications and malformed requests without hanging', async t => {
  const dir = fs.mkdtempSync(path.join(os.tmpdir(), 'input-stdio-'));
  t.after(() => fs.rmSync(dir, { recursive: true, force: true }));
  const delivery = await createDelivery(t, { files: [], threads: [] }, dir);
  assert.deepEqual(await delivery.handle({ jsonrpc: '2.0', method: 'ping' }), {});
  delivery.notify({ jsonrpc: '2.0', method: 'notifications/initialized' });
  assert.deepEqual(await delivery.handle({ jsonrpc: '2.0', method: 'ping' }), {});
  assert.deepEqual(delivery.unexpected, []);
  assert.deepEqual(await delivery.raw('{"jsonrpc":"2.0","id":null,"method":"ping"}', null), {});
  await assert.rejects(delivery.raw('{', null), /JSON|parse|invalid/i);
  await assert.rejects(delivery.raw('x'.repeat(65537), null), /bounded input limit/);
  await assert.rejects(delivery.raw('null', null, 2000), /Invalid JSON-RPC/);
});

test('tampered oversized patches and index keys cannot produce accepted receipts', async t => {
  const snapshot = { files: [{ filename: 'large.cs', status: 'modified', patch: 'x'.repeat(50000) }], threads: [] };
  const nonce = 'b'.repeat(32);
  for (const changed of ['patch', 'key']) {
    const dir = fs.mkdtempSync(path.join(os.tmpdir(), `input-${changed}-`));
    t.after(() => fs.rmSync(dir, { recursive: true, force: true }));
    const delivery = await createDelivery(t, snapshot, dir, { beforeStart: context => {
      const name = path.join(context, changed === 'patch' ? 'snapshot.json' : 'delivery-index.json');
      const data = JSON.parse(fs.readFileSync(name, 'utf8'));
      if (changed === 'patch') data.files[0].patch = 'y'.repeat(50000);
      else data.items['file:0'][0].key = 'patch:' + '0'.repeat(64);
      fs.writeFileSync(name, JSON.stringify(data));
    } });
    await assert.rejects(delivery.page({ item: 'file:0', kind: 'patch', nonce }), /does not match/);
    assert.ok(!fs.existsSync(path.join(dir, nonce + '.jsonl')));
  }
});

test('a tampered index snapshot cannot authenticate receipts', async t => {
  const dir = fs.mkdtempSync(path.join(os.tmpdir(), 'input-index-snapshot-'));
  t.after(() => fs.rmSync(dir, { recursive: true, force: true }));
  const snapshot = { files: [], threads: [{ id: 't', comments: [{ path: 'a.cs', body: 'history' }] }] };
  const nonce = 'c'.repeat(32), item = { id: 'thread:0', thread: snapshot.threads[0] };
  const delivery = await createDelivery(t, snapshot, dir, { beforeStart: context => {
    const name = path.join(context, 'delivery-index.json');
    const index = JSON.parse(fs.readFileSync(name, 'utf8'));
    index.snapshot = '0'.repeat(64);
    fs.writeFileSync(name, JSON.stringify(index));
  } });
  const page = await delivery.page({ item: item.id, kind: 'history', nonce });
  const rows = fs.readFileSync(path.join(dir, nonce + '.jsonl'), 'utf8').trim().split('\n').map(JSON.parse);
  await assert.rejects(verifyDelivery(snapshot, [item], [{ id: item.id, status: 'complete', delivery_tokens: [page.delivery_token] }], nonce, rows), /delivery/i);
});

test('rejects a tampered captured thread before issuing a receipt', async t => {
  const dir = fs.mkdtempSync(path.join(os.tmpdir(), 'input-tamper-'));
  t.after(() => fs.rmSync(dir, { recursive: true, force: true }));
  const snapshot = { files: [], threads: [{ id: 't', comments: [{ path: 'a.cs', body: 'history' }] }] };
  const delivery = await createDelivery(t, snapshot, dir);
  fs.writeFileSync(path.join(dir, 'input', 'thread-0.json'), '{"body":"tampered"}');
  await assert.rejects(delivery.page({ item: 'thread:0', kind: 'history', nonce: 'a'.repeat(32) }), /does not match/);
  assert.ok(!fs.existsSync(path.join(dir, 'a'.repeat(32) + '.jsonl')));
});
