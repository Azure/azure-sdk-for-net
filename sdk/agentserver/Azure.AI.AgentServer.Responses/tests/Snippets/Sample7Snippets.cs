// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample7_Tier3SelfHosted.md (Tier 3). Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample7Snippets
    {
        [Test]
        public void SelfHost()
        {
            #region Snippet:Responses_Sample7_SelfHost

            var builder = WebApplication.CreateBuilder();

            // Your existing services.
            builder.Services.AddSingleton<IKnowledgeBase, WikiKnowledgeBase>();

            // Register the Responses SDK services and your handler.
            builder.Services.AddResponsesServer();
            builder.Services.AddScoped<ResponseHandler, KnowledgeHandler>();

            var app = builder.Build();

            // Your existing endpoints.
            app.MapGet("/", () => "My existing app");
            app.MapGet("/healthy", () => Results.Ok());

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

        #region Snippet:Responses_Sample7_KnowledgeHandler

        public class KnowledgeHandler : ResponseHandler
        {
            private readonly IKnowledgeBase _kb;

            public KnowledgeHandler(IKnowledgeBase kb) => _kb = kb;

            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var stream = new ResponseEventStream(context, request);

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                var message = stream.AddOutputItemMessage();
                yield return message.EmitAdded();

                var text = message.AddTextContent();
                yield return text.EmitAdded();

                var question = request.GetInputText();
                var answer = await _kb.SearchAsync(question, cancellationToken);

                yield return text.EmitDelta(answer);
                yield return text.EmitDone(answer);

                yield return message.EmitContentDone(text);
                yield return message.EmitDone();
                yield return stream.EmitCompleted();
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
