'use strict';

// Host-side MCP script: read-only GETs to the workflow's trusted GitHub API origin. It never
// executes PR code or exposes its token to the agent. Raw responses avoid the
// base64 decoding that previously required unrestricted agent shell commands.
async function readSource(inputs, snapshot, repository, token, fetcher = fetch, apiUrl = 'https://api.github.com', cache) {
  const { path, ref = snapshot.head_sha, offset = 0, limit = 4000, search } = inputs;
  if (typeof path !== 'string' || !path || path.startsWith('/') || path.split('/').includes('..') || /[\x00-\x1f]/.test(path) || path.length > 1024) throw new Error('Invalid repository-relative source path.');
  const capturedRef = [snapshot.head_sha, snapshot.base_sha].includes(ref) && /^[a-f0-9]{40}$/i.test(ref);
  const packageName = path.startsWith('sdk/') ? path.split('/')[2] : '';
  const baselineRef = typeof ref === 'string' && ref.length <= 200 && /^(Azure|System|Microsoft)\.[a-zA-Z0-9_.]+$/.test(packageName || '') &&
    ref.startsWith(`${packageName}_`) && /^\d+\.\d+\.\d+$/.test(ref.slice(packageName.length + 1));
  if (!capturedRef && !baselineRef) throw new Error('Source ref is outside the captured head/base or package GA baseline candidates.');
  if (!Number.isSafeInteger(offset) || offset < 0 || !Number.isSafeInteger(limit) || limit < 1 || limit > 4000 || (search !== undefined && (typeof search !== 'string' || search.length > 200))) throw new Error('Invalid bounded source page.');
  const sourceRepo = baselineRef || ref === snapshot.base_sha ? snapshot.base_repo || repository : snapshot.head_repo || repository;
  if (!/^[a-zA-Z0-9_-]+\/[a-zA-Z0-9_.-]+$/.test(sourceRepo) || ['.', '..'].includes(sourceRepo.split('/')[1]) || (snapshot.base_repo && snapshot.base_repo !== repository)) throw new Error('Invalid captured repository identity.');
  const api = new URL(apiUrl);
  if (api.protocol !== 'https:' || api.username || api.password || api.search || api.hash) throw new Error('Invalid trusted GitHub API endpoint.');
  const cacheKey = JSON.stringify([api.href, sourceRepo, ref, path]);
  let content;
  if (capturedRef && cache?.has(cacheKey)) {
    content = cache.get(cacheKey);
    cache.delete(cacheKey); cache.set(cacheKey, content); // bounded LRU
  } else {
    const url = `${api.href.replace(/\/$/, '')}/repos/${sourceRepo}/contents/${path.split('/').map(encodeURIComponent).join('/')}?ref=${ref}`;
    const options = { method: 'GET', redirect: 'error', signal: AbortSignal.timeout(30000), headers: { Accept: 'application/vnd.github.raw+json', Authorization: `Bearer ${token}`, 'X-GitHub-Api-Version': '2022-11-28' } };
    let response = await fetcher(url, options);
    // Installation tokens may not read a public fork directly. The triggering
    // repository's shared PR commit objects can still expose the exact same SHA.
    if (!response.ok && [403, 404].includes(response.status) && sourceRepo !== repository)
      response = await fetcher(url.replace(`/repos/${sourceRepo}/`, `/repos/${repository}/`), options);
    if (!response.ok) throw new Error(`Captured source read failed with HTTP ${response.status}.`);
    if (response.body?.getReader) {
      const reader = response.body.getReader(); const chunks = []; let bytes = 0;
      while (true) {
        const { value, done } = await reader.read();
        if (done) break;
        bytes += value.length;
        if (bytes > 4 * 1024 * 1024) { await reader.cancel(); throw new Error('Source response exceeds the read-only helper limit.'); }
        chunks.push(Buffer.from(value));
      }
      try { content = new TextDecoder('utf-8', { fatal: true }).decode(Buffer.concat(chunks)); }
      catch { throw new Error('Source is not valid UTF-8.'); }
    } else content = await response.text();
    if (content.includes('\0')) throw new Error('Binary source cannot be delivered as text.');
    if (Buffer.byteLength(content) > 4 * 1024 * 1024) throw new Error('Source response exceeds the read-only helper limit.');
    if (capturedRef && cache) {
      cache.set(cacheKey, content);
      while (cache.size > 4) cache.delete(cache.keys().next().value);
    }
  }
  let start = offset;
  if (search !== undefined) {
    const match = content.indexOf(search, offset);
    if (match < 0) return { path, ref, reference_kind: baselineRef ? 'ga-baseline-candidate' : 'captured-source', found: false, total_characters: content.length };
    start = Math.max(0, match - Math.min(500, Math.floor(limit / 4)));
  }
  const end = Math.min(content.length, start + limit);
  return { path, ref, reference_kind: baselineRef ? 'ga-baseline-candidate' : 'captured-source', offset: start, total_characters: content.length, next_offset: end < content.length ? end : null, content: content.slice(start, end) };
}
module.exports = { readSource };
