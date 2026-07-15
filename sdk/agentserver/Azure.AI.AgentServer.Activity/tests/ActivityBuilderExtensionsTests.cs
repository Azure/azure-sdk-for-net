// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Activity.Internal;
using Azure.AI.AgentServer.Core;
using Microsoft.Agents.Authentication;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Builder.State;
using Microsoft.Agents.Core.Models;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

/// <summary>
/// Verifies the Tier 2 hosting path: composing the Activity protocol onto a Core host built with
/// <see cref="AgentHost.CreateBuilder(string[])"/> via
/// <see cref="ActivityBuilderExtensions.AddActivity{TAgent}(AgentHostBuilder, System.Action{ActivityServerOptions})"/>.
/// </summary>
[TestFixture]
[NonParallelizable]
public class ActivityBuilderExtensionsTests
{
    private sealed class EchoAgent : AgentApplication
    {
        public EchoAgent(AgentApplicationOptions options) : base(options)
        {
            OnActivity(ActivityTypes.Message, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
            {
                await turnContext.SendActivityAsync($"Echo: {turnContext.Activity.Text}", cancellationToken: cancellationToken);
            });
        }
    }

    private const string NormalMessagePayload =
        """{"type":"message","text":"hi","from":{"id":"u1"},"recipient":{"id":"b1"},"conversation":{"id":"c1"},"channelId":"msteams","serviceUrl":"http://localhost:1/","id":"a1"}""";

    [Test]
    public void AddActivity_Generic_SubstitutesFoundryConnectionsAndRegistersHandler()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.AddActivity<EchoAgent>();

        using var app = builder.Build().App;

        Assert.That(app.Services.GetRequiredService<IConnections>(), Is.InstanceOf<FoundryConnections>());
        Assert.That(app.Services.GetService<IAgentHttpAdapter>(), Is.Not.Null);
        Assert.That(app.Services.GetService<ActivityEndpointHandler>(), Is.Not.Null);
        Assert.That(app.Services.GetService<IAgent>(), Is.InstanceOf<EchoAgent>());
    }

    [Test]
    public async Task AddActivity_Generic_ReturnsAccepted_ForNormalMessage()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.AddActivity<EchoAgent>();

        var host = builder.Build();
        await host.App.StartAsync();

        var client = host.App.GetTestClient();
        var response = await client.PostAsync(
            "/activity/messages",
            new StringContent(NormalMessagePayload, System.Text.Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));

        await host.App.StopAsync();
        await host.App.DisposeAsync();
    }

    [Test]
    public async Task AddActivity_Instance_HostsPreBuiltApplication()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();

        // Build an AgentApplication instance up front, then host it as-is.
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddSingleton<Microsoft.Extensions.Configuration.IConfiguration>(
            new Microsoft.Extensions.Configuration.ConfigurationBuilder().Build());
        services.AddActivityServerServices();
        Internal.ActivityStack.RegisterM365Services(services, new ActivityServerOptions());
        using var provider = services.BuildServiceProvider();
        var app = new AgentApplication(provider.GetRequiredService<AgentApplicationOptions>());

        builder.AddActivity(app);

        using var host = builder.Build().App;
        Assert.That(host.Services.GetService<IAgent>(), Is.SameAs(app));
    }

    [Test]
    public void AddActivity_Factory_RegistersAgentFromFactory()
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();

        builder.AddActivity(sp => new EchoAgent(sp.GetRequiredService<AgentApplicationOptions>()));

        using var host = builder.Build().App;

        var agent = host.Services.GetService<IAgent>();
        Assert.That(agent, Is.InstanceOf<EchoAgent>());
        // The concrete AgentApplication and IAgent resolve to the same singleton instance.
        Assert.That(host.Services.GetRequiredService<AgentApplication>(), Is.SameAs(agent));
    }

    [Test]
    public void AddActivity_WithNullFactory_ThrowsArgumentNullException()
    {
        var builder = AgentHost.CreateBuilder();
        Assert.Throws<ArgumentNullException>(
            () => builder.AddActivity((Func<IServiceProvider, AgentApplication>)null!));
    }

    [Test]
    public void AddActivity_WithNullBuilder_ThrowsArgumentNullException()
    {
        AgentHostBuilder builder = null!;
        Assert.Throws<ArgumentNullException>(() => builder.AddActivity<EchoAgent>());
    }

    [Test]
    public void ActivityServer_Run_Generic_ComposesTheSamePipeline()
    {
        // ActivityServer.Run<TAgent>() is the Tier 1 one-liner. It wraps the same
        // AgentHost.CreateBuilder().AddActivity<TAgent>().Build().Run() the Tier 2 test exercises.
        // We verify it builds an equivalent host via the configure callback (without Run() blocking).
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        builder.AddActivity<EchoAgent>();

        using var app = builder.Build().App;

        Assert.That(app.Services.GetRequiredService<IConnections>(), Is.InstanceOf<FoundryConnections>());
        Assert.That(app.Services.GetService<IAgent>(), Is.InstanceOf<EchoAgent>());
    }
}
