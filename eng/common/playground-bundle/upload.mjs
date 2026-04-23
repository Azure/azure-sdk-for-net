#!/usr/bin/env node
// @ts-check
//
// Bundle a TypeSpec emitter package and upload it to the typespec playground
// blob storage so the package can be loaded by the in-browser playground.
//
// Mirrors the behavior of `bundleAndUploadStandalonePackage` from
// microsoft/typespec's `@typespec/bundle-uploader` package, but is
// self-contained so it can run from azure-sdk-tools eng/common.
//
// Required arguments:
//   --package-path <path>   Absolute or relative path to the emitter package root.
//
// Optional arguments:
//   --version <version>     Version string to record in the uploaded manifest.
//                           Overrides the version from package.json. Useful
//                           when the build pipeline stamps a prerelease
//                           version that the bundler shouldn't re-read from
//                           a restored package.json.
//
// Authentication:
//   Uses AzureCliCredential, which works inside an AzureCLI@2 task on Azure
//   DevOps (the task's service principal logs in to az before running this
//   script).

import { AzureCliCredential } from "@azure/identity";
import { BlobServiceClient } from "@azure/storage-blob";
import { createTypeSpecBundle } from "@typespec/bundler";
import { readFile } from "node:fs/promises";
import { resolve } from "node:path";
import { join as joinUnix } from "node:path/posix";

const STORAGE_ACCOUNT_NAME = "typespec";
const PKGS_CONTAINER = "pkgs";

function parseArgs(argv) {
  const args = { packagePath: undefined, version: undefined };
  for (let i = 0; i < argv.length; i++) {
    const arg = argv[i];
    if (arg === "--package-path") {
      args.packagePath = argv[++i];
    } else if (arg === "--version") {
      args.version = argv[++i];
    } else {
      throw new Error(`Unknown argument: ${arg}`);
    }
  }
  if (!args.packagePath) {
    throw new Error("Missing required --package-path argument.");
  }
  return args;
}

function normalizePath(path) {
  return path.replace(/\\/g, "/");
}

async function manifestAlreadyExists(container, manifest) {
  const blob = container.getBlockBlobClient(
    normalizePath(joinUnix(manifest.name, manifest.version, "manifest.json")),
  );
  return blob.exists();
}

async function uploadManifest(container, manifest) {
  const blob = container.getBlockBlobClient(
    normalizePath(joinUnix(manifest.name, manifest.version, "manifest.json")),
  );
  const content = JSON.stringify(manifest);
  await blob.upload(content, content.length, {
    blobHTTPHeaders: { blobContentType: "application/json; charset=utf-8" },
    conditions: { ifNoneMatch: "*" },
  });
}

async function uploadJsFile(container, pkgName, version, file) {
  const blob = container.getBlockBlobClient(
    normalizePath(joinUnix(pkgName, version, file.filename)),
  );
  // Overwrite without ifNoneMatch — a previous crashed run may have
  // partially uploaded a subset of files. The manifest is the version's
  // commit marker (uploaded last), so writing files freely here is safe.
  await blob.uploadData(Buffer.from(file.content), {
    blobHTTPHeaders: { blobContentType: "application/javascript; charset=utf-8" },
  });
}

async function updatePackageLatest(container, pkgName, index) {
  const blob = container.getBlockBlobClient(normalizePath(joinUnix(pkgName, "latest.json")));
  const content = JSON.stringify(index);
  await blob.upload(content, content.length, {
    blobHTTPHeaders: { blobContentType: "application/json; charset=utf-8" },
  });
}

async function main() {
  const { packagePath, version: versionOverride } = parseArgs(process.argv.slice(2));
  const absPackagePath = resolve(packagePath);
  const pkgJson = JSON.parse(await readFile(resolve(absPackagePath, "package.json"), "utf-8"));

  console.log(`Bundling package at ${absPackagePath}`);
  const bundle = await createTypeSpecBundle(absPackagePath);

  // The package.json may have been restored to its non-stamped version after
  // npm pack. Honor the explicit version from the pipeline if provided.
  const bundlerVersion = bundle.manifest.version ?? pkgJson.version;
  const resolvedVersion = versionOverride ?? bundlerVersion;
  if (!resolvedVersion) {
    throw new Error("Could not resolve a version for the bundle.");
  }
  if (versionOverride && bundlerVersion && versionOverride !== bundlerVersion) {
    console.log(
      `Note: --version override "${versionOverride}" differs from package.json version "${bundlerVersion}".`,
    );
  }
  bundle.manifest.version = resolvedVersion;
  console.log(`Bundle: ${bundle.manifest.name}@${resolvedVersion}`);

  const credential = new AzureCliCredential();
  const blobSvc = new BlobServiceClient(
    `https://${STORAGE_ACCOUNT_NAME}.blob.core.windows.net`,
    credential,
  );
  const container = blobSvc.getContainerClient(PKGS_CONTAINER);
  await container.createIfNotExists({ access: "blob" });

  // Upload the JS files first, then the manifest. The manifest acts as the
  // "commit marker" for the version: if it already exists we trust the
  // previous run and skip everything. This makes retries safe — a half-
  // uploaded run can re-upload the missing files because the manifest
  // wasn't written yet, instead of being short-circuited by a stale
  // manifest from a crashed earlier run.
  const manifestExisted = await manifestAlreadyExists(container, bundle.manifest);
  if (!manifestExisted) {
    for (const file of bundle.files) {
      await uploadJsFile(container, bundle.manifest.name, resolvedVersion, file);
    }
    await uploadManifest(container, bundle.manifest);
    console.log(`✔ Uploaded bundle ${bundle.manifest.name}@${resolvedVersion}`);
  } else {
    console.log(`Bundle ${bundle.manifest.name}@${resolvedVersion} already exists, skipping upload.`);
  }

  // Build absolute import URLs. Prefix each manifest key with the package
  // name so the resulting import map keys match what the in-browser
  // playground expects (e.g. "@azure-typespec/http-client-csharp",
  // "@azure-typespec/http-client-csharp/testing", ...).
  const imports = Object.fromEntries(
    Object.entries(bundle.manifest.imports).map(([key, value]) => [
      normalizePath(joinUnix(bundle.manifest.name, key)),
      `${container.url}/${normalizePath(joinUnix(bundle.manifest.name, resolvedVersion, value))}`,
    ]),
  );

  await updatePackageLatest(container, bundle.manifest.name, {
    version: resolvedVersion,
    imports,
  });
  console.log(`✔ Updated ${bundle.manifest.name}/latest.json to ${resolvedVersion}`);
}

main().catch((err) => {
  console.error(err);
  process.exit(1);
});
