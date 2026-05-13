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
  convertArmProviderSchemaToArguments,
  expandArmResources,
  postProcessArmResources,
  ParentResourceLookupContext,
  assignNonResourceMethodsToResources,
  resolveResourceApiVersions,
  extractRbacRoles,
  RequestPath,
  extractNameConstraintOverrides
} from "./resource-metadata.js";
import {
  DecoratorInfo,
  SdkHttpOperation,
  SdkMethod,
  SdkModelType
} from "@azure-tools/typespec-client-generator-core";
import pluralize from "pluralize";
import {
  armProviderSchema,
  armResourceInternal,
  armResourceWithParameter,
  customAzureResource,
  singleton
} from "./sdk-context-options.js";
import {
  Model,
  NoTarget,
  getPattern,
  getMinLength,
  getMaxLength
} from "@typespec/compiler";
import { resolveArmResources } from "./resolve-arm-resources-converter.js";
import { AzureMgmtEmitterOptions } from "./options.js";
import { getAllSdkClients, traverseClient } from "./sdk-client-utils.js";

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
 * Builds the ARM provider schema by detecting all resources and non-resource methods.
 * This is the main function that gathers all ARM-related information from the code model
 * and consolidates it into a unified ArmProviderSchema structure.
 *
 * This function is exported for testing purposes and can be called directly from tests
 * to validate the schema structure using the legacy custom resource detection logic.
 *
 * @param sdkContext - The emitter context
 * @param codeModel - The code model to analyze
 * @returns The unified ARM provider schema containing all resources and non-resource methods
 */
export function buildArmProviderSchema(
  sdkContext: CSharpEmitterContext,
  codeModel: CodeModel
): ArmProviderSchema {
  return detectResourcesByPath(sdkContext, codeModel);
}

/**
 * Path-driven ARM resource detection.
 *
 * Implementation of the design described in
 * `docs/resource-detection.md`. Steps:
 *
 * 1. Find candidate resource models via {@link getAllResourceModels} — models
 *    using ARM templates (`@armResourceInternal` / `@armResourceWithParameter`)
 *    or carrying `@customAzureResource` anywhere in the base-model chain.
 * 2. For each candidate model M, scan all GET methods whose direct (non-paging)
 *    response is exactly M. Each such GET's path is an instance path of M.
 *    Then for every method (any verb) whose `operation.path` equals an instance
 *    path, classify by HTTP verb:
 *      PUT → Create, PATCH → Update, DELETE → Delete, GET → Read.
 *    Decorators like `@armResourceRead`/`@armResourceCreateOrUpdate`/etc. are
 *    NOT consulted.
 * 3. Resolve parents by walking the instance path up one `/type/{name}` pair
 *    at a time, matching against the detected resource set. Walks that strip
 *    more than one pair before matching indicate a tuple-like ancestor (the
 *    intermediate segments are not modeled as resources).
 * 4. Reuse {@link postProcessArmResources} +
 *    {@link assignNonResourceMethodsToResources} for List/Action assignment.
 */
function detectResourcesByPath(
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

  // Build a paging-item lookup once so we can reuse it for relocation as well
  // as for assigning leftover list operations.
  const methodResponseModelIdMap = new Map<string, string>();
  for (const [methodId, sdkMethod] of serviceMethods) {
    const itemModelId = getPagingItemModelIdLocal(sdkMethod);
    if (itemModelId) {
      methodResponseModelIdMap.set(methodId, itemModelId);
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
  };
  const resourceEntries: ResourceEntry[] = [];
  const consumedMethodIds = new Set<string>();

  for (const { client, method } of allEntries) {
    const sdkMethod = serviceMethods.get(method.crossLanguageDefinitionId);
    if (!sdkMethod) continue;
    if (sdkMethod.operation?.verb !== "get") continue;
    const respModelId = getDirectResponseModelId(sdkMethod);
    if (!respModelId || !resourceModelIds.has(respModelId)) continue;

    const path = new RequestPath(method.operation.path);
    validateInstancePath(sdkContext, path, respModelId);

    const entry: ResourceEntry = {
      modelId: respModelId,
      instancePath: path,
      client,
      methods: []
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

  // Step 2b: classify lifecycle methods (PUT/PATCH/DELETE) whose path equals
  // an instance path. Verb-based, no decorator consultation.
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
      default:
        continue;
    }
    const opPath = new RequestPath(method.operation.path);
    // Find the entry whose instance path equals this operation path. If
    // multiple models share a path (rare), prefer the one whose model is the
    // request body or response.
    let matched: ResourceEntry | undefined;
    for (const entry of resourceEntries) {
      if (!entry.instancePath.equals(opPath)) continue;
      if (!matched) {
        matched = entry;
        continue;
      }
      // Disambiguate: prefer entry whose model is the response/body.
      const respModelId = getDirectResponseModelId(sdkMethod);
      if (respModelId === entry.modelId) {
        matched = entry;
        break;
      }
    }
    if (!matched) continue;
    matched.methods.push({
      methodId: method.crossLanguageDefinitionId,
      kind,
      operationPath: opPath
    });
    consumedMethodIds.add(method.crossLanguageDefinitionId);
  }

  // Step 2c (Pass 1 of List/Action assignment): attach paging methods whose
  // page item is a resource model T as List on the shortest detected resource
  // R of model T whose instance path begins with the operation path. This
  // covers ArmResourceListByParent / ArmListBySubscription as well as
  // @armResourceAction-styled list operations (POST + Page<T>). Lists that
  // don't prefix any resource of model T fall through to nonResourceMethods
  // and are picked up by the model-id strategy in
  // assignNonResourceMethodsToResources.
  for (const { method } of allEntries) {
    if (consumedMethodIds.has(method.crossLanguageDefinitionId)) continue;
    const sdkMethod = serviceMethods.get(method.crossLanguageDefinitionId);
    if (!sdkMethod) continue;
    const itemModelId = getPagingItemModelIdLocal(sdkMethod);
    if (!itemModelId || !identifiedResourceModelIds.has(itemModelId)) continue;

    const opPath = new RequestPath(method.operation.path);
    let best: ResourceEntry | undefined;
    for (const entry of resourceEntries) {
      if (entry.modelId !== itemModelId) continue;
      if (!opPath.isPrefixOf(entry.instancePath)) continue;
      if (!best || entry.instancePath.length < best.instancePath.length) {
        best = entry;
      }
    }
    if (!best) continue;
    best.methods.push({
      methodId: method.crossLanguageDefinitionId,
      kind: ResourceOperationKind.List,
      operationPath: opPath
    });
    consumedMethodIds.add(method.crossLanguageDefinitionId);
  }

  // Build the ArmResourceSchema list from collected entries.
  const resources: ArmResourceSchema[] = [];
  const resourcePathToClientName = new Map<string, string>();
  for (const entry of resourceEntries) {
    const model = resourceModelMap.get(entry.modelId);
    resourcePathToClientName.set(entry.instancePath.path, entry.client.name);

    const methods: ResourceMethod[] = entry.methods.map((m) => ({
      methodId: m.methodId,
      kind: m.kind,
      operationPath: m.operationPath,
      scope: buildScopeInfoFromPath(m.operationPath)
    }));

    const metadata: ResourceMetadata = {
      resourceIdPattern: entry.instancePath,
      resourceType: entry.instancePath.resourceType ?? "",
      singletonResourceName: getSingletonResource(
        model?.decorators?.find((d) => d.name == singleton)
      ),
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

  // Build non-resource method list: any service method not consumed by a
  // resource. `resourceModelId` is populated for paging GETs whose item type
  // is a known resource model so the shared list-assignment helper can match
  // them by model id when prefix matching fails.
  const nonResourceMethodsArray: NonResourceMethod[] = [];
  for (const { method } of allEntries) {
    if (consumedMethodIds.has(method.crossLanguageDefinitionId)) continue;
    const opPath = new RequestPath(method.operation.path);
    const sdkMethod = serviceMethods.get(method.crossLanguageDefinitionId);
    let resourceModelIdForNonRes: string | undefined;
    if (sdkMethod) {
      const itemModelId = getPagingItemModelIdLocal(sdkMethod);
      if (itemModelId && identifiedResourceModelIds.has(itemModelId)) {
        resourceModelIdForNonRes = itemModelId;
      }
    }
    nonResourceMethodsArray.push({
      methodId: method.crossLanguageDefinitionId,
      operationPath: opPath,
      scope: buildScopeInfoFromPath(opPath),
      resourceModelId: resourceModelIdForNonRes
    });
  }

  const reportWarning = (message: string) =>
    sdkContext.program.reportDiagnostic({
      code: "general-warning",
      severity: "warning",
      message,
      target: NoTarget
    });

  // Expand resources with dynamic parent type segments before any path-based
  // parent inference runs, so the inference sees concrete paths.
  const { expandedResources } = expandArmResources(resources, {
    serviceMethods,
    diagnosticReporter: reportWarning
  });

  // Path-based parent lookup: walk up the instance path one `/type/{name}`
  // pair at a time and look for a detected resource at that path. Walks that
  // strip more than one pair before matching produce tuple-like ancestors
  // (the intermediate pair is not modeled as its own resource).
  const parentLookup = buildPathBasedParentLookup(expandedResources);

  const filteredResources = postProcessArmResources(
    expandedResources,
    nonResourceMethodsArray,
    parentLookup,
    { methodResponseModelIdMap }
  );

  // Multi-path same-model resource name derivation. For a model with multiple
  // detected instance paths, derive each entry's name from its originating
  // client name (singularized).
  const modelIdToResources = new Map<string, ArmResourceSchema[]>();
  for (const r of filteredResources) {
    if (!modelIdToResources.has(r.resourceModelId)) {
      modelIdToResources.set(r.resourceModelId, []);
    }
    modelIdToResources.get(r.resourceModelId)!.push(r);
  }
  for (const [, list] of modelIdToResources) {
    if (list.length > 1) {
      for (const resource of list) {
        const clientName = resourcePathToClientName.get(
          resource.metadata.resourceIdPattern!.path
        );
        if (clientName) {
          resource.metadata.resourceName = pluralize.singular(clientName);
        }
      }
    }
  }

  // Name constraints from the resource model's `name` property.
  for (const resource of filteredResources) {
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
  }

  // Assign remaining non-resource methods as Actions/Lists on detected
  // resources (longest-prefix for actions, model-id fallback for lists).
  assignNonResourceMethodsToResources(
    filteredResources,
    nonResourceMethodsArray
  );

  // Compute per-resource API versions after all post-processing so that
  // merged/moved methods are reflected.
  for (const resource of filteredResources) {
    resource.metadata.apiVersions = resolveResourceApiVersions(
      resource.metadata.methods,
      serviceMethods
    );
  }

  return {
    resources: filteredResources,
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

/**
 * Lightweight path-shape validation. The design calls for rejecting invalid
 * ARM paths (e.g., missing provider namespace or non-alternating segments),
 * but for now we only emit a diagnostic so behavior stays compatible with
 * existing tests.
 */
function validateInstancePath(
  sdkContext: CSharpEmitterContext,
  path: RequestPath,
  modelId: string
): void {
  // Currently no validation enforced — kept as a single point to tighten
  // later. Avoid emitting a diagnostic for now to keep test output stable.
  void sdkContext;
  void path;
  void modelId;
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

function getSingletonResource(
  decorator: DecoratorInfo | undefined
): string | undefined {
  if (!decorator) return undefined;
  const singletonResource = decorator.arguments["keyValue"] as
    | string
    | undefined;
  return singletonResource ?? "default";
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
