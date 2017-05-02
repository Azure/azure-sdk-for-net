// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Rest;
    using Models;

    internal partial class CdnProfilesImpl 
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
        CdnProfile.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<CdnProfile.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as CdnProfile.Definition.IBlank;
        }

        /// <summary>
        /// Checks the availability of a endpoint name without creating the CDN endpoint.
        /// </summary>
        /// <param name="name">The endpoint resource name to validate.</param>
        /// <return>The CheckNameAvailabilityResult object if successful.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CheckNameAvailabilityResult Microsoft.Azure.Management.Cdn.Fluent.ICdnProfiles.CheckEndpointNameAvailability(string name)
        {
            return this.CheckEndpointNameAvailabilityAsync(name).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Generates a dynamic SSO URI used to sign in to the CDN supplemental portal.
        /// Supplemental portal is used to configure advanced feature capabilities that are not
        /// yet available in the Azure portal, such as core reports in a standard profile;
        /// rules engine, advanced HTTP reports, and real-time stats and alerts in a premium profile.
        /// The SSO URI changes approximately every 10 minutes.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <return>The Sso Uri string if successful.</return>
        string Microsoft.Azure.Management.Cdn.Fluent.ICdnProfiles.GenerateSsoUri(string resourceGroupName, string profileName)
        {
            return this.GenerateSsoUriAsync(resourceGroupName, profileName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Lists all of the available CDN REST API operations.
        /// </summary>
        /// <return>List of available CDN REST operations.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Cdn.Fluent.Operation> Microsoft.Azure.Management.Cdn.Fluent.ICdnProfiles.ListOperations()
        {
            return this.ListOperations() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Cdn.Fluent.Operation>;
        }

        /// <summary>
        /// Forcibly purges CDN endpoint content.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be purged. Can describe a file path or a wild card directory.</param>
        void Microsoft.Azure.Management.Cdn.Fluent.ICdnProfiles.PurgeEndpointContent(string resourceGroupName, string profileName, string endpointName, IList<string> contentPaths)
        {
            this.PurgeEndpointContentAsync(resourceGroupName, profileName, endpointName, contentPaths).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Starts an existing stopped CDN endpoint.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        void Microsoft.Azure.Management.Cdn.Fluent.ICdnProfiles.StartEndpoint(string resourceGroupName, string profileName, string endpointName)
        {
 
            this.StartEndpointAsync(resourceGroupName, profileName, endpointName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Check the quota and actual usage of the CDN profiles under the current subscription.
        /// </summary>
        /// <return>Quotas and actual usages of the CDN profiles under the current subscription.</return>
        System.Collections.Generic.IEnumerable<ResourceUsage> Microsoft.Azure.Management.Cdn.Fluent.ICdnProfiles.ListResourceUsage()
        {
            return this.ListResourceUsage();
        }

        /// <summary>
        /// Checks the availability of a endpoint name without creating the CDN endpoint asynchronously.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="name">The endpoint resource name to validate.</param>
        /// <return>The Observable to CheckNameAvailabilityResult object if successful.</return>
        async Task<Microsoft.Azure.Management.Cdn.Fluent.CheckNameAvailabilityResult> Microsoft.Azure.Management.Cdn.Fluent.ICdnProfilesBeta.CheckEndpointNameAvailabilityAsync(string name, CancellationToken cancellationToken)
        {
            return await this.CheckEndpointNameAvailabilityAsync(name, cancellationToken) as Microsoft.Azure.Management.Cdn.Fluent.CheckNameAvailabilityResult;
        }

        /// <summary>
        /// Lists all the edge nodes of a CDN service.
        /// </summary>
        /// <return>List of all the edge nodes of a CDN service.</return>
        System.Collections.Generic.IEnumerable<EdgeNode> Microsoft.Azure.Management.Cdn.Fluent.ICdnProfiles.ListEdgeNodes()
        {
            return this.ListEdgeNodes();
        }

        /// <summary>
        /// Stops an existing running CDN endpoint.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        void Microsoft.Azure.Management.Cdn.Fluent.ICdnProfiles.StopEndpoint(string resourceGroupName, string profileName, string endpointName)
        {
 
            this.StopEndpointAsync(resourceGroupName, profileName, endpointName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Forcibly pre-loads CDN endpoint content. Available for Verizon profiles.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be loaded. Should describe a file path.</param>
        void Microsoft.Azure.Management.Cdn.Fluent.ICdnProfiles.LoadEndpointContent(string resourceGroupName, string profileName, string endpointName, IList<string> contentPaths)
        {
            this.LoadEndpointContentAsync(resourceGroupName, profileName, endpointName, contentPaths).GetAwaiter().GetResult();
        }
    }
}