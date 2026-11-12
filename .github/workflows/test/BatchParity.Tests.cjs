'use strict';
const assert = require('node:assert/strict');
const { spawnSync } = require('node:child_process');
const { test } = require('node:test');
const path = require('node:path');
const { nextBatch } = require('./TestBatchReference.cjs');

// Compare compact JSON-derived work items with the original JavaScript selector.
test('PowerShell batch sizing preserves JavaScript ordering and UTF-8 limits', { timeout: 30000 }, async t => {
  const item = (index, bytes, unicode = false) => {
    const value = { id: `file:${index}`, file: { filename: `src/${index}.cs`, status: 'modified', patch: '' } };
    const remaining = bytes - Buffer.byteLength(JSON.stringify(value));
    value.file.patch = unicode ? 'é'.repeat(Math.floor(remaining / 2)) + (remaining % 2 ? 'x' : '') : 'x'.repeat(remaining);
    assert.equal(Buffer.byteLength(JSON.stringify(value)), bytes); return value;
  };
  const cases = [[], [item(0, 48001)], [item(0, 48001), item(1, 100)],
    [item(0, 24000), item(1, 24000, true)], [item(0, 24000), item(1, 24001, true)],
    Array.from({ length: 10 }, (_, i) => item(i, 100)),
    [{ id: 'thread:0', thread: { comments: [] } }, { id: 'file:0', file: { filename: 'f' } }],
    [{ id: 'file:0', file: { filename: 'f' } }, { id: 'thread:0', thread: { comments: [] } }],
    [{ id: 'thread:0', thread: [] }, { id: 'thread:1', thread: {} }],
    [{ id: 'file:0', thread: '' }, { id: 'thread:0', thread: 'x' }],
  ];
  let seed = 0x16a8d7f3;
  const rnd = () => (seed = (Math.imul(seed, 1664525) + 1013904223) >>> 0);
  const units = [0, 9, 10, 34, 47, 92, 0x85, 0xe9, 0x2028, 0xd800, 0xd83d, 0xde00, 0xdfff];
  const str = () => String.fromCharCode(...Array.from({ length: rnd() % 35 }, () => units[rnd() % units.length]));
  for (let n = 0; n < 1000; n++) {
    const work = Array.from({ length: rnd() % 12 }, (_, i) => rnd() % 3 === 0
      ? { id: `thread:${i}`, thread: { id: str(), comments: [{ body: str() }] } }
      : { id: `file:${i}`, file: { filename: str(), status: 'modified', patch: str() } });
    cases.push(work);
  }
  const expected = cases.map(work => nextBatch(work).length);
  const input = JSON.stringify(cases.map(work => ({ work: work.slice(0, 9) })));
  const result = spawnSync(process.env.GH_AW_REVIEW_PWSH || 'pwsh', ['-NoLogo', '-NoProfile', '-NonInteractive', '-File', path.join(__dirname, 'Invoke-BatchCases.ps1')], { input, encoding: 'utf8', maxBuffer: 8 * 1024 * 1024 });
  assert.equal(result.status, 0, result.stderr);
  assert.deepEqual(JSON.parse(result.stdout), expected);
  // Stream all original arbitrary-item cases through the actual generic
  // transport and shared selector. The new production host accepts snapshots,
  // not this retired standalone selector protocol; use a test-only dispatcher.
  const fs=require('node:fs'),os=require('node:os');
  const directory=fs.mkdtempSync(path.join(os.tmpdir(),'core-batch-parity-')),proxy=path.join(directory,'pwsh');
  const previous=process.env.GH_AW_REVIEW_PWSH,executable=previous||'pwsh';
  fs.writeFileSync(proxy,'#!/usr/bin/env node\n'+`const child=require('node:child_process').spawn(${JSON.stringify(executable)},['-NoLogo','-NoProfile','-NonInteractive','-File',${JSON.stringify(path.join(__dirname,'Invoke-BatchCases.ps1'))},'-Stream'],{stdio:'inherit'});child.on('error',error=>{console.error(error);process.exitCode=1;});child.on('exit',(code,signal)=>{process.exitCode=signal?1:code;});`,{mode:0o755});
  process.env.GH_AW_REVIEW_PWSH=proxy;
  t.after(()=>{if(previous===undefined)delete process.env.GH_AW_REVIEW_PWSH;else process.env.GH_AW_REVIEW_PWSH=previous;fs.rmSync(directory,{recursive:true,force:true});});
  const { startContinuationSession } = require('../pr-re-review/ReviewContinuationSession.cjs');
  const session = startContinuationSession();
  try {
    for (const [i, work] of cases.entries()) {
      const {value}=await session.request('batch',{work},{deadline:Date.now()+10000});
      assert.equal(value,expected[i],`streaming count ${i}`);
      assert.deepEqual(work.slice(0,value), work.slice(0, expected[i]), `streaming case ${i}`);
    }
  } finally { await session.close(); }
});
