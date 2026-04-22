import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ResourceManager.Legacy;
using Azure.Core;

namespace ProvisioningTypeSpec;

// ---- Shared input model across multiple resources (regression test for
// issue #56733 + ContainerInstance ContainerGroupProfile/Revision pattern) ----
//
// `Profile` is a proxy resource. A virtual `ProfileRevision` sub-resource
// is defined via `Azure.ResourceManager.Legacy.LegacyOperations` reusing
// the SAME `Profile` model (with `ResourceName = "ProfileRevision"`).
//
// Two ProvisioningResourceProvider instances are created off the same
// InputModelType — this exercises:
//   * `ProvisioningResourceProvider.BuildName` returning the resource
//     metadata name (so files/types are `Profile.cs` and
//     `ProfileRevision.cs` instead of two `Profile.cs` colliding).
//   * `ProvisioningTypeFactory.CreateModelCore` preferring the canonical
//     provider whose `ResourceMetadata.ResourceName == model.Name`,
//     so the flattened properties from `@@Legacy.flattenProperty(Profile.properties)`
//     land on the parent `Profile` resource and not on the child revision.

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

// Virtual sub-resource that REUSES the `Profile` input model under a
// `revisions/{revisionNumber}` segment, but is published as a distinct
// resource named `ProfileRevision`.
alias ProfileRevisionOps = Azure.ResourceManager.Legacy.LegacyOperations<
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
  getByRevisionNumber is ProfileRevisionOps.Read<Profile>;
}
