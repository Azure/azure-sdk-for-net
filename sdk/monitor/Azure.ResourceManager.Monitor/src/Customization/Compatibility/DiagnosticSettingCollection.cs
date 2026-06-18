// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Monitor
{
    /// <summary> A collection of <see cref="DiagnosticSettingResource"/> resources. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class DiagnosticSettingCollection : ArmCollection, IEnumerable<DiagnosticSettingResource>, IAsyncEnumerable<DiagnosticSettingResource>
    {
        /// <summary> Initializes a new instance of the <see cref="DiagnosticSettingCollection"/> class for mocking. </summary>
        protected DiagnosticSettingCollection()
        {
        }

        /// <summary> Creates or updates a diagnostic setting. </summary>
        /// <param name="waitUntil"> Completion behavior for the operation. </param>
        /// <param name="name"> The diagnostic setting name. </param>
        /// <param name="data"> The diagnostic setting data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The create or update operation. </returns>
        public virtual ArmOperation<DiagnosticSettingResource> CreateOrUpdate(WaitUntil waitUntil, string name, DiagnosticSettingData data, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Creates or updates a diagnostic setting. </summary>
        /// <param name="waitUntil"> Completion behavior for the operation. </param>
        /// <param name="name"> The diagnostic setting name. </param>
        /// <param name="data"> The diagnostic setting data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The create or update operation. </returns>
        public virtual Task<ArmOperation<DiagnosticSettingResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, DiagnosticSettingData data, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a diagnostic setting. </summary>
        /// <param name="name"> The diagnostic setting name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic setting resource. </returns>
        public virtual Response<DiagnosticSettingResource> Get(string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a diagnostic setting. </summary>
        /// <param name="name"> The diagnostic setting name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic setting resource. </returns>
        public virtual Task<Response<DiagnosticSettingResource>> GetAsync(string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets all diagnostic settings in the collection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of diagnostic setting resources. </returns>
        public virtual Pageable<DiagnosticSettingResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets all diagnostic settings in the collection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of diagnostic setting resources. </returns>
        public virtual AsyncPageable<DiagnosticSettingResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Checks whether a diagnostic setting exists. </summary>
        /// <param name="name"> The diagnostic setting name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> Whether the diagnostic setting exists. </returns>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Checks whether a diagnostic setting exists. </summary>
        /// <param name="name"> The diagnostic setting name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> Whether the diagnostic setting exists. </returns>
        public virtual Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Tries to get a diagnostic setting. </summary>
        /// <param name="name"> The diagnostic setting name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic setting resource if it exists. </returns>
        public virtual NullableResponse<DiagnosticSettingResource> GetIfExists(string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Tries to get a diagnostic setting. </summary>
        /// <param name="name"> The diagnostic setting name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic setting resource if it exists. </returns>
        public virtual Task<NullableResponse<DiagnosticSettingResource>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        IEnumerator<DiagnosticSettingResource> IEnumerable<DiagnosticSettingResource>.GetEnumerator() => throw new NotSupportedException("This API is no longer supported.");
        IAsyncEnumerator<DiagnosticSettingResource> IAsyncEnumerable<DiagnosticSettingResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => throw new NotSupportedException("This API is no longer supported.");
        IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException("This API is no longer supported.");
    }
}
