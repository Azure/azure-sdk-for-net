// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

/**
 * ARM resources validator.
 *
 * This module contains the post-processing validation/prune step that runs
 * after either resource resolution path (the new `resolveArmResources` based
 * converter or the legacy `buildArmProviderSchema`) produces an
 * `ArmProviderSchema`. Centralizing the validation here ensures both paths
 * benefit from the same correctness checks and emit the same diagnostics.
 */

import { Program, NoTarget } from "@typespec/compiler";
import { CSharpEmitterContext } from "@typespec/http-client-csharp";
import { SdkModelType } from "@azure-tools/typespec-client-generator-core";
import {
  ArmProviderSchema,
  ArmResourceSchema,
  ValidArmResourceSchema,
  ResourceOperationKind
} from "./resource-metadata.js";
import { getAllSdkClients } from "./sdk-client-utils.js";
import { $lib } from "./lib/lib.js";

/**
 * Validates and prunes ARM resources after resolution.
 *
 * This function performs the following steps:
 * 1. Prunes methods whose crossLanguageDefinitionId cannot be found in the SDK library
 * 2. Validates that read operations return the resource model type
 * 3. Validates that list operations are pageable
 * 4. Validates that each resource has a unique resource ID pattern
 * 5. Validates that each resource has a unique resource name
 *
 * All validation failures emit error-level diagnostics.
 *
 * @param program - The TypeSpec program for reporting diagnostics
 * @param sdkContext - The emitter context used to look up SDK methods
 * @param schema - The resolved ARM provider schema to validate
 * @returns A new ArmProviderSchema containing only the pruned/validated resources
 */
export function validateAndPruneArmResources(
  program: Program,
  sdkContext: CSharpEmitterContext,
  schema: ArmProviderSchema
): ArmProviderSchema {
  const { methodKindMap, methodDirectResponseModelIdMap } =
    buildValidationMaps(sdkContext);

  // Step 1: Prune methods whose crossLanguageDefinitionId cannot be found in the SDK library
  for (const resource of schema.resources) {
    resource.metadata.methods = resource.metadata.methods.filter((method) =>
      methodKindMap.has(method.methodId)
    );
  }
  // Remove resources that have no methods left after pruning
  const prunedResources: ValidArmResourceSchema[] = schema.resources.filter(
    (r) => r.metadata.methods.length > 0
  );

  // Step 2: Validate read operations return the resource model type
  for (const resource of prunedResources) {
    const readMethods = resource.metadata.methods.filter(
      (m) => m.kind === ResourceOperationKind.Read
    );
    for (const readMethod of readMethods) {
      const responseModelId = methodDirectResponseModelIdMap.get(
        readMethod.methodId
      );
      if (responseModelId && responseModelId !== resource.resourceModelId) {
        $lib.reportDiagnostic(program, {
          code: "invalid-resource-read-response",
          target: NoTarget,
          format: {
            message: `Read operation '${readMethod.methodId}' for resource '${resource.resourceModelId}' returns model '${responseModelId}' instead of the resource model. The read operation should return the resource's own model type. See https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/docs/resource-validation-diagnostics.md#invalid-resource-read-response for guidance on how to fix this.`
          }
        });
      }
    }
  }

  // Step 3: Validate list operations are pageable
  for (const resource of prunedResources) {
    const listMethods = resource.metadata.methods.filter(
      (m) => m.kind === ResourceOperationKind.List
    );
    for (const listMethod of listMethods) {
      const methodKind = methodKindMap.get(listMethod.methodId);
      if (methodKind && methodKind !== "paging" && methodKind !== "lropaging") {
        $lib.reportDiagnostic(program, {
          code: "non-pageable-list-operation",
          target: NoTarget,
          format: {
            message: `List operation '${listMethod.methodId}' on resource '${resource.resourceModelId}' is not pageable (kind: '${methodKind}'). All list operations should be pageable. To fix, add the \`@list\` decorator if applicable, or the \`@@markAsPageable\` decorator on \`csharp\` scope. See https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/docs/resource-validation-diagnostics.md#non-pageable-list-operation for details.`
          }
        });
      }
    }
  }

  // Step 4: Validate unique resource ID patterns
  const resourceIdMap = new Map<string, ArmResourceSchema>();
  for (const resource of prunedResources) {
    const resourceId = resource.metadata.resourceIdPattern;
    if (!resourceId) continue;
    const existing = resourceIdMap.get(resourceId.path);
    if (existing) {
      $lib.reportDiagnostic(program, {
        code: "duplicate-resource-id",
        target: NoTarget,
        format: {
          message: `Duplicate resource ID pattern '${resourceId.path}' found for resource models '${existing.resourceModelId}' and '${resource.resourceModelId}'. Each resolved resource must have a unique resource ID. See https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/docs/resource-validation-diagnostics.md#duplicate-resource-id for guidance on how to fix this.`
        }
      });
    } else {
      resourceIdMap.set(resourceId.path, resource);
    }
  }

  // Step 5: Validate unique resource names
  const resourceNameMap = new Map<string, ArmResourceSchema>();
  for (const resource of prunedResources) {
    const resourceName = resource.metadata.resourceName;
    if (!resourceName) continue;
    const existing = resourceNameMap.get(resourceName);
    if (existing) {
      $lib.reportDiagnostic(program, {
        code: "duplicate-resource-name",
        target: NoTarget,
        format: {
          message: `Duplicate resource name '${resourceName}' found for resource models '${existing.resourceModelId}' and '${resource.resourceModelId}'. Each resolved resource must have a unique resource name. See https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/docs/resource-validation-diagnostics.md#duplicate-resource-name for guidance on how to fix this.`
        }
      });
    } else {
      resourceNameMap.set(resourceName, resource);
    }
  }

  return {
    resources: prunedResources,
    nonResourceMethods: schema.nonResourceMethods
  };
}

/**
 * Builds the lookup maps required by the validation step from the SDK context.
 *
 * - `methodKindMap`: methodId -> SdkMethod kind (basic, paging, lro, lropaging).
 *   Used both for pruning unknown methods and validating list operations.
 * - `methodDirectResponseModelIdMap`: methodId -> response model
 *   crossLanguageDefinitionId for basic/lro methods. Used to validate that
 *   read operations return the resource's own model type.
 */
function buildValidationMaps(sdkContext: CSharpEmitterContext): {
  methodKindMap: Map<string, string>;
  methodDirectResponseModelIdMap: Map<string, string>;
} {
  const methodKindMap = new Map<string, string>();
  const methodDirectResponseModelIdMap = new Map<string, string>();
  for (const client of getAllSdkClients(sdkContext)) {
    for (const method of client.methods) {
      if (!methodKindMap.has(method.crossLanguageDefinitionId)) {
        methodKindMap.set(method.crossLanguageDefinitionId, method.kind);
      }
      if (
        (method.kind === "basic" || method.kind === "lro") &&
        !methodDirectResponseModelIdMap.has(method.crossLanguageDefinitionId)
      ) {
        const responseType = method.response?.type;
        if (responseType?.kind === "model") {
          methodDirectResponseModelIdMap.set(
            method.crossLanguageDefinitionId,
            (responseType as SdkModelType).crossLanguageDefinitionId
          );
        }
      }
    }
  }
  return { methodKindMap, methodDirectResponseModelIdMap };
}
