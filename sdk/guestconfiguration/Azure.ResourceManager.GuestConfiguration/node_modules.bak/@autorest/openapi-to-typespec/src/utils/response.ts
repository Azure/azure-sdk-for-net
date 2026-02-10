import { ArraySchema, ObjectSchema, Operation, SchemaResponse } from "@autorest/codemodel";
import { getSession } from "../autorest-session";
import { getDataTypes } from "../data-types";
import { TypespecModel, TypespecObjectProperty } from "../interfaces";
import { getOptions } from "../options";
import { isArraySchema, isResponseSchema } from "./schemas";
import { isResourceListResult } from "./type-mapping";

export function transformSchemaResponse(response: SchemaResponse): TypespecModel {
  const codeModel = getSession().model;
  const dataTypes = getDataTypes(codeModel);
  const isArm = getOptions().isArm;

  const mediaTypes = response.protocol.http?.mediaTypes;
  let contentType = "";
  if (mediaTypes && ((mediaTypes as string[]).length !== 1 || (mediaTypes as string[])[0] !== "application/json")) {
    contentType = (mediaTypes as string[]).map((m) => `"${m}"`).join(" | ");
  }
  const additionalProperties: TypespecObjectProperty[] | undefined =
    contentType !== ""
      ? [
          {
            kind: "property",
            name: "contentType",
            isOptional: false,
            type: contentType,
            decorators: [{ name: "header" }],
          },
        ]
      : undefined;

  if (isArm && isResourceListResult(response as SchemaResponse)) {
    const valueSchema = ((response as SchemaResponse).schema as ObjectSchema).properties?.find(
      (p) => p.language.default.name === "value",
    );
    const valueName = dataTypes.get((valueSchema!.schema as ArraySchema).elementType)?.name ?? "void";
    return {
      kind: "template",
      name: "ResourceListResult",
      arguments: [{ kind: "object", name: valueName }],
      additionalProperties: additionalProperties,
    };
  }

  let responseTypeName = "";
  if (isArraySchema(response.schema)) {
    const itemName = dataTypes.get(response.schema.elementType)?.name;
    responseTypeName = `${itemName}[]`;
  } else responseTypeName = response.schema.language.default.name;

  return { kind: "object", name: responseTypeName, additionalProperties };
}

export function get200ResponseName(operation: Operation): string | undefined {
  const _200Response = operation.responses?.find((r) => r.protocol.http?.statusCodes[0] === "200");
  if (!_200Response || !isResponseSchema(_200Response)) return undefined;
  return _200Response.schema.language.default.name;
}
