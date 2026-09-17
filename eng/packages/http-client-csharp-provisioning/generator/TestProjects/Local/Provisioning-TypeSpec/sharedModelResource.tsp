import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ResourceManager.Legacy;
using Azure.Core;

namespace ProvisioningTypeSpec;

// A parent and virtual child resource share the same input model.

/** A profile resource. */
@parentResource(ConfigurationStore)
@resource("profiles")
model Profile is Azure.ResourceManager.ProxyResource<ProfileProperties> {
  ...ResourceNameParameter<Profile, SegmentName = "profiles">;
}

/** Properties of a profile. */
model ProfileProperties {
  /** A scalar property that should land on the parent Profile resource
   * after flattening, and stay on `ProfileProperties` itself for the
   * standalone model. */
  description?: string;

  /** A SKU sub-property. */
  sku?: ProfileSku;
}

/** SKU of a profile. */
model ProfileSku {
  /** The SKU name. */
  name: string;
}

@armResourceOperations
interface Profiles {
  get is ArmResourceRead<Profile>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<Profile>;
  delete is ArmResourceDeleteWithoutOkAsync<Profile>;
  list is ArmResourceListByParent<Profile>;
}

// Publish the shared model as a distinct virtual child resource.
alias ProfileRevisionReadOps = Azure.ResourceManager.Legacy.LegacyOperations<
  {
    ...ApiVersionParameter;
    ...SubscriptionIdParameter;
    ...ResourceGroupParameter;
    ...Azure.ResourceManager.Legacy.Provider;

    /** The configuration store name. */
    @path
    @segment("configurationStores")
    @key
    configurationStoreName: string;

    /** The profile name. */
    @path
    @segment("profiles")
    @key
    profileName: string;
  },
  {
    /** The revision number. */
    @path
    @segment("revisions")
    @key
    revisionNumber: string;
  },
  ErrorResponse,
  ResourceName = "ProfileRevision"
>;

@armResourceOperations(#{ omitTags: true })
interface ProfileRevisions {
  /** Get a specific revision of a profile. */
  getByRevisionNumber is ProfileRevisionReadOps.Read<Profile>;
}
