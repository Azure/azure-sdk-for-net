'use strict';
const assert = require('node:assert/strict');
const { test } = require('node:test');
const { captureContext, assertFresh, assertMutationFresh, exportContext } = require('../pr-re-review/ReviewSnapshot.cjs');
const files = { pull_number: 64192, head_sha: 'a'.repeat(40), base_sha: 'b'.repeat(40), changed_files: 106, files: [] };
const thread = i => ({ id: `thread-${i}`, isResolved: false, comments: { nodes: [{ databaseId: i + 1, body: 'finding', path: 'src/F.cs' }], pageInfo: { hasNextPage: false, endCursor: null } } });
function fixture(count = 1, extra = {}) {
  const threads = Array.from({ length: count }, (_, i) => thread(i));
  const calls = [];
  const pull = { state: 'open', draft: false, head: { sha: files.head_sha, repo: { full_name: 'Azure/azure-sdk-for-net' } }, base: { sha: files.base_sha, repo: { full_name: 'Azure/azure-sdk-for-net' } }, changed_files: 106 };
  const github = {
    request: async () => ({ data: { base_commit: { sha: files.base_sha }, merge_base_commit: { sha: files.base_sha } } }),
    rest: { pulls: { get: async () => ({ data: { ...pull, ...extra.pull } }), listReviews: () => {} } },
    paginate: async () => [{ id: 7, body: 'prior review', state: 'COMMENTED', commit_id: files.head_sha }],
    graphql: async (query, vars) => {
      calls.push(vars);
      const offset = vars.after === null ? 0 : Number(vars.after);
      const nodes = threads.slice(offset, offset + 100);
      return { repository: { pullRequest: { reviewThreads: { totalCount: count, nodes, pageInfo: { hasNextPage: offset + nodes.length < count, endCursor: String(offset + nodes.length) } } } } };
    },
  };
  return { github, threads, calls, pull };
}

function fixtureWithBaseline(t) {
  const fs = require('node:fs'), os = require('node:os'), path = require('node:path');
  const f = fixture();
  const name = 'eng/apicompatbaselines/Azure.Example.xml';
  const manifest = { ...files, files: [{ filename: name, status: 'modified' }] };
  const repo = { owner: 'Azure', repo: 'azure-sdk-for-net' };
  f.pull.head.repo = { full_name: 'Azure/azure-sdk-for-net' };
  f.pull.base.repo = { full_name: 'Azure/azure-sdk-for-net' };
  const directory = fs.mkdtempSync(path.join(os.tmpdir(), 'baseline-gh-'));
  const statePath = path.join(directory, 'state.json');
  fs.writeFileSync(statePath, JSON.stringify({ reads: 0, unavailable: false, corrupt: false }));
  const oldPath = process.env.PATH, oldState = process.env.GH_TEST_STATE, oldToken = process.env.GH_TOKEN;
  process.env.PATH = `${directory}${path.delimiter}${oldPath}`;
  process.env.GH_TEST_STATE = statePath; process.env.GH_TOKEN = 'fixture-token';
  t.after(() => { process.env.PATH = oldPath; if (oldState === undefined) delete process.env.GH_TEST_STATE; else process.env.GH_TEST_STATE = oldState; if (oldToken === undefined) delete process.env.GH_TOKEN; else process.env.GH_TOKEN = oldToken; fs.rmSync(directory, { recursive: true, force: true }); });
  const fake = `#!/usr/bin/env node
    const fs=require('node:fs'),crypto=require('node:crypto');
    if(process.env.GH_TOKEN!=='fixture-token') { console.error('missing scoped token'); process.exit(1); }
    const state=JSON.parse(fs.readFileSync(process.env.GH_TEST_STATE,'utf8'));state.reads++;fs.writeFileSync(process.env.GH_TEST_STATE,JSON.stringify(state));
    if(state.unavailable){console.log('HTTP/2.0 500 Error\\nContent-Type: application/json\\n\\n{}');console.error('gh: unavailable (HTTP 500)');process.exit(1);}
    const route=process.argv.at(-1),ref=new URL('https://example.invalid/'+route).searchParams.get('ref');
    const content=ref===${JSON.stringify(files.base_sha)}?(state.baseContent ?? '<Suppressions />'):(state.headContent ?? '<Suppressions><Suppression><DiagnosticId>CP1</DiagnosticId><Target>T:Model</Target></Suppression></Suppressions>');
    const b=Buffer.from(content),sha=state.corrupt?'0'.repeat(40):crypto.createHash('sha1').update('blob '+b.length+'\\0').update(b).digest('hex');
    console.log('HTTP/2.0 200 OK\\nContent-Type: application/json\\n\\n'+JSON.stringify({type:'file',encoding:'base64',content:b.toString('base64'),size:b.length,sha}));
  `;
  if (process.platform === 'win32') {
    fs.writeFileSync(path.join(directory, 'gh-fake.cjs'), fake);
    fs.writeFileSync(path.join(directory, 'gh.cmd'), '@node "%~dp0gh-fake.cjs" %*\r\n');
  } else {
    fs.writeFileSync(path.join(directory, 'gh'), fake, { mode: 0o755 });
  }
  const state = new Proxy({}, { get: (_target, key) => JSON.parse(fs.readFileSync(statePath, 'utf8'))[key], set: (_target, key, value) => { const data = JSON.parse(fs.readFileSync(statePath, 'utf8')); data[key] = value; fs.writeFileSync(statePath, JSON.stringify(data)); return true; } });
  return { ...f, manifest, repo, state };
}

test('captures the pinned merge base once and retains the base tip for freshness', async () => {
  const f = fixture(); const mergeBase = 'c'.repeat(40); let calls = 0;
  f.github.request = async (route, args) => {
    calls++;
    assert.equal(route, 'GET /repos/{owner}/{repo}/compare/{basehead}');
    assert.equal(args.basehead, `${files.base_sha}...${files.head_sha}`);
    assert.equal(args.per_page, 1);
    return { data: { base_commit: { sha: files.base_sha }, merge_base_commit: { sha: mergeBase } } };
  };
  const snapshot = await captureContext(f.github, { owner: 'Azure', repo: 'azure-sdk-for-net' }, files);
  assert.equal(snapshot.base_sha, files.base_sha);
  assert.equal(snapshot.diff_base_sha, mergeBase);
  f.github.request = async () => { throw new Error('immutable compare unavailable'); };
  await assertFresh(f.github, { owner: 'Azure', repo: 'azure-sdk-for-net' }, snapshot);
  f.threads[0].comments.nodes.push({ databaseId: 2, body: 'our reply', path: 'src/F.cs' });
  await assertMutationFresh(f.github, { owner: 'Azure', repo: 'azure-sdk-for-net' }, snapshot, [1], [{ type: 'reply_to_pull_request_review_comment', provider: 'github', id: 1, metadata: { reply_id: 2 } }]);
  assert.equal(calls, 1);
  f.pull.base.sha = 'd'.repeat(40);
  await assert.rejects(assertFresh(f.github, { owner: 'Azure', repo: 'azure-sdk-for-net' }, snapshot), /state|stale/i);
});

test('a base change during compare still blocks publication and mutation', async () => {
  const f = fixture();
  f.github.request = async () => {
    f.pull.base.sha = 'd'.repeat(40);
    return { data: { base_commit: { sha: files.base_sha }, merge_base_commit: { sha: 'c'.repeat(40) } } };
  };
  const repo = { owner: 'Azure', repo: 'azure-sdk-for-net' };
  const snapshot = await captureContext(f.github, repo, files);
  await assert.rejects(assertFresh(f.github, repo, snapshot), /state|stale/i);
  await assert.rejects(assertMutationFresh(f.github, repo, snapshot, [1], [{ type: 'reply_to_pull_request_review_comment', provider: 'github', id: 1, metadata: { reply_id: 2 } }]), /state|stale/i);
});

test('fails closed when the pinned diff base is unavailable or invalid', async () => {
  for (const data of [{}, { base_commit: { sha: 'd'.repeat(40) }, merge_base_commit: { sha: 'c'.repeat(40) } }, { base_commit: { sha: files.base_sha }, merge_base_commit: { sha: 'bad' } }]) {
    const f = fixture(); f.github.request = async () => ({ data });
    await assert.rejects(captureContext(f.github, {}, files), /diff base/i);
  }
  const f = fixture(); f.github.request = async () => { throw new Error('compare unavailable'); };
  await assert.rejects(captureContext(f.github, {}, files), /compare unavailable/);
});

test('captured baseline is checked once and not refetched for freshness', async t => {
  const f = fixtureWithBaseline(t);
  const snapshot = await captureContext(f.github, f.repo, f.manifest);
  assert.equal(snapshot.baseline_suppressions.length, 1);
  assert.equal(f.state.reads, 2);
  f.state.unavailable = true;
  await assertFresh(f.github, f.repo, snapshot);
  f.threads[0].comments.nodes.push({ databaseId: 2, body: 'our reply', path: 'src/F.cs' });
  await assertMutationFresh(f.github, f.repo, snapshot, [1], [{ type: 'reply_to_pull_request_review_comment', provider: 'github', id: 1, metadata: { reply_id: 2 } }]);
  assert.equal(f.state.reads, 2);
});

test('PowerShell capture preserves Unicode and case-distinct fields through Node JSON parsing', async t => {
  const f = fixtureWithBaseline(t);
  f.state.headContent = '<Suppressions><Suppression><DiagnosticId>CP1</DiagnosticId><Target>T:𝄞界</Target><target>different</target></Suppression><Suppression><DiagnosticId>CP2</DiagnosticId><Target>T:Other</Target></Suppression></Suppressions>';
  const snapshot = await captureContext(f.github, f.repo, f.manifest);
  assert.equal(snapshot.baseline_suppressions.length, 2);
  assert.deepEqual(snapshot.baseline_suppressions[0].fields, { DiagnosticId: 'CP1', Target: 'T:𝄞界', target: 'different' });
  assert.equal(snapshot.baseline_suppressions[1].fields.Target, 'T:Other');
});

test('initial missing baseline data still fails closed', async t => {
  const f = fixtureWithBaseline(t);
  f.state.unavailable = true;
  await assert.rejects(captureContext(f.github, f.repo, f.manifest), /unable|unavailable/i);
});

test('initial corrupt baseline data still fails closed', async t => {
  const f = fixtureWithBaseline(t);
  f.state.corrupt = true;
  await assert.rejects(captureContext(f.github, f.repo, f.manifest), /corrupt/i);
});

test('freshness still rejects changed identity, thread and review state without refetching baselines', async t => {
  const f = fixtureWithBaseline(t);
  const snapshot = await captureContext(f.github, f.repo, f.manifest);
  f.state.unavailable = true;
  f.pull.head.sha = 'c'.repeat(40);
  await assert.rejects(assertFresh(f.github, f.repo, snapshot), /state|stale/i);
  f.pull.head.sha = files.head_sha;
  f.pull.base.sha = 'c'.repeat(40);
  await assert.rejects(assertFresh(f.github, f.repo, snapshot), /state|stale/i);
  f.pull.base.sha = files.base_sha;
  f.threads[0].comments.nodes.push({ databaseId: 9, body: 'external', path: 'src/F.cs' });
  await assert.rejects(assertFresh(f.github, f.repo, snapshot), /thread state/i);
  f.threads[0].comments.nodes.pop();
  const originalReviews = f.github.paginate;
  f.github.paginate = async () => [{ id: 9, body: 'new review', state: 'COMMENTED', commit_id: files.head_sha }];
  await assert.rejects(assertFresh(f.github, f.repo, snapshot), /review history/i);
  f.github.paginate = originalReviews;
  f.pull.head.repo.full_name = 'other/azure-sdk-for-net';
  await assert.rejects(assertFresh(f.github, f.repo, snapshot), /repository identity/i);
  assert.equal(f.state.reads, 2);
});

test('freshness detects captured thread and comment metadata changes', async t => {
  const f = fixtureWithBaseline(t);
  f.threads[0].isOutdated = false;
  f.threads[0].isCollapsed = false;
  f.threads[0].comments.nodes[0].author = { login: 'reviewer' };
  f.threads[0].comments.nodes[0].updatedAt = '2026-01-02T00:00:00Z';
  const snapshot = JSON.parse(JSON.stringify(await captureContext(f.github, f.repo, f.manifest)));
  f.state.unavailable = true;
  f.threads[0].isOutdated = true;
  await assert.rejects(assertFresh(f.github, f.repo, snapshot), /thread state/i);
  f.threads[0].isOutdated = false;
  f.threads[0].comments.nodes[0].author.login = 'different';
  await assert.rejects(assertFresh(f.github, f.repo, snapshot), /thread state/i);
  assert.equal(f.state.reads, 2);
});

test('thread mutation still rejects external replies without refetching baselines', async t => {
  const f = fixtureWithBaseline(t);
  const snapshot = await captureContext(f.github, f.repo, f.manifest);
  f.state.unavailable = true;
  f.threads[0].comments.nodes.push({ databaseId: 2, body: 'our reply', path: 'src/F.cs' }, { databaseId: 3, body: 'external', path: 'src/F.cs' });
  const receipts = [{ type: 'reply_to_pull_request_review_comment', provider: 'github', id: 1, metadata: { reply_id: 2 } }];
  await assert.rejects(assertMutationFresh(f.github, f.repo, snapshot, [1], receipts), /changed after publication/i);
  f.threads[0].comments.nodes.pop();
  await assertMutationFresh(f.github, f.repo, snapshot, [1], receipts);
  assert.equal(f.state.reads, 2);
});

test('exports captured thread histories and prior reviews for worker context', async t => {
  const fs = require('node:fs'); const os = require('node:os'); const path = require('node:path');
  const directory = fs.mkdtempSync(path.join(os.tmpdir(), 'review-context-'));
  t.after(() => fs.rmSync(directory, { recursive: true, force: true }));
  const f = fixture();
  const snapshot = await captureContext(f.github, { owner: 'Azure', repo: 'azure-sdk-for-net' }, files);
  await exportContext(snapshot, directory);
  const index = JSON.parse(fs.readFileSync(path.join(directory, 'index.json'), 'utf8'));
  assert.equal(index.threads.length, 1);
  assert.equal(index.reviews.length, 1);
  assert.equal(index.diff_base_sha, snapshot.diff_base_sha);
  assert.deepEqual(JSON.parse(fs.readFileSync(index.threads[0].history_path, 'utf8')), snapshot.threads[0]);
  assert.deepEqual(JSON.parse(fs.readFileSync(index.reviews[0].history_path, 'utf8')), snapshot.reviews[0]);
});

test('exports canonical required-input keys for the private reader', async t => {
  const fs = require('node:fs'); const os = require('node:os'); const path = require('node:path');
  const { snapshotDigest } = require('../pr-re-review/ReviewDelivery.cjs');
  const { requiredInputs } = require('./TestDeliveryReference.cjs');
  const directory = fs.mkdtempSync(path.join(os.tmpdir(), 'delivery-index-'));
  t.after(() => fs.rmSync(directory, { recursive: true, force: true }));
  const snapshot = {
    head_sha: 'a'.repeat(40), base_sha: 'b'.repeat(40),
    files: [{ filename: 'small.cs', status: 'modified', patch: 'short' }, { filename: 'big.cs', status: 'modified', patch: 'x'.repeat(50000) + '\ud83d' }, { filename: 'source.cs', status: 'modified' },
      { filename: 'boundary.cs', status: 'added', patch: 'x'.repeat(48000) }, { filename: 'above.cs', status: 'added', patch: 'é'.repeat(24000) + 'x' }],
    threads: [{ id: 'one', comments: [{ path: 'small.cs', body: '😀' }] }, { 10: 'integer key', 2: 'first', id: 'surrogate', comments: [{ body: '\ud800 and \\ slash' }] }], reviews: [],
  };
  await exportContext(snapshot, directory);
  const index = JSON.parse(fs.readFileSync(path.join(directory, 'delivery-index.json'), 'utf8'));
  assert.equal(index.snapshot, snapshotDigest(snapshot));
  for (const [kind, values] of [['file', snapshot.files], ['thread', snapshot.threads]]) values.forEach((value, i) => {
    const id = `${kind}:${i}`;
    assert.deepEqual(index.items[id], requiredInputs(snapshot, { id, [kind]: value }).map(({ key, kind }) => ({ key, kind })));
  });
  assert.deepEqual(index.items['file:0'], []);
  assert.deepEqual(index.items['file:2'], []);
  assert.equal(index.items['file:1'][0].kind, 'patch');
  assert.deepEqual(index.items['file:3'], []);
  assert.equal(index.items['file:4'][0].kind, 'patch');
  assert.equal(index.items['thread:0'][0].kind, 'history');
  assert.equal(index.items['thread:1'][0].kind, 'history');
});

test('capture rejects incomplete or malformed delivery index responses', async t => {
  const fs = require('node:fs'); const os = require('node:os'); const path = require('node:path');
  const delivery = require('../pr-re-review/ReviewDelivery.cjs'); const { snapshotDigest } = delivery;
  const directory = fs.mkdtempSync(path.join(os.tmpdir(), 'delivery-bad-index-'));
  const originalRunner = delivery.runPowerShell;
  t.after(() => { delivery.runPowerShell = originalRunner; fs.rmSync(directory, { recursive: true, force: true }); });
  const snapshot = { files: [{ filename: 'f', status: 'added' }], threads: [{ id: 't', comments: [] }], reviews: [] };
  const valid = { snapshot: snapshotDigest(snapshot), items: { 'file:0': [], 'thread:0': [{ kind: 'history', key: 'history:' + 'a'.repeat(64) }] } };
  for (const bad of [
    { ...valid, snapshot: '0'.repeat(64) },
    { ...valid, items: { 'file:0': [] } },
    { ...valid, items: { ...valid.items, 'thread:0': [] } },
    { ...valid, items: { ...valid.items, 'thread:0': [{ kind: 'patch', key: 'patch:' + 'a'.repeat(64) }] } },
    { ...valid, items: { ...valid.items, 'file:1': [] } },
  ]) {
    delivery.runPowerShell = async () => ({ stdout: JSON.stringify(bad), stderr: '' });
    await assert.rejects(exportContext(snapshot, directory), /invalid captured delivery/i);
    assert.equal(fs.existsSync(path.join(directory, 'delivery-index.json')), false);
  }
});

test('capture fails closed for malformed omitted-patch status and rename', async t => {
  const fs = require('node:fs'); const os = require('node:os'); const path = require('node:path');
  const directory = fs.mkdtempSync(path.join(os.tmpdir(), 'delivery-invalid-'));
  t.after(() => fs.rmSync(directory, { recursive: true, force: true }));
  for (const file of [{ filename: 'f', status: 'modified\0' }, { filename: 'f', status: 'renamed' }]) {
    await assert.rejects(exportContext({ files: [file], threads: [], reviews: [] }, directory), /unsupported|source path/i);
    assert.equal(fs.existsSync(path.join(directory, 'delivery-index.json')), false);
  }
});

test('captures all thread pages and previous reviews', async () => {
  const f = fixture(106);
  const s = await captureContext(f.github, { owner: 'Azure', repo: 'azure-sdk-for-net' }, files);
  assert.equal(s.threads.length, 106);
  assert.deepEqual(f.calls.map(c => c.after), [null, '100']);
  assert.equal(s.reviews[0].body, 'prior review');
});

test('captures review metadata on every thread comment page', async () => {
  const f = fixture();
  f.threads[0].isOutdated = true;
  f.threads[0].isCollapsed = false;
  f.threads[0].comments.nodes = Array.from({ length: 100 }, (_, i) => ({
    databaseId: i + 1, body: `comment ${i + 1}`, path: 'src/F.cs',
    author: { login: `author${i + 1}` }, createdAt: '2026-01-01T00:00:00Z',
    publishedAt: '2026-01-04T00:00:00Z', pullRequestReview: { submittedAt: '2026-01-04T00:00:00Z' },
    updatedAt: i === 99 ? '2026-01-08T00:00:00Z' : '2026-01-02T00:00:00Z',
  }));
  f.threads[0].comments.pageInfo = { hasNextPage: true, endCursor: 'comments-next' };
  const first = f.github.graphql;
  f.github.graphql = async (query, vars) => {
    assert.match(query, /author\s*\{\s*login\s*\}/);
    assert.match(query, /createdAt/);
    assert.match(query, /updatedAt/);
    assert.match(query, /publishedAt/);
    assert.match(query, /pullRequestReview\s*\{\s*submittedAt\s*\}/);
    if (!vars.id) {
      assert.match(query, /isOutdated/);
      assert.match(query, /isCollapsed/);
      return first(query, vars);
    }
    return { node: { comments: { nodes: [{ databaseId: 101, body: 'last comment', path: 'src/F.cs', author: { login: 'author101' }, createdAt: '2026-01-03T00:00:00Z', updatedAt: '2026-01-04T00:00:00Z', publishedAt: '2026-01-07T00:00:00Z', pullRequestReview: { submittedAt: '2026-01-07T00:00:00Z' } }], pageInfo: { hasNextPage: false, endCursor: null } } } };
  };
  f.github.paginate = async () => [{ id: 7, body: 'prior review', state: 'COMMENTED', commit_id: files.head_sha, user: { login: 'reviewer' }, submitted_at: '2026-01-05T00:00:00Z', html_url: 'https://github.com/example/review', author_association: 'MEMBER' }];
  const captured = await captureContext(f.github, { owner: 'Azure', repo: 'azure-sdk-for-net' }, files);
  assert.equal(captured.threads[0].isOutdated, true);
  assert.equal(captured.threads[0].isCollapsed, false);
  // Comment 100 was public before the January 6 fix but edited afterward.
  const edited = captured.threads[0].comments[99];
  assert.ok(Date.parse(edited.publishedAt) < Date.parse('2026-01-06T00:00:00Z'));
  assert.ok(Date.parse(edited.updatedAt) > Date.parse('2026-01-06T00:00:00Z'));
  assert.equal(captured.threads[0].comments[100].author.login, 'author101');
  assert.equal(captured.threads[0].comments[100].createdAt, '2026-01-03T00:00:00Z');
  assert.equal(captured.threads[0].comments[100].updatedAt, '2026-01-04T00:00:00Z');
  // The comment was drafted before a fix on January 6 but only became public afterward.
  assert.equal(captured.threads[0].comments[100].publishedAt, '2026-01-07T00:00:00Z');
  assert.equal(captured.threads[0].comments[100].pullRequestReview.submittedAt, '2026-01-07T00:00:00Z');
  assert.equal(captured.reviews[0].author, 'reviewer');
  assert.equal(captured.reviews[0].submittedAt, '2026-01-05T00:00:00Z');
  assert.equal(captured.reviews[0].url, 'https://github.com/example/review');
  assert.equal(captured.reviews[0].authorAssociation, 'MEMBER');
});

test('captures a thread history beyond its first 100 comments', async () => {
  const f = fixture();
  f.threads[0].comments.pageInfo = { hasNextPage: true, endCursor: 'comments-next' };
  const original = f.github.graphql;
  f.github.graphql = async (query, vars) => vars.id ? { node: { comments: { nodes: [{ databaseId: 2, body: 'reply', path: 'src/F.cs' }], pageInfo: { hasNextPage: false, endCursor: null } } } } : original(query, vars);
  const s = await captureContext(f.github, { owner: 'Azure', repo: 'azure-sdk-for-net' }, files);
  assert.equal(s.threads[0].comments.length, 2);
});

test('rejects stale state and missing thread pages', async () => {
  for (const pull of [{ draft: true }, { state: 'closed' }, { head: { sha: 'c'.repeat(40) } }, { base: { sha: 'c'.repeat(40) } }, { changed_files: 107 }]) {
    await assert.rejects(captureContext(fixture(1, { pull }).github, {}, files), /stale/i);
  }
  const f = fixture();
  f.github.graphql = async () => ({ repository: { pullRequest: { reviewThreads: { nodes: [], totalCount: 1, pageInfo: { hasNextPage: false } } } } });
  await assert.rejects(captureContext(f.github, {}, files), /count mismatch/i);
});

test('publication rechecks thread status and replies rather than trusting old decisions', async () => {
  const f = fixture();
  const s = await captureContext(f.github, { owner: 'Azure', repo: 'azure-sdk-for-net' }, files);
  await assertFresh(f.github, {}, s);
  f.threads[0].isResolved = true;
  await assert.rejects(assertFresh(f.github, {}, s), /thread state/i);
  f.threads[0].isResolved = false;
  f.threads[0].comments.nodes.push({ databaseId: 2, body: 'new reply', path: 'src/F.cs' });
  await assert.rejects(assertFresh(f.github, {}, s), /thread state/i);
});

test('publication detects new summary reviews even when no thread changed', async () => {
  const f = fixture(); const s = await captureContext(f.github, { owner: 'Azure', repo: 'azure-sdk-for-net' }, files);
  f.github.paginate = async () => [{ id: 7, body: 'New finding in an edited review.', state: 'COMMENTED', commit_id: files.head_sha }];
  await assert.rejects(assertFresh(f.github, {}, s), /review history/i);
});

test('thread mutation skips unused review refetch while publication still checks reviews', async () => {
  const f = fixture();
  let reviewReads = 0, unavailable = false;
  f.github.paginate = async () => {
    reviewReads++;
    if (unavailable) throw new Error('simulated review listing unavailable');
    return [];
  };
  const snapshot = await captureContext(f.github, { owner: 'Azure', repo: 'azure-sdk-for-net' }, files);
  assert.equal(reviewReads, 1);
  const receipts = [{ type: 'reply_to_pull_request_review_comment', provider: 'github', id: 1, metadata: { reply_id: 2 } }];
  f.threads[0].comments.nodes.push({ databaseId: 2, body: 'our reply', path: 'src/F.cs' });
  unavailable = true;
  await assertMutationFresh(f.github, {}, snapshot, [1], receipts);
  assert.equal(reviewReads, 1);
  f.threads[0].comments.nodes.push({ databaseId: 3, body: 'external', path: 'src/F.cs' });
  await assert.rejects(assertMutationFresh(f.github, {}, snapshot, [1], receipts), /changed after publication/i);
  f.threads[0].comments.nodes.pop();
  f.pull.base = { sha: 'c'.repeat(40) };
  await assert.rejects(assertMutationFresh(f.github, {}, snapshot, [1], receipts), /stale/i);
  f.pull.base = { sha: files.base_sha };
  await assert.rejects(assertFresh(f.github, {}, snapshot), /review listing unavailable/i);
});

test('late mutation rejects a moved base or external reply, allowing only exact applied reply IDs',async()=>{
  const f=fixture();
  const s=JSON.parse(JSON.stringify(await captureContext(f.github,{owner:'Azure',repo:'azure-sdk-for-net'},files)));
  const receipt=[{type:'reply_to_pull_request_review_comment',provider:'github',id:1,metadata:{reply_id:2}}];
  f.threads[0].comments.nodes.push({databaseId:2,body:'Our applied reply',path:'src/F.cs'});
  await assertMutationFresh(f.github,{},s,[1],receipt);
  f.threads[0].comments.nodes.push({databaseId:3,body:'External clarification',path:'src/F.cs'});
  await assert.rejects(assertMutationFresh(f.github,{},s,[1],receipt),/changed after publication/);
  f.threads[0].comments.nodes.pop();
  f.pull.base={sha:'c'.repeat(40)};
  await assert.rejects(assertMutationFresh(f.github,{},s,[1],receipt),/stale/);
});

test('late mutation rejects absent reply provenance and removed replies',async()=>{
  const f=fixture();const s=JSON.parse(JSON.stringify(await captureContext(f.github,{owner:'Azure',repo:'azure-sdk-for-net'},files)));
  await assert.rejects(assertMutationFresh(f.github,{},s,[1],[]),/Missing applied reply identity/);
  await assert.rejects(assertMutationFresh(f.github,{},s,[1],[{type:'reply_to_pull_request_review_comment',provider:'github',id:1,metadata:{reply_id:2}}]),/no longer visible/);
});

test('rejects duplicate IDs and nonadvancing cursors', async () => {
  const f = fixture(101);
  f.threads[100].id = f.threads[0].id;
  await assert.rejects(captureContext(f.github, {}, files), /duplicate/i);
  const g = fixture();
  const original = g.github.graphql;
  g.github.graphql = async (query, vars) => {
    const result = await original(query, vars);
    result.repository.pullRequest.reviewThreads.nodes = [];
    result.repository.pullRequest.reviewThreads.pageInfo = { hasNextPage: true, endCursor: '0' };
    return result;
  };
  await assert.rejects(captureContext(g.github, {}, files), /cursor/i);
});
