// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net.ServerSentEvents;
using System.Text.Json;
using System.Threading;
using OpenAI;
using OpenAI.Responses;

#nullable enable

namespace Azure.AI.Projects.OpenAI;

/// <summary>
/// A synchronous <see cref="CollectionResult{StreamingResponseUpdate}"/> implementation that parses
/// server-sent events from an unbuffered HTTP response.
/// </summary>
internal sealed class ProjectSseCollectionResult : CollectionResult<StreamingResponseUpdate>
{
    private static ReadOnlySpan<byte> TerminalData => "[DONE]"u8;

    private readonly Func<ClientResult> _sendRequest;
    private readonly CancellationToken _cancellationToken;

    public ProjectSseCollectionResult(Func<ClientResult> sendRequest, CancellationToken cancellationToken)
    {
        Argument.AssertNotNull(sendRequest, nameof(sendRequest));
        _sendRequest = sendRequest;
        _cancellationToken = cancellationToken;
    }

    public override ContinuationToken? GetContinuationToken(ClientResult page) => null;

    public override IEnumerable<ClientResult> GetRawPages()
    {
        yield return _sendRequest();
    }

    protected override IEnumerable<StreamingResponseUpdate> GetValuesFromPage(ClientResult page)
    {
        PipelineResponse response = page.GetRawResponse();
        if (response.ContentStream is null)
        {
            yield break;
        }

        IEnumerable<SseItem<byte[]>> sseEvents = SseParser.Create(
            response.ContentStream,
            (_, bytes) => bytes.ToArray()).Enumerate();

        foreach (SseItem<byte[]> sseEvent in sseEvents)
        {
            _cancellationToken.ThrowIfCancellationRequested();

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
