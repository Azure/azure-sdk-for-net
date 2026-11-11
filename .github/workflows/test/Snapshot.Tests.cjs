'use strict';
const assert = require('node:assert/strict');
const { test } = require('node:test');
const crypto = require('node:crypto');
const { captureContext, assertFresh, assertMutationFresh, exportContext } = require('../pr-re-review/ReviewSnapshot.cjs');
const files = { pull_number: 64192, head_sha: 'a'.repeat(40), base_sha: 'b'.repeat(40), changed_files: 106, files: [] };
const thread = i => ({ id: `thread-${i}`, isResolved: false, comments: { nodes: [{ databaseId: i + 1, body: 'finding', path: 'src/F.cs' }], pageInfo: { hasNextPage: false, endCursor: null } } });
function fixture(count = 1, extra = {}) {
  const threads = Array.from({ length: count }, (_, i) => thread(i));
  const calls = [];
  const pull = { state: 'open', draft: false, head: { sha: files.head_sha }, base: { sha: files.base_sha }, changed_files: 106 };
  const github = {
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

function fixtureWithBaseline() {
  const f = fixture();
  const name = 'eng/apicompatbaselines/Azure.Example.xml';
  const manifest = { ...files, files: [{ filename: name, status: 'modified' }] };
  const repo = { owner: 'Azure', repo: 'azure-sdk-for-net' };
  f.pull.head.repo = { full_name: 'Azure/azure-sdk-for-net' };
  f.pull.base.repo = { full_name: 'Azure/azure-sdk-for-net' };
  const state = { reads: 0, unavailable: false, corrupt: false };
  f.github.rest.repos = { getContent: async ({ ref }) => {
    state.reads++;
    if (state.unavailable) throw new Error('simulated unavailable immutable blob');
    const content = ref === files.base_sha ? '<Suppressions />' : '<Suppressions><Suppression><DiagnosticId>CP1</DiagnosticId><Target>T:Model</Target></Suppression></Suppressions>';
    const bytes = Buffer.from(content);
    return { data: { type: 'file', encoding: 'base64', content: bytes.toString('base64'), size: bytes.length,
      sha: state.corrupt ? '0'.repeat(40) : crypto.createHash('sha1').update(`blob ${bytes.length}\0`).update(bytes).digest('hex') } };
  } };
  return { ...f, manifest, repo, state };
}

test('captured baseline is checked once and not refetched for freshness', async () => {
  const f = fixtureWithBaseline();
  const snapshot = await captureContext(f.github, f.repo, f.manifest);
  assert.equal(snapshot.baseline_suppressions.length, 1);
  assert.equal(f.state.reads, 2);
  f.state.unavailable = true;
  await assertFresh(f.github, f.repo, snapshot);
  f.threads[0].comments.nodes.push({ databaseId: 2, body: 'our reply', path: 'src/F.cs' });
  await assertMutationFresh(f.github, f.repo, snapshot, [1], [{ type: 'reply_to_pull_request_review_comment', provider: 'github', id: 1, metadata: { reply_id: 2 } }]);
  assert.equal(f.state.reads, 2);
});

test('initial missing baseline data still fails closed', async () => {
  const f = fixtureWithBaseline();
  f.state.unavailable = true;
  await assert.rejects(captureContext(f.github, f.repo, f.manifest), /unavailable immutable blob/);
});

test('initial corrupt baseline data still fails closed', async () => {
  const f = fixtureWithBaseline();
  f.state.corrupt = true;
  await assert.rejects(captureContext(f.github, f.repo, f.manifest), /corrupt/i);
});

test('freshness still rejects changed identity, thread and review state without refetching baselines', async () => {
  const f = fixtureWithBaseline();
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

test('freshness detects captured thread and comment metadata changes', async () => {
  const f = fixtureWithBaseline();
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

test('thread mutation still rejects external replies without refetching baselines', async () => {
  const f = fixtureWithBaseline();
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
  exportContext(snapshot, directory);
  const index = JSON.parse(fs.readFileSync(path.join(directory, 'index.json'), 'utf8'));
  assert.equal(index.threads.length, 1);
  assert.equal(index.reviews.length, 1);
  assert.deepEqual(JSON.parse(fs.readFileSync(index.threads[0].history_path, 'utf8')), snapshot.threads[0]);
  assert.deepEqual(JSON.parse(fs.readFileSync(index.reviews[0].history_path, 'utf8')), snapshot.reviews[0]);
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
  const s = await captureContext(f.github, {}, files);
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
  const s = await captureContext(f.github, {}, files);
  await assertFresh(f.github, {}, s);
  f.threads[0].isResolved = true;
  await assert.rejects(assertFresh(f.github, {}, s), /thread state/i);
  f.threads[0].isResolved = false;
  f.threads[0].comments.nodes.push({ databaseId: 2, body: 'new reply', path: 'src/F.cs' });
  await assert.rejects(assertFresh(f.github, {}, s), /thread state/i);
});

test('publication detects new summary reviews even when no thread changed', async () => {
  const f = fixture(); const s = await captureContext(f.github, {}, files);
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
  const snapshot = await captureContext(f.github, {}, files);
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
  const s=JSON.parse(JSON.stringify(await captureContext(f.github,{},files)));
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
  const f=fixture();const s=JSON.parse(JSON.stringify(await captureContext(f.github,{},files)));
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
