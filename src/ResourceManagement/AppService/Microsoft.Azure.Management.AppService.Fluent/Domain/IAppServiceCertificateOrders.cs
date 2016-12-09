// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServiceCertificateOrder.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point for app service certificate order management API.
    /// </summary>
    public interface IAppServiceCertificateOrders  :
        ISupportsCreating<AppServiceCertificateOrder.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsListingByGroup<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder>,
        ISupportsGettingById<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder>,
        ISupportsDeletingByGroup
    {
        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name and the name of its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the resource is in.</param>
        /// <param name="name">The name of the resource. (Note, this is not the ID).</param>
        Task<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder> GetByGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}