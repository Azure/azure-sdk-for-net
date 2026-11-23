// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Cdn
{
    // RuleSets_Create accepts an optional request body starting with api-version 2026-10-01.
    // Keep the body-less overloads shipped in Azure.ResourceManager.Cdn 1.5.1 for backward compatibility.
    public partial class FrontDoorRuleSetResource
    {
        /// <summary> Creates or updates this rule set. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<FrontDoorRuleSetResource>> UpdateAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => UpdateAsync(waitUntil, null, cancellationToken);

        /// <summary> Creates or updates this rule set. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<FrontDoorRuleSetResource> Update(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => Update(waitUntil, null, cancellationToken);
    }
}
