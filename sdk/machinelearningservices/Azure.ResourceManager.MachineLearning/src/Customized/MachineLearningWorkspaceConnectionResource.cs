// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.MachineLearning
{
    /// <summary>
    /// A Class representing a MachineLearningWorkspaceConnection along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="MachineLearningWorkspaceConnectionResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetMachineLearningWorkspaceConnectionResource method.
    /// Otherwise you can get one from its parent resource <see cref="MachineLearningWorkspaceResource" /> using the GetMachineLearningWorkspaceConnection method.
    /// </summary>
    public partial class MachineLearningWorkspaceConnectionResource : ArmResource
    {
        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/connections/{connectionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceConnections_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The object for creating or updating a new workspace connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<MachineLearningWorkspaceConnectionResource>> UpdateAsync(WaitUntil waitUntil, MachineLearningWorkspaceConnectionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            // Customized: preserve the shipped WorkspaceConnections_Create method shape for source compatibility,
            // but do not replay the old PUT because the migrated TypeSpec API only exposes a PATCH request shape.
            // TODO: tracked in https://github.com/Azure/azure-sdk-for-net/issues/60130 - remove when the generated API restores a safe full-resource PUT overload.
            throw new NotSupportedException("The legacy WorkspaceConnections_Create overload accepted full resource data for an endpoint that now updates connection properties through PATCH. The generated replacement is UpdateAsync(WorkspaceConnectionPropertiesV2BasicResourcePatch, CancellationToken); replaying the old PUT would require private generated serialization against a removed request shape.");
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/connections/{connectionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkspaceConnections_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The object for creating or updating a new workspace connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<MachineLearningWorkspaceConnectionResource> Update(WaitUntil waitUntil, MachineLearningWorkspaceConnectionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            // Customized: preserve the shipped WorkspaceConnections_Create method shape for source compatibility,
            // but do not replay the old PUT because the migrated TypeSpec API only exposes a PATCH request shape.
            // TODO: tracked in https://github.com/Azure/azure-sdk-for-net/issues/60130 - remove when the generated API restores a safe full-resource PUT overload.
            throw new NotSupportedException("The legacy WorkspaceConnections_Create overload accepted full resource data for an endpoint that now updates connection properties through PATCH. The generated replacement is Update(WorkspaceConnectionPropertiesV2BasicResourcePatch, CancellationToken); replaying the old PUT would require private generated serialization against a removed request shape.");
        }
    }
}
