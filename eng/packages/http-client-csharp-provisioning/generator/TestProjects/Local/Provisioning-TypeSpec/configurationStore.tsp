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
