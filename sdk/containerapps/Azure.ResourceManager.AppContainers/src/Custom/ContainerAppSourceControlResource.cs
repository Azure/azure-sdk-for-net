// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager;

namespace Azure.ResourceManager.AppContainers
{
    public partial class ContainerAppSourceControlResource
    {
        // New generated overloads include optional x-ms-original-file and x-ms-file-path parameters.
        // Preserve the old overloads that only accepted WaitUntil, data, and cancellation token.
        /// <summary> Delete a ContainerAppSourceControl. </summary>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            return Delete(waitUntil, default, default, default, cancellationToken);
        }

        /// <summary> Delete a ContainerAppSourceControl. </summary>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            return await DeleteAsync(waitUntil, default, default, default, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Update a ContainerAppSourceControl. </summary>
        public virtual ArmOperation<ContainerAppSourceControlResource> Update(WaitUntil waitUntil, ContainerAppSourceControlData data, CancellationToken cancellationToken)
        {
            return Update(waitUntil, data, default, cancellationToken);
        }

        /// <summary> Update a ContainerAppSourceControl. </summary>
        public virtual async Task<ArmOperation<ContainerAppSourceControlResource>> UpdateAsync(WaitUntil waitUntil, ContainerAppSourceControlData data, CancellationToken cancellationToken)
        {
            return await UpdateAsync(waitUntil, data, default, cancellationToken).ConfigureAwait(false);
        }
    }
}
