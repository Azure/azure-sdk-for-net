// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Core;
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

            var builder = AgentHost.CreateBuilder();
            builder.AddResponses<EchoHandler>();
            builder.Build().Run();

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

        [Test]
        public void Implement_MultiUserHandler()
        {
            var handler = new MultiUserHandler(null!);
            Assert.That(handler, Is.Not.Null);
        }

        public void MultiUser_Startup(WebApplicationBuilder builder, string projectEndpoint)
        {
            #region Snippet:Responses_ReadMe_MultiUser_Startup

            // Any HttpClient with FoundryCallIdHandler echoes the CURRENT request's
            // x-agent-foundry-call-id — never bake one call's ID into static headers.
            builder.Services.AddHttpClient("foundry", c => c.BaseAddress = new Uri(projectEndpoint))
                .AddHttpMessageHandler<FoundryCallIdHandler>();

            #endregion
        }

        #region Snippet:Responses_ReadMe_MultiUser

        // One agent session can serve many users. Forwarding the per-request call ID on the
        // outbound toolbox call lets the tool server resolve which user made this request and
        // act on their behalf. x-agent-user-id is never forwarded; use
        // context.PlatformContext.UserIdKey only for the container's own per-user state.
        public class MultiUserHandler : ResponseHandler
        {
            private readonly IHttpClientFactory _httpClientFactory;

            public MultiUserHandler(IHttpClientFactory httpClientFactory) =>
                _httpClientFactory = httpClientFactory;

            public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                CancellationToken cancellationToken)
            {
                return new TextResponse(context, request,
                    createText: async ct =>
                    {
                        var query = await context.GetInputTextAsync(cancellationToken: ct);

                        // The "foundry" client is registered with FoundryCallIdHandler, so this
                        // request's x-agent-foundry-call-id rides the toolbox tools/call.
                        var foundry = _httpClientFactory.CreateClient("foundry");
                        using var resp = await foundry.PostAsJsonAsync(
                            "/toolboxes/github/mcp",
                            new
                            {
                                jsonrpc = "2.0",
                                method = "tools/call",
                                @params = new { name = "list_my_assigned_issues", arguments = new { } },
                            },
                            ct);

                        // The toolbox resolved the caller from the call ID and returned THIS user's issues.
                        return await resp.Content.ReadAsStringAsync(ct);
                    });
            }
        }

        #endregion

    }
}
