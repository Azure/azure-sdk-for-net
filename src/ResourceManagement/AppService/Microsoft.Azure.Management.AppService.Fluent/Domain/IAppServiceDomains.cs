// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.AppService.Fluent.AppServiceDomain.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point for domain management API.
    /// </summary>
    public interface IAppServiceDomains  :
        IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<AppServiceDomain.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.AppService.Fluent.IAppServiceManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.AppService.Fluent.IDomainsOperations>
    {
        /// <summary>
        /// List the agreements for purchasing a domain with a specific top level extension.
        /// </summary>
        /// <param name="topLevelExtension">The top level extension of the domain, e.g., "com", "net", "org".</param>
        /// <return>The list of agreements required for the purchase.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.AppService.Fluent.IDomainLegalAgreement> ListAgreements(string topLevelExtension);
    }
}