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
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Hosting;

[TestFixture]
[NonParallelizable]
public class CredentialSettingsIsolationTests
{
    private readonly Dictionary<string, string?> _previousEnvironment = new();

    [SetUp]
    public void SetUp()
    {
        foreach (var pair in new Dictionary<string, string>
        {
            ["FOUNDRY_HOSTING_ENVIRONMENT"] = "Production",
            ["FOUNDRY_PROJECT_ENDPOINT"] = "https://environment.example/project",
            ["FOUNDRY_AGENT_NAME"] = "credential-isolation",
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
    public void ExplicitHostedSettingsRemainIsolated(
        [Values("none", "keyed", "unkeyed", "both")] string ambientKind,
        [Values(false, true)] bool ambientFirst)
    {
        var services = new ServiceCollection();
        services.AddLogging();
        var credential = new ProbeCredential();
        var ambient = new ProbeCredential();
        var endpoint = new Uri("https://configured.example/project");
        var storage = new ResponsesHostedStorage(
            credential,
            endpoint,
            ResponsesServerServiceCollectionExtensions.ResolveStorageBaseUri(
                endpoint,
                isDevelopment: false));
        int keyedCalls = 0;
        int unkeyedCalls = 0;

        void AddAmbient()
        {
            if (ambientKind is "keyed" or "both")
            {
                services.AddKeyedSingleton<TokenCredential>(
                    "other",
                    (_, _) => { keyedCalls++; return ambient; });
            }

            if (ambientKind is "unkeyed" or "both")
            {
                services.AddSingleton<TokenCredential>(_ => { unkeyedCalls++; return ambient; });
            }
        }

        if (ambientFirst)
        {
            AddAmbient();
        }

        services.AddResponsesServerCore(o => o.ResilientBackground = true, storage);
        if (!ambientFirst)
        {
            AddAmbient();
        }

        services.AddResilientTasks(credential, endpoint);
        services.AddResilientTasks(credential, endpoint);
        Assert.That(
            services.Count(d => d.ServiceType == typeof(TokenCredential) && !d.IsKeyedService),
            Is.EqualTo(ambientKind is "unkeyed" or "both" ? 1 : 0));
        Assert.That(
            services.Count(d => d.ServiceType == typeof(TokenCredential) && d.IsKeyedService),
            Is.EqualTo(ambientKind is "keyed" or "both" ? 1 : 0));

        using ServiceProvider provider = services.BuildServiceProvider(validateScopes: true);
        Assert.That(provider.GetRequiredService<HttpPipeline>(), Is.Not.Null);
        Assert.That(provider.GetRequiredService<ITaskStore>(), Is.InstanceOf<HostedTaskStore>());
        var environment = provider.GetRequiredService<TaskHostEnvironment>();
        Assert.That(environment.Credential, Is.SameAs(credential));
        Assert.That(environment.Endpoint, Is.EqualTo(endpoint));
        Assert.That(keyedCalls, Is.Zero);
        Assert.That(unkeyedCalls, Is.Zero);
    }

    private sealed class ProbeCredential : TokenCredential
    {
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => throw new InvalidOperationException("No test should request a token or contact Azure.");

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => throw new InvalidOperationException("No test should request a token or contact Azure.");
    }
}
