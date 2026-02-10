import { Property } from "@autorest/codemodel";
import { TypespecDecorator, TypespecSpreadStatement } from "../interfaces";
import {
  extendedLocationLibraryType,
  isEquivalent,
  LibraryType,
  managedServiceIdentityLibraryType,
  planLibraryType,
  skuLibraryType,
} from "./library-type-mapping";
import { ArmResourceSchema } from "./resource-discovery";

interface Envelope {
  serializedName: string;
  required: boolean;
  isReadOnly: boolean;
  schema: LibraryType;

  envelopeName: string;
}

const knownEnvelopes: Record<string, Envelope> = {
  sku: {
    serializedName: "sku",
    required: false,
    isReadOnly: false,
    schema: skuLibraryType,
    envelopeName: "Azure.ResourceManager.ResourceSkuProperty",
  },
  plan: {
    serializedName: "plan",
    required: false,
    isReadOnly: false,
    schema: planLibraryType,
    envelopeName: "Azure.ResourceManager.ResourcePlanProperty",
  },
  extendedLocation: {
    serializedName: "extendedLocation",
    required: false,
    isReadOnly: true,
    schema: extendedLocationLibraryType,
    envelopeName: "Azure.ResourceManager.ExtendedLocationProperty",
  },
  zones: {
    serializedName: "zones",
    required: false,
    isReadOnly: false,
    schema: {
      name: "_",
      type: "array",
      elementType: () => ({ name: "string", type: "primitive", schema: (schema) => schema.type === "string" }),
    },
    envelopeName: "Azure.ResourceManager.AvailabilityZonesProperty",
  },
  identity: {
    serializedName: "identity",
    required: false,
    isReadOnly: false,
    schema: managedServiceIdentityLibraryType,
    envelopeName: "Azure.ResourceManager.ManagedServiceIdentityProperty",
  },
  eTag: {
    serializedName: "eTag",
    required: false,
    isReadOnly: true,
    schema: { name: "string", type: "primitive", schema: (schema) => schema.type === "string" },
    envelopeName: "Azure.ResourceManager.EntityTagProperty",
  },
  etag: {
    serializedName: "etag",
    required: false,
    isReadOnly: true,
    schema: { name: "string", type: "primitive", schema: (schema) => schema.type === "string" },
    envelopeName: "Azure.ResourceManager.Legacy.EntityTagProperty",
  },
};

export function getEnvelopeProperty(property: Property): TypespecSpreadStatement | undefined {
  for (const key of Object.keys(knownEnvelopes)) {
    const envelope = knownEnvelopes[key];
    if (
      property.serializedName === envelope.serializedName &&
      (property.required ?? false) === envelope.required &&
      (property.readOnly ?? false) === envelope.isReadOnly &&
      isEquivalent(property.schema, envelope.schema)
    ) {
      return {
        kind: "spread",
        model: {
          kind: "template",
          name: envelope.envelopeName,
        },
      };
    }
  }
}

export function getEnvelopeAugmentedDecorator(
  schema: ArmResourceSchema,
  property: Property,
): TypespecDecorator | undefined {
  for (const key of Object.keys(knownEnvelopes)) {
    const envelope = knownEnvelopes[key];
    if (
      property.serializedName.toLowerCase() === envelope.serializedName.toLowerCase() &&
      property.serializedName !== envelope.serializedName
    ) {
      return {
        name: "encodedName",
        target: `${schema.resourceMetadata[0].SwaggerModelName}.${envelope.serializedName}`,
        arguments: ["application/json", property.serializedName], // Currently we only support application/json
      };
    }
  }
}
