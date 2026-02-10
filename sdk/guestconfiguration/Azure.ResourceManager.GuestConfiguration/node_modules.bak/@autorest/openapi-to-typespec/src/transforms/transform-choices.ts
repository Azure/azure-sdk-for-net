import { ChoiceSchema, ChoiceValue, CodeModel, SchemaType, SealedChoiceSchema } from "@autorest/codemodel";
import { getDataTypes } from "../data-types";
import { TypespecChoiceValue, TypespecEnum } from "../interfaces";
import { getEnumChoiceClientDecorators, getEnumClientDecorators } from "../utils/decorators";
import { transformValue } from "../utils/values";

export function transformEnum(schema: SealedChoiceSchema | ChoiceSchema, codeModel: CodeModel): TypespecEnum {
  const dataTypes = getDataTypes(codeModel);

  let typespecEnum = dataTypes.get(schema) as TypespecEnum;

  if (!typespecEnum) {
    typespecEnum = {
      decorators: [],
      clientDecorators: getEnumClientDecorators(schema),
      doc: schema.language.default.description,
      kind: "enum",
      name: schema.language.default.name.replace(/-/g, "_"),
      members: schema.choices.map((choice) => transformChoiceMember(choice)),
      isExtensible: !isSealedChoiceSchema(schema),
      ...(hasSyntheticName(schema) && {
        fixMe: [
          "// FIXME: (synthetic-name) This enum has a generated name. Please rename it to something more appropriate.",
        ],
      }),
      choiceType: schema.choiceType.type,
    };
    dataTypes.set(schema, typespecEnum);
  }
  return typespecEnum;
}

function hasSyntheticName(schema: ChoiceSchema | SealedChoiceSchema) {
  return schema.language.default.name.startsWith("components·");
}

function transformChoiceMember(member: ChoiceValue): TypespecChoiceValue {
  return {
    doc: member.language.default.description,
    name: member.language.default.name,
    value: transformValue(member.value),
    clientDecorators: getEnumChoiceClientDecorators(member),
  };
}

const isSealedChoiceSchema = (schema: any): schema is SealedChoiceSchema => {
  return schema.type === SchemaType.SealedChoice;
};
