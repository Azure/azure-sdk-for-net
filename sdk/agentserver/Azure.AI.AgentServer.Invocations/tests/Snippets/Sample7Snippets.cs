// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

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

            // Register the Invocations SDK services and your handler.
            builder.Services.AddInvocationsServer();
            builder.Services.AddScoped<InvocationHandler, SummarizationHandler>();

            var app = builder.Build();

            // Your existing endpoints.
            app.MapGet("/", () => "My existing app");
            app.MapGet("/readiness", () => Results.Ok());

            // Map the Invocations protocol endpoints.
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
