import "@typespec/http";
import "@typespec/rest";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec {

  @armResourceOperations
  interface Clusters {
    get is ArmResourceRead<Cluster>;
    createOrUpdate is ArmResourceCreateOrReplaceAsync<Cluster>;
    update is ArmResourcePatchAsync<Cluster, ClusterUpdate>;
    delete is ArmResourceDeleteAsync<Cluster>;
    listByResourceGroup is ArmResourceListByParent<Cluster>;
    listBySubscription is ArmListBySubscription<Cluster>;
  }

  model Cluster is TrackedResource<ClusterCreateProperties> {
    ...ResourceNameParameter<Cluster>;
  }

  /**
   * Create properties model that extends ClusterProperties - reproduces issue #55437.
   * When Cluster.properties is flattened, the inherited properties from ClusterProperties
   * (like encryption with its single-property ClusterPropertiesEncryption)
   * should be safe-flattened through the inheritance chain.
   */
  model ClusterCreateProperties extends ClusterProperties {
    /**
     * Whether or not public network traffic can access the Redis cluster.
     */
    publicNetworkAccess?: PublicNetworkAccess | null;
  }

  /**
   * Patch model that has properties flattened - this is the key pattern from
   * the original issue where the factory method was missing constructor parameters.
   */
  model ClusterUpdate {
    /**
     * The SKU to create, which affects price, performance, and features.
     */
    sku?: Sku;

    /**
     * Other properties of the cluster - this gets flattened via decorator.
     */
    properties?: ClusterUpdateProperties;

    /**
     * The identity of the resource.
     */
    identity?: ManagedServiceIdentityProperty;

    /**
     * Resource tags.
     */
    @visibility(Lifecycle.Read, Lifecycle.Create, Lifecycle.Update)
    tags?: Record<string>;
  }

  /**
   * Extended properties model - extends ClusterProperties which has nested
   * complex objects (encryption, maintenanceConfiguration). The original issue
   * was that the factory method for ClusterUpdate was calling
   * new ClusterUpdateProperties(...) with missing parameters for these nested objects.
   */
  model ClusterUpdateProperties extends ClusterProperties {
    /**
     * Whether or not public network traffic can access the Redis cluster.
     */
    publicNetworkAccess?: PublicNetworkAccess | null;
  }

  model ClusterProperties {
    /**
     * Enabled by default. If highAvailability is disabled, the data set is not replicated.
     */
    highAvailability?: HighAvailability;

    /**
     * The minimum TLS version for the cluster to support, e.g. '1.2'.
     */
    minimumTlsVersion?: TlsVersion;

    /**
     * Encryption-at-rest configuration for the cluster.
     * This nested object was missing in the factory constructor call.
     */
    encryption?: ClusterPropertiesEncryption;

    /**
     * Cluster-level maintenance configuration.
     * This nested object was missing in the factory constructor call.
     */
    @visibility(Lifecycle.Read, Lifecycle.Create, Lifecycle.Update)
    maintenanceConfiguration?: MaintenanceConfiguration;

    /**
     * DNS name of the cluster endpoint
     */
    @visibility(Lifecycle.Read)
    hostName?: string;

    /**
     * Current provisioning status of the cluster
     */
    @visibility(Lifecycle.Read)
    provisioningState?: ProvisioningState;

    /**
     * Explains the current redundancy strategy of the cluster.
     */
    @visibility(Lifecycle.Read)
    redundancyMode?: RedundancyMode;

    /**
     * Current resource status of the cluster
     */
    @visibility(Lifecycle.Read)
    resourceState?: ResourceState;

    /**
     * Version of redis the cluster supports, e.g. '6'
     */
    @visibility(Lifecycle.Read)
    redisVersion?: string;

    /**
     * List of private endpoint connections
     */
    @visibility(Lifecycle.Read)
    privateEndpointConnections?: RedisPrivateEndpointConnection[];
  }

  model Sku {
    name: SkuName;
    capacity?: int32;
  }

  model ClusterPropertiesEncryption {
    customerManagedKeyEncryption?: CustomerManagedKeyEncryption;
  }

  model CustomerManagedKeyEncryption {
    keyEncryptionKeyIdentity?: KeyEncryptionKeyIdentity;
    keyEncryptionKeyUrl?: string;
  }

  model KeyEncryptionKeyIdentity {
    userAssignedIdentityResourceId?: string;
    identityType?: CmkIdentityType;
  }

  model MaintenanceConfiguration {
    maintenanceWindows?: MaintenanceWindow[];
  }

  model MaintenanceWindow {
    dayOfWeek?: DayOfWeek;
    startHour?: int32;
    duration?: int32;
  }

  enum SkuName {
    Standard,
    Premium,
  }

  enum HighAvailability {
    Enabled,
    Disabled,
  }

  enum TlsVersion {
    "1.0",
    "1.1",
    "1.2",
  }

  enum PublicNetworkAccess {
    Enabled,
    Disabled,
  }

  enum ProvisioningState {
    Succeeded,
    Failed,
    Canceled,
    Creating,
    Updating,
    Deleting,
  }

  enum RedundancyMode {
    Disabled,
    GeoReplicated,
    ZoneReplicated,
  }

  enum ResourceState {
    Running,
    Creating,
    Updating,
    Deleting,
    Disabled,
  }

  enum CmkIdentityType {
    SystemAssignedIdentity,
    UserAssignedIdentity,
  }

  enum DayOfWeek {
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday,
  }

  model RedisPrivateEndpointConnection is ProxyResource<RedisPrivateEndpointConnectionProperties> {
    ...ResourceNameParameter<RedisPrivateEndpointConnection>;
  }

  model RedisPrivateEndpointConnectionProperties {
    privateEndpoint?: RedisPrivateEndpoint;
    privateLinkServiceConnectionState: RedisPrivateLinkServiceConnectionState;
    provisioningState?: ProvisioningState;
  }

  model RedisPrivateEndpoint {
    id?: string;
  }

  model RedisPrivateLinkServiceConnectionState {
    status?: RedisPrivateEndpointServiceConnectionStatus;
    description?: string;
    actionsRequired?: string;
  }

  enum RedisPrivateEndpointServiceConnectionStatus {
    Pending,
    Approved,
    Rejected,
  }

  // Apply property flattening to ClusterUpdate.properties - this triggers the bug
  #suppress "deprecated"
  @@Azure.ClientGenerator.Core.Legacy.flattenProperty(ClusterUpdate.properties);

  // Apply property flattening to Cluster.properties to reproduce issue #55437
  // Cluster uses ClusterCreateProperties (extends ClusterProperties) which has
  // nested single-property models (ClusterPropertiesEncryption with only CustomerManagedKeyEncryption)
  // that should be safe-flattened through the inheritance chain.
  #suppress "deprecated"
  @@Azure.ClientGenerator.Core.Legacy.flattenProperty(Cluster.properties);
}
