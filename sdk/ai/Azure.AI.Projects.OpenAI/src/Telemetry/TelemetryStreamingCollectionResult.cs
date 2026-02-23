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
        => _innerResult.GetContinuationToken(page);

    public override IEnumerable<ClientResult> GetRawPages()
        => _innerResult.GetRawPages();

    protected override IEnumerable<StreamingResponseUpdate> GetValuesFromPage(ClientResult page)
    {
        // Instead of parsing the page ourselves (which would require calling the
        // inner result's protected GetValuesFromPage via reflection), we enumerate
        // the inner result directly. The inner result handles its own page iteration
        // and SSE parsing internally. We just observe and record telemetry on the
        // values as they flow through.
        //
        // This works because streaming responses use a single page/response, so
        // GetValuesFromPage is called exactly once.
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
