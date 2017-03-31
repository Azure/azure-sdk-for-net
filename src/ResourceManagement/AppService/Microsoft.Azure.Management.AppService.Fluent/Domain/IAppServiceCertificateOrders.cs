// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServiceCertificateOrder.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point for app service certificate order management API.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface IAppServiceCertificateOrders  :
        ISupportsCreating<IBlank>,
        ISupportsDeletingById,
        ISupportsListingByGroup<IAppServiceCertificateOrder>,
        ISupportsGettingByGroup<IAppServiceCertificateOrder>,
        ISupportsGettingById<IAppServiceCertificateOrder>,
        ISupportsDeletingByGroup,
        IHasManager<IAppServiceManager>,
        IHasInner<IAppServiceCertificateOrdersOperations>
    {
    }
}