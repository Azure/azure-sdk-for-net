// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Models;

namespace Azure.ResourceManager.ContainerRegistry
{
    /// <summary>
    /// A Class representing a ContainerRegistryRun along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="ContainerRegistryRunResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetContainerRegistryRunResource method.
    /// Otherwise you can get one from its parent resource <see cref="ContainerRegistryResource"/> using the GetContainerRegistryRun method.
    /// </summary>
    public partial class ContainerRegistryRunResource : ArmResource
    {
        /// <summary>
        /// Patch the run properties.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Runs_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2019-06-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryRunResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> The run update properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated, use `Task<Response<ContainerRegistryRunResource>> UpdateAsync(ContainerRegistryRunPatch patch, CancellationToken cancellationToken = default)` instead")]
        public virtual Task<ArmOperation<ContainerRegistryRunResource>> UpdateAsync(WaitUntil waitUntil, ContainerRegistryRunPatch patch, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported. Please use `Task<Response<ContainerRegistryRunResource>> UpdateAsync(ContainerRegistryRunPatch patch, CancellationToken cancellationToken = default)` instead.");
        }

        /// <summary>
        /// Patch the run properties.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Runs_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2019-06-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryRunResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> The run update properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated, use `Response<ContainerRegistryRunResource> Update(ContainerRegistryRunPatch patch, CancellationToken cancellationToken = default)` instead")]
        public virtual ArmOperation<ContainerRegistryRunResource> Update(WaitUntil waitUntil, ContainerRegistryRunPatch patch, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported. Please use `Response<ContainerRegistryRunResource> Update(ContainerRegistryRunPatch patch, CancellationToken cancellationToken = default)` instead.");
        }

        /// <summary>
        /// Cancel an existing run.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}/cancel</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Runs_Cancel</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2019-06-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryRunResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated, use `Task<Response> CancelAsync(CancellationToken cancellationToken = default)` instead")]
        public virtual Task<ArmOperation> CancelAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported. Please use `Task<Response> CancelAsync(CancellationToken cancellationToken = default)` instead.");
        }

        /// <summary>
        /// Cancel an existing run.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/runs/{runId}/cancel</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Runs_Cancel</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2019-06-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerRegistryRunResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated, use `Response Cancel(CancellationToken cancellationToken = default)` instead")]
        public virtual ArmOperation Cancel(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported. Please use `Response Cancel(CancellationToken cancellationToken = default)` instead.");
        }
    }
}
