'use strict';
const assert = require('node:assert/strict');
const { test } = require('node:test');
const { spawnSync } = require('node:child_process');
const path = require('node:path');
const { requiredInputs } = require('./TestDeliveryReference.cjs');

test('PowerShell delivery selection matches the original JavaScript contract', { timeout: 30000 }, () => {
  let seed = 0x5ca1ab1e;
  function rnd() { seed = (Math.imul(seed, 1664525) + 1013904223) >>> 0; return seed; }
  const units = [0, 8, 9, 10, 12, 13, 31, 34, 47, 92, 65, 0x85, 0xe9, 0x2028, 0x2029, 0xd7ff, 0xd800, 0xd83d, 0xde00, 0xdfff, 0xe000, 0xffff];
  function str() { return String.fromCharCode(...Array.from({ length: rnd() % 12 }, () => units[rnd() % units.length])); }
  function value(depth) {
    const kind = rnd() % 7;
    if (depth <= 0 || kind < 3) return [null, true, false, str(), rnd(), 1e21, 1e-7, -0][rnd() % 8];
    if (kind < 5) return Array.from({ length: rnd() % 5 }, () => value(depth - 1));
    const object = {}; for (let i = 0, count = rnd() % 5; i < count; i++) object[[String(rnd() % 9), str(), 'normal'][rnd() % 3]] = value(depth - 1);
    return object;
  }
  const items = Array.from({ length: 1000 }, () => ({ id: 'thread:0', thread: value(3) }));
  for (const patch of ['x'.repeat(47999), 'x'.repeat(48000), 'x'.repeat(48001), 'é'.repeat(24000), 'é'.repeat(24000) + 'x', 'x'.repeat(47999) + '\ud800'])
    for (const status of ['added', 'modified', 'removed', 'renamed']) items.push({ id: 'file:0', file: { filename: 'f', status, previous_filename: 'old', patch } });
  for (const file of [{ filename: 'f', status: 'modified\0' }, { filename: 'f', status: 'renamed\0' }, { filename: 'f', status: 'added\u00ad' }, { filename: 'f', status: 'renamed' }, { filename: 'f', status: 'unknown' }, { filename: 'f', status: 'modified', patch: null }, { filename: 5, status: 'added' }, { filename: '', status: 'added' }]) items.push({ id: 'file:0', file });
  let deep = { end: 'x' }; for (let i = 0; i < 80; i++) deep = { nested: deep }; items.push({ id: 'thread:0', thread: deep });
  const expected = items.map(item => { try { return { value: requiredInputs({}, item) }; } catch (error) { return { error: error.message }; } });
  const result = spawnSync(process.env.GH_AW_REVIEW_PWSH || 'pwsh', ['-NoLogo', '-NoProfile', '-NonInteractive', '-File', path.join(__dirname, 'Invoke-DeliveryInputs.ps1')], { input: JSON.stringify(items), encoding: 'utf8', maxBuffer: 16 * 1024 * 1024 });
  assert.equal(result.status, 0, result.stderr);
  assert.deepEqual(JSON.parse(result.stdout), expected);
});
