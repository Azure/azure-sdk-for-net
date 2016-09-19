/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.KeyVault
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition;
    /// <summary>
    /// Entry point for key vaults management API.
    /// </summary>
    public interface IVaults  :
        ISupportsListing<IVault>,
        ISupportsCreating<IBlank>,
        ISupportsDeleting,
        ISupportsListingByGroup<IVault>,
        ISupportsGettingByGroup<IVault>,
        ISupportsGettingById<IVault>,
        ISupportsDeletingByGroup
    {
    }
}