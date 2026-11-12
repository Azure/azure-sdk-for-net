'use strict';

const assert = require('node:assert/strict');
const fs = require('node:fs');
const { test } = require('node:test');
const path = require('node:path');
const { captureChangedFiles } = require('../pr-re-review/ReviewSnapshot.cjs');
const HEAD = 'a'.repeat(40);
const BASE = 'b'.repeat(40);

function fixture(count, options = {}) {
  const files = Array.from({ length: count }, (_, i) => ({
    filename: `file-${i}.cs`, status: 'modified', patch: `@@ -1 +1 @@\n-old ${i}\n+new ${i}`,
  }));
  const calls = [];
  let getCount = 0;
  const github = { rest: { pulls: {
    get: async () => ({ data: {
      state: options.closed ? 'closed' : 'open', draft: !!options.draft,
      changed_files: ++getCount > 1 && options.countChanged ? count + 1 : count,
      head: { sha: getCount > 1 && options.moved ? 'c'.repeat(40) : HEAD },
      base: { sha: getCount > 1 && options.baseMoved ? 'd'.repeat(40) : options.baseInitiallyMoved ? 'e'.repeat(40) : BASE },
    } }),
    listFiles: async ({ page, per_page }) => {
      calls.push({ page, per_page });
      if (page === options.failPage) throw new Error('API unavailable');
      let data = files.slice((page - 1) * per_page, page * per_page);
      if (page === 2 && options.duplicate) data = [files[0], ...data.slice(1)];
      if (options.omitPage === page) data = [];
      if (page === 1 && options.missingPatch && data.length) data[0] = { filename: data[0].filename, status: 'modified' };
      return { data };
    },
  } } };
  return { github, calls, args: { owner: 'Azure', repo: 'azure-sdk-for-net', pullNumber: 64192, headSha: HEAD, baseSha: BASE } };
}

test('compiled agent captures changed files before starting and mounts the manifest read-only', () => {
  const lock = fs.readFileSync(path.join(__dirname, '..', 'pr-re-review.lock.yml'), 'utf8');
  const job = lock.match(/^  agent:\n([\s\S]*?)(?=^  [a-zA-Z0-9_-]+:\n|(?![\s\S]))/m)?.[1];
  assert.ok(job, 'missing agent job');
  const capture = job.indexOf('name: Capture all changed-file pages');
  const execution = job.indexOf('id: agentic_execution');
  assert.ok(capture >= 0 && execution > capture, 'capture must run before the agent');
  assert.doesNotMatch(job, /CaptureChangedFiles\.cjs|\.review-capture-tools/);
  assert.match(job, /pr-re-review-files\.json/);
  assert.match(job, /--mount "\$\{RUNNER_TEMP\}\/gh-aw:\$\{RUNNER_TEMP\}\/gh-aw:ro"/);
});

for (const count of [0, 100, 106, 201]) {
  test(`captures all ${count} changed files with 100-item pages`, async () => {
    const f = fixture(count);
    const result = await captureChangedFiles(f.github, f.args);
    assert.equal(result.files.length, count);
    assert.equal(result.changed_files, count);
    assert.deepEqual(f.calls, Array.from({ length: Math.floor(count / 100) + 1 }, (_, i) => ({ page: i + 1, per_page: 100 })));
  });
}

test('accepts 3000 files without requesting a page beyond the endpoint limit', async () => {
  const f = fixture(3000);
  const result = await captureChangedFiles(f.github, f.args);
  assert.equal(result.files.length, 3000);
  assert.equal(f.calls.length, 30);
});

test('accepts a base that advanced before capture and remains stable', async () => {
  const f = fixture(106, { baseInitiallyMoved: true });
  const result = await captureChangedFiles(f.github, f.args);
  assert.equal(result.base_sha, 'e'.repeat(40));
  assert.equal(result.files.length, 106);
});

test('rejects PRs beyond the GitHub changed-files endpoint limit', async () => {
  const f = fixture(3001);
  await assert.rejects(() => captureChangedFiles(f.github, f.args), /3000-file endpoint limit/);
  assert.equal(f.calls.length, 0);
});

test('preserves the absence of a patch for the full-file fallback', async () => {
  const f = fixture(1, { missingPatch: true });
  const result = await captureChangedFiles(f.github, f.args);
  assert.equal(Object.hasOwn(result.files[0], 'patch'), false);
});

for (const [name, options, pattern] of [
  ['a failed page', { failPage: 2 }, /API unavailable/],
  ['duplicate filenames', { duplicate: true }, /duplicate/i],
  ['an incomplete listing', { omitPage: 2 }, /count|incomplete/i],
  ['a moved PR head', { moved: true }, /head|changed/i],
  ['a moved PR base', { baseMoved: true }, /base|changed/i],
  ['a changed file count', { countChanged: true }, /count changed/i],
  ['a closed PR', { closed: true }, /state|stale/i],
  ['a draft PR', { draft: true }, /state|stale/i],
]) {
  test(`fails closed on ${name}`, async () => {
    const f = fixture(106, options);
    await assert.rejects(() => captureChangedFiles(f.github, f.args), pattern);
  });
}
