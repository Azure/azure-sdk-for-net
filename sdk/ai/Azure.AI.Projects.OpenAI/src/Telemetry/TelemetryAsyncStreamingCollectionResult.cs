// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
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
        => _innerResult.GetContinuationToken(page);

    public override IAsyncEnumerable<ClientResult> GetRawPagesAsync()
        => _innerResult.GetRawPagesAsync();

    protected override async IAsyncEnumerable<StreamingResponseUpdate> GetValuesFromPageAsync(
        ClientResult page)
    {
        // SSE streaming responses consist of a single page (one HTTP response).
        // Instead of parsing the page ourselves (which would require calling the
        // inner result's protected GetValuesFromPageAsync), we enumerate the inner
        // result directly. The inner result handles its own page iteration and
        // SSE parsing internally. We just observe and record telemetry on the
        // values as they flow through.
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
