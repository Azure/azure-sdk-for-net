// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.AI.AgentServer.Responses.Tests.Hosting;

/// <summary>
/// Tests for MapResponsesServer() startup validation (S-004).
/// Verifies fail-fast behaviour when ResponseHandler is not registered.
/// </summary>
public sealed class StartupValidationTests
{
    [Test]
    public void MapResponsesServer_Throws_WhenHandlerNotRegistered()
    {
        // T036 / S-004: missing ResponseHandler → InvalidOperationException
        var ex = Assert.Throws<InvalidOperationException>(() =>
        {
            var builder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.ConfigureServices(services =>
                    {
                        services.AddRouting();
                        // Deliberately NOT registering ResponseHandler
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

            var host = builder.Build();
            host.Start();
        });

        XAssert.Contains("ResponseHandler", ex.Message);
    }

    [Test]
    public void MapResponsesServer_Succeeds_WhenHandlerRegistered()
    {
        // T037: no exception when handler is registered
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
        host.Start(); // Should not throw
    }
}
