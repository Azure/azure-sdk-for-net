// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A Class representing a NetworkCloudBareMetalMachine along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="NetworkCloudBareMetalMachineResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetNetworkCloudBareMetalMachineResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetNetworkCloudBareMetalMachine method.
    /// </summary>
    public partial class NetworkCloudBareMetalMachineResource : ArmResource
    {
        /// <summary>
        /// Patch properties of the provided bare metal machine, or update tags associated with the bare metal machine. Properties and tag updates can be done independently.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/bareMetalMachines/{bareMetalMachineName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BareMetalMachines_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudBareMetalMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<ArmOperation<NetworkCloudBareMetalMachineResource>> UpdateAsync(WaitUntil waitUntil, NetworkCloudBareMetalMachinePatch patch, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, patch, null, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Patch properties of the provided bare metal machine, or update tags associated with the bare metal machine. Properties and tag updates can be done independently.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/bareMetalMachines/{bareMetalMachineName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BareMetalMachines_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudBareMetalMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual ArmOperation<NetworkCloudBareMetalMachineResource> Update(WaitUntil waitUntil, NetworkCloudBareMetalMachinePatch patch, CancellationToken cancellationToken)
            => Update(waitUntil, patch, null, null, cancellationToken);

        // /// <summary>
        // /// Run one or more data extractions on the provided bare metal machine. The URL to storage account with the command execution results and the command exit code can be retrieved from the operation status API once available.
        // /// <list type="bullet">
        // /// <item>
        // /// <term>Request Path</term>
        // /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/bareMetalMachines/{bareMetalMachineName}/runDataExtracts</description>
        // /// </item>
        // /// <item>
        // /// <term>Operation Id</term>
        // /// <description>BareMetalMachines_RunDataExtracts</description>
        // /// </item>
        // /// <item>
        // /// <term>Default Api Version</term>
        // /// <description>2025-07-01-preview</description>
        // /// </item>
        // /// <item>
        // /// <term>Resource</term>
        // /// <description><see cref="NetworkCloudBareMetalMachineResource"/></description>
        // /// </item>
        // /// </list>
        // /// </summary>
        // /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        // /// <param name="bareMetalMachineRunDataExtractsContent"> The request body. </param>
        // /// <param name="cancellationToken"> The cancellation token to use. </param>
        // /// <exception cref="ArgumentNullException"> <paramref name="bareMetalMachineRunDataExtractsContent"/> is null. </exception>
        // public virtual async Task<ArmOperation<NetworkCloudOperationStatusResult>> RunDataExtracts(WaitUntil waitUntil, BareMetalMachineRunDataExtractsContent bareMetalMachineRunDataExtractsContent, CancellationToken cancellationToken)
		// 	=> RunDataExtracts(waitUntil, bareMetalMachineRunDataExtractsContent, cancellationToken).ConfigureAwait(false);
    }
}
