import "@azure-tools/typespec-azure-core";
import "../common-types/common-types.tsp";

using Azure.Core;
using Azure.ResourceManager.CommonTypes.Private;

namespace Azure.ResourceManager.Legacy;

/**
 * Model representing the standard `ManagedServiceIdentity` envelope property from V4 of common type.
 *
 * Please note that this is only included for legacy specs with mixed v3 and v4 types, which would cause
 * breaking changes due to the ManagedServiceIdentityType.SystemAndUserAssigned value changes.
 *
 * Do not use this if you are already on CommonTypes.Version.v4 or beyond.
 *
 * @example
 *
 * ```typespec
 * model Foo is TrackedResource<FooProperties> {
 *   ...ResourceNameParameter<Foo>;
 *   ...Legacy.ManagedServiceIdentityV4Property;
 * }
 * ```
 */
@doc("The managed service identities envelope.")
model ManagedServiceIdentityV4Property {
  @doc("The managed service identities assigned to this resource.")
  identity?: ManagedServiceIdentityV4;
}

/**
 * Managed service identity (system assigned and/or user assigned identities)
 */
#suppress "@azure-tools/typespec-azure-resource-manager/arm-common-types-incompatible-version" "intended only for v3/v4 mix backcompat cases"
@armCommonDefinition(
  "ManagedServiceIdentity",
  #{ version: Azure.ResourceManager.CommonTypes.Versions.v4, isDefault: true },
  "managedidentity.json"
)
model ManagedServiceIdentityV4 {
  /** The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity. */
  @visibility(Lifecycle.Read)
  principalId?: uuid;

  /** The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity. */
  @visibility(Lifecycle.Read)
  tenantId?: uuid;

  /** The type of managed identity assigned to this resource. */
  type: ManagedServiceIdentityType;

  /** The identities assigned to this resource by the user. */
  userAssignedIdentities?: Record<Azure.ResourceManager.CommonTypes.UserAssignedIdentity>;
}

/**
 * Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).
 */
union ManagedServiceIdentityType {
  /** No managed identity. */
  None: "None",

  /** System assigned managed identity. */
  SystemAssigned: "SystemAssigned",

  /** User assigned managed identity. */
  UserAssigned: "UserAssigned",

  /** System and user assigned managed identity. */
  SystemAndUserAssigned: "SystemAssigned, UserAssigned",

  string,
}
