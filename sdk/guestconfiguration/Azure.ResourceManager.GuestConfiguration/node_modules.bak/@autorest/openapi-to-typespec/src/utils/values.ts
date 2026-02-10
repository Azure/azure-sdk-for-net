import { Schema } from "@autorest/codemodel";
import { isArraySchema, isChoiceSchema, isDurationSchema, isSealedChoiceSchema } from "./schemas";

export function transformValue(value: string | number | boolean) {
  if (typeof value === "string") {
    return `"${value}"`;
  }

  return value;
}

export function getDefaultValue(type: string, schema: Schema) {
  if (schema.defaultValue === undefined) {
    return undefined;
  }
  if (isChoiceSchema(schema) || isSealedChoiceSchema(schema)) {
    for (const choice of schema.choices) {
      if (schema.defaultValue === choice.value.toString()) {
        return `${type}.\`${choice.language.default.name}\``;
      }
    }
  } else if (isDurationSchema(schema)) {
    // TODO: need to add back default value when TypeSpec supports
    return undefined;
  } else if (isArraySchema(schema)) {
    return `#[${schema.defaultValue
      .map((v: any) => {
        schema.elementType.defaultValue = v;
        return getDefaultValue(schema.elementType.type, schema.elementType);
      })
      .join(", ")}]`;
  } else {
    return transformValue(schema.defaultValue);
  }
}
