// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.AI.AgentServer.Responses.Tests.Helpers;

/// <summary>
/// A test application factory that configures a minimal ASP.NET Core host
/// with the Responses SDK services and routes.
/// </summary>
public sealed class TestWebApplicationFactory : IDisposable
{
    private readonly IHost _host;

    public TestWebApplicationFactory(
        TestHandler? handler = null,
        Action<ResponsesServerOptions>? configureOptions = null,
        string? routePrefix = null,
        Action<IServiceCollection>? configureTestServices = null,
        Action<AgentHostOptions>? configureHostOptions = null)
    {
        var testHandler = handler ?? new TestHandler();

        var builder = new HostBuilder()
            .ConfigureWebHost(webHost =>
            {
                webHost.UseTestServer();
                webHost.ConfigureServices(services =>
                {
                    services.AddRouting();
                    services.AddAgentServerVersion();
                    if (configureHostOptions is not null)
                    {
                        services.Configure(configureHostOptions);
                    }
                    services.AddSingleton<ResponseHandler>(testHandler);
                    configureTestServices?.Invoke(services);
                    services.AddResponsesServer(configureOptions);
                });
                webHost.Configure(app =>
                {
                    app.UseAgentServerVersion();
                    app.UseRouting();
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapResponsesServer(routePrefix);
                    });
                });
            });

        _host = builder.Build();
        _host.Start();
    }

    public HttpClient CreateClient()
    {
        return _host.GetTestClient();
    }

    /// <summary>
    /// Triggers graceful host shutdown, firing <see cref="IHostedService.StopAsync"/>
    /// on all registered services (including <c>ResponseExecutionTracker</c>).
    /// </summary>
    public Task StopAsync(CancellationToken cancellationToken = default)
    {
        return _host.StopAsync(cancellationToken);
    }

    public void Dispose()
    {
        _host.Dispose();
    }
}
