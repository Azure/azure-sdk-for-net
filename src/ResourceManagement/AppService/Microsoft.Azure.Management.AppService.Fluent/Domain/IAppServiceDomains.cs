// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using AppServiceDomain.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point for domain management API.
    /// </summary>
    public interface IAppServiceDomains  :
        ISupportsCreating<AppServiceDomain.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain>,
        ISupportsListingByGroup<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
        ISupportsGettingByGroup<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain>,
        ISupportsGettingById<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain>
    {
        /// <summary>
        /// List the agreements for purchasing a domain with a specific top level extension.
        /// </summary>
        /// <param name="topLevelExtension">The top level extension of the domain, e.g., "com", "net", "org".</param>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.AppService.Fluent.IDomainLegalAgreement> ListAgreements(string topLevelExtension);
    }
}