// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Collections.Generic;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

/// <summary>
/// Asynchronous counterpart of <see cref="NormalizingStreamingCollectionResult"/>. Re-dispatches
/// opaque Azure response items in each streaming update into their strongly-typed subtypes as the
/// stream is consumed.
/// </summary>
internal sealed class NormalizingAsyncStreamingCollectionResult : AsyncCollectionResult<StreamingResponseUpdate>
{
    private readonly AsyncCollectionResult<StreamingResponseUpdate> _innerResult;

    public NormalizingAsyncStreamingCollectionResult(AsyncCollectionResult<StreamingResponseUpdate> innerResult)
    {
        _innerResult = innerResult;
    }

    public override ContinuationToken GetContinuationToken(ClientResult page)
        // SSE streaming responses have no continuation token.
        => null;

#pragma warning disable CS1998 // async iterator with no await — intentional, mirrors the sync version
    public override async IAsyncEnumerable<ClientResult> GetRawPagesAsync()
    {
        // Yield a single sentinel page so GetValuesFromPageAsync is invoked exactly once and the
        // read-once SSE inner result is enumerated only from inside that call. See the equivalent
        // comment in TelemetryAsyncStreamingCollectionResult.
        yield return null;
    }
#pragma warning restore CS1998

    protected override async IAsyncEnumerable<StreamingResponseUpdate> GetValuesFromPageAsync(ClientResult page)
    {
        // The inner result owns its SSE parsing; the page parameter is intentionally unused.
        var enumerator = _innerResult.GetAsyncEnumerator();
        try
        {
            while (await enumerator.MoveNextAsync().ConfigureAwait(false))
            {
                yield return AzureAIExtensions.NormalizeStreamingUpdate(enumerator.Current);
            }
        }
        finally
        {
            await enumerator.DisposeAsync().ConfigureAwait(false);
        }
    }
}
