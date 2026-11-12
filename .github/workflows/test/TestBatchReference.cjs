'use strict';
// Original selector retained as an independent test oracle.
function nextBatch(work) {
  const batch = []; let bytes = 0;
  for (const item of work) {
    const size = Buffer.byteLength(JSON.stringify(item));
    if (batch.length && (Boolean(item.thread) !== Boolean(batch[0].thread) || batch.length === 8 || bytes + size > 48000)) break;
    batch.push(item); bytes += size;
  }
  return batch;
}
module.exports = { nextBatch };
