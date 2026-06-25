// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Optimization;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            CandidateDeployConfig? config = configuration.GetOptimizationConfig();

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton(configuration);
            if (config is not null)
            {
                services.AddSingleton(config);
            }

            using ServiceProvider provider = services.BuildServiceProvider();
            CandidateDeployConfig? options = provider.GetService<CandidateDeployConfig>();

            Console.WriteLine($"Model: {options?.Model}");
            Console.WriteLine($"Instructions: {options?.Instructions}");
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
            CandidateDeployConfig? triage = configuration.GetOptimizationConfig("triage-agent");
            CandidateDeployConfig? billing = configuration.GetOptimizationConfig("billing-agent");
            #endregion

            Assert.That(services, Is.Not.Null);
        }

        [Test]
        public void ConfigureOptions()
        {
            #region Snippet:Configuration_ReadMe_ConfigureOptions
            IConfiguration configuration = new ConfigurationBuilder()
                .AddOptimizationConfigSource(options =>
                {
                    options.SectionName = "MyAgent";
                    options.FailOnEmpty = true;
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

            CandidateDeployConfig? options = configuration.GetOptimizationConfig();

            if (options is not null)
            {
                Console.WriteLine($"Loaded model: {options.Model}");
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
            string candidateId = Environment.GetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID");
            CandidateDeployConfig? options = client.ResolveOptions(candidateId);

            if (options is not null)
            {
                Console.WriteLine($"Model: {options.Model}");
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
