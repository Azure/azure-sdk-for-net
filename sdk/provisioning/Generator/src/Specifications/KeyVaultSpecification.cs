// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.KeyVault.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class KeyVaultSpecification() :
    Specification("KeyVault", typeof(KeyVaultExtensions))
{
    protected override void Customize()
    {
        // Patch models
        CustomizeModel<KeyVaultResource>(m => m.Name = "KeyVaultService");
        CustomizeEnum<ManagedHsmCreateMode>(e => { foreach (EnumValue member in e.Values) { member.Value = member.Name.ToLowerInvariant(); } });
        IncludeHiddenVersions<KeyVaultPrivateEndpointConnectionResource>("2023-08-01-PREVIEW");
        IncludeHiddenVersions<KeyVaultSecretResource>("2023-08-01-PREVIEW");
        IncludeHiddenVersions<KeyVaultResource>("2023-08-01-PREVIEW");
        IncludeHiddenVersions<ManagedHsmResource>("2023-08-01-PREVIEW");
        IncludeHiddenVersions<ManagedHsmPrivateEndpointConnectionResource>("2023-08-01-PREVIEW");

        // Naming requirements
        AddNameRequirements<KeyVaultResource>(min: 3, max: 24, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<KeyVaultSecretResource>(min: 1, max: 127, lower: true, upper: true, digits: true, hyphen: true);

        // Roles
        Roles.Add(new Role("KeyVaultAdministrator", "00482a5a-887f-4fb3-b363-3b7fe8e74483", "Perform all data plane operations on a key vault and all objects in it, including certificates, keys, and secrets. Cannot manage key vault resources or manage role assignments. Only works for key vaults that use the 'Azure role-based access control' permission model."));
        Roles.Add(new Role("KeyVaultCertificateUser", "db79e9a7-68ee-4b58-9aeb-b90e7c24fcba", "Read certificate contents. Only works for key vaults that use the 'Azure role-based access control' permission model."));
        Roles.Add(new Role("KeyVaultCertificatesOfficer", "a4417e6f-fecd-4de8-b567-7b0420556985", "Perform any action on the certificates of a key vault, except manage permissions. Only works for key vaults that use the 'Azure role-based access control' permission model."));
        Roles.Add(new Role("KeyVaultContributor", "f25e0fa2-a7c8-4377-a976-54943a77a395", "Manage key vaults, but does not allow you to assign roles in Azure RBAC, and does not allow you to access secrets, keys, or certificates."));
        Roles.Add(new Role("KeyVaultCryptoOfficer", "14b46e9e-c2b7-41b4-b07b-48a6ebf60603", "Perform any action on the keys of a key vault, except manage permissions. Only works for key vaults that use the 'Azure role-based access control' permission model."));
        Roles.Add(new Role("KeyVaultCryptoServiceEncryptionUser", "e147488a-f6f5-4113-8e2d-b22465e65bf6", "Read metadata of keys and perform wrap/unwrap operations. Only works for key vaults that use the 'Azure role-based access control' permission model."));
        Roles.Add(new Role("KeyVaultCryptoServiceReleaseUser", "08bbd89e-9f13-488c-ac41-acfcb10c90ab", "Release keys. Only works for key vaults that use the 'Azure role-based access control' permission model."));
        Roles.Add(new Role("KeyVaultCryptoUser", "12338af0-0e69-4776-bea7-57ae8d297424", "Perform cryptographic operations using keys. Only works for key vaults that use the 'Azure role-based access control' permission model."));
        Roles.Add(new Role("KeyVaultDataAccessAdministrator", "8b54135c-b56d-4d72-a534-26097cfdc8d8", "Manage access to Azure Key Vault by adding or removing role assignments for the Key Vault Administrator, Key Vault Certificates Officer, Key Vault Crypto Officer, Key Vault Crypto Service Encryption User, Key Vault Crypto User, Key Vault Reader, Key Vault Secrets Officer, or Key Vault Secrets User roles. Includes an ABAC condition to constrain role assignments."));
        Roles.Add(new Role("KeyVaultReader", "21090545-7ca7-4776-b22c-e363652d74d2", "Read metadata of key vaults and its certificates, keys, and secrets. Cannot read sensitive values such as secret contents or key material. Only works for key vaults that use the 'Azure role-based access control' permission model."));
        Roles.Add(new Role("KeyVaultSecretsOfficer", "b86a8fe4-44ce-4948-aee5-eccb2c155cd7", "Perform any action on the secrets of a key vault, except manage permissions. Only works for key vaults that use the 'Azure role-based access control' permission model."));
        Roles.Add(new Role("KeyVaultSecretsUser", "4633458b-17de-408a-b874-0445c86b69e6", "Read secret contents. Only works for key vaults that use the 'Azure role-based access control' permission model."));
        Roles.Add(new Role("ManagedHsmContributor", "18500a29-7fe2-46b2-a342-b16a415e101d", "Lets you manage managed HSM pools, but not access to them."));

        // Assign Roles
        CustomizeResource<KeyVaultResource>(r => r.GenerateRoleAssignment = true);
    }
}
