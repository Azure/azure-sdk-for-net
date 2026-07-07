// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample7_Tier1HostingCustomize.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample7Snippets
    {
        [Test]
        public void CustomServices()
        {
            #region Snippet:Responses_Sample7_CustomServices

            ResponsesServer.Run<KnowledgeHandler>(configure: builder =>
            {
                builder.Services.AddSingleton<IKnowledgeBase, WikiKnowledgeBase>();
            });

            #endregion
        }

        [Test]
        public void FactoryDelegate()
        {
            #region Snippet:Responses_Sample7_FactoryDelegate

            ResponsesServer.Run(
                factory: sp =>
                {
                    var kb = sp.GetRequiredService<IKnowledgeBase>();
                    return new KnowledgeHandler(kb);
                },
                configure: builder =>
                {
                    builder.Services.AddSingleton<IKnowledgeBase, WikiKnowledgeBase>();
                });

            #endregion
        }

        [Test]
        public void ConfigAndTracing()
        {
            #region Snippet:Responses_Sample7_ConfigAndTracing

            ResponsesServer.Run<KnowledgeHandler>(configure: builder =>
            {
                // Register custom services.
                builder.Services.AddSingleton<IKnowledgeBase, WikiKnowledgeBase>();

                // Read typed configuration from appsettings.json or environment variables.
                builder.Services.Configure<KnowledgeBaseOptions>(
                    builder.Configuration.GetSection("KnowledgeBase"));

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
            #region Snippet:Responses_Sample7_WebAppAccess

            ResponsesServer.Run<KnowledgeHandler>(configure: builder =>
            {
                builder.Services.AddSingleton<IKnowledgeBase, WikiKnowledgeBase>();

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
        public void Implement_KnowledgeHandler()
        {
            var handler = new KnowledgeHandler(new WikiKnowledgeBase());
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample7_KnowledgeHandler

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

        public class KnowledgeBaseOptions
        {
            public string? IndexName { get; set; }
            public int MaxResults { get; set; } = 5;
        }
    }
}
