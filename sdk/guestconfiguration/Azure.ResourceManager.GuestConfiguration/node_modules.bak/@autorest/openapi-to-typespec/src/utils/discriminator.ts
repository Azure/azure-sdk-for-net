import { ObjectSchema, Property } from "@autorest/codemodel";
import { TypespecObjectProperty } from "../interfaces";
import { getLogger } from "./logger";

export function getOwnDiscriminator(schema: ObjectSchema): Property | undefined {
  return schema.discriminator?.property;
}

export function getDiscriminator(schema: ObjectSchema): TypespecObjectProperty | undefined {
  if (!schema.discriminatorValue) {
    return undefined;
  }
  const discriminator = getDiscriminatorProperty(schema);
  if (!discriminator) {
    const logger = getLogger("getDiscriminator");
    logger.warning(`No discriminator property found for ${schema.language.default.name}`);
    return undefined;
  }
  const { serializedName: name, language } = discriminator;
  const type = `"${schema.discriminatorValue}"`;

  return {
    isOptional: false,
    name,
    type,
    kind: "property",
    doc: language.default.description,
  };
}

function getDiscriminatorProperty(schema: ObjectSchema): Property | undefined {
  const logger = getLogger("getDiscriminatorProperty");

  logger.info(`Getting discriminator property for ${schema.language.default.name}`);

  if (schema.discriminator?.property) {
    return schema.discriminator.property;
  }

  if (!schema.parents?.immediate || schema.parents.immediate.length === 0) {
    return;
  }

  for (const parent of schema.parents.immediate as ObjectSchema[]) {
    const discriminator = getDiscriminatorProperty(parent);

    if (discriminator) {
      return discriminator;
    }
  }
}
