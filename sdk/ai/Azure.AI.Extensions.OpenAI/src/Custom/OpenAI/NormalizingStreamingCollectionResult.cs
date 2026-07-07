// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Collections.Generic;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

/// <summary>
/// Decorates a streaming response collection, re-dispatching opaque Azure response items in each
/// update into their strongly-typed subtypes as the stream is consumed. Temporary client-side
/// bridge for the streaming path, matching the non-streaming behavior of
/// <see cref="AzureAIExtensions.NormalizeAgentOutputItems(ResponseResult)"/>.
/// </summary>
internal sealed class NormalizingStreamingCollectionResult : CollectionResult<StreamingResponseUpdate>
{
    private readonly CollectionResult<StreamingResponseUpdate> _innerResult;

    public NormalizingStreamingCollectionResult(CollectionResult<StreamingResponseUpdate> innerResult)
    {
        _innerResult = innerResult;
    }

    public override ContinuationToken GetContinuationToken(ClientResult page)
        // SSE streaming responses have no continuation token.
        => null;

    public override IEnumerable<ClientResult> GetRawPages()
    {
        // Yield a single sentinel page so GetValuesFromPage is invoked exactly once and the
        // read-once SSE inner result is enumerated only from inside that call. See the equivalent
        // comment in TelemetryStreamingCollectionResult.
        yield return null;
    }

    protected override IEnumerable<StreamingResponseUpdate> GetValuesFromPage(ClientResult page)
    {
        // The inner result owns its SSE parsing; the page parameter is intentionally unused.
        foreach (var value in _innerResult)
        {
            yield return AzureAIExtensions.NormalizeStreamingUpdate(value);
        }
    }
}
