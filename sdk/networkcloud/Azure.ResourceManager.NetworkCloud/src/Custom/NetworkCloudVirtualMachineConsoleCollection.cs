// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A class representing a collection of <see cref="NetworkCloudVirtualMachineConsoleResource"/> and their operations.
    /// Each <see cref="NetworkCloudVirtualMachineConsoleResource"/> in the collection will belong to the same instance of <see cref="NetworkCloudVirtualMachineResource"/>.
    /// To get a <see cref="NetworkCloudVirtualMachineConsoleCollection"/> instance call the GetNetworkCloudVirtualMachineConsoles method from an instance of <see cref="NetworkCloudVirtualMachineResource"/>.
    /// </summary>
    public partial class NetworkCloudVirtualMachineConsoleCollection : ArmCollection, IEnumerable<NetworkCloudVirtualMachineConsoleResource>, IAsyncEnumerable<NetworkCloudVirtualMachineConsoleResource>
    {
        /// <summary>
        /// Create a new virtual machine console or update the properties of the existing virtual machine console.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/virtualMachines/{virtualMachineName}/consoles/{consoleName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Consoles_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVirtualMachineConsoleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="consoleName"> The name of the virtual machine console. </param>
        /// <param name="data"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="consoleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="consoleName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<NetworkCloudVirtualMachineConsoleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string consoleName, NetworkCloudVirtualMachineConsoleData data, CancellationToken cancellationToken)
            => await CreateOrUpdateAsync(waitUntil, consoleName, data, null, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Create a new virtual machine console or update the properties of the existing virtual machine console.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/virtualMachines/{virtualMachineName}/consoles/{consoleName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Consoles_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVirtualMachineConsoleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="consoleName"> The name of the virtual machine console. </param>
        /// <param name="data"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="consoleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="consoleName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<NetworkCloudVirtualMachineConsoleResource> CreateOrUpdate(WaitUntil waitUntil, string consoleName, NetworkCloudVirtualMachineConsoleData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, consoleName, data, null, null, cancellationToken);

        /// <summary>
        /// Get a list of consoles for the provided virtual machine.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/virtualMachines/{virtualMachineName}/consoles</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Consoles_ListByVirtualMachine</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVirtualMachineConsoleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NetworkCloudVirtualMachineConsoleResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NetworkCloudVirtualMachineConsoleResource> GetAllAsync(CancellationToken cancellationToken)
			=> GetAllAsync(null, null, cancellationToken);

        /// <summary>
        /// Get a list of consoles for the provided virtual machine.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/virtualMachines/{virtualMachineName}/consoles</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Consoles_ListByVirtualMachine</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudVirtualMachineConsoleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NetworkCloudVirtualMachineConsoleResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NetworkCloudVirtualMachineConsoleResource> GetAll(CancellationToken cancellationToken)
			=> GetAll(null, null, cancellationToken);
    }
}
