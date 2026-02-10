import {
  ChoiceSchema,
  CodeModel,
  isObjectSchema,
  ObjectSchema,
  Property,
  SealedChoiceSchema,
} from "@autorest/codemodel";
import { Style } from "@azure-tools/codegen";

// Skip casing transform if there are n upper case letters next to each other.
const MAX_UPPERCASE_PRESERVE = 3;

export function pretransformNames(codeModel: CodeModel) {
  codeModel.schemas.objects?.forEach(preTransformObjectName);
  [...(codeModel.schemas.choices ?? []), ...(codeModel.schemas.sealedChoices ?? [])].forEach(preTransformEnums);
}

const pascal = (name: string) => Style.pascal(name.replace(/\$/g, ""), false, {}, MAX_UPPERCASE_PRESERVE);
const camel = (name: string) => Style.camel(name.replace(/\$/g, ""), false, {}, MAX_UPPERCASE_PRESERVE);

function preTransformEnums(schema: ChoiceSchema | SealedChoiceSchema) {
  schema.language.default.name = pascal(schema.language.default.name);
}

function preTransformObjectName(schema: ObjectSchema) {
  schema.language.default.name = pascal(schema.language.default.name);
  schema.properties?.forEach(preTransformObjectPropertyName);
}

function preTransformObjectPropertyName(property: Property) {
  property.language.default.name = camel(property.language.default.name);
  property.language.default.pretransformed = true;
  if (isObjectSchema(property.schema)) {
    property.schema.properties
      ?.filter((p) => !p.language.default.pretransformed)
      .forEach(preTransformObjectPropertyName);
  }
}
