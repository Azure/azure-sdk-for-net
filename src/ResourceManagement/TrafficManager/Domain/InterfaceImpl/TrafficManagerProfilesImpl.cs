// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition;
    using Microsoft.Azure.Management.TrafficManager.Fluent.Models;
    using Microsoft.Rest;

    internal partial class TrafficManagerProfilesImpl 
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
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IBlank;
        }

        /// <summary>
        /// Asynchronously checks that the DNS name is valid for traffic manager profile and is not in use.
        /// </summary>
        /// <param name="dnsNameLabel">The DNS name to check.</param>
        /// <return>A representation of the deferred computation of this call, returning whether the DNS is available to be used for a traffic manager profile and other info if not.</return>
        async Task<Microsoft.Azure.Management.TrafficManager.Fluent.CheckProfileDnsNameAvailabilityResult> Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfiles.CheckDnsNameAvailabilityAsync(string dnsNameLabel, CancellationToken cancellationToken)
        {
            return await this.CheckDnsNameAvailabilityAsync(dnsNameLabel, cancellationToken) as Microsoft.Azure.Management.TrafficManager.Fluent.CheckProfileDnsNameAvailabilityResult;
        }

        /// <summary>
        /// Checks that the DNS name is valid for traffic manager profile and is not in use.
        /// </summary>
        /// <param name="dnsNameLabel">The DNS name to check.</param>
        /// <return>Whether the DNS is available to be used for a traffic manager profile and other info if not.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.CheckProfileDnsNameAvailabilityResult Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfiles.CheckDnsNameAvailability(string dnsNameLabel)
        {
            return this.CheckDnsNameAvailability(dnsNameLabel) as Microsoft.Azure.Management.TrafficManager.Fluent.CheckProfileDnsNameAvailabilityResult;
        }

        /// <return>The default Geographic Hierarchy used by the Geographic traffic routing method.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfilesBeta.GetGeographicHierarchyRoot()
        {
            return this.GetGeographicHierarchyRoot() as Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation;
        }

    }
}