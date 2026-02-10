import {
  ArraySchema,
  getAllProperties,
  isObjectSchema,
  ObjectSchema,
  Operation,
  Schema,
  SchemaResponse,
} from "@autorest/codemodel";
import { isArmIdSchema, isArraySchema, isDictionarySchema, isResponseSchema, isStringSchema } from "../utils/schemas";

// Common-type v2 resource doesn't have systemData
export function isResource(schema: ObjectSchema): boolean {
  let idPropertyFound = false;
  let typePropertyFound = false;
  let namePropertyFound = false;
  for (const property of getAllProperties(schema)) {
    if (property.flattenedNames) continue;

    if (property.serializedName === "id" && (isStringSchema(property.schema) || isArmIdSchema(property.schema))) {
      idPropertyFound = true;
    } else if (property.serializedName === "type" && isStringSchema(property.schema)) {
      typePropertyFound = true;
    } else if (property.serializedName === "name" && isStringSchema(property.schema)) {
      namePropertyFound = true;
    }
  }
  return idPropertyFound && typePropertyFound && namePropertyFound;
}

export function isTrackedResource(schema: ObjectSchema): [isTrackedResource: boolean, isOptionalLocation: boolean] {
  if (!isResource(schema)) return [false, false];

  let isLocationFound = false;
  let isOptionalLocation = false;
  let isTagsFound = false;
  for (const property of getAllProperties(schema)) {
    if (property.flattenedNames) continue;

    if (property.serializedName === "location" && isStringSchema(property.schema)) {
      isLocationFound = true;
      isOptionalLocation = property.required !== true;
    } else if (property.serializedName === "tags" && isDictionarySchema(property.schema)) {
      isTagsFound = true;
    }
  }
  return [isLocationFound && isTagsFound, isLocationFound && isTagsFound && isOptionalLocation];
}

export function getPagingItemType(operation: Operation, markPaging: boolean = false): string | undefined {
  const response = operation.responses?.find((r) => isResponseSchema(r));
  if (response === undefined) return undefined;

  let itemName = "value";
  if (operation.extensions?.["x-ms-pageable"]?.itemName) {
    itemName = operation.extensions?.["x-ms-pageable"]?.itemName;
  }

  const schemaResponse = response as SchemaResponse;
  if (isArraySchema(schemaResponse.schema)) {
    return schemaResponse.schema.elementType.language.default.name;
  }
  if (isObjectSchema(schemaResponse.schema)) {
    const responseSchema = schemaResponse.schema.properties?.find(
      (p) => p.serializedName === itemName && isArraySchema(p.schema),
    );
    if (!responseSchema) return undefined;

    markPaging && markPagination(schemaResponse.schema, operation);
    return (responseSchema.schema as ArraySchema).elementType.language.default.name;
  }
  return undefined;
}

function markPagination(schema: Schema, operation: Operation) {
  schema.language.default.paging = {
    ...schema.language.default.paging,
    isPageable: true,
  };

  if (!isObjectSchema(schema)) return;

  let itemName = "value";
  if (operation.extensions?.["x-ms-pageable"]?.itemName) {
    itemName = operation.extensions?.["x-ms-pageable"]?.itemName;
  }
  let nextLinkName = null;
  if (operation.extensions?.["x-ms-pageable"]?.nextLinkName) {
    nextLinkName = operation.extensions?.["x-ms-pageable"]?.nextLinkName;
  }
  for (const property of schema.properties ?? []) {
    if (property.serializedName === nextLinkName) {
      property.language.default.paging = {
        ...property.language.default.paging,
        isNextLink: true,
      };
    }

    if (property.serializedName === itemName) {
      property.language.default.paging = {
        ...property.language.default.paging,
        isValue: true,
      };
    }
  }
}
