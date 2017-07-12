// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition;
    using Microsoft.Azure.Management.Dns.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

    internal partial class DnsZonesImpl 
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
        DnsZone.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<DnsZone.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as DnsZone.Definition.IBlank;
        }

        /// <summary>
        /// Asynchronously delete the zone from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        /// <return>A representation of the deferred computation this delete call.</return>
        async Task Microsoft.Azure.Management.Dns.Fluent.IDnsZones.DeleteByIdAsync(string id, string eTagValue, CancellationToken cancellationToken)
        {
 
            await this.DeleteByIdAsync(id, eTagValue, cancellationToken);
        }

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        void Microsoft.Azure.Management.Dns.Fluent.IDnsZones.DeleteById(string id, string eTagValue)
        {
 
            this.DeleteById(id, eTagValue);
        }

        /// <summary>
        /// Asynchronously deletes the zone from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the resource is part of.</param>
        /// <param name="zoneName">The name of the zone.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        /// <return>A representation of the deferred computation this delete call.</return>
        async Task Microsoft.Azure.Management.Dns.Fluent.IDnsZones.DeleteByResourceGroupNameAsync(string resourceGroupName, string zoneName, string eTagValue, CancellationToken cancellationToken)
        {
 
            await this.DeleteByResourceGroupNameAsync(resourceGroupName, zoneName, eTagValue, cancellationToken);
        }

        /// <summary>
        /// Deletes the zone from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the resource is part of.</param>
        /// <param name="zoneName">The name of the zone.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        void Microsoft.Azure.Management.Dns.Fluent.IDnsZones.DeleteByResourceGroupName(string resourceGroupName, string zoneName, string eTagValue)
        {
 
            this.DeleteByResourceGroupName(resourceGroupName, zoneName, eTagValue);
        }
    }
}