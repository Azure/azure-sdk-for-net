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

        Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var body = await deleteResponse.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        Assert.That(doc.RootElement.GetProperty("id").GetString(), Is.EqualTo(responseId));
        Assert.That(doc.RootElement.GetProperty("deleted").GetBoolean(), Is.True);
        Assert.That(doc.RootElement.GetProperty("object").GetString(), Is.EqualTo("response"),
            "DELETE result must include 'object': 'response'");
    }

    /// <summary>
    /// T020: DELETE a non-existent response returns 404 with standard error shape.
    /// </summary>
    [Test]
    public async Task Delete_NonExistent_Response_Returns_404()
    {
        var deleteResponse = await Client.DeleteAsync($"/responses/{IdGenerator.NewResponseId()}");

        Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        var body = await deleteResponse.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        Assert.That(doc.RootElement.TryGetProperty("error", out var error), Is.True);
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("invalid_request_error"));
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

        Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        var body2 = await deleteResponse.Content.ReadAsStringAsync();
        using var doc2 = JsonDocument.Parse(body2);
        Assert.That(doc2.RootElement.TryGetProperty("error", out var error2), Is.True);
        Assert.That(error2.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error2.GetProperty("code").GetString(), Is.EqualTo("invalid_request_error"));
        // Spec: "Cannot delete an in-flight response."
        Assert.That(error2.GetProperty("message").GetString(), Is.EqualTo("Cannot delete an in-flight response."));

        // Clean up
        tcs.SetResult();
        await WaitForBackgroundCompletionAsync(responseId);
    }

    /// <summary>
    /// T022: GET after DELETE returns 404 (response not found).
    /// Per API Behaviour Contract Endpoint 5 Post-Deletion Behaviour:
    /// GET /responses/{id} → HTTP 404 (response not found).
    /// </summary>
    [Test]
    public async Task Get_After_Delete_Returns_404()
    {
        // Create and then delete a response
        var responseId = await CreateDefaultResponseAsync();

        var deleteResponse = await Client.DeleteAsync($"/responses/{responseId}");
        Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Spec: GET after DELETE → 404 (response not found)
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    /// <summary>
    /// Post-deletion: Cancel after DELETE returns 404.
    /// Per API Behaviour Contract Endpoint 5 Post-Deletion Behaviour:
    /// POST /responses/{id}/cancel → HTTP 404 (response not found).
    /// </summary>
    [Test]
    public async Task Cancel_After_Delete_Returns_404()
    {
        var responseId = await CreateDefaultResponseAsync();

        var deleteResponse = await Client.DeleteAsync($"/responses/{responseId}");
        Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Spec: Cancel after DELETE → 404
        var cancelResponse = await CancelResponseAsync(responseId);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
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
        Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Extract response ID from the returned body
        using var createDoc = await ParseJsonAsync(createResponse);
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        // DELETE should return 404 since store=false responses aren't persisted
        var deleteResponse = await Client.DeleteAsync($"/responses/{responseId}");
        Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    /// <summary>
    /// Additional: DELETE the same response twice returns 404 on second attempt.
    /// </summary>
    [Test]
    public async Task Delete_Same_Response_Twice_Returns_404_On_Second()
    {
        var responseId = await CreateDefaultResponseAsync();

        var firstDelete = await Client.DeleteAsync($"/responses/{responseId}");
        Assert.That(firstDelete.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var secondDelete = await Client.DeleteAsync($"/responses/{responseId}");
        Assert.That(secondDelete.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
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
        Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var body = await deleteResponse.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        Assert.That(doc.RootElement.GetProperty("id").GetString(), Is.EqualTo(responseId));
        Assert.That(doc.RootElement.GetProperty("deleted").GetBoolean(), Is.True);
        Assert.That(doc.RootElement.GetProperty("object").GetString(), Is.EqualTo("response"),
            "DELETE result must include 'object': 'response'");
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> BlockingStream(
        ResponseContext ctx,
        Task delayTask,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);
        await delayTask.WaitAsync(ct);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }
}
