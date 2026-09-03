// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.Core;
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
        Action<AgentHostOptions>? configureHostOptions = null,
        bool hosted = false,
        Action<IServiceCollection>? configureAfterResponsesServices = null)
    {
        var testHandler = handler ?? new TestHandler();

        var builder = new HostBuilder()
            .ConfigureWebHost(webHost =>
            {
                webHost.UseTestServer();
                webHost.ConfigureServices(services =>
                {
                    services.AddRouting();
                    services.AddAgentServerCore();
                    if (configureHostOptions is not null)
                    {
                        services.Configure(configureHostOptions);
                    }
                    services.AddSingleton<ResponseHandler>(testHandler);
                    configureTestServices?.Invoke(services);
                    if (hosted)
                    {
                        // Hosted registration binds the Foundry credential + endpoint from settings in
                        // production; the test harness (which uses the legacy IHostBuilder, not an
                        // IHostApplicationBuilder) drives the same shared core directly with a fake
                        // credential and a development storage endpoint.
                        var projectEndpoint =
                            new Uri("https://example.com/api/projects/proj");
                        var storageBaseUri = ResponsesServerServiceCollectionExtensions.ResolveStorageBaseUri(
                            projectEndpoint,
                            isDevelopment: false);
                        services.AddResponsesServerCore(
                            configureOptions,
                            new ResponsesHostedStorage(
                                new FakeTokenCredential(),
                                projectEndpoint,
                                storageBaseUri));
                    }
                    else
                    {
                        services.AddResponsesServer(configureOptions);
                    }
                    configureAfterResponsesServices?.Invoke(services);
                });
                webHost.Configure(app =>
                {
                    app.UseAgentServerCore();
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

    public IServiceProvider Services => _host.Services;

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
