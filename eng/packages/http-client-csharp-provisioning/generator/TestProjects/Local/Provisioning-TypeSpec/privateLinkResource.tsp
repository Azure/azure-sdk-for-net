import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.Core;

namespace ProvisioningTypeSpec;

// Distinct read-only child resource used to verify that resources with no
// writable operations remain non-settable even when their parent is settable.

/** A private link resource for a configuration store. */
@parentResource(ConfigurationStore)
@resource("privateLinkResources")
model ConfigurationStorePrivateLinkResource is ProxyResource<PrivateLinkResourceProperties> {
  ...ResourceNameParameter<ConfigurationStorePrivateLinkResource, SegmentName = "privateLinkResources">;
}

/** Properties of a private link resource. */
model PrivateLinkResourceProperties {
  /** The private link resource group ID. */
  @visibility(Lifecycle.Read)
  groupId?: string;

  /** Required private link resource members. */
  @visibility(Lifecycle.Read)
  requiredMembers?: string[];

  /** Required private link DNS zone names. */
  @visibility(Lifecycle.Read)
  requiredZoneNames?: string[];
}

@armResourceOperations(#{ omitTags: true })
interface ConfigurationStorePrivateLinkResources {
  get is ArmResourceRead<ConfigurationStorePrivateLinkResource>;
  list is ArmResourceListByParent<ConfigurationStorePrivateLinkResource>;
}
