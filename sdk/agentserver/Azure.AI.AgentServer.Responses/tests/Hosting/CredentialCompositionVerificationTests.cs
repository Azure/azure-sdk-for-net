// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Providers.Hosted;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Hosting;

[TestFixture]
[NonParallelizable]
public class CredentialCompositionVerificationTests
{
    private readonly Dictionary<string, string?> _previousEnvironment = new();

    [SetUp]
    public void SetUp()
    {
        foreach (var pair in new Dictionary<string, string>
        {
            ["FOUNDRY_HOSTING_ENVIRONMENT"] = "Production",
            ["FOUNDRY_PROJECT_ENDPOINT"] = "https://example.com/project",
            ["FOUNDRY_AGENT_NAME"] = "credential-verification",
            ["FOUNDRY_AGENT_VERSION"] = "1",
        })
        {
            _previousEnvironment[pair.Key] = Environment.GetEnvironmentVariable(pair.Key);
            Environment.SetEnvironmentVariable(pair.Key, pair.Value);
        }

        FoundryEnvironment.Reload();
        Assert.That(FoundryEnvironment.IsHosted, Is.True);
    }

    [TearDown]
    public void TearDown()
    {
        foreach (var pair in _previousEnvironment)
        {
            Environment.SetEnvironmentVariable(pair.Key, pair.Value);
        }

        _previousEnvironment.Clear();
        FoundryEnvironment.Reload();
    }

    [Test]
    public void KeyedOnlyDoesNotSuppressHostedDefault(
        [Values(false, true)] bool keyedFirst,
        [Values(false, true)] bool factory,
        [Values(false, true)] bool wildcard)
    {
        var services = CreateServices();
        var keyedCredential = new ProbeCredential();
        object registrationKey = wildcard ? KeyedService.AnyKey : "secondary";
        int keyedCalls = 0;
        void RegisterKeyed()
        {
            if (factory)
            {
                services.AddKeyedSingleton<TokenCredential>(
                    registrationKey,
                    (_, _) => { keyedCalls++; return keyedCredential; });
            }
            else
            {
                services.AddKeyedSingleton<TokenCredential>(registrationKey, keyedCredential);
            }
        }

        if (keyedFirst)
        {
            RegisterKeyed();
        }

        services.AddResponsesServer();
        if (!keyedFirst)
        {
            RegisterKeyed();
        }

        using ServiceProvider provider = services.BuildServiceProvider(validateScopes: true);
        TokenCredential actual = AssertHostedConsumers(provider);
        Assert.That(actual, Is.InstanceOf<DefaultAzureCredential>());
        Assert.That(keyedCalls, Is.Zero);
        Assert.That(provider.GetRequiredKeyedService<TokenCredential>("secondary"), Is.SameAs(keyedCredential));
        Assert.That(keyedCalls, Is.EqualTo(factory ? 1 : 0));
        Assert.That(keyedCredential.TokenCalls, Is.Zero);
    }

    [Test]
    public void ExplicitCredentialReplacesOnlyDefaultInEveryOrder(
        [Values("KRE", "KER", "RKE", "REK", "EKR", "ERK")] string order,
        [Values(false, true)] bool factory)
    {
        var services = CreateServices();
        var keyedCredential = new ProbeCredential();
        var explicitCredential = new ProbeCredential();
        int keyedCalls = 0;
        foreach (char step in order)
        {
            switch (step)
            {
                case 'K':
                    if (factory)
                    {
                        services.AddKeyedSingleton<TokenCredential>(
                            "secondary",
                            (_, _) => { keyedCalls++; return keyedCredential; });
                    }
                    else
                    {
                        services.AddKeyedSingleton<TokenCredential>("secondary", keyedCredential);
                    }
                    break;
                case 'R':
                    services.AddResponsesServer();
                    break;
                case 'E':
                    services.AddResilientTasks(explicitCredential);
                    break;
            }
        }

        using ServiceProvider provider = services.BuildServiceProvider(validateScopes: true);
        Assert.That(AssertHostedConsumers(provider), Is.SameAs(explicitCredential));
        Assert.That(keyedCalls, Is.Zero);
        Assert.That(provider.GetRequiredKeyedService<TokenCredential>("secondary"), Is.SameAs(keyedCredential));
        Assert.That(services.Count(d => d.ServiceType == typeof(TokenCredential) && !d.IsKeyedService), Is.EqualTo(1));
        Assert.That(explicitCredential.TokenCalls, Is.Zero);
    }

    [Test]
    public void ConsumerUnkeyedRegistrationRemainsAuthoritative(
        [Values("KRC", "KCR", "RKC", "RCK", "CKR", "CRK")] string order,
        [Values("instance", "factory", "type")] string registration)
    {
        var services = CreateServices();
        var consumerCredential = new ProbeCredential();
        var keyedCredential = new ProbeCredential();
        int consumerCalls = 0;
        int keyedCalls = 0;
        foreach (char step in order)
        {
            switch (step)
            {
                case 'K':
                    services.AddKeyedSingleton<TokenCredential>(
                        "secondary",
                        (_, _) => { keyedCalls++; return keyedCredential; });
                    break;
                case 'R':
                    services.AddResponsesServer();
                    break;
                case 'C':
                    if (registration == "instance")
                    {
                        services.AddSingleton<TokenCredential>(consumerCredential);
                    }
                    else if (registration == "factory")
                    {
                        services.AddSingleton<TokenCredential>(_ => { consumerCalls++; return consumerCredential; });
                    }
                    else
                    {
                        services.AddSingleton<TokenCredential, ProbeCredential>();
                    }
                    break;
            }
        }

        ServiceDescriptor[] before = services.Where(d => d.ServiceType == typeof(TokenCredential)).ToArray();
        services.AddResilientTaskCredentialDefault(_ => throw new InvalidOperationException("Unexpected fallback."));
        Assert.That(services.Where(d => d.ServiceType == typeof(TokenCredential)), Is.EqualTo(before));
        using ServiceProvider provider = services.BuildServiceProvider(validateScopes: true);
        TokenCredential actual = AssertHostedConsumers(provider);
        Assert.That(actual, Is.InstanceOf<ProbeCredential>());
        if (registration != "type")
        {
            Assert.That(actual, Is.SameAs(consumerCredential));
        }

        Assert.That(consumerCalls, Is.EqualTo(registration == "factory" ? 1 : 0));
        Assert.That(keyedCalls, Is.Zero);
        Assert.That(((ProbeCredential)actual).TokenCalls, Is.Zero);
    }

    [Test]
    public void UnkeyedConflictIsNotHiddenByKeyedRegistration(
        [Values("CRE", "CER", "RCE", "REC", "ECR", "ERC")] string order,
        [Values(false, true)] bool factory)
    {
        var services = CreateServices();
        services.AddKeyedSingleton<TokenCredential>("secondary", new ProbeCredential());
        var explicitCredential = new ProbeCredential();
        var consumerCredential = new ProbeCredential();
        foreach (char step in order)
        {
            switch (step)
            {
                case 'C':
                    if (factory)
                    {
                        services.AddSingleton<TokenCredential>(_ => consumerCredential);
                    }
                    else
                    {
                        services.AddSingleton<TokenCredential>(consumerCredential);
                    }
                    break;
                case 'R':
                    services.AddResponsesServer();
                    break;
                case 'E':
                    services.AddResilientTasks(explicitCredential);
                    break;
            }
        }

        using ServiceProvider provider = services.BuildServiceProvider();
        Assert.That(provider.GetRequiredService<TokenCredential>(), Is.SameAs(consumerCredential));
        Assert.That(provider.GetRequiredService<HttpPipeline>(), Is.Not.Null);
        Assert.That(
            () => provider.GetRequiredService<ITaskStore>(),
            Throws.InvalidOperationException.With.Message.Contains("different TokenCredential"));
    }

    [Test]
    public void NullKeyIsTreatedAsAnUnkeyedCredential([Values(false, true)] bool registeredFirst)
    {
        var services = CreateServices();
        var credential = new ProbeCredential();
        if (!registeredFirst)
        {
            services.AddResponsesServer();
        }

        services.AddKeyedSingleton<TokenCredential>(null, credential);
        Assert.That(services.Last().IsKeyedService, Is.False);
        if (registeredFirst)
        {
            services.AddResponsesServer();
        }

        int descriptorCount = services.Count(d => d.ServiceType == typeof(TokenCredential));
        services.AddResilientTasks(credential);
        services.AddResilientTaskCredentialDefault(_ => throw new InvalidOperationException("Unexpected fallback."));
        Assert.That(services.Count(d => d.ServiceType == typeof(TokenCredential)), Is.EqualTo(descriptorCount));
        using ServiceProvider provider = services.BuildServiceProvider();
        Assert.That(AssertHostedConsumers(provider), Is.SameAs(credential));
    }

    [Test]
    public void RepeatedDefaultAndExplicitCallsAreIdempotent()
    {
        var services = CreateServices();
        var credential = new ProbeCredential();
        int fallbackCalls = 0;
        int keyedCalls = 0;
        services.AddKeyedSingleton<TokenCredential>(
            "secondary",
            (_, _) => { keyedCalls++; return new ProbeCredential(); });
        for (int i = 0; i < 3; i++)
        {
            services.AddResilientTaskCredentialDefault(_ => { fallbackCalls++; return new ProbeCredential(); });
        }

        Assert.That(services.Count(d => d.ServiceType == typeof(TokenCredential) && !d.IsKeyedService), Is.EqualTo(1));
        services.AddResponsesServer();
        for (int i = 0; i < 3; i++)
        {
            services.AddResilientTasks(credential);
            services.AddResilientTaskCredentialDefault(_ => { fallbackCalls++; return new ProbeCredential(); });
        }

        using ServiceProvider provider = services.BuildServiceProvider();
        Assert.That(AssertHostedConsumers(provider), Is.SameAs(credential));
        Assert.That(fallbackCalls, Is.Zero);
        Assert.That(keyedCalls, Is.Zero);
        Assert.That(services.Count(d => d.ServiceType == typeof(TokenCredential) && !d.IsKeyedService), Is.EqualTo(1));
    }

    [Test]
    public void AKeyedScopedCredentialIsNotResolvedFromRoot()
    {
        var services = CreateServices();
        var credential = new ProbeCredential();
        int calls = 0;
        services.AddKeyedScoped<TokenCredential>("secondary", (_, _) => { calls++; return credential; });
        services.AddResponsesServer();
        using ServiceProvider provider = services.BuildServiceProvider(validateScopes: true);
        Assert.That(AssertHostedConsumers(provider), Is.InstanceOf<DefaultAzureCredential>());
        Assert.That(calls, Is.Zero);
        using IServiceScope scope = provider.CreateScope();
        Assert.That(scope.ServiceProvider.GetRequiredKeyedService<TokenCredential>("secondary"), Is.SameAs(credential));
        Assert.That(calls, Is.EqualTo(1));
    }

    private static ServiceCollection CreateServices()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        return services;
    }

    private static TokenCredential AssertHostedConsumers(ServiceProvider provider)
    {
        Assert.That(provider.GetRequiredService<HttpPipeline>(), Is.Not.Null);
        Assert.That(provider.GetRequiredService<ITaskStore>(), Is.InstanceOf<HostedTaskStore>());
        TokenCredential credential = provider.GetRequiredService<TokenCredential>();
        Assert.That(provider.GetRequiredService<TaskHostEnvironment>().Credential, Is.SameAs(credential));
        return credential;
    }

    public sealed class ProbeCredential : TokenCredential
    {
        public int TokenCalls { get; private set; }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            TokenCalls++;
            throw new InvalidOperationException("No test should request a token or contact Azure.");
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            TokenCalls++;
            throw new InvalidOperationException("No test should request a token or contact Azure.");
        }
    }
}
