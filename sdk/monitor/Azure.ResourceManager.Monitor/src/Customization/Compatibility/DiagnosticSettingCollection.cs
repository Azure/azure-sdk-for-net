// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Azure;

namespace Azure.ResourceManager.Monitor
{
    public partial class DiagnosticSettingCollection : IEnumerable<DiagnosticSettingResource>, IAsyncEnumerable<DiagnosticSettingResource>
    {
        /// <summary> Gets all diagnostic settings for the specified resource. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of diagnostic settings. </returns>
        public virtual Pageable<DiagnosticSettingResource> GetAll(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets all diagnostic settings for the specified resource. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of diagnostic settings. </returns>
        public virtual AsyncPageable<DiagnosticSettingResource> GetAllAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <inheritdoc/>
        public IEnumerator<DiagnosticSettingResource> GetEnumerator()
            => GetAll().GetEnumerator();

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        /// <inheritdoc/>
        public IAsyncEnumerator<DiagnosticSettingResource> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            => GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
    }
}
