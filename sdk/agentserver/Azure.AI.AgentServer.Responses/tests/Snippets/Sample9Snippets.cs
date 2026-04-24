// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using Azure.Monitor.OpenTelemetry.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample9_Tier3SelfHosting.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample9Snippets
    {
        [Test]
        public void SelfHost()
        {
            #region Snippet:Responses_Sample9_SelfHost

            var builder = WebApplication.CreateBuilder();

            // Your existing services.
            builder.Services.AddSingleton<IKnowledgeBase, WikiKnowledgeBase>();

            // Core middleware: x-request-id correlation, x-platform-server header, request logging.
            builder.Services.AddAgentServerCore();

            // Responses protocol: services and handler.
            builder.Services.AddResponsesServer();
            builder.Services.AddScoped<ResponseHandler, KnowledgeHandler>();

            // Health probe.
            builder.Services.AddHealthChecks();

            // Observability: Azure Monitor + OpenTelemetry traces and metrics.
            // UseAzureMonitor reads APPLICATIONINSIGHTS_CONNECTION_STRING at runtime.
            builder.Services.AddOpenTelemetry()
                .UseAzureMonitor()
                .WithTracing(tracing =>
                {
                    tracing.AddSource("Azure.AI.AgentServer.Responses");
                })
                .WithMetrics(metrics =>
                {
                    metrics.AddMeter("Azure.AI.AgentServer.Responses");
                });

            var app = builder.Build();

            // Core middleware pipeline.
            app.UseAgentServerCore();

            // Health probe endpoint.
            app.MapHealthChecks("/readiness");

            // Your existing endpoints.
            app.MapGet("/", () => "My existing app");

            // Responses protocol endpoints.
            app.MapResponsesServer();

            app.Run();

            #endregion
        }

        [Test]
        public void Implement_KnowledgeHandler()
        {
            var handler = new KnowledgeHandler(new WikiKnowledgeBase());
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample9_KnowledgeHandler

        public class KnowledgeHandler : ResponseHandler
        {
            private readonly IKnowledgeBase _kb;

            public KnowledgeHandler(IKnowledgeBase kb) => _kb = kb;

            public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                CancellationToken cancellationToken)
            {
                return new TextResponse(context, request,
                    createText: async ct =>
                    {
                        var question = await context.GetInputTextAsync(cancellationToken: ct);
                        return await _kb.SearchAsync(question, ct);
                    });
            }
        }

        #endregion

        // Supporting types for the sample.

        public interface IKnowledgeBase
        {
            Task<string> SearchAsync(string query, CancellationToken cancellationToken);
        }

        public class WikiKnowledgeBase : IKnowledgeBase
        {
            public Task<string> SearchAsync(string query, CancellationToken cancellationToken) =>
                Task.FromResult($"Here is what I found about \"{query}\": [mock knowledge base result]");
        }
    }
}
