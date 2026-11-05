// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { createTypeSpecBundle } from '@typespec/bundler';
import { ok, strictEqual } from 'node:assert';
import { execFileSync } from 'node:child_process';
import { mkdir, mkdtemp, rm, writeFile } from 'node:fs/promises';
import { createRequire } from 'node:module';
import { dirname, resolve } from 'node:path';
import { test } from 'node:test';
import { fileURLToPath, pathToFileURL } from 'node:url';

const packagesDirectory = resolve(
  dirname(fileURLToPath(import.meta.url)),
  '../../../../packages',
);
const dataPlane = `
import "@typespec/http";
using TypeSpec.Http;
@service
namespace Playground;
@route("/widgets")
@get op listWidgets(): string[];
`;
const managementPlane = `
import "@azure-tools/typespec-azure-resource-manager";
using Azure.ResourceManager;
using TypeSpec.Versioning;
@armProviderNamespace
@service
@versioned(Versions)
namespace Playground;
enum Versions { v2024_01_01: "2024-01-01" }
model Widget is TrackedResource<WidgetProperties> {
  ...ResourceNameParameter<Widget>;
}
model WidgetProperties { description?: string; }
@armResourceOperations
interface Widgets {
  get is ArmResourceRead<Widget>;
  createOrUpdate is ArmResourceCreateOrUpdateSync<Widget>;
  delete is ArmResourceDeleteSync<Widget>;
  listByResourceGroup is ArmResourceListByParent<Widget>;
}
`;

const cases = [
  ['http-client-csharp', 'AzureClientGenerator', dataPlane],
  ['http-client-csharp-mgmt', 'ManagementClientGenerator', managementPlane],
  ['http-client-csharp-provisioning', 'ProvisioningGenerator', managementPlane],
];

for (const [name, generatorName, source] of cases) {
  test(`${name} bundles and generates through the browser transport`, async (t) => {
    if (!process.env.PLAYGROUND_EMITTER) {
      // Each package has its own compiler dependencies, whose singletons cannot share a process.
      const env = { ...process.env, PLAYGROUND_EMITTER: name };
      delete env.NODE_TEST_CONTEXT;
      const output = execFileSync(
        process.execPath,
        ['--test', fileURLToPath(import.meta.url)],
        {
          env,
          encoding: 'utf8',
          stdio: 'pipe',
        },
      );
      ok(output.includes('pass 1'), output);
      return;
    }
    if (process.env.PLAYGROUND_EMITTER !== name) {
      t.skip();
      return;
    }
    const packageDirectory = resolve(packagesDirectory, name);
    const tempDirectory = resolve(packageDirectory, 'emitter/temp');
    await mkdir(tempDirectory, { recursive: true });
    const directory = await mkdtemp(resolve(tempDirectory, 'playground-'));
    t.after(() => rm(directory, { recursive: true, force: true }));

    const bundle = await createTypeSpecBundle(packageDirectory);
    for (const file of bundle.files) {
      await writeFile(resolve(directory, file.filename), file.content);
    }
    const require = createRequire(resolve(packageDirectory, 'package.json'));
    const { compile, NodeHost, normalizePath, formatDiagnostic } = await import(
      pathToFileURL(require.resolve('@typespec/compiler')).href
    );
    const mainFile = resolve(directory, 'main.tsp');
    await writeFile(mainFile, source);
    const writtenFiles = new Map();
    const program = await compile(
      {
        ...NodeHost,
        writeFile: async (path, content) => {
          writtenFiles.set(path, content);
        },
      },
      normalizePath(mainFile),
      {},
    );
    ok(
      !program.hasError(),
      program.diagnostics.map(formatDiagnostic).join('\n'),
    );

    const content = '// Generated C# from the playground server';
    let request;
    t.mock.method(globalThis, 'fetch', async (url, options) => {
      strictEqual(
        url,
        'https://csharp-playground-server.azurewebsites.net/generate',
      );
      strictEqual(options.method, 'POST');
      request = JSON.parse(options.body);
      return Response.json({
        files: [{ path: 'src/Generated/Widget.cs', content }],
      });
    });

    const emitter = await import(
      pathToFileURL(resolve(directory, 'index.js')).href
    );
    await emitter.$onEmit({
      program,
      emitterOutputDir: normalizePath(resolve(directory, 'output')),
      options: { namespace: 'Playground', 'package-name': 'Playground' },
    });

    ok(
      !program.hasError(),
      program.diagnostics.map(formatDiagnostic).join('\n'),
    );
    ok(request, 'Expected browser generation, not a local .NET subprocess');
    strictEqual(request.generatorName, generatorName);
    ok(JSON.parse(request.codeModel).clients.length > 0);
    strictEqual(
      JSON.parse(request.configuration)['package-name'],
      'Playground',
    );
    strictEqual(
      writtenFiles.get(
        normalizePath(resolve(directory, 'output/src/Generated/Widget.cs')),
      ),
      content,
    );
  });
}
