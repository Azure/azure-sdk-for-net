// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { CSharpEmitterContext } from "@typespec/http-client-csharp";
import {
  getClientOptions,
  SdkModelType
} from "@azure-tools/typespec-client-generator-core";

/**
 * The name of the client option that marks a resource model as a non-resource.
 * When applied to a resource model, the emitter will exclude it from the ARM provider schema
 * so the schema builder never sees it as a resource. Its operations are naturally assigned
 * to the parent resource via the schema builder's normal non-resource method handling.
 *
 * Usage in TypeSpec:
 * ```typespec
 * @@clientOption(MyResourceModel, "markAsNonResource", true, "csharp")
 * ```
 */
export const MARK_AS_NON_RESOURCE_OPTION = "markAsNonResource";

/**
 * Parsed client options for a resource model.
 * This interface is designed to be extensible for future client options.
 */
export interface ResourceClientOptions {
  /** When true, the resource model should be treated as a non-resource. */
  markAsNonResource?: boolean;
}

/**
 * Parses @clientOption decorators from all SDK models and returns a map of
 * resource client options keyed by crossLanguageDefinitionId.
 *
 * This function is designed to be the single entry point for reading all
 * client options that affect resource classification. As new options are added,
 * they should be parsed here and added to the ResourceClientOptions interface.
 *
 * @param sdkContext - The emitter context containing SDK package models
 * @returns A map from model crossLanguageDefinitionId to its client options
 */
export function parseResourceClientOptions(
  sdkContext: CSharpEmitterContext
): Map<string, ResourceClientOptions> {
  const result = new Map<string, ResourceClientOptions>();

  for (const model of sdkContext.sdkPackage.models) {
    const options = parseClientOptionsForModel(model);
    if (options) {
      result.set(model.crossLanguageDefinitionId, options);
    }
  }

  return result;
}

/**
 * Returns a set of crossLanguageDefinitionIds for models that should be
 * excluded from resource detection (i.e., marked as non-resource).
 *
 * Use this to filter resource model lists *before* building the ARM provider schema,
 * so the schema builder never sees these models as resources.
 *
 * @param clientOptionsMap - Map of model crossLanguageDefinitionId to client options
 * @returns Set of crossLanguageDefinitionIds to exclude
 */
export function getMarkedNonResourceIds(
  clientOptionsMap: Map<string, ResourceClientOptions>
): Set<string> {
  const result = new Set<string>();
  for (const [id, options] of clientOptionsMap) {
    if (options.markAsNonResource) {
      result.add(id);
    }
  }
  return result;
}

/**
 * Parses client options for a single SDK model.
 * Returns undefined if no relevant options are found.
 */
function parseClientOptionsForModel(
  model: SdkModelType
): ResourceClientOptions | undefined {
  const markAsNonResource = getClientOptions(
    model,
    MARK_AS_NON_RESOURCE_OPTION
  );

  if (markAsNonResource === undefined) {
    return undefined;
  }

  return {
    markAsNonResource: markAsNonResource === true
  };
}
