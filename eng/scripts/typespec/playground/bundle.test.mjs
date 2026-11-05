// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { deepStrictEqual, rejects, strictEqual } from 'node:assert';
import { mkdtemp, readFile, rm } from 'node:fs/promises';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { test } from 'node:test';
import { writeBundle } from './bundle.mjs';

test('writes versioned bundles and the standalone TypeSpec import map', async (t) => {
  const directory = await mkdtemp(join(tmpdir(), 'csharp-playground-'));
  t.after(() => rm(directory, { recursive: true, force: true }));
  const manifest = {
    name: '@azure-typespec/http-client-csharp',
    version: '1.0.0-alpha.20261104.1',
    imports: { '.': 'index.js', './models': 'models.js' },
  };
  await writeBundle(
    {
      manifest,
      files: [
        { filename: 'index.js', content: 'export const $onEmit = () => {};' },
        {
          filename: 'models.js',
          content: 'export * from "./chunks/models.js";',
        },
        { filename: 'chunks/models.js', content: 'export const model = {};' },
      ],
    },
    directory,
  );

  const packageDirectory = join(directory, manifest.name);
  deepStrictEqual(
    JSON.parse(
      await readFile(join(packageDirectory, manifest.version, 'manifest.json')),
    ),
    manifest,
  );
  strictEqual(
    await readFile(
      join(packageDirectory, manifest.version, 'chunks', 'models.js'),
      'utf8',
    ),
    'export const model = {};',
  );
  deepStrictEqual(
    JSON.parse(await readFile(join(packageDirectory, 'latest.json'))),
    {
      version: manifest.version,
      imports: {
        '@azure-typespec/http-client-csharp': `https://typespec.blob.core.windows.net/pkgs/${manifest.name}/${manifest.version}/index.js`,
        '@azure-typespec/http-client-csharp/models': `https://typespec.blob.core.windows.net/pkgs/${manifest.name}/${manifest.version}/models.js`,
      },
    },
  );
  deepStrictEqual(
    JSON.parse(
      await readFile(
        join(packageDirectory, manifest.version, 'import-map.json'),
      ),
    ),
    JSON.parse(await readFile(join(packageDirectory, 'latest.json'))),
  );
});

test('does not publish an import map when writing a bundle fails', async (t) => {
  const directory = await mkdtemp(join(tmpdir(), 'csharp-playground-'));
  t.after(() => rm(directory, { recursive: true, force: true }));
  await rejects(
    writeBundle(
      {
        manifest: {
          name: '@azure-typespec/http-client-csharp',
          version: '1.0.0',
          imports: { '.': 'index.js' },
        },
        files: [{ filename: 'index.js', content: undefined }],
      },
      directory,
    ),
  );
  await rejects(
    readFile(join(directory, '@azure-typespec/http-client-csharp/latest.json')),
    {
      code: 'ENOENT',
    },
  );
  await rejects(
    readFile(
      join(
        directory,
        '@azure-typespec/http-client-csharp/1.0.0/import-map.json',
      ),
    ),
    { code: 'ENOENT' },
  );
});

test('retains the old versioned map when the latest package advances', async (t) => {
  const directory = await mkdtemp(join(tmpdir(), 'csharp-playground-'));
  t.after(() => rm(directory, { recursive: true, force: true }));
  const name = '@azure-typespec/http-client-csharp';
  for (const version of ['1.0.0', '2.0.0']) {
    await writeBundle(
      {
        manifest: { name, version, imports: { '.': 'index.js' } },
        files: [{ filename: 'index.js', content: 'export {};' }],
      },
      directory,
    );
  }
  const oldMap = JSON.parse(
    await readFile(join(directory, name, '1.0.0/import-map.json')),
  );
  const latestMap = JSON.parse(
    await readFile(join(directory, name, 'latest.json')),
  );
  strictEqual(oldMap.version, '1.0.0');
  strictEqual(
    oldMap.imports[name],
    `https://typespec.blob.core.windows.net/pkgs/${name}/1.0.0/index.js`,
  );
  strictEqual(latestMap.version, '2.0.0');
});

test('includes separately bundled peers in the emitter import map', async (t) => {
  const directory = await mkdtemp(join(tmpdir(), 'csharp-playground-'));
  t.after(() => rm(directory, { recursive: true, force: true }));
  const manifest = {
    name: '@azure-typespec/http-client-csharp',
    version: '1.0.0',
    imports: { '.': 'index.js' },
  };
  await writeBundle(
    { manifest, files: [{ filename: 'index.js', content: 'export {};' }] },
    directory,
    [
      {
        manifest: {
          name: '@typespec/http-client',
          version: '0.17.0',
          imports: { '.': 'index.js', './typekit': 'typekit.js' },
        },
        files: [
          { filename: 'index.js', content: 'export {};' },
          { filename: 'typekit.js', content: 'export const typekit = {};' },
        ],
      },
    ],
  );
  const index = JSON.parse(
    await readFile(
      join(directory, manifest.name, manifest.version, 'import-map.json'),
    ),
  );
  strictEqual(
    index.imports['@typespec/http-client/typekit'],
    'https://typespec.blob.core.windows.net/pkgs/@typespec/http-client/0.17.0/typekit.js',
  );
  strictEqual(
    await readFile(
      join(directory, '@typespec/http-client/0.17.0/typekit.js'),
      'utf8',
    ),
    'export const typekit = {};',
  );
  await rejects(
    readFile(join(directory, '@typespec/http-client/latest.json')),
    {
      code: 'ENOENT',
    },
  );
});
