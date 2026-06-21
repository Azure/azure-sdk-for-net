// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.WebSockets;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing the Invocations README.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class ReadMeSnippets
    {
        [Test]
        public void Tier1_Startup()
        {
            #region Snippet:Invocations_ReadMe_Tier1

            InvocationsServer.Run<EchoHandler>();

            #endregion
        }

        [Test]
        public void ManualSetup()
        {
            #region Snippet:Invocations_ReadMe_ManualSetup

            var builder = AgentHost.CreateBuilder();
            builder.AddInvocations<EchoHandler>();
            builder.Build().Run();

            #endregion
        }

        [Test]
        public void Implement_EchoHandler()
        {
            var handler = new EchoHandler();
            Assert.That(handler, Is.Not.Null);
        }

        [Test]
        public void Implement_WebSocketEchoHandler()
        {
            var handler = new WebSocketEchoHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Invocations_ReadMe_EchoHandler

        public class EchoHandler : InvocationHandler
        {
            public override async Task HandleAsync(
                HttpRequest request, HttpResponse response,
                InvocationContext context, CancellationToken cancellationToken)
            {
                var input = await new StreamReader(request.Body).ReadToEndAsync(cancellationToken);
                await response.WriteAsync($"You said: {input}", cancellationToken);
            }
        }

        #endregion

        #region Snippet:Invocations_ReadMe_WebSocketHandler

        public class WebSocketEchoHandler : InvocationWebSocketHandler
        {
            public override async Task HandleWebSocketAsync(
                WebSocket webSocket, InvocationContext context, CancellationToken cancellationToken)
            {
                var buffer = new byte[4096];
                while (webSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
                {
                    var received = await webSocket.ReceiveAsync(buffer, cancellationToken);
                    if (received.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }
                    await webSocket.SendAsync(
                        new ArraySegment<byte>(buffer, 0, received.Count),
                        received.MessageType,
                        received.EndOfMessage,
                        cancellationToken);
                }
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
            #region Snippet:Invocations_ReadMe_MultiUser_Startup

            // Any HttpClient with FoundryCallIdHandler echoes the CURRENT request's
            // x-agent-foundry-call-id — never bake one call's ID into static headers.
            builder.Services.AddHttpClient("foundry", c => c.BaseAddress = new Uri(projectEndpoint))
                .AddHttpMessageHandler<FoundryCallIdHandler>();

            #endregion
        }

        #region Snippet:Invocations_ReadMe_MultiUser

        // One agent session can serve many users. Forwarding the per-request call ID on the
        // outbound toolbox call lets the tool server resolve which user made this request and
        // act on their behalf. x-agent-user-id is never forwarded; use
        // context.PlatformContext.UserIdKey only for the container's own per-user state.
        public class MultiUserHandler : InvocationHandler
        {
            private readonly IHttpClientFactory _httpClientFactory;

            public MultiUserHandler(IHttpClientFactory httpClientFactory) =>
                _httpClientFactory = httpClientFactory;

            public override async Task HandleAsync(
                HttpRequest request, HttpResponse response,
                InvocationContext context, CancellationToken cancellationToken)
            {
                _ = context.PlatformContext.UserIdKey; // container's own per-user state

                // The "foundry" client (registered with FoundryCallIdHandler) echoes this
                // request's x-agent-foundry-call-id, so the toolbox acts for THIS user.
                var foundry = _httpClientFactory.CreateClient("foundry");
                using var toolResponse = await foundry.PostAsJsonAsync(
                    "/toolboxes/github/mcp",
                    new
                    {
                        jsonrpc = "2.0",
                        method = "tools/call",
                        @params = new { name = "list_my_assigned_issues", arguments = new { } },
                    },
                    cancellationToken);

                await response.WriteAsync(
                    await toolResponse.Content.ReadAsStringAsync(cancellationToken), cancellationToken);
            }
        }

        #endregion

    }
}
