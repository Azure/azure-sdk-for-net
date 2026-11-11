'use strict';
const assert = require('node:assert/strict');
const { spawnSync } = require('node:child_process');
const { test } = require('node:test');
const path = require('node:path');
const script = path.join(__dirname, '..', 'pr-re-review', 'ReviewFreshness.ps1');

// Original JavaScript behavior retained as an independent test oracle.
function oracle(mode, expected, current, roots, receipts) {
  if (mode === 'publication') {
    if (JSON.stringify(current.threads) !== JSON.stringify(expected.threads)) throw Error('thread');
    if (JSON.stringify(current.reviews) !== JSON.stringify(expected.reviews)) throw Error('reviews');
    if (current.head_repo !== expected.head_repo || current.base_repo !== expected.base_repo) throw Error('repo');
    return;
  }
  const byId = new Map(current.threads.map(thread => [thread.id, thread]));
  for (const root of roots) {
    const before = expected.threads.find(thread => thread.comments[0].databaseId === root);
    const after = before && byId.get(before.id);
    const ownIds = new Set(receipts.filter(item => item.type === 'reply_to_pull_request_review_comment' && item.provider === 'github' && item.id === root && Number.isSafeInteger(item.metadata?.reply_id) && item.metadata.reply_id > 0).map(item => item.metadata.reply_id));
    if (!ownIds.size) throw Error('identity');
    if (!after) throw Error('available');
    if (!after.comments.some(comment => ownIds.has(comment.databaseId))) throw Error('visible');
    const withoutOwn = { ...after, comments: after.comments.filter(comment => !ownIds.has(comment.databaseId)) };
    if (JSON.stringify(withoutOwn) !== JSON.stringify(before)) throw Error('changed');
  }
}
function category(stderr) {
  if (/thread state or history changed/i.test(stderr)) return 'thread';
  if (/Review history changed/i.test(stderr)) return 'reviews';
  if (/Source repository identity/i.test(stderr)) return 'repo';
  if (/Missing applied reply identity/i.test(stderr)) return 'identity';
  if (/no longer available/i.test(stderr)) return 'available';
  if (/no longer visible/i.test(stderr)) return 'visible';
  if (/changed after publication/i.test(stderr)) return 'changed';
  return 'invalid';
}
const original = { id: 'thréad😀', isResolved: false, isOutdated: null, comments: [{ databaseId: 1, body: 'base\u0000😀\ud800', path: 'f.cs', updatedAt: '2026-01-01T00:00:00Z' }] };
const reply = { databaseId: 2, body: 'reply', path: 'f.cs' };
const expected = { threads: [original], reviews: [{ id: 7, body: 'prev', state: 'COMMENTED' }], head_repo: 'A/B', base_repo: 'A/B' };
const receipt = { type: 'reply_to_pull_request_review_comment', provider: 'github', id: 1, metadata: { reply_id: 2 } };
const clone = value => structuredClone(value);
const cases = [];
function publication(name, edit) {
  const current = clone(expected); if (edit) edit(current);
  cases.push({ name, mode: 'publication', expected, current });
}
function mutation(name, edit, receipts = [receipt], rootIds = [1]) {
  const current = clone(expected); current.threads[0].comments.push(clone(reply)); if (edit) edit(current);
  cases.push({ name, mode: 'mutation', expected, current, rootIds, receipts });
}
publication('unchanged');
publication('resolved flag changed', c => { c.threads[0].isResolved = true; });
publication('comment timestamp changed', c => { c.threads[0].comments[0].updatedAt = '2026-01-02T00:00:00Z'; });
publication('review changed', c => { c.reviews[0].body = 'edited'; });
publication('head repo NUL', c => { c.head_repo = 'A/B\0'; });
publication('comment property order changed', c => { const x = c.threads[0].comments[0]; c.threads[0].comments[0] = { path: x.path, databaseId: x.databaseId, body: x.body, updatedAt: x.updatedAt }; });
publication('lone surrogate changed', c => { c.threads[0].comments[0].body = 'base\u0000😀\ud801'; });
publication('base repo ignorable character', c => { c.base_repo = 'A/B\u00ad'; });
mutation('applied reply');
mutation('duplicate receipt', null, [receipt, receipt]);
mutation('external reply', c => { c.threads[0].comments.push({ databaseId: 3, body: 'external' }); });
mutation('original comment changed', c => { c.threads[0].comments[0].body = 'changed'; });
mutation('applied reply metadata changed', c => { c.threads[0].comments[1].body = 'ignored edit'; });
mutation('thread removed', c => { c.threads = []; });
mutation('applied reply removed', c => { c.threads[0].comments.pop(); });
mutation('no receipt', null, []);
mutation('provider casing', null, [{ ...receipt, provider: 'GitHub' }]);
mutation('root string', null, [{ ...receipt, id: '1' }]);
mutation('reply string', null, [{ ...receipt, metadata: { reply_id: '2' } }]);
mutation('reply zero', null, [{ ...receipt, metadata: { reply_id: 0 } }]);
mutation('reply fraction', null, [{ ...receipt, metadata: { reply_id: 2.5 } }]);
mutation('unsafe reply id', null, [{ ...receipt, metadata: { reply_id: 9007199254740992 } }]);
mutation('safe boundary reply id not visible', null, [{ ...receipt, metadata: { reply_id: 9007199254740991 } }]);
mutation('null receipt metadata', null, [{ ...receipt, metadata: null }]);
mutation('only one of two applied replies visible', null, [receipt, { ...receipt, metadata: { reply_id: 99 } }]);
mutation('duplicate requested root', null, [receipt], [1, 1]);
mutation('unrelated thread changed', c => { c.threads.push({ id: 'other', isResolved: false, comments: [{ databaseId: 100, body: 'unrelated' }] }); });
mutation('empty roots', null, [], []);
mutation('missing root without matching receipt', null, [receipt], [99]);
mutation('missing root with matching receipt', null, [{ ...receipt, id: 99 }], [99]);

// These cases require or challenge the ordered-comparison fallback.
{
  const before = clone(expected); before.threads[0].comments.push({ databaseId: 2, body: 'pre-existing' });
  const current = clone(before); current.threads[0].comments.push(clone(reply));
  cases.push({ name: 'applied ID already existed', mode: 'mutation', expected: before, current, rootIds: [1], receipts: [receipt] });
}
{
  const before = clone(expected); before.threads[0].comments.push({ databaseId: 4, body: 'later original' });
  const current = clone(before); current.threads[0].comments.splice(1, 0, clone(reply));
  cases.push({ name: 'interleaved reply', mode: 'mutation', expected: before, current, rootIds: [1], receipts: [receipt] });
}
{
  const before = clone(expected), thread = before.threads[0];
  before.threads[0] = { id: thread.id, comments: thread.comments, isResolved: thread.isResolved, isOutdated: thread.isOutdated };
  const current = clone(before); current.threads[0].comments.push(clone(reply));
  cases.push({ name: 'comments property not last', mode: 'mutation', expected: before, current, rootIds: [1], receipts: [receipt] });
}
{
  const before = clone(expected); before.threads[0].comments[0].body = 'quoted "databaseId":2, text';
  const current = clone(before); current.threads[0].comments.push(clone(reply));
  cases.push({ name: 'escaped ID text in body', mode: 'mutation', expected: before, current, rootIds: [1], receipts: [receipt] });
}
mutation('external string reply ID', c => { c.threads[0].comments.push({ databaseId: '2', body: 'external' }); });
{
  const before = clone(expected); before.threads[0].comments.push({ databaseId: 2, body: 'pre-existing' });
  const current = clone(before); current.threads[0].comments.push({ databaseId: 3, body: 'new' });
  cases.push({ name: 'old and new applied IDs', mode: 'mutation', expected: before, current, rootIds: [1], receipts: [receipt, { ...receipt, metadata: { reply_id: 3 } }] });
}
{
  const before = clone(expected); before.threads[0].comments.push({ databaseId: 20, body: 'not reply 2' });
  const current = clone(before); current.threads[0].comments.push(clone(reply));
  cases.push({ name: 'ID 2 versus 20', mode: 'mutation', expected: before, current, rootIds: [1], receipts: [receipt] });
}
{
  const before = clone(expected); before.threads.push({ id: 'duplicate-root', isResolved: false, comments: [{ databaseId: 1, body: 'different thread' }] });
  const current = clone(before); current.threads[0].comments.push(clone(reply)); current.threads.reverse();
  cases.push({ name: 'duplicate snapshot root uses first', mode: 'mutation', expected: before, current, rootIds: [1], receipts: [receipt] });
}
mutation('null receipt', null, [receipt, null]);
cases.push({ name: 'empty roots do not read missing expected data', mode: 'mutation', expected: {}, current: { threads: [] }, rootIds: [], receipts: null });
cases.push({ name: 'empty roots still reject null current thread', mode: 'mutation', expected: {}, current: { threads: [null] }, rootIds: [], receipts: [] });

test('PowerShell freshness comparison preserves JavaScript decisions and failure categories', { timeout: 90000 }, () => {
  for (const item of cases) {
    let wanted = 'ok';
    try { oracle(item.mode, item.expected, item.current, item.rootIds, item.receipts); }
    catch (error) { wanted = ['thread', 'reviews', 'repo', 'identity', 'available', 'visible', 'changed'].includes(error.message) ? error.message : 'invalid'; }
    const result = spawnSync(process.env.GH_AW_REVIEW_PWSH || 'pwsh', ['-NoLogo', '-NoProfile', '-NonInteractive', '-File', script], { input: JSON.stringify(item), encoding: 'utf8' });
    const actual = result.status === 0 && result.stdout === '{}' ? 'ok' : category(result.stderr);
    assert.equal(actual, wanted, `${item.name}: ${result.stderr}`);
  }
});
