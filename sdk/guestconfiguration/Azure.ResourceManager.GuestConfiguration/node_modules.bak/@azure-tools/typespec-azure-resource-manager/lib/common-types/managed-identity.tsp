using Azure.Core;
using Versioning;

namespace Azure.ResourceManager.CommonTypes;

/** The set of user assigned identities associated with the resource. The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}. The dictionary values can be empty objects ({}) in requests. */
#deprecated "Do not use this model. Instead, use Record<UserAssignedIdentity | null> directly. Using this model will result in a different client SDK when generated from TypeSpec compared to the Swagger."
@summary("User-Assigned Identities")
@removed(Versions.v6)
model UserAssignedIdentities is Record<UserAssignedIdentity | null>;

/**
 * Managed service identity (system assigned and/or user assigned identities)
 */
model ManagedServiceIdentity {
  /** The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity. */
  @visibility(Lifecycle.Read)
  principalId?: uuid;

  /** The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity. */
  @visibility(Lifecycle.Read)
  tenantId?: uuid;

  /** The type of managed identity assigned to this resource. */
  type: ManagedServiceIdentityType;

  /** The identities assigned to this resource by the user. */
  @typeChangedFrom(Versions.v5, Record<UserAssignedIdentity>)
  userAssignedIdentities?: Record<UserAssignedIdentity | null>;
}

/**
 * Managed service identity (either system assigned, or none)
 */
model SystemAssignedServiceIdentity {
  /** The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity. */
  @visibility(Lifecycle.Read)
  principalId?: uuid;

  /** The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity. */
  @visibility(Lifecycle.Read)
  tenantId?: uuid;

  /** The type of managed identity assigned to this resource. */
  type: SystemAssignedServiceIdentityType;
}

/**
 * User assigned identity properties
 */
model UserAssignedIdentity {
  /** The principal ID of the assigned identity. */
  @visibility(Lifecycle.Read)
  principalId?: uuid;

  /** The client ID of the assigned identity. */
  @visibility(Lifecycle.Read)
  clientId?: uuid;
}

/**
 * Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).
 */
union ManagedServiceIdentityType {
  /** No managed identity. */
  "None",

  /** System assigned managed identity. */
  "SystemAssigned",

  /** User assigned managed identity. */
  "UserAssigned",

  /** System and user assigned managed identity. */
  @added(Versions.v3)
  @removed(Versions.v4)
  @added(Versions.v5)
  "SystemAssigned,UserAssigned",

  /** System and user assigned managed identity. */
  @added(Versions.v4)
  @removed(Versions.v5)
  "SystemAssigned, UserAssigned",

  string,
}

/**
 * Type of managed service identity (either system assigned, or none).
 */
union SystemAssignedServiceIdentityType {
  /** No managed system identity. */
  None: "None",

  /** System assigned managed system identity. */
  SystemAssigned: "SystemAssigned",

  string,
}
