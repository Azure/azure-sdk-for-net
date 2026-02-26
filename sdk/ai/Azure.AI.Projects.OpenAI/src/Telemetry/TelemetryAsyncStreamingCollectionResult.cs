// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Telemetry;

internal sealed class TelemetryAsyncStreamingCollectionResult : AsyncCollectionResult<StreamingResponseUpdate>
{
    private readonly AsyncCollectionResult<StreamingResponseUpdate> _innerResult;
    private readonly StreamingTelemetryContext _telemetryContext;
    private OpenTelemetryResponseScope _scope;

    public TelemetryAsyncStreamingCollectionResult(
        AsyncCollectionResult<StreamingResponseUpdate> innerResult,
        StreamingTelemetryContext telemetryContext)
    {
        _innerResult = innerResult;
        _telemetryContext = telemetryContext;
    }

    public override ContinuationToken GetContinuationToken(ClientResult page)
        // SSE streaming responses have no continuation token.
        => null;

#pragma warning disable CS1998 // async iterator with no await — intentional, mirrors the sync version
    public override async IAsyncEnumerable<ClientResult> GetRawPagesAsync()
    {
        // We yield a single sentinel page rather than delegating to _innerResult.GetRawPagesAsync().
        // Any caller that drives GetRawPagesAsync and GetValuesFromPageAsync as two separate steps —
        // including the base-class GetAsyncEnumerator — would otherwise trigger two independent
        // enumerations of _innerResult. For an SSE stream that can only be read once, the
        // second enumeration hangs. The sentinel ensures GetValuesFromPageAsync is called exactly
        // once and the inner result is only opened from inside that single call.
        yield return null;
    }
#pragma warning restore CS1998

    protected override async IAsyncEnumerable<StreamingResponseUpdate> GetValuesFromPageAsync(
        ClientResult page)
    {
        // We enumerate _innerResult directly rather than using the page parameter.
        // The inner result owns its SSE parsing; the page parameter is intentionally unused.
        if (_scope == null)
        {
            _scope = _telemetryContext.CreateScope();
        }

        var enumerator = _innerResult.GetAsyncEnumerator();
        try
        {
            while (await enumerator.MoveNextAsync().ConfigureAwait(false))
            {
                _scope?.RecordStreamingUpdate(enumerator.Current);
                yield return enumerator.Current;
            }
        }
        finally
        {
            await enumerator.DisposeAsync().ConfigureAwait(false);
        }

        _scope?.Dispose();
        _scope = null;
    }
}
