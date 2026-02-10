using Azure.Core;
using Versioning;

namespace Azure.ResourceManager.CommonTypes;

/** (Optional) Discouraged to include in resource definition. Only needed where it is possible to disable platform (AKA infrastructure) encryption. Azure SQL TDE is an example of this. Values are enabled and disabled. */
@added(Versions.v4)
union InfrastructureEncryption {
  /** Encryption is enabled */
  Enabled: "enabled",

  /** Encryption is disabled */
  Disabled: "disabled",

  string,
}

/** The type of identity to use. */
@added(Versions.v4)
union KeyEncryptionKeyIdentityType {
  /** System assigned identity */
  SystemAssignedIdentity: "systemAssignedIdentity",

  /** User assigned identity */
  UserAssignedIdentity: "userAssignedIdentity",

  /** Delegated identity */
  DelegatedResourceIdentity: "delegatedResourceIdentity",

  string,
}

/** All identity configuration for Customer-managed key settings defining which identity should be used to auth to Key Vault. */
@added(Versions.v4)
model KeyEncryptionKeyIdentity {
  /** The type of identity to use. Values can be systemAssignedIdentity, userAssignedIdentity, or delegatedResourceIdentity. */
  identityType?: KeyEncryptionKeyIdentityType;

  /** User assigned identity to use for accessing key encryption key Url. Ex: /subscriptions/fa5fc227-a624-475e-b696-cdd604c735bc/resourceGroups/<resource group>/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myId. Mutually exclusive with identityType systemAssignedIdentity. */
  userAssignedIdentityResourceId?: Azure.Core.armResourceIdentifier;

  /** application client identity to use for accessing key encryption key Url in a different tenant. Ex: f83c6b1b-4d34-47e4-bb34-9d83df58b540 */
  @added(Versions.v5)
  federatedClientId?: uuid;

  /** delegated identity to use for accessing key encryption key Url. Ex: /subscriptions/fa5fc227-a624-475e-b696-cdd604c735bc/resourceGroups/<resource group>/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myId. Mutually exclusive with identityType systemAssignedIdentity and userAssignedIdentity - internal use only. */
  delegatedIdentityClientId?: uuid;
}

/** Customer-managed key encryption properties for the resource. */
@added(Versions.v4)
model CustomerManagedKeyEncryption {
  /** All identity configuration for Customer-managed key settings defining which identity should be used to auth to Key Vault. */
  keyEncryptionKeyIdentity?: KeyEncryptionKeyIdentity;

  /** key encryption key Url, versioned or non-versioned. Ex: https://contosovault.vault.azure.net/keys/contosokek/562a4bb76b524a1493a6afe8e536ee78 or https://contosovault.vault.azure.net/keys/contosokek. */
  keyEncryptionKeyUrl?: string;
}

/** (Optional) Discouraged to include in resource definition. Only needed where it is possible to disable platform (AKA infrastructure) encryption. Azure SQL TDE is an example of this. Values are enabled and disabled. */
@added(Versions.v4)
@encodedName("application/json", "encryption")
model Encryption {
  /** Values are enabled and disabled. */
  infrastructureEncryption?: InfrastructureEncryption;

  /** All Customer-managed key encryption properties for the resource. */
  @added(Versions.v4)
  customerManagedKeyEncryption?: CustomerManagedKeyEncryption;
}
