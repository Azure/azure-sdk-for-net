'use strict';

// Trusted GitHub adapter: capture paginated PR history at pinned commits and
// recheck mutable state before publication or thread mutation. PR text remains
// untrusted; this module never executes PR-derived code.
const CAPTURE_TIMEOUT_MS = 22 * 60 * 1000;
const QUERY = `query($owner:String!,$repo:String!,$number:Int!,$after:String){
  repository(owner:$owner,name:$repo){pullRequest(number:$number){
    reviewThreads(first:100,after:$after){totalCount pageInfo{hasNextPage endCursor} nodes{
      id isResolved isOutdated isCollapsed comments(first:100){pageInfo{hasNextPage endCursor} nodes{
        databaseId body path line originalLine startLine originalStartLine url createdAt updatedAt publishedAt author{login} pullRequestReview{submittedAt}
      }}
    }}
  }}
}`;
const COMMENTS = `query($id:ID!,$after:String){node(id:$id){... on PullRequestReviewThread{
  comments(first:100,after:$after){pageInfo{hasNextPage endCursor} nodes{databaseId body path line originalLine startLine originalStartLine url createdAt updatedAt publishedAt author{login} pullRequestReview{submittedAt}}}
}}}`;

async function captureReviewState(github, repo, files, { includeReviews = true } = {}) {
  const before = (await github.rest.pulls.get({ ...repo, pull_number: files.pull_number })).data;
  const assertCurrent = pull => {
    if (pull.state !== 'open' || pull.draft || pull.head?.sha !== files.head_sha || pull.base?.sha !== files.base_sha || pull.changed_files !== files.changed_files) {
      throw new Error('PR state, head, base or file count changed; refusing a stale review.');
    }
  };
  assertCurrent(before);
  const threads = [];
  const ids = new Set();
  const cursors = new Set();
  let after = null;
  let total;
  while (true) {
    const response = await github.graphql(QUERY, { ...repo, number: files.pull_number, after });
    const connection = response.repository?.pullRequest?.reviewThreads;
    if (!connection || !Array.isArray(connection.nodes) || !Number.isSafeInteger(connection.totalCount)) throw new Error('Incomplete thread listing.');
    if (total !== undefined && total !== connection.totalCount) throw new Error('Thread count changed during capture.');
    total = connection.totalCount;
    for (const thread of connection.nodes) {
      if (!thread || typeof thread.id !== 'string' || ids.has(thread.id) || typeof thread.isResolved !== 'boolean' || !Array.isArray(thread.comments?.nodes)) throw new Error('Invalid or duplicate thread.');
      ids.add(thread.id);
      const comments = [...thread.comments.nodes];
      let pageInfo = thread.comments.pageInfo;
      const commentCursors = new Set();
      while (pageInfo?.hasNextPage) {
        const cursor = pageInfo.endCursor;
        if (typeof cursor !== 'string' || !cursor || commentCursors.has(cursor)) throw new Error('Invalid thread comment cursor.');
        commentCursors.add(cursor);
        const next = (await github.graphql(COMMENTS, { id: thread.id, after: cursor })).node?.comments;
        if (!next || !Array.isArray(next.nodes)) throw new Error('Incomplete thread comment listing.');
        comments.push(...next.nodes);
        pageInfo = next.pageInfo;
      }
      if (!pageInfo || !comments.length || new Set(comments.map(c => c.databaseId)).size !== comments.length) throw new Error('Incomplete or duplicate thread comments.');
      threads.push({ id: thread.id, isResolved: thread.isResolved,
        ...(thread.isOutdated !== undefined ? { isOutdated: thread.isOutdated } : {}),
        ...(thread.isCollapsed !== undefined ? { isCollapsed: thread.isCollapsed } : {}), comments });
    }
    if (!connection.pageInfo) throw new Error('Missing thread pagination state.');
    if (!connection.pageInfo.hasNextPage) break;
    const cursor = connection.pageInfo.endCursor;
    if (typeof cursor !== 'string' || !cursor || cursors.has(cursor)) throw new Error('Invalid thread cursor.');
    cursors.add(cursor);
    after = cursor;
  }
  if (threads.length !== total) throw new Error('Incomplete thread listing: count mismatch.');
  const reviews = includeReviews ? await github.paginate(github.rest.pulls.listReviews, { ...repo, pull_number: files.pull_number, per_page: 100 }) : [];
  assertCurrent((await github.rest.pulls.get({ ...repo, pull_number: files.pull_number })).data);
  return { ...files, head_repo: before.head.repo?.full_name || `${repo.owner}/${repo.repo}`, base_repo: before.base.repo?.full_name || `${repo.owner}/${repo.repo}`, threads, reviews: reviews.map(r => ({ id: r.id, body: r.body, state: r.state, commit_id: r.commit_id, author: r.user?.login ?? null, submittedAt: r.submitted_at ?? null, url: r.html_url ?? null, authorAssociation: r.author_association ?? null })) };
}

async function captureContext(github, repo, files, { timeoutMs = CAPTURE_TIMEOUT_MS } = {}) {
  const snapshot = await captureReviewState(github, repo, files);
  // GitHub's PR diff is merge-base-to-head; the base tip remains the freshness anchor.
  const comparison = await github.request('GET /repos/{owner}/{repo}/compare/{basehead}', {
    ...repo, basehead: `${snapshot.base_sha}...${snapshot.head_sha}`, per_page: 1,
  });
  const diffBase = comparison.data?.merge_base_commit?.sha;
  if (!/^[a-f0-9]{40}$/i.test(diffBase || '') || comparison.data?.base_commit?.sha !== snapshot.base_sha) {
    throw new Error('Cannot establish the captured PR diff base.');
  }
  snapshot.diff_base_sha = diffBase;
  // Baselines are immutable at the captured SHAs; fetch and validate them once.
  // Only filename metadata is needed by the PowerShell capture, not large patches or histories.
  const { runPowerShell } = require('./ReviewDelivery.cjs');
  const input = { repo, snapshot: { head_sha: snapshot.head_sha, base_sha: snapshot.base_sha,
    diff_base_sha: snapshot.diff_base_sha, head_repo: snapshot.head_repo,
    files: snapshot.files.map(({ filename, previous_filename, status }) => ({ filename, previous_filename, status })) } };
  if (!Number.isSafeInteger(timeoutMs) || timeoutMs <= 0) throw new Error('Invalid baseline capture deadline.');
  let result;
  try {
    result = await runPowerShell('ReviewBaselines.ps1', JSON.stringify(input), {
      scriptArgs: ['-Capture'], timeoutMs, timeoutReason: 'Baseline capture timed out.', label: 'Baseline capture', maxOutputBytes: 16 * 1024 * 1024,
    });
  } catch (error) { throw new Error(`Cannot capture baselines: ${error.message}`); }
  const inventory = JSON.parse(result.stdout);
  if (!Array.isArray(inventory)) throw new Error('Invalid baseline comparison output.');
  snapshot.baseline_suppressions = inventory;
  return snapshot;
}

async function assertFresh(github, repo, snapshot) {
  const pull = (await github.rest.pulls.get({ ...repo, pull_number: snapshot.pull_number })).data;
  if (pull.state !== 'open' || pull.draft || pull.head?.sha !== snapshot.head_sha || pull.base?.sha !== snapshot.base_sha || pull.changed_files !== snapshot.changed_files) {
    throw new Error('PR state, head or base changed before publication.');
  }
  // Reread thread state/history too. Reuse capture rather than trusting the
  // agent's assertion that its old thread-resolution decisions are still current.
  const current = await captureReviewState(github, repo, snapshot);
  if (JSON.stringify(current.threads) !== JSON.stringify(snapshot.threads)) throw new Error('Review thread state or history changed before publication.');
  if (JSON.stringify(current.reviews) !== JSON.stringify(snapshot.reviews)) throw new Error('Review history changed before publication.');
  if (current.head_repo !== snapshot.head_repo || current.base_repo !== snapshot.base_repo) throw new Error('Source repository identity changed before publication.');
}

async function assertMutationFresh(github, repo, snapshot, rootIds, receipts) {
  // Mutation freshness compares the targeted threads, not the review list.
  const current=await captureReviewState(github,repo,snapshot,{includeReviews:false});
  const byId=new Map(current.threads.map(thread=>[thread.id,thread]));
  for(const root of rootIds) {
    const expected=snapshot.threads.find(thread=>thread.comments[0].databaseId===root);
    const actual=expected && byId.get(expected.id);
    const ownIds=new Set(receipts.filter(item=>item.type==='reply_to_pull_request_review_comment' && item.provider==='github' && item.id===root && Number.isSafeInteger(item.metadata?.reply_id) && item.metadata.reply_id>0).map(item=>item.metadata.reply_id));
    if(!ownIds.size)throw new Error(`Missing applied reply identity for thread root ${root}.`);
    if(!actual)throw new Error(`Captured thread ${root} is no longer available.`);
    if(!actual.comments.some(comment=>ownIds.has(comment.databaseId)))throw new Error(`Applied reply for ${root} is no longer visible.`);
    const withoutOwnReplies={...actual,comments:actual.comments.filter(comment=>!ownIds.has(comment.databaseId))};
    if(JSON.stringify(withoutOwnReplies)!==JSON.stringify(expected))throw new Error(`Thread ${root} changed after publication; refusing stale mutation.`);
  }
}

async function exportContext(snapshot, directory, { timeoutMs = CAPTURE_TIMEOUT_MS } = {}) {
  const fs = require('node:fs'); const path = require('node:path');
  const { MAX_BATCH_BYTES, snapshotDigest, runPowerShell } = require('./ReviewDelivery.cjs');
  if (!Number.isSafeInteger(timeoutMs) || timeoutMs <= 0) throw new Error('Invalid delivery capture deadline.');
  if (!directory) throw new Error('Invalid review context directory.');
  const marker = '__REVIEW_BASENAME__';
  const pathPrefix = path.join(directory, marker).slice(0, -marker.length);
  const normalizedDirectory = path.normalize(directory);
  const result = await runPowerShell('Export-ReviewContext.ps1', JSON.stringify({ snapshot, maxBatchBytes: MAX_BATCH_BYTES, directory: normalizedDirectory, pathPrefix }), {
    timeoutMs, timeoutReason: 'Delivery index capture timed out.', label: 'Delivery index capture',
    maxOutputBytes: Math.max(16 * 1024 * 1024, (snapshot.files.length + snapshot.threads.length) * 256 + 1024 * 1024),
  });
  let delivery;
  try { delivery = JSON.parse(result.stdout); } catch { throw new Error('Invalid captured delivery index.'); }
  if (!delivery || delivery.snapshot !== snapshotDigest(snapshot) || !delivery.items || typeof delivery.items !== 'object' || Array.isArray(delivery.items)) throw new Error('Invalid captured delivery index.');
  const expectedItems = [...snapshot.files.map((_, i) => [`file:${i}`, 'patch']), ...snapshot.threads.map((_, i) => [`thread:${i}`, 'history'])];
  if (Object.keys(delivery.items).length !== expectedItems.length) throw new Error('Invalid captured delivery assignments.');
  for (const [id, kind] of expectedItems) {
    const inputs = delivery.items[id];
    if (!Object.hasOwn(delivery.items, id) || !Array.isArray(inputs) || inputs.length > 1 || (kind === 'history' && inputs.length !== 1) ||
        inputs.some(input => !input || input.kind !== kind || typeof input.key !== 'string' || !new RegExp(`^${kind}:[a-f0-9]{64}$`).test(input.key))) throw new Error('Invalid captured delivery assignments.');
  }
  let capturedSnapshot, capturedIndex, context;
  try {
    capturedSnapshot = JSON.parse(fs.readFileSync(path.join(directory, 'snapshot.json'), 'utf8'));
    capturedIndex = JSON.parse(fs.readFileSync(path.join(directory, 'delivery-index.json'), 'utf8'));
    context = JSON.parse(fs.readFileSync(path.join(directory, 'index.json'), 'utf8'));
  } catch { throw new Error('Missing or invalid exported review context.'); }
  if (snapshotDigest(capturedSnapshot) !== delivery.snapshot || JSON.stringify(capturedIndex) !== JSON.stringify(delivery) ||
      !context || !Array.isArray(context.files) || context.files.length !== snapshot.files.length ||
      !Array.isArray(context.threads) || context.threads.length !== snapshot.threads.length ||
      !Array.isArray(context.reviews) || context.reviews.length !== (snapshot.reviews || []).length) throw new Error('Exported review context does not match the captured snapshot.');
  for (const [index, review] of (snapshot.reviews || []).entries()) {
    const expectedPath = path.join(directory, `review-${index}.json`), exported = context.reviews[index];
    let history;
    try { history = JSON.parse(fs.readFileSync(expectedPath, 'utf8')); } catch { throw new Error('Missing or invalid exported review history.'); }
    if (!exported || exported.history_path !== expectedPath || exported.id !== review.id || exported.state !== review.state ||
        JSON.stringify(history) !== JSON.stringify(review)) throw new Error('Exported review history does not match the captured snapshot.');
  }
}

module.exports = { captureContext, assertFresh, assertMutationFresh, exportContext };
