'use strict';
const assert = require('node:assert/strict');
const { test } = require('node:test');
const { captureContext, assertFresh, assertMutationFresh } = require('./ReviewSnapshot.cjs');
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

test('captures all thread pages and previous reviews', async () => {
  const f = fixture(106);
  const s = await captureContext(f.github, { owner: 'Azure', repo: 'azure-sdk-for-net' }, files);
  assert.equal(s.threads.length, 106);
  assert.deepEqual(f.calls.map(c => c.after), [null, '100']);
  assert.equal(s.reviews[0].body, 'prior review');
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
