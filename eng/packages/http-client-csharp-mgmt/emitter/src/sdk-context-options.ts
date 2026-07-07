// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  CreateSdkContextOptions,
  DecoratorInfo,
  getClientOptions,
  getClientNameOverride,
  SdkHttpOperation,
  SdkMethod
} from "@azure-tools/typespec-client-generator-core";
import { CodeModel, CSharpEmitterContext } from "@typespec/http-client-csharp";
import { getAllSdkClients } from "./sdk-client-utils.js";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armprovidernamespace
const armProviderNamespaceRegex =
  "Azure\\.ResourceManager\\.@armProviderNamespace";

// https://github.com/microsoft/typespec/blob/main/packages/rest/README.md#parentresource
export const parentResource = "TypeSpec.Rest.@parentResource";
export const parentResourceName = "@parentResource";
const parentResourceRegex = "TypeSpec\\.Rest\\.@parentResource";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armresourceoperations
export const armResourceOperations =
  "Azure.ResourceManager.@armResourceOperations";
const armResourceOperationsRegex =
  "Azure\\.ResourceManager\\.@armResourceOperations";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#singleton
export const singleton = "Azure.ResourceManager.@singleton";
const singletonRegex = "Azure\\.ResourceManager\\.@singleton";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armResourceRead
export const armResourceRead = "Azure.ResourceManager.@armResourceRead";
export const armResourceReadName = "@armResourceRead";
const armResourceReadRegex = "Azure\\.ResourceManager\\.@armResourceRead";

export const readsResourceName = "@readsResource";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armresourcecreateorupdate
export const armResourceCreateOrUpdate =
  "Azure.ResourceManager.@armResourceCreateOrUpdate";
export const armResourceCreateOrUpdateName = "@armResourceCreateOrUpdate";
const armResourceCreateOrUpdateRegex =
  "Azure\\.ResourceManager\\.@armResourceCreateOrUpdate";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armResourceAction
export const armResourceAction = "Azure.ResourceManager.@armResourceAction";
export const armResourceActionName = "@armResourceAction";
const armResourceActionRegex = "Azure\\.ResourceManager\\.@armResourceAction";

export const resourceOperationKindKey = "resource-operation-kind";
const collectionActionKind = "CollectionAction";

export function isResourceCollectionAction(
  method: SdkMethod<SdkHttpOperation> | undefined
): boolean {
  return method
    ? getClientOptions(method, resourceOperationKindKey) ===
        collectionActionKind
    : false;
}

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armResourceList
export const armResourceList = "Azure.ResourceManager.@armResourceList";
export const armResourceListName = "@armResourceList";
const armResourceListRegex = "Azure\\.ResourceManager\\.@armResourceList";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armResourceDelete
export const armResourceDelete = "Azure.ResourceManager.@armResourceDelete";
export const armResourceDeleteName = "@armResourceDelete";
const armResourceDeleteRegex = "Azure\\.ResourceManager\\.@armResourceDelete";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armResourceUpdate
export const armResourceUpdate = "Azure.ResourceManager.@armResourceUpdate";
export const armResourceUpdateName = "@armResourceUpdate";
const armResourceUpdateRegex = "Azure\\.ResourceManager\\.@armResourceUpdate";

export const extensionResourceOperationName = "@extensionResourceOperation";
export const legacyExtensionResourceOperationName =
  "@legacyExtensionResourceOperation";
export const legacyResourceOperationName = "@legacyResourceOperation";
export const builtInResourceOperationName = "@builtInResourceOperation";

export const armResourceWithParameter =
  "Azure.ResourceManager.Private.@armResourceWithParameter";
const armResourceWithParameterRegex =
  "Azure\\.ResourceManager\\.Private\\.@armResourceWithParameter";

export const armResourceInternal =
  "Azure.ResourceManager.Private.@armResourceInternal";
export const armResourceInternalName = "@armResourceInternal";
const armResourceInternalRegex =
  "Azure\\.ResourceManager\\.Private\\.@armResourceInternal";

// Custom Azure resource decorator for legacy/converted specs.
// Used by services like TrafficManager that were converted from Swagger to TypeSpec
// and don't use standard ARM resource templates (TrackedResource<T>, ProxyResource<T>).
// Docs: https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#customazureresource
export const customAzureResource =
  "Azure.ResourceManager.Legacy.@customAzureResource";
const customAzureResourceRegex =
  "Azure\\.ResourceManager\\.Legacy\\.@customAzureResource";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#subscriptionresource
export const subscriptionResource =
  "Azure.ResourceManager.@subscriptionResource";
const subscriptionResourceRegex =
  "Azure\\.ResourceManager\\.@subscriptionResource";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#tenantresource
export const tenantResource = "Azure.ResourceManager.@tenantResource";
const tenantResourceRegex = "Azure\\.ResourceManager\\.@tenantResource";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#resourcegroupresource
export const resourceGroupResource =
  "Azure.ResourceManager.@resourceGroupResource";
const resourceGroupResourceRegex =
  "Azure\\.ResourceManager\\.@resourceGroupResource";

// TODO: add this decorator to TCGC
export const resourceMetadata = "Azure.ClientGenerator.Core.@resourceSchema";
const resourceMetadataRegex =
  "Azure\\.ClientGenerator\\.Core\\.@resourceSchema";
export const nonResourceMethodMetadata =
  "Azure.ClientGenerator.Core.@nonResourceMethodSchema";
const nonResourceMethodMetadataRegex =
  "Azure\\.ClientGenerator\\.Core\\.@nonResourceMethodSchema";

// New unified decorator for ARM provider schema
export const armProviderSchema =
  "Azure.ClientGenerator.Core.@armProviderSchema";

export const flattenPropertyDecorator =
  "Azure.ResourceManager.@flattenProperty";

// Synthetic decorator stamped onto InputModelType.Decorators when the user has applied
// a @@clientName override (csharp scope or all scopes) to the underlying TypeSpec model.
// Consumed by Azure.Generator.Management's NameVisitor to suppress automatic renaming
// of resource update models when the user has explicitly chosen a name.
export const hasClientNameOverrideDecorator =
  "Azure.ResourceManager.@hasClientNameOverride";

// https://azure.github.io/typespec-azure/docs/libraries/typespec-client-generator-core/reference/decorators#@Azure.ClientGenerator.Core.clientOption
// Propagated onto InputModelType.Decorators so the management generator can read
// per-model opt-outs (e.g. "disable-safe-flatten") that aren't consumed during
// resource detection in the emitter.
const clientOptionRegex = "Azure\\.ClientGenerator\\.Core\\.@clientOption";

// TypeSpec validation decorators for resource name constraints
const patternRegex = "TypeSpec\\.@pattern";
const minLengthRegex = "TypeSpec\\.@minLength";
const maxLengthRegex = "TypeSpec\\.@maxLength";

export const azureSDKContextOptions: CreateSdkContextOptions = {
  versioning: {
    previewStringRegex: /-preview$/
  },
  additionalDecorators: [
    resourceMetadataRegex,
    nonResourceMethodMetadataRegex,
    armProviderNamespaceRegex,
    armResourceActionRegex,
    armResourceCreateOrUpdateRegex,
    armResourceDeleteRegex,
    armResourceInternalRegex,
    armResourceListRegex,
    armResourceOperationsRegex,
    armResourceUpdateRegex,
    armResourceReadRegex,
    parentResourceRegex,
    resourceGroupResourceRegex,
    singletonRegex,
    subscriptionResourceRegex,
    tenantResourceRegex,
    armResourceWithParameterRegex,
    customAzureResourceRegex,
    clientOptionRegex,
    patternRegex,
    minLengthRegex,
    maxLengthRegex
  ]
};

/**
 * Stamps a marker decorator onto every InputModelType whose underlying TypeSpec model
 * carries a user-supplied `@@clientName` override (csharp scope or unscoped), and onto
 * every InputOperation whose service method has the same override. The management
 * generator's NameVisitor / MockableResourceProvider read this marker to suppress
 * automatic renaming so user-chosen names are preserved.
 *
 * The base C# emitter copies `decorators` into InputModelType via `getAllModelDecorators`,
 * which produces a fresh array, so we must mutate `codeModel.models[].decorators`
 * directly rather than `sdkPackage.models[].decorators`. For operations,
 * `fromSdkServiceMethodOperation` copies `SdkServiceMethod.decorators` by reference
 * into `InputOperation.decorators`, so pushing onto the SdkServiceMethod array works.
 */
export function setHasClientNameOverride(
  codeModel: CodeModel,
  sdkContext: CSharpEmitterContext
): void {
  const sdkModelByKey = new Map<
    string,
    (typeof sdkContext.sdkPackage.models)[number]
  >();
  for (const sdkModel of sdkContext.sdkPackage.models) {
    sdkModelByKey.set(`${sdkModel.namespace}.${sdkModel.name}`, sdkModel);
  }
  for (const inputModel of codeModel.models) {
    const sdkModel = sdkModelByKey.get(
      `${inputModel.namespace}.${inputModel.name}`
    );
    const raw = sdkModel?.__raw;
    if (!raw) {
      continue;
    }
    const override = getClientNameOverride(sdkContext, raw, "csharp");
    if (override === undefined) {
      continue;
    }
    inputModel.decorators ??= [];
    const marker: DecoratorInfo = {
      name: hasClientNameOverrideDecorator,
      arguments: {}
    };
    inputModel.decorators.push(marker);
  }

  for (const sdkClient of getAllSdkClients(sdkContext)) {
    for (const sdkMethod of sdkClient.methods) {
      const raw = sdkMethod.__raw;
      if (!raw) {
        continue;
      }
      const override = getClientNameOverride(sdkContext, raw, "csharp");
      if (override === undefined) {
        continue;
      }
      sdkMethod.decorators ??= [];
      sdkMethod.decorators.push({
        name: hasClientNameOverrideDecorator,
        arguments: {}
      });
    }
  }
}
