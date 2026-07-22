// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ManagementCodeModelTransformer } from "@azure-typespec/http-client-csharp-mgmt";
import { CodeModel, InputModelType } from "@typespec/http-client-csharp";

type ArmProviderSchema = Parameters<ManagementCodeModelTransformer>[2];
type ArmResourceSchema = ArmProviderSchema["resources"][number];
type ArmResourceMetadata = ArmResourceSchema["metadata"];
type ResourceScopeKind = ArmResourceMetadata["scope"]["kind"];
type ResourceNameConstraints = ArmResourceMetadata["nameConstraints"];
type ResourceRbacRole = ArmResourceMetadata["rbacRoles"][number];
type ResourcePath = ArmResourceMetadata["resourceIdPattern"];
type InputModelProperty = InputModelType["properties"][number];
type InputType = InputModelProperty["type"];
type InputEnumType = Extract<InputType, { kind: "enum" }>;
type ProjectionScopeOperation = "Create" | "Read";

const provisioningProviderSchema =
  "Azure.ClientGenerator.Core.@provisioningProviderSchema";

interface ResourceProjection {
  resourceModel: InputModelType;
  isSettable: boolean;
  resourceModelId: string;
  resourceName: string;
  resourceType: string;
  singletonResourceName?: string;
  parentResourceId?: string;
  nameConstraints: ResourceNameConstraints;
  resourceIdPatterns: string[];
  apiVersions: string[];
  methodIds: string[];
  rbacRoles: ResourceRbacRole[];
  readableScopes: ResourceScopeKind[];
  writableScopes: ResourceScopeKind[];
  isExtensionResource: boolean;
}

export function updateProvisioningCodeModel(
  codeModel: CodeModel,
  armProviderSchema: ArmProviderSchema
): CodeModel {
  const projections = buildResourceProjections(codeModel, armProviderSchema);
  const { models, enums, modelSettableUsage } =
    collectReachableTypes(projections);

  codeModel.models = codeModel.models.filter((model) => models.has(model));
  codeModel.enums = codeModel.enums.filter((inputEnum) => enums.has(inputEnum));

  const rootClient = codeModel.clients[0];
  if (rootClient) {
    rootClient.decorators ??= [];
    rootClient.decorators.push({
      name: provisioningProviderSchema,
      arguments: {
        resourceProjections: projections.map((projection) => ({
          resourceModelId: projection.resourceModelId,
          resourceName: projection.resourceName,
          resourceType: projection.resourceType,
          singletonResourceName: projection.singletonResourceName,
          parentResourceId: projection.parentResourceId,
          nameConstraints: projection.nameConstraints,
          resourceIdPatterns: projection.resourceIdPatterns,
          apiVersions: projection.apiVersions,
          methodIds: projection.methodIds,
          rbacRoles: projection.rbacRoles,
          readableScopes: projection.readableScopes,
          writableScopes: projection.writableScopes,
          isExtensionResource: projection.isExtensionResource
        })),
        modelSettableUsage: Array.from(
          modelSettableUsage,
          ([modelId, isSettable]) => ({ modelId, isSettable })
        )
      }
    });
  }

  return codeModel;
}

function buildResourceProjections(
  codeModel: CodeModel,
  armProviderSchema: ArmProviderSchema
): ResourceProjection[] {
  // Resource metadata identifies body models by cross-language ID, while the
  // reachability analysis below needs the actual model instances.
  const modelsById = new Map(
    codeModel.models.map((model) => [model.crossLanguageDefinitionId, model])
  );
  const groups = new Map<string, ArmResourceSchema[]>();

  // A logical provisioning resource can have multiple ARM metadata entries,
  // such as different request paths or scopes. Collapse entries only when both
  // the serialized resource type and body model match; the C# generator later
  // resolves the complete set through their resource ID patterns.
  for (const resource of armProviderSchema.resources) {
    const key = `${resource.metadata.resourceType}\0${resource.resourceModelId}`;
    const group = groups.get(key);
    if (group) {
      group.push(resource);
    } else {
      groups.set(key, [resource]);
    }
  }

  return Array.from(groups.values(), (resources) => {
    const resourceModel = modelsById.get(resources[0].resourceModelId);
    if (!resourceModel) {
      throw new Error(
        `Resource model '${resources[0].resourceModelId}' was not found in the code model.`
      );
    }

    // Like Bicep, treat the projection as deployable/settable only when at
    // least one grouped resource has a Create (PUT) operation. PATCH-only
    // resources remain reachable for existing-resource scenarios.
    const projection = buildResourceProjectionMetadata(
      resources,
      resourceModel.name
    );
    return {
      ...projection,
      resourceModel,
      isSettable: projection.writableScopes.length > 0
    };
  });
}

export function buildResourceProjectionMetadata(
  resources: ArmResourceSchema[],
  defaultResourceName: string
): Omit<ResourceProjection, "resourceModel" | "isSettable"> {
  const first = resources[0];
  const writableScopes = collectScopes(resources, "Create");

  return {
    resourceModelId: first.resourceModelId,
    resourceName: getConsistentValue(
      resources.map((resource) => resource.metadata.resourceName),
      defaultResourceName
    ),
    resourceType: first.metadata.resourceType,
    singletonResourceName: getConsistentValue(
      resources.map((resource) => resource.metadata.singletonResourceName),
      undefined
    ),
    parentResourceId: getConsistentValue(
      resources.map((resource) => resource.metadata.parentResourceId),
      undefined,
      resourcePathsEqual
    )?.path,
    nameConstraints: getConsistentValue(
      resources.map((resource) => resource.metadata.nameConstraints),
      {},
      nameConstraintsEqual
    ),
    resourceIdPatterns: distinctResourcePaths(
      resources.map((resource) => resource.metadata.resourceIdPattern)
    ).map((path) => path.path),
    apiVersions: distinct(
      resources.flatMap((resource) => resource.metadata.apiVersions)
    ),
    methodIds: distinct(
      resources.flatMap((resource) =>
        resource.metadata.methods.map((method) => method.methodId)
      )
    ),
    rbacRoles: distinctBy(
      resources.flatMap((resource) => resource.metadata.rbacRoles),
      (role) => `${role.name}\0${role.value}`
    ),
    readableScopes: collectScopes(resources, "Read"),
    writableScopes,
    isExtensionResource: writableScopes.some(isExtensionScope)
  };
}

function resourcePathsEqual(
  left: ResourcePath | undefined,
  right: ResourcePath | undefined
): boolean {
  if (!left || !right) {
    return left === right;
  }
  return left.equals(right);
}

function distinctResourcePaths(paths: ResourcePath[]): ResourcePath[] {
  const distinctPaths: ResourcePath[] = [];
  for (const path of paths) {
    if (!distinctPaths.some((existing) => existing.equals(path))) {
      distinctPaths.push(path);
    }
  }
  return distinctPaths;
}

function isExtensionScope(scope: ResourceScopeKind): boolean {
  return scope.toString() === "Extension";
}

function getConsistentValue<T>(
  values: T[],
  fallback: T,
  equals: (left: T, right: T) => boolean = Object.is
): T {
  const first = values[0];
  return values.every((value) => equals(value, first)) ? first : fallback;
}

function nameConstraintsEqual(
  left: ResourceNameConstraints,
  right: ResourceNameConstraints
): boolean {
  return (
    left.pattern === right.pattern &&
    left.minLength === right.minLength &&
    left.maxLength === right.maxLength
  );
}

function distinct<T>(values: T[]): T[] {
  return Array.from(new Set(values));
}

function distinctBy<T>(values: T[], getKey: (value: T) => string): T[] {
  const seen = new Set<string>();
  return values.filter((value) => {
    const key = getKey(value);
    if (seen.has(key)) {
      return false;
    }
    seen.add(key);
    return true;
  });
}

function collectScopes(
  resources: ArmResourceSchema[],
  operationKind: ProjectionScopeOperation
): ResourceScopeKind[] {
  return distinct(
    resources
      .filter((resource) =>
        resource.metadata.methods.some(
          (method) => method.kind === operationKind
        )
      )
      .map((resource) => resource.metadata.scope.kind)
  );
}

function collectReachableTypes(projections: ResourceProjection[]) {
  const models = new Set<InputModelType>();
  const enums = new Set<InputEnumType>();
  const modelSettableUsage = new Map<string, boolean>();
  const readOnlyVisited = new Set<InputType>();
  const settableVisited = new Set<InputType>();
  const projectionsByModel = new Map<InputModelType, ResourceProjection[]>();
  const queue: { type: InputType; isSettable: boolean }[] = [];
  let queueIndex = 0;

  for (const projection of projections) {
    const modelProjections =
      projectionsByModel.get(projection.resourceModel) ?? [];
    modelProjections.push(projection);
    projectionsByModel.set(projection.resourceModel, modelProjections);
    queue.push({
      type: projection.resourceModel,
      isSettable: projection.isSettable
    });
  }

  while (queueIndex < queue.length) {
    const item = queue[queueIndex++];
    const visited = item.isSettable ? settableVisited : readOnlyVisited;
    if (visited.has(item.type)) {
      continue;
    }
    visited.add(item.type);

    switch (item.type.kind) {
      case "model": {
        const model = item.type;
        const resourceProjections = projectionsByModel.get(model);
        const isSettable =
          item.isSettable ||
          resourceProjections?.some((projection) => projection.isSettable) ===
            true;

        models.add(model);
        modelSettableUsage.set(
          model.crossLanguageDefinitionId,
          isSettable ||
            modelSettableUsage.get(model.crossLanguageDefinitionId) === true
        );
        enqueueModelHierarchy(model, isSettable, queue);

        const properties = resourceProjections
          ? getResourceProperties(model)
          : model.properties;
        for (const property of properties) {
          queue.push({
            type: property.type,
            isSettable: isSettable && !property.readOnly
          });
        }
        if (!resourceProjections && model.additionalProperties) {
          queue.push({ type: model.additionalProperties, isSettable });
        }
        break;
      }
      case "array":
        queue.push({ type: item.type.valueType, isSettable: item.isSettable });
        break;
      case "dict":
        queue.push(
          { type: item.type.keyType, isSettable: item.isSettable },
          { type: item.type.valueType, isSettable: item.isSettable }
        );
        break;
      case "nullable":
        queue.push({ type: item.type.type, isSettable: item.isSettable });
        break;
      case "constant":
        queue.push({ type: item.type.valueType, isSettable: item.isSettable });
        break;
      case "union":
        for (const variant of item.type.variantTypes) {
          queue.push({ type: variant, isSettable: item.isSettable });
        }
        break;
      case "enum":
        enums.add(item.type);
        break;
    }
  }

  return { models, enums, modelSettableUsage };
}

function enqueueModelHierarchy(
  model: InputModelType,
  isSettable: boolean,
  queue: { type: InputType; isSettable: boolean }[]
): void {
  if (model.baseModel) {
    queue.push({ type: model.baseModel, isSettable });
  }
  for (const derived of Object.values(model.discriminatedSubtypes ?? {})) {
    queue.push({ type: derived, isSettable });
  }
}

function getResourceProperties(
  resourceModel: InputModelType
): InputModelProperty[] {
  const hierarchy: InputModelType[] = [];
  let model: InputModelType | undefined = resourceModel;
  while (model) {
    hierarchy.push(model);
    model = model.baseModel;
  }
  return hierarchy.reverse().flatMap((type) => type.properties);
}
