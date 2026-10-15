// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Hosting;

/// <summary>
/// Verifies that hosted registration falls back to the platform (FOUNDRY_PROJECT_ENDPOINT and a
/// production-only DefaultAzureCredential) only for values the operator did not provide, so the
/// one-line <c>ResponsesServer.Run&lt;THandler&gt;()</c> starts in a hosted Foundry container that
/// has no <c>ResponsesServer</c> configuration section.
/// </summary>
[Experimental("SCME0002")]
[TestFixture]
[NonParallelizable]
public class HostedPlatformFallbackTests
{
    private const string PlatformEndpoint = "https://platform.example.com/api/projects/platform";
    private const string ConfiguredEndpoint = "https://configured.example.com/api/projects/configured";

    private static readonly string[] s_variables =
    {
        "FOUNDRY_HOSTING_ENVIRONMENT",
        "FOUNDRY_PROJECT_ENDPOINT",
        "FOUNDRY_AGENT_NAME",
        "FOUNDRY_AGENT_VERSION",
        "AZURE_TOKEN_CREDENTIALS",
    };

    private readonly Dictionary<string, string?> _previous = new();

    [SetUp]
    public void SetUp()
    {
        foreach (string name in s_variables)
        {
            _previous[name] = Environment.GetEnvironmentVariable(name);
        }

        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", "Production");
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", PlatformEndpoint);
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_NAME", "agent");
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_VERSION", "1");
        Environment.SetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS", null);
        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.IsHosted, Is.True);
    }

    [TearDown]
    public void TearDown()
    {
        foreach (var pair in _previous)
        {
            Environment.SetEnvironmentVariable(pair.Key, pair.Value);
        }

        _previous.Clear();
        FoundryEnvironment.Reload();
    }

    [Test]
    public void PlatformEnvironmentOnly_AgentHostBuilder_UsesPlatformEndpointAndFallbackCredential()
    {
        AgentHostBuilder builder = AgentHost.CreateBuilder();

        Assert.DoesNotThrow(() => builder.AddResponses<TestHandler>());

        Assert.That(
            builder.Services.Any(d => d.ServiceType == typeof(TokenCredential)),
            Is.False,
            "The fallback credential must stay private to hosted storage.");
        using ServiceProvider provider = builder.Services.BuildServiceProvider();
        Assert.That(
            provider.GetRequiredService<ResponsesProvider>(),
            Is.InstanceOf<FoundryStorageProvider>());
        var environment = provider.GetRequiredService<TaskHostEnvironment>();
        Assert.That(environment.Endpoint, Is.EqualTo(new Uri(PlatformEndpoint)));
        Assert.That(environment.Credential, Is.InstanceOf<DefaultAzureCredential>());
    }

    [Test]
    public void ConfiguredEndpointAndCredential_TakePrecedenceOverPlatformFallback()
    {
        HostApplicationBuilder builder = NewHost(new()
        {
            ["ResponsesServer:Endpoint"] = ConfiguredEndpoint,
            ["ResponsesServer:Credential:CredentialSource"] = "ManagedIdentityCredential",
        });

        builder.AddResponsesServer("ResponsesServer");

        using ServiceProvider provider = builder.Services.BuildServiceProvider();
        var environment = provider.GetRequiredService<TaskHostEnvironment>();
        Assert.That(environment.Endpoint, Is.EqualTo(new Uri(ConfiguredEndpoint)));
        Assert.That(environment.Credential, Is.Not.Null.And.Not.InstanceOf<DefaultAzureCredential>());
        Assert.That(provider.GetService<ResponsesHostedCredentialFallback>(), Is.Null);
    }

    [Test]
    public void CodeConfiguredCredential_SuppressesFallback_AndEndpointComesFromPlatform()
    {
        var credential = new FakeTokenCredential();
        HostApplicationBuilder builder = NewHost(new());

        builder.AddResponsesServer("ResponsesServer", settings => settings.CredentialProvider = credential);

        using ServiceProvider provider = builder.Services.BuildServiceProvider();
        var environment = provider.GetRequiredService<TaskHostEnvironment>();
        Assert.That(environment.Credential, Is.SameAs(credential));
        Assert.That(environment.Endpoint, Is.EqualTo(new Uri(PlatformEndpoint)));
        Assert.That(provider.GetService<ResponsesHostedCredentialFallback>(), Is.Null);
    }

    [TestCase("NotARealCredential")]
    [TestCase("DefaultAzureCredential")]
    public void UnresolvableCredentialSection_IsNotReplacedByFallback(string source)
    {
        HostApplicationBuilder builder = NewHost(new()
        {
            ["ResponsesServer:Credential:CredentialSource"] = source,
        });

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
            () => builder.AddResponsesServer("ResponsesServer"))!;

        Assert.That(exception.Message, Does.Contain("ResponsesServer:Credential"));
        Assert.That(exception.Message, Does.Contain(source));
    }

    [Test]
    public void CodeSuppliedCredentialSource_WithoutProvider_IsNotReplacedByFallback()
    {
        HostApplicationBuilder builder = NewHost(new());

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
            () => builder.AddResponsesServer(
                "ResponsesServer",
                settings => settings.Credential!.CredentialSource = "ManagedIdentityCredential"))!;

        Assert.That(exception.Message, Does.Contain("ResponsesServer:Credential"));
        Assert.That(exception.Message, Does.Contain("managedidentitycredential").IgnoreCase);
    }

    [Test]
    public void BlankConfiguredEndpoint_IsNotReplacedByPlatformEndpoint()
    {
        HostApplicationBuilder builder = NewHost(new()
        {
            ["ResponsesServer:Endpoint"] = string.Empty,
        });

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
            () => builder.AddResponsesServer("ResponsesServer"))!;

        Assert.That(exception.Message, Does.Contain("ResponsesServer:Endpoint"));
    }

    [TestCase(null, "FOUNDRY_PROJECT_ENDPOINT")]
    [TestCase("not a uri", "absolute URI")]
    public void MissingOrInvalidPlatformEndpoint_FailsClearly(string? value, string expected)
    {
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", value);
        FoundryEnvironment.Reload();
        HostApplicationBuilder builder = NewHost(new());

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
            () => builder.AddResponsesServer("ResponsesServer"))!;

        Assert.That(exception.Message, Does.Contain(expected));
    }

    [Test]
    public void PlatformEndpoint_MustUseHttps_OutsideDevelopment_ButNotInDevelopment()
    {
        Environment.SetEnvironmentVariable(
            "FOUNDRY_PROJECT_ENDPOINT",
            "http://platform.example.com/api/projects/platform");
        FoundryEnvironment.Reload();

        HostApplicationBuilder production = NewHost(new());
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
            () => production.AddResponsesServer("ResponsesServer"))!;
        Assert.That(exception.Message, Does.Contain("HTTPS"));

        HostApplicationBuilder development = NewHost(new(), Environments.Development);
        Assert.DoesNotThrow(() => development.AddResponsesServer("ResponsesServer"));
    }

    [TestCase("prod")]
    [TestCase("dev")]
    [TestCase("ManagedIdentityCredential")]
    public void CredentialSelectionVariable_IsHonoredByTheFallback(string selection)
    {
        Environment.SetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS", selection);
        HostApplicationBuilder builder = NewHost(new());

        Assert.DoesNotThrow(() => builder.AddResponsesServer("ResponsesServer"));
    }

    [Test]
    public void InvalidCredentialSelectionVariable_FailsRegistration()
    {
        Environment.SetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS", "bogus");
        HostApplicationBuilder builder = NewHost(new());

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
            () => builder.AddResponsesServer("ResponsesServer"))!;

        Assert.That(exception.Message, Does.Contain("AZURE_TOKEN_CREDENTIALS"));
    }

    [Test]
    public async Task StartupLogger_ReportsFallbackCredential_OnlyWhenUsed()
    {
        var fallbackLogs = new CapturingLoggerProvider();
        HostApplicationBuilder fallback = NewHost(new());
        fallback.Logging.AddProvider(fallbackLogs);
        fallback.AddResponsesServer("ResponsesServer");
        using (ServiceProvider provider = fallback.Services.BuildServiceProvider())
        {
            await ActivatorUtilities.CreateInstance<ResponsesStartupLogger>(provider)
                .StartAsync(CancellationToken.None);
        }

        var configuredLogs = new CapturingLoggerProvider();
        HostApplicationBuilder configured = NewHost(new());
        configured.Logging.AddProvider(configuredLogs);
        configured.AddResponsesServer(
            "ResponsesServer",
            settings => settings.CredentialProvider = new FakeTokenCredential());
        using (ServiceProvider provider = configured.Services.BuildServiceProvider())
        {
            await ActivatorUtilities.CreateInstance<ResponsesStartupLogger>(provider)
                .StartAsync(CancellationToken.None);
        }

        Assert.That(fallbackLogs.Messages.Any(m => m.Contains("fallback credential")), Is.True);
        Assert.That(configuredLogs.Messages.Any(m => m.Contains("fallback credential")), Is.False);
    }

    [Test]
    public async Task StartupLogger_DescribesOperatorSelectedCredentialChain()
    {
        Environment.SetEnvironmentVariable("AZURE_TOKEN_CREDENTIALS", "ManagedIdentityCredential");
        var logs = new CapturingLoggerProvider();
        HostApplicationBuilder builder = NewHost(new());
        builder.Logging.AddProvider(logs);
        builder.AddResponsesServer("ResponsesServer");

        using ServiceProvider provider = builder.Services.BuildServiceProvider();
        await ActivatorUtilities.CreateInstance<ResponsesStartupLogger>(provider)
            .StartAsync(CancellationToken.None);

        Assert.That(
            logs.Messages.Any(m => m.Contains("AZURE_TOKEN_CREDENTIALS='ManagedIdentityCredential'")),
            Is.True);
        Assert.That(
            logs.Messages.Any(m => m.Contains("limited to environment, workload identity")),
            Is.False,
            "The log must not claim the production-only chain when the operator selected one.");
    }

    private static HostApplicationBuilder NewHost(
        Dictionary<string, string?> configuration,
        string environmentName = "Production")
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(
            new HostApplicationBuilderSettings { EnvironmentName = environmentName });
        builder.Configuration.AddInMemoryCollection(configuration);
        builder.Services.AddRouting();
        builder.Services.AddAgentServerCore();
        builder.Services.AddSingleton<ResponseHandler>(new TestHandler());
        return builder;
    }

    private sealed class CapturingLoggerProvider : ILoggerProvider
    {
        public List<string> Messages { get; } = new();

        public ILogger CreateLogger(string categoryName) => new CapturingLogger(Messages);

        public void Dispose()
        {
        }

        private sealed class CapturingLogger : ILogger
        {
            private readonly List<string> _messages;

            public CapturingLogger(List<string> messages) => _messages = messages;

            public IDisposable? BeginScope<TState>(TState state)
                where TState : notnull => null;

            public bool IsEnabled(LogLevel logLevel) => true;

            public void Log<TState>(
                LogLevel logLevel,
                EventId eventId,
                TState state,
                Exception? exception,
                Func<TState, Exception?, string> formatter)
                => _messages.Add(formatter(state, exception));
        }
    }
}
