// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  CodeModel,
  CSharpEmitterContext,
  InputClient,
  InputModelType
} from "@typespec/http-client-csharp";
import {
  NonResourceMethod,
  ResourceMetadata,
  ResourceMethod,
  ResourceOperationKind,
  ResourceScopeKind,
  ArmScopeInfo,
  ArmProviderSchema,
  ArmResourceSchema,
  ValidArmResourceSchema,
  convertArmProviderSchemaToArguments,
  expandArmResources,
  ParentResourceLookupContext,
  resolveResourceApiVersions,
  extractRbacRoles,
  findLongestPrefixMatch,
  isResourceInstancePath,
  sortResourceMethods,
  RequestPath,
  extractNameConstraintOverrides,
  getSingletonResourceNameFromPath,
  resolveFixedEnumNameSegments
} from "./resource-metadata.js";
import {
  SdkHttpOperation,
  SdkMethod,
  SdkModelType
} from "@azure-tools/typespec-client-generator-core";
import pluralize from "pluralize";
import {
  armProviderSchema,
  armResourceInternal,
  armResourceWithParameter,
  builtInResourceOperationName,
  customAzureResource,
  extensionResourceOperationName,
  legacyExtensionResourceOperationName,
  legacyResourceOperationName
} from "./sdk-context-options.js";
import {
  DecoratorApplication,
  Model,
  NoTarget,
  getPattern,
  getMinLength,
  getMaxLength
} from "@typespec/compiler";
import { resolveArmResources } from "./resolve-arm-resources-converter.js";
import { AzureMgmtEmitterOptions } from "./options.js";
import { getAllSdkClients, traverseClient } from "./sdk-client-utils.js";
import { $lib } from "./lib/lib.js";

export async function updateClients(
  codeModel: CodeModel,
  sdkContext: CSharpEmitterContext,
  options: AzureMgmtEmitterOptions
) {
  let armProviderSchema: ArmProviderSchema;

  if (options?.["use-legacy-resource-detection"] === false) {
    armProviderSchema = resolveArmResources(sdkContext.program, sdkContext);
  } else {
    armProviderSchema = buildArmProviderSchema(sdkContext, codeModel);
  }

  applyArmProviderSchemaDecorator(codeModel, armProviderSchema);
}

/**
 * Builds the path-driven ARM provider schema described in
 * `docs/resource-detection.md` from TypeSpec resource model annotations,
 * resource instance paths, and HTTP verbs.
 *
 * @param sdkContext - The emitter context
 * @param codeModel - The code model to analyze
 * @returns The unified ARM provider schema containing all resources and non-resource methods
 */
export function buildArmProviderSchema(
  sdkContext: CSharpEmitterContext,
  codeModel: CodeModel
): ArmProviderSchema {
  const serviceMethods = new Map<string, SdkMethod<SdkHttpOperation>>(
    getAllSdkClients(sdkContext)
      .flatMap((c) => c.methods)
      .map((obj) => [obj.crossLanguageDefinitionId, obj])
  );
  const models = new Map<string, SdkModelType>(
    sdkContext.sdkPackage.models.map((m) => [m.crossLanguageDefinitionId, m])
  );

  // Step 1: candidate resource models.
  const resourceModels = getAllResourceModels(codeModel);
  const resourceModelMap = new Map<string, InputModelType>(
    resourceModels.map((m) => [m.crossLanguageDefinitionId, m])
  );
  const resourceModelIds = new Set<string>(
    resourceModels.map((m) => m.crossLanguageDefinitionId)
  );

  // Flatten every (client, method) pair we will visit, in client order.
  const clients = getAllClients(codeModel);
  const allEntries: Array<{ client: InputClient; method: any }> = [];
  for (const client of clients) {
    for (const method of client.methods) {
      allEntries.push({ client, method });
    }
  }

  // Step 2a: locate GETs whose direct response is a candidate model. Each
  // such GET path becomes an instance path. Multiple GETs returning the same
  // model produce multiple instance paths (multi-path resource).
  type ResourceEntry = {
    modelId: string;
    instancePath: RequestPath;
    client: InputClient;
    methods: Array<{
      methodId: string;
      kind: ResourceOperationKind;
      operationPath: RequestPath;
    }>;
    explicitResourceName?: string;
    singletonResourceName?: string;
  };
  const resourceEntries: ResourceEntry[] = [];
  const consumedMethodIds = new Set<string>();

  for (const { client, method } of allEntries) {
    const sdkMethod = serviceMethods.get(method.crossLanguageDefinitionId);
    if (!sdkMethod) continue;
    if (sdkMethod.operation?.verb !== "get") continue;
    const respModelId = getDirectResponseModelId(sdkMethod);
    if (!respModelId || !resourceModelIds.has(respModelId)) continue;

    const rawPath = new RequestPath(method.operation.path);
    if (!isResourceInstancePath(sdkMethod, rawPath)) continue;
    const path = resolveFixedEnumNameSegments(sdkMethod, rawPath);

    const entry: ResourceEntry = {
      modelId: respModelId,
      instancePath: path,
      client,
      methods: [],
      explicitResourceName: getExplicitResourceName(sdkMethod),
      singletonResourceName: getSingletonResourceNameFromPath(
        sdkMethod,
        rawPath
      )
    };
    resourceEntries.push(entry);
    entry.methods.push({
      methodId: method.crossLanguageDefinitionId,
      kind: ResourceOperationKind.Read,
      operationPath: path
    });
    consumedMethodIds.add(method.crossLanguageDefinitionId);
  }

  const identifiedResourceModelIds = new Set(
    resourceEntries.map((entry) => entry.modelId)
  );
  const unassociatedResourceModelIds = new Set(resourceModelIds);
  for (const modelId of unassociatedResourceModelIds) {
    if (identifiedResourceModelIds.has(modelId)) {
      continue;
    }
    const modelName =
      resourceModelMap.get(modelId)?.name ??
      models.get(modelId)?.name ??
      modelId;
    $lib.reportDiagnostic(sdkContext.program, {
      code: "resource-model-not-associated-with-arm-resource",
      format: { modelName },
      target: NoTarget
    });
  }

  // Step 2b: classify lifecycle methods (PUT/PATCH/DELETE/HEAD) whose path
  // equals an instance path. Verb-based, no decorator consultation.
  for (const { method } of allEntries) {
    if (consumedMethodIds.has(method.crossLanguageDefinitionId)) continue;
    const sdkMethod = serviceMethods.get(method.crossLanguageDefinitionId);
    if (!sdkMethod) continue;
    const verb = sdkMethod.operation?.verb;
    let kind: ResourceOperationKind | undefined;
    switch (verb) {
      case "put":
        kind = ResourceOperationKind.Create;
        break;
      case "patch":
        kind = ResourceOperationKind.Update;
        break;
      case "delete":
        kind = ResourceOperationKind.Delete;
        break;
      case "head":
        kind = ResourceOperationKind.CheckExistence;
        break;
      default:
        continue;
    }
    const rawOpPath = new RequestPath(method.operation.path);
    if (!isResourceInstancePath(sdkMethod, rawOpPath)) continue;
    const opPath = resolveFixedEnumNameSegments(sdkMethod, rawOpPath);
    const matched = resourceEntries.find((entry) =>
      entry.instancePath.equals(opPath)
    );
    if (!matched) continue;
    matched.explicitResourceName ??= getExplicitResourceName(sdkMethod);
    matched.methods.push({
      methodId: method.crossLanguageDefinitionId,
      kind,
      operationPath: opPath
    });
    consumedMethodIds.add(method.crossLanguageDefinitionId);
  }

  // Build the ArmResourceSchema list from collected entries.
  const resources: ArmResourceSchema[] = [];
  const resourcePathToClientName = new Map<string, string>();
  const resourcePathToExplicitName = new Map<string, string>();
  for (const entry of resourceEntries) {
    const model = resourceModelMap.get(entry.modelId);
    resourcePathToClientName.set(entry.instancePath.path, entry.client.name);
    if (entry.explicitResourceName) {
      resourcePathToExplicitName.set(
        entry.instancePath.path,
        entry.explicitResourceName
      );
    }

    const methods: ResourceMethod[] = entry.methods.map((m) => ({
      methodId: m.methodId,
      kind: m.kind,
      operationPath: m.operationPath,
      scope: buildResourceMethodScope(m.operationPath)
    }));

    const metadata: ResourceMetadata = {
      resourceIdPattern: entry.instancePath,
      resourceType: entry.instancePath.resourceType ?? "",
      singletonResourceName: entry.singletonResourceName,
      scope: {
        kind: ResourceScopeKind.Tenant,
        scopeIdPattern: RequestPath.empty
      },
      methods,
      parentResourceId: undefined,
      parentResourceModelId: undefined,
      resourceName: model?.name ?? "Unknown",
      nameConstraints: {},
      apiVersions: [],
      rbacRoles: []
    };
    // Derive resource scope from its instance path so the post-process step
    // sees the correct scope kind (ResourceGroup / Subscription / ...).
    metadata.scope = buildScopeInfoFromPath(entry.instancePath);
    resources.push({ resourceModelId: entry.modelId, metadata });
  }

  const nonResourceMethodsArray: NonResourceMethod[] = [];

  const reportWarning = (message: string) =>
    sdkContext.program.reportDiagnostic({
      code: "general-warning",
      severity: "warning",
      message,
      target: NoTarget
    });

  // Step 2c: expand resources with dynamic parent type segments before any
  // path-based parent inference runs, so the inference sees concrete paths.
  const { expandedResources } = expandArmResources(resources, {
    serviceMethods,
    diagnosticReporter: reportWarning
  });

  // Step 3: resolve parent relationships by walking up each resource's
  // instance path one `/type/{name}` pair at a time and looking for a detected
  // resource at that path. Top-level resources are represented by their scope
  // rather than by parentResourceId.
  const detectedResources = expandedResources.filter(
    (resource): resource is ValidArmResourceSchema =>
      resource.metadata.resourceIdPattern !== undefined
  );
  const parentLookup = buildPathBasedParentLookup(detectedResources);
  resolveParentRelationships(detectedResources, parentLookup);

  // Multi-path same-model resource name derivation. For a model with multiple
  // detected instance paths, derive each entry's name from its originating
  // client name (singularized).
  const modelIdToResources = new Map<string, ArmResourceSchema[]>();
  for (const r of detectedResources) {
    if (!modelIdToResources.has(r.resourceModelId)) {
      modelIdToResources.set(r.resourceModelId, []);
    }
    modelIdToResources.get(r.resourceModelId)!.push(r);
  }
  for (const [, list] of modelIdToResources) {
    for (const resource of list) {
      const resourcePath = resource.metadata.resourceIdPattern!.path;
      const explicitName = resourcePathToExplicitName.get(resourcePath);
      if (explicitName) {
        resource.metadata.resourceName = explicitName;
        continue;
      }
      if (list.length > 1) {
        const clientName = resourcePathToClientName.get(resourcePath);
        if (clientName) {
          resource.metadata.resourceName = pluralize.singular(clientName);
        }
      }
    }
  }

  // Step 4: assign all operations not consumed by Step 2 as List, Action, or
  // non-resource methods.
  assignRemainingOperations(
    detectedResources,
    nonResourceMethodsArray,
    allEntries,
    consumedMethodIds,
    serviceMethods,
    identifiedResourceModelIds
  );

  // Fill metadata that depends on the resource model or final method set.
  for (const resource of detectedResources) {
    const sdkModel = models.get(resource.resourceModelId);
    const typespecModel = sdkModel?.__raw as Model | undefined;
    const nameProperty = typespecModel?.properties.get("name");
    const rawPattern = nameProperty
      ? getPattern(sdkContext.program, nameProperty)
      : undefined;
    resource.metadata.nameConstraints = {
      pattern: rawPattern || undefined,
      minLength: nameProperty
        ? getMinLength(sdkContext.program, nameProperty)
        : undefined,
      maxLength: nameProperty
        ? getMaxLength(sdkContext.program, nameProperty)
        : undefined
    };
    const overrides = extractNameConstraintOverrides(sdkModel);
    if (overrides) {
      resource.metadata.nameConstraints = {
        pattern: overrides.pattern ?? resource.metadata.nameConstraints.pattern,
        minLength:
          overrides.minLength ?? resource.metadata.nameConstraints.minLength,
        maxLength:
          overrides.maxLength ?? resource.metadata.nameConstraints.maxLength
      };
    }
    resource.metadata.rbacRoles = extractRbacRoles(sdkModel);
    resource.metadata.apiVersions = resolveResourceApiVersions(
      resource.metadata.methods,
      serviceMethods
    );
  }

  return {
    resources: detectedResources,
    nonResourceMethods: nonResourceMethodsArray
  };
}

/**
 * Returns the response model id for a non-paging method, or undefined when the
 * method is pageable or returns a non-model type. Lro single-response methods
 * count: their `response.type` is the final model, not an array.
 */
function getDirectResponseModelId(
  method: SdkMethod<SdkHttpOperation>
): string | undefined {
  if (method.kind === "paging" || method.kind === "lropaging") return undefined;
  const t = method.response?.type;
  if (t?.kind === "model") {
    return (t as SdkModelType).crossLanguageDefinitionId;
  }
  return undefined;
}

/**
 * Returns the page-item model id for a pageable method, or undefined when the
 * method is not pageable or returns a non-model item type.
 */
function getPagingItemModelIdLocal(
  method: SdkMethod<SdkHttpOperation>
): string | undefined {
  if (method.kind !== "paging" && method.kind !== "lropaging") return undefined;
  const r = method.response?.type;
  if (r?.kind === "array" && r.valueType.kind === "model") {
    return (r.valueType as SdkModelType).crossLanguageDefinitionId;
  }
  return undefined;
}

function buildResourceMethodScope(operationPath: RequestPath): ArmScopeInfo {
  const scope = buildScopeInfoFromPath(operationPath);
  return {
    ...scope,
    scopeIdPattern: operationPath
  };
}

function resolveParentRelationships(
  resources: ValidArmResourceSchema[],
  parentLookup: ParentResourceLookupContext
): void {
  for (const resource of resources) {
    const parent = parentLookup.getParentResource(resource);
    if (!parent?.metadata.resourceIdPattern) continue;

    resource.metadata.parentResourceId = parent.metadata.resourceIdPattern;
    resource.metadata.parentResourceModelId = parent.resourceModelId;
  }
}

function assignRemainingOperations(
  resources: ValidArmResourceSchema[],
  nonResourceMethods: NonResourceMethod[],
  allEntries: Array<{ method: any }>,
  consumedMethodIds: Set<string>,
  serviceMethods: Map<string, SdkMethod<SdkHttpOperation>>,
  identifiedResourceModelIds: ReadonlySet<string>
): void {
  for (const { method } of allEntries) {
    const methodId = method.crossLanguageDefinitionId;
    if (consumedMethodIds.has(methodId)) continue;

    const sdkMethod = serviceMethods.get(methodId);
    const rawOperationPath = new RequestPath(method.operation.path);
    const operationPath = sdkMethod
      ? resolveFixedEnumNameSegments(sdkMethod, rawOperationPath)
      : rawOperationPath;
    const itemModelId =
      sdkMethod?.operation?.verb === "get"
        ? getPagingItemModelIdLocal(sdkMethod)
        : undefined;
    const listTarget =
      itemModelId && identifiedResourceModelIds.has(itemModelId)
        ? findListTargetResource(resources, operationPath, itemModelId)
        : undefined;
    const actionTarget = listTarget
      ? undefined
      : findLongestPrefixMatch(
          operationPath,
          resources,
          (resource) => resource.metadata.resourceIdPattern
        );

    if (listTarget) {
      listTarget.metadata.methods.push({
        methodId,
        kind: ResourceOperationKind.List,
        operationPath,
        scope: buildListOperationScope(resources, operationPath)
      });
    } else if (actionTarget) {
      const scope = buildScopeInfoFromPath(operationPath);
      actionTarget.metadata.methods.push({
        methodId,
        kind: ResourceOperationKind.Action,
        operationPath,
        scope: {
          ...scope,
          scopeIdPattern: actionTarget.metadata.resourceIdPattern
        }
      });
    } else {
      nonResourceMethods.push({
        methodId,
        operationPath,
        scope: buildScopeInfoFromPath(operationPath)
      });
    }
    consumedMethodIds.add(methodId);
  }

  for (const resource of resources) {
    sortResourceMethods(resource.metadata.methods);
  }
}

function findListTargetResource(
  resources: ValidArmResourceSchema[],
  operationPath: RequestPath,
  itemModelId: string
): ValidArmResourceSchema | undefined {
  const candidates = resources.filter(
    (resource) => resource.resourceModelId === itemModelId
  );

  const exactCollectionMatches = candidates.filter(
    (resource) =>
      resource.metadata.resourceIdPattern.trimLastSegment?.equals(operationPath)
  );
  if (exactCollectionMatches.length > 0) {
    return shortestResourcePath(exactCollectionMatches);
  }

  const operationType = operationPath.resourceType;
  if (operationType === undefined) return undefined;

  const scopeCollectionMatches = candidates.filter(
    (resource) =>
      resource.metadata.resourceType === operationType &&
      operationPath.hasSameScopeNesting(resource.metadata.resourceIdPattern) &&
      operationPathEndsWithResourceType(operationPath, operationType)
  );
  return shortestResourcePath(scopeCollectionMatches);
}

function shortestResourcePath(
  resources: ValidArmResourceSchema[]
): ValidArmResourceSchema | undefined {
  return resources
    .slice()
    .sort(
      (a, b) =>
        a.metadata.resourceIdPattern.length -
        b.metadata.resourceIdPattern.length
    )[0];
}

function buildListOperationScope(
  resources: ValidArmResourceSchema[],
  operationPath: RequestPath
): ArmScopeInfo {
  const scope = buildScopeInfoFromPath(operationPath);
  const parentResourcePath = resources
    .map((resource) => resource.metadata.resourceIdPattern)
    .filter((resourcePath) => resourcePath.isPrefixOf(operationPath))
    .sort((a, b) => b.length - a.length)[0];

  return parentResourcePath
    ? {
        ...scope,
        scopeIdPattern: parentResourcePath
      }
    : scope;
}

function operationPathEndsWithResourceType(
  operationPath: RequestPath,
  resourceType: string
): boolean {
  const lastTypeSegment = resourceType.split("/").at(-1);
  return (
    lastTypeSegment !== undefined &&
    operationPath.segments[operationPath.length - 1] === lastTypeSegment
  );
}

// Only legacy/built-in operation decorators carry an explicit resource name.
function getExplicitResourceName(
  method: SdkMethod<SdkHttpOperation> | undefined
): string | undefined {
  for (const decorator of method?.__raw?.decorators ?? []) {
    switch (decorator.definition?.name) {
      case extensionResourceOperationName:
        return getStringLiteralArg(decorator, 3);
      case legacyExtensionResourceOperationName:
      case legacyResourceOperationName:
        return getStringLiteralArg(decorator, 2);
      case builtInResourceOperationName:
        return getStringLiteralArg(decorator, 3);
    }
  }
  return undefined;
}

function getStringLiteralArg(
  decorator: DecoratorApplication,
  index: number
): string | undefined {
  const value = decorator.args[index]?.jsValue;
  return typeof value === "string" && value.length > 0 ? value : undefined;
}

/**
 * Path-based parent lookup. Walks the resource's instance path up one
 * `/type/{name}` pair at a time, returning the first detected resource whose
 * instance path equals the walked-up candidate.
 */
function buildPathBasedParentLookup(
  expanded: ArmResourceSchema[]
): ParentResourceLookupContext {
  return {
    getParentResource(
      resource: ArmResourceSchema
    ): ArmResourceSchema | undefined {
      const path = resource.metadata.resourceIdPattern;
      if (!path || path.length < 2) return undefined;
      let segments = path.segments.slice(0, -2);
      while (segments.length >= 2) {
        const candidate = RequestPath.fromSegments(segments);
        for (const r of expanded) {
          if (r === resource) continue;
          const rp = r.metadata.resourceIdPattern;
          if (rp && rp.equals(candidate)) {
            return r;
          }
        }
        // Step up another `/type/{name}` pair (tuple-style ancestor walk).
        segments = segments.slice(0, -2);
      }
      return undefined;
    }
  };
}

export function getAllClients(codeModel: CodeModel): InputClient[] {
  const clients: InputClient[] = [];
  for (const client of codeModel.clients) {
    traverseClient(client, clients);
  }

  return clients;
}

/**
 * Checks if a model or any of its base models has the @customAzureResource decorator.
 *
 * The @customAzureResource decorator (Azure.ResourceManager.Legacy.@customAzureResource) is used
 * for ARM resources that don't follow standard ARM resource templates. This is commonly used for:
 * - Legacy services that were converted from Swagger to TypeSpec (e.g., TrafficManager)
 * - Services with custom resource hierarchies that don't fit standard ARM patterns
 *
 * Unlike standard ARM resources that use TrackedResource<T> or ProxyResource<T> templates
 * (which automatically get @armResourceInternal decorator), custom resources define their own
 * base Resource model with this decorator.
 *
 * @see https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#customazureresource
 *
 * @param model - The model to check for @customAzureResource decorator
 * @returns true if the model or any ancestor has @customAzureResource decorator
 */
function hasCustomAzureResourceInHierarchy(model: InputModelType): boolean {
  let current: InputModelType | undefined = model;
  while (current) {
    if (current.decorators?.some((d) => d.name === customAzureResource)) {
      return true;
    }
    current = current.baseModel;
  }
  return false;
}

/**
 * Collects all models that represent ARM resources from the code model.
 *
 * ARM resources are detected in two ways:
 *
 * 1. **Standard ARM resources**: Models that use standard ARM templates like TrackedResource<T>
 *    or ProxyResource<T>. These models have @armResourceInternal or @armResourceWithParameter
 *    decorators applied automatically by the typespec-azure-resource-manager library.
 *
 * 2. **Custom Azure resources**: Models that inherit from a custom base Resource model decorated
 *    with @customAzureResource. This pattern is used by legacy services (e.g., TrafficManager)
 *    that were converted from Swagger to TypeSpec and don't fit standard ARM templates.
 *
 * @param codeModel - The code model containing all models
 * @returns Array of resource models
 */
function getAllResourceModels(codeModel: CodeModel): InputModelType[] {
  const resourceModels: InputModelType[] = [];

  for (const model of codeModel.models) {
    // Check for armResource decorators
    if (
      model.decorators?.some(
        (d) =>
          d.name == armResourceInternal || d.name == armResourceWithParameter
      )
    ) {
      resourceModels.push(model);
    }
    // 2. Custom Azure resources: Models inheriting from a @customAzureResource base model
    //    Used by legacy services like TrafficManager that don't use standard ARM templates
    else if (hasCustomAzureResourceInHierarchy(model)) {
      resourceModels.push(model);
    }
  }
  return resourceModels;
}

/**
 * Builds an ArmScopeInfo from an operation path.
 * Extracts the scope ID pattern and resource type from the path's scope portion.
 */
export function buildScopeInfoFromPath(
  operationPath: RequestPath
): ArmScopeInfo {
  return buildScopeInfo(operationPath.operationScope, operationPath.scopePath);
}

/**
 * Builds an ArmScopeInfo from a scope kind and scope path.
 * Computes scopeResourceType from the scope path when it's concrete (no variable segments).
 */
export function buildScopeInfo(
  kind: ResourceScopeKind,
  scopePath: RequestPath
): ArmScopeInfo {
  const resourceType = scopePath.resourceType;
  return {
    kind,
    scopeIdPattern: scopePath,
    // Only include scopeResourceType when it's concrete (no variable segments)
    scopeResourceType:
      resourceType !== undefined && !resourceType.includes("{")
        ? resourceType
        : undefined
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
  // It's technically allowed to have no clients, so we just return early in that case
  if (!codeModel.clients || codeModel.clients.length === 0) {
    return;
  }
  const rootClient = codeModel.clients[0];
  rootClient.decorators ??= [];
  rootClient.decorators.push({
    name: armProviderSchema,
    arguments: convertArmProviderSchemaToArguments(schema)
  });
}
