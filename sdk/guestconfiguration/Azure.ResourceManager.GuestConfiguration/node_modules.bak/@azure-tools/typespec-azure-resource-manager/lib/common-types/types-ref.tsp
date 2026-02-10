import "../private.decorators.tsp";
import "./common-types.tsp";
import "./types.tsp";

using Azure.ResourceManager.Private;
using Azure.ResourceManager.CommonTypes.Private;

namespace Azure.ResourceManager.CommonTypes;

@@azureResourceBase(Resource);
@@azureResourceBase(ResourceModelWithAllowedPropertySet);

/** Common resource fields that are returned in the response for all Azure Resource Manager resources. */
@@armCommonDefinition(Resource, "Resource", Azure.ResourceManager.CommonTypes.Versions.v3);
@@armCommonDefinition(Resource, "Resource", Azure.ResourceManager.CommonTypes.Versions.v4);
@@armCommonDefinition(Resource, "Resource", Azure.ResourceManager.CommonTypes.Versions.v5);
@@armCommonDefinition(Resource, "Resource", Azure.ResourceManager.CommonTypes.Versions.v6);

/** The resource model definition for an Azure Resource Manager resource with an etag. */
@@armCommonDefinition(AzureEntityResource,
  "TrackedResource",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonDefinition(AzureEntityResource,
  "TrackedResource",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonDefinition(AzureEntityResource,
  "TrackedResource",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonDefinition(AzureEntityResource,
  "TrackedResource",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/**
 * The base tracked resource.
 */
@@armCommonDefinition(TrackedResource,
  "TrackedResource",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonDefinition(TrackedResource,
  "TrackedResource",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonDefinition(TrackedResource,
  "TrackedResource",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonDefinition(TrackedResource,
  "TrackedResource",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/**
 * The base proxy resource.
 */
@@armCommonDefinition(ProxyResource,
  "ProxyResource",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonDefinition(ProxyResource,
  "ProxyResource",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonDefinition(ProxyResource,
  "ProxyResource",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonDefinition(ProxyResource,
  "ProxyResource",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/**
 * The base extension resource.
 */
@@armCommonDefinition(ExtensionResource,
  "ProxyResource",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonDefinition(ExtensionResource,
  "ProxyResource",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonDefinition(ExtensionResource,
  "ProxyResource",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonDefinition(ExtensionResource,
  "ProxyResource",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/**
 * The SKU (Stock Keeping Unit) assigned to this resource.
 */
@@armCommonDefinition(Sku, "Sku", Azure.ResourceManager.CommonTypes.Versions.v3);
@@armCommonDefinition(Sku, "Sku", Azure.ResourceManager.CommonTypes.Versions.v4);
@@armCommonDefinition(Sku, "Sku", Azure.ResourceManager.CommonTypes.Versions.v5);
@@armCommonDefinition(Sku, "Sku", Azure.ResourceManager.CommonTypes.Versions.v6);

/**
 * A list of REST API operations supported by an Azure Resource Provider. It contains an URL link to get the next set of results.
 */
@@armCommonDefinition(OperationListResult,
  "OperationListResult",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonDefinition(OperationListResult,
  "OperationListResult",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonDefinition(OperationListResult,
  "OperationListResult",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonDefinition(OperationListResult,
  "OperationListResult",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/**
 * Details of a REST API operation, returned from the Resource Provider Operations API
 */
@@armCommonDefinition(Operation, "Operation", Azure.ResourceManager.CommonTypes.Versions.v3);
@@armCommonDefinition(Operation, "Operation", Azure.ResourceManager.CommonTypes.Versions.v4);
@@armCommonDefinition(Operation, "Operation", Azure.ResourceManager.CommonTypes.Versions.v5);
@@armCommonDefinition(Operation, "Operation", Azure.ResourceManager.CommonTypes.Versions.v6);

/**
 * Localized display information for an operation.
 */
@@armCommonDefinition(OperationDisplay,
  "OperationDisplay",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonDefinition(OperationDisplay,
  "OperationDisplay",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonDefinition(OperationDisplay,
  "OperationDisplay",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonDefinition(OperationDisplay,
  "OperationDisplay",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/**
 * The current status of an async operation.
 */
@@armCommonDefinition(OperationStatusResult,
  "OperationStatusResult",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonDefinition(OperationStatusResult,
  "OperationStatusResult",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonDefinition(OperationStatusResult,
  "OperationStatusResult",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonDefinition(OperationStatusResult,
  "OperationStatusResult",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/**
 * locationData
 */
@@armCommonDefinition(LocationData, "locationData", Azure.ResourceManager.CommonTypes.Versions.v3);
@@armCommonDefinition(LocationData, "locationData", Azure.ResourceManager.CommonTypes.Versions.v4);
@@armCommonDefinition(LocationData, "locationData", Azure.ResourceManager.CommonTypes.Versions.v5);
@@armCommonDefinition(LocationData, "locationData", Azure.ResourceManager.CommonTypes.Versions.v6);

/**
 * The error detail.
 */
@@armCommonDefinition(ErrorDetail, "ErrorDetail", Azure.ResourceManager.CommonTypes.Versions.v3);
@@armCommonDefinition(ErrorDetail, "ErrorDetail", Azure.ResourceManager.CommonTypes.Versions.v4);
@@armCommonDefinition(ErrorDetail, "ErrorDetail", Azure.ResourceManager.CommonTypes.Versions.v5);
@@armCommonDefinition(ErrorDetail, "ErrorDetail", Azure.ResourceManager.CommonTypes.Versions.v6);

/**
 * The resource management error additional info.
 */
@@armCommonDefinition(ErrorAdditionalInfo,
  "ErrorAdditionalInfo",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonDefinition(ErrorAdditionalInfo,
  "ErrorAdditionalInfo",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonDefinition(ErrorAdditionalInfo,
  "ErrorAdditionalInfo",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonDefinition(ErrorAdditionalInfo,
  "ErrorAdditionalInfo",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/**
 * Identity
 */
@@armCommonDefinition(Identity, "Identity", Azure.ResourceManager.CommonTypes.Versions.v3);
@@armCommonDefinition(Identity, "Identity", Azure.ResourceManager.CommonTypes.Versions.v4);
@@armCommonDefinition(Identity, "Identity", Azure.ResourceManager.CommonTypes.Versions.v5);

/**
 * Metadata pertaining to creation and last modification of the resource.
 */
@@armCommonDefinition(SystemData, "systemData", Azure.ResourceManager.CommonTypes.Versions.v3);
@@armCommonDefinition(SystemData, "systemData", Azure.ResourceManager.CommonTypes.Versions.v4);
@@armCommonDefinition(SystemData, "systemData", Azure.ResourceManager.CommonTypes.Versions.v5);
@@armCommonDefinition(SystemData, "systemData", Azure.ResourceManager.CommonTypes.Versions.v6);

/**
 * Details of the resource plan.
 */
@@armCommonDefinition(Plan, "Plan", Azure.ResourceManager.CommonTypes.Versions.v3);
@@armCommonDefinition(Plan, "Plan", Azure.ResourceManager.CommonTypes.Versions.v4);
@@armCommonDefinition(Plan, "Plan", Azure.ResourceManager.CommonTypes.Versions.v5);
@@armCommonDefinition(Plan, "Plan", Azure.ResourceManager.CommonTypes.Versions.v6);

/**
 * encryptionProperties
 */
@@armCommonDefinition(EncryptionProperties,
  "encryptionProperties",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonDefinition(EncryptionProperties,
  "encryptionProperties",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonDefinition(EncryptionProperties,
  "encryptionProperties",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonDefinition(EncryptionProperties,
  "encryptionProperties",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/**
 * KeyVaultProperties
 */
@@armCommonDefinition(KeyVaultProperties,
  "KeyVaultProperties",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonDefinition(KeyVaultProperties,
  "KeyVaultProperties",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonDefinition(KeyVaultProperties,
  "KeyVaultProperties",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonDefinition(KeyVaultProperties,
  "KeyVaultProperties",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/**
 * ResourceModelWithAllowedPropertySet
 */
@@armCommonDefinition(ResourceModelWithAllowedPropertySet,
  "ResourceModelWithAllowedPropertySet",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonDefinition(ResourceModelWithAllowedPropertySet,
  "ResourceModelWithAllowedPropertySet",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonDefinition(ResourceModelWithAllowedPropertySet,
  "ResourceModelWithAllowedPropertySet",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonDefinition(ResourceModelWithAllowedPropertySet,
  "ResourceModelWithAllowedPropertySet",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/**
 * The check availability request body.
 */
@@armCommonDefinition(CheckNameAvailabilityRequest,
  "CheckNameAvailabilityRequest",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonDefinition(CheckNameAvailabilityRequest,
  "CheckNameAvailabilityRequest",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonDefinition(CheckNameAvailabilityRequest,
  "CheckNameAvailabilityRequest",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonDefinition(CheckNameAvailabilityRequest,
  "CheckNameAvailabilityRequest",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/**
 * The check availability result.
 */
@@armCommonDefinition(CheckNameAvailabilityResponse,
  "CheckNameAvailabilityResponse",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonDefinition(CheckNameAvailabilityResponse,
  "CheckNameAvailabilityResponse",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonDefinition(CheckNameAvailabilityResponse,
  "CheckNameAvailabilityResponse",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonDefinition(CheckNameAvailabilityResponse,
  "CheckNameAvailabilityResponse",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

@@armCommonDefinition(ErrorResponse,
  "ErrorResponse",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonDefinition(ErrorResponse,
  "ErrorResponse",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonDefinition(ErrorResponse,
  "ErrorResponse",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonDefinition(ErrorResponse,
  "ErrorResponse",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

@@armCommonDefinition(SkuTier, "SkuTier", Azure.ResourceManager.CommonTypes.Versions.v3);
@@armCommonDefinition(SkuTier, "SkuTier", Azure.ResourceManager.CommonTypes.Versions.v4);
@@armCommonDefinition(SkuTier, "SkuTier", Azure.ResourceManager.CommonTypes.Versions.v5);
@@armCommonDefinition(SkuTier, "SkuTier", Azure.ResourceManager.CommonTypes.Versions.v6);

// -- Parameters
/** ApiVersionParameter */
@@armCommonParameter(ApiVersionParameter.apiVersion,
  "ApiVersionParameter",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonParameter(ApiVersionParameter.apiVersion,
  "ApiVersionParameter",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonParameter(ApiVersionParameter.apiVersion,
  "ApiVersionParameter",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonParameter(ApiVersionParameter.apiVersion,
  "ApiVersionParameter",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

@@resourceParameterBaseFor(ApiVersionParameter.apiVersion,
  [
    ResourceHome.ResourceGroup,
    ResourceHome.Subscription,
    ResourceHome.Location,
    ResourceHome.Tenant,
    ResourceHome.Extension,
    ResourceHome.BuiltIn,
    ResourceHome.BuiltInSubscription,
    ResourceHome.BuiltInResourceGroup
  ]
);

/** SubscriptionIdParameter */
@@armCommonParameter(SubscriptionIdParameter.subscriptionId,
  "SubscriptionIdParameter",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonParameter(SubscriptionIdParameter.subscriptionId,
  "SubscriptionIdParameter",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonParameter(SubscriptionIdParameter.subscriptionId,
  "SubscriptionIdParameter",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonParameter(SubscriptionIdParameter.subscriptionId,
  "SubscriptionIdParameter",
  Azure.ResourceManager.CommonTypes.Versions.v6
);
@@resourceParameterBaseFor(SubscriptionIdParameter.subscriptionId,
  [
    ResourceHome.ResourceGroup,
    ResourceHome.Subscription,
    ResourceHome.Location,
    ResourceHome.BuiltInSubscription,
    ResourceHome.BuiltInResourceGroup
  ]
);

/** ResourceGroupNameParameter */
@@armCommonParameter(ResourceGroupNameParameter.resourceGroupName,
  "ResourceGroupNameParameter",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonParameter(ResourceGroupNameParameter.resourceGroupName,
  "ResourceGroupNameParameter",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonParameter(ResourceGroupNameParameter.resourceGroupName,
  "ResourceGroupNameParameter",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonParameter(ResourceGroupNameParameter.resourceGroupName,
  "ResourceGroupNameParameter",
  Azure.ResourceManager.CommonTypes.Versions.v6
);
@@resourceParameterBaseFor(ResourceGroupNameParameter.resourceGroupName,
  [ResourceHome.ResourceGroup, ResourceHome.BuiltInResourceGroup]
);

/** ManagementGroupNameParameter */
@@armCommonParameter(ManagementGroupNameParameter.managementGroupName,
  "ManagementGroupNameParameter",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonParameter(ManagementGroupNameParameter.managementGroupName,
  "ManagementGroupNameParameter",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonParameter(ManagementGroupNameParameter.managementGroupName,
  "ManagementGroupNameParameter",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonParameter(ManagementGroupNameParameter.managementGroupName,
  "ManagementGroupNameParameter",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/** ScopeParameter */
@@armCommonParameter(ScopeParameter.scope,
  "ScopeParameter",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonParameter(ScopeParameter.scope,
  "ScopeParameter",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonParameter(ScopeParameter.scope,
  "ScopeParameter",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonParameter(ScopeParameter.scope,
  "ScopeParameter",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/** LocationResourceParameter */
@@armCommonParameter(LocationResourceParameter.location,
  "LocationParameter",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonParameter(LocationResourceParameter.location,
  "LocationParameter",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonParameter(LocationResourceParameter.location,
  "LocationParameter",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonParameter(LocationResourceParameter.location,
  "LocationParameter",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/**
 * The default operationId parameter type.
 */
@@armCommonParameter(OperationIdParameter.operationId,
  "OperationIdParameter",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonParameter(OperationIdParameter.operationId,
  "OperationIdParameter",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonParameter(OperationIdParameter.operationId,
  "OperationIdParameter",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonParameter(OperationIdParameter.operationId,
  "OperationIdParameter",
  Azure.ResourceManager.CommonTypes.Versions.v6
);

/**
 * TenantIdParameter
 */
@@armCommonParameter(TenantIdParameter.tenantId,
  "TenantIdParameter",
  Azure.ResourceManager.CommonTypes.Versions.v3
);
@@armCommonParameter(TenantIdParameter.tenantId,
  "TenantIdParameter",
  Azure.ResourceManager.CommonTypes.Versions.v4
);
@@armCommonParameter(TenantIdParameter.tenantId,
  "TenantIdParameter",
  Azure.ResourceManager.CommonTypes.Versions.v5
);
@@armCommonParameter(TenantIdParameter.tenantId,
  "TenantIdParameter",
  Azure.ResourceManager.CommonTypes.Versions.v6
);
