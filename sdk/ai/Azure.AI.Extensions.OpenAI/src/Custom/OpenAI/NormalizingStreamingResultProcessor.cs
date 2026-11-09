// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Extensions.OpenAI.Telemetry;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

[Experimental("OPENAI001")]
internal sealed class NormalizingStreamingResultProcessor
{
    private readonly StreamingTelemetryContext _telemetryContext;
    public NormalizingStreamingResultProcessor(StreamingTelemetryContext telemetryContext)
    {
        _telemetryContext = telemetryContext;
    }

    public async IAsyncEnumerable<StreamingResponseUpdate> NormalizeUpdateAsync(
        IAsyncEnumerable<StreamingResponseUpdate> updates,
       [EnumeratorCancellation] CancellationToken cancellationToken
    )
    {
        using OpenTelemetryResponseScope scope =
            _telemetryContext?.CreateScope();

        await foreach (StreamingResponseUpdate update in updates.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            StreamingResponseUpdate fixedUpdate = AzureAIExtensions.NormalizeStreamingUpdate(update);
            scope?.RecordStreamingUpdate(fixedUpdate);
            yield return fixedUpdate;
        }
    }
}
