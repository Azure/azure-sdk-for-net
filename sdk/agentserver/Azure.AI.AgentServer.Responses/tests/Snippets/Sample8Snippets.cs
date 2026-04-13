// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample8_Tier2HostingBuilder.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample8Snippets
    {
        [Test]
        public void BuilderGeneric()
        {
            #region Snippet:Responses_Sample8_BuilderGeneric

            var builder = AgentHost.CreateBuilder();

            // Register services that the handler depends on.
            builder.Services.AddSingleton<IKnowledgeBase, WikiKnowledgeBase>();

            // Register the Responses protocol with a concrete handler type.
            builder.AddResponses<KnowledgeHandler>();

            var app = builder.Build();
            app.Run();

            #endregion
        }

        [Test]
        public void BuilderWithFactory()
        {
            #region Snippet:Responses_Sample8_BuilderWithFactory

            var builder = AgentHost.CreateBuilder();

            // Register services on the builder.
            builder.Services.AddSingleton<IKnowledgeBase, WikiKnowledgeBase>();

            // Use a factory delegate for handler construction.
            builder.AddResponses(factory: sp =>
            {
                var kb = sp.GetRequiredService<IKnowledgeBase>();
                return new KnowledgeHandler(kb);
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
        public void Implement_KnowledgeHandler()
        {
            var handler = new KnowledgeHandler(new WikiKnowledgeBase());
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample8_KnowledgeHandler

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
