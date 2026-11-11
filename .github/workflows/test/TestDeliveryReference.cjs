'use strict';
// Original JavaScript behavior retained solely as an independent test oracle
// for the PowerShell delivery selector and fake review worker.
const crypto = require('node:crypto');
const digest = value => crypto.createHash('sha256').update(value).digest('hex');
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
    if (Buffer.byteLength(file.patch) > 48000) result.push({ key: `patch:${digest(file.patch)}`, kind: 'patch', content: file.patch });
  }
  if (file.status === 'renamed' && (typeof file.previous_filename !== 'string' || !file.previous_filename)) throw new Error('Missing source path for delivery.');
  if (file.patch === undefined && !['added', 'modified', 'removed', 'renamed'].includes(file.status)) throw new Error('Unsupported file status for omitted patch delivery.');
  return result;
}
module.exports = { requiredInputs };
