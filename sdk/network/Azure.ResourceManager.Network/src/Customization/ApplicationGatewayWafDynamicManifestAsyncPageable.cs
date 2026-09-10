// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Network
{
    internal sealed class ApplicationGatewayWafDynamicManifestAsyncPageable : AsyncPageable<ApplicationGatewayWafDynamicManifestResource>
    {
        private readonly Func<CancellationToken, Task<Response<ApplicationGatewayWafDynamicManifestResource>>> _getAsync;

        /// <summary> Initializes a new instance of the ApplicationGatewayWafDynamicManifestAsyncPageable class. </summary>
        public ApplicationGatewayWafDynamicManifestAsyncPageable(Func<CancellationToken, Task<Response<ApplicationGatewayWafDynamicManifestResource>>> getAsync, CancellationToken cancellationToken)
            : base(cancellationToken)
        {
            _getAsync = getAsync;
        }

        /// <summary> Invokes the AsPages compatibility operation. </summary>
        public override async IAsyncEnumerable<Page<ApplicationGatewayWafDynamicManifestResource>> AsPages(string continuationToken = default, int? pageSizeHint = default)
        {
            if (continuationToken is not null)
            {
                yield break;
            }

            Response<ApplicationGatewayWafDynamicManifestResource> response = await _getAsync(CancellationToken).ConfigureAwait(false);
            yield return Page<ApplicationGatewayWafDynamicManifestResource>.FromValues(new[] { response.Value }, default, response.GetRawResponse());
        }
    }
}
