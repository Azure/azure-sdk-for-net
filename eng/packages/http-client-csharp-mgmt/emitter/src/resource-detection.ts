// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  CodeModel,
  CSharpEmitterContext,
  InputClient,
  InputModelType
} from "@typespec/http-client-csharp";
import {
  calculateResourceTypeFromPath,
  convertArmProviderSchemaToArguments,
  NonResourceMethod,
  ResourceMetadata,
  ResourceMethod,
  ResourceOperationKind,
  ResourceScope,
  ArmProviderSchema,
  ArmResourceSchema
} from "./resource-metadata.js";
import {
  DecoratorInfo,
  getClientType,
  SdkClientType,
  SdkContext,
  SdkHttpOperation,
  SdkMethod,
  SdkModelType,
  SdkServiceOperation
} from "@azure-tools/typespec-client-generator-core";
import {
  armResourceActionName,
  armResourceCreateOrUpdateName,
  armResourceDeleteName,
  armResourceInternal,
  armResourceListName,
  armResourceReadName,
  armResourceUpdateName,
  armResourceWithParameter,
  extensionResourceOperationName,
  legacyExtensionResourceOperationName,
  legacyResourceOperationName,
  builtInResourceOperationName,
  parentResourceName,
  readsResourceName,
  resourceGroupResource,
  singleton,
  subscriptionResource,
  tenantResource,
  armProviderSchema
} from "./sdk-context-options.js";
import { DecoratorApplication, Model, NoTarget } from "@typespec/compiler";
import { AzureEmitterOptions } from "@azure-typespec/http-client-csharp";

export async function updateClients(
  codeModel: CodeModel,
  sdkContext: CSharpEmitterContext
) {
  // Detect and collect ARM resource information
  const { resourceModels, resourceModelToMetadataMap, nonResourceMethods } =
    detectArmResourcesAndMethods(sdkContext, codeModel);

  // Build the unified ARM provider schema
  const armProviderSchema = buildArmProviderSchema(
    sdkContext,
    resourceModels,
    resourceModelToMetadataMap,
    nonResourceMethods
  );

  // Apply the unified decorator to the root client
  applyArmProviderSchemaDecorator(codeModel, armProviderSchema);
}

/**
 * Detects ARM resources and methods from the code model.
 * This function processes all clients and methods to identify resource operations,
 * populates metadata including resource ID patterns, types, and scopes.
 *
 * @param sdkContext - The emitter context
 * @param codeModel - The code model to process
 * @returns Object containing resource models, metadata map, and non-resource methods
 */
function detectArmResourcesAndMethods(
  sdkContext: CSharpEmitterContext,
  codeModel: CodeModel
): {
  resourceModels: InputModelType[];
  resourceModelToMetadataMap: Map<string, ResourceMetadata>;
  nonResourceMethods: Map<string, NonResourceMethod>;
} {
  const serviceMethods = new Map<string, SdkMethod<SdkHttpOperation>>(
    getAllSdkClients(sdkContext)
      .flatMap((c) => c.methods)
      .map((obj) => [obj.crossLanguageDefinitionId, obj])
  );
  const models = new Map<string, SdkModelType>(
    sdkContext.sdkPackage.models.map((m) => [m.crossLanguageDefinitionId, m])
  );
  const resourceModels = getAllResourceModels(codeModel);
  const resourceModelMap = new Map<string, InputModelType>(
    resourceModels.map((m) => [m.crossLanguageDefinitionId, m])
  );

  const resourceModelToMetadataMap = new Map<string, ResourceMetadata>(
    resourceModels.map((m) => [
      m.crossLanguageDefinitionId,
      {
        resourceIdPattern: "", // this will be populated later
        resourceType: "", // this will be populated later
        singletonResourceName: getSingletonResource(
          m.decorators?.find((d) => d.name == singleton)
        ),
        resourceScope: ResourceScope.Tenant, // temporary default to Tenant, will be properly set later after methods are populated
        methods: [],
        parentResourceId: undefined, // this will be populated later
        parentResourceModelId: undefined,
        resourceName: m.name
      } as ResourceMetadata
    ])
  );
  const nonResourceMethods: Map<string, NonResourceMethod> = new Map();

  // first we flatten all possible clients in the code model
  const clients = getAllClients(codeModel);

  // then we iterate over all the clients and their methods to find the resource operations
  // and add them to the resource model metadata
  // during the process we populate the resourceIdPattern and resourceType
  for (const client of clients) {
    for (const method of client.methods) {
      const serviceMethod = serviceMethods.get(
        method.crossLanguageDefinitionId
      );
      const [kind, modelId] =
        parseResourceOperation(serviceMethod, sdkContext) ?? [];

      if (modelId && kind) {
        const entry = resourceModelToMetadataMap.get(modelId);
        if (entry) {
          entry.methods.push({
            methodId: method.crossLanguageDefinitionId,
            kind,
            operationPath: method.operation.path,
            operationScope: getOperationScope(method.operation.path)
          });
          if (!entry.resourceType) {
            entry.resourceType = calculateResourceTypeFromPath(
              method.operation.path
            );
          }
          if (!entry.resourceIdPattern && isCRUDKind(kind)) {
            entry.resourceIdPattern = method.operation.path;
          }
        } else {
          // no resource model found for this modelId, treat as non-resource method
          nonResourceMethods.set(method.crossLanguageDefinitionId, {
            methodId: method.crossLanguageDefinitionId,
            operationPath: method.operation.path,
            operationScope: getOperationScope(method.operation.path)
          });
        }
      } else {
        // we add a methodMetadata decorator to this method
        nonResourceMethods.set(method.crossLanguageDefinitionId, {
          methodId: method.crossLanguageDefinitionId,
          operationPath: method.operation.path,
          operationScope: getOperationScope(method.operation.path)
        });
      }
    }
  }

  // after the resourceIdPattern has been populated, we can set the parentResourceId and the resource scope of each resource method
  for (const [modelId, metadata] of resourceModelToMetadataMap) {
    // get parent resource model id
    const parentResourceModelId = getParentResourceModelId(
      sdkContext,
      models.get(modelId)
    );
    if (parentResourceModelId) {
      metadata.parentResourceId = resourceModelToMetadataMap.get(
        parentResourceModelId
      )?.resourceIdPattern;
      metadata.parentResourceModelId = parentResourceModelId;
    }

    // figure out the resourceScope of all resource methods
    for (const method of metadata.methods) {
      method.resourceScope = getResourceScopeOfMethod(
        method.operationPath,
        resourceModelToMetadataMap.values()
      );
    }

    // update the model's resourceScope based on resource scope decorator if it exists or based on the Get method's scope. If neither exist, it will be set to ResourceGroup by default
    const model = resourceModelMap.get(modelId);
    if (model) {
      metadata.resourceScope = getResourceScope(model, metadata.methods);
    }
  }

  // after the parentResourceId and resource scopes are populated, we can reorganize the metadata that is missing resourceIdPattern
  for (const [modelId, metadata] of resourceModelToMetadataMap) {
    if (metadata.resourceIdPattern === "") {
      if (metadata.parentResourceModelId) {
        // If there's a parent, move methods to parent and delete this resource
        resourceModelToMetadataMap
          .get(metadata.parentResourceModelId)
          ?.methods.push(...metadata.methods);
        resourceModelToMetadataMap.delete(modelId);
      } else {
        // If there's no parent, treat all methods as non-resource methods
        for (const method of metadata.methods) {
          nonResourceMethods.set(method.methodId, {
            methodId: method.methodId,
            operationPath: method.operationPath,
            operationScope: method.operationScope
          });
        }
        resourceModelToMetadataMap.delete(modelId);
      }
    }
  }

  return {
    resourceModels,
    resourceModelToMetadataMap,
    nonResourceMethods
  };
}

function isCRUDKind(kind: ResourceOperationKind): boolean {
  return [
    ResourceOperationKind.Get,
    ResourceOperationKind.Create,
    ResourceOperationKind.Update,
    ResourceOperationKind.Delete
  ].includes(kind);
}

function parseResourceOperation(
  serviceMethod: SdkMethod<SdkHttpOperation> | undefined,
  sdkContext: CSharpEmitterContext
): [ResourceOperationKind, string | undefined] | undefined {
  const decorators = serviceMethod?.__raw?.decorators;
  for (const decorator of decorators ?? []) {
    switch (decorator.definition?.name) {
      case readsResourceName:
      case armResourceReadName:
        return [
          ResourceOperationKind.Get,
          getResourceModelId(sdkContext, decorator)
        ];
      case armResourceCreateOrUpdateName:
        return [
          ResourceOperationKind.Create,
          getResourceModelId(sdkContext, decorator)
        ];
      case armResourceUpdateName:
        return [
          ResourceOperationKind.Update,
          getResourceModelId(sdkContext, decorator)
        ];
      case armResourceDeleteName:
        return [
          ResourceOperationKind.Delete,
          getResourceModelId(sdkContext, decorator)
        ];
      case armResourceListName:
        return [
          ResourceOperationKind.List,
          getResourceModelId(sdkContext, decorator)
        ];
      case armResourceActionName:
        return [
          ResourceOperationKind.Action,
          getResourceModelId(sdkContext, decorator)
        ];
      case extensionResourceOperationName:
        switch (decorator.args[2].jsValue) {
          case "read":
            return [
              ResourceOperationKind.Get,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              )
            ];
          case "createOrUpdate":
            return [
              ResourceOperationKind.Create,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              )
            ];
          case "update":
            return [
              ResourceOperationKind.Update,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              )
            ];
          case "delete":
            return [
              ResourceOperationKind.Delete,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              )
            ];
          case "list":
            return [
              ResourceOperationKind.List,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              )
            ];
          case "action":
            return [
              ResourceOperationKind.Action,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              )
            ];
        }
        break;
      case legacyExtensionResourceOperationName:
      case legacyResourceOperationName:
        switch (decorator.args[1].jsValue) {
          case "read":
            return [
              ResourceOperationKind.Get,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              )
            ];
          case "createOrUpdate":
            return [
              ResourceOperationKind.Create,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              )
            ];
          case "update":
            return [
              ResourceOperationKind.Update,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              )
            ];
          case "delete":
            return [
              ResourceOperationKind.Delete,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              )
            ];
          case "list":
            return [
              ResourceOperationKind.List,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              )
            ];
          case "action":
            return [
              ResourceOperationKind.Action,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[0].value as Model,
                decorator.definition?.name
              )
            ];
        }
        return undefined;
      case builtInResourceOperationName:
        switch (decorator.args[2].jsValue) {
          case "read":
            return [
              ResourceOperationKind.Get,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              )
            ];
          case "createOrUpdate":
            return [
              ResourceOperationKind.Create,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              )
            ];
          case "update":
            return [
              ResourceOperationKind.Update,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              )
            ];
          case "delete":
            return [
              ResourceOperationKind.Delete,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              )
            ];
          case "list":
            return [
              ResourceOperationKind.List,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              )
            ];
          case "action":
            return [
              ResourceOperationKind.Action,
              getResourceModelIdCore(
                sdkContext,
                decorator.args[1].value as Model,
                decorator.definition?.name
              )
            ];
        }
        return undefined;
    }
  }
  return undefined;
}

function getParentResourceModelId(
  sdkContext: CSharpEmitterContext,
  model: SdkModelType | undefined
): string | undefined {
  const decorators = (model?.__raw as Model)?.decorators;
  const parentResourceDecorator = decorators?.find(
    (d) => d.definition?.name == parentResourceName
  );
  return getResourceModelId(sdkContext, parentResourceDecorator);
}

function getResourceModelId(
  sdkContext: CSharpEmitterContext,
  decorator?: DecoratorApplication
): string | undefined {
  if (!decorator) return undefined;
  return getResourceModelIdCore(
    sdkContext,
    decorator.args[0].value as Model,
    decorator.definition?.name
  );
}

function getResourceModelIdCore(
  sdkContext: CSharpEmitterContext,
  decoratorModel: Model,
  decoratorName?: string
): string | undefined {
  const model = getClientType(sdkContext, decoratorModel) as SdkModelType;
  if (model) {
    return model.crossLanguageDefinitionId;
  } else {
    sdkContext.logger.reportDiagnostic({
      code: "general-error",
      messageId: "default",
      format: {
        message: `Resource model not found for decorator ${decoratorName}`
      },
      target: NoTarget
    });
    return undefined;
  }
}

export function getAllSdkClients(
  sdkContext: SdkContext<AzureEmitterOptions, SdkHttpOperation>
): SdkClientType<SdkServiceOperation>[] {
  const clients: SdkClientType<SdkServiceOperation>[] = [];
  for (const client of sdkContext.sdkPackage.clients) {
    traverseClient(client, clients);
  }

  return clients;
}

export function getAllClients(codeModel: CodeModel): InputClient[] {
  const clients: InputClient[] = [];
  for (const client of codeModel.clients) {
    traverseClient(client, clients);
  }

  return clients;
}

function traverseClient<T extends { children?: T[] }>(client: T, clients: T[]) {
  clients.push(client);
  if (client.children) {
    for (const child of client.children) {
      traverseClient(child, clients);
    }
  }
}

function getAllResourceModels(codeModel: CodeModel): InputModelType[] {
  const resourceModels: InputModelType[] = [];
  for (const model of codeModel.models) {
    if (model.decorators?.some((d) => d.name == armResourceInternal || d.name == armResourceWithParameter)) {
      resourceModels.push(model);
    }
  }
  return resourceModels;
}

function getSingletonResource(
  decorator: DecoratorInfo | undefined
): string | undefined {
  if (!decorator) return undefined;
  const singletonResource = decorator.arguments["keyValue"] as
    | string
    | undefined;
  return singletonResource ?? "default";
}

function getResourceScope(
  model: InputModelType,
  methods?: ResourceMethod[]
): ResourceScope {
  // First, check for explicit scope decorators
  const decorators = model.decorators;
  if (decorators?.some((d) => d.name == tenantResource)) {
    return ResourceScope.Tenant;
  } else if (decorators?.some((d) => d.name == subscriptionResource)) {
    return ResourceScope.Subscription;
  } else if (decorators?.some((d) => d.name == resourceGroupResource)) {
    return ResourceScope.ResourceGroup;
  }

  // Fall back to Get method's scope only if no scope decorators are found
  if (methods) {
    const getMethod = methods.find((m) => m.kind === ResourceOperationKind.Get);
    if (getMethod) {
      return getMethod.operationScope;
    }
  }

  // Final fallback to ResourceGroup
  return ResourceScope.ResourceGroup; // all the templates work as if there is a resource group decorator when there is no such decorator
}

function getResourceScopeOfMethod(
  path: string,
  resources: MapIterator<ResourceMetadata>
): string | undefined {
  // loop all possible resource metadata and see if some of them match the operation path of this method as a prefix
  const candidates: string[] = [];
  for (const otherMetadata of resources) {
    if (
      otherMetadata.resourceIdPattern &&
      path.startsWith(otherMetadata.resourceIdPattern)
    ) {
      candidates.push(otherMetadata.resourceIdPattern);
    }
  }
  // finds the longest resource path id in candidates as the resource scope
  if (candidates.length > 0) {
    return candidates.reduce((a, b) => (a.length > b.length ? a : b));
  }
  return undefined;
}

function getOperationScope(path: string): ResourceScope {
  if (path.startsWith("/{resourceUri}") || path.startsWith("/{scope}")) {
    return ResourceScope.Extension;
  } else if (
    path.startsWith(
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/"
    )
  ) {
    return ResourceScope.ResourceGroup;
  } else if (path.startsWith("/subscriptions/{subscriptionId}/")) {
    return ResourceScope.Subscription;
  } else if (
    path.startsWith(
      "/providers/Microsoft.Management/managementGroups/{managementGroupId}/"
    )
  ) {
    return ResourceScope.ManagementGroup;
  }
  return ResourceScope.Tenant; // all the templates work as if there is a tenant decorator when there is no such decorator
}

/**
 * Builds the unified ARM provider schema from resource metadata and non-resource methods.
 * @param sdkContext - The emitter context for logging
 * @param resourceModels - All resource models in the code model
 * @param resourceModelToMetadataMap - Map of resource model IDs to their metadata
 * @param nonResourceMethods - Map of non-resource method IDs to their metadata
 * @returns The complete ARM provider schema
 */
function buildArmProviderSchema(
  sdkContext: CSharpEmitterContext,
  resourceModels: InputModelType[],
  resourceModelToMetadataMap: Map<string, ResourceMetadata>,
  nonResourceMethods: Map<string, NonResourceMethod>
): ArmProviderSchema {
  const resources: ArmResourceSchema[] = [];

  // Build resource schemas from the metadata map
  for (const model of resourceModels) {
    const metadata = resourceModelToMetadataMap.get(
      model.crossLanguageDefinitionId
    );
    if (metadata) {
      if (metadata.resourceIdPattern === "") {
        sdkContext.logger.reportDiagnostic({
          code: "general-warning",
          messageId: "default",
          format: {
            message: `Cannot figure out resourceIdPattern from model ${model.name}.`
          },
          target: NoTarget
        });
        continue;
      }

      resources.push({
        resourceModelId: model.crossLanguageDefinitionId,
        metadata: metadata
      });
    }
  }

  return {
    resources: resources,
    nonResourceMethods: Array.from(nonResourceMethods.values())
  };
}

/**
 * Applies the ARM provider schema as a decorator to the root client.
 * @param codeModel - The code model to update
 * @param schema - The ARM provider schema to apply
 */
function applyArmProviderSchemaDecorator(
  codeModel: CodeModel,
  schema: ArmProviderSchema
): void {
  const rootClient = codeModel.clients[0];
  rootClient.decorators ??= [];
  rootClient.decorators.push({
    name: armProviderSchema,
    arguments: convertArmProviderSchemaToArguments(schema)
  });
}


