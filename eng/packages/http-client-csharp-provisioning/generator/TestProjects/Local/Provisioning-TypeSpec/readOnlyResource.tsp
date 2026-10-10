import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;

namespace ProvisioningTypeSpec;

// Resources without writable operations remain read-only.

/** A private link resource for a configuration store. */
model ConfigurationStorePrivateLinkResource is PrivateLink;

alias ConfigurationStorePrivateLinkOperations = PrivateLinks<ConfigurationStorePrivateLinkResource>;

@armResourceOperations
interface ConfigurationStorePrivateLinkResources {
  get is ConfigurationStorePrivateLinkOperations.Read<ConfigurationStore>;
  list is ConfigurationStorePrivateLinkOperations.ListByParent<ConfigurationStore>;
}
