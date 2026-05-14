// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

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

            // Register the Responses SDK services and your handler.
            builder.Services.AddResponsesServer();
            builder.Services.AddScoped<ResponseHandler, KnowledgeHandler>();

            var app = builder.Build();

            // Your existing endpoints.
            app.MapGet("/", () => "My existing app");
            app.MapGet("/readiness", () => Results.Ok());

            // Map the Responses protocol endpoints.
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
