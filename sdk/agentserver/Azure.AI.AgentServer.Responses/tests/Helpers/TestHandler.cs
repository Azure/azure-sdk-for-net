// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Helpers;

/// <summary>
/// A configurable <see cref="ResponseHandler"/> for testing.
/// Set <see cref="EventFactory"/> to control what events are yielded.
/// </summary>
public sealed class TestHandler : ResponseHandler
{
    /// <summary>
    /// Factory function that produces the event stream.
    /// Default: yields response.created → response.completed.
    /// </summary>
    public Func<CreateResponse, ResponseContext, CancellationToken, IAsyncEnumerable<ResponseStreamEvent>>?
        EventFactory
    { get; set; }

    /// <summary>
    /// Gets the last request received by the handler.
    /// </summary>
    public CreateResponse? LastRequest { get; private set; }

    /// <summary>
    /// Gets the last context received by the handler.
    /// </summary>
    public ResponseContext? LastContext { get; private set; }

    /// <summary>
    /// Gets the number of times CreateAsync was called.
    /// </summary>
    public int CallCount { get; private set; }

    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        LastRequest = request;
        LastContext = context;
        CallCount++;

        if (EventFactory is not null)
        {
            await foreach (var evt in EventFactory(request, context, cancellationToken)
                .WithCancellation(cancellationToken))
            {
                yield return evt;
            }

            yield break;
        }

        // Default: simple lifecycle
        var response = new Models.ResponseObject(context.ResponseId, request.Model ?? "test-model");
        yield return new ResponseCreatedEvent(0, response);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }
}
