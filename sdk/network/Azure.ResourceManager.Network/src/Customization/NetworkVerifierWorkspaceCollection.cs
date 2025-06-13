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

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing a collection of <see cref="NetworkVerifierWorkspaceResource"/> and their operations.
    /// Each <see cref="NetworkVerifierWorkspaceResource"/> in the collection will belong to the same instance of <see cref="NetworkManagerResource"/>.
    /// To get a <see cref="NetworkVerifierWorkspaceCollection"/> instance call the GetNetworkVerifierWorkspaces method from an instance of <see cref="NetworkManagerResource"/>.
    /// </summary>
    public partial class NetworkVerifierWorkspaceCollection : ArmCollection, IEnumerable<NetworkVerifierWorkspaceResource>, IAsyncEnumerable<NetworkVerifierWorkspaceResource>
    {
        /// <summary>
        /// Creates Verifier Workspace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkManagers/{networkManagerName}/verifierWorkspaces/{workspaceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VerifierWorkspaces_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-05-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkVerifierWorkspaceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="workspaceName"> Workspace name. </param>
        /// <param name="data"> Verifier Workspace object to create/update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<NetworkVerifierWorkspaceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string workspaceName, NetworkVerifierWorkspaceData data, CancellationToken cancellationToken)
            => await CreateOrUpdateAsync(waitUntil, workspaceName, data, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates Verifier Workspace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkManagers/{networkManagerName}/verifierWorkspaces/{workspaceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VerifierWorkspaces_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-05-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkVerifierWorkspaceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="workspaceName"> Workspace name. </param>
        /// <param name="data"> Verifier Workspace object to create/update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workspaceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<NetworkVerifierWorkspaceResource> CreateOrUpdate(WaitUntil waitUntil, string workspaceName, NetworkVerifierWorkspaceData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, workspaceName, data, null, cancellationToken);
    }
}
