// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Threading;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class CdnProfilesImpl 
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is Creatable.create().
        /// Note that the Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see Creatable.create() among the available methods, it
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
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        IEnumerable<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>.ListByResourceGroup(string resourceGroupName)
        {
            return this.ListByResourceGroup(resourceGroupName);
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name and the name of its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the resource is in.</param>
        /// <param name="name">The name of the resource. (Note, this is not the ID).</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<ICdnProfile> ISupportsGettingByResourceGroup<ICdnProfile>.GetByResourceGroupAsync(
            string resourceGroupName, 
            string name, 
            CancellationToken cancellationToken)
        {
            return await this.GetByResourceGroupAsync(resourceGroupName, name, cancellationToken);
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
 
            this.PurgeEndpointContent(resourceGroupName, profileName, endpointName, contentPaths);
        }

        /// <summary>
        /// Stops an existing running CDN endpoint.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        void Microsoft.Azure.Management.Cdn.Fluent.ICdnProfiles.StopEndpoint(string resourceGroupName, string profileName, string endpointName)
        {
 
            this.StopEndpoint(resourceGroupName, profileName, endpointName);
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
            return this.GenerateSsoUri(resourceGroupName, profileName);
        }

        /// <summary>
        /// Lists all of the available CDN REST API operations.
        /// </summary>
        /// <return>List of available CDN REST operations.</return>
        IEnumerable<Microsoft.Azure.Management.Cdn.Fluent.Operation> Microsoft.Azure.Management.Cdn.Fluent.ICdnProfiles.ListOperations()
        {
            return this.ListOperations();
        }

        /// <summary>
        /// Checks the availability of a endpoint name without creating the CDN endpoint.
        /// </summary>
        /// <param name="name">The endpoint resource name to validate.</param>
        /// <return>The CheckNameAvailabilityResult object if successful.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CheckNameAvailabilityResult Microsoft.Azure.Management.Cdn.Fluent.ICdnProfiles.CheckEndpointNameAvailability(string name)
        {
            return this.CheckEndpointNameAvailability(name) as Microsoft.Azure.Management.Cdn.Fluent.CheckNameAvailabilityResult;
        }

        /// <summary>
        /// Starts an existing stopped CDN endpoint.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        void Microsoft.Azure.Management.Cdn.Fluent.ICdnProfiles.StartEndpoint(string resourceGroupName, string profileName, string endpointName)
        {
 
            this.StartEndpoint(resourceGroupName, profileName, endpointName);
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
 
            this.LoadEndpointContent(resourceGroupName, profileName, endpointName, contentPaths);
        }

        /// <summary>
        /// Asynchronously delete a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="groupName">The group the resource is part of.</param>
        /// <param name="name">The name of the resource.</param>
        /// <return>An observable to the request.</return>
        async Task ISupportsDeletingByResourceGroup.DeleteByResourceGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        { 
            await this.DeleteByResourceGroupAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        IEnumerable<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>.List()
        {
            return this.List();
        }
    }
}