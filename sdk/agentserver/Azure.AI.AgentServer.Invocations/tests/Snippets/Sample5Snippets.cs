// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample5_Tier1HostingCustomize.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample5Snippets
    {
        [Test]
        public void CustomServices()
        {
            #region Snippet:Invocations_Sample5_CustomServices

            InvocationsServer.Run<SummarizationHandler>(configure: builder =>
            {
                builder.Services.AddSingleton<ISummarizationService, OpenAISummarizationService>();
            });

            #endregion
        }

        [Test]
        public void FactoryDelegate()
        {
            #region Snippet:Invocations_Sample5_FactoryDelegate

            InvocationsServer.Run(
                factory: sp =>
                {
                    var summarizer = sp.GetRequiredService<ISummarizationService>();
                    var maxTokens = int.Parse(
                        sp.GetRequiredService<IConfiguration>()["MaxTokens"] ?? "1000");
                    return new SummarizationHandler(summarizer) { MaxTokens = maxTokens };
                },
                configure: builder =>
                {
                    builder.Services.AddSingleton<ISummarizationService, OpenAISummarizationService>();
                });

            #endregion
        }

        [Test]
        public void ConfigAndTracing()
        {
            #region Snippet:Invocations_Sample5_ConfigAndTracing

            InvocationsServer.Run<SummarizationHandler>(configure: builder =>
            {
                // Register custom services.
                builder.Services.AddSingleton<ISummarizationService, OpenAISummarizationService>();

                // Read typed configuration from appsettings.json or environment variables.
                builder.Services.Configure<SummarizationOptions>(
                    builder.Configuration.GetSection("Summarization"));

                // Add a custom OpenTelemetry tracing source.
                builder.ConfigureTracing(tracing =>
                {
                    tracing.AddSource("MyAgent.BusinessLogic");
                });

                // Set a custom shutdown timeout (default is 30s).
                builder.ConfigureShutdown(TimeSpan.FromSeconds(10));
            });

            #endregion
        }

        [Test]
        public void WebAppAccess()
        {
            #region Snippet:Invocations_Sample5_WebAppAccess

            InvocationsServer.Run<SummarizationHandler>(configure: builder =>
            {
                builder.Services.AddSingleton<ISummarizationService, OpenAISummarizationService>();

                // Add CORS support at the ASP.NET Core level.
                builder.WebApplicationBuilder.Services.AddCors(cors =>
                {
                    cors.AddDefaultPolicy(policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
                });
            });

            #endregion
        }

        [Test]
        public void Implement_SummarizationHandler()
        {
            var handler = new SummarizationHandler(new OpenAISummarizationService());
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Invocations_Sample5_SummarizationHandler

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

                // Use the injected service to produce the summary.
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

        public class SummarizationOptions
        {
            public string? ModelId { get; set; }
            public int MaxTokens { get; set; } = 1000;
        }
    }
}
