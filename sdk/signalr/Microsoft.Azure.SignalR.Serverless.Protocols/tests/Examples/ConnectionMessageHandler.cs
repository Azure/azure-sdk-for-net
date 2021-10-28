// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.SignalR.Serverless.Protocols.Tests.Examples
{
    internal class ConnectionMessageHandler
    {
        #region Snippet:HandleConnectedMessage
        public void HandleConnectedMessage(HttpRequest httpRequest, ILogger logger)
        {
            var connectionId = httpRequest.Headers["X-ASRS-Connection-Id"];
            var userId = httpRequest.Headers["X-ASRS-User-Id"];

            using var memoryStream = new MemoryStream();
            httpRequest.Body.CopyTo(memoryStream);
            var bytes = new ReadOnlySequence<byte>(memoryStream.ToArray());
            var protocol = new JsonServerlessProtocol();
            if (protocol.TryParseMessage(ref bytes, out var message))
            {
                if (message is OpenConnectionMessage connectedMessage)
                {
                    logger.LogInformation($"Connection {connectionId} is connected. User name is {userId}.");
                }
            }
        }
        #endregion

        #region Snippet:HandleDisconnectedMessage
        public void HandleDisconnectedMessage(HttpRequest httpRequest, ILogger logger)
        {
            var connectionId = httpRequest.Headers["X-ASRS-Connection-Id"];
            var userId = httpRequest.Headers["X-ASRS-User-Id"];

            using var memoryStream = new MemoryStream();
            httpRequest.Body.CopyTo(memoryStream);
            var bytes = new ReadOnlySequence<byte>(memoryStream.ToArray());
            var protocol = new JsonServerlessProtocol();
            if (protocol.TryParseMessage(ref bytes, out var message))
            {
                if (message is CloseConnectionMessage disconnectedMessage)
                {
                    logger.LogInformation($"Connection {connectionId} is disconnected. User name is {userId}. Reason is {disconnectedMessage.Error}");
                }
            }
        }
        #endregion
    }
}