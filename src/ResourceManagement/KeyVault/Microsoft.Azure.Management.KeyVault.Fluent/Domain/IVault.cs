// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent
{

    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    /// <summary>
    /// An immutable client-side representation of an Azure Key Vault.
    /// </summary>
    public interface IVault  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.KeyVault.Fluent.IVault>,
        IUpdatable<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>,
        IWrapper<Microsoft.Azure.Management.KeyVault.Fluent.Models.VaultInner>
    {
        /// <returns>the URI of the vault for performing operations on keys and secrets.</returns>
        string VaultUri { get; }

        /// <returns>the Azure Active Directory tenant ID that should be used for</returns>
        /// <returns>authenticating requests to the key vault.</returns>
        string TenantId { get; }

        /// <returns>SKU details.</returns>
        Sku Sku { get; }

        /// <returns>an array of 0 to 16 identities that have access to the key vault. All</returns>
        /// <returns>identities in the array must use the same tenant ID as the key vault's</returns>
        /// <returns>tenant ID.</returns>
        IList<Microsoft.Azure.Management.KeyVault.Fluent.IAccessPolicy> AccessPolicies { get; }

        /// <returns>whether Azure Virtual Machines are permitted to</returns>
        /// <returns>retrieve certificates stored as secrets from the key vault.</returns>
        bool EnabledForDeployment { get; }

        /// <returns>whether Azure Disk Encryption is permitted to</returns>
        /// <returns>retrieve secrets from the vault and unwrap keys.</returns>
        bool EnabledForDiskEncryption { get; }

        /// <returns>whether Azure Resource Manager is permitted to</returns>
        /// <returns>retrieve secrets from the key vault.</returns>
        bool EnabledForTemplateDeployment { get; }

    }
}