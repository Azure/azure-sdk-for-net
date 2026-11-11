'use strict';

// Trusted GitHub adapter: fetch and verify immutable ApiCompat baseline blobs,
// then invoke the PowerShell comparator. GitHub's PR patch may be absent or truncated.
const crypto = require('node:crypto');
const path = require('node:path');
const { spawnSync } = require('node:child_process');
const isBaseline = name => typeof name === 'string' && /^eng\/apicompatbaselines\/[^/]+\.xml$/.test(name);

async function captureBaselines(github, repo, snapshot) {
  const read = async (name, ref, ownerRepo) => {
    let response;
    let sourceRepo = ownerRepo;
    try {
      response = await github.rest.repos.getContent({ ...sourceRepo, path: name, ref });
    } catch (error) {
      if (ref !== snapshot.head_sha || ![403, 404].includes(error.status) || (ownerRepo.owner === repo.owner && ownerRepo.repo === repo.repo)) throw error;
      sourceRepo = repo;
      response = await github.rest.repos.getContent({ ...sourceRepo, path: name, ref });
    }
    const metadata = response.data;
    if (!metadata || metadata.type !== 'file' || !Number.isSafeInteger(metadata.size) || metadata.size < 0 ||
        metadata.size > 4 * 1024 * 1024 || !/^[a-f0-9]{40}$/i.test(metadata.sha || '')) throw new Error('Unreadable baseline content.');
    // Contents API omits encoded content above 1 MiB. Fetch that exact Git blob
    // rather than mistaking a supported large file for an unavailable input.
    const data = metadata.encoding === 'none' ? (await github.rest.git.getBlob({ ...sourceRepo, file_sha: metadata.sha })).data : metadata;
    if (!data || data.encoding !== 'base64' || typeof data.content !== 'string' || data.size !== metadata.size || data.sha !== metadata.sha) throw new Error('Unreadable baseline blob.');
    const encoded = data.content.replace(/\s/g, '');
    if (!/^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$/.test(encoded)) throw new Error('Invalid baseline encoding.');
    const bytes = Buffer.from(encoded, 'base64');
    const digest = crypto.createHash('sha1').update(`blob ${bytes.length}\0`).update(bytes).digest('hex');
    if (bytes.length !== data.size || digest !== data.sha.toLowerCase()) throw new Error('Incomplete or corrupt baseline content.');
    return new TextDecoder('utf-8', { fatal: true }).decode(bytes);
  };
  const pair = [];
  for (const file of snapshot.files) {
    if (!isBaseline(file.filename) && !isBaseline(file.previous_filename)) continue;
    if (!['added', 'modified', 'removed', 'renamed'].includes(file.status)) throw new Error('Unknown baseline file status.');
    if (!isBaseline(file.filename) || file.status === 'removed') continue;
    const names = (snapshot.head_repo || `${repo.owner}/${repo.repo}`).split('/');
    if (names.length !== 2 || !names.every(name => /^[a-zA-Z0-9_.-]+$/.test(name))) throw new Error('Invalid baseline head repository.');
    if (file.status === 'modified' && !/^[a-f0-9]{40}$/i.test(snapshot.diff_base_sha || '')) throw new Error('Missing captured baseline diff base.');
    const base = file.status === 'modified' ? await read(file.filename, snapshot.diff_base_sha, repo) : null;
    const head = await read(file.filename, snapshot.head_sha, { owner: names[0], repo: names[1] });
    pair.push({ path: file.filename, base, head });
  }
  if (!pair.length) return [];
  const result = spawnSync('pwsh', ['-NoLogo', '-NoProfile', '-NonInteractive', '-File', path.join(__dirname, 'ReviewBaselines.ps1')], { input: JSON.stringify(pair), encoding: 'utf8', maxBuffer: 16 * 1024 * 1024 });
  if (result.error || result.status !== 0) throw new Error(`Cannot compare captured baselines: ${result.error?.message || result.stderr}`);
  const parsed = JSON.parse(result.stdout);
  if (!Array.isArray(parsed)) throw new Error('Invalid baseline comparison output.');
  return parsed;
}
module.exports = { captureBaselines, isBaseline };
