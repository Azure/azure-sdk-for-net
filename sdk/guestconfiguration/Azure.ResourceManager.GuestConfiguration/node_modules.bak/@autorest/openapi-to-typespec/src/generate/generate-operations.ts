import {
  TspArmProviderActionOperation,
  TypespecOperation,
  TypespecOperationGroup,
  TypespecParameter,
} from "../interfaces";
import { getOptions } from "../options";
import { generateDecorators } from "../utils/decorators";
import { generateDocs, generateSummary } from "../utils/docs";
import { generateLroHeaders } from "../utils/lro";
import { getArmCommonTypeModelName } from "../utils/model-generation";
import { generateSuppressions } from "../utils/suppressions";
import { generateExamples, getGeneratedOperationId } from "./generate-arm-resource";
import { generateParameter } from "./generate-parameter";

export function generateOperation(operation: TypespecOperation, operationGroup?: TypespecOperationGroup) {
  const { isArm } = getOptions();
  const doc = generateDocs(operation);
  const summary = generateSummary(operation);
  const { verb, name, route, parameters } = operation;
  const params = generateParameters(parameters);
  const statements: string[] = [];
  summary && statements.push(summary);
  statements.push(doc);
  const modelResponses = [...new Set(operation.responses.filter((r) => r[1] !== "void").map((r) => r[1]))];
  generateMultiResponseWarning(modelResponses, statements);

  for (const fixme of operation.fixMe ?? []) {
    statements.push(fixme);
  }

  if (operation.decorators) {
    statements.push(generateDecorators(operation.decorators));
  }
  if (isArm) {
    statements.push(`@route("${route}")`);
    const otherResponses = operation.responses
      .filter((r) => r[1] === "void" && ["200", "202"].includes(r[0]))
      .map((r) => {
        if (r[0] === "200") return "OkResponse";
        if (r[0] === "202") return "ArmAcceptedResponse";
      });
    statements.push(
      `@${verb} op \`${name}\`(
        ...ApiVersionParameter,
        ${params}
        ): ${modelResponses.length > 0 ? `ArmResponse<${modelResponses.join(" | ")}>` : ""}${
          otherResponses.length > 0 ? `| ${otherResponses.join("|")}` : ""
        } | ErrorResponse;\n\n\n`,
    );
  } else if (!operation.resource) {
    const names = [name, ...modelResponses, ...parameters.map((p) => p.name)];
    const duplicateNames = findDuplicates(names);
    generateNameCollisionWarning(duplicateNames, statements);
    statements.push(`@route("${route}")`);
    statements.push(
      `@${verb} op \`${name}\` is Azure.Core.Foundations.Operation<${params ? params : "{}"}, ${
        modelResponses.length > 0 ? `${modelResponses.join(" | ")}` : "void"
      }>;\n\n\n`,
    );
  } else {
    const { resource } = operation;
    const names = [name, ...modelResponses, ...parameters.map((p) => p.name)];
    const duplicateNames = findDuplicates(names);
    generateNameCollisionWarning(duplicateNames, statements);
    const resourceParameters = generateParameters(
      parameters.filter((param) => !["path", "body"].some((p) => p === param.location)),
    );
    const parametersString = resourceParameters ? `, { parameters: ${resourceParameters}}` : "";
    statements.push(
      `${operationGroup?.name ? "" : "op "}`,
      `\`${name}\` is Azure.Core.${resource.kind}<${resource.response.name} ${parametersString}>;\n\n\n`,
    );
  }
  return statements.join("\n");
}

export function generateProviderAction(operation: TspArmProviderActionOperation) {
  const doc = generateDocs(operation);
  const summary = generateSummary(operation);
  const statements: string[] = [];
  summary && statements.push(summary);
  statements.push(doc);
  const templateParameters = [];

  if (operation.request) {
    templateParameters.push(`Request = ${getArmCommonTypeModelName(operation.request.type)}`);
  }

  if (operation.response) {
    if (operation.response.endsWith("[]")) {
      templateParameters.push(`Response = {@bodyRoot _: ${getArmCommonTypeModelName(operation.response)}}`);
    } else {
      templateParameters.push(`Response = ${getArmCommonTypeModelName(operation.response)}`);
    }
  }

  if (operation.scope) {
    templateParameters.push(`Scope = ${operation.scope}`);
  }

  if (operation.parameters.length > 0) {
    const params: string[] = [];
    for (const parameter of operation.parameters) {
      if (parameter.name === "location") {
        params.push("...LocationParameter");
      } else {
        params.push(generateParameter(parameter));
      }
    }

    if (params.length === 1 && params[0] === "...LocationParameter") {
      templateParameters.push(`Parameters = LocationParameter`);
    } else {
      templateParameters.push(`Parameters = {${params}}`);
    }
  }

  if (operation.lroHeaders) {
    templateParameters.push(`LroHeaders = ${generateLroHeaders(operation.lroHeaders)}`);
  }
  if (operation.suppressions) {
    statements.push(generateSuppressions(operation.suppressions).join("\n"));
  }
  if (operation.decorators) {
    statements.push(generateDecorators(operation.decorators));
  }
  if (operation.verb) {
    statements.push(`@${operation.verb}`);
  }
  if (operation.action) {
    statements.push(`@action("${operation.action}")`);
  }

  statements.push(`${operation.name} is ${operation.kind}<${(templateParameters ?? []).join(",")}>`);
  return statements.join("\n");
}

function findDuplicates(arr: string[]) {
  return arr.filter((item, index) => arr.indexOf(item) != index);
}

function generateNameCollisionWarning(duplicateNames: string[], statements: string[]) {
  if (!duplicateNames.length) {
    return;
  }

  const unique = [...new Set(duplicateNames)];
  const message = `// FIXME: (name-collision-error) There is a potential collision with Operation, Parameter and Response names.
          // Problematic names: [${unique.join()}]`;

  statements.push(message);
}

function generateMultiResponseWarning(responses: string[], statements: string[]) {
  responses.length > 2 &&
    statements.push(
      `// FIXME: (multi-response) Swagger defines multiple requests and responses.
       //      This needs to be revisited as Typespec supports linking specific responses to each request`,
    );
}

export function generateParameters(parameters: TypespecParameter[]) {
  const { isArm } = getOptions();
  if (parameters.length === 0) {
    return "";
  }
  if (parameters.length === 1 && parameters[0].location === "body") {
    if (parameters[0].type === "unknown") {
      return "void";
    } else {
      return parameters[0].type;
    }
  }
  const params: string[] = [];
  for (const parameter of parameters) {
    params.push(generateParameter(parameter));
  }
  if (isArm) {
    return `${params.join(",\n")}`;
  }
  return `{${params.join("\n")}}`;
}

export function generateOperationGroup(operationGroup: TypespecOperationGroup) {
  const statements: string[] = [];
  const doc = generateDocs(operationGroup);
  const { name, operations } = operationGroup;

  statements.push(`${doc}`);
  operationGroup.suppressions && statements.push(generateSuppressions(operationGroup.suppressions).join("\n"));
  const hasInterface = Boolean(name);
  hasInterface && statements.push(`interface ${name} {`);

  for (const operation of operations) {
    if ((operation as TspArmProviderActionOperation).kind !== undefined) {
      statements.push(generateProviderAction(operation as TspArmProviderActionOperation));
    } else {
      statements.push(generateOperation(operation as TypespecOperation, operationGroup));
    }
  }
  hasInterface && statements.push(`}`);

  return statements.join("\n");
}

export function generateOperationGroupExamples(operationGroup: TypespecOperationGroup): Record<string, string> {
  const examples: Record<string, string> = {};
  const { name, operations } = operationGroup;
  for (const operation of operations) {
    generateExamples(
      operation.examples ?? {},
      operation.operationId ?? getGeneratedOperationId(name, operation.name),
      examples,
    );
  }
  return examples;
}
