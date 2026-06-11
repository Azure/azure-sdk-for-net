// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecureScoreResource
    {
        // TypeSpec generates the action as GetBySecureScore with ExpandControlsEnum. The GA SDK
        // exposed GetSecureScoreControls with SecurityScoreODataExpand.
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
