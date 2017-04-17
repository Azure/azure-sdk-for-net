// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    internal partial class AppServiceDomainsImpl 
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        AppServiceDomain.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<AppServiceDomain.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as AppServiceDomain.Definition.IBlank;
        }

        /// <summary>
        /// List the agreements for purchasing a domain with a specific top level extension.
        /// </summary>
        /// <param name="topLevelExtension">The top level extension of the domain, e.g., "com", "net", "org".</param>
        /// <return>The list of agreements required for the purchase.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.AppService.Fluent.IDomainLegalAgreement> Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomains.ListAgreements(string topLevelExtension)
        {
            return this.ListAgreements(topLevelExtension) as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.AppService.Fluent.IDomainLegalAgreement>;
        }
    }
}