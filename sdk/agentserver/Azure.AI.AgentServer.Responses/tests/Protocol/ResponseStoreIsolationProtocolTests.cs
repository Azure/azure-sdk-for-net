// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

[TestFixture(false)]
[TestFixture(true)]
public class ResponseStoreIsolationProtocolTests
{
    private readonly bool _fileBacked;
    private string _directory = null!;
    private ResponsesProvider _provider = null!;
    private TestWebApplicationFactory _factory = null!;
    private HttpClient _client = null!;
    private readonly TestHandler _handler = new();
    private IReadOnlyList<Item> _resolvedInput = Array.Empty<Item>();
    private IReadOnlyList<OutputItem> _resolvedHistory = Array.Empty<OutputItem>();

    public ResponseStoreIsolationProtocolTests(bool fileBacked) => _fileBacked = fileBacked;

    [SetUp]
    public void SetUp()
    {
        _directory = Path.Combine(TestContext.CurrentContext.WorkDirectory, "response-protocol-" + Guid.NewGuid().ToString("N"));
        _provider = _fileBacked
            ? new FileResponsesProvider(_directory)
            : new InMemoryResponsesProvider(Options.Create(new InMemoryProviderOptions()), TimeProvider.System);
        _handler.EventFactory = (_, context, ct) => CaptureInputs(context, ct);
        _factory = new TestWebApplicationFactory(_handler,
            configureTestServices: services => services.AddSingleton(_provider));
        _client = _factory.CreateClient();
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
        (_provider as IDisposable)?.Dispose();
        if (Directory.Exists(_directory))
        {
            Directory.Delete(_directory, recursive: true);
        }
    }

    [TestCase("user-a", "user-b", "reference")]
    [TestCase("user-a", "user-b", "previous")]
    [TestCase("user-a", "user-b", "conversation")]
    [TestCase(null, "user-b", "reference")]
    [TestCase(null, "user-b", "previous")]
    [TestCase(null, "user-b", "conversation")]
    [TestCase("user-a", null, "reference")]
    [TestCase("user-a", null, "previous")]
    [TestCase("user-a", null, "conversation")]
    public async Task New_Response_Resolves_Only_Its_Callers_Stored_Content(string? owner, string? other, string source)
    {
        using var created = await SendAsync(HttpMethod.Post, "/responses", owner, new
        {
            model = "test",
            input = "owner input",
            conversation = "conv_isolation",
        });
        Assert.That(created.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var original = await created.Content.ReadFromJsonAsync<JsonElement>();
        var responseId = original.GetProperty("id").GetString()!;
        var itemId = original.GetProperty("output")[0].GetProperty("id").GetString()!;

        foreach (var path in new[] { $"/responses/{responseId}", $"/responses/{responseId}/input_items" })
        {
            using var denied = await SendAsync(HttpMethod.Get, path, other);
            Assert.That(denied.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        using (var denied = await SendAsync(HttpMethod.Delete, $"/responses/{responseId}", other))
        {
            Assert.That(denied.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        var body = new Dictionary<string, object> { ["model"] = "test" };
        switch (source)
        {
            case "reference":
                body["input"] = new[] { new { type = "item_reference", id = itemId } };
                break;
            case "previous":
                body["previous_response_id"] = responseId;
                break;
            default:
                body["conversation"] = "conv_isolation";
                break;
        }

        using var foreign = await SendAsync(HttpMethod.Post, "/responses", other, body);
        Assert.That(foreign.StatusCode, Is.EqualTo(HttpStatusCode.OK), await foreign.Content.ReadAsStringAsync());
        Assert.That(_resolvedInput, Is.Empty);
        Assert.That(_resolvedHistory, Is.Empty);
        var foreignObject = await foreign.Content.ReadFromJsonAsync<JsonElement>();
        using var inputPage = await SendAsync(HttpMethod.Get,
            $"/responses/{foreignObject.GetProperty("id").GetString()}/input_items", other);
        var page = await inputPage.Content.ReadFromJsonAsync<JsonElement>();
        Assert.That(page.GetProperty("data").GetArrayLength(), Is.Zero);

        using var own = await SendAsync(HttpMethod.Post, "/responses", owner, body);
        Assert.That(own.StatusCode, Is.EqualTo(HttpStatusCode.OK), await own.Content.ReadAsStringAsync());
        Assert.That(source == "reference" ? _resolvedInput.Count : _resolvedHistory.Count, Is.GreaterThan(0));
    }

    private async IAsyncEnumerable<ResponseStreamEvent> CaptureInputs(
        ResponseContext context, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        _resolvedInput = await context.GetInputItemsAsync(cancellationToken: cancellationToken);
        _resolvedHistory = await context.GetHistoryAsync(cancellationToken: cancellationToken);
        yield return new ResponseCreatedEvent(0, new ResponseObject(context.ResponseId, "test"));
        var message = new OutputItemMessage($"msg_{Guid.NewGuid():N}", MessageStatus.Completed,
            new MessageContent[]
            {
                new MessageContentOutputTextContent("owned output", Array.Empty<Annotation>(), Array.Empty<LogProb>()),
            });
        yield return new ResponseOutputItemAddedEvent(0, 0, message);
        yield return new ResponseOutputItemDoneEvent(0, 0, message);
        var completed = new ResponseObject(context.ResponseId, "test");
        completed.Output.Add(message);
        completed.SetCompleted();
        yield return new ResponseCompletedEvent(0, completed);
    }

    [TestCase(null, "user-b")]
    [TestCase("user-a", null)]
    [TestCase("user-a", "user-b")]
    public async Task Active_Background_Response_Enforces_The_Same_User_Boundary(string? owner, string? other)
    {
        var release = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var finished = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var handlerCancellation = CancellationToken.None;
        _handler.EventFactory = (_, context, ct) => WaitingResponse(context, ct);

        async IAsyncEnumerable<ResponseStreamEvent> WaitingResponse(
            ResponseContext context, [EnumeratorCancellation] CancellationToken ct)
        {
            handlerCancellation = ct;
            var response = new ResponseObject(context.ResponseId, "test");
            yield return new ResponseCreatedEvent(0, response);
            try
            {
                await release.Task.WaitAsync(ct);
                response.SetCompleted();
                yield return new ResponseCompletedEvent(0, response);
            }
            finally
            {
                finished.TrySetResult();
            }
        }

        try
        {
            using var created = await SendAsync(HttpMethod.Post, "/responses", owner,
                new { model = "test", background = true, stream = false });
            Assert.That(created.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var body = await created.Content.ReadFromJsonAsync<JsonElement>();
            var id = body.GetProperty("id").GetString()!;
            foreach (var (method, path) in new[]
            {
                (HttpMethod.Get, $"/responses/{id}"),
                (HttpMethod.Get, $"/responses/{id}/input_items"),
                (HttpMethod.Delete, $"/responses/{id}"),
                (HttpMethod.Post, $"/responses/{id}/cancel"),
            })
            {
                using var denied = await SendAsync(method, path, other);
                Assert.That(denied.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            }
            Assert.That(handlerCancellation.IsCancellationRequested, Is.False);
            using var own = await SendAsync(HttpMethod.Get, $"/responses/{id}", owner);
            Assert.That(own.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        finally
        {
            release.TrySetResult();
            await finished.Task.WaitAsync(TimeSpan.FromSeconds(10));
        }
    }

    private Task<HttpResponseMessage> SendAsync(HttpMethod method, string path, string? user, object? body = null)
    {
        var request = new HttpRequestMessage(method, path);
        if (user is not null)
        {
            request.Headers.Add(PlatformHeaders.UserId, user);
        }
        if (body is not null)
        {
            request.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        }
        return _client.SendAsync(request);
    }
}
