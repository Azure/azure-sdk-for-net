// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Azure.AI.AgentServer.A2A.Internal;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace Azure.AI.AgentServer.A2A.Tests;

[TestFixture]
public class TransportTests
{
    private static async Task<WebApplication> CreateAppAsync(Func<ValueTask<object?>> next)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        var app = builder.Build();
        app.UseAgentServerCore();
        app.MapPost("/a2a", () => new A2ATransportResult(next));
        await app.StartAsync();
        return app;
    }

    [TestCase(422, "user")]
    [TestCase(503, "upstream")]
    public async Task HttpErrorsAreClassifiedWithoutRewritingBody(int status, string source)
    {
        await using var app = await CreateAppAsync(() =>
            ValueTask.FromResult<object?>(Results.Text("native-body", statusCode: status)));
        using var client = app.GetTestClient();
        using var response = await client.PostAsync("/a2a", null);
        Assert.That((int)response.StatusCode, Is.EqualTo(status));
        Assert.That(response.Headers.GetValues("x-platform-error-source").Single(), Is.EqualTo(source));
        Assert.That(await response.Content.ReadAsStringAsync(), Is.EqualTo("native-body"));
    }

    [Test]
    public async Task TaggedFailureHasSanitizedBoundedPlatformDetail()
    {
        var exception = new InvalidOperationException("failure\r\n\u2603" + new string('x', 3000));
        exception.Data["Azure.AI.AgentServer.PlatformError"] = true;
        await using var app = await CreateAppAsync(() => ValueTask.FromException<object?>(exception));
        using var client = app.GetTestClient();
        using var response = await client.PostAsync("/a2a", null);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        Assert.That(response.Headers.GetValues("x-platform-error-source").Single(), Is.EqualTo("platform"));
        var detail = response.Headers.GetValues("x-platform-error-detail").Single();
        Assert.That(detail, Has.Length.EqualTo(2048));
        Assert.That(detail.All(c => c >= ' ' && c <= '~'), Is.True);
        Assert.That(await response.Content.ReadAsStringAsync(), Does.Not.Contain("failure"));
    }

    [Test]
    public async Task BadHttpRequestKeepsItsStatusAndUserClassification()
    {
        await using var app = await CreateAppAsync(() => ValueTask.FromException<object?>(
            new BadHttpRequestException("Invalid request", StatusCodes.Status413PayloadTooLarge)));
        using var client = app.GetTestClient();
        using var response = await client.PostAsync("/a2a", null);
        Assert.That((int)response.StatusCode, Is.EqualTo(413));
        Assert.That(response.Headers.GetValues("x-platform-error-source").Single(), Is.EqualTo("user"));
    }
}
