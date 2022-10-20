// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.SecurityCenter. </summary>
    [CodeGenSuppress("GetSoftwareInventoryAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSoftwareInventory", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSoftwareInventories", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(string))]
    public static partial class SecurityCenterExtensions
    {
        /// <summary> Gets a collection of SoftwareInventoryResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vmName"> Name of the virtual machine. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> is null. </exception>
        /// <returns> An object representing collection of SoftwareInventoryResources and their operations over a SoftwareInventoryResource. </returns>
        public static SoftwareInventoryCollection GetVmSoftwareInventories(this ResourceGroupResource resourceGroupResource, string vmName)
        {
            Argument.AssertNotNullOrEmpty(vmName, nameof(vmName));

            return GetExtensionClient(resourceGroupResource).GetSoftwareInventories("Microsoft.Compute", "virtualMachines", vmName);
        }

        /// <summary>
        /// Gets a single software data of the virtual machine.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceNamespace}/{resourceType}/{resourceName}/providers/Microsoft.Security/softwareInventories/{softwareName}
        /// Operation Id: SoftwareInventories_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vmName"> Name of the resource. </param>
        /// <param name="softwareName"> Name of the installed software. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmName"/> or <paramref name="softwareName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> or <paramref name="softwareName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<SoftwareInventoryResource>> GetVmSoftwareInventoryAsync(this ResourceGroupResource resourceGroupResource, string vmName, string softwareName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetVmSoftwareInventories(vmName).GetAsync(softwareName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a single software data of the virtual machine.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceNamespace}/{resourceType}/{resourceName}/providers/Microsoft.Security/softwareInventories/{softwareName}
        /// Operation Id: SoftwareInventories_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vmName"> Name of the resource. </param>
        /// <param name="softwareName"> Name of the installed software. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmName"/> or <paramref name="softwareName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> or <paramref name="softwareName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<SoftwareInventoryResource> GetVmSoftwareInventory(this ResourceGroupResource resourceGroupResource, string vmName, string softwareName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetVmSoftwareInventories(vmName).Get(softwareName, cancellationToken);
        }
    }
}
