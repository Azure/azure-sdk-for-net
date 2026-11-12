'use strict';
// Frozen original changed-file policy oracle, before the PowerShell port.
            async function captureChangedFiles(github, { owner, repo, pullNumber, headSha }) {
              if (!owner || !repo || !Number.isSafeInteger(pullNumber) || pullNumber <= 0 ||
                  !/^[0-9a-f]{40}$/i.test(headSha)) {
                throw new Error('Invalid pull request identity.');
              }
              const request = { owner, repo, pull_number: pullNumber };
              const readPull = async () => (await github.rest.pulls.get(request)).data;
              const first = await readPull();
              const baseSha = first.base?.sha;
              if (!/^[0-9a-f]{40}$/i.test(baseSha || '')) throw new Error('Invalid pull request base.');
              const assertCurrent = (pull) => {
                if (pull.state !== 'open' || pull.draft || pull.head?.sha !== headSha || pull.base?.sha !== baseSha) {
                  throw new Error('Pull request state, head or base changed; refusing a stale review.');
                }
                if (!Number.isSafeInteger(pull.changed_files) || pull.changed_files < 0 || pull.changed_files > 3000) {
                  throw new Error('Invalid changed-file count or GitHub 3000-file endpoint limit exceeded.');
                }
              };

              assertCurrent(first);
              const files = [];
              const filenames = new Set();
              for (let page = 1; ; page++) {
                const result = await github.rest.pulls.listFiles({ ...request, per_page: 100, page });
                if (!Array.isArray(result.data) || result.data.length > 100) throw new Error('Invalid changed-file page.');
                for (const file of result.data) {
                  if (typeof file.filename !== 'string' || !file.filename || filenames.has(file.filename)) {
                    throw new Error('Invalid or duplicate changed filename.');
                  }
                  filenames.add(file.filename);
                  // Do not infer an empty patch when GitHub omits it.
                  const entry = { filename: file.filename, status: file.status };
                  if (file.previous_filename !== undefined) entry.previous_filename = file.previous_filename;
                  if (file.patch !== undefined) entry.patch = file.patch;
                  files.push(entry);
                }
                if (files.length > first.changed_files) throw new Error('Changed-file count exceeds PR metadata.');
                if (result.data.length < 100 || files.length === 3000) break;
              }
              if (files.length !== first.changed_files) throw new Error('Incomplete changed-file listing: count differs from PR metadata.');
              const last = await readPull();
              assertCurrent(last);
              if (last.changed_files !== first.changed_files) throw new Error('Changed-file count changed during capture.');
              return { pull_number: pullNumber, head_sha: headSha, base_sha: baseSha, changed_files: files.length, files };
            }
module.exports={captureChangedFiles};
