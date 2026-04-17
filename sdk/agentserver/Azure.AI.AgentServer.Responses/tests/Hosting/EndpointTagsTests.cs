// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.AI.AgentServer.Responses.Tests.Hosting;

/// <summary>
/// Tests for OpenAPI endpoint tags.
/// Verifies all Responses API endpoints carry the "Responses" tag.
/// </summary>
public sealed class EndpointTagsTests
{
    [Test]
    public void AllEndpoints_HaveResponsesTag()
    {
        // T038: all 5 endpoints have tag "Responses"
        var builder = new HostBuilder()
            .ConfigureWebHost(webHost =>
            {
                webHost.UseTestServer();
                webHost.ConfigureServices(services =>
                {
                    services.AddRouting();
                    services.AddSingleton<ResponseHandler>(new Azure.AI.AgentServer.Responses.Tests.Helpers.TestHandler());
                    services.AddResponsesServer();
                });
                webHost.Configure(app =>
                {
                    app.UseRouting();
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapResponsesServer();
                    });
                });
            });

        using var host = builder.Build();
        host.Start();

        var endpointDataSource = host.Services.GetRequiredService<EndpointDataSource>();
        var endpoints = endpointDataSource.Endpoints.OfType<RouteEndpoint>()
            .Where(e => e.RoutePattern.RawText?.Contains("responses") == true)
            .ToList();

        Assert.That(endpoints.Count >= 5, Is.True,
            $"Expected at least 5 Responses endpoints, found {endpoints.Count}");

        foreach (var endpoint in endpoints)
        {
            var tagsMetadata = endpoint.Metadata.OfType<TagsAttribute>().ToList();
            var allTags = tagsMetadata.SelectMany(t => t.Tags).ToList();
            XAssert.Contains("Responses", allTags);
        }
    }
}
