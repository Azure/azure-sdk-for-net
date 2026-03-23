// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: this type was removed in the TypeSpec migration.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.AlertsManagement
{
    /// <summary> Backward compatibility stub. This type is no longer supported. </summary>
    [Obsolete("This type is no longer supported.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AlertProcessingRuleCollection : ArmCollection, IEnumerable<AlertProcessingRuleResource>, IAsyncEnumerable<AlertProcessingRuleResource>
    {
        /// <summary> Initializes a new instance for mocking. </summary>
        protected AlertProcessingRuleCollection() { }

        /// <summary> Creates or updates. </summary>
        /// <param name="waitUntil"> Wait until. </param>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="data"> The data. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual ArmOperation<AlertProcessingRuleResource> CreateOrUpdate(WaitUntil waitUntil, string alertProcessingRuleName, AlertProcessingRuleData data, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Creates or updates async. </summary>
        /// <param name="waitUntil"> Wait until. </param>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="data"> The data. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<ArmOperation<AlertProcessingRuleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string alertProcessingRuleName, AlertProcessingRuleData data, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Checks if exists. </summary>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<bool> Exists(string alertProcessingRuleName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Checks if exists async. </summary>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<Response<bool>> ExistsAsync(string alertProcessingRuleName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets a resource. </summary>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<AlertProcessingRuleResource> Get(string alertProcessingRuleName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets a resource async. </summary>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<Response<AlertProcessingRuleResource>> GetAsync(string alertProcessingRuleName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets all resources. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Pageable<AlertProcessingRuleResource> GetAll(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets all resources async. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual AsyncPageable<AlertProcessingRuleResource> GetAllAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets if exists. </summary>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual NullableResponse<AlertProcessingRuleResource> GetIfExists(string alertProcessingRuleName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets if exists async. </summary>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<NullableResponse<AlertProcessingRuleResource>> GetIfExistsAsync(string alertProcessingRuleName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets the async enumerator. </summary>
        IAsyncEnumerator<AlertProcessingRuleResource> IAsyncEnumerable<AlertProcessingRuleResource>.GetAsyncEnumerator(CancellationToken cancellationToken) { throw new NotSupportedException(); }
        /// <summary> Gets the enumerator. </summary>
        IEnumerator<AlertProcessingRuleResource> IEnumerable<AlertProcessingRuleResource>.GetEnumerator() { throw new NotSupportedException(); }
        /// <summary> Gets the enumerator. </summary>
        IEnumerator IEnumerable.GetEnumerator() { throw new NotSupportedException(); }
    }
}
