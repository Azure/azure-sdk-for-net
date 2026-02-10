import { CodeModel, isObjectSchema, Schema } from "@autorest/codemodel";
import { getDataTypes } from "./data-types";
import { generateExamples } from "./generate/generate-arm-resource";
import { TypespecDataType, TypespecProgram } from "./interfaces";
import { getOptions } from "./options";
import { transformTspArmResource } from "./transforms/transform-arm-resources";
import { transformEnum } from "./transforms/transform-choices";
import { getTypespecType, transformObject } from "./transforms/transform-object";
import { isListOperation, transformOperationGroup } from "./transforms/transform-operations";
import { transformServiceInformation } from "./transforms/transform-service-information";
import { isInterfaceName } from "./utils/operation-group";
import { ArmResourceSchema, filterArmEnums, filterArmModels, isResourceSchema } from "./utils/resource-discovery";
import { isChoiceSchema } from "./utils/schemas";

const models: Map<CodeModel, TypespecProgram> = new Map();

export function getModel(codeModel: CodeModel): TypespecProgram {
  let model = models.get(codeModel);

  if (!model) {
    getDataTypes(codeModel);
    model = transformModel(codeModel);
    models.set(codeModel, model);
  }

  return model;
}

export function transformDataType(schema: Schema, codeModel: CodeModel): TypespecDataType {
  if (isObjectSchema(schema)) {
    return transformObject(schema, codeModel);
  }

  if (isChoiceSchema(schema)) {
    return transformEnum(schema, codeModel);
  }

  return {
    name: getTypespecType(schema, codeModel),
    kind: "wildcard",
    doc: schema.language.default.description,
  };
}

function transformModel(codeModel: CodeModel): TypespecProgram {
  const typespecEnums = [...(codeModel.schemas.choices ?? []), ...(codeModel.schemas.sealedChoices ?? [])]
    .filter((c) => c.language.default.name !== "Versions")
    .map((c) => transformEnum(c, codeModel));

  const { isArm, namespace } = getOptions();

  // objects need to be converted first because they are used in operation convertion
  const typespecObjects = (codeModel.schemas.objects ?? []).map((o) => transformObject(o, codeModel));

  const armResources = isArm
    ? (codeModel.schemas.objects
        ?.filter((o) => isResourceSchema(o))
        .map((o) => transformTspArmResource(o as ArmResourceSchema)) ?? [])
    : [];

  const serviceInformation = transformServiceInformation(codeModel);

  const typespecOperationGroups = [];

  for (const og of codeModel.operationGroups) {
    const typespecOperationGroup = transformOperationGroup(og, codeModel);
    if (typespecOperationGroup.operations.length > 0) {
      typespecOperationGroups.push(typespecOperationGroup);
    }
  }

  // post processing for clientLocation decorators
  for (const armResource of armResources) {
    for (const resourceOperation of armResource.resourceOperationGroups.flatMap((g) => g.resourceOperations)) {
      const clientLocation = resourceOperation.clientDecorators?.find((d) => d.name === "clientLocation");
      if (clientLocation && clientLocation.arguments![0] && isInterfaceName(clientLocation.arguments![0] as string)) {
        clientLocation.arguments = [{ value: clientLocation.arguments![0] as string, options: { unwrap: true } }];
      }
    }
  }

  for (const resourceOperation of typespecOperationGroups.flatMap((g) => g.operations)) {
    const clientLocation = resourceOperation.clientDecorators?.find((d) => d.name === "clientLocation");
    if (clientLocation && clientLocation.arguments![0] && isInterfaceName(clientLocation.arguments![0] as string)) {
      clientLocation.arguments = [{ value: clientLocation.arguments![0] as string, options: { unwrap: true } }];
    }
  }

  let listOperationInfo = undefined;
  const listOperation = codeModel.operationGroups.flatMap((g) => g.operations).find((o) => isListOperation(o));
  if (listOperation !== undefined) {
    const examples: Record<string, string> = {};
    generateExamples(listOperation.extensions?.["x-ms-examples"] ?? {}, listOperation.operationId!, examples);

    listOperationInfo = {
      examples,
    };
  }
  return {
    serviceInformation,
    models: {
      enums: isArm ? filterArmEnums(typespecEnums) : typespecEnums,
      objects: isArm ? filterArmModels(codeModel, typespecObjects) : typespecObjects,
      armResources,
    },
    operationGroups: typespecOperationGroups,
    listOperation: listOperationInfo,
  };
}
