// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Tests.Hosting;

/// <summary>
/// Verifies the <see cref="System.ClientModel.Primitives.ClientSettings"/>-based
/// <c>AddResponsesServer(IHostApplicationBuilder, sectionName)</c> registration path (m-nash #1/#2/#13):
/// settings bind from one configuration section, the option shape is applied to
/// <see cref="ResponsesServerOptions"/>, and the code-first <c>configureSettings</c> callback wins over
/// the bound section. Also verifies the local <see cref="IServiceCollection"/> overload refuses to run
/// in a hosted Foundry environment (where the credential/endpoint must bind from configuration).
/// </summary>
[Experimental("SCME0002")]
[TestFixture]
[NonParallelizable]
public class ResponsesServerHostExtensionsTests
{
    private static IHostApplicationBuilder NewBuilder(Dictionary<string, string?> config)
    {
        var builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddInMemoryCollection(config);
        builder.Services.AddRouting();
        builder.Services.AddAgentServerCore();
        builder.Services.AddSingleton<ResponseHandler>(new TestHandler());
        return builder;
    }

    [Test]
    public void BindsOptionShape_FromConfigurationSection()
    {
        var builder = NewBuilder(new Dictionary<string, string?>
        {
            ["ResponsesServer:DefaultModel"] = "gpt-4o",
            ["ResponsesServer:DefaultFetchHistoryCount"] = "42",
            ["ResponsesServer:SteerableConversations"] = "true",
        });

        builder.AddResponsesServer("ResponsesServer");

        using var sp = builder.Services.BuildServiceProvider();
        var options = sp.GetRequiredService<IOptions<ResponsesServerOptions>>().Value;

        Assert.Multiple(() =>
        {
            Assert.That(options.DefaultModel, Is.EqualTo("gpt-4o"));
            Assert.That(options.DefaultFetchHistoryCount, Is.EqualTo(42));
            Assert.That(options.SteerableConversations, Is.True);
        });
    }

    [Test]
    public void ConfigureSettingsCallback_WinsOverConfiguration()
    {
        var builder = NewBuilder(new Dictionary<string, string?>
        {
            ["ResponsesServer:DefaultModel"] = "from-config",
        });

        builder.AddResponsesServer("ResponsesServer", settings =>
        {
            settings.DefaultModel = "from-code";
        });

        using var sp = builder.Services.BuildServiceProvider();
        var options = sp.GetRequiredService<IOptions<ResponsesServerOptions>>().Value;

        Assert.That(options.DefaultModel, Is.EqualTo("from-code"));
    }

    [Test]
    public void RegistersResponsesServices_Locally()
    {
        var builder = NewBuilder(new Dictionary<string, string?>());

        builder.AddResponsesServer("ResponsesServer");

        using var sp = builder.Services.BuildServiceProvider();

        // Local (non-hosted) selects the durable file-backed response provider, not Foundry storage.
        Assert.That(sp.GetRequiredService<ResponsesProvider>(),
            Is.InstanceOf<Azure.AI.AgentServer.Responses.Internal.Resilience.FileResponsesProvider>());
    }

    [Test]
    public void Settings_BindCore_BindsEndpointAndFlags()
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Sec:Endpoint"] = "https://proj.example.com/api/projects/p",
                ["Sec:ResilientBackground"] = "true",
                ["Sec:DefaultFetchHistoryCount"] = "7",
            })
            .Build();

        var settings = new ResponsesServerSettings();
        settings.Bind(config.GetSection("Sec"));

        Assert.Multiple(() =>
        {
            Assert.That(settings.Endpoint, Is.EqualTo(new Uri("https://proj.example.com/api/projects/p")));
            Assert.That(settings.ResilientBackground, Is.True);
            Assert.That(settings.DefaultFetchHistoryCount, Is.EqualTo(7));
        });
    }

    [TestCase("Endpoint", "not an endpoint")]
    [TestCase("DefaultFetchHistoryCount", "zero")]
    [TestCase("DefaultFetchHistoryCount", "0")]
    [TestCase("ResilientBackground", "sometimes")]
    [TestCase("SteerableConversations", "sometimes")]
    public void Settings_BindCore_RejectsMalformedValues(string key, string value)
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                [$"Sec:{key}"] = value,
            })
            .Build();
        var settings = new ResponsesServerSettings();

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
            () => settings.Bind(config.GetSection("Sec")))!;

        Assert.That(exception.Message, Does.Contain($"Sec:{key}"));
        Assert.That(exception.Message, Does.Contain(value));
    }

    [Test]
    public void HostedRegistration_PassesConfiguredEndpointToCoreTaskStorage()
    {
        try
        {
            SetHostedEnvironment();
            var endpoint = new Uri("https://configured.example.com/api/projects/project");
            var builder = NewBuilder(new Dictionary<string, string?>
            {
                ["ResponsesServer:Endpoint"] = endpoint.AbsoluteUri,
            });

            builder.AddResponsesServer(
                "ResponsesServer",
                settings => settings.CredentialProvider = new FakeTokenCredential());

            using ServiceProvider provider = builder.Services.BuildServiceProvider();
            Assert.That(
                provider.GetRequiredService<TaskHostEnvironment>().Endpoint,
                Is.EqualTo(endpoint));
        }
        finally
        {
            ClearHostedEnvironment();
        }
    }

    [Test]
    public void HostedRegistration_RejectsNonAzureAuthenticationProviderClearly()
    {
        try
        {
            SetHostedEnvironment();
            var builder = NewBuilder(new Dictionary<string, string?>
            {
                ["ResponsesServer:Endpoint"] =
                    "https://configured.example.com/api/projects/project",
            });

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => builder.AddResponsesServer(
                    "ResponsesServer",
                    settings => settings.CredentialProvider = new NonAzureTokenProvider()))!;

            Assert.That(exception.Message, Does.Contain(nameof(TokenCredential)));
            Assert.That(exception.Message, Does.Contain(typeof(NonAzureTokenProvider).FullName));
        }
        finally
        {
            ClearHostedEnvironment();
        }
    }

    [Test]
    public void IServiceCollectionOverload_Throws_InHostedEnvironment()
    {
        try
        {
            SetHostedEnvironment();
            Assert.That(FoundryEnvironment.IsHosted, Is.True);

            var services = new ServiceCollection();
            var ex = Assert.Throws<InvalidOperationException>(() => services.AddResponsesServer());
            Assert.That(ex!.Message, Does.Contain("IHostApplicationBuilder"));
        }
        finally
        {
            ClearHostedEnvironment();
        }
    }

    private static void SetHostedEnvironment()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", "Production");
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", "https://environment.example.com/project");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "agent");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", "1.0.0");
        FoundryEnvironment.Reload();
    }

    private static void ClearHostedEnvironment()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", null);
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", null);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", null);
        FoundryEnvironment.Reload();
    }

    private sealed class NonAzureTokenProvider : AuthenticationTokenProvider
    {
        public override GetTokenOptions? CreateTokenOptions(
            IReadOnlyDictionary<string, object> properties)
            => new(properties);

        public override AuthenticationToken GetToken(
            GetTokenOptions properties,
            CancellationToken cancellationToken)
            => throw new NotSupportedException();

        public override ValueTask<AuthenticationToken> GetTokenAsync(
            GetTokenOptions properties,
            CancellationToken cancellationToken)
            => throw new NotSupportedException();
    }
}
