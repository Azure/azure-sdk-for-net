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

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        var data = doc.RootElement.GetProperty("data");
        Assert.AreEqual(3, data.GetArrayLength());
        Assert.IsFalse(doc.RootElement.GetProperty("has_more").GetBoolean());
    }

    /// <summary>
    /// T029 (cont): GET with no stored items returns 200 with empty data.
    /// </summary>
    [Test]
    public async Task Get_InputItems_Returns_200_With_Empty_Data()
    {
        var responseId = await CreateResponseAsync();

        var response = await _client.GetAsync($"/responses/{responseId}/input_items");

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        var data = doc.RootElement.GetProperty("data");
        Assert.AreEqual(0, data.GetArrayLength());
        Assert.IsFalse(doc.RootElement.GetProperty("has_more").GetBoolean());
    }

    /// <summary>
    /// T030: GET /responses/{id}/input_items returns 404 for non-existent response.
    /// </summary>
    [Test]
    public async Task Get_InputItems_NonExistent_Response_Returns_404()
    {
        var response = await _client.GetAsync("/responses/resp_nonexistent/input_items");

        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
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

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        var data = doc.RootElement.GetProperty("data");
        Assert.AreEqual(5, data.GetArrayLength());
        Assert.IsTrue(doc.RootElement.GetProperty("has_more").GetBoolean());
    }

    /// <summary>
    /// T032: GET /responses/{id}/input_items?order=asc returns items in ascending order.
    /// </summary>
    [Test]
    public async Task Get_InputItems_With_Order_Asc_Returns_Ascending()
    {
        var responseId = await CreateResponseWithInputsAsync(3);

        var response = await _client.GetAsync($"/responses/{responseId}/input_items?order=asc");

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        var data = doc.RootElement.GetProperty("data");
        Assert.AreEqual(3, data.GetArrayLength());

        // Ascending order: items in insertion order (msg 0, msg 1, msg 2)
        var firstText = GetTextContent(data[0]);
        var lastText = GetTextContent(data[2]);
        Assert.AreEqual("test message 0", firstText);
        Assert.AreEqual("test message 2", lastText);
    }

    /// <summary>
    /// T032 (cont): GET /responses/{id}/input_items?order=desc returns items in descending order.
    /// </summary>
    [Test]
    public async Task Get_InputItems_With_Order_Desc_Returns_Descending()
    {
        var responseId = await CreateResponseWithInputsAsync(3);

        var response = await _client.GetAsync($"/responses/{responseId}/input_items?order=desc");

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        var data = doc.RootElement.GetProperty("data");
        Assert.AreEqual(3, data.GetArrayLength());

        // Descending order reverses: last item first
        var firstText = GetTextContent(data[0]);
        var lastText = GetTextContent(data[2]);
        Assert.AreEqual("test message 2", firstText);
        Assert.AreEqual("test message 0", lastText);
    }

    /// <summary>
    /// T033: GET /responses/{id}/input_items returns 400 for a deleted response.
    /// </summary>
    [Test]
    public async Task Get_InputItems_Deleted_Response_Returns_400()
    {
        var responseId = await CreateResponseWithInputsAsync(2);

        // Delete the response
        var deleteResponse = await _client.DeleteAsync($"/responses/{responseId}");
        Assert.AreEqual(HttpStatusCode.OK, deleteResponse.StatusCode);

        // GET input_items on deleted response should return 400
        var response = await _client.GetAsync($"/responses/{responseId}/input_items");

        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    /// <summary>
    /// Additional: invalid limit returns 400.
    /// </summary>
    [Test]
    public async Task Get_InputItems_Invalid_Limit_Returns_400()
    {
        var responseId = await CreateResponseAsync();

        var response = await _client.GetAsync($"/responses/{responseId}/input_items?limit=0");
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        var response2 = await _client.GetAsync($"/responses/{responseId}/input_items?limit=101");
        Assert.AreEqual(HttpStatusCode.BadRequest, response2.StatusCode);
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
        Assert.AreEqual(HttpStatusCode.OK, postResponse.StatusCode);

        var postBody = await postResponse.Content.ReadAsStringAsync();
        using var postDoc = JsonDocument.Parse(postBody);
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;

        // GET input_items — should return the 1 item auto-persisted by orchestrator
        // (string input expands to a single user message)
        var getResponse = await _client.GetAsync($"/responses/{responseId}/input_items?order=asc");
        Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");
        Assert.AreEqual(1, data.GetArrayLength());
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
        Assert.AreEqual(HttpStatusCode.OK, postResponse.StatusCode);

        var postBody = await postResponse.Content.ReadAsStringAsync();
        using var postDoc = JsonDocument.Parse(postBody);
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;

        var getResponse = await _client.GetAsync($"/responses/{responseId}/input_items?order=asc");
        Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");
        Assert.AreEqual(1, data.GetArrayLength());
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T064: POST with previous_response_id → combined history + current input
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>
    /// T064: POST with previous_response_id chains history. Models.Response B's
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
        Assert.IsTrue(postA.StatusCode == HttpStatusCode.OK, $"POST A failed: {bodyA}");
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
        Assert.IsTrue(postB.StatusCode == HttpStatusCode.OK, $"POST B failed: {bodyB}");
        using var docB = JsonDocument.Parse(bodyB);
        var responseIdB = docB.RootElement.GetProperty("id").GetString()!;

        // Step 3: GET response B's input_items → should have history (from A) + current (from B)
        var getResponse = await _client.GetAsync($"/responses/{responseIdB}/input_items?order=asc");
        Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");

        // Models.Response A had 1 input item, response B also has 1 → total 2
        Assert.AreEqual(2, data.GetArrayLength());
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
        Assert.IsTrue(postA.StatusCode == HttpStatusCode.OK, $"POST A failed: {bodyA}");
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
        Assert.IsTrue(postB.StatusCode == HttpStatusCode.OK, $"POST B failed: {bodyB}");
        using var docB = JsonDocument.Parse(bodyB);
        var responseIdB = docB.RootElement.GetProperty("id").GetString()!;

        // Step 3: GET response B's input_items in ascending order
        var getResponse = await _client.GetAsync($"/responses/{responseIdB}/input_items?order=asc");
        Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");

        // Must have exactly 2 items: 1 history (from A) + 1 current (from B)
        Assert.AreEqual(2, data.GetArrayLength());

        // First item (ascending) = history item from response A
        var historyItem = data[0];
        Assert.AreEqual("message", historyItem.GetProperty("type").GetString());
        var historyContent = historyItem.GetProperty("content");
        Assert.IsTrue(historyContent.GetArrayLength() > 0, "History item should have content");
        var historyText = historyContent[0].GetProperty("text").GetString();
        Assert.AreEqual("History from response A", historyText);

        // Second item (ascending) = current inline input from response B
        var currentItem = data[1];
        Assert.AreEqual("message", currentItem.GetProperty("type").GetString());
        var currentContent = currentItem.GetProperty("content");
        Assert.IsTrue(currentContent.GetArrayLength() > 0, "Current item should have content");
        var currentText = currentContent[0].GetProperty("text").GetString();
        Assert.AreEqual("Current inline from response B", currentText);
    }

    /// <summary>
    /// Verifies that a three-response chain (A → B → C) correctly resolves history
    /// from the entire chain. Models.Response C's input_items should include history from
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
        Assert.IsTrue(postA.StatusCode == HttpStatusCode.OK, $"POST A failed: {bodyA}");
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
        Assert.IsTrue(postB.StatusCode == HttpStatusCode.OK, $"POST B failed: {bodyB}");
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
        Assert.IsTrue(postC.StatusCode == HttpStatusCode.OK, $"POST C failed: {bodyC}");
        using var docC = JsonDocument.Parse(bodyC);
        var responseIdC = docC.RootElement.GetProperty("id").GetString()!;

        // Step 4: GET response C's input_items in ascending order
        var getResponse = await _client.GetAsync($"/responses/{responseIdC}/input_items?order=asc");
        Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");

        // C's input_items should include history (from B's stored items) + C's own input
        // B's stored items = A's input (history) + B's input (current at that time)
        // So total: A's input + B's input + C's input = 3 items
        Assert.AreEqual(3, data.GetArrayLength());

        // Verify content ordering and text: history items first, then current
        var texts = new List<string>();
        for (int i = 0; i < data.GetArrayLength(); i++)
        {
            var item = data[i];
            Assert.AreEqual("message", item.GetProperty("type").GetString());
            var content = item.GetProperty("content");
            Assert.IsTrue(content.GetArrayLength() > 0);
            texts.Add(content[0].GetProperty("text").GetString()!);
        }

        Assert.AreEqual("Message from A", texts[0]);
        Assert.AreEqual("Message from B", texts[1]);
        Assert.AreEqual("Message from C", texts[2]);
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
        Assert.IsTrue(postA.StatusCode == HttpStatusCode.OK, $"POST A failed: {bodyA}");
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
        Assert.IsTrue(postB.StatusCode == HttpStatusCode.OK, $"POST B failed: {bodyB}");
        using var docB = JsonDocument.Parse(bodyB);
        var responseIdB = docB.RootElement.GetProperty("id").GetString()!;

        // Step 3: GET response B's input_items in DESCENDING order (default)
        var getResponse = await _client.GetAsync($"/responses/{responseIdB}/input_items?order=desc");
        Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");

        // 1 history + 1 current = 2 items
        Assert.AreEqual(2, data.GetArrayLength());

        // Descending: current (last added) appears first, history appears second
        var firstContent = data[0].GetProperty("content");
        var secondContent = data[1].GetProperty("content");
        Assert.IsTrue(firstContent.GetArrayLength() > 0);
        Assert.IsTrue(secondContent.GetArrayLength() > 0);

        var firstText = firstContent[0].GetProperty("text").GetString();
        var secondText = secondContent[0].GetProperty("text").GetString();

        Assert.AreEqual("Current inline from B", firstText);
        Assert.AreEqual("History context from A", secondText);
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
        Assert.IsTrue(postResponse.StatusCode == HttpStatusCode.OK, $"POST failed: {postBody}");

        using var postDoc = JsonDocument.Parse(postBody);
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;

        // GET input_items — items should be available after bg POST returns
        // (persisted at response.created time, before handler completion)
        var getResponse = await _client.GetAsync($"/responses/{responseId}/input_items?order=asc");
        Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");
        Assert.AreEqual(1, data.GetArrayLength());
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
                content = new { type = "input_text", text = $"test message {i}" }
            });
        }

        var payload = new { model = "test", input = items };
        var json = JsonSerializer.Serialize(payload);
        var response = await _client.PostAsync("/responses",
            new StringContent(json, Encoding.UTF8, "application/json"));
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, $"POST failed: {responseBody}");
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
