// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample6_Tier2HostingBuilder.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample6Snippets
    {
        [Test]
        public void BuilderGeneric()
        {
            #region Snippet:Invocations_Sample6_BuilderGeneric

            var builder = AgentHost.CreateBuilder();

            // Register services that the handler depends on.
            builder.Services.AddSingleton<ISummarizationService, OpenAISummarizationService>();

            // Register the Invocations protocol with a concrete handler type.
            builder.AddInvocations<SummarizationHandler>();

            var app = builder.Build();
            app.Run();

            #endregion
        }

        [Test]
        public void BuilderWithFactory()
        {
            #region Snippet:Invocations_Sample6_BuilderWithFactory

            var builder = AgentHost.CreateBuilder();

            // Register services on the builder.
            builder.Services.AddSingleton<ISummarizationService, OpenAISummarizationService>();

            // Use a factory delegate for handler construction.
            builder.AddInvocations(factory: sp =>
            {
                var summarizer = sp.GetRequiredService<ISummarizationService>();
                return new SummarizationHandler(summarizer) { MaxTokens = 2000 };
            });

            // Configuration and tracing work the same way.
            builder.ConfigureTracing(tracing =>
            {
                tracing.AddSource("MyAgent.BusinessLogic");
            });

            builder.ConfigureShutdown(TimeSpan.FromSeconds(15));

            var app = builder.Build();
            app.Run();

            #endregion
        }

        [Test]
        public void Implement_SummarizationHandler()
        {
            var handler = new SummarizationHandler(new OpenAISummarizationService());
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Invocations_Sample6_SummarizationHandler

        public class SummarizationHandler : InvocationHandler
        {
            private readonly ISummarizationService _summarizer;

            public SummarizationHandler(ISummarizationService summarizer) => _summarizer = summarizer;

            public int MaxTokens { get; set; } = 1000;

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
