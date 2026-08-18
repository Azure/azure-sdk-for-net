// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext } from "@typespec/compiler";

import { emitManagementCodeModel } from "@azure-typespec/http-client-csharp-mgmt";
import { AzureProvisioningEmitterOptions } from "./options.js";
import { updateProvisioningCodeModel } from "./provisioning-code-model.js";

export async function $onEmit(
  context: EmitContext<AzureProvisioningEmitterOptions>
) {
  context.options["generator-name"] ??= "ProvisioningGenerator";
  context.options["emitter-extension-path"] ??= import.meta.url;
  // Provisioning libraries use a flat namespace (no .Models sub-namespace)
  context.options["model-namespace"] = false;
  context.options["api-version"] = normalizeApiVersionOption(
    context.options["api-version"]
  );
  await emitManagementCodeModel(context, (codeModel, _, armProviderSchema) =>
    updateProvisioningCodeModel(codeModel, armProviderSchema)
  );
}

export function normalizeApiVersionOption(
  apiVersion: unknown
): AzureProvisioningEmitterOptions["api-version"] {
  if (apiVersion === undefined || typeof apiVersion === "string") {
    return apiVersion;
  }

  if (!isRecord(apiVersion)) {
    throw new Error("The api-version option must be a string or an object.");
  }

  const result: Record<string, string> = {};
  flattenApiVersionOption(apiVersion, [], result);
  return result;
}

function flattenApiVersionOption(
  apiVersion: Record<string, unknown>,
  namespaceSegments: string[],
  result: Record<string, string>
): void {
  for (const [key, value] of Object.entries(apiVersion)) {
    const segments = [...namespaceSegments, key];
    if (typeof value === "string") {
      result[segments.join(".")] = value;
    } else if (isRecord(value)) {
      flattenApiVersionOption(value, segments, result);
    } else {
      throw new Error(
        `The api-version value for '${segments.join(".")}' must be a string.`
      );
    }
  }
}

function isRecord(value: unknown): value is Record<string, unknown> {
  return typeof value === "object" && value !== null && !Array.isArray(value);
}
