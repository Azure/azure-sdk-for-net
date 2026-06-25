// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Optimization;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Configuration.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing the Configuration README.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require optimization env vars to execute.")]
    public class ReadMeSnippets
    {
        [Test]
        public void SingleAgent()
        {
            #region Snippet:Configuration_ReadMe_SingleAgent
            IConfiguration configuration = new ConfigurationBuilder()
                .AddOptimizationConfigSource()
                .Build();

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton(configuration);
            services.Configure<OptimizationOptions>(opts =>
                configuration.GetSection("Agent").Bind(opts));

            using ServiceProvider provider = services.BuildServiceProvider();
            OptimizationOptions options = provider.GetRequiredService<IOptions<OptimizationOptions>>().Value;

            Console.WriteLine($"Source: {options.Source}");
            Console.WriteLine($"Model: {options.Model}");
            Console.WriteLine($"Instructions: {options.Instructions}");
            #endregion
        }

        [Test]
        public void MultiAgent()
        {
            #region Snippet:Configuration_ReadMe_MultiAgent
            IConfiguration configuration = new ConfigurationBuilder()
                .AddOptimizationConfigSource("triage-agent")
                .AddOptimizationConfigSource("billing-agent")
                .Build();

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton(configuration);

            // Named-options registrations — one per agent key.
            services.Configure<OptimizationOptions>("triage-agent", opts =>
                configuration.GetSection("Agents:triage-agent").Bind(opts));
            services.Configure<OptimizationOptions>("billing-agent", opts =>
                configuration.GetSection("Agents:billing-agent").Bind(opts));

            using ServiceProvider provider = services.BuildServiceProvider();
            IOptionsSnapshot<OptimizationOptions> snapshot =
                provider.CreateScope().ServiceProvider
                    .GetRequiredService<IOptionsSnapshot<OptimizationOptions>>();

            OptimizationOptions triage = snapshot.Get("triage-agent");
            OptimizationOptions billing = snapshot.Get("billing-agent");
            #endregion

            Assert.That(triage, Is.Not.Null);
            Assert.That(billing, Is.Not.Null);
        }

        [Test]
        public void ConfigureOptions()
        {
            #region Snippet:Configuration_ReadMe_ConfigureOptions
            IConfiguration configuration = new ConfigurationBuilder()
                .AddOptimizationConfigSource(options =>
                {
                    // Authenticate the resolver API call with any Azure.Core
                    // TokenCredential (e.g. DefaultAzureCredential).
                    options.Credential = ResolveMyCredential();

                    options.ResolverTimeout = TimeSpan.FromSeconds(10);
                    options.StrictMode = true;    // rethrow resolver/parse errors
                    options.FailOnEmpty = true;   // throw when no source matches
                })
                .Build();
            #endregion

            Assert.That(configuration, Is.Not.Null);
        }

        [Test]
        public void WithoutDI()
        {
            #region Snippet:Configuration_ReadMe_WithoutDI
            // No DI container — just build IConfiguration and bind to a POCO.
            IConfiguration configuration = new ConfigurationBuilder()
                .AddOptimizationConfigSource()
                .Build();

            OptimizationOptions options = configuration.GetOptimizationOptions();

            if (options.Source is not null)
            {
                Console.WriteLine($"Loaded from: {options.Source}");
            }
            #endregion

            Assert.That(options, Is.Not.Null);
        }

        [Test]
        public void DirectLoader()
        {
            #region Snippet:Configuration_ReadMe_DirectLoader
            // Skip Microsoft.Extensions.Configuration entirely and call the client
            // directly. Useful for console apps, AWS Lambdas, or anywhere you do
            // not have an IConfiguration pipeline.
            AgentOptimizationClient client = new(new Uri("https://my-project.services.ai.azure.com/api/projects/my-project"), ResolveMyCredential());
            OptimizationOptions options = client.ResolveOptions();

            if (options is not null)
            {
                Console.WriteLine($"Source: {options.Source}");
            }
            #endregion
        }

        private static TokenCredential ResolveMyCredential() => new NoOpCredential();

        private sealed class NoOpCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                throw new NotImplementedException();

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                throw new NotImplementedException();
        }
    }
}
