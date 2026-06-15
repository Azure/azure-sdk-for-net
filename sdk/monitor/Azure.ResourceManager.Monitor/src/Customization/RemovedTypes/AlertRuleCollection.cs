// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Monitor
{
    /// <summary> A collection of <see cref="AlertRuleResource"/> resources. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class AlertRuleCollection : ArmCollection, IEnumerable<AlertRuleResource>, IAsyncEnumerable<AlertRuleResource>
    {
        /// <summary> Initializes a new instance of the <see cref="AlertRuleCollection"/> class for mocking. </summary>
        protected AlertRuleCollection()
        {
        }

        /// <summary> Gets an alert rule. </summary>
        /// <param name="ruleName"> The rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule resource. </returns>
        public virtual Response<AlertRuleResource> Get(string ruleName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an alert rule. </summary>
        /// <param name="ruleName"> The rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule resource. </returns>
        public virtual Task<Response<AlertRuleResource>> GetAsync(string ruleName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets all alert rules in the collection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of alert rules. </returns>
        public virtual Pageable<AlertRuleResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets all alert rules in the collection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of alert rules. </returns>
        public virtual AsyncPageable<AlertRuleResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Checks whether the alert rule exists. </summary>
        /// <param name="ruleName"> The rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> Whether the alert rule exists. </returns>
        public virtual Response<bool> Exists(string ruleName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Checks whether the alert rule exists. </summary>
        /// <param name="ruleName"> The rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> Whether the alert rule exists. </returns>
        public virtual Task<Response<bool>> ExistsAsync(string ruleName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an alert rule if it exists. </summary>
        /// <param name="ruleName"> The rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule resource if it exists. </returns>
        public virtual NullableResponse<AlertRuleResource> GetIfExists(string ruleName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an alert rule if it exists. </summary>
        /// <param name="ruleName"> The rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule resource if it exists. </returns>
        public virtual Task<NullableResponse<AlertRuleResource>> GetIfExistsAsync(string ruleName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Creates or updates an alert rule. </summary>
        /// <param name="waitUntil"> Completion behavior for the operation. </param>
        /// <param name="ruleName"> The rule name. </param>
        /// <param name="data"> The alert rule data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule operation. </returns>
        public virtual ArmOperation<AlertRuleResource> CreateOrUpdate(WaitUntil waitUntil, string ruleName, AlertRuleData data, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Creates or updates an alert rule. </summary>
        /// <param name="waitUntil"> Completion behavior for the operation. </param>
        /// <param name="ruleName"> The rule name. </param>
        /// <param name="data"> The alert rule data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule operation. </returns>
        public virtual Task<ArmOperation<AlertRuleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ruleName, AlertRuleData data, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        IEnumerator<AlertRuleResource> IEnumerable<AlertRuleResource>.GetEnumerator() => throw new NotSupportedException("This API is no longer supported.");
        IAsyncEnumerator<AlertRuleResource> IAsyncEnumerable<AlertRuleResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => throw new NotSupportedException("This API is no longer supported.");
        IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException("This API is no longer supported.");
    }
}
