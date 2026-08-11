// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.E2E.ResilienceContract;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Recovered-input parity (US1 / T016). A re-invoked handler must observe the same request-scoped
/// inputs it would have seen on the original invocation: the original <see cref="CreateResponse"/>
/// request (model/background/store/stream + input items), the client headers, and the query
/// parameters — all reconstructed from the durable recovery payload. This locks in that recovery is
/// a faithful replay of the accepted invocation, not a lossy restart.
/// </summary>
[NonParallelizable]
public sealed class RecoveryContextParityProtocolTests : CrashRecoveryE2ETestBase
{
    [Test]
    public async Task RecoveredHandler_ObservesRequestHeadersQueryAndInputParity()
    {
        var responseId = IdGenerator.NewResponseId();
        await SeedDurableEnvelopeAsync(responseId);

        var headers = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase)
        {
            ["x-custom-header"] = "header-value",
            ["x-trace-id"] = "trace-123",
        };
        var query = new Dictionary<string, string>(System.StringComparer.Ordinal)
        {
            ["foo"] = "bar",
            ["mode"] = "resilient",
        };

        var request = new CreateResponse
        {
            Model = "test-model",
            Background = true,
            Store = true,
            Stream = false,
            Input = BinaryData.FromObjectAsJson("recover this input"),
        };

        await SeedInterruptedTaskAsync(new ResponseRecoveryPayload(
            responseId: responseId,
            disposition: ResponseRecoveryPayload.DispositionReinvoke,
            request: request,
            clientHeaders: headers,
            queryParameters: query));

        var observed = new TaskCompletionSource();
        string? observedInputText = null;
        CreateResponse? observedRequest = null;
        IReadOnlyDictionary<string, string>? observedHeaders = null;
        string? observedFoo = null;
        string? observedFooUpper = null;
        string? observedMode = null;

        var handler = new TestHandler
        {
            EventFactory = (req, ctx, ct) =>
            {
                observedRequest = req;
                observedHeaders = ctx.ClientHeaders;
                observedFoo = ctx.QueryParameters.TryGetValue("foo", out var f) ? f.ToString() : null;
                observedFooUpper = ctx.QueryParameters.TryGetValue("FOO", out var fu) ? fu.ToString() : null;
                observedMode = ctx.QueryParameters.TryGetValue("mode", out var m) ? m.ToString() : null;
                return CaptureInputThenComplete(ctx, observed, text => observedInputText = text, ct);
            },
        };

        using var factory = NewRecoveringHost(handler);
        using var client = factory.CreateClient();

        await observed.Task.WaitAsync(TimeSpan.FromSeconds(10));
        await WaitForStatusAsync(client, responseId, "completed");

        // Request parity.
        Assert.That(observedRequest, Is.Not.Null);
        Assert.That(observedRequest!.Model, Is.EqualTo("test-model"));
        Assert.That(observedRequest.Background, Is.True);
        Assert.That(observedRequest.Store, Is.True);

        // Header parity (case-insensitive keys preserved across the crash boundary — a handler that
        // reads with different casing than stored must still resolve, matching ingress semantics).
        Assert.That(observedHeaders, Is.Not.Null);
        Assert.That(observedHeaders!.TryGetValue("x-custom-header", out var hv) ? hv : null, Is.EqualTo("header-value"));
        Assert.That(observedHeaders.TryGetValue("x-trace-id", out var tv) ? tv : null, Is.EqualTo("trace-123"));
        Assert.That(observedHeaders.TryGetValue("X-Custom-Header", out var hvUpper) ? hvUpper : null,
            Is.EqualTo("header-value"), "recovered client headers must remain case-insensitive");

        // Query parity (case-insensitive lookup preserved across the crash boundary).
        Assert.That(observedFoo, Is.EqualTo("bar"));
        Assert.That(observedFooUpper, Is.EqualTo("bar"), "recovered query parameters must remain case-insensitive");
        Assert.That(observedMode, Is.EqualTo("resilient"));

        // Input-item parity.
        Assert.That(observedInputText, Is.EqualTo("recover this input"));
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> CaptureInputThenComplete(
        ResponseContext ctx,
        TaskCompletionSource signal,
        System.Action<string> captureInput,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
    {
        var text = await ctx.GetInputTextAsync(resolveReferences: true, ct).ConfigureAwait(false);
        captureInput(text);

        var response = new ResponseObject(ctx.ResponseId, "test-model");
        yield return new ResponseCreatedEvent(0, response);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
        signal.TrySetResult();
    }
}
