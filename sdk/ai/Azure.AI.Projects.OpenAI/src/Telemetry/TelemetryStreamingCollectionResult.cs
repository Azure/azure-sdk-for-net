// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Telemetry;

internal sealed class TelemetryStreamingCollectionResult : CollectionResult<StreamingResponseUpdate>
{
    private readonly CollectionResult<StreamingResponseUpdate> _innerResult;
    private readonly StreamingTelemetryContext _telemetryContext;
    private OpenTelemetryResponseScope _scope;

    public TelemetryStreamingCollectionResult(
        CollectionResult<StreamingResponseUpdate> innerResult,
        StreamingTelemetryContext telemetryContext)
    {
        _innerResult = innerResult;
        _telemetryContext = telemetryContext;
    }

    public override ContinuationToken GetContinuationToken(ClientResult page)
        // SSE streaming responses have no continuation token.
        => null;

    public override IEnumerable<ClientResult> GetRawPages()
    {
        // We yield a single sentinel page rather than delegating to _innerResult.GetRawPages().
        // Any caller that drives GetRawPages and GetValuesFromPage as two separate steps —
        // including the base-class GetEnumerator — would otherwise trigger two independent
        // enumerations of _innerResult. For an SSE stream that can only be read once, the
        // second enumeration hangs. The sentinel ensures GetValuesFromPage is called exactly
        // once and the inner result is only opened from inside that single call.
        yield return null;
    }

    protected override IEnumerable<StreamingResponseUpdate> GetValuesFromPage(ClientResult page)
    {
        // We enumerate _innerResult directly rather than using the page parameter.
        // The inner result owns its SSE parsing; the page parameter is intentionally unused.
        if (_scope == null)
        {
            _scope = _telemetryContext.CreateScope();
        }

        foreach (var value in _innerResult)
        {
            _scope?.RecordStreamingUpdate(value);
            yield return value;
        }

        _scope?.Dispose();
        _scope = null;
    }
}
