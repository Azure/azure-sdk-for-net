import {
  ChoiceSchema,
  ObjectSchema,
  ChoiceValue,
  Parameter,
  Property,
  Schema,
  SchemaType,
  SealedChoiceSchema,
  SerializationStyle,
  Operation,
  isNumberSchema,
} from "@autorest/codemodel";
import { TypespecDecorator, DecoratorArgument, WithSuppressDirective } from "../interfaces";
import { getOptions } from "../options";
import { createCSharpNameDecorator } from "../pretransforms/rename-pretransform";
import { getOwnDiscriminator } from "./discriminator";
import { isStringSchema, isUnixTimeSchema, isUuidSchema } from "./schemas";
import { escapeRegex } from "./strings";

export function getModelDecorators(model: ObjectSchema): TypespecDecorator[] {
  const decorators: TypespecDecorator[] = [];

  const ownDiscriminator = getOwnDiscriminator(model);

  if (ownDiscriminator) {
    decorators.push({
      name: "discriminator",
      arguments: [ownDiscriminator.serializedName],
    });
  }

  if (model.language.default.isError) {
    decorators.push({ name: "error" });
  }

  let resource = model.language.default.resource;
  if (resource) {
    if (resource.startsWith("/")) {
      // Remove the leading
      resource = resource.slice(1);
    }
    decorators.push({
      name: "resource",
      module: "@azure-tools/typespec-azure-core",
      namespace: "Azure.Core",
      arguments: [resource],
    });
  }

  return decorators;
}

export function getModelClientDecorators(model: ObjectSchema): TypespecDecorator[] {
  const decorators: TypespecDecorator[] = [];

  if (model.language.csharp?.name) {
    decorators.push(createCSharpNameDecorator(model));
  }
  return decorators;
}

export function getPropertyDecorators(element: Property | Parameter): TypespecDecorator[] {
  const { isFullCompatible } = getOptions();
  const decorators: TypespecDecorator[] = [];

  const paging = element.language.default.paging ?? {};

  if (!isParameter(element)) {
    const visibility = getPropertyVisibility(element);
    if (visibility.length) {
      decorators.push({
        name: "visibility",
        arguments: visibility.map((v) => ({ value: v, options: { unwrap: true } })),
      });
    }
  }

  if (paging.isNextLink) {
    decorators.push({ name: "nextLink" });
  }

  if (paging.isValue) {
    decorators.push({ name: "pageItems", module: "@azure-tools/typespec-azure-core", namespace: "Azure.Core" });
  }

  if (element.schema.type === SchemaType.Credential) {
    decorators.push({ name: "secret" });
  }

  getNumberSchemaDecorators(element.schema, decorators);
  getStringSchemaDecorators(element.schema, decorators);
  getUnixTimeSchemaDecorators(element.schema, decorators);
  getUuidSchemaDecorators(element.schema, decorators);

  if (element.language.default.isResourceKey) {
    decorators.push({
      name: "key",
      fixMe: [
        "// FIXME: (resource-key-guessing) - Verify that this property is the resource key, if not please update the model with the right one",
      ],
    });
  }

  if (isParameter(element) && element?.protocol?.http?.in) {
    const location = element.protocol.http.in === "body" ? "bodyRoot" : element.protocol.http.in;
    const locationDecorator: TypespecDecorator = { name: location };

    if (location === "query") {
      locationDecorator.arguments = [element.language.default.serializedName];
      if (element.schema.type === SchemaType.Array) {
        let format = "multi";
        switch (element.protocol.http?.style) {
          case SerializationStyle.Form:
            if (!element.protocol.http?.explode) {
              format = "csv";
            }
            break;
          case SerializationStyle.PipeDelimited:
            format = "pipes";
            break;
          case SerializationStyle.Simple:
            format = "csv";
            break;
          case SerializationStyle.SpaceDelimited:
            format = "ssv";
            break;
          case SerializationStyle.TabDelimited:
            format = "tsv";
            break;
        }
        locationDecorator.arguments =
          format === "multi"
            ? [
                {
                  value: `#{ name: "${element.language.default.serializedName}", explode: true }`,
                  options: { unwrap: true },
                },
              ]
            : [
                {
                  value:
                    format === "csv"
                      ? `"${element.language.default.serializedName}"`
                      : `{name: "${element.language.default.serializedName}", format: "${format}"}`,
                  options: { unwrap: true },
                },
              ];

        if (isFullCompatible && locationDecorator.name === "query" && format === "multi") {
          locationDecorator.suppressionCode = "@azure-tools/typespec-azure-core/no-query-explode";
          locationDecorator.suppressionMessage = "For backward compatibility";
        }
      }
    }

    decorators.push(locationDecorator);
  }

  if (!isParameter(element) && element.extensions?.["x-ms-identifiers"]?.length >= 0) {
    decorators.push({
      name: "identifiers",
      arguments: [
        {
          value: `#[${element.extensions!["x-ms-identifiers"].map((v: any) => `"${v}"`).join(", ")}]`,
          options: { unwrap: true },
        },
      ],
      namespace: "Azure.ResourceManager",
      module: "@azure-tools/typespec-azure-resource-manager",
    });
  }

  return decorators;
}

export function getPropertyClientDecorators(element: Property): TypespecDecorator[] {
  const { isFullCompatible } = getOptions();
  const decorators: TypespecDecorator[] = [];

  if (element.extensions?.["x-ms-client-flatten"] && isFullCompatible) {
    decorators.push({
      name: "Legacy.flattenProperty",
      module: "@azure-tools/typespec-client-generator-core",
      namespace: "Azure.ClientGenerator.Core",
      suppressionCode: "@azure-tools/typespec-azure-core/no-legacy-usage",
      suppressionMessage: "Property flatten for SDK backward compatibility.",
    });
  }

  if (element.language.default.name !== element.serializedName) {
    decorators.push({
      name: "clientName",
      module: "@azure-tools/typespec-client-generator-core",
      namespace: "Azure.ClientGenerator.Core",
      arguments: [element.language.default.name],
    });
  }

  if (element.language.csharp?.name) {
    decorators.push(createCSharpNameDecorator(element));
  }

  return decorators;
}

function isParameter(schema: Parameter | Property): schema is Parameter {
  return !(schema as Property).serializedName;
}

export function getPropertyVisibility(property: Property): string[] {
  const xmsMutability = property.extensions?.["x-ms-mutability"];
  if (!xmsMutability) {
    return property.readOnly ? ["Lifecycle.Read"] : [];
  }

  const visibility: string[] = [];

  if (Array.isArray(xmsMutability)) {
    if (xmsMutability.includes("read")) {
      visibility.push("Lifecycle.Read");
    }
    if (xmsMutability.includes("create")) {
      visibility.push("Lifecycle.Create");
    }
    if (xmsMutability.includes("update")) {
      visibility.push("Lifecycle.Update");
    }
  }

  return visibility;
}

function getUnixTimeSchemaDecorators(schema: Schema, decorators: TypespecDecorator[]): void {
  if (!isUnixTimeSchema(schema)) {
    return;
  }

  decorators.push({
    name: "encode",
    arguments: [
      { value: "unixTimestamp", options: { unwrap: false } },
      { value: "int32", options: { unwrap: true } },
    ],
  });
}

function getNumberSchemaDecorators(schema: Schema, decorators: TypespecDecorator[]): void {
  if (!isNumberSchema(schema)) {
    return;
  }

  if (schema.maximum) {
    if (schema.exclusiveMaximum) {
      decorators.push({ name: "maxValueExclusive", arguments: [schema.maximum] });
    } else {
      decorators.push({ name: "maxValue", arguments: [schema.maximum] });
    }
  }

  if (schema.minimum) {
    if (schema.exclusiveMinimum) {
      decorators.push({ name: "minValueExclusive", arguments: [schema.minimum] });
    } else {
      decorators.push({ name: "minValue", arguments: [schema.minimum] });
    }
  }
}

function getUuidSchemaDecorators(schema: Schema, decorators: TypespecDecorator[]): void {
  if (!isUuidSchema(schema)) {
    return;
  }

  decorators.push({
    name: "format",
    arguments: ["uuid"],
    suppressionCode: getOptions().isFullCompatible ? "@azure-tools/typespec-azure-core/no-format" : undefined,
  });
}

function getStringSchemaDecorators(schema: Schema, decorators: TypespecDecorator[]): void {
  if (!isStringSchema(schema)) {
    return;
  }

  if (schema.maxLength) {
    decorators.push({ name: "maxLength", arguments: [schema.maxLength] });
  }

  if (schema.minLength) {
    decorators.push({ name: "minLength", arguments: [schema.minLength] });
  }

  if (schema.pattern) {
    decorators.push({ name: "pattern", arguments: [escapeRegex(schema.pattern)] });
  }
}

export function getEnumClientDecorators(enumeration: SealedChoiceSchema | ChoiceSchema): TypespecDecorator[] {
  const decorators: TypespecDecorator[] = [];

  if (enumeration.language.csharp?.name) {
    decorators.push(createCSharpNameDecorator(enumeration));
  }

  return decorators;
}

export function getEnumChoiceClientDecorators(enumChoice: ChoiceValue): TypespecDecorator[] {
  const decorators: TypespecDecorator[] = [];

  if (enumChoice.language.csharp?.name) {
    decorators.push(createCSharpNameDecorator(enumChoice));
  }
  return decorators;
}

export function getOperationClientDecorators(operation: Operation): TypespecDecorator[] {
  const decorators: TypespecDecorator[] = [];

  if (operation.language.csharp?.name) {
    decorators.push(createCSharpNameDecorator(operation));
  }
  return decorators;
}

export function generateDecorators(decorators: TypespecDecorator[] = []): string {
  const definitions: string[] = [];
  for (const decorator of decorators ?? []) {
    if (decorator.fixMe) {
      definitions.push(decorator.fixMe.join(`\n`));
    }
    if (decorator.suppressionCode) {
      definitions.push(
        `#suppress "${decorator.suppressionCode}"${
          decorator.suppressionMessage ? ` "${decorator.suppressionMessage}"` : ""
        }`,
      );
    }
    if (decorator.arguments) {
      definitions.push(`@${decorator.name}(${decorator.arguments.map((a) => getArgumentValue(a)).join(", ")})`);
    } else {
      definitions.push(`@${decorator.name}`);
    }
  }

  return definitions.join("\n");
}

export function generateAugmentedDecorators(keyName: string, decorators: TypespecDecorator[] = []): string {
  const definitions: string[] = [];
  for (const decorator of decorators ?? []) {
    if (decorator.fixMe) {
      definitions.push(decorator.fixMe.join(`\n`));
    }
    if (decorator.suppressionCode) {
      definitions.push(
        `#suppress "${decorator.suppressionCode}"${
          decorator.suppressionMessage ? ` "${decorator.suppressionMessage}"` : ""
        }`,
      );
    }
    if (decorator.arguments) {
      definitions.push(
        `@@${decorator.name}(${decorator.target ?? keyName}, ${decorator.arguments
          .map((a) => getArgumentValue(a))
          .join(", ")})`,
      );
    } else {
      definitions.push(`@@${decorator.name}(${keyName})`);
    }
  }

  return definitions.join("\n");
}

function getArgumentValue(argument: DecoratorArgument | string | number | string[]): string {
  if (typeof argument === "string") {
    return `"${argument}"`;
  } else if (typeof argument === "number") {
    return `${argument}`;
  } else if (Array.isArray(argument)) {
    return `[${argument.map((a) => `"${a}"`).join(", ")}]`;
  } else {
    let value = argument.value;
    if (!argument.options?.unwrap) {
      value = `"${argument.value}"`;
    }

    return value;
  }
}
