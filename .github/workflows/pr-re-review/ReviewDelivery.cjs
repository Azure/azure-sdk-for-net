'use strict';

// The MCP backend records delivered pages in a directory mounted read-only in
// the worker sandbox. A fresh nonce makes receipts specific to one invocation.
const crypto = require('node:crypto');
const MAX_BATCH_BYTES = 48000;
const digest = value => crypto.createHash('sha256').update(value).digest('hex');
const snapshotDigest = snapshot => digest(JSON.stringify(snapshot));

function requiredInputs(snapshot, item) {
  if (item.thread) {
    const content = JSON.stringify(item.thread, null, 2);
    return [{ key: `history:${digest(content)}`, kind: 'history', content }];
  }
  const file = item.file;
  if (!file || typeof file.filename !== 'string') throw new Error('Invalid delivery assignment.');
  const result = [];
  if (file.patch !== undefined) {
    if (typeof file.patch !== 'string') throw new Error('Invalid captured patch.');
    if (Buffer.byteLength(file.patch) > MAX_BATCH_BYTES) result.push({ key: `patch:${digest(file.patch)}`, kind: 'patch', content: file.patch });
    // Otherwise the exact patch is embedded in the prompt by the controller.
  }
  const source = (ref, name) => {
    if (typeof name !== 'string' || !name) throw new Error('Missing source path for delivery.');
    result.push({ key: `source:${ref}:${name}`, kind: 'source', ref, path: name });
  };
  if (file.status === 'removed') source(snapshot.base_sha, file.filename);
  else if (file.status === 'renamed') {
    source(snapshot.base_sha, file.previous_filename);
    source(snapshot.head_sha, file.filename);
  } else if (file.patch === undefined) {
    if (file.status === 'added') source(snapshot.head_sha, file.filename);
    else if (file.status === 'modified') {
      source(snapshot.base_sha, file.filename);
      source(snapshot.head_sha, file.filename);
    } else throw new Error('Unsupported file status for omitted patch delivery.');
  }
  return result;
}

function verifyDelivery(snapshot, batch, results, nonce, receipts) {
  if (!/^[a-f0-9]{32}$/.test(nonce) || !Array.isArray(receipts)) throw new Error('Invalid delivery evidence.');
  const completed = new Map(results.filter(result => result.status === 'complete').map(result => [result.id, result]));
  const hash = snapshotDigest(snapshot);
  for (const item of batch.filter(item => completed.has(item.id))) {
    const requiredList = requiredInputs(snapshot, item);
    const tokens = completed.get(item.id).delivery_tokens;
    if (requiredList.length && (!Array.isArray(tokens) || tokens.length > 8192 || tokens.some(token => typeof token !== 'string' || !/^[a-f0-9]{64}$/.test(token)))) throw new Error(`Missing delivery acknowledgements for ${item.id}.`);
    const proofs = new Set((tokens || []).map(digest));
    for (const required of requiredList) {
      const records = receipts.filter(row => row && row.snapshot === hash && row.nonce === nonce && row.item === item.id && row.key === required.key && proofs.has(row.proof_hash));
      if (!records.length) throw new Error(`Missing delivery evidence for ${item.id}.`);
      const total = records[0].total;
      if (!Number.isSafeInteger(total) || total < 0 || (required.content !== undefined && total !== required.content.length) ||
          records.some(row => row.total !== total || !Number.isSafeInteger(row.start) || !Number.isSafeInteger(row.end) || row.start < 0 || row.end < row.start || row.end > total)) throw new Error(`Invalid delivery ranges for ${item.id}.`);
      records.sort((a, b) => a.start - b.start || b.end - a.end);
      let end = 0;
      for (const row of records) {
        if (row.start > end) break;
        end = Math.max(end, row.end);
      }
      if (end !== total) throw new Error(`Incomplete delivery evidence for ${item.id}.`);
    }
  }
}
module.exports = { snapshotDigest, requiredInputs, verifyDelivery };
