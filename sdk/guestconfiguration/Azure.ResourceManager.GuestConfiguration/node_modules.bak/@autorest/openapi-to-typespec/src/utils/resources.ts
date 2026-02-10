import {
  ArraySchema,
  CodeModel,
  ComplexSchema,
  HttpMethod,
  isObjectSchema,
  ObjectSchema,
  Operation,
  Property,
  Schema,
  SchemaResponse,
} from "@autorest/codemodel";
import { getDataTypes } from "../data-types";
import { TypespecResource } from "../interfaces";
import { transformDataType } from "../model";
import { getOptions } from "../options";
import { hasLROExtension } from "./lro";
import { getHttpMethod } from "./operations";
import { getPageableResponse, isPageableOperation, isPageValue } from "./paging";
import { isArraySchema, isResponseSchema } from "./schemas";

const knownResourceSchema: Map<string, Schema> = new Map();

export function markResources(codeModel: CodeModel) {
  for (const operationGroup of codeModel.operationGroups) {
    for (const operation of operationGroup.operations) {
      const resource = getResourceKind(codeModel, operation);
      if (resource) {
        operation.language.default.resource = resource;
      }
    }
  }
}

/**
 * Figures out if the path represents an
 */
// function markActionResource(codeModel: CodeModel, operation: Operation): void {
//   const method = getHttpMethod(codeModel, operation);
//   const pathParts = getResourcePath(operation).split("/");
//   const partsLastIndex = pathParts.length - 1;

//   if (method !== HttpMethod.Post) {
//     return;
//   }

//   const lastPart = pathParts[partsLastIndex];

//   if (lastPart.startsWith(":")) {
//     operation.language.default.actionResource = {
//       resource: pathParts.slice(0, partsLastIndex).join("/"),
//       action: lastPart,
//     };
//   }
// }

function isActionOperation(operation: Operation) {
  const path = getResourcePath(operation);
  const pathParts = path.split("/");
  const lastPart = pathParts[pathParts.length - 1];
  return lastPart.startsWith(":");
}

function getResourceKind(codeModel: CodeModel, operation: Operation): TypespecResource | undefined {
  if (isActionOperation(operation)) {
    // Actions are not yet supported
    return undefined;
  }

  const operationMethod = getHttpMethod(codeModel, operation);
  if (hasLROExtension(operation)) {
    const resource = handleLROResource(codeModel, operation);
    if (resource) {
      return resource;
    }
  }

  if (operationMethod === HttpMethod.Get) {
    const resource = handleGetOperation(codeModel, operation);
    if (resource) {
      return resource;
    }
  }

  if (operationMethod === HttpMethod.Patch) {
    const resource = handleResource(codeModel, operation, "ResourceCreateOrUpdate");
    if (resource) {
      return resource;
    }
  }

  if (operationMethod === HttpMethod.Put) {
    const resource = handleResource(codeModel, operation, "ResourceCreateOrReplace");
    if (resource) {
      return resource;
    }
  }

  if (operationMethod === HttpMethod.Post) {
    const resource = handleResource(codeModel, operation, "ResourceCreateWithServiceProvidedName");
    if (resource) {
      return resource;
    }
  }

  if (operationMethod === HttpMethod.Delete) {
    const resource = handleResource(codeModel, operation, "ResourceDelete");
    if (resource) {
      return resource;
    }
  }

  if (operation.language.default.actionResource) {
    return handleResource(codeModel, operation, "ResourceAction");
  }

  return undefined;
}

function handleLROResource(codeModel: CodeModel, operation: Operation): TypespecResource | undefined {
  const operationMethod = getHttpMethod(codeModel, operation);

  if (operationMethod === HttpMethod.Patch) {
    return handleResource(codeModel, operation, "LongRunningResourceCreateOrUpdate");
  }

  if (operationMethod === HttpMethod.Put) {
    return handleResource(codeModel, operation, "LongRunningResourceCreateOrReplace");
  }

  if (operationMethod === HttpMethod.Post) {
    return handleResource(codeModel, operation, "LongRunningResourceCreateWithServiceProvidedName");
  }

  if (operationMethod === HttpMethod.Delete) {
    return handleResource(codeModel, operation, "LongRunningResourceDelete");
  }

  return undefined;
}

function handleResource(
  codeModel: CodeModel,
  operation: Operation,
  kind:
    | "ResourceRead"
    | "ResourceCreateOrUpdate"
    | "ResourceCreateOrReplace"
    | "ResourceCreateWithServiceProvidedName"
    | "ResourceDelete"
    | "LongRunningResourceCreateOrReplace"
    | "LongRunningResourceCreateOrUpdate"
    | "LongRunningResourceCreateWithServiceProvidedName"
    | "LongRunningResourceDelete"
    | "ResourceAction",
): TypespecResource | undefined {
  const dataTypes = getDataTypes(codeModel);
  for (const response of operation.responses ?? []) {
    let schema: Schema | undefined;
    if (!isResponseSchema(response)) {
      let resourcePath = getResourcePath(operation);
      schema = knownResourceSchema.get(resourcePath);

      if (kind === "ResourceAction" && operation.language.default.actionResource?.resource) {
        resourcePath = operation.language.default.actionResource.resource;
        schema = knownResourceSchema.get(resourcePath);
      }

      if (!schema) {
        continue;
      }
    } else {
      schema = response.schema;
    }
    if (!markResource(operation, schema)) {
      return undefined;
    }
    const typespecResponse = dataTypes.get(schema) ?? transformDataType(schema, codeModel);
    return {
      kind,
      response: typespecResponse,
    };
  }

  return undefined;
}

function getResourcePath(operation: Operation): string {
  for (const requests of operation.requests ?? []) {
    const path = requests.protocol.http?.path;
    if (path) {
      return path;
    }
  }

  throw new Error(`Couldn't find a resource path for operation ${operation.language.default.name}`);
}

function getNonPageableListResource(operation: Operation): ArraySchema | undefined {
  if (!operation.responses) {
    throw new Error(`Operation ${operation.language.default.name} has no defined responses`);
  }
  for (const response of operation.responses) {
    let schema: Schema | undefined;
    if (!isResponseSchema(response)) {
      const resourcePath = getResourcePath(operation);
      schema = knownResourceSchema.get(resourcePath);

      if (!schema) {
        continue;
      }
    } else {
      schema = response.schema;
    }

    if (!isArraySchema(schema)) {
      return undefined;
    }
  }

  const firstResponse = operation.responses[0];
  return isResponseSchema(firstResponse) && isArraySchema(firstResponse.schema) ? firstResponse.schema : undefined;
}

function handleGetOperation(codeModel: CodeModel, operation: Operation): TypespecResource | undefined {
  if (isPageableOperation(operation)) {
    return getPageableResource(codeModel, operation);
  }

  const nonPageableListResource = getNonPageableListResource(operation);
  if (nonPageableListResource) {
    if (!markResource(operation, nonPageableListResource.elementType)) {
      return undefined;
    }
    const dataTypes = getDataTypes(codeModel);
    const typespecResponse =
      dataTypes.get(nonPageableListResource.elementType) ??
      transformDataType(nonPageableListResource.elementType, codeModel);
    return {
      kind: "NonPagedResourceList",
      response: typespecResponse,
    };
  }

  return handleResource(codeModel, operation, "ResourceRead");
}

function markResource(operation: Operation, elementType: Schema) {
  if (!isObjectSchema(elementType)) {
    return false;
  }

  const hasKey = markWithKey(elementType);
  if (hasKey) {
    markModelWithResource(elementType, getResourcePath(operation));
    return true;
  }

  return false;
}

function getPageableResource(codeModel: CodeModel, operation: Operation): TypespecResource | undefined {
  const response = getPageableResponse(operation) as SchemaResponse;
  if (isObjectSchema(response.schema)) {
    for (const property of response.schema.properties ?? []) {
      if (isPageValue(property) && isArraySchema(property.schema)) {
        const dataTypes = getDataTypes(codeModel);

        const elementType = property.schema.elementType;
        if (isObjectSchema(elementType)) {
          if (!markResource(operation, elementType)) {
            return undefined;
          }
        }

        const typespecResponse = dataTypes.get(elementType) ?? transformDataType(elementType, codeModel);
        return {
          kind: "ResourceList",
          response: typespecResponse,
        };
      }
    }
  }

  throw new Error(`Couldn't determine the Pageable resource for the operation: ${operation.language.default.name}`);
}

function markModelWithResource(elementType: Schema, resource: string) {
  knownResourceSchema.set(resource, elementType);
  elementType.language.default.resource = resource;
}

function markWithKey(schema: ObjectSchema): boolean {
  const { properties, parents } = schema;
  const options = getOptions();
  const { guessResourceKey } = options;

  if (!guessResourceKey) {
    return false;
  }

  if (parents && parents.immediate.length) {
    if (hasParentWithKey(parents.immediate)) {
      return false;
    }
    const defaultKeyInParent = shouldTryDefaultKeyInParent(schema);
    if (markParents(parents.immediate, defaultKeyInParent)) {
      return false;
    }
  }

  return markKeyProperty(properties ?? [], true);
}

function hasParentWithKey(parents: ComplexSchema[]) {
  for (const parent of parents) {
    if (!isObjectSchema(parent)) {
      continue;
    }

    const properties = parent.properties ?? [];

    if (properties.some((p) => p.language.default.isResourceKey)) {
      return true;
    }
  }

  return false;
}

function markParents(parents: ComplexSchema[], defaultToFirst = false): boolean {
  for (const parent of parents) {
    if (!isObjectSchema(parent)) {
      continue;
    }

    const properties = parent.properties ?? [];
    if (markKeyProperty(properties, defaultToFirst)) {
      return true;
    }
  }

  return false;
}

function shouldTryDefaultKeyInParent(schema: ObjectSchema) {
  if (schema.properties && schema.properties.some((p) => p.required)) {
    return false;
  }

  return true;
}

function markKeyProperty(allProperties: Property[], defaultToFirst = false): boolean {
  const properties = allProperties.filter((p) => p.required && !p.isDiscriminator);

  for (const property of properties) {
    const serializedName = property.serializedName.toLowerCase();
    if (serializedName.endsWith("name") || serializedName.endsWith("key") || serializedName.endsWith("id")) {
      property.language.default.isResourceKey = true;
      return true;
    }
  }

  if (defaultToFirst) {
    const firstRequired = properties.find((p) => p.required);
    if (firstRequired) {
      firstRequired.language.default.isResourceKey = true;
    }
  }

  return false;
}
