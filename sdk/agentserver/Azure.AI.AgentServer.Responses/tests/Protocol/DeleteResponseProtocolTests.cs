// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// T019–T023: Protocol tests for DELETE /responses/{id} endpoint (User Story 2).
/// Covers: completed response deletion (200), not-found (404), in-flight (400),
/// GET after DELETE (404), store=false response (404).
/// </summary>
public class DeleteResponseProtocolTests : ProtocolTestBase
{
    /// <summary>
    /// T019: DELETE a completed response returns 200 with
    /// DeleteResponseResult { id, deleted: true }.
    /// </summary>
    [Test]
    public async Task Delete_Completed_Response_Returns_200_With_DeleteResult()
    {
        // Create a default (sync, non-background) response
        var responseId = await CreateDefaultResponseAsync();

        // DELETE the completed response
        var deleteResponse = await Client.DeleteAsync($"/responses/{responseId}");

        Assert.AreEqual(HttpStatusCode.OK, deleteResponse.StatusCode);

        var body = await deleteResponse.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        Assert.AreEqual(responseId, doc.RootElement.GetProperty("id").GetString());
        Assert.IsTrue(doc.RootElement.GetProperty("deleted").GetBoolean());
    }

    /// <summary>
    /// T020: DELETE a non-existent response returns 404 with standard error shape.
    /// </summary>
    [Test]
    public async Task Delete_NonExistent_Response_Returns_404()
    {
        var deleteResponse = await Client.DeleteAsync("/responses/resp_nonexistent_delete_test");

        Assert.AreEqual(HttpStatusCode.NotFound, deleteResponse.StatusCode);

        var body = await deleteResponse.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        Assert.IsTrue(doc.RootElement.TryGetProperty("error", out var error));
        Assert.AreEqual("invalid_request_error", error.GetProperty("type").GetString());
    }

    /// <summary>
    /// T021: DELETE an in-flight response returns 400 with standard error shape.
    /// </summary>
    [Test]
    public async Task Delete_InFlight_Response_Returns_400()
    {
        // Create a background response that blocks until we signal
        var tcs = new TaskCompletionSource();
        Handler.EventFactory = (_, ctx, ct) => BlockingStream(ctx, tcs.Task, ct);

        var responseId = await CreateBackgroundResponseAsync();

        // DELETE the in-flight response
        var deleteResponse = await Client.DeleteAsync($"/responses/{responseId}");

        Assert.AreEqual(HttpStatusCode.BadRequest, deleteResponse.StatusCode);

        var body2 = await deleteResponse.Content.ReadAsStringAsync();
        using var doc2 = JsonDocument.Parse(body2);
        Assert.IsTrue(doc2.RootElement.TryGetProperty("error", out var error2));
        Assert.AreEqual("invalid_request_error", error2.GetProperty("type").GetString());

        // Clean up
        tcs.SetResult();
        await WaitForBackgroundCompletionAsync(responseId);
    }

    /// <summary>
    /// T022: GET after DELETE returns 400 (deleted responses are distinguished from never-existed).
    /// Per API Behaviour Contract Endpoint 5 Post-Deletion Behaviour:
    /// GET /responses/{id} → HTTP 400 with message indicating the response has been deleted.
    /// </summary>
    [Test]
    public async Task Get_After_Delete_Returns_400()
    {
        // Create and then delete a response
        var responseId = await CreateDefaultResponseAsync();

        var deleteResponse = await Client.DeleteAsync($"/responses/{responseId}");
        Assert.AreEqual(HttpStatusCode.OK, deleteResponse.StatusCode);

        // GET should return 400 (deleted, not 404 = never-existed)
        var getResponse = await GetResponseAsync(responseId);
        Assert.AreEqual(HttpStatusCode.BadRequest, getResponse.StatusCode);
    }

    /// <summary>
    /// T023: DELETE a store=false response returns 404 (never persisted).
    /// </summary>
    [Test]
    public async Task Delete_StoreFalse_Response_Returns_404()
    {
        // Create a store=false response (non-background, non-streaming)
        var body = JsonSerializer.Serialize(new { model = "test", store = false });
        var createResponse = await PostResponsesAsync(body);
        Assert.AreEqual(HttpStatusCode.OK, createResponse.StatusCode);

        // Extract response ID from the returned body
        using var createDoc = await ParseJsonAsync(createResponse);
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        // DELETE should return 404 since store=false responses aren't persisted
        var deleteResponse = await Client.DeleteAsync($"/responses/{responseId}");
        Assert.AreEqual(HttpStatusCode.NotFound, deleteResponse.StatusCode);
    }

    /// <summary>
    /// Additional: DELETE the same response twice returns 404 on second attempt.
    /// </summary>
    [Test]
    public async Task Delete_Same_Response_Twice_Returns_404_On_Second()
    {
        var responseId = await CreateDefaultResponseAsync();

        var firstDelete = await Client.DeleteAsync($"/responses/{responseId}");
        Assert.AreEqual(HttpStatusCode.OK, firstDelete.StatusCode);

        var secondDelete = await Client.DeleteAsync($"/responses/{responseId}");
        Assert.AreEqual(HttpStatusCode.NotFound, secondDelete.StatusCode);
    }

    /// <summary>
    /// Additional: DELETE a completed background response returns 200.
    /// </summary>
    [Test]
    public async Task Delete_Completed_Background_Response_Returns_200()
    {
        var responseId = await CreateBackgroundResponseAsync();
        await WaitForBackgroundCompletionAsync(responseId);

        var deleteResponse = await Client.DeleteAsync($"/responses/{responseId}");
        Assert.AreEqual(HttpStatusCode.OK, deleteResponse.StatusCode);

        var body = await deleteResponse.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        Assert.AreEqual(responseId, doc.RootElement.GetProperty("id").GetString());
        Assert.IsTrue(doc.RootElement.GetProperty("deleted").GetBoolean());
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> BlockingStream(
        IResponseContext ctx,
        Task delayTask,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var response = new Models.Response(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);
        await delayTask.WaitAsync(ct);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }
}
