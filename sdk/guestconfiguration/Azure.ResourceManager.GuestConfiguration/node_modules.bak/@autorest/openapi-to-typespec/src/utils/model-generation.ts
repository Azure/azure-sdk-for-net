import { getArmCommonTypeVersion, isCommonTypeModel } from "../autorest-session";
import { generateParameter } from "../generate/generate-parameter";
import { TypespecObjectProperty, TypespecSpreadStatement, TypespecTemplateModel } from "../interfaces";
import { getOptions } from "../options";
import { generateDecorators } from "./decorators";
import { generateDocs } from "./docs";
import { generateSuppressions } from "./suppressions";
import { getFullyQualifiedName } from "./type-mapping";

export function getModelPropertiesDeclarations(properties: TypespecObjectProperty[]): string[] {
  const definitions: string[] = [];
  for (const property of properties) {
    definitions.push(...getModelPropertyDeclarations(property));
  }

  return definitions;
}

export function getModelPropertyDeclarations(property: TypespecObjectProperty): string[] {
  const definitions: string[] = [];
  const propertyDoc = generateDocs(property);
  propertyDoc && definitions.push(propertyDoc);
  const decorators = generateDecorators(property.decorators);
  decorators && definitions.push(decorators);
  property.fixMe && property.fixMe.length && definitions.push(property.fixMe.join("\n"));
  let defaultValue = "";
  if (property.defaultValue) {
    defaultValue = ` = ${property.defaultValue}`;
  }
  if (property.suppressions) {
    definitions.push(...generateSuppressions(property.suppressions));
  }
  definitions.push(
    `"${property.name}"${getOptionalOperator(property)}: ${getArmCommonTypeModelName(
      getFullyQualifiedName(property.type),
    )}${defaultValue};`,
  );
  return definitions;
}

export function getSpreadExpressionDecalaration(property: TypespecSpreadStatement): string {
  return `...${generateTemplateModel(property.model)}`;
}

function getOptionalOperator(property: TypespecObjectProperty) {
  return property.isOptional ? "?" : "";
}

export function generateTemplateModel(templateModel: TypespecTemplateModel): string {
  return `${templateModel.name}${
    templateModel.namedArguments
      ? `<${Object.keys(templateModel.namedArguments)
          .map(
            (k) =>
              `${k} = ${
                templateModel.name === "ResourceNameParameter"
                  ? templateModel.namedArguments![k]
                  : getArmCommonTypeModelName(templateModel.namedArguments![k])
              }`,
          )
          .join(",")}>`
      : ""
  }${
    !templateModel.namedArguments && templateModel.arguments
      ? `<${templateModel.arguments
          .map((a) =>
            a.kind === "template"
              ? generateTemplateModel(a as TypespecTemplateModel)
              : `${getArmCommonTypeModelName(a.name)}${
                  a.additionalProperties ? ` & { ${generateAdditionalProperties(a.additionalProperties)} }` : ""
                }`,
          )
          .join(",")}>`
      : ""
  }${
    templateModel.additionalProperties
      ? ` & { ${generateAdditionalProperties(templateModel.additionalProperties)} }`
      : ""
  }${templateModel.additionalTemplateModel ? templateModel.additionalTemplateModel : ""}`;
}

export function generateAdditionalProperties(properties: TypespecObjectProperty[]): string {
  return properties.map((p) => getModelPropertyDeclarations(p).join("\n")).join(";");
}

const commonTypeMapping: Record<string, string> = {
  Resource: "Azure.ResourceManager.CommonTypes.Resource",
  TrackedResource: "Azure.ResourceManager.CommonTypes.TrackedResource",
  ProxyResource: "Azure.ResourceManager.CommonTypes.ProxyResource",
  Sku: "Azure.ResourceManager.CommonTypes.Sku",
  OperationListResult: "Azure.ResourceManager.CommonTypes.OperationListResult",
  Operation: "Azure.ResourceManager.CommonTypes.Operation",
  OperationDisplay: "Azure.ResourceManager.CommonTypes.OperationDisplay",
  OperationStatusResult: "Azure.ResourceManager.CommonTypes.OperationStatusResult",
  locationData: "Azure.ResourceManager.CommonTypes.LocationData",
  ErrorDetail: "Azure.ResourceManager.CommonTypes.ErrorDetail",
  ErrorAdditionalInfo: "Azure.ResourceManager.CommonTypes.ErrorAdditionalInfo",
  Identity: "Azure.ResourceManager.CommonTypes.Identity",
  systemData: "Azure.ResourceManager.CommonTypes.SystemData",
  Plan: "Azure.ResourceManager.CommonTypes.Plan",
  encryptionProperties: "Azure.ResourceManager.CommonTypes.EncryptionProperties",
  KeyVaultProperties: "Azure.ResourceManager.CommonTypes.KeyVaultProperties",
  ResourceModelWithAllowedPropertySet: "Azure.ResourceManager.CommonTypes.ResourceModelWithAllowedPropertySet",
  CheckNameAvailabilityRequest: "Azure.ResourceManager.CommonTypes.CheckNameAvailabilityRequest",
  CheckNameAvailabilityResponse: "Azure.ResourceManager.CommonTypes.CheckNameAvailabilityResponse",
  ErrorResponse: "Azure.ResourceManager.CommonTypes.ErrorResponse",
  SkuTier: "Azure.ResourceManager.CommonTypes.SkuTier",
  PrivateEndpoint: "Azure.ResourceManager.CommonTypes.PrivateEndpoint",
  PrivateLinkResource: "Azure.ResourceManager.CommonTypes.PrivateLinkResource",
  PrivateEndpointConnection: "Azure.ResourceManager.CommonTypes.PrivateEndpointConnection",
  PrivateEndpointConnectionProperties: "Azure.ResourceManager.CommonTypes.PrivateEndpointConnectionProperties",
  PrivateLinkServiceConnectionState: "Azure.ResourceManager.CommonTypes.PrivateLinkServiceConnectionState",
  PrivateLinkResourceProperties: "Azure.ResourceManager.CommonTypes.PrivateLinkResourceProperties",
  PrivateEndpointServiceConnectionStatus: "Azure.ResourceManager.CommonTypes.PrivateEndpointServiceConnectionStatus",
  PrivateEndpointConnectionProvisioningState:
    "Azure.ResourceManager.CommonTypes.PrivateEndpointConnectionProvisioningState",
  ManagedServiceIdentity: "Azure.ResourceManager.CommonTypes.ManagedServiceIdentity",
  UserAssignedIdentities: "Azure.ResourceManager.CommonTypes.UserAssignedIdentities",
  SystemAssignedServiceIdentity: "Azure.ResourceManager.CommonTypes.SystemAssignedServiceIdentity",
  UserAssignedIdentity: "Azure.ResourceManager.CommonTypes.UserAssignedIdentity",
  ManagedServiceIdentityType: "Azure.ResourceManager.CommonTypes.ManagedServiceIdentityType",
  SystemAssignedServiceIdentityType: "Azure.ResourceManager.CommonTypes.SystemAssignedServiceIdentityType",
};
export function getArmCommonTypeModelName(model: string): string {
  if (!isCommonTypeModel(model)) {
    return model;
  }

  const version = getArmCommonTypeVersion();
  if (model === "PrivateEndpointConnectionListResult") {
    if (["v3", "v4", "v5"].includes(version)) {
      return "Azure.ResourceManager.CommonTypes.PrivateEndpointConnectionListResultV5";
    } else {
      return "Azure.ResourceManager.CommonTypes.PrivateEndpointConnectionListResult";
    }
  } else if (model === "PrivateLinkResourceListResult") {
    if (["v3", "v4", "v5"].includes(version)) {
      return "Azure.ResourceManager.CommonTypes.PrivateLinkResourceListResultV5";
    } else {
      return "Azure.ResourceManager.CommonTypes.PrivateLinkResourceListResult";
    }
  }

  return commonTypeMapping[model] || model;
}
