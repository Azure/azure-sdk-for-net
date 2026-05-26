// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager;

namespace Azure.ResourceManager.AppContainers
{
    public partial class ContainerAppSourceControlCollection
    {
        // Preserve the shipped overload without xMsGithubAuxiliary; the generated method now
        // exposes that optional header parameter before the cancellation token.
        /// <summary> Create or update the SourceControl for a Container App. </summary>
        public virtual ArmOperation<ContainerAppSourceControlResource> CreateOrUpdate(WaitUntil waitUntil, string sourceControlName, ContainerAppSourceControlData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdate(waitUntil, sourceControlName, data, default, cancellationToken);
        }

        /// <summary> Create or update the SourceControl for a Container App. </summary>
        public virtual async Task<ArmOperation<ContainerAppSourceControlResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string sourceControlName, ContainerAppSourceControlData data, CancellationToken cancellationToken)
        {
            return await CreateOrUpdateAsync(waitUntil, sourceControlName, data, default, cancellationToken).ConfigureAwait(false);
        }
    }
}
