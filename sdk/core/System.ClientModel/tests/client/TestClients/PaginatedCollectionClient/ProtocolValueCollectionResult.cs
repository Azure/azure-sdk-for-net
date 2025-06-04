// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;

namespace ClientModel.Tests.Collections;

/// <summary>
/// Protocol-layer paginated collection
/// </summary>
internal class ProtocolValueCollectionResult : CollectionResult
{
    private readonly IEnumerable<ValueItemPage> _mockPagesData;

    private readonly int? _pageSize;
    private readonly int? _offset;
    private readonly RequestOptions? _options;
    private readonly CancellationToken _cancellationToken;

    public ProtocolValueCollectionResult(int? pageSize, int? offset, RequestOptions? options)
    {
        _pageSize = pageSize;
        _offset = offset;
        _options = options;
        _cancellationToken = _options?.CancellationToken ?? default;

        _mockPagesData = MockPageResponseData.GetPages(pageSize, offset);
    }

    public override ContinuationToken? GetContinuationToken(ClientResult page)
        => ValueCollectionPageToken.FromResponse(page, _pageSize);

    public override IEnumerable<ClientResult> GetRawPages()
    {
        foreach (ValueItemPage page in _mockPagesData)
        {
            // Simulate the pipeline checking for cancellation,
            // which happens in the transport
            _cancellationToken.ThrowIfCancellationRequested();

            PipelineResponse response = new MockPageResponse(page);
            yield return ClientResult.FromResponse(response);
        }
    }
}
