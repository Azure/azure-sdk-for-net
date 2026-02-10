import { ArraySchema, HttpMethod, isObjectSchema, Operation, SchemaResponse } from "@autorest/codemodel";
import { isArraySchema, isConstantSchema, isResponseSchema } from "../utils/schemas";
import { ProvidersSegment } from "./constants";
import { isResource } from "./resource-equivalent";

export interface OperationSet {
  RequestPath: string;
  Operations: Array<Operation>;
  SingletonRequestPath: string | undefined;
}

const resourceDataSchemaCache = new WeakMap<OperationSet, string | undefined>();

export function getResourceDataSchema(set: OperationSet): string | undefined {
  if (resourceDataSchemaCache.has(set)) return resourceDataSchemaCache.get(set);

  // Check if the request path has even number of segments after the providers segment
  if (!checkEvenSegments(set.RequestPath)) {
    resourceDataSchemaCache.set(set, undefined);
    return undefined;
  }

  // before we are finding any operations, we need to ensure this operation set has a GET request.
  if (findOperation(set, HttpMethod.Get) === undefined) {
    resourceDataSchemaCache.set(set, undefined);
    return undefined;
  }

  // try put operation to get the resource name
  let resourceSchemaName = getResourceSchemaName(set, HttpMethod.Put);
  if (resourceSchemaName !== undefined) {
    resourceDataSchemaCache.set(set, resourceSchemaName);
    return resourceSchemaName;
  }

  // try get operation to get the resource name
  resourceSchemaName = getResourceSchemaName(set, HttpMethod.Get);
  if (resourceSchemaName !== undefined) {
    resourceDataSchemaCache.set(set, resourceSchemaName);
    return resourceSchemaName;
  }

  // We tried everything, this is not a resource
  resourceDataSchemaCache.set(set, undefined);
  return undefined;
}

export function setResourceDataSchema(set: OperationSet, resourceDataName: string): void {
  resourceDataSchemaCache.set(set, resourceDataName);
}

function checkEvenSegments(path: string): boolean {
  const index = path.lastIndexOf(ProvidersSegment);

  // this request path does not have providers segment - it can be a "ById" request, skip to next criteria
  if (index < 0) return true;

  // get whatever following the providers
  const following = path.substring(index);
  const segments = following.split("/").filter((s) => s.length > 0);
  return segments.length % 2 === 0;
}

export function populateSingletonRequestPath(set: OperationSet): void {
  const updatedSegments: string[] = [];
  const segments = set.RequestPath.split("/");
  for (const segment of segments) {
    if (segment.match(/^\{\w+\}$/) === null) {
      updatedSegments.push(segment);
    } else {
      const keyName = segment.replace(/^\{(\w+)\}$/, "$1");
      const resourceKeyParameter = set.Operations[0].parameters?.find(
        (p) => p.language.default.name === keyName || p.language.default.serializedName === keyName,
      );
      if (resourceKeyParameter === undefined)
        throw `Cannot find parameter ${keyName} in operation ${set.Operations[0].operationId}`;

      if (!isConstantSchema(resourceKeyParameter.schema)) {
        updatedSegments.push(segment);
      } else {
        const value = resourceKeyParameter.schema.value.value;
        updatedSegments.push(value);
      }
    }
  }
  set.SingletonRequestPath = updatedSegments.join("/");
}

export function findOperation(set: OperationSet, method: HttpMethod): Operation | undefined {
  return set.Operations.find((o) => o.requests![0].protocol.http?.method === method);
}

function getResourceSchemaName(set: OperationSet, method: HttpMethod): string | undefined {
  const operation = findOperation(set, method);
  if (operation === undefined) return undefined;

  // find the response with code 200
  const response = operation.responses?.find((r) => r.protocol.http?.statusCodes.includes("200"));
  if (response === undefined) return undefined;

  // find the response schema
  if (!isResponseSchema(response) || !isObjectSchema(response.schema)) return undefined;

  // we need to verify this schema has ID, type and name so that this is a resource model
  if (!isResource(response.schema)) return undefined;

  return response.schema.language.default.name;
}
