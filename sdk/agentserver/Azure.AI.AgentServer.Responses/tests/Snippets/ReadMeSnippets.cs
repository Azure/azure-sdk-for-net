// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing the README.md. Compiled to prevent rot.
    /// Marked [Explicit] because they require a running server.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class ReadMeSnippets
    {
        [Test]
        public void ConfigureServer_Tier1()
        {
            #region Snippet:Responses_ReadMe_ConfigureServer_Tier1

            ResponsesServer.Run<EchoHandler>();

            #endregion
        }

        [Test]
        public void ConfigureServer_Manual()
        {
            #region Snippet:Responses_ReadMe_ConfigureServer_Manual

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddResponsesServer();
            builder.Services.AddScoped<ResponseHandler, EchoHandler>();

            var app = builder.Build();
            app.MapResponsesServer();
            app.Run();

            #endregion
        }

        [Test]
        public void Implement_EchoHandler()
        {
            // This test validates the EchoHandler snippet compiles.
            // The class definition itself IS the snippet.
            var handler = new EchoHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_ReadMe_EchoHandler

        public class EchoHandler : ResponseHandler
        {
            public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                CancellationToken cancellationToken)
            {
                return new TextResponse(context, request,
                    createText: async ct =>
                    {
                        var input = await context.GetInputTextAsync(cancellationToken: ct);
                        return $"Echo: {input}";
                    });
            }
        }

        #endregion

        [Test]
        public void Implement_EchoHandlerConvenience()
        {
            var handler = new EchoHandlerConvenience();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_ReadMe_EchoHandler_Convenience

        public class EchoHandlerConvenience : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var stream = new ResponseEventStream(context, request);

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                // One call emits all text output events automatically.
                var input = await context.GetInputTextAsync(cancellationToken: cancellationToken);
                foreach (var evt in stream.OutputItemMessage($"Echo: {input}"))
                    yield return evt;

                yield return stream.EmitCompleted();
            }
        }

        #endregion

        [Test]
        public void Implement_EchoHandlerFullControl()
        {
            var handler = new EchoHandlerFullControl();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_ReadMe_EchoHandler_FullControl

        public class EchoHandlerFullControl : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                await Task.CompletedTask;
                var stream = new ResponseEventStream(context, request);
                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                var message = stream.AddOutputItemMessage();
                yield return message.EmitAdded();

                var text = message.AddTextContent();
                yield return text.EmitAdded();
                yield return text.EmitDelta("Hello, world!");
                yield return text.EmitTextDone("Hello, world!");

                yield return text.EmitDone();
                yield return message.EmitDone();
                yield return stream.EmitCompleted();
            }
        }

        #endregion
    }
}
