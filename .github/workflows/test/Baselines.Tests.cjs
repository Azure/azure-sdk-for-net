'use strict';

const assert = require('node:assert/strict');
const { test } = require('node:test');
const crypto = require('node:crypto');
const { captureBaselines } = require('../pr-re-review/ReviewBaselines.cjs');

const path = 'eng/apicompatbaselines/Azure.ResourceManager.Compute.Recommender.xml';
const entry = (id, target) => `<Suppression><DiagnosticId>${id}</DiagnosticId><Target>${target}</Target></Suppression>`;
const xml = body => `<?xml version="1.0"?><Suppressions>${body}</Suppressions>`;
const fileResponse = content => {
  const bytes = Buffer.from(content);
  return { data: { type: 'file', encoding: 'base64', content: bytes.toString('base64'), size: bytes.length,
    sha: crypto.createHash('sha1').update(`blob ${bytes.length}\0`).update(bytes).digest('hex') } };
};
const run = (files, contents) => captureBaselines({ rest: { repos: { getContent: async ({ path, ref }) => {
  const key = `${ref}:${path}`;
  if (!Object.hasOwn(contents, key)) throw new Error(`Missing ${key}`);
  return fileResponse(contents[key]);
} } } }, { owner: 'Azure', repo: 'azure-sdk-for-net' }, { files, base_sha: 'base', head_sha: 'head', head_repo: 'Azure/azure-sdk-for-net' });

test('captures all new suppressions in a #64595-style added baseline', async () => {
  const added = xml('<!-- Intentional preview rename. -->' + entry('CP0001', 'T:DiagnosticData') + entry('CP0002', 'M:Factory'));
  const result = await run([{ filename: path, status: 'added' }], { [`head:${path}`]: added });
  assert.deepEqual(result.map(x => x.fields.Target), ['T:DiagnosticData', 'M:Factory']);
  assert.equal(result[0].nearby_comment, 'Intentional preview rename.');
});

test('compares complete entries, preserving distinct targets and duplicate additions', async () => {
  const one = entry('CP0001', 'T:One');
  const two = entry('CP0001', 'T:Two');
  const result = await run([{ filename: path, status: 'modified' }], { [`base:${path}`]: xml(one), [`head:${path}`]: xml(two + one + two) });
  assert.deepEqual(result.map(x => x.fields.Target), ['T:Two', 'T:Two']);
});

test('does not attribute an old comment to an unrelated appended entry', async () => {
  const one = entry('CP0001', 'T:One'), two = entry('CP0002', 'T:Two');
  const result = await run([{ filename: path, status: 'modified' }], { [`base:${path}`]: xml('<!-- Old rationale -->' + one), [`head:${path}`]: xml('<!-- Old rationale -->' + one + two) });
  assert.equal(result[0].nearby_comment, null);
});

test('loads large contents API objects via the verified Git blob', async () => {
  const content = xml(' '.repeat(1024 * 1024) + entry('CP0001', 'T:One'));
  const blob = fileResponse(content).data;
  const github = { rest: { repos: { getContent: async () => ({ data: { ...blob, encoding: 'none', content: '' } }) }, git: { getBlob: async () => ({ data: blob }) } } };
  const result = await captureBaselines(github, { owner: 'Azure', repo: 'azure-sdk-for-net' }, { files: [{ filename: path, status: 'added' }], base_sha: 'base', head_sha: 'head', head_repo: 'Azure/azure-sdk-for-net' });
  assert.equal(result[0].fields.Target, 'T:One');
});

test('renames into another package surface entries even when the source had them', async () => {
  const previous = 'eng/apicompatbaselines/Azure.Old.xml';
  const content = xml(entry('CP0001', 'T:One'));
  const result = await run([{ filename: path, previous_filename: previous, status: 'renamed' }], { [`head:${path}`]: content });
  assert.equal(result.length, 1);
  assert.equal(result[0].path, path);
  assert.deepEqual(await run([{ filename: path, status: 'removed' }], {}), []);
});

test('preserves empty results, Unicode values and case-sensitive suppression fields', async () => {
  assert.deepEqual(await run([{ filename: path, status: 'added' }], { [`head:${path}`]: xml('') }), []);
  const content = xml(entry('CP0001', 'T:𝄞界') + '<Suppression><DiagnosticId>CP0002</DiagnosticId><Target>T:Two</Target><target>different</target></Suppression>');
  const result = await run([{ filename: path, status: 'added' }], { [`head:${path}`]: content });
  assert.equal(result[0].fields.Target, 'T:𝄞界');
  assert.deepEqual(result[1].fields, { DiagnosticId: 'CP0002', Target: 'T:Two', target: 'different' });
});

test('preserves XML namespace and comment handling from the original comparator', async () => {
  const content = xml('<!-- note --><?ignored x?><Suppression xmlns:ext="urn:test"><DiagnosticId>CP0001</DiagnosticId><Target>T:One</Target><ext:Extra>value</ext:Extra></Suppression>');
  const result = await run([{ filename: path, status: 'added' }], { [`head:${path}`]: content });
  assert.equal(result[0].nearby_comment, 'note');
  assert.equal(result[0].fields['{urn:test}Extra'], 'value');
  await assert.rejects(run([{ filename: path, status: 'added' }], { [`head:${path}`]: xml('<!-- <!DOCTYPE ignored> -->') }), /baseline/i);
});

test('does not confuse XML fields with PowerShell DOM properties', async () => {
  const content = xml('<Suppression><NodeType>Comment</NodeType><Value>ignored</Value><Name>x</Name><Attributes>y</Attributes><ChildNodes>z</ChildNodes><DiagnosticId>CP0001</DiagnosticId><Target>T:One</Target></Suppression>');
  const result = await run([{ filename: path, status: 'added' }], { [`head:${path}`]: content });
  assert.equal(result.length, 1);
  assert.equal(result[0].fields.NodeType, 'Comment');
  assert.equal(result[0].fields.Target, 'T:One');
});

test('rejects invalid suppression structure and external XML entities', async () => {
  for (const content of [
    xml('<Suppression><DiagnosticId>CP0001</DiagnosticId><Target>T:One</Target><Target>T:Two</Target></Suppression>'),
    xml('<Suppression><DiagnosticId>CP0001</DiagnosticId><Target><Nested /></Target></Suppression>'),
    xml('<Suppression><DiagnosticId>CP0001</DiagnosticId><!-- unexpected --><Target>T:One</Target></Suppression>'),
    '<Suppressions xmlns="urn:test" />',
    '<!DOCTYPE Suppressions [<!ENTITY x SYSTEM "file:///etc/passwd">]><Suppressions>&x;</Suppressions>',
  ]) {
    await assert.rejects(run([{ filename: path, status: 'added' }], { [`head:${path}`]: content }), /baseline/i);
  }
});

test('fails closed for missing or malformed baseline content', async () => {
  await assert.rejects(run([{ filename: path, status: 'modified' }], { [`head:${path}`]: xml('') }), /Missing/);
  await assert.rejects(run([{ filename: path, status: 'added' }], { [`head:${path}`]: '<Suppressions>' }), /baseline/i);
  await assert.rejects(run([{ filename: path, status: 'added' }], { [`head:${path}`]: '<!DOCTYPE x><Suppressions />' }), /baseline/i);
});
