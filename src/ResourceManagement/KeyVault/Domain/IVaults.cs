// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent
{

    using Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point for key vaults management API.
    /// </summary>
    public interface IVaults  :
        ISupportsListing<Microsoft.Azure.Management.KeyVault.Fluent.IVault>,
        ISupportsCreating<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.KeyVault.Fluent.IVault>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.KeyVault.Fluent.IVault>,
        ISupportsGettingById<Microsoft.Azure.Management.KeyVault.Fluent.IVault>,
        ISupportsDeletingByResourceGroup,
        IHasManager<IKeyVaultManager>,
        IHasInner<IVaultsOperations>
    {
    }
}