import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using Azure.Core;
using Azure.ResourceManager;
using TypeSpec.Rest;

namespace ProvisioningTypeSpec;

/** A profile whose properties include other resource models. */
@parentResource(ConfigurationStore)
@resource("resourceProfiles")
model ResourceProfile is Azure.ResourceManager.ProxyResource<ResourceProfileProperties> {
  ...ResourceNameParameter<ResourceProfile, SegmentName = "resourceProfiles">;
}

/** Properties of a resource profile. */
model ResourceProfileProperties {
  /** The latest revision resource returned with the profile. */
  @visibility(Lifecycle.Read)
  latestRevision?: ResourceProfileRevision;

  /** The specialized profile resource returned with the profile. */
  @visibility(Lifecycle.Read)
  specializedProfile?: SpecializedResourceProfile;
}

/** A discriminated profile resource. */
@discriminator("kind")
@parentResource(ConfigurationStore)
@resource("discriminatedResourceProfiles")
model DiscriminatedResourceProfile is Azure.ResourceManager.ProxyResource<DiscriminatedResourceProfileProperties> {
  ...ResourceNameParameter<
    DiscriminatedResourceProfile,
    SegmentName = "discriminatedResourceProfiles"
  >;

  /** The profile kind. */
  kind: string;
}

/** Properties of a discriminated profile resource. */
model DiscriminatedResourceProfileProperties {
  /** The profile description. */
  description?: string;
}

/** A specialized resource profile. */
model SpecializedResourceProfile extends DiscriminatedResourceProfile {
  /** The specialized profile kind. */
  kind: "Specialized";
}

/** A revision of a resource profile. */
@parentResource(ResourceProfile)
@resource("revisions")
model ResourceProfileRevision is Azure.ResourceManager.ProxyResource<ResourceProfileRevisionProperties> {
  ...ResourceNameParameter<
    ResourceProfileRevision,
    SegmentName = "revisions"
  >;
}

/** Properties of a resource profile revision. */
model ResourceProfileRevisionProperties {
  /** The revision description. */
  description?: string;
}

@armResourceOperations
interface ResourceProfiles {
  get is ArmResourceRead<ResourceProfile>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<ResourceProfile>;
}

@armResourceOperations
interface DiscriminatedResourceProfiles {
  get is ArmResourceRead<DiscriminatedResourceProfile>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<DiscriminatedResourceProfile>;
}

@armResourceOperations
interface ResourceProfileRevisions {
  get is ArmResourceRead<ResourceProfileRevision>;
}
