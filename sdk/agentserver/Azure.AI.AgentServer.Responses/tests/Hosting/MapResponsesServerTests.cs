// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

public class MapResponsesServerTests : IDisposable
{
    [Test]
    public async Task DefaultPrefix_RoutesAtSlashResponses()
    {
        using var factory = new TestWebApplicationFactory();
        using var client = factory.CreateClient();

        var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task CustomPrefix_RoutesAtPrefixSlashResponses()
    {
        using var factory = new TestWebApplicationFactory(routePrefix: "/v1");
        using var client = factory.CreateClient();

        var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/v1/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task CustomPrefix_OldPathReturns404()
    {
        using var factory = new TestWebApplicationFactory(routePrefix: "/v1");
        using var client = factory.CreateClient();

        var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task CancelRoute_IsMapped()
    {
        using var factory = new TestWebApplicationFactory();
        using var client = factory.CreateClient();

        // Cancel on unknown ID should return 404 (not 405 / routing miss)
        var response = await client.PostAsync($"/responses/{IdGenerator.NewResponseId()}/cancel", null);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task GetRoute_IsMapped()
    {
        using var factory = new TestWebApplicationFactory();
        using var client = factory.CreateClient();

        // GET on unknown ID should return 404
        var response = await client.GetAsync($"/responses/{IdGenerator.NewResponseId()}");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
