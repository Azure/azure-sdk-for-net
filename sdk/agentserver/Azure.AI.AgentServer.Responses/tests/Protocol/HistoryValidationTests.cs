// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for eager history validation.
/// When previous_response_id or conversation.id are provided, GetHistoryItemIdsAsync
/// must be called before the handler runs. If the provider rejects the reference
/// (e.g., 404 for unknown previous_response_id), the error must surface to the client
/// without invoking the handler.
/// </summary>
public class HistoryValidationTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly ValidatingProvider _provider;
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public HistoryValidationTests()
    {
        _provider = new ValidatingProvider();

        _factory = new TestWebApplicationFactory(
            _handler,
            configureTestServices: services =>
            {
                services.AddSingleton<ResponsesProvider>(_provider);
            });
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task Post_InvalidPreviousResponseId_Returns404_HandlerNotInvoked()
    {
        // Use a well-formatted ID that passes schema validation but doesn't exist in storage
        var fakeId = IdGenerator.NewResponseId("");
        _provider.InvalidPreviousResponseIds.Add(fakeId);

        var body = JsonSerializer.Serialize(new
        {
            model = "test",
            previous_response_id = fakeId
        });

        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        Assert.That(_handler.CallCount, Is.EqualTo(0),
            "Handler must not be invoked when previous_response_id is invalid");
    }

    [Test]
    public async Task Post_InvalidConversationId_Returns400_HandlerNotInvoked()
    {
        _provider.InvalidConversationIds.Add("conv_does_not_exist");

        var body = JsonSerializer.Serialize(new
        {
            model = "test",
            conversation = new { id = "conv_does_not_exist" }
        });

        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(_handler.CallCount, Is.EqualTo(0),
            "Handler must not be invoked when conversation_id is invalid");
    }

    [Test]
    public async Task Post_ValidPreviousResponseId_HandlerInvoked()
    {
        // Create a response first so previous_response_id is valid
        var createBody = JsonSerializer.Serialize(new { model = "test" });
        var createResponse = await _client.PostAsync("/responses",
            new StringContent(createBody, Encoding.UTF8, "application/json"));
        Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var createDoc = JsonDocument.Parse(await createResponse.Content.ReadAsStringAsync());
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        // Use it as previous_response_id — should succeed
        var body = JsonSerializer.Serialize(new
        {
            model = "test",
            previous_response_id = responseId
        });

        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(_handler.CallCount, Is.EqualTo(2)); // first create + second with previous
    }

    [Test]
    public async Task Post_InvalidPreviousResponseId_Background_Returns404()
    {
        var fakeId = IdGenerator.NewResponseId("");
        _provider.InvalidPreviousResponseIds.Add(fakeId);

        var body = JsonSerializer.Serialize(new
        {
            model = "test",
            previous_response_id = fakeId,
            background = true
        });

        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        Assert.That(_handler.CallCount, Is.EqualTo(0));
    }

    [Test]
    public async Task Post_InvalidPreviousResponseId_Streaming_Returns404()
    {
        var fakeId = IdGenerator.NewResponseId("");
        _provider.InvalidPreviousResponseIds.Add(fakeId);

        var body = JsonSerializer.Serialize(new
        {
            model = "test",
            previous_response_id = fakeId,
            stream = true
        });

        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        Assert.That(_handler.CallCount, Is.EqualTo(0));
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    // ── Validating provider ─────────────────────────────────────

    /// <summary>
    /// Provider that throws ResourceNotFoundException for configured invalid previous response IDs
    /// and BadRequestException for configured invalid conversation IDs, simulating Foundry
    /// storage's validation behaviour.
    /// </summary>
    private sealed class ValidatingProvider : ResponsesProvider
    {
        private readonly InMemoryResponsesProvider _inner = new(
            Options.Create(new InMemoryProviderOptions()), TimeProvider.System);

        public HashSet<string> InvalidPreviousResponseIds { get; } = new();
        public HashSet<string> InvalidConversationIds { get; } = new();

        public override Task CreateResponseAsync(CreateResponseRequest request, IsolationContext isolation, CancellationToken cancellationToken = default)
            => _inner.CreateResponseAsync(request, isolation, cancellationToken);

        public override Task<ResponseObject> GetResponseAsync(string responseId, IsolationContext isolation, CancellationToken cancellationToken = default)
            => _inner.GetResponseAsync(responseId, isolation, cancellationToken);

        public override Task UpdateResponseAsync(ResponseObject response, IsolationContext isolation, CancellationToken cancellationToken = default)
            => _inner.UpdateResponseAsync(response, isolation, cancellationToken);

        public override Task DeleteResponseAsync(string responseId, IsolationContext isolation, CancellationToken cancellationToken = default)
            => _inner.DeleteResponseAsync(responseId, isolation, cancellationToken);

        public override Task<AgentsPagedResultOutputItem> GetInputItemsAsync(string responseId, IsolationContext isolation, int limit = 20, bool ascending = false, string? after = null, string? before = null, CancellationToken cancellationToken = default)
            => _inner.GetInputItemsAsync(responseId, isolation, limit, ascending, after, before, cancellationToken);

        public override Task<IEnumerable<OutputItem?>> GetItemsAsync(IEnumerable<string> itemIds, IsolationContext isolation, CancellationToken cancellationToken = default)
            => _inner.GetItemsAsync(itemIds, isolation, cancellationToken);

        public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(
            string? previousResponseId,
            string? conversationId,
            int limit,
            IsolationContext isolation,
            CancellationToken cancellationToken = default)
        {
            if (previousResponseId is not null && InvalidPreviousResponseIds.Contains(previousResponseId))
            {
                throw new ResourceNotFoundException(
                    $"Response '{previousResponseId}' not found.");
            }

            if (conversationId is not null && InvalidConversationIds.Contains(conversationId))
            {
                throw new BadRequestException(
                    $"Conversation '{conversationId}' not found.");
            }

            return _inner.GetHistoryItemIdsAsync(previousResponseId, conversationId, limit, isolation, cancellationToken);
        }
    }
}
