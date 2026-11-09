'use strict';

const assert = require('node:assert/strict');
const fs = require('node:fs');
const { spawnSync } = require('node:child_process');
const { test } = require('node:test');
const path = require('node:path');

const workflow = fs.readFileSync(path.join(__dirname, '..', 'pr-re-review.md'), 'utf8');
const script = workflow.match(/# BEGIN SAFE OUTPUT STATUS[^\n]*\n([\s\S]*?)\n\s*# END SAFE OUTPUT STATUS/)?.[1];
assert.ok(script, 'missing inline safe-output status check');

function check(skipped) {
  const env = { ...process.env };
  if (skipped === undefined) delete env.SAFE_OUTPUTS_SKIPPED;
  else env.SAFE_OUTPUTS_SKIPPED = skipped;
  return spawnSync('bash', ['-c', script], { env, encoding: 'utf8' });
}

test('compiled workflow checks the safe-output job skip count', () => {
  const lock = fs.readFileSync(path.join(__dirname, '..', 'pr-re-review.lock.yml'), 'utf8');
  const job = lock.match(/^  check_safe_output_status:\n([\s\S]*?)(?=^  [a-zA-Z0-9_-]+:\n|(?![\s\S]))/m)?.[1];
  assert.ok(job, 'missing check_safe_output_status job');
  assert.match(job, /needs:[\s\S]*?safe_outputs/);
  assert.match(job, /needs\.safe_outputs\.outputs\.process_safe_outputs_items_skipped/);
  assert.match(job, /BEGIN SAFE OUTPUT STATUS/);
  assert.doesNotMatch(job, /CheckSafeOutputStatus\.cjs/);
});

test('accepts a safe-output run with no skipped items', () => {
  const result = check('0');
  assert.equal(result.status, 0, result.stderr);
});

test('fails visibly for the nine skips observed in issue 64475', () => {
  const result = check('9');
  assert.notEqual(result.status, 0);
  assert.match(result.stderr, /9.*skipped/i);
});

test('fails closed when the skipped count is missing or invalid', () => {
  for (const value of [undefined, '', '-1', '1.5', 'not-a-number']) {
    const result = check(value);
    assert.notEqual(result.status, 0, `accepted ${String(value)}`);
    assert.match(result.stderr, /invalid|missing/i);
  }
});
