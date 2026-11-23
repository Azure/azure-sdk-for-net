// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ok, strictEqual } from 'node:assert';
import { spawnSync } from 'node:child_process';
import { mkdir, mkdtemp, readFile, rm, writeFile } from 'node:fs/promises';
import { tmpdir } from 'node:os';
import { dirname, join, resolve } from 'node:path';
import { test } from 'node:test';
import { fileURLToPath } from 'node:url';

const pipelinePath = resolve(
  dirname(fileURLToPath(import.meta.url)),
  '../../../../pipelines/templates/archetype-typespec-emitter.yml',
);
const pipeline = await readFile(pipelinePath, 'utf8');
const script = pipeline
  .split('displayName: Publish TypeSpec playground bundle')[1]
  .split('inlineScript: |')[1]
  .split('\n    - ${{')[0]
  .split(/\r?\n/)
  .map((line) => line.replace(/^ {26}/, ''))
  .join('\n')
  .replace('$(buildArtifactsPath)/playground', '$env:PLAYGROUND_TEST_ROOT');

const mock = `
$ErrorActionPreference = 'Stop'
function az {
  $arguments = @($args)
  $operation = $arguments[2]
  $blob = $arguments[[Array]::IndexOf($arguments, '--name') + 1]
  "$operation $blob" | Add-Content -LiteralPath $env:PLAYGROUND_TEST_LOG
  $global:LASTEXITCODE = 0
  $immutable = $blob -notlike '*/latest.json'
  if ($operation -eq 'exists') {
    if ($env:PLAYGROUND_TEST_MODE -eq 'exists-error') {
      $global:LASTEXITCODE = 1
      'ERROR: (AuthorizationFailure) Not authorized'
      return
    }
    if ($env:PLAYGROUND_TEST_MODE -like 'existing*') { 'true' } else { 'false' }
  }
  elseif ($operation -eq 'upload') {
    $overwrite = $arguments[[Array]::IndexOf($arguments, '--overwrite') + 1]
    if ($overwrite -ne $(if ($immutable) { 'false' } else { 'true' })) {
      throw 'Unexpected overwrite option'
    }
    if ($immutable -and $env:PLAYGROUND_TEST_MODE -eq 'upload-error') {
      $global:LASTEXITCODE = 1
      'ERROR: (AuthorizationFailure) Not authorized'
    }
    elseif (($immutable -and $env:PLAYGROUND_TEST_MODE -like 'race*') -or
      (!$immutable -and $env:PLAYGROUND_TEST_MODE -eq 'latest-conflict')) {
      $global:LASTEXITCODE = 1
      'ERROR: (BlobAlreadyExists) The specified blob already exists.'
      'ErrorCode:BlobAlreadyExists'
    }
  }
  elseif ($operation -eq 'download') {
    $destination = $arguments[[Array]::IndexOf($arguments, '--file') + 1]
    if ($env:PLAYGROUND_TEST_MODE -eq 'race-download-error') {
      $global:LASTEXITCODE = 1
      'ERROR: Download failed'
    }
    elseif ($env:PLAYGROUND_TEST_MODE -like '*mismatch') {
      [System.IO.File]::WriteAllText($destination, 'different content')
    }
    else {
      Copy-Item -LiteralPath (Join-Path $env:PLAYGROUND_TEST_ROOT $blob) -Destination $destination -Force
    }
  }
  else { throw "Unexpected Azure operation $operation" }
}
`;

for (const [mode, error] of [
  ['fresh', undefined],
  ['existing', undefined],
  ['race', undefined],
  ['existing-mismatch', 'differs from the built artifact'],
  ['race-mismatch', 'differs from the built artifact'],
  ['upload-error', 'AuthorizationFailure'],
  ['exists-error', 'Failed to check playground blob'],
  ['race-download-error', 'Failed to download existing playground blob'],
  ['latest-conflict', 'Failed to upload playground blob'],
]) {
  test(`publishes playground blobs safely: ${mode}`, async (t) => {
    const directory = await mkdtemp(join(tmpdir(), 'playground-publication-'));
    t.after(() => rm(directory, { recursive: true, force: true }));
    const root = join(directory, 'artifacts');
    const packageRoot = join(root, '@azure-typespec/http-client-csharp');
    const peerRoot = join(root, '@typespec/http-client/0.17.0');
    await mkdir(join(packageRoot, '1.0.0'), { recursive: true });
    await mkdir(peerRoot, { recursive: true });
    await writeFile(
      join(packageRoot, '1.0.0/runtime.tgz'),
      Buffer.from([1, 2, 3]),
    );
    await writeFile(join(packageRoot, 'latest.json'), '{}');
    await writeFile(join(peerRoot, 'index.js'), 'export {};');
    const log = join(directory, 'operations.log');
    const result = spawnSync(
      'pwsh',
      ['-NoProfile', '-NonInteractive', '-Command', `${mock}\n${script}`],
      {
        encoding: 'utf8',
        env: {
          ...process.env,
          PLAYGROUND_TEST_ROOT: root,
          PLAYGROUND_TEST_LOG: log,
          PLAYGROUND_TEST_MODE: mode,
        },
      },
    );
    if (result.error) throw result.error;
    const output = result.stdout + result.stderr;
    const operations = (await readFile(log, 'utf8')).trim().split(/\r?\n/);
    const latestUpload =
      'upload @azure-typespec/http-client-csharp/latest.json';
    if (error) {
      ok(result.status !== 0, output);
      ok(output.includes(error), output);
      if (mode !== 'latest-conflict') {
        ok(!operations.includes(latestUpload), operations.join('\n'));
      }
    } else {
      strictEqual(result.status, 0, output);
      ok(!output.includes('Exception'), output);
      strictEqual(operations.at(-1), latestUpload);
      if (mode !== 'fresh') {
        strictEqual(
          operations.filter((operation) => operation.startsWith('download '))
            .length,
          2,
        );
      }
    }
  });
}
