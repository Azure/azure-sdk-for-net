// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.Disk.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    /// <summary>
    /// Entry point to managed disk management API in Azure.
    /// </summary>
    public interface IDisks :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Disk.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IDisk>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.Compute.Fluent.IDisk>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Compute.Fluent.IDisk>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Compute.Fluent.IDisk>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.Compute.Fluent.IDisk>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Compute.Fluent.IComputeManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Compute.Fluent.IDisksOperations>,
        Microsoft.Azure.Management.Compute.Fluent.IDisksBeta
    {
    }
}