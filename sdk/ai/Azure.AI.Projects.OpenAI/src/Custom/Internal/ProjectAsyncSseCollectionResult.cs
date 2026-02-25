// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net.ServerSentEvents;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OpenAI;
using OpenAI.Responses;

#nullable enable

namespace Azure.AI.Projects.OpenAI;

/// <summary>
/// An asynchronous <see cref="AsyncCollectionResult{StreamingResponseUpdate}"/> implementation that parses
/// server-sent events from an unbuffered HTTP response.
/// </summary>
internal sealed class ProjectAsyncSseCollectionResult : AsyncCollectionResult<StreamingResponseUpdate>
{
    private static ReadOnlySpan<byte> TerminalData => "[DONE]"u8;

    private readonly Func<Task<ClientResult>> _sendRequestAsync;
    private readonly CancellationToken _cancellationToken;

    public ProjectAsyncSseCollectionResult(Func<Task<ClientResult>> sendRequestAsync, CancellationToken cancellationToken)
    {
        Argument.AssertNotNull(sendRequestAsync, nameof(sendRequestAsync));
        _sendRequestAsync = sendRequestAsync;
        _cancellationToken = cancellationToken;
    }

    public override ContinuationToken? GetContinuationToken(ClientResult page) => null;

    public override async IAsyncEnumerable<ClientResult> GetRawPagesAsync()
    {
        yield return await _sendRequestAsync().ConfigureAwait(false);
    }

    protected override async IAsyncEnumerable<StreamingResponseUpdate> GetValuesFromPageAsync(ClientResult page)
    {
        PipelineResponse response = page.GetRawResponse();
        if (response.ContentStream is null)
        {
            yield break;
        }

        IAsyncEnumerable<SseItem<byte[]>> sseEvents = SseParser.Create(
            response.ContentStream,
            (_, bytes) => bytes.ToArray()).EnumerateAsync();

        await foreach (SseItem<byte[]> sseEvent in sseEvents.WithCancellation(_cancellationToken).ConfigureAwait(false))
        {
            if (sseEvent.Data.AsSpan().SequenceEqual(TerminalData))
            {
                break;
            }

            using JsonDocument doc = JsonDocument.Parse(sseEvent.Data);
            StreamingResponseUpdate update = ModelReaderWriter.Read<StreamingResponseUpdate>(
                BinaryData.FromString(doc.RootElement.GetRawText()),
                ModelSerializationExtensions.WireOptions,
                OpenAIContext.Default)!;
            yield return update;
        }
    }
}
