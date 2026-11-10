// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { createTypeSpecBundle } from '@typespec/bundler';
import { copyFile, mkdir, writeFile } from 'node:fs/promises';
import { dirname, resolve } from 'node:path';
import { join } from 'node:path/posix';
import { fileURLToPath } from 'node:url';

const storageUrl = 'https://typespec.blob.core.windows.net/pkgs/';

export async function writeBundle(
  bundle,
  outputDirectory,
  peerBundles = [],
  runtimePackage,
) {
  const imports = {};
  for (const { manifest, files } of [bundle, ...peerBundles]) {
    const assetDirectory =
      manifest === bundle.manifest
        ? join(manifest.name, manifest.version)
        : join(
            bundle.manifest.name,
            bundle.manifest.version,
            'peers',
            manifest.name,
            manifest.version,
          );
    const versionDirectory = resolve(outputDirectory, assetDirectory);
    for (const [key, value] of Object.entries(manifest.imports)) {
      imports[join(manifest.name, key)] = new URL(
        join(assetDirectory, value),
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
  let runtimeUrl;
  if (runtimePackage) {
    const runtimePath = join(
      bundle.manifest.name,
      bundle.manifest.version,
      'runtime.tgz',
    );
    await copyFile(runtimePackage, resolve(outputDirectory, runtimePath));
    runtimeUrl = new URL(runtimePath, storageUrl).href;
  }
  const importMap = JSON.stringify(
    { version: bundle.manifest.version, imports, runtimeUrl },
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
  const [packagePath, outputDirectory, runtimePackage] = process.argv.slice(2);
  if (!packagePath || !outputDirectory) {
    throw new Error(
      'Usage: node bundle.mjs <package-path> <output-directory> [runtime-package.tgz]',
    );
  }
  const bundle = await createTypeSpecBundle(resolve(packagePath));
  const peerBundles = [];
  for (const name of bundle.definition.packageJson.playgroundConfig
    ?.bundlePeerDependencies ?? []) {
    peerBundles.push(
      await createTypeSpecBundle(resolve(packagePath, 'node_modules', name)),
    );
  }
  await writeBundle(
    bundle,
    resolve(outputDirectory),
    peerBundles,
    runtimePackage && resolve(runtimePackage),
  );
}
