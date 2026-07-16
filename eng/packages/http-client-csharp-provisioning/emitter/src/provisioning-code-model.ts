// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ManagementCodeModelTransformer } from "@azure-typespec/http-client-csharp-mgmt";
import { CodeModel, InputModelType } from "@typespec/http-client-csharp";

type ArmProviderSchema = Parameters<ManagementCodeModelTransformer>[2];
type ArmResourceSchema = ArmProviderSchema["resources"][number];
type InputModelProperty = InputModelType["properties"][number];
type InputType = InputModelProperty["type"];
type InputEnumType = Extract<InputType, { kind: "enum" }>;

const provisioningProviderSchema =
  "Azure.ClientGenerator.Core.@provisioningProviderSchema";

interface ResourceProjection {
  resources: ArmResourceSchema[];
  resourceModel: InputModelType;
  isSettable: boolean;
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
          resourceIdPatterns: projection.resources.map(
            (resource) => resource.metadata.resourceIdPattern.path
          )
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
  const modelsById = new Map(
    codeModel.models.map((model) => [model.crossLanguageDefinitionId, model])
  );
  const groups = new Map<string, ArmResourceSchema[]>();

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

    return {
      resources,
      resourceModel,
      isSettable: resources.some((resource) =>
        resource.metadata.methods.some((method) => method.kind === "Create")
      )
    };
  });
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
