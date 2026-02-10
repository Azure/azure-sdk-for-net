import { Case } from "change-case-all";
import _ from "lodash";
import pluralize from "pluralize";
import {
  TspArmResource,
  TypespecTemplateModel,
  TypespecVoidType,
  TypespecParameter,
  TypespecDataType,
  TspArmResourceOperationGroup,
  TspArmOperationType,
  TspArmResourceOperation,
} from "../interfaces";
import { getOptions } from "../options";
import { generateAugmentedDecorators, generateDecorators } from "../utils/decorators";
import { generateDocs } from "../utils/docs";
import { getLogger } from "../utils/logger";
import { generateLroHeaders } from "../utils/lro";
import {
  generateTemplateModel,
  getModelPropertyDeclarations,
  getSpreadExpressionDecalaration,
} from "../utils/model-generation";
import { generateSuppressions } from "../utils/suppressions";
import { generateParameters } from "./generate-operations";
import { generateParameter } from "./generate-parameter";

const logger = () => getLogger("generate-arm-resource");

export function generateArmResource(resource: TspArmResource): string {
  const definitions: string[] = [];

  definitions.push(generateArmResourceModel(resource));

  definitions.push("\n");

  definitions.push(generateArmResourceOperationGroups(resource));

  definitions.push("\n");

  for (const a of resource.augmentDecorators ?? []) {
    definitions.push(generateAugmentedDecorators(a.target!, [a]));
  }

  for (const o of resource.resourceOperationGroups.flatMap((g) => g.resourceOperations)) {
    for (const d of o.augmentedDecorators ?? []) {
      definitions.push(`${d}`);
    }
  }

  return definitions.join("\n");
}

function generateArmResourceModel(resource: TspArmResource): string {
  const definitions: string[] = [];

  for (const fixme of resource.fixMe ?? []) {
    definitions.push(fixme);
  }

  const doc = generateDocs(resource);
  definitions.push(doc);

  if (resource.resourceKind === "PrivateEndpointConnectionResource") {
    definitions.push(`model PrivateEndpointConnection is PrivateEndpointConnectionResource;`);
    definitions.push(`alias PrivateEndpointOperations = PrivateEndpoints<PrivateEndpointConnection>;`);
    return definitions.join("\n");
  }

  const decorators = generateDecorators(resource.decorators);
  decorators && definitions.push(decorators);

  if (resource.resourceParent) {
    definitions.push(`@parentResource(${resource.resourceParent.name})`);
  }

  if (resource.locationParent) {
    definitions.push(`@parentResource(${resource.locationParent})`);
  }

  definitions.push(
    `model ${resource.name} is Azure.ResourceManager.${resource.resourceKind}<${resource.propertiesModelName}${
      resource.propertiesPropertyRequired ? ", false" : ""
    }> {`,
  );

  for (const property of resource.properties) {
    if (property.kind === "property") definitions.push(...getModelPropertyDeclarations(property));
    else if (property.kind === "spread") definitions.push(getSpreadExpressionDecalaration(property));
  }

  definitions.push("}\n");
  return definitions.join("\n");
}

function generateArmResourceOperationGroups(resource: TspArmResource): string {
  const definitions: string[] = [];

  for (const operationGroup of resource.resourceOperationGroups) {
    definitions.push(generateArmResourceOperationGroup(operationGroup, resource));
  }

  return definitions.join("\n");
}

function generateArmResourceOperationGroup(
  operationGroup: TspArmResourceOperationGroup,
  resource: TspArmResource,
): string {
  const { isFullCompatible } = getOptions();

  const definitions: string[] = [];

  if (operationGroup.isLegacy) {
    definitions.push(
      `alias ${
        operationGroup.legacyOperationGroup!.interfaceName
      } = Azure.ResourceManager.Legacy.${operationGroup.legacyOperationGroup?.type === "Normal" ? "LegacyOperations" : "ExtensionOperations"}<{${operationGroup.legacyOperationGroup!.targetParentParameters.join(
        ";",
      )}}, ${operationGroup.legacyOperationGroup?.type === "Normal" ? "" : `{${operationGroup.legacyOperationGroup!.extensionParentParameters!.join(";")}},`}{${operationGroup.legacyOperationGroup!.instanceParameters.join(";")}}>;`,
    );
    definitions.push("\n");
  }

  if (operationGroup.externalResource) {
    definitions.push(
      `alias ${operationGroup.externalResource.aliasName} = Extension.ExternalResource<"${operationGroup.externalResource.targetNamespace}"
      , "${operationGroup.externalResource.resourceType}", "${operationGroup.externalResource.resourceParameterName}">;
      `,
    );
  }

  definitions.push("@armResourceOperations");
  definitions.push(`interface ${operationGroup.interfaceName} {`);

  for (const operation of operationGroup.resourceOperations) {
    for (const fixme of operation.fixMe ?? []) {
      definitions.push(fixme);
    }
    definitions.push(generateDocs(operation));
    const decorators = generateDecorators(operation.decorators);
    decorators && definitions.push(decorators);
    if (isFullCompatible && operation.suppressions) {
      definitions.push(...generateSuppressions(operation.suppressions));
    }

    const operationKind = operationGroup.isLegacy
      ? `${operationGroup.legacyOperationGroup!.interfaceName}.${getLegacyOperationKind(operation.kind)}`
      : getOperationKind(operation, resource);
    if (operation.kind === "ArmResourceActionSync" || operation.kind === "ArmResourceActionAsync") {
      definitions.push(
        `${operation.name} is ${operationKind}<${getSpecialParameter(operation, resource)}${operation.resource}, ${generateArmRequest(
          operation.request,
        )}, ${generateArmResponse(operation.response)}${
          operation.baseParameters && !operationGroup.isLegacy
            ? `, BaseParameters = ${operation.baseParameters[0]}`
            : ""
        }${operation.parameters ? `, Parameters = { ${generateParameters(operation.parameters)} }` : ""}${
          operation.lroHeaders ? `, LroHeaders = ${generateLroHeaders(operation.lroHeaders)}` : ""
        }${operation.optionalRequestBody === true ? `, OptionalRequestBody = true` : ""}>;`,
      );
    } else if (operation.kind === "ArmResourceActionAsyncBase") {
      definitions.push(
        `${operation.name} is ${operationKind}<${getSpecialParameter(operation, resource)}${operation.resource}, ${generateArmRequest(
          operation.request,
        )}, ${generateArmResponse(operation.response)}, BaseParameters = ${operation.baseParameters![0]}${
          operation.parameters ? `, Parameters = { ${generateParameters(operation.parameters)} }` : ""
        }${operation.optionalRequestBody === true ? `, OptionalRequestBody = true` : ""}>;`,
      );
    } else {
      definitions.push(
        `${operation.name} is ${operationKind}<${getSpecialParameter(operation, resource)}${operation.resource}${operation.request ? `, Request = ${generateArmRequest(operation.request)}` : ""}${
          operation.patchModel ? `, PatchModel = ${generateArmRequest(operation.patchModel)}` : ""
        }${
          operation.baseParameters && !operationGroup.isLegacy
            ? `, BaseParameters = ${operation.baseParameters[0]}`
            : ""
        }${operation.parameters ? `, Parameters = { ${generateParameters(operation.parameters)} }` : ""}${
          operation.response ? `, Response = ${generateArmResponse(operation.response)}` : ""
        }${operation.lroHeaders ? `, LroHeaders = ${generateLroHeaders(operation.lroHeaders)}` : ""}
        ${getAvailableTemplateWithOptionalBody(operation) ? `, OptionalRequestBody = true` : ""}>;`,
      );
    }
    definitions.push("\n");
  }

  definitions.push("}");
  return definitions.join("\n");
}

// Only several operation templates accept optional body
function getAvailableTemplateWithOptionalBody(operation: TspArmResourceOperation): string | undefined {
  if (operation.optionalRequestBody !== true) return undefined;
  if (operation.kind === "ArmCustomPatchAsync" || operation.kind === "ArmCustomPatchSync")
    return `Azure.ResourceManager.Legacy.${operation.kind.replace("Arm", "")}`;
  if (operation.kind === "ArmResourceCreateOrReplaceAsync" || operation.kind === "ArmResourceCreateOrReplaceSync")
    return `Azure.ResourceManager.Legacy.${operation.kind.replace("ArmResource", "").replace("CreateOrReplace", "CreateOrUpdate")}`;
  return undefined;
}

// Only several operation templates accept request/empty patch body
function getAvailableTemplateWithRequest(operation: TspArmResourceOperation): string | undefined {
  if (
    operation.request !== undefined &&
    (operation.kind === "ArmResourceCreateOrReplaceAsync" || operation.kind === "ArmResourceCreateOrReplaceSync")
  )
    return `Azure.ResourceManager.Legacy.${operation.kind.replace("ArmResource", "").replace("CreateOrReplace", "CreateOrUpdate")}`;
  if (
    operation.patchModel?.kind === "void" &&
    (operation.kind === "ArmCustomPatchAsync" || operation.kind === "ArmCustomPatchSync")
  )
    return `Azure.ResourceManager.Legacy.${operation.kind.replace("Arm", "")}`;
  return undefined;
}

// These templates have special parameter as the first parameter
// - Extension operations
// - PrivateEndpointConnection operations
function getSpecialParameter(operation: TspArmResourceOperation, resource: TspArmResource): string {
  if (operation.targetResource) return `${operation.targetResource}, `;
  if (resource.resourceKind === "PrivateEndpointConnectionResource") return `${resource.resourceParent!.name}, `;
  return "";
}

function getOperationKind(operation: TspArmResourceOperation, resource: TspArmResource): string {
  if (resource.resourceKind === "PrivateEndpointConnectionResource")
    return `PrivateEndpointOperations.${getPrivateEndpointConnectionOperationKind(operation.kind)}`;
  if (operation.targetResource) return `${getExtensionOperationKind(operation)}`;
  return (
    getAvailableTemplateWithOptionalBody(operation) ?? getAvailableTemplateWithRequest(operation) ?? operation.kind
  );
}

function getPrivateEndpointConnectionOperationKind(kind: TspArmOperationType): string {
  switch (kind) {
    case "ArmResourceListByParent":
      return "ListByParent";
    default:
      return getOperationBaseKind(kind);
  }
}

function getExtensionOperationKind(operation: TspArmResourceOperation): string {
  if (
    operation.request &&
    (operation.kind === "ArmResourceCreateOrReplaceAsync" || operation.kind === "ArmResourceCreateOrReplaceSync")
  ) {
    return `Azure.ResourceManager.Legacy.Extension.${operation.kind.replace("ArmResource", "")}`;
  }
  if (
    operation.patchModel?.kind === "void" &&
    (operation.kind === "ArmCustomPatchAsync" || operation.kind === "ArmCustomPatchSync")
  ) {
    return `Azure.ResourceManager.Legacy.Extension.${operation.kind.replace("Arm", "")}`;
  }

  switch (operation.kind) {
    case "ArmResourceDeleteWithoutOkAsync":
      return "Extension.DeleteWithoutOkAsync";
    case "ArmResourceListByParent":
      return "Extension.ListByTarget";
    case "ArmListBySubscription":
      return "Extension.List";
    case "ArmResourceListAtScope":
      return "Extension.List";
    default:
      return `Extension.${getOperationBaseKind(operation.kind)}`;
  }
}

function getLegacyOperationKind(kind: TspArmOperationType): string {
  switch (kind) {
    case "ArmResourceCreateOrReplaceSync":
      return "CreateOrUpdateSync";
    case "ArmResourceCreateOrReplaceAsync":
      return "CreateOrUpdateAsync";
    case "ArmResourcePatchSync":
      return "PatchSync";
    case "ArmResourcePatchAsync":
      return "PatchAsync";
    case "ArmResourceDeleteWithoutOkAsync":
      return "DeleteWithoutOkAsync";
    default:
      return getOperationBaseKind(kind);
  }
}

function getOperationBaseKind(kind: TspArmOperationType): string {
  switch (kind) {
    case "ArmResourceRead":
      return "Read";
    case "ArmResourceCheckExistence":
      return "CheckExistence";
    case "ArmResourceCreateOrReplaceSync":
      return "CreateOrReplaceSync";
    case "ArmResourceCreateOrReplaceAsync":
      return "CreateOrReplaceAsync";
    case "ArmResourcePatchSync":
      return "CustomPatchSync";
    case "ArmResourcePatchAsync":
      return "CustomPatchAsync";
    case "ArmCustomPatchSync":
      return "CustomPatchSync";
    case "ArmCustomPatchAsync":
      return "CustomPatchAsync";
    case "ArmResourceDeleteSync":
      return "DeleteSync";
    case "ArmResourceDeleteWithoutOkAsync":
      return "DeleteAsync";
    case "ArmResourceActionSync":
      return "ActionSync";
    case "ArmResourceActionAsync":
      return "ActionAsync";
    case "ArmResourceActionAsyncBase":
      return "ActionAsyncBase";
    case "ArmResourceListByParent":
      return "List";
    case "ArmListBySubscription":
      return "ListBySubscription";
    case "ArmResourceListAtScope":
      return "ListAtScope";
  }
}

function generateArmRequest(request: TypespecParameter | TypespecVoidType | TypespecDataType): string {
  if (request.kind === "void") {
    return "void";
  }

  if (request.kind === "parameter") {
    return `{${generateParameter(request as TypespecParameter)}}`;
  }

  return request.name;
}

function generateArmResponse(responses: TypespecTemplateModel[] | TypespecVoidType): string {
  if (!Array.isArray(responses)) {
    return "void";
  }

  return responses.map((r) => generateTemplateModel(r)).join(" | ");
}

export function generateArmResourceExamples(resource: TspArmResource): Record<string, string> {
  const formalOperationGroupName = pluralize(resource.name);
  const examples: Record<string, string> = {};
  for (const operation of resource.resourceOperationGroups.flatMap((g) => g.resourceOperations)) {
    generateExamples(
      operation.examples ?? {},
      operation.operationId ?? getGeneratedOperationId(formalOperationGroupName, operation.name),
      examples,
    );
  }
  return examples;
}

export function generateExamples(
  examples: Record<string, Record<string, unknown>>,
  operationId: string,
  generatedExamples: Record<string, string>,
) {
  const count = _.keys(examples).length;
  for (const [title, example] of _.entries(examples)) {
    example.operationId = operationId;
    example.title = title;

    let filename = undefined;
    const originalFile = example["x-ms-original-file"] as string;
    if (originalFile) {
      const exampleIndex = originalFile.lastIndexOf("/examples/");
      if (exampleIndex !== -1) {
        filename = originalFile.substring(exampleIndex + "/examples/".length);
        delete example["x-ms-original-file"];
        generatedExamples[filename] = JSON.stringify(example, null, 2);
        continue;
      }
    }

    logger().info(
      `Cannot find the example original path or the path isn't in the examples folder for operation ${operationId}`,
    );
  }
}

export function getGeneratedOperationId(operationGroupName: string, operationName: string): string {
  return `${Case.pascal(operationGroupName)}_${Case.pascal(operationName)}`;
}
