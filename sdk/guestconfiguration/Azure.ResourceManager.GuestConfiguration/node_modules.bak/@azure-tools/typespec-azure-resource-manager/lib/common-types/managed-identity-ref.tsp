import "./managed-identity.tsp";

using Azure.ResourceManager.CommonTypes.Private;

namespace Azure.ResourceManager.CommonTypes;

/**
 * The properties of the managed service identities assigned to this resource.
 */
@@armCommonDefinition(ManagedServiceIdentity,
  "ManagedServiceIdentity",
  #{ version: Azure.ResourceManager.CommonTypes.Versions.v3, isDefault: true },
  "managedidentity.json"
);
@@armCommonDefinition(ManagedServiceIdentity,
  "ManagedServiceIdentity",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "managedidentity.json"
);
@@armCommonDefinition(ManagedServiceIdentity,
  "ManagedServiceIdentity",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "managedidentity.json"
);
@@armCommonDefinition(ManagedServiceIdentity,
  "ManagedServiceIdentity",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "managedidentity.json"
);

/** The set of user assigned identities associated with the resource. The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}. The dictionary values can be empty objects ({}) in requests.", */
@@armCommonDefinition(UserAssignedIdentities,
  "UserAssignedIdentities",
  #{ version: Azure.ResourceManager.CommonTypes.Versions.v3, isDefault: true },
  "managedidentity.json"
);
@@armCommonDefinition(UserAssignedIdentities,
  "UserAssignedIdentities",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "managedidentity.json"
);
@@armCommonDefinition(UserAssignedIdentities,
  "UserAssignedIdentities",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "managedidentity.json"
);

/**
 * The properties of the service-assigned identity associated with this resource.
 */
@@armCommonDefinition(SystemAssignedServiceIdentity,
  "SystemAssignedServiceIdentity",
  #{ version: Azure.ResourceManager.CommonTypes.Versions.v3, isDefault: true },
  "managedidentity.json"
);
@@armCommonDefinition(SystemAssignedServiceIdentity,
  "SystemAssignedServiceIdentity",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "managedidentity.json"
);
@@armCommonDefinition(SystemAssignedServiceIdentity,
  "SystemAssignedServiceIdentity",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "managedidentity.json"
);
@@armCommonDefinition(SystemAssignedServiceIdentity,
  "SystemAssignedServiceIdentity",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "managedidentity.json"
);

/**
 * A managed identity assigned by the user.
 */
@@armCommonDefinition(UserAssignedIdentity,
  "UserAssignedIdentity",
  #{ version: Azure.ResourceManager.CommonTypes.Versions.v3, isDefault: true },
  "managedidentity.json"
);
@@armCommonDefinition(UserAssignedIdentity,
  "UserAssignedIdentity",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "managedidentity.json"
);
@@armCommonDefinition(UserAssignedIdentity,
  "UserAssignedIdentity",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "managedidentity.json"
);
@@armCommonDefinition(UserAssignedIdentity,
  "UserAssignedIdentity",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "managedidentity.json"
);

@@armCommonDefinition(ManagedServiceIdentityType,
  "ManagedServiceIdentityType",
  Azure.ResourceManager.CommonTypes.Versions.v3,
  "managedidentity.json"
);
@@armCommonDefinition(ManagedServiceIdentityType,
  "ManagedServiceIdentityType",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "managedidentity.json"
);
@@armCommonDefinition(ManagedServiceIdentityType,
  "ManagedServiceIdentityType",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "managedidentity.json"
);
@@armCommonDefinition(ManagedServiceIdentityType,
  "ManagedServiceIdentityType",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "managedidentity.json"
);

@@armCommonDefinition(SystemAssignedServiceIdentityType,
  "SystemAssignedServiceIdentityType",
  Azure.ResourceManager.CommonTypes.Versions.v3,
  "managedidentity.json"
);
@@armCommonDefinition(SystemAssignedServiceIdentityType,
  "SystemAssignedServiceIdentityType",
  Azure.ResourceManager.CommonTypes.Versions.v4,
  "managedidentity.json"
);
@@armCommonDefinition(SystemAssignedServiceIdentityType,
  "SystemAssignedServiceIdentityType",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "managedidentity.json"
);
@@armCommonDefinition(SystemAssignedServiceIdentityType,
  "SystemAssignedServiceIdentityType",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "managedidentity.json"
);
