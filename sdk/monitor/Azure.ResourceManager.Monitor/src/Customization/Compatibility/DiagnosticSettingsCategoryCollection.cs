// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Monitor
{
    /// <summary> A collection of <see cref="DiagnosticSettingsCategoryResource"/> resources. </summary>
    [Obsolete("This API is no longer supported.", false)]
    public partial class DiagnosticSettingsCategoryCollection : ArmCollection, IEnumerable<DiagnosticSettingsCategoryResource>, IAsyncEnumerable<DiagnosticSettingsCategoryResource>
    {
        /// <summary> Initializes a new instance of the <see cref="DiagnosticSettingsCategoryCollection"/> class for mocking. </summary>
        protected DiagnosticSettingsCategoryCollection()
        {
        }

        /// <summary> Gets a diagnostic settings category. </summary>
        /// <param name="name"> The diagnostic settings category name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic settings category resource. </returns>
        public virtual Response<DiagnosticSettingsCategoryResource> Get(string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a diagnostic settings category. </summary>
        /// <param name="name"> The diagnostic settings category name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic settings category resource. </returns>
        public virtual Task<Response<DiagnosticSettingsCategoryResource>> GetAsync(string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets all diagnostic settings categories in the collection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of diagnostic settings category resources. </returns>
        public virtual Pageable<DiagnosticSettingsCategoryResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets all diagnostic settings categories in the collection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of diagnostic settings category resources. </returns>
        public virtual AsyncPageable<DiagnosticSettingsCategoryResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Checks whether a diagnostic settings category exists. </summary>
        /// <param name="name"> The diagnostic settings category name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> Whether the diagnostic settings category exists. </returns>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Checks whether a diagnostic settings category exists. </summary>
        /// <param name="name"> The diagnostic settings category name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> Whether the diagnostic settings category exists. </returns>
        public virtual Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Tries to get a diagnostic settings category. </summary>
        /// <param name="name"> The diagnostic settings category name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic settings category resource if it exists. </returns>
        public virtual NullableResponse<DiagnosticSettingsCategoryResource> GetIfExists(string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Tries to get a diagnostic settings category. </summary>
        /// <param name="name"> The diagnostic settings category name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic settings category resource if it exists. </returns>
        public virtual Task<NullableResponse<DiagnosticSettingsCategoryResource>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        IEnumerator<DiagnosticSettingsCategoryResource> IEnumerable<DiagnosticSettingsCategoryResource>.GetEnumerator() => throw new NotSupportedException("This API is no longer supported.");
        IAsyncEnumerator<DiagnosticSettingsCategoryResource> IAsyncEnumerable<DiagnosticSettingsCategoryResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => throw new NotSupportedException("This API is no longer supported.");
        IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException("This API is no longer supported.");
    }
}
