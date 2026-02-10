using Azure.Core;
using Versioning;

namespace Azure.ResourceManager.CommonTypes;

/** Managed service identity (system assigned and/or user assigned identities and/or delegated identities) - internal use only. */
@added(Versions.v4)
model ManagedServiceIdentityWithDelegation extends ManagedServiceIdentity {
  delegatedResources?: DelegatedResources;
}

/** The set of delegated resources. The delegated resources dictionary keys will be source resource internal ids - internal use only. */
@added(Versions.v4)
model DelegatedResources {
  ...Record<DelegatedResource>;
}

/** Delegated resource properties - internal use only. */
@added(Versions.v4)
model DelegatedResource {
  /** The ARM resource id of the delegated resource - internal use only. */
  resourceId?: string;

  /** The tenant id of the delegated resource - internal use only. */
  tenantId?: uuid;

  /** The delegation id of the referral delegation (optional) - internal use only. */
  referralResource?: string;

  /** The source resource location - internal use only. */
  location?: string;
}
