// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using AppServiceDomain.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point for domain management API.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface IAppServiceDomains  :
        ISupportsCreating<AppServiceDomain.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain>,
        ISupportsListingByGroup<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
        ISupportsGettingByGroup<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain>,
        ISupportsGettingById<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain>,
        IHasManager<IAppServiceManager>,
        IHasInner<IDomainsOperations>
    {
        /// <summary>
        /// List the agreements for purchasing a domain with a specific top level extension.
        /// </summary>
        /// <param name="topLevelExtension">The top level extension of the domain, e.g., "com", "net", "org".</param>
        /// <return>The list of agreements required for the purchase.</return>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.PagedList<Microsoft.Azure.Management.AppService.Fluent.IDomainLegalAgreement> ListAgreements(string topLevelExtension);
    }
}