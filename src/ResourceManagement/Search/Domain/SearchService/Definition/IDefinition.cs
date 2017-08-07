// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Search.Fluent.SearchService.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Search.Fluent;
    using Microsoft.Azure.Management.Search.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;

    public interface IWithReplicasAndCreate  :
        Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IWithCreate
    {
        /// <summary>
        /// Specifies the SKU of the Search service.
        /// </summary>
        /// <param name="count">The number of replicas to be created.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IWithCreate WithReplicaCount(int count);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// (via  WithCreate.create()), but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Search.Fluent.ISearchService>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the Search service definition allowing to specify the SKU.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the SKU of the Search service.
        /// </summary>
        /// <param name="skuName">The SKU.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IWithCreate WithSku(SkuName skuName);

        /// <summary>
        /// Specifies to use a basic SKU type for the Search service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IWithReplicasAndCreate WithBasicSku();

        /// <summary>
        /// Specifies to use a free SKU type for the Search service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IWithCreate WithFreeSku();

        /// <summary>
        /// Specifies to use a standard SKU type for the Search service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IWithPartitionsAndCreate WithStandardSku();
    }

    /// <summary>
    /// The first stage of the Search service definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The entirety of the Search service definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IBlank,
        Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IWithGroup,
        Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IWithSku,
        Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IWithPartitionsAndCreate,
        Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IWithReplicasAndCreate,
        Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IWithCreate
    {
    }

    public interface IWithPartitionsAndCreate  :
        Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IWithReplicasAndCreate
    {
        /// <summary>
        /// Specifies the SKU of the Search service.
        /// </summary>
        /// <param name="count">The number of partitions to be created.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IWithReplicasAndCreate WithPartitionCount(int count);
    }

    /// <summary>
    /// The stage of the Search service definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Search.Fluent.SearchService.Definition.IWithSku>
    {
    }
}