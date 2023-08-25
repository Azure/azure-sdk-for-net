// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Logic
{
    /// <summary>
    /// A Class representing a LogicWorkflow along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="LogicWorkflowResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetLogicWorkflowResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetLogicWorkflow method.
    /// </summary>
    public partial class LogicWorkflowResource
    {
        /// <summary>
        /// Updates a workflow.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Workflows_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release. Please use UpdateAsync(WaitUntil waitUntil, LogicWorkflowData data, CancellationToken cancellationToken = default) instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<LogicWorkflowResource>> UpdateAsync(CancellationToken cancellationToken = default)
        {
            var operation = await UpdateAsync(WaitUntil.Started, Data, cancellationToken).ConfigureAwait(false);
            return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates a workflow.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Workflows_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release. Please use Update(WaitUntil waitUntil, LogicWorkflowData data, CancellationToken cancellationToken = default) instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<LogicWorkflowResource> Update(CancellationToken cancellationToken = default)
        {
            var operation = Update(WaitUntil.Started, Data, cancellationToken);
            return operation.WaitForCompletion(cancellationToken);
        }
    }
}
