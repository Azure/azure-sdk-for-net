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
    public partial class FrontDoorRuleSetCollection
    {
        /// <summary> Creates a new rule set within the specified profile. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ruleSetName"> Name of the rule set under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="ruleSetName"/> is null. </exception>
        /// <exception cref="System.ArgumentException"> <paramref name="ruleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<FrontDoorRuleSetResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ruleSetName, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, ruleSetName, null, cancellationToken);

        /// <summary> Creates a new rule set within the specified profile. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ruleSetName"> Name of the rule set under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="ruleSetName"/> is null. </exception>
        /// <exception cref="System.ArgumentException"> <paramref name="ruleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<FrontDoorRuleSetResource> CreateOrUpdate(WaitUntil waitUntil, string ruleSetName, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, ruleSetName, null, cancellationToken);
    }
}
