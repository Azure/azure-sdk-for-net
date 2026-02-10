using Http;
using Rest;
using Versioning;
using Azure.Core;

namespace Azure.ResourceManager.CommonTypes;

/** Common fields that are returned in the response for all Azure Resource Manager resources */
@summary("Resource")
model Resource {
  /** Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName} */
  @typeChangedFrom(Versions.v4, string)
  @visibility(Lifecycle.Read)
  id?: armResourceIdentifier;

  /** The name of the resource */
  @visibility(Lifecycle.Read)
  name?: string;

  /** The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts" */
  @visibility(Lifecycle.Read)
  type?: armResourceType;

  /** Azure Resource Manager metadata containing createdBy and modifiedBy information. */
  @visibility(Lifecycle.Read)
  systemData?: SystemData;
}

/** The resource model definition for an Azure Resource Manager resource with an etag. */
@summary("Entity Resource")
model AzureEntityResource extends Resource {
  /** Resource Etag. */
  @visibility(Lifecycle.Read)
  etag?: string;
}

/**
 * The resource model definition for an Azure Resource Manager tracked top level resource which has 'tags' and a 'location'
 */
@summary("Tracked Resource")
model TrackedResource extends Resource {
  /** Resource tags. */
  tags?: Record<string>;

  /** The geo-location where the resource lives */
  @visibility(Lifecycle.Read, Lifecycle.Create)
  @Azure.ResourceManager.CommonTypes.Private.inlineAzureType
  location: Azure.Core.azureLocation;
}

/**
 * The resource model definition for a Azure Resource Manager proxy resource. It will not have tags and a location
 */
@summary("Proxy Resource")
model ProxyResource extends Resource {}

/**
 * The base extension resource.
 */
// Note that ProxyResource is the base definition for both kinds of resources
model ExtensionResource extends Resource {}

/**
 * The resource model definition containing the full set of allowed properties for a resource. Except properties bag, there cannot be a top level property outside of this set.
 */
model ResourceModelWithAllowedPropertySet extends TrackedResource {
  /** The fully qualified resource ID of the resource that manages this resource. Indicates if this resource is managed by another Azure resource.
   * If this is present, complete mode deployment will not delete the resource if it is removed from the template since it is managed by another resource. */
  managedBy?: string;

  /** Metadata used by portal/tooling/etc to render different UX experiences for resources of the same type; e.g. ApiApps are a kind of Microsoft.Web/sites type.
   * If supported, the resource provider must validate and persist this value. */
  @pattern("^[-\\w\\._,\\(\\)]+$")
  @visibility(Lifecycle.Read, Lifecycle.Create)
  kind?: string;

  /** The etag field is *not* required. If it is provided in the response body, it must also be provided as a header per the normal etag convention.
   * Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19),
   * If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields. */
  @visibility(Lifecycle.Read)
  etag?: string;

  @typeChangedFrom(Versions.v6, Identity)
  identity?: ManagedServiceIdentity;

  sku?: Sku;
  plan?: Plan;
}

/**
 * The resource model definition representing SKU
 */
model Sku {
  /** The name of the SKU. Ex - P3. It is typically a letter+number code */
  name: string;

  /** This field is required to be implemented by the Resource Provider if the service has more than one tier, but is not required on a PUT. */
  tier?: SkuTier;

  /** The SKU size. When the name field is the combination of tier and some other value, this would be the standalone code. */
  size?: string;

  /** If the service has different generations of hardware, for the same SKU, then that can be captured here. */
  family?: string;

  /** If the SKU supports scale out/in then the capacity integer should be included. If scale out/in is not possible for the resource this may be omitted. */
  capacity?: int32;
}

/**
 * This field is required to be implemented by the Resource Provider if the service has more than one tier, but is not required on a PUT.
 */
union SkuTier {
  /** The Free service tier. */
  Free: "Free",

  /** The Basic service tier. */
  Basic: "Basic",

  /** The Standard service tier. */
  Standard: "Standard",

  /** The Premium service tier. */
  Premium: "Premium",
}

/**
 * A list of REST API operations supported by an Azure Resource Provider. It contains an URL link to get the next set of results.
 */
@friendlyName("OperationListResult")
model OperationListResult is Azure.Core.Page<Operation>;

/**
 * Details of a REST API operation, returned from the Resource Provider Operations API
 */
@summary("REST API Operation")
model Operation {
  /** 
    The name of the operation, as per Resource-Based Access Control (RBAC). Examples: "Microsoft.Compute/virtualMachines/write", "Microsoft.Compute/virtualMachines/capture/action"
     */
  @visibility(Lifecycle.Read)
  name?: string;

  /** 
    Whether the operation applies to data-plane. This is "true" for data-plane operations and "false" for Azure Resource Manager/control-plane operations.
     */
  @visibility(Lifecycle.Read)
  isDataAction?: boolean;

  /** Localized display information for this particular operation. */
  display?: OperationDisplay;

  /** 
    The intended executor of the operation; as in Resource Based Access Control (RBAC) and audit logs UX. Default value is "user,system"
     */
  @visibility(Lifecycle.Read)
  origin?: Origin;

  /** 
    Extensible enum. Indicates the action type. "Internal" refers to actions that are for internal only APIs.
     */
  @visibility(Lifecycle.Read)
  actionType?: ActionType;
}

/**
 * Localized display information for an operation.
 */
model OperationDisplay {
  /** 
  The localized friendly form of the resource provider name, e.g. "Microsoft Monitoring Insights" or "Microsoft Compute".
   */
  @visibility(Lifecycle.Read)
  provider?: string;

  /** 
    The localized friendly name of the resource type related to this operation. E.g. "Virtual Machines" or "Job Schedule Collections".
     */
  @visibility(Lifecycle.Read)
  resource?: string;

  /** 
    The concise, localized friendly name for the operation; suitable for dropdowns. E.g. "Create or Update Virtual Machine", "Restart Virtual Machine".
     */
  @visibility(Lifecycle.Read)
  operation?: string;

  /** The short, localized friendly description of the operation; suitable for tool tips and detailed views. */
  @visibility(Lifecycle.Read)
  description?: string;
}

/**
 * The current status of an async operation.
 */
model OperationStatusResult {
  /** Fully qualified ID for the async operation. */
  @typeChangedFrom(Versions.v5, string)
  id?: armResourceIdentifier;

  /** Name of the async operation. */
  name?: string;

  /** Operation status. */
  status: string;

  /** Percent of the operation that is complete. */
  @minValue(0)
  @maxValue(100)
  percentComplete?: float64;

  /** The start time of the operation. */
  startTime?: utcDateTime;

  /** The end time of the operation. */
  endTime?: utcDateTime;

  /** The operations list. */
  operations?: OperationStatusResult[];

  /** If present, details of the operation error. */
  error?: ErrorDetail;

  /** Fully qualified ID of the resource against which the original async operation was started. */
  @visibility(Lifecycle.Read)
  @added(Versions.v5)
  resourceId?: armResourceIdentifier;
}

/**
 * Extensible enum. Indicates the action type. "Internal" refers to actions that are for internal only APIs.
 */
union ActionType {
  /** Actions are for internal-only APIs. */
  Internal: "Internal",

  string,
}

/**
 * The intended executor of the operation; as in Resource Based Access Control (RBAC) and audit logs UX. Default value is "user,system"
 */
union Origin {
  /** Indicates the operation is initiated by a user. */
  user: "user",

  /** Indicates the operation is initiated by a system. */
  system: "system",

  /** Indicates the operation is initiated by a user or system. */
  `user,system`: "user,system",

  string,
}

/**
 * The error detail.
 */
model ErrorDetail {
  /** The error code. */
  @visibility(Lifecycle.Read)
  code?: string;

  /** The error message. */
  @visibility(Lifecycle.Read)
  message?: string;

  /** The error target. */
  @visibility(Lifecycle.Read)
  target?: string;

  /** The error details. */
  @visibility(Lifecycle.Read)
  details?: ErrorDetail[];

  /** The error additional info. */
  @visibility(Lifecycle.Read)
  additionalInfo?: ErrorAdditionalInfo[];
}

/**
 * Common error response for all Azure Resource Manager APIs to return error details for failed operations.
 */
@summary("Error response")
@error
model ErrorResponse {
  /** The error object. */
  error?: ErrorDetail;
}

/**
 * The resource management error additional info.
 */
model ErrorAdditionalInfo {
  /** The additional info type. */
  @visibility(Lifecycle.Read)
  type?: string;

  /** The additional info. */
  @visibility(Lifecycle.Read)
  info?: unknown;
}

/**
 * Metadata pertaining to creation and last modification of the resource.
 */
model SystemData {
  /** The identity that created the resource. */
  createdBy?: string;

  /** The type of identity that created the resource. */
  createdByType?: createdByType;

  /** The timestamp of resource creation (UTC). */
  createdAt?: utcDateTime;

  /** The identity that last modified the resource. */
  lastModifiedBy?: string;

  /** The type of identity that last modified the resource. */
  lastModifiedByType?: createdByType;

  /** The timestamp of resource last modification (UTC) */
  lastModifiedAt?: utcDateTime;
}

/**
 * The kind of entity that created the resource.
 */
// NOTE: This is how the extensible enum is named in types.json
union createdByType {
  /** The entity was created by a user. */
  User: "User",

  /** The entity was created by an application. */
  Application: "Application",

  /** The entity was created by a managed identity. */
  ManagedIdentity: "ManagedIdentity",

  /** The entity was created by a key. */
  Key: "Key",

  string,
}

/** @dev Resource Identity Type */
@doc("")
union ResourceIdentityType {
  SystemAssigned: "SystemAssigned",
}

/** Identity for the resource. */
@removed(Versions.v6)
model Identity {
  /** The principal ID of resource identity. The value must be an UUID. */
  @removed(Versions.v6)
  @typeChangedFrom(Versions.v4, string)
  @visibility(Lifecycle.Read)
  principalId?: uuid;

  /** The tenant ID of resource. The value must be an UUID. */
  @removed(Versions.v6)
  @typeChangedFrom(Versions.v4, string)
  @visibility(Lifecycle.Read)
  tenantId?: uuid;

  /** The identity type. */
  type?: ResourceIdentityType;
}

/** @dev Properties of a KeyVault */
model KeyVaultProperties {
  /** Key vault uri to access the encryption key. */
  keyIdentifier?: string;

  /** The client ID of the identity which will be used to access key vault. */
  identity?: string;
}
/**
 * Plan for the resource.
 */
model Plan {
  /** A user defined name of the 3rd Party Artifact that is being procured. */
  name: string;

  /** The publisher of the 3rd Party Artifact that is being bought. E.g. NewRelic */
  publisher: string;

  /** The 3rd Party artifact that is being procured. E.g. NewRelic. Product maps to the OfferID specified for the artifact at the time of Data Market onboarding. */
  product: string;

  /** A publisher provided promotion code as provisioned in Data Market for the said product/artifact. */
  promotionCode?: string;

  /** The version of the desired product/artifact. */
  version?: string;
}

/**
 * The check availability request body.
 */
model CheckNameAvailabilityRequest {
  /** The name of the resource for which availability needs to be checked. */
  name?: string;

  /** The resource type. */
  type?: string;
}

/**
 * The check availability result.
 */
model CheckNameAvailabilityResponse {
  /** Indicates if the resource name is available. */
  nameAvailable?: boolean;

  /** The reason why the given name is not available. */
  reason?: CheckNameAvailabilityReason;

  /** Detailed reason why the given name is not available. */
  message?: string;
}

/**
 * Possible reasons for a name not being available.
 */
union CheckNameAvailabilityReason {
  /** Name is invalid. */
  Invalid: "Invalid",

  /** Name already exists. */
  AlreadyExists: "AlreadyExists",

  string,
}

/** Indicates whether or not the encryption is enabled for container registry. */
union EncryptionStatus {
  /** Encryption is enabled. */
  enabled: "enabled",

  /** Encryption is disabled. */
  disabled: "disabled",

  string,
}
/**
 * Configuration of key for data encryption
 */
model EncryptionProperties {
  /** Indicates whether or not the encryption is enabled for container registry. */
  status?: EncryptionStatus;

  /** Key vault properties. */
  keyVaultProperties?: KeyVaultProperties;
}

/**
 * Metadata pertaining to the geographic location of the resource.
 */
model LocationData {
  /** A canonical name for the geographic or physical location. */
  @maxLength(256)
  name: string;

  /** The city or locality where the resource is located. */
  city?: string;

  /** The district, state, or province where the resource is located. */
  district?: string;

  /** The country or region where the resource is located */
  countryOrRegion?: string;
}

/**
 * The default api-version parameter type.
 *
 * @example
 * ```typespec
 * model Employee is TrackedResource<EmployeeProperties> {
 *  ...ResourceNameParameter<Employee>;
 * }
 * ```
 */
model ApiVersionParameter {
  /** The API version to use for this operation. */
  @query("api-version")
  @minLength(1)
  apiVersion: string;
}

/**
 * The default operationId parameter type.
 */
model OperationIdParameter {
  /** The ID of an ongoing async operation. */
  @path
  @minLength(1)
  operationId: string;
}

/**
 * The default location parameter type.
 *
 * @example
 * ```typespec
 * op employee is ArmProviderActionSync<
 *  Request = Employee,
 *  Response = Employee,
 *  Scope = SubscriptionActionScope,
 *  Parameters = LocationParameter
 * >;
 * ```
 */
model LocationParameter {
  /** The name of Azure region. */
  @path
  @minLength(1)
  @segment("locations")
  @Azure.ResourceManager.CommonTypes.Private.inlineAzureType
  location: string;
}

/**
 * The default resource group parameter type.
 */
model ResourceGroupNameParameter {
  /** The name of the resource group. The name is case insensitive. */
  @path
  @minLength(1)
  @maxLength(90)
  @segment("resourceGroups")
  @pattern("^[-\\w\\._\\(\\)]+$")
  resourceGroupName: string;
}

/**
 * The default subscriptionId parameter type.
 */
model SubscriptionIdParameter {
  /** The ID of the target subscription. The value must be an UUID. */
  @typeChangedFrom(Versions.v4, string)
  @path
  @segment("subscriptions")
  @minLength(1)
  subscriptionId: uuid;
}

/**
 * The default ManagementGroupName parameter type.
 */
@added(Versions.v4)
model ManagementGroupNameParameter {
  /** The name of the management group. The name is case insensitive. */
  @path
  @minLength(1)
  @maxLength(90)
  @segment("managementGroups")
  managementGroupName: string;
}

/**
 * The default Scope parameter type.
 */
@added(Versions.v4)
model ScopeParameter {
  /** The scope at which the operation is performed. */
  @path(#{ allowReserved: true })
  @segment("scope")
  @minLength(1)
  scope: string;
}

/**
 * The default TenantIdParameter type.
 */
@added(Versions.v4)
model TenantIdParameter {
  /** The Azure tenant ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000) */
  @path
  @segment("tenant")
  tenantId: uuid;
}

/**
 * The default ARM If-Match header type.
 */
@added(Versions.v4)
@friendlyName("If-Match")
model IfMatchHeader {
  /** The If-Match header that makes a request conditional. */
  @header("If-Match")
  ifMatch: string;
}

/**
 * The default ARM If-None-Match header type.
 */
@added(Versions.v4)
@friendlyName("If-None-Match")
model IfNoneMatchHeader {
  /** The If-None-Match header that makes a request conditional. */
  @header("If-None-Match")
  ifNoneMatch: string;
}
