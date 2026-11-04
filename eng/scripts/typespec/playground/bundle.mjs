// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { createTypeSpecBundle } from '@typespec/bundler';
import { mkdir, writeFile } from 'node:fs/promises';
import { dirname, resolve } from 'node:path';
import { join } from 'node:path/posix';
import { fileURLToPath } from 'node:url';

const storageUrl = 'https://typespec.blob.core.windows.net/pkgs/';

export async function writeBundle(bundle, outputDirectory) {
  const { manifest, files } = bundle;
  const packageDirectory = resolve(outputDirectory, manifest.name);
  const versionDirectory = resolve(packageDirectory, manifest.version);
  const imports = Object.fromEntries(
    Object.entries(manifest.imports).map(([key, value]) => [
      join(manifest.name, key),
      new URL(join(manifest.name, manifest.version, value), storageUrl).href,
    ]),
  );

  for (const file of files) {
    const path = resolve(versionDirectory, file.filename);
    await mkdir(dirname(path), { recursive: true });
    await writeFile(path, file.content);
  }
  await writeFile(
    resolve(versionDirectory, 'manifest.json'),
    JSON.stringify(manifest, null, 2),
  );
  await writeFile(
    resolve(packageDirectory, 'latest.json'),
    JSON.stringify({ version: manifest.version, imports }, null, 2),
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
  await writeBundle(
    await createTypeSpecBundle(resolve(packagePath)),
    resolve(outputDirectory),
  );
}
