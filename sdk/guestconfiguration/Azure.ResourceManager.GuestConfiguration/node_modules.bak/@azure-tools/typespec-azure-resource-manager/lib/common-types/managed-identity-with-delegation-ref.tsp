import "./managed-identity-with-delegation.tsp";
using Azure.ResourceManager.CommonTypes.Private;

namespace Azure.ResourceManager.CommonTypes;

/** Managed service identity (system assigned and/or user assigned identities and/or delegated identities) - internal use only. */
@@armCommonDefinition(ManagedServiceIdentityWithDelegation,
  "ManagedServiceIdentityWithDelegation",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "managedidentitywithdelegation.json"
);
@@armCommonDefinition(ManagedServiceIdentityWithDelegation,
  "ManagedServiceIdentityWithDelegation",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "managedidentitywithdelegation.json"
);
@@armCommonDefinition(ManagedServiceIdentityWithDelegation,
  "ManagedServiceIdentityWithDelegation",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "managedidentitywithdelegation.json"
);

/** Delegated resource properties - internal use only. */
@@armCommonDefinition(DelegatedResource,
  "DelegatedResource",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "managedidentitywithdelegation.json"
);
@@armCommonDefinition(DelegatedResource,
  "DelegatedResource",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "managedidentitywithdelegation.json"
);
@@armCommonDefinition(DelegatedResource,
  "DelegatedResource",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "managedidentitywithdelegation.json"
);
