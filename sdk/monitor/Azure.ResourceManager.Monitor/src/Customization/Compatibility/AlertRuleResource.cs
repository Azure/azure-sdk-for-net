// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Monitor
{
    /// <summary> A class representing an AlertRule resource and its operations. </summary>
    [Obsolete("This API is no longer supported.", false)]
    public partial class AlertRuleResource : ArmResource
    {
        /// <summary> The resource type for AlertRule resources. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Insights/alertrules";

        /// <summary> Initializes a new instance of the <see cref="AlertRuleResource"/> class for mocking. </summary>
        protected AlertRuleResource()
        {
        }

        /// <summary> Gets the resource data. </summary>
        public virtual AlertRuleData Data => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets whether the resource has data. </summary>
        public virtual bool HasData => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Creates a resource identifier for an AlertRule resource. </summary>
        /// <param name="subscriptionId"> The subscription id. </param>
        /// <param name="resourceGroupName"> The resource group name. </param>
        /// <param name="ruleName"> The rule name. </param>
        /// <returns> A resource identifier. </returns>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ruleName) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets the alert rule. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule resource. </returns>
        public virtual Response<AlertRuleResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets the alert rule. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule resource. </returns>
        public virtual Task<Response<AlertRuleResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Deletes the alert rule. </summary>
        /// <param name="waitUntil"> Completion behavior for the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The delete operation. </returns>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Deletes the alert rule. </summary>
        /// <param name="waitUntil"> Completion behavior for the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The delete operation. </returns>
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Updates the alert rule. </summary>
        /// <param name="patch"> The alert rule patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated alert rule resource. </returns>
        public virtual Response<AlertRuleResource> Update(BinaryData patch, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Updates the alert rule. </summary>
        /// <param name="patch"> The alert rule patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated alert rule resource. </returns>
        public virtual Task<Response<AlertRuleResource>> UpdateAsync(BinaryData patch, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");
    }
}
