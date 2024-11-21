// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.Tests.Collections;

internal class AsyncProtocolValueCollectionResult : AsyncCollectionResult
{
    private readonly IEnumerable<ValueItemPage> _mockPagesData;

    private readonly int? _pageSize;
    private readonly int? _offset;
    private readonly RequestOptions? _options;
    private readonly CancellationToken _cancellationToken;

    public AsyncProtocolValueCollectionResult(int? pageSize, int? offset, RequestOptions? options)
    {
        _pageSize = pageSize;
        _offset = offset;
        _options = options;
        _cancellationToken = _options?.CancellationToken ?? default;

        _mockPagesData = MockPageResponseData.GetPages(pageSize, offset);
    }

    public override ContinuationToken? GetContinuationToken(ClientResult page)
        => ValueCollectionPageToken.FromResponse(page, _pageSize);

    public override async IAsyncEnumerable<ClientResult> GetRawPagesAsync()
    {
        foreach (ValueItemPage page in _mockPagesData)
        {
            await Task.Delay(0, _cancellationToken).ConfigureAwait(false);

            PipelineResponse response = new MockPageResponse(page);
            yield return ClientResult.FromResponse(response);
        }
    }
}
