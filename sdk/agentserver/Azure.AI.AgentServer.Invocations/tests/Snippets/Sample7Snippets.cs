// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations;
using Azure.Monitor.OpenTelemetry.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Invocations.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample7_Tier3SelfHosting.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample7Snippets
    {
        [Test]
        public void SelfHost()
        {
            #region Snippet:Invocations_Sample7_SelfHost

            var builder = WebApplication.CreateBuilder();

            // Your existing services.
            builder.Services.AddSingleton<ISummarizationService, OpenAISummarizationService>();

            // Core middleware: x-request-id correlation, x-platform-server header, request logging.
            builder.Services.AddAgentServerCore();

            // Invocations protocol: services and handler.
            builder.Services.AddInvocationsServer();
            builder.Services.AddScoped<InvocationHandler, SummarizationHandler>();

            // Health probe.
            builder.Services.AddHealthChecks();

            // Observability: Azure Monitor + OpenTelemetry traces and metrics.
            // UseAzureMonitor reads APPLICATIONINSIGHTS_CONNECTION_STRING at runtime.
            builder.Services.AddOpenTelemetry()
                .UseAzureMonitor()
                .WithTracing(tracing =>
                {
                    tracing.AddSource("Azure.AI.AgentServer.Invocations");
                })
                .WithMetrics(metrics =>
                {
                    metrics.AddMeter("Azure.AI.AgentServer.Invocations");
                });

            var app = builder.Build();

            // Core middleware pipeline.
            app.UseAgentServerCore();

            // Health probe endpoint.
            app.MapHealthChecks("/readiness");

            // Your existing endpoints.
            app.MapGet("/", () => "My existing app");

            // Invocations protocol endpoints.
            app.MapInvocationsServer();

            app.Run();

            #endregion
        }

        [Test]
        public void Implement_SummarizationHandler()
        {
            var handler = new SummarizationHandler(new OpenAISummarizationService());
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Invocations_Sample7_SummarizationHandler

        public class SummarizationHandler : InvocationHandler
        {
            private readonly ISummarizationService _summarizer;

            public SummarizationHandler(ISummarizationService summarizer) => _summarizer = summarizer;

            public override async Task HandleAsync(
                HttpRequest request, HttpResponse response,
                InvocationContext context, CancellationToken cancellationToken)
            {
                var input = await new StreamReader(request.Body).ReadToEndAsync(cancellationToken);

                var summary = await _summarizer.SummarizeAsync(input, cancellationToken);

                response.ContentType = "application/json";
                await response.WriteAsJsonAsync(new
                {
                    invocation_id = context.InvocationId,
                    session_id = context.SessionId,
                    summary
                }, cancellationToken);
            }
        }

        #endregion

        // Supporting types for the sample.

        public interface ISummarizationService
        {
            Task<string> SummarizeAsync(string input, CancellationToken cancellationToken);
        }

        public class OpenAISummarizationService : ISummarizationService
        {
            public Task<string> SummarizeAsync(string input, CancellationToken cancellationToken) =>
                Task.FromResult($"Summary of ({input.Length} chars): {(input.Length > 50 ? input[..50] + "..." : input)}");
        }
    }
}
