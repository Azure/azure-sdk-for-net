// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// T029–T033: Protocol tests for GET /responses/{id}/input_items endpoint (User Story 3).
/// Uses the real <c>InMemoryResponsesProvider</c> — no spy or test double.
/// </summary>
public class GetInputItemsProtocolTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public GetInputItemsProtocolTests()
    {
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();
    }

    /// <summary>
    /// T029: GET /responses/{id}/input_items returns 200 with AgentsPagedResultOutputItem
    /// for a response with stored input items.
    /// </summary>
    [Test]
    public async Task Get_InputItems_Returns_200_With_Items()
    {
        // Create a response with 3 input items via POST
        var responseId = await CreateResponseWithInputsAsync(3);

        // GET input_items
        var response = await _client.GetAsync($"/responses/{responseId}/input_items");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        var data = doc.RootElement.GetProperty("data");
        Assert.That(data.GetArrayLength(), Is.EqualTo(3));
        Assert.That(doc.RootElement.GetProperty("has_more").GetBoolean(), Is.False);
        Assert.That(doc.RootElement.GetProperty("object").GetString(), Is.EqualTo("list"),
            "Input items list must include 'object': 'list'");
    }

    /// <summary>
    /// T029 (cont): GET with no stored items returns 200 with empty data.
    /// </summary>
    [Test]
    public async Task Get_InputItems_Returns_200_With_Empty_Data()
    {
        var responseId = await CreateResponseAsync();

        var response = await _client.GetAsync($"/responses/{responseId}/input_items");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        var data = doc.RootElement.GetProperty("data");
        Assert.That(data.GetArrayLength(), Is.EqualTo(0));
        Assert.That(doc.RootElement.GetProperty("has_more").GetBoolean(), Is.False);
        Assert.That(doc.RootElement.GetProperty("object").GetString(), Is.EqualTo("list"),
            "Empty input items list must still include 'object': 'list'");
    }

    /// <summary>
    /// T030: GET /responses/{id}/input_items returns 404 for non-existent response.
    /// </summary>
    [Test]
    public async Task Get_InputItems_NonExistent_Response_Returns_404()
    {
        var response = await _client.GetAsync($"/responses/{IdGenerator.NewResponseId()}/input_items");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    /// <summary>
    /// T031: GET /responses/{id}/input_items?limit=5 returns at most 5 items
    /// with has_more set correctly.
    /// </summary>
    [Test]
    public async Task Get_InputItems_With_Limit_Returns_Limited_Items()
    {
        var responseId = await CreateResponseWithInputsAsync(10);

        var response = await _client.GetAsync($"/responses/{responseId}/input_items?limit=5");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        var data = doc.RootElement.GetProperty("data");
        Assert.That(data.GetArrayLength(), Is.EqualTo(5));
        Assert.That(doc.RootElement.GetProperty("has_more").GetBoolean(), Is.True);
    }

    /// <summary>
    /// T032: GET /responses/{id}/input_items?order=asc returns items in ascending order.
    /// </summary>
    [Test]
    public async Task Get_InputItems_With_Order_Asc_Returns_Ascending()
    {
        var responseId = await CreateResponseWithInputsAsync(3);

        var response = await _client.GetAsync($"/responses/{responseId}/input_items?order=asc");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        var data = doc.RootElement.GetProperty("data");
        Assert.That(data.GetArrayLength(), Is.EqualTo(3));

        // Ascending order: items in insertion order (msg 0, msg 1, msg 2)
        var firstText = GetTextContent(data[0]);
        var lastText = GetTextContent(data[2]);
        Assert.That(firstText, Is.EqualTo("test message 0"));
        Assert.That(lastText, Is.EqualTo("test message 2"));
    }

    /// <summary>
    /// T032 (cont): GET /responses/{id}/input_items?order=desc returns items in descending order.
    /// </summary>
    [Test]
    public async Task Get_InputItems_With_Order_Desc_Returns_Descending()
    {
        var responseId = await CreateResponseWithInputsAsync(3);

        var response = await _client.GetAsync($"/responses/{responseId}/input_items?order=desc");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        var data = doc.RootElement.GetProperty("data");
        Assert.That(data.GetArrayLength(), Is.EqualTo(3));

        // Descending order reverses: last item first
        var firstText = GetTextContent(data[0]);
        var lastText = GetTextContent(data[2]);
        Assert.That(firstText, Is.EqualTo("test message 2"));
        Assert.That(lastText, Is.EqualTo("test message 0"));
    }

    /// <summary>
    /// T033: GET /responses/{id}/input_items returns 404 for a deleted response.
    /// Per API Behaviour Contract Endpoint 5 Post-Deletion Behaviour:
    /// GET /responses/{id}/input_items → HTTP 404 (response not found).
    /// </summary>
    [Test]
    public async Task Get_InputItems_Deleted_Response_Returns_404()
    {
        var responseId = await CreateResponseWithInputsAsync(2);

        // Delete the response
        var deleteResponse = await _client.DeleteAsync($"/responses/{responseId}");
        Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Spec: GET input_items after DELETE → 404
        var response = await _client.GetAsync($"/responses/{responseId}/input_items");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    /// <summary>
    /// Additional: invalid limit returns 400.
    /// </summary>
    [Test]
    public async Task Get_InputItems_Invalid_Limit_Returns_400()
    {
        var responseId = await CreateResponseAsync();

        var response = await _client.GetAsync($"/responses/{responseId}/input_items?limit=0");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        var response2 = await _client.GetAsync($"/responses/{responseId}/input_items?limit=101");
        Assert.That(response2.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T063: POST with input items → GET input_items returns them
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>
    /// T063: Auto-persist pipeline — POST with input items, then GET input_items
    /// returns the same items (they were resolved and persisted by the orchestrator).
    /// </summary>
    [Test]
    public async Task Post_WithInputItems_Then_GetInputItems_Returns_Persisted_Items()
    {
        var json = """
        {
            "model": "test",
            "input": "Hello world"
        }
        """;

        var postResponse = await _client.PostAsync("/responses",
            new StringContent(json, Encoding.UTF8, "application/json"));
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var postBody = await postResponse.Content.ReadAsStringAsync();
        using var postDoc = JsonDocument.Parse(postBody);
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;

        // GET input_items — should return the 1 item auto-persisted by orchestrator
        // (string input expands to a single user message)
        var getResponse = await _client.GetAsync($"/responses/{responseId}/input_items?order=asc");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");
        Assert.That(data.GetArrayLength(), Is.EqualTo(1));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T066: POST with no conversation context → only current input
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>
    /// T066: POST with no previous_response_id or conversation → GET input_items
    /// returns only the current input items (empty history).
    /// </summary>
    [Test]
    public async Task Post_WithNoConversationContext_GetInputItems_Returns_Only_CurrentInput()
    {
        var json = """
        {
            "model": "test",
            "input": "Solo message"
        }
        """;

        var postResponse = await _client.PostAsync("/responses",
            new StringContent(json, Encoding.UTF8, "application/json"));
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var postBody = await postResponse.Content.ReadAsStringAsync();
        using var postDoc = JsonDocument.Parse(postBody);
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;

        var getResponse = await _client.GetAsync($"/responses/{responseId}/input_items?order=asc");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");
        Assert.That(data.GetArrayLength(), Is.EqualTo(1));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T064: POST with previous_response_id → combined history + current input
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>
    /// T064: POST with previous_response_id chains history. Models.ResponseObject B's
    /// input_items contain both response A's input (as history) and response B's own input.
    /// </summary>
    [Test]
    public async Task Post_WithPreviousResponseId_GetInputItems_Returns_History_And_Current()
    {
        // Step 1: Create response A with input "First"
        var jsonA = """
        {
            "model": "test",
            "input": "First message"
        }
        """;
        var postA = await _client.PostAsync("/responses",
            new StringContent(jsonA, Encoding.UTF8, "application/json"));
        var bodyA = await postA.Content.ReadAsStringAsync();
        Assert.That(postA.StatusCode == HttpStatusCode.OK, Is.True, $"POST A failed: {bodyA}");
        using var docA = JsonDocument.Parse(bodyA);
        var responseIdA = docA.RootElement.GetProperty("id").GetString()!;

        // Step 2: Create response B with previous_response_id pointing to A
        var jsonB = $$"""
        {
            "model": "test",
            "input": "Second message",
            "previous_response_id": "{{responseIdA}}"
        }
        """;
        var postB = await _client.PostAsync("/responses",
            new StringContent(jsonB, Encoding.UTF8, "application/json"));
        var bodyB = await postB.Content.ReadAsStringAsync();
        Assert.That(postB.StatusCode == HttpStatusCode.OK, Is.True, $"POST B failed: {bodyB}");
        using var docB = JsonDocument.Parse(bodyB);
        var responseIdB = docB.RootElement.GetProperty("id").GetString()!;

        // Step 3: GET response B's input_items → should have history (from A) + current (from B)
        var getResponse = await _client.GetAsync($"/responses/{responseIdB}/input_items?order=asc");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");

        // Models.ResponseObject A had 1 input item, response B also has 1 → total 2
        Assert.That(data.GetArrayLength(), Is.EqualTo(2));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Input items include both inline input AND history from previous_response_id
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Verifies that GET /responses/{id}/input_items returns items that include
    /// both the current request's inline input AND history items resolved from
    /// previous_response_id. History items appear first (ascending order), followed
    /// by the current request's inline input. Each item's text content is preserved.
    /// </summary>
    [Test]
    public async Task Post_WithPreviousResponseId_InputItems_Contains_History_Text_And_Current_Text()
    {
        // Step 1: Create response A with a known input message
        var jsonA = """
        {
            "model": "test",
            "input": "History from response A"
        }
        """;
        var postA = await _client.PostAsync("/responses",
            new StringContent(jsonA, Encoding.UTF8, "application/json"));
        var bodyA = await postA.Content.ReadAsStringAsync();
        Assert.That(postA.StatusCode == HttpStatusCode.OK, Is.True, $"POST A failed: {bodyA}");
        using var docA = JsonDocument.Parse(bodyA);
        var responseIdA = docA.RootElement.GetProperty("id").GetString()!;

        // Step 2: Create response B that chains from A with its own inline input
        var jsonB = $$"""
        {
            "model": "test",
            "input": "Current inline from response B",
            "previous_response_id": "{{responseIdA}}"
        }
        """;
        var postB = await _client.PostAsync("/responses",
            new StringContent(jsonB, Encoding.UTF8, "application/json"));
        var bodyB = await postB.Content.ReadAsStringAsync();
        Assert.That(postB.StatusCode == HttpStatusCode.OK, Is.True, $"POST B failed: {bodyB}");
        using var docB = JsonDocument.Parse(bodyB);
        var responseIdB = docB.RootElement.GetProperty("id").GetString()!;

        // Step 3: GET response B's input_items in ascending order
        var getResponse = await _client.GetAsync($"/responses/{responseIdB}/input_items?order=asc");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");

        // Must have exactly 2 items: 1 history (from A) + 1 current (from B)
        Assert.That(data.GetArrayLength(), Is.EqualTo(2));

        // First item (ascending) = history item from response A
        var historyItem = data[0];
        Assert.That(historyItem.GetProperty("type").GetString(), Is.EqualTo("message"));
        var historyContent = historyItem.GetProperty("content");
        Assert.That(historyContent.GetArrayLength() > 0, Is.True, "History item should have content");
        var historyText = historyContent[0].GetProperty("text").GetString();
        Assert.That(historyText, Is.EqualTo("History from response A"));

        // Second item (ascending) = current inline input from response B
        var currentItem = data[1];
        Assert.That(currentItem.GetProperty("type").GetString(), Is.EqualTo("message"));
        var currentContent = currentItem.GetProperty("content");
        Assert.That(currentContent.GetArrayLength() > 0, Is.True, "Current item should have content");
        var currentText = currentContent[0].GetProperty("text").GetString();
        Assert.That(currentText, Is.EqualTo("Current inline from response B"));
    }

    /// <summary>
    /// Verifies that a three-response chain (A → B → C) correctly resolves history
    /// from the entire chain. Models.ResponseObject C's input_items should include history from
    /// both A and B, plus C's own inline input.
    /// </summary>
    [Test]
    public async Task Post_WithChainedPreviousResponseIds_InputItems_Contains_Full_History_Chain()
    {
        // Step 1: Create response A
        var jsonA = """
        {
            "model": "test",
            "input": "Message from A"
        }
        """;
        var postA = await _client.PostAsync("/responses",
            new StringContent(jsonA, Encoding.UTF8, "application/json"));
        var bodyA = await postA.Content.ReadAsStringAsync();
        Assert.That(postA.StatusCode == HttpStatusCode.OK, Is.True, $"POST A failed: {bodyA}");
        using var docA = JsonDocument.Parse(bodyA);
        var responseIdA = docA.RootElement.GetProperty("id").GetString()!;

        // Step 2: Create response B chained from A
        var jsonB = $$"""
        {
            "model": "test",
            "input": "Message from B",
            "previous_response_id": "{{responseIdA}}"
        }
        """;
        var postB = await _client.PostAsync("/responses",
            new StringContent(jsonB, Encoding.UTF8, "application/json"));
        var bodyB = await postB.Content.ReadAsStringAsync();
        Assert.That(postB.StatusCode == HttpStatusCode.OK, Is.True, $"POST B failed: {bodyB}");
        using var docB = JsonDocument.Parse(bodyB);
        var responseIdB = docB.RootElement.GetProperty("id").GetString()!;

        // Step 3: Create response C chained from B (so history = A's input + B's input)
        var jsonC = $$"""
        {
            "model": "test",
            "input": "Message from C",
            "previous_response_id": "{{responseIdB}}"
        }
        """;
        var postC = await _client.PostAsync("/responses",
            new StringContent(jsonC, Encoding.UTF8, "application/json"));
        var bodyC = await postC.Content.ReadAsStringAsync();
        Assert.That(postC.StatusCode == HttpStatusCode.OK, Is.True, $"POST C failed: {bodyC}");
        using var docC = JsonDocument.Parse(bodyC);
        var responseIdC = docC.RootElement.GetProperty("id").GetString()!;

        // Step 4: GET response C's input_items in ascending order
        var getResponse = await _client.GetAsync($"/responses/{responseIdC}/input_items?order=asc");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");

        // C's input_items should include history (from B's stored items) + C's own input
        // B's stored items = A's input (history) + B's input (current at that time)
        // So total: A's input + B's input + C's input = 3 items
        Assert.That(data.GetArrayLength(), Is.EqualTo(3));

        // Verify content ordering and text: history items first, then current
        var texts = new List<string>();
        for (int i = 0; i < data.GetArrayLength(); i++)
        {
            var item = data[i];
            Assert.That(item.GetProperty("type").GetString(), Is.EqualTo("message"));
            var content = item.GetProperty("content");
            Assert.That(content.GetArrayLength() > 0, Is.True);
            texts.Add(content[0].GetProperty("text").GetString()!);
        }

        Assert.That(texts[0], Is.EqualTo("Message from A"));
        Assert.That(texts[1], Is.EqualTo("Message from B"));
        Assert.That(texts[2], Is.EqualTo("Message from C"));
    }

    /// <summary>
    /// Verifies that descending order returns current inline input first, then history items
    /// from previous_response_id — demonstrating both types are present and correctly ordered.
    /// </summary>
    [Test]
    public async Task Post_WithPreviousResponseId_DescOrder_Returns_Current_Before_History()
    {
        // Step 1: Create response A with known input
        var jsonA = """
        {
            "model": "test",
            "input": "History context from A"
        }
        """;
        var postA = await _client.PostAsync("/responses",
            new StringContent(jsonA, Encoding.UTF8, "application/json"));
        var bodyA = await postA.Content.ReadAsStringAsync();
        Assert.That(postA.StatusCode == HttpStatusCode.OK, Is.True, $"POST A failed: {bodyA}");
        using var docA = JsonDocument.Parse(bodyA);
        var responseIdA = docA.RootElement.GetProperty("id").GetString()!;

        // Step 2: Create response B with previous_response_id pointing to A
        var jsonB = $$"""
        {
            "model": "test",
            "input": "Current inline from B",
            "previous_response_id": "{{responseIdA}}"
        }
        """;
        var postB = await _client.PostAsync("/responses",
            new StringContent(jsonB, Encoding.UTF8, "application/json"));
        var bodyB = await postB.Content.ReadAsStringAsync();
        Assert.That(postB.StatusCode == HttpStatusCode.OK, Is.True, $"POST B failed: {bodyB}");
        using var docB = JsonDocument.Parse(bodyB);
        var responseIdB = docB.RootElement.GetProperty("id").GetString()!;

        // Step 3: GET response B's input_items in DESCENDING order (default)
        var getResponse = await _client.GetAsync($"/responses/{responseIdB}/input_items?order=desc");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");

        // 1 history + 1 current = 2 items
        Assert.That(data.GetArrayLength(), Is.EqualTo(2));

        // Descending: current (last added) appears first, history appears second
        var firstContent = data[0].GetProperty("content");
        var secondContent = data[1].GetProperty("content");
        Assert.That(firstContent.GetArrayLength() > 0, Is.True);
        Assert.That(secondContent.GetArrayLength() > 0, Is.True);

        var firstText = firstContent[0].GetProperty("text").GetString();
        var secondText = secondContent[0].GetProperty("text").GetString();

        Assert.That(firstText, Is.EqualTo("Current inline from B"));
        Assert.That(secondText, Is.EqualTo("History context from A"));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T065: Background mode persists input items at response.created time
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>
    /// T065: Background-mode response persists input items at response.created time,
    /// making them available via GET input_items immediately after POST returns.
    /// </summary>
    [Test]
    public async Task Post_Background_PersistsInputItems_AtResponseCreated()
    {
        var json = """
        {
            "model": "test",
            "input": "Background input",
            "background": true
        }
        """;

        var postResponse = await _client.PostAsync("/responses",
            new StringContent(json, Encoding.UTF8, "application/json"));
        var postBody = await postResponse.Content.ReadAsStringAsync();
        Assert.That(postResponse.StatusCode == HttpStatusCode.OK, Is.True, $"POST failed: {postBody}");

        using var postDoc = JsonDocument.Parse(postBody);
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;

        // GET input_items — items should be available after bg POST returns
        // (persisted at response.created time, before handler completion)
        var getResponse = await _client.GetAsync($"/responses/{responseId}/input_items?order=asc");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");
        Assert.That(data.GetArrayLength(), Is.EqualTo(1));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Helpers
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Creates a response with no input items via POST.
    /// </summary>
    private async Task<string> CreateResponseAsync()
    {
        var body = JsonSerializer.Serialize(new { model = "test" });
        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        var responseBody = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(responseBody);
        return doc.RootElement.GetProperty("id").GetString()!;
    }

    /// <summary>
    /// Creates a response with <paramref name="count"/> input items via POST.
    /// Each item is an inline message with text "test message {i}".
    /// </summary>
    private async Task<string> CreateResponseWithInputsAsync(int count)
    {
        var items = new List<object>();
        for (int i = 0; i < count; i++)
        {
            items.Add(new
            {
                type = "message",
                id = $"msg_{i:D4}",
                status = "completed",
                role = "user",
                content = new[] { new { type = "input_text", text = $"test message {i}" } }
            });
        }

        var payload = new { model = "test", input = items };
        var json = JsonSerializer.Serialize(payload);
        var response = await _client.PostAsync("/responses",
            new StringContent(json, Encoding.UTF8, "application/json"));
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.That(response.StatusCode == HttpStatusCode.OK, Is.True, $"POST failed: {responseBody}");
        using var doc = JsonDocument.Parse(responseBody);
        return doc.RootElement.GetProperty("id").GetString()!;
    }

    /// <summary>
    /// Extracts the text content from an input item JSON element.
    /// </summary>
    private static string? GetTextContent(JsonElement item)
    {
        if (item.TryGetProperty("content", out var content) && content.GetArrayLength() > 0)
        {
            return content[0].GetProperty("text").GetString();
        }

        return null;
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
        GC.SuppressFinalize(this);
    }
}
