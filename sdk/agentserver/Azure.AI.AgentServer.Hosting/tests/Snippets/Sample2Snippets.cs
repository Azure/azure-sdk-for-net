// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Hosting;
using Azure.AI.AgentServer.Invocations;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Hosting.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Hosting Sample2_MultiProtocol.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample2Snippets
    {
        [Test]
        public void ComposeProtocols()
        {
            #region Snippet:Hosting_Sample2_Compose

#if SNIPPET
            using Azure.AI.AgentServer.Invocations;
            using Azure.AI.AgentServer.Responses;

            var builder = AgentHost.CreateBuilder(args);
#else
            var builder = AgentHost.CreateBuilder();
#endif

            // Register the Responses protocol for streaming chat.
            builder.AddResponses<ChatHandler>();

            // Register the Invocations protocol for ticket submission.
            builder.AddInvocations<TicketHandler>();

            // Customize health checks — add a readiness check for the knowledge base.
#if SNIPPET
            builder.ConfigureHealth(health =>
            {
                health.AddCheck("knowledge_base", () =>
                    HealthCheckResult.Healthy());
            });
#endif

            // Add a custom tracing source for your business logic.
            builder.ConfigureTracing(tracing =>
            {
                tracing.AddSource("CustomerSupport.BusinessLogic");
            });

            var app = builder.Build();
            app.Run();

            #endregion
        }

        [Test]
        public void Implement_Handlers()
        {
            var chat = new ChatHandler();
            Assert.That(chat, Is.Not.Null);
            var ticket = new TicketHandler();
            Assert.That(ticket, Is.Not.Null);
        }

        #region Snippet:Hosting_Sample2_ChatHandler

        public class ChatHandler : IResponseHandler
        {
            public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                IResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var stream = new ResponseEventStream(context, request);
                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                var message = stream.AddOutputItemMessage();
                yield return message.EmitAdded();

                var text = message.AddTextContent();
                yield return text.EmitAdded();

                var reply = "Hello! I'm the support agent. How can I help you today?";
                yield return text.EmitDelta(reply);
                yield return text.EmitDone(reply);

                yield return message.EmitContentDone(text);
                yield return message.EmitDone();
                yield return stream.EmitCompleted();
            }
        }

        #endregion

        #region Snippet:Hosting_Sample2_TicketHandler

        public class TicketHandler : InvocationHandler
        {
            public override async Task HandleAsync(
                HttpRequest request,
                HttpResponse response,
                InvocationContext context,
                CancellationToken cancellationToken)
            {
                var ticket = await request.ReadFromJsonAsync<TicketInput>(cancellationToken);

                await response.WriteAsJsonAsync(new
                {
                    ticket_id = context.InvocationId,
                    subject = ticket?.Subject,
                    status = "created"
                }, cancellationToken);
            }
        }

        public record TicketInput(string Subject, string Description);

        #endregion
    }
}
