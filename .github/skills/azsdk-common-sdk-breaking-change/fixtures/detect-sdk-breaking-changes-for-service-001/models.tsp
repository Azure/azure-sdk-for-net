import "@typespec/rest";
import "@typespec/http";
import "@typespec/versioning";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using Azure.ResourceManager;
using TypeSpec.Versioning;

namespace Microsoft.SignalRService;

/**
 * Optional tier of this particular SKU. 'Standard' or 'Free'.
 *
 * `Basic` is deprecated, use `Standard` instead.
 */
union WebPubSubSkuTier {
  string,

  /** Free tier for WebPubSub service */
  Free: "Free",

  /** Basic tier for WebPubSub service (deprecated, use Standard instead) */
  Basic: "Basic",

  /** Standard tier for WebPubSub service */
  Standard: "Standard",

  /** Premium tier for WebPubSub service */
  Premium: "Premium",
}

/**
 * Provisioning state of the resource.
 */
union ProvisioningState {
  string,

  /** Unknown provisioning state */
  Unknown: "Unknown",

  /** Resource successfully provisioned */
  Succeeded: "Succeeded",

  /** Resource provisioning failed */
  Failed: "Failed",

  /** Resource provisioning was canceled */
  Canceled: "Canceled",

  /** Resource provisioning is running */
  Running: "Running",

  /** Resource is being created */
  Creating: "Creating",

  /** Resource is being updated */
  Updating: "Updating",

  /** Resource is being deleted */
  Deleting: "Deleting",

  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Moving: "Moving",
}

/**
 * Indicates whether the connection has been Approved/Rejected/Removed by the owner of the service.
 */
union PrivateLinkServiceConnectionStatus {
  string,
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Pending: "Pending",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Approved: "Approved",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Rejected: "Rejected",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Disconnected: "Disconnected",
}

/**
 * The type of identity that created the resource.
 */
union CreatedByType {
  string,

  /** The entity was created by a user. */
  User: "User",

  /** The entity was created by an application. */
  Application: "Application",

  /** The entity was created by a managed identity. */
  ManagedIdentity: "ManagedIdentity",

  /** The entity was created by a key. */
  Key: "Key",
}

/**
 * Status of the shared private link resource
 */
union SharedPrivateLinkResourceStatus {
  string,
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Pending: "Pending",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Approved: "Approved",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Rejected: "Rejected",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Disconnected: "Disconnected",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Timeout: "Timeout",
}

/**
 * Azure Networking ACL Action.
 */
union ACLAction {
  string,
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Allow: "Allow",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Deny: "Deny",
}

/**
 * The incoming request type to the service
 */
union WebPubSubRequestType {
  string,
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  ClientConnection: "ClientConnection",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  ServerConnection: "ServerConnection",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  RESTAPI: "RESTAPI",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Trace: "Trace",
}

#suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
union ClientConnectionCountRuleDiscriminator {
  string,
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  ThrottleByJwtSignatureRule: "ThrottleByJwtSignatureRule",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  ThrottleByUserIdRule: "ThrottleByUserIdRule",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  ThrottleByJwtCustomClaimRule: "ThrottleByJwtCustomClaimRule",
}

#suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
union ClientTrafficControlRuleDiscriminator {
  string,
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  TrafficThrottleByJwtSignatureRule: "TrafficThrottleByJwtSignatureRule",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  TrafficThrottleByUserIdRule: "TrafficThrottleByUserIdRule",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  TrafficThrottleByJwtCustomClaimRule: "TrafficThrottleByJwtCustomClaimRule",
}

/**
 * The kind of the service
 */
union ServiceKind {
  string,
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  WebPubSub: "WebPubSub",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  SocketIO: "SocketIO",
}

/**
 * Represents the identity type: systemAssigned, userAssigned, None
 */
union ManagedIdentityType {
  string,
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  None: "None",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  SystemAssigned: "SystemAssigned",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  UserAssigned: "UserAssigned",
}

/**
 * Upstream auth type enum.
 */
union UpstreamAuthType {
  string,
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  None: "None",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  ManagedIdentity: "ManagedIdentity",
}

#suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
union EventListenerFilterDiscriminator {
  string,
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  EventName: "EventName",
}

#suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
union EventListenerEndpointDiscriminator {
  string,
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  EventHub: "EventHub",
}

/**
 * The type of access key.
 */
union KeyType {
  string,
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Primary: "Primary",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Secondary: "Secondary",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Salt: "Salt",
}

/**
 * The scale type applicable to the sku.
 */
union ScaleType {
  string,
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  None: "None",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Manual: "Manual",
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  Automatic: "Automatic",
}

/**
 * REST API operation supported by resource provider.
 */
model Operation {
  /**
   * Name of the operation with format: {provider}/{resource}/{operation}
   */
  name?: string;

  /**
   * If the operation is a data action. (for data plane rbac)
   */
  isDataAction?: boolean;

  /**
   * The object that describes a operation.
   */
  display?: OperationDisplay;

  /**
   * Optional. The intended executor of the operation; governs the display of the operation in the RBAC UX and the audit logs UX.
   */
  origin?: string;

  /**
   * Extra Operation properties.
   */
  properties?: OperationProperties;
}

/**
 * The object that describes a operation.
 */
model OperationDisplay {
  /**
   * Friendly name of the resource provider
   */
  provider?: string;

  /**
   * Resource type on which the operation is performed.
   */
  resource?: string;

  /**
   * The localized friendly name for the operation.
   */
  operation?: string;

  /**
   * The localized friendly description for the operation
   */
  description?: string;
}

/**
 * Extra Operation properties.
 */
model OperationProperties {
  /**
   * An object that describes a specification.
   */
  serviceSpecification?: ServiceSpecification;
}

model OperationList is Azure.Core.Page<Operation>;
/**
 * An object that describes a specification.
 */
model ServiceSpecification {
  /**
   * Specifications of the Metrics for Azure Monitoring.
   */
  @identifiers(#["name", "unit"])
  metricSpecifications?: MetricSpecification[];

  /**
   * Specifications of the Logs for Azure Monitoring.
   */
  @identifiers(#["name"])
  logSpecifications?: LogSpecification[];
}

/**
 * Specifications of the Metrics for Azure Monitoring.
 */
model MetricSpecification {
  /**
   * Name of the metric.
   */
  name?: string;

  /**
   * Localized friendly display name of the metric.
   */
  displayName?: string;

  /**
   * Localized friendly description of the metric.
   */
  displayDescription?: string;

  /**
   * The unit that makes sense for the metric.
   */
  unit?: string;

  /**
   * Only provide one value for this field. Valid values: Average, Minimum, Maximum, Total, Count.
   */
  aggregationType?: string;

  /**
   * Optional. If set to true, then zero will be returned for time duration where no metric is emitted/published.
   * Ex. a metric that returns the number of times a particular error code was emitted. The error code may not appear
   * often, instead of the RP publishing 0, Shoebox can auto fill in 0s for time periods where nothing was emitted.
   */
  fillGapWithZero?: string;

  /**
   * The name of the metric category that the metric belongs to. A metric can only belong to a single category.
   */
  category?: string;

  /**
   * The dimensions of the metrics.
   */
  @identifiers(#["name"])
  dimensions?: Dimension[];
}

/**
 * Specifications of the Dimension of metrics.
 */
model Dimension {
  /**
   * The public facing name of the dimension.
   */
  name?: string;

  /**
   * Localized friendly display name of the dimension.
   */
  displayName?: string;

  /**
   * Name of the dimension as it appears in MDM.
   */
  internalName?: string;

  /**
   * A Boolean flag indicating whether this dimension should be included for the shoebox export scenario.
   */
  toBeExportedForShoebox?: boolean;
}

/**
 * Specifications of the Logs for Azure Monitoring.
 */
model LogSpecification {
  /**
   * Name of the log.
   */
  name?: string;

  /**
   * Localized friendly display name of the log.
   */
  displayName?: string;
}

/**
 * Data POST-ed to the nameAvailability action
 */
model NameAvailabilityParameters {
  /**
   * The resource type. Can be "Microsoft.SignalRService/SignalR", "Microsoft.SignalRService/WebPubSub", "Microsoft.SignalRService/SignalR/replicas" or "Microsoft.SignalRService/WebPubSub/replicas"
   */
  type: string;

  /**
   * The resource name to validate. e.g."my-resource-name"
   */
  name: string;
}

/**
 * Result of the request to check name availability. It contains a flag and possible reason of failure.
 */
model NameAvailability {
  /**
   * Indicates whether the name is available or not.
   */
  nameAvailable?: boolean;

  /**
   * The reason of the availability. Required if name is not available.
   */
  reason?: string;

  /**
   * The message of the operation.
   */
  message?: string;
}

/**
 * Object that includes an array of the resource usages and a possible link for next set.
 */
#suppress "@azure-tools/typespec-azure-core/casing-style" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
model SignalRServiceUsageList is Azure.Core.Page<SignalRServiceUsage>;

/**
 * Object that describes a specific usage of the resources.
 */
#suppress "@azure-tools/typespec-azure-core/casing-style" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
model SignalRServiceUsage {
  /**
   * Fully qualified ARM resource id
   */
  id?: string;

  /**
   * Current value for the usage quota.
   */
  currentValue?: int64;

  /**
   * The maximum permitted value for the usage quota. If there is no limit, this value will be -1.
   */
  limit?: int64;

  /**
   * Localizable String object containing the name and a localized value.
   */
  name?: SignalRServiceUsageName;

  /**
   * Representing the units of the usage quota. Possible values are: Count, Bytes, Seconds, Percent, CountPerSecond, BytesPerSecond.
   */
  unit?: string;
}

/**
 * Localizable String object containing the name and a localized value.
 */
#suppress "@azure-tools/typespec-azure-core/casing-style" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
model SignalRServiceUsageName {
  /**
   * The identifier of the usage.
   */
  value?: string;

  /**
   * Localized name of the usage.
   */
  localizedValue?: string;
}

/**
 * Object that includes an array of resources and a possible link for next set.
 */
model WebPubSubResourceList is Azure.Core.Page<WebPubSubResource>;

/**
 * The billing information of the resource.
 */
model ResourceSku {
  /**
   * The name of the SKU. Required.
   *
   * Allowed values: Standard_S1, Free_F1, Premium_P1, Premium_P2
   */
  name: string;

  /**
   * Optional tier of this particular SKU. 'Standard' or 'Free'.
   *
   * `Basic` is deprecated, use `Standard` instead.
   */
  @renamedFrom(Versions.v2025_08_01_preview, "tier")
  tierNew?: WebPubSubSkuTier;

  /**
   * Not used. Retained for future use.
   */
  @visibility(Lifecycle.Read)
  size?: string;

  /**
   * Not used. Retained for future use.
   */
  @visibility(Lifecycle.Read)
  family?: string;

  /**
   * Optional, integer. The unit count of the resource.
   * 1 for Free_F1/Standard_S1/Premium_P1, 100 for Premium_P2 by default.
   *
   * If present, following values are allowed:
   *     Free_F1: 1;
   *     Standard_S1: 1,2,3,4,5,6,7,8,9,10,20,30,40,50,60,70,80,90,100;
   *     Premium_P1:  1,2,3,4,5,6,7,8,9,10,20,30,40,50,60,70,80,90,100;
   *     Premium_P2:  100,200,300,400,500,600,700,800,900,1000;
   */
  capacity?: int32;
}

/**
 * A class that describes the properties of the resource
 */
model WebPubSubProperties {
  /**
   * Provisioning state of the resource.
   */
  @visibility(Lifecycle.Read)
  provisioningState?: ProvisioningState;

  /**
   * The publicly accessible IP of the resource.
   */
  #suppress "@azure-tools/typespec-azure-core/casing-style" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  @visibility(Lifecycle.Read)
  externalIP?: string;

  /**
   * FQDN of the service instance.
   */
  @visibility(Lifecycle.Read)
  hostName?: string;

  /**
   * The publicly accessible port of the resource which is designed for browser/client side usage.
   */
  @visibility(Lifecycle.Read)
  publicPort?: int32;

  /**
   * The publicly accessible port of the resource which is designed for customer server side usage.
   */
  @visibility(Lifecycle.Read)
  serverPort?: int32;

  /**
   * Version of the resource. Probably you need the same or higher version of client SDKs.
   */
  @visibility(Lifecycle.Read)
  version?: string;

  /**
   * Private endpoint connections to the resource.
   */
  @visibility(Lifecycle.Read)
  @identifiers(#[])
  privateEndpointConnections?: PrivateEndpointConnection[];

  /**
   * The list of shared private link resources.
   */
  @visibility(Lifecycle.Read)
  @identifiers(#[])
  sharedPrivateLinkResources?: SharedPrivateLinkResource[];

  /**
   * TLS settings for the resource
   */
  tls?: WebPubSubTlsSettings;

  /**
   * Deprecated.
   */
  @visibility(Lifecycle.Read)
  hostNamePrefix?: string;

  /**
   * Live trace configuration of a Microsoft.SignalRService resource.
   */
  liveTraceConfiguration?: LiveTraceConfiguration;

  /**
   * Resource log configuration of a Microsoft.SignalRService resource.
   */
  resourceLogConfiguration?: ResourceLogConfiguration;

  /**
   * Network ACLs for the resource
   */
  #suppress "@azure-tools/typespec-azure-core/casing-style" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  networkACLs?: WebPubSubNetworkACLs;

  /**
   * Application firewall settings for the resource
   */
  applicationFirewall?: ApplicationFirewallSettings;

  /**
   * Enable or disable public network access. Default to "Enabled".
   * When it's Enabled, network ACLs still apply.
   * When it's Disabled, public network access is always disabled no matter what you set in network ACLs.
   */
  #suppress "@azure-tools/typespec-azure-resource-manager/secret-prop" "TODO: Check if this is a secret and add @secret or update reason"
  publicNetworkAccess?: string = "Enabled";

  /**
   * DisableLocalAuth
   * Enable or disable local auth with AccessKey
   * When set as true, connection with AccessKey=xxx won't work.
   */
  disableLocalAuth?: boolean = false;

  /**
   * DisableLocalAuth
   * Enable or disable aad auth
   * When set as true, connection with AuthType=aad won't work.
   */
  disableAadAuth?: boolean = false;

  /**
   * Enable or disable the regional endpoint. Default to "Enabled".
   * When it's Disabled, new connections will not be routed to this endpoint, however existing connections will not be affected.
   * This property is replica specific. Disable the regional endpoint without replica is not allowed.
   */
  regionEndpointEnabled?: string = "Enabled";

  /**
   * Stop or start the resource.  Default to "False".
   * When it's true, the data plane of the resource is shutdown.
   * When it's false, the data plane of the resource is started.
   */
  resourceStopped?: string = "false";

  /**
   * SocketIO settings for the resource
   */
  #suppress "@azure-tools/typespec-azure-core/casing-style" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  socketIO?: WebPubSubSocketIOSettings;
}

/**
 * Private endpoint connection properties
 */
model PrivateEndpointConnectionProperties {
  /**
   * Provisioning state of the resource.
   */
  @visibility(Lifecycle.Read)
  provisioningState?: ProvisioningState;

  /**
   * Private endpoint
   */
  privateEndpoint?: PrivateEndpoint;

  /**
   * Group IDs
   */
  @visibility(Lifecycle.Read)
  groupIds?: string[];

  /**
   * Connection state of the private endpoint connection
   */
  privateLinkServiceConnectionState?: PrivateLinkServiceConnectionState;
}

/**
 * Private endpoint
 */
model PrivateEndpoint {
  /**
   * Full qualified Id of the private endpoint
   */
  id?: string;
}

/**
 * Connection state of the private endpoint connection
 */
model PrivateLinkServiceConnectionState {
  /**
   * Indicates whether the connection has been Approved/Rejected/Removed by the owner of the service.
   */
  status?: PrivateLinkServiceConnectionStatus;

  /**
   * The reason for approval/rejection of the connection.
   */
  description?: string;

  /**
   * A message indicating if changes on the service provider require any updates on the consumer.
   */
  actionsRequired?: string;
}

/**
 * Describes the properties of an existing Shared Private Link Resource
 */
model SharedPrivateLinkResourceProperties {
  /**
   * The group id from the provider of resource the shared private link resource is for
   */
  groupId: string;

  /**
   * The resource id of the resource the shared private link resource is for
   */
  privateLinkResourceId: string;

  /**
   * Provisioning state of the resource.
   */
  @visibility(Lifecycle.Read)
  provisioningState?: ProvisioningState;

  /**
   * The request message for requesting approval of the shared private link resource
   */
  requestMessage?: string;

  /**
   * A list of FQDNs for third party private link service
   */
  fqdns?: string[];

  /**
   * Status of the shared private link resource
   */
  @visibility(Lifecycle.Read)
  status?: SharedPrivateLinkResourceStatus;
}

/**
 * TLS settings for the resource
 */
model WebPubSubTlsSettings {
  /**
   * Request client certificate during TLS handshake if enabled. Not supported for free tier. Any input will be ignored for free tier.
   */
  clientCertEnabled?: boolean = false;
}

/**
 * Live trace configuration of a Microsoft.SignalRService resource.
 */
model LiveTraceConfiguration {
  /**
   * Indicates whether or not enable live trace.
   * When it's set to true, live trace client can connect to the service.
   * Otherwise, live trace client can't connect to the service, so that you are unable to receive any log, no matter what you configure in "categories".
   * Available values: true, false.
   * Case insensitive.
   */
  enabled?: string = "false";

  /**
   * Gets or sets the list of category configurations.
   */
  @identifiers(#["name"])
  categories?: LiveTraceCategory[];
}

/**
 * Live trace category configuration of a Microsoft.SignalRService resource.
 */
model LiveTraceCategory {
  /**
   * Gets or sets the live trace category's name.
   * Available values: ConnectivityLogs, MessagingLogs.
   * Case insensitive.
   */
  name?: string;

  /**
   * Indicates whether or the live trace category is enabled.
   * Available values: true, false.
   * Case insensitive.
   */
  enabled?: string;
}

/**
 * Resource log configuration of a Microsoft.SignalRService resource.
 */
model ResourceLogConfiguration {
  /**
   * Gets or sets the list of category configurations.
   */
  @identifiers(#["name"])
  categories?: ResourceLogCategory[];
}

/**
 * Resource log category configuration of a Microsoft.SignalRService resource.
 */
model ResourceLogCategory {
  /**
   * Gets or sets the resource log category's name.
   * Available values: ConnectivityLogs, MessagingLogs.
   * Case insensitive.
   */
  name?: string;

  /**
   * Indicates whether or the resource log category is enabled.
   * Available values: true, false.
   * Case insensitive.
   */
  enabled?: string;
}

/**
 * Network ACLs for the resource
 */
#suppress "@azure-tools/typespec-azure-core/casing-style" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
model WebPubSubNetworkACLs {
  /**
   * Azure Networking ACL Action.
   */
  defaultAction?: ACLAction;

  /**
   * Network ACL
   */
  publicNetwork?: NetworkACL;

  /**
   * ACLs for requests from private endpoints
   */
  @identifiers(#["name"])
  privateEndpoints?: PrivateEndpointACL[];

  /**
   * IP rules for filtering public traffic
   */
  @maxItems(30)
  @identifiers(#[])
  ipRules?: IPRule[];
}

/**
 * Network ACL
 */
#suppress "@azure-tools/typespec-azure-core/casing-style" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
model NetworkACL {
  /**
   * Allowed request types. The value can be one or more of: ClientConnection, ServerConnection, RESTAPI.
   */
  allow?: WebPubSubRequestType[];

  /**
   * Denied request types. The value can be one or more of: ClientConnection, ServerConnection, RESTAPI.
   */
  deny?: WebPubSubRequestType[];
}

/**
 * ACL for a private endpoint
 */
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
#suppress "@azure-tools/typespec-azure-core/casing-style" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
model PrivateEndpointACL extends NetworkACL {
  /**
   * Name of the private endpoint connection
   */
  name: string;
}

/**
 * An IP rule
 */
model IPRule {
  /**
   * An IP or CIDR or ServiceTag
   */
  value?: string;

  /**
   * Azure Networking ACL Action.
   */
  action?: ACLAction;
}

/**
 * Application firewall settings for the resource
 */
model ApplicationFirewallSettings {
  /**
   * Rules to control the client connection count
   */
  @maxItems(10)
  @identifiers(#[])
  clientConnectionCountRules?: ClientConnectionCountRule[];

  /**
   * Rules to control the client traffic
   */
  @maxItems(10)
  @identifiers(#[])
  clientTrafficControlRules?: ClientTrafficControlRule[];

  /**
   * Config to control the client connection lifetime in seconds, can be set to 0 to disable the config
   */
  @minValue(0)
  @maxValue(604800)
  maxClientConnectionLifetimeInSeconds?: int64;
}

/**
 * A base class for client connection count rules
 */
@discriminator("type")
model ClientConnectionCountRule {
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  type: ClientConnectionCountRuleDiscriminator;
}

/**
 * A base class for client traffic control rules
 */
@discriminator("type")
model ClientTrafficControlRule {
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  type: ClientTrafficControlRuleDiscriminator;
}

/**
 * SocketIO settings for the resource
 */
#suppress "@azure-tools/typespec-azure-core/casing-style" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
model WebPubSubSocketIOSettings {
  /**
   * The service mode of Web PubSub for Socket.IO. Values allowed:
   * "Default": have your own backend Socket.IO server
   * "Serverless": your application doesn't have a backend server
   */
  serviceMode?: string;
}

/**
 * A class represent managed identities used for request and response
 */
model ManagedIdentity {
  /**
   * Represents the identity type: systemAssigned, userAssigned, None
   */
  type?: ManagedIdentityType;

  /**
   * Get or set the user assigned identities
   */
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-no-record" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  userAssignedIdentities?: Record<UserAssignedIdentityProperty>;

  /**
   * Get the principal id for the system assigned identity.
   * Only be used in response.
   */
  @visibility(Lifecycle.Read)
  principalId?: string;

  /**
   * Get the tenant id for the system assigned identity.
   * Only be used in response
   */
  @visibility(Lifecycle.Read)
  tenantId?: string;
}

/**
 * Properties of user assigned identity.
 */
model UserAssignedIdentityProperty {
  /**
   * Get the principal id for the user assigned identity
   */
  @visibility(Lifecycle.Read)
  principalId?: string;

  /**
   * Get the client id for the user assigned identity
   */
  @visibility(Lifecycle.Read)
  clientId?: string;
}

/**
 * Custom certificates list.
 */
model CustomCertificateList is Azure.Core.Page<CustomCertificate>;

/**
 * Custom certificate properties.
 */
model CustomCertificateProperties {
  /**
   * Provisioning state of the resource.
   */
  @visibility(Lifecycle.Read)
  provisioningState?: ProvisioningState;

  /**
   * Base uri of the KeyVault that stores certificate.
   */
  @visibility(Lifecycle.Read, Lifecycle.Create)
  keyVaultBaseUri: string;

  /**
   * Certificate secret name.
   */
  @visibility(Lifecycle.Read, Lifecycle.Create)
  keyVaultSecretName: string;

  /**
   * Certificate secret version.
   */
  @visibility(Lifecycle.Read, Lifecycle.Create)
  keyVaultSecretVersion?: string;
}

/**
 * Custom domains list
 */
model CustomDomainList is Azure.Core.Page<CustomDomain>;

/**
 * Properties of a custom domain.
 */
model CustomDomainProperties {
  /**
   * Provisioning state of the resource.
   */
  @visibility(Lifecycle.Read)
  provisioningState?: ProvisioningState;

  /**
   * The custom domain name.
   */
  domainName: string;

  /**
   * Reference to a resource.
   */
  customCertificate: ResourceReference;
}

/**
 * Reference to a resource.
 */
model ResourceReference {
  /**
   * Resource ID.
   */
  id?: string;
}

/**
 * Hub setting list
 */
model WebPubSubHubList is Azure.Core.Page<WebPubSubHub>;

/**
 * Properties of a hub.
 */
#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-provisioning-state" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
model WebPubSubHubProperties {
  /**
   * Event handler of a hub.
   */
  @identifiers(#[])
  eventHandlers?: EventHandler[];

  /**
   * Event listener settings for forwarding your client events to listeners.
   * Event listener is transparent to Web PubSub clients, and it doesn't return any result to clients nor interrupt the lifetime of clients.
   * One event can be sent to multiple listeners, as long as it matches the filters in those listeners. The order of the array elements doesn't matter.
   * Maximum count of event listeners among all hubs is 10.
   */
  @identifiers(#[])
  eventListeners?: EventListener[];

  /**
   * The settings for configuring if anonymous connections are allowed for this hub: "allow" or "deny". Default to "deny".
   */
  anonymousConnectPolicy?: string = "deny";

  /**
   * The settings for configuring the WebSocket ping-pong interval in seconds for all clients in the hub. Valid range: 1 to 120. Default to 20 seconds.
   */
  @maxValue(120)
  @minValue(1)
  webSocketKeepAliveIntervalInSeconds?: int32 = 20;

  /**
   * The chat settings for the hub.
   */
  @added(Versions.v2025_12_01_preview)
  chat?: ChatSettings;
}

/**
 * Properties of event handler.
 */
model EventHandler {
  @doc("""
    Gets or sets the URL template for the event handler. The actual URL is calculated when the corresponding event is triggered.
    The template supports predefined parameters syntax: `{event}`, `{hub}`, and KeyVault reference syntax `{@Microsoft.KeyVault(SecretUri=_your_secret_identifier_)}`
    For example, if the template is `http://example.com/api/{event}`, when `connect` event is triggered, a POST request will be sent to the URL `http://example.com/chat/api/connect`.
    Note: Parameters are not allowed in the hostname of the URL, and curly brackets `{}` are reserved for parameter syntax only. If your URL path contains literal curly brackets, please URL-encode them to ensure proper handling.
    """)
  urlTemplate: string;

  /**
   * Gets or sets the matching pattern for event names.
   * There are 3 kinds of patterns supported:
   *     1. "*", it matches any event name
   *     2. Combine multiple events with ",", for example "event1,event2", it matches event "event1" and "event2"
   *     3. A single event name, for example, "event1", it matches "event1"
   */
  userEventPattern?: string;

  /**
   * Gets or sets the list of system events.
   */
  systemEvents?: string[];

  /**
   * Upstream auth settings. If not set, no auth is used for upstream messages.
   */
  auth?: UpstreamAuthSettings;

  /**
   * The group presence events that this event handler is concerned with. Group presence events are triggered when connections join or leave groups in the hub. If the value is null, no presence events will be sent to this event handler.
   */
  @added(Versions.v2025_08_01_preview)
  groupPresenceEvents?: GroupPresenceEventFilters;
}

/**
 * Represents presence event filters for event handler configuration.
 */
@added(Versions.v2025_08_01_preview)
model GroupPresenceEventFilters {
  /**
   * The concerning event names. Valid values are "joined", "left". If the value is null or empty, no presence events will be sent to the event handler.
   */
  eventNames: GroupPresenceEventName[];

  /**
   * The group filters. Only events from these groups will be sent to the event handler. Each element is a pattern that may match multiple groups. If null or empty, events from all groups will be sent (subject to eventNames).
   */
  groupFilters?: string[];
}

/** Allowed event names for group presence events. */
@added(Versions.v2025_08_01_preview)
union GroupPresenceEventName {
  /** Event triggered when a connection joins a group. */
  Joined: "joined",

  /** Event triggered when a connection leaves a group. */
  Left: "left",

  string,
}

/**
 * Upstream auth settings. If not set, no auth is used for upstream messages.
 */
model UpstreamAuthSettings {
  /**
   * Upstream auth type enum.
   */
  type?: UpstreamAuthType;

  /**
   * Managed identity settings for upstream.
   */
  managedIdentity?: ManagedIdentitySettings;
}

/**
 * Managed identity settings for upstream.
 */
model ManagedIdentitySettings {
  /**
   * The Resource indicating the App ID URI of the target resource.
   * It also appears in the aud (audience) claim of the issued token.
   */
  resource?: string;
}

/**
 * A setting defines which kinds of events should be sent to which endpoint.
 */
model EventListener {
  /**
   * A base class for event filter which determines whether an event should be sent to an event listener.
   */
  filter: EventListenerFilter;

  /**
   * An endpoint specifying where Web PubSub should send events to.
   */
  endpoint: EventListenerEndpoint;
}

/**
 * A base class for event filter which determines whether an event should be sent to an event listener.
 */
@discriminator("type")
model EventListenerFilter {
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  type: EventListenerFilterDiscriminator;
}

/**
 * An endpoint specifying where Web PubSub should send events to.
 */
@discriminator("type")
model EventListenerEndpoint {
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  type: EventListenerEndpointDiscriminator;
}

/**
 * Chat settings.
 */
model ChatSettings {
  /**
   * Enable or disable the chat feature.
   */
  mode?: string;

  /**
   * Reference to the the persistent storage for perisisting chat states.
   */
  persistentStorage?: ResourceReference;
}

/**
 * A class represents the access keys of the resource.
 */
model WebPubSubKeys {
  /**
   * The primary access key.
   */
  @secret
  primaryKey?: string;

  /**
   * The secondary access key.
   */
  @secret
  secondaryKey?: string;

  /**
   * Connection string constructed via the primaryKey
   */
  @secret
  primaryConnectionString?: string;

  /**
   * Connection string constructed via the secondaryKey
   */
  @secret
  secondaryConnectionString?: string;
}

/**
 * A list of private endpoint connections
 */
model PrivateEndpointConnectionList
  is Azure.Core.Page<PrivateEndpointConnection>;

/**
 * Contains a list of PrivateLinkResource and a possible link to query more results
 */
model PrivateLinkResourceList is Azure.Core.Page<PrivateLinkResource>;

/**
 * Private link resource
 */
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
model PrivateLinkResource
  extends Azure.ResourceManager.CommonTypes.ProxyResource {
  /**
   * Private link resource properties
   */
  properties?: PrivateLinkResourceProperties;
}

/**
 * Private link resource properties
 */
model PrivateLinkResourceProperties {
  /**
   * Group Id of the private link resource
   */
  groupId?: string;

  /**
   * Required members of the private link resource
   */
  requiredMembers?: string[];

  /**
   * Required private DNS zone names
   */
  requiredZoneNames?: string[];

  /**
   * The list of resources that are onboarded to private link service
   */
  @identifiers(#[])
  shareablePrivateLinkResourceTypes?: ShareablePrivateLinkResourceType[];
}

/**
 * Describes a  resource type that has been onboarded to private link service
 */
model ShareablePrivateLinkResourceType {
  /**
   * The name of the resource type that has been onboarded to private link service
   */
  name?: string;

  /**
   * Describes the properties of a resource type that has been onboarded to private link service
   */
  properties?: ShareablePrivateLinkResourceProperties;
}

/**
 * Describes the properties of a resource type that has been onboarded to private link service
 */
model ShareablePrivateLinkResourceProperties {
  /**
   * The description of the resource type that has been onboarded to private link service
   */
  description?: string;

  /**
   * The resource provider group id for the resource that has been onboarded to private link service
   */
  groupId?: string;

  /**
   * The resource provider type for the resource that has been onboarded to private link service
   */
  type?: string;
}

/**
 * Parameters describes the request to regenerate access keys
 */
model RegenerateKeyParameters {
  /**
   * The type of access key.
   */
  keyType?: KeyType;
}

#suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
model ReplicaList is Azure.Core.Page<Replica>;

#suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
model ReplicaProperties {
  /**
   * Provisioning state of the resource.
   */
  @visibility(Lifecycle.Read)
  provisioningState?: ProvisioningState;

  /**
   * Enable or disable the regional endpoint. Default to "Enabled".
   * When it's Disabled, new connections will not be routed to this endpoint, however existing connections will not be affected.
   */
  regionEndpointEnabled?: string = "Enabled";

  /**
   * Stop or start the resource.  Default to "false".
   * When it's true, the data plane of the resource is shutdown.
   * When it's false, the data plane of the resource is started.
   */
  resourceStopped?: string = "false";
}

/**
 * A list of shared private link resources
 */
model SharedPrivateLinkResourceList
  is Azure.Core.Page<SharedPrivateLinkResource>;

/**
 * The list skus operation response
 */
model SkuList {
  /**
   * The list of skus available for the resource.
   */
  @visibility(Lifecycle.Read)
  @Azure.ResourceManager.identifiers(#[
    "resourceType",
    "/sku/name",
    "/sku/tier"
  ])
  value?: Sku[];

  /**
   * The URL the client should use to fetch the next page (per server side paging).
   * It's null for now, added for future use.
   */
  @visibility(Lifecycle.Read)
  nextLink?: string;
}

/**
 * Describes an available sku."
 */
model Sku {
  /**
   * The resource type that this object applies to
   */
  @visibility(Lifecycle.Read)
  resourceType?: string;

  /**
   * The billing information of the resource.
   */
  #suppress "@azure-tools/typespec-client-generator-core/property-name-conflict" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  @visibility(Lifecycle.Read)
  sku?: ResourceSku;

  /**
   * Describes scaling information of a sku.
   */
  @visibility(Lifecycle.Read)
  capacity?: SkuCapacity;
}

/**
 * Describes scaling information of a sku.
 */
model SkuCapacity {
  /**
   * The lowest permitted capacity for this resource
   */
  @visibility(Lifecycle.Read)
  minimum?: int32;

  /**
   * The highest permitted capacity for this resource
   */
  @visibility(Lifecycle.Read)
  maximum?: int32;

  /**
   * The default capacity.
   */
  @visibility(Lifecycle.Read)
  default?: int32;

  /**
   * Allows capacity value list.
   */
  @visibility(Lifecycle.Read)
  allowedValues?: int32[];

  /**
   * The scale type applicable to the sku.
   */
  @visibility(Lifecycle.Read)
  scaleType?: ScaleType;
}

/**
 * An Event Hub endpoint.
 * The managed identity of Web PubSub service must be enabled, and the identity should have the "Azure Event Hubs Data sender" role to access Event Hub.
 */
model EventHubEndpoint extends EventListenerEndpoint {
  /**
   * The fully qualified namespace name of the Event Hub resource.
   */
  fullyQualifiedNamespace: string;

  /**
   * The name of the Event Hub.
   */
  eventHubName: string;

  type: "EventHub";
}

/**
 * Filter events by their name.
 */
model EventNameFilter extends EventListenerFilter {
  /**
   * Gets or sets a list of system events. Supported events: "connected" and "disconnected". Blocking event "connect" is not supported because it requires a response.
   */
  systemEvents?: string[];

  /**
   * Gets or sets a matching pattern for event names.
   * There are 3 kinds of patterns supported:
   *     1. "*", it matches any event name
   *     2. Combine multiple events with ",", for example "event1,event2", it matches events "event1" and "event2"
   *     3. A single event name, for example, "event1", it matches "event1"
   */
  userEventPattern?: string;

  type: "EventName";
}

/**
 * Throttle the client connection by a custom JWT claim
 */
model ThrottleByJwtCustomClaimRule extends ClientConnectionCountRule {
  /**
   * The name of the claim in the JWT token. The client connection with the same claim value will be aggregated. If the claim is not found in the token, the connection will be allowed.
   */
  claimName: string;

  /**
   * Maximum connection count allowed for the same Jwt claim value. Clients with the same Jwt claim will get rejected if the connection count exceeds this value. Default value is 20.
   */
  @minValue(0)
  @maxValue(2147483647)
  maxCount?: int32 = 20;

  type: "ThrottleByJwtCustomClaimRule";
}

/**
 * Throttle the client connection by the JWT signature
 */
model ThrottleByJwtSignatureRule extends ClientConnectionCountRule {
  /**
   * Maximum connection count allowed for the same JWT signature. Clients with the same JWT signature will get rejected if the connection count exceeds this value. Default value is 20.
   */
  @minValue(0)
  @maxValue(2147483647)
  maxCount?: int32 = 20;

  type: "ThrottleByJwtSignatureRule";
}

/**
 * Throttle the client connection by the user ID
 */
model ThrottleByUserIdRule extends ClientConnectionCountRule {
  /**
   * Maximum connection count allowed for the same user ID. Clients with the same user ID will get rejected if the connection count exceeds this value. Default value is 20.
   */
  @minValue(0)
  @maxValue(2147483647)
  maxCount?: int32 = 20;

  type: "ThrottleByUserIdRule";
}

/**
 * Throttle the client traffic by a custom JWT claim
 */
model TrafficThrottleByJwtCustomClaimRule extends ClientTrafficControlRule {
  /**
   * The name of the claim in the JWT token. The message bytes with the same claim value will be aggregated. If the claim is not found in the token, the rule will be skipped.
   */
  claimName: string;

  /**
   * Maximum accumulated inbound message bytes allowed for the same JWT signature within a time window. Clients with the same JWT claim will get disconnected if the message bytes exceeds this value. Default value is 1GB.
   */
  @minValue(0)
  maxInboundMessageBytes?: int64;

  /**
   * The aggregation window for the message bytes. The message bytes will be aggregated in this window and be reset after the window. Default value is 60 seconds.
   */
  @maxValue(3600)
  @minValue(10)
  aggregationWindowInSeconds?: int32 = 60;

  type: "TrafficThrottleByJwtCustomClaimRule";
}

/**
 * Throttle the client traffic by the JWT signature
 */
model TrafficThrottleByJwtSignatureRule extends ClientTrafficControlRule {
  /**
   * Maximum accumulated inbound message bytes allowed for the same JWT signature within a time window. Clients with the same JWT signature will get disconnected if the message bytes exceeds this value. Default value is 1GB.
   */
  @minValue(0)
  maxInboundMessageBytes?: int64;

  /**
   * The aggregation window for the message bytes. The message bytes will be aggregated in this window and be reset after the window. Default value is 60 seconds.
   */
  @maxValue(3600)
  @minValue(10)
  aggregationWindowInSeconds?: int32 = 60;

  type: "TrafficThrottleByJwtSignatureRule";
}

/**
 * Throttle the client traffic by the user ID
 */
model TrafficThrottleByUserIdRule extends ClientTrafficControlRule {
  /**
   * Maximum accumulated inbound message bytes allowed for the same user ID within a time window. Clients with the same user ID will get disconnected if the message bytes exceeds this value. Default value is 1GB.
   */
  @minValue(0)
  maxInboundMessageBytes?: int64;

  /**
   * The aggregation window for the message bytes. The message bytes will be aggregated in this window and be reset after the window. Default value is 60 seconds.
   */
  @maxValue(3600)
  @minValue(10)
  aggregationWindowInSeconds?: int32 = 60;

  type: "TrafficThrottleByUserIdRule";
}
@@identifiers(OperationList.value, #["name"]);
