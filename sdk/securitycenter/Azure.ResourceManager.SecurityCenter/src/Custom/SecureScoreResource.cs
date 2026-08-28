// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // The current TypeSpec renamed, nested, or removed these legacy model members, so generation omits the GA constructor/property shape; reintroduce the source-compatible member in this partial.
    // The current TypeSpec emits the expand query as the regenerated request shape, but GA exposed overloads with the strongly typed SecurityScoreODataExpand value; keep those overloads and forward to the generated implementation.
    public partial class SecureScoreResource
    {
        /// <summary> Get all security controls for a specific initiative within a scope. </summary>
        /// <param name="expand"> OData expand. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecureScoreControlDetails"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecureScoreControlDetails> GetSecureScoreControlsAsync(SecurityScoreODataExpand? expand = default, CancellationToken cancellationToken = default)
            => GetBySecureScoreAsync(expand?.ToString(), cancellationToken);

        /// <summary> Get all security controls for a specific initiative within a scope. </summary>
        /// <param name="expand"> OData expand. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecureScoreControlDetails"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecureScoreControlDetails> GetSecureScoreControls(SecurityScoreODataExpand? expand = default, CancellationToken cancellationToken = default)
            => GetBySecureScore(expand?.ToString(), cancellationToken);
    }
}
