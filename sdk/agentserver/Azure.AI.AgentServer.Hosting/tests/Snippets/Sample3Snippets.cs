// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Hosting.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Hosting Sample3_SelfHosted.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample3Snippets
    {
        [Test]
        public void SelfHostSetup()
        {
            #region Snippet:Hosting_Sample3_SelfHost

#if SNIPPET
            var builder = WebApplication.CreateBuilder(args);
#else
            var builder = WebApplication.CreateBuilder();
#endif

            // Your existing services.
            builder.Services.AddSingleton<MyExistingService>();

            // Register the Invocations SDK services and your handler.
            builder.Services.AddInvocationsServer();
            builder.Services.AddScoped<InvocationHandler, SummaryHandler>();

#if SNIPPET
            // Set up OpenTelemetry yourself — the Hosting framework is not involved.
            builder.Services.AddOpenTelemetry()
                .WithTracing(tracing => tracing
                    .AddAspNetCoreInstrumentation()
                    .AddSource("Azure.AI.AgentServer.Invocations"));
#endif

            var app = builder.Build();

            // Your existing endpoints.
            app.MapGet("/", () => "My existing app");
            app.MapGet("/healthy", () => Results.Ok());

            // Map the Invocations protocol endpoints.
            app.MapInvocationsServer();

            app.Run();

            #endregion
        }

        [Test]
        public void Implement_SummaryHandler()
        {
            var handler = new SummaryHandler();
            Assert.That(handler, Is.Not.Null);
        }

        // Helper type for self-hosted snippet.
        public class MyExistingService { }

        #region Snippet:Hosting_Sample3_SummaryHandler

        public class SummaryHandler : InvocationHandler
        {
            public override async Task HandleAsync(
                HttpRequest request,
                HttpResponse response,
                InvocationContext context,
                CancellationToken cancellationToken)
            {
                var input = await request.ReadFromJsonAsync<SummaryInput>(cancellationToken);
                var text = input?.Text ?? "";

                // In a real agent, call a summarization model here.
                var summary = text.Length > 100
                    ? text[..100] + "..."
                    : text;

                await response.WriteAsJsonAsync(new
                {
                    invocation_id = context.InvocationId,
                    summary,
                    original_length = text.Length
                }, cancellationToken);
            }
        }

        public record SummaryInput(string Text);

        #endregion
    }
}
