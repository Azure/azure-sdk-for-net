import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.Core;

namespace ProvisioningTypeSpec;

/** A configuration store. */
@resource("configurationStores")
model ConfigurationStore is TrackedResource<ConfigurationStoreProperties> {
  ...ResourceNameParameter<
    ConfigurationStore,
    SegmentName = "configurationStores"
  >;
  ...EntityTagProperty;
}

/** The properties of a configuration store. */
model ConfigurationStoreProperties {
  /** The provisioning state of the configuration store. */
  @visibility(Lifecycle.Read)
  provisioningState?: ConfigurationStoreProvisioningState;

  /** The creation date of configuration store. */
  @visibility(Lifecycle.Read)
  creationDate?: utcDateTime;

  /** The DNS endpoint where the configuration store API will be available. */
  @visibility(Lifecycle.Read)
  endpoint?: string;

  /** The sku of the configuration store. */
  sku: ConfigurationStoreSku;

  /** Indicates whether the configuration store need to be recovered. */
  softDeleteRetentionInDays?: int32;

  /** Disables all authentication methods other than AAD authentication. */
  disableLocalAuth?: boolean;

  /** The backup policy for the configuration store. */
  backupPolicy?: BackupPolicy;

  /** Enables or disables public network access. */
  publicNetworkAccess?: PublicNetworkAccess;

  /** The SKU tier of the configuration store. */
  skuTier?: ConfigurationStoreSkuTier;

  /** The create mode for the configuration store. */
  createMode?: ConfigurationStoreCreateMode;

  /** The linked resources of the configuration store. */
  linkedResources?: LinkedResource[];

  /** The amount of time configuration data should be retained. */
  retentionPeriod?: duration;

  /** Byte-oriented content serialized as a base64 string. */
  binaryContent?: bytes;

  /** Byte-oriented content serialized as a base64url string. */
  @encode("base64url")
  urlSafeBinaryContent?: bytes;

  /** A date-time serialized using RFC 7231. */
  @encode("rfc7231")
  lastModified?: utcDateTime;

  /** Date-times serialized using RFC 3339. */
  auditTimestamps?: utcDateTime[];

  /** A date-time serialized as a Unix timestamp. */
  @encode("unixTimestamp", int64)
  expirationTimestamp?: utcDateTime;

  /** A calendar date without a time or timezone. */
  activationDate?: plainDate;

  /** A clock time without a date or timezone. */
  activationTime?: plainTime;

  /** A duration serialized as an integer number of seconds. */
  @encode("seconds", int64)
  retryAfter?: duration;

  /** A duration serialized as a floating-point number of milliseconds. */
  @encode("milliseconds", float64)
  pollingInterval?: duration;

  /** An integer serialized as a string. */
  @encode(string)
  encodedInteger?: int64;

  /** Arbitrary JSON content that should keep JSON literal semantics. */
  jsonMetadata?: unknown;
}

/** A linked resource reference. */
model LinkedResource {
}

/** The sku of a configuration store. */
model ConfigurationStoreSku {
  /** The name of the sku. */
  name: string;
}

/** Provisioning state of the configuration store. */
union ConfigurationStoreProvisioningState {
  string,

  /** The resource is being created. */
  Creating: "Creating",

  /** The resource has been created. */
  Succeeded: "Succeeded",

  /** The resource is being deleted. */
  Deleting: "Deleting",

  /** The resource creation or deletion has failed. */
  Failed: "Failed",

  /** The resource creation or deletion has been canceled. */
  Canceled: "Canceled",
}

/** Whether or not public endpoint access is allowed for the configuration store. */
union PublicNetworkAccess {
  string,

  /** Public network access is enabled. */
  Enabled: "Enabled",

  /** Public network access is disabled. */
  Disabled: "Disabled",
}

/** The SKU tier of the configuration store. */
// Wire values intentionally differ from their C# enum member names.
union ConfigurationStoreSkuTier {
  string,

  /** The free tier. */
  Free: "Free",

  /** Standard tier with S1 throughput. */
  StandardS1: "Standard_S1",

  /** Premium tier with P1 throughput. */
  PremiumP1: "Premium_P1",
}

/** The create mode for the configuration store. */
// Wire values intentionally differ from their C# enum member names.
union ConfigurationStoreCreateMode {
  string,

  /** Create a new configuration store. */
  Default: "default",

  /** Recover a soft-deleted configuration store. */
  Recover: "recover",
}

@armResourceOperations
interface ConfigurationStores {
  createOrUpdate is ArmResourceCreateOrUpdateAsync<ConfigurationStore>;

  get is ArmResourceRead<ConfigurationStore>;

  update is ArmResourcePatchAsync<
    ConfigurationStore,
    ConfigurationStoreProperties
  >;

  delete is ArmResourceDeleteWithoutOkAsync<ConfigurationStore>;

  list is ArmResourceListByParent<ConfigurationStore>;

  listBySubscription is ArmListBySubscription<ConfigurationStore>;
}
