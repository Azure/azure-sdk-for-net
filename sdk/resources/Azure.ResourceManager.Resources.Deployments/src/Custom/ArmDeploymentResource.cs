// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    public partial class ArmDeploymentResource : ArmResource
    {
        // This operation is only used for tags operations: AddTag, SetTags, RemoveTag.
        /// <summary>
        /// Update a ArmDeployment.
        /// </summary>
        internal virtual async Task<ArmOperation<ArmDeploymentResource>> UpdateAsync(WaitUntil waitUntil, ArmDeploymentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            ArmDeploymentContent content = new ArmDeploymentContent(data.Location, new ArmDeploymentProperties(data.Properties.Mode.Value), data.Tags, null, null);
            return await UpdateAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
        }

        // This operation is only used for tags operations: AddTag, SetTags, RemoveTag.
        /// <summary>
        /// Update a ArmDeployment.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Additional parameters supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        internal virtual ArmOperation<ArmDeploymentResource> Update(WaitUntil waitUntil, ArmDeploymentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            ArmDeploymentContent content = new ArmDeploymentContent(data.Location, new ArmDeploymentProperties(data.Properties.Mode.Value), data.Tags, null, null);
            return Update(waitUntil, content, cancellationToken);
        }
    }
}
