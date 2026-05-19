// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;
using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Invocations SampleWs1_Echo.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class SampleWs1Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Invocations_SampleWs1_StartServer

            InvocationsServer.Run<EchoAgentHandler>();

            #endregion
        }

        [Test]
        public void Implement_EchoAgentHandler()
        {
            var handler = new EchoAgentHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Invocations_SampleWs1_EchoAgentHandler

        public class EchoAgentHandler : InvocationHandler
        {
            // POST /invocations — classic request/response echo.
            public override async Task HandleAsync(
                HttpRequest request,
                HttpResponse response,
                InvocationContext context,
                CancellationToken cancellationToken)
            {
                var input = await new StreamReader(request.Body).ReadToEndAsync(cancellationToken);
                await response.WriteAsync($"You said: {input}", cancellationToken);
            }

            // /invocations_ws — full-duplex echo. The SDK has already accepted
            // the upgrade; the handler owns the connection until it returns.
            public override async Task HandleWebSocketAsync(
                WebSocket webSocket,
                InvocationContext context,
                CancellationToken cancellationToken)
            {
                var buffer = new byte[4096];
                while (webSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
                {
                    var received = await webSocket.ReceiveAsync(buffer, cancellationToken);

                    if (received.MessageType == WebSocketMessageType.Close)
                    {
                        // Client initiated close — exit the loop and let the SDK
                        // send the close frame back with NormalClosure (1000).
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
    }
}
