import {
  ChoiceSchema,
  CodeModel,
  ObjectSchema,
  SealedChoiceSchema,
  Schema,
  ChoiceValue,
  Property,
  Parameter,
  SchemaType,
  Operation,
} from "@autorest/codemodel";
import { TypespecDecorator } from "../interfaces";
import { getOptions } from "../options";
import { getLogger } from "../utils/logger";
import { Metadata } from "../utils/resource-discovery";

type RenamableSchema = Schema | Property | Parameter | ChoiceValue | Operation;

const logger = () => getLogger("rename-pretransform");

export function pretransformRename(codeModel: CodeModel, metadata: Metadata): void {
  const { isArm } = getOptions();
  if (!isArm) {
    return;
  }

  applyRenameMapping(metadata, codeModel);
  applyOverrideOperationName(metadata, codeModel);
}

export function createCSharpNameDecorator(schema: RenamableSchema): TypespecDecorator {
  return {
    name: "clientName",
    module: "@azure-tools/typespec-client-generator-core",
    namespace: "Azure.ClientGenerator.Core",
    arguments: [schema.language.csharp!.name, "csharp"],
  };
}
export function createClientNameDecorator(target: string, value: string): TypespecDecorator {
  return {
    name: "clientName",
    module: "@azure-tools/typespec-client-generator-core",
    namespace: "Azure.ClientGenerator.Core",
    target,
    arguments: [value],
  };
}

function parseNewCSharpNameAndSetToSchema(schema: RenamableSchema, renameValue: string) {
  const newName = parseNewName(renameValue);
  setSchemaCSharpName(schema, newName);
}

function setSchemaCSharpName(schema: RenamableSchema, newName: string) {
  if (!schema.language.csharp)
    schema.language.csharp = { name: newName, description: schema.language.default.description };
  else schema.language.csharp.name = newName;
}

function parseNewName(value: string) {
  // TODO: format not supported
  return value.split("|")[0].trim();
}

function applyOverrideOperationName(metadata: Metadata, codeModel: CodeModel) {
  for (const opId in metadata.OverrideOperationName) {
    const found = codeModel.operationGroups.flatMap((og) => og.operations).find((op) => op.operationId === opId);
    if (found) parseNewCSharpNameAndSetToSchema(found, metadata.OverrideOperationName[opId]);
    else
      logger().warning(
        `Can't find operation to rename for OverrideOperationName rule: ${opId}->${metadata.OverrideOperationName[opId]}`,
      );
  }
}

function applyRenameMapping(metadata: Metadata, codeModel: CodeModel) {
  for (const key in metadata.RenameMapping) {
    const subKeys = key
      .split(".")
      .map((s) => s.trim())
      .filter((s) => s.length > 0);
    if (subKeys.length === 0) continue;
    const lowerFirstSubKey = subKeys[0].toLowerCase();
    const value = metadata.RenameMapping[key];

    const found: Schema | undefined = [
      ...(codeModel.schemas.choices ?? []),
      ...(codeModel.schemas.sealedChoices ?? []),
      ...(codeModel.schemas.objects ?? []),
    ].find((o: Schema) => o.language.default.name.toLowerCase() === lowerFirstSubKey);

    if (!found) {
      logger().info(`Can't find object or enum for RenameMapping rule: ${key} -> ${value}`);
      continue;
    }

    if (found.type === SchemaType.Choice || found.type == SchemaType.SealedChoice) {
      transformEnum(subKeys, value, found as ChoiceSchema | SealedChoiceSchema);
    } else if (found.type === SchemaType.Object) {
      transformObject(subKeys, value, found as ObjectSchema);
    } else {
      logger().error(`Unexpected schema type '${found.type}' found with key ${key}`);
    }
  }
}

function transformEnum(keys: string[], value: string, target: ChoiceSchema | SealedChoiceSchema) {
  if (keys.length === 1) parseNewCSharpNameAndSetToSchema(target, value);
  else if (keys.length === 2) {
    const lowerMemberValue = keys[1].toLowerCase();
    const found = target.choices.find((c) => c.language.default.name.toLowerCase() === lowerMemberValue);
    if (found) parseNewCSharpNameAndSetToSchema(found, value);
    else logger().warning(`Can't find enum member for RenameMapping rule: ${keys.join(".")} -> ${value}`);
  } else {
    logger().error(`Unexpected keys for enum RenameMapping: ${keys.join(".")}`);
  }
}

function transformObject(keys: string[], value: string, target: ObjectSchema) {
  if (keys.length === 1) parseNewCSharpNameAndSetToSchema(target, value);
  else if (keys.length === 2) {
    const lowerPropertyName = keys[1].toLowerCase();
    const found = target.properties?.find((p) => p.language.default.name.toLowerCase() === lowerPropertyName);
    if (found) parseNewCSharpNameAndSetToSchema(found, value);
    else logger().info(`Can't find object property for RenameMapping rule: ${keys.join(".")} -> ${value}`);
  } else if (keys.length > 2) {
    // handle flatten scenario
    const lowerPropName = keys.pop()?.toLowerCase();
    let cur = target;
    for (let i = 1; i < keys.length && cur; i++) {
      const foundProp = cur.properties?.find((p) => p.language.default.name.toLowerCase() === keys[i].toLowerCase());
      cur = foundProp?.schema as ObjectSchema;
    }
    const foundProp = cur?.properties?.find((p) => p.language.default.name.toLowerCase() === lowerPropName);
    if (foundProp) parseNewCSharpNameAndSetToSchema(foundProp, value);
    else {
      logger().info(`Can't find object property for RenameMapping rule: ${keys.join(".")} -> ${value}`);
    }
  } else {
    logger().error(`Unexpected keys for object property RenameMapping: ${keys.join(".")}`);
  }
}
