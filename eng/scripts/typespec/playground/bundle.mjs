// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { createTypeSpecBundle } from '@typespec/bundler';
import { mkdir, writeFile } from 'node:fs/promises';
import { dirname, resolve } from 'node:path';
import { join } from 'node:path/posix';
import { fileURLToPath } from 'node:url';

const storageUrl = 'https://typespec.blob.core.windows.net/pkgs/';

export async function writeBundle(bundle, outputDirectory, peerBundles = []) {
  const imports = {};
  for (const { manifest, files } of [bundle, ...peerBundles]) {
    const versionDirectory = resolve(
      outputDirectory,
      manifest.name,
      manifest.version,
    );
    for (const [key, value] of Object.entries(manifest.imports)) {
      imports[join(manifest.name, key)] = new URL(
        join(manifest.name, manifest.version, value),
        storageUrl,
      ).href;
    }

    for (const file of files) {
      const path = resolve(versionDirectory, file.filename);
      await mkdir(dirname(path), { recursive: true });
      await writeFile(path, file.content);
    }
    await writeFile(
      resolve(versionDirectory, 'manifest.json'),
      JSON.stringify(manifest, null, 2),
    );
  }
  const importMap = JSON.stringify(
    { version: bundle.manifest.version, imports },
    null,
    2,
  );
  await writeFile(
    resolve(
      outputDirectory,
      bundle.manifest.name,
      bundle.manifest.version,
      'import-map.json',
    ),
    importMap,
  );
  await writeFile(
    resolve(outputDirectory, bundle.manifest.name, 'latest.json'),
    importMap,
  );
}

if (
  process.argv[1] &&
  resolve(process.argv[1]) === fileURLToPath(import.meta.url)
) {
  const [packagePath, outputDirectory] = process.argv.slice(2);
  if (!packagePath || !outputDirectory) {
    throw new Error('Usage: node bundle.mjs <package-path> <output-directory>');
  }
  const bundle = await createTypeSpecBundle(resolve(packagePath));
  const peerBundles = [];
  for (const name of bundle.definition.packageJson.playgroundConfig
    ?.bundlePeerDependencies ?? []) {
    peerBundles.push(
      await createTypeSpecBundle(resolve(packagePath, 'node_modules', name)),
    );
  }
  await writeBundle(bundle, resolve(outputDirectory), peerBundles);
}
