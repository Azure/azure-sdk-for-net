import {
  ArraySchema,
  ChoiceSchema,
  ConstantSchema,
  DictionarySchema,
  Schema,
  SchemaResponse,
  SchemaType,
  SealedChoiceSchema,
  Response,
  AnySchema,
  StringSchema,
  ArmIdSchema,
  UriSchema,
  UuidSchema,
} from "@autorest/codemodel";

export function isConstantSchema(schema: Schema): schema is ConstantSchema {
  return schema.type === SchemaType.Constant;
}

export function isStringSchema(schema: Schema): schema is StringSchema {
  return schema.type === SchemaType.String;
}

export function isUriSchema(schema: Schema): schema is UriSchema {
  return schema.type === SchemaType.Uri;
}

export function isUuidSchema(schema: Schema): schema is UuidSchema {
  return schema.type === SchemaType.Uuid;
}

export function isArraySchema(schema: Schema): schema is ArraySchema {
  return schema.type === SchemaType.Array;
}

export function isChoiceSchema(schema: Schema): schema is ChoiceSchema {
  return schema.type === SchemaType.Choice;
}

export function isSealedChoiceSchema(schema: Schema): schema is SealedChoiceSchema {
  return schema.type === SchemaType.SealedChoice;
}

export function isDictionarySchema(schema: Schema): schema is DictionarySchema {
  return schema.type === SchemaType.Dictionary;
}

export function isResponseSchema(response: Response | SchemaResponse): response is SchemaResponse {
  return (response as SchemaResponse).schema !== undefined;
}

export function isAnySchema(schema: Schema): schema is AnySchema {
  return schema.type === SchemaType.Any;
}

export function isAnyObjectSchema(schema: Schema): schema is AnySchema {
  return schema.type === SchemaType.AnyObject;
}

export function isArmIdSchema(schema: Schema): schema is ArmIdSchema {
  return schema.type === SchemaType.ArmId;
}

export function isDurationSchema(schema: Schema): boolean {
  return schema.type === SchemaType.Duration;
}

export function isUnixTimeSchema(schema: Schema): boolean {
  return schema.type === SchemaType.UnixTime;
}
