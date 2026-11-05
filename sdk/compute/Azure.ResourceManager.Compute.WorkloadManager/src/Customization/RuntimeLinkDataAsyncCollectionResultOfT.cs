// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;
using Azure.ResourceManager.Compute.WorkloadManager.Models;

namespace Azure.ResourceManager.Compute.WorkloadManager
{
    // Remove after https://github.com/Azure/azure-sdk-for-net/issues/63508 is fixed in the pinned generator.
    [CodeGenSuppress("AsPages", typeof(string), typeof(int?))]
    internal partial class RuntimeLinkDataAsyncCollectionResultOfT
    {
        public override IAsyncEnumerable<Page<RuntimeLinkData>> AsPages(string continuationToken, int? pageSizeHint)
            => CancellationAwarePageableHelpers.GetPagesAsync(
                _client.Pipeline,
                _client.ClientDiagnostics,
                _diagnosticScope,
                _context,
                nextLink => nextLink != null
                    ? _client.CreateNextGetByWorkloadSpaceRequest(nextLink, _subscriptionId, _resourceGroupName, _spaceName, _context)
                    : _client.CreateGetByWorkloadSpaceRequest(_subscriptionId, _resourceGroupName, _spaceName, _context),
                response =>
                {
                    var result = RuntimeLinkListResult.FromResponse(response);
                    return ((IReadOnlyList<RuntimeLinkData>)result.Value, result.NextLink);
                },
                continuationToken,
                _context?.CancellationToken ?? default);
    }
}
