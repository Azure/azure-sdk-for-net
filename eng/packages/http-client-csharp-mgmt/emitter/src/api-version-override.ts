// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { getEffectiveApiVersionOverride } from "@azure-tools/typespec-azure-core";
import type {
  CodeModel,
  CSharpEmitterContext,
  InputClient
} from "./code-model-types.js";
import { getAllSdkClients, traverseClient } from "./sdk-client-utils.js";

export const apiVersionOverrideMarker =
  "Azure.ResourceManager.@hasApiVersionOverride";

/**
 * Preserve override intent even when its value equals the projected service version.
 * TCGC owns resolution of the wire value in clientDefaultValue; this marker only
 * records the presence of a decorator using Azure Core's scope resolver.
 */
export function markApiVersionOverrides(
  codeModel: CodeModel,
  context: CSharpEmitterContext
): void {
  const overriddenMethods = new Set<string>();
  for (const client of getAllSdkClients(context)) {
    for (const method of client.methods) {
      let declaration = method.__raw;
      while (declaration) {
        if (
          getEffectiveApiVersionOverride(context.program, declaration) !==
          undefined
        ) {
          overriddenMethods.add(method.crossLanguageDefinitionId);
          break;
        }
        declaration = declaration.sourceOperation;
      }
    }
  }
  const clients: InputClient[] = [];
  for (const client of codeModel.clients) traverseClient(client, clients);
  for (const client of clients) {
    for (const method of client.methods) {
      if (overriddenMethods.has(method.crossLanguageDefinitionId)) {
        const decorators = (method.operation.decorators ??= []);
        if (!decorators.some((d) => d.name === apiVersionOverrideMarker)) {
          decorators.push({ name: apiVersionOverrideMarker, arguments: {} });
        }
      }
    }
  }
}
