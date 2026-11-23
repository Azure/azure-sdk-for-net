// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using NUnit.Framework;

#pragma warning disable AAAS005 // Test the experimental attribution contract.

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

public class OriginalSubjectProtocolTests
{
    [Test]
    public async Task QueuedNonStreamingTurnDoesNotInheritPreviousSubject()
    {
        var firstEntered = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseFirst = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var secondObserved = new TaskCompletionSource<(string?, string?)>(TaskCreationOptions.RunContinuationsAsynchronously);
        var handler = new TestHandler { EventFactory = (_, context, ct) => Events(context, ct) };
        using var factory = new TestWebApplicationFactory(handler, configureOptions: options =>
        {
            options.ResilientBackground = true;
            options.SteerableConversations = true;
        });
        using var client = factory.CreateClient();
        string conversation = "subject-" + Guid.NewGuid().ToString("N");

        async IAsyncEnumerable<ResponseStreamEvent> Events(
            ResponseContext context, [EnumeratorCancellation] CancellationToken ct)
        {
            var response = new ResponseObject { Id = context.ResponseId, Model = "test" };
            if (context.IsSteeredTurn)
            {
                secondObserved.TrySetResult((context.PlatformContext.OriginalSubject?.ObjectId,
                    FoundryAgentRequestContext.Current.OriginalSubject?.ObjectId));
            }
            yield return new ResponseCreatedEvent { SequenceNumber = 0, Response = response };
            if (!context.IsSteeredTurn)
            {
                firstEntered.TrySetResult();
                await releaseFirst.Task;
            }
            response.SetCompleted();
            yield return new ResponseCompletedEvent { SequenceNumber = 1, Response = response };
        }

        async Task<HttpResponseMessage> SendAsync(string subject)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
            {
                Content = new StringContent(
                    JsonSerializer.Serialize(new { model = "test", background = true, conversation }),
                    Encoding.UTF8, "application/json"),
            };
            request.Headers.TryAddWithoutValidation("x-ms-original-subject",
                $"oid=\"{subject}\", tid=\"tenant\", idtype=\"user\"");
            return await client.SendAsync(request);
        }

        try
        {
            using var first = await SendAsync("first");
            Assert.That(first.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            await firstEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));
            using var second = await SendAsync("second");
            Assert.That(second.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using var result = JsonDocument.Parse(await second.Content.ReadAsStringAsync());
            Assert.That(result.RootElement.GetProperty("status").GetString(), Is.EqualTo("queued"));
            releaseFirst.TrySetResult();
            var observed = await secondObserved.Task.WaitAsync(TimeSpan.FromSeconds(10));
            Assert.That(observed.Item1, Is.Null);
            Assert.That(observed.Item2, Is.Null);
        }
        finally
        {
            releaseFirst.TrySetResult();
        }
    }

    [TestCase(false, false)]
    [TestCase(true, false)]
    [TestCase(false, true)]
    [TestCase(true, true)]
    public async Task HandlerKeepsPerRequestSubjectAcrossStreamingAndTaskExecution(bool stream, bool resilient)
    {
        var observed = new ConcurrentDictionary<string, ConcurrentQueue<string>>();
        var completed = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        int checks = 0;
        var handler = new TestHandler();
        handler.EventFactory = (_, context, ct) => Events(context, ct);
        using var factory = new TestWebApplicationFactory(
            handler,
            configureOptions: options => options.ResilientBackground = resilient);
        using var client = factory.CreateClient();

        async IAsyncEnumerable<ResponseStreamEvent> Events(
            ResponseContext context, [EnumeratorCancellation] CancellationToken ct)
        {
            string key = context.PlatformContext.OriginalSubject?.ObjectId ?? "none";
            void Record()
            {
                string actual = FoundryAgentRequestContext.Current.OriginalSubject?.ObjectId ?? "none";
                observed.GetOrAdd(key, _ => new ConcurrentQueue<string>()).Enqueue(actual);
                if (Interlocked.Increment(ref checks) == 6)
                {
                    completed.TrySetResult();
                }
            }

            Record();
            await Task.Delay(20, ct);
            var response = new ResponseObject { Id = context.ResponseId, Model = "test" };
            yield return new ResponseCreatedEvent { SequenceNumber = 0, Response = response };
            await Task.Delay(20, ct);
            Record();
            response.SetCompleted();
            yield return new ResponseCompletedEvent { SequenceNumber = 1, Response = response };
        }

        async Task SendAsync(string? subject)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
            {
                Content = new StringContent(
                    $"{{\"model\":\"test\",\"stream\":{stream.ToString().ToLowerInvariant()},\"store\":true}}",
                    Encoding.UTF8, "application/json"),
            };
            if (subject is not null)
            {
                request.Headers.TryAddWithoutValidation(
                    "x-ms-original-subject", $"oid=\"{subject}\", tid=\"tenant\", idtype=\"user\"");
            }
            using var response = await client.SendAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            await response.Content.ReadAsStringAsync();
        }

        await Task.WhenAll(SendAsync("one"), SendAsync("two"), SendAsync(null));
        await completed.Task.WaitAsync(TimeSpan.FromSeconds(10));
        Assert.That(observed["one"], Is.EqualTo(new[] { "one", "one" }));
        Assert.That(observed["two"], Is.EqualTo(new[] { "two", "two" }));
        Assert.That(observed["none"], Is.EqualTo(new[] { "none", "none" }));
        Assert.That(FoundryAgentRequestContext.Current.OriginalSubject, Is.Null);
    }
}
