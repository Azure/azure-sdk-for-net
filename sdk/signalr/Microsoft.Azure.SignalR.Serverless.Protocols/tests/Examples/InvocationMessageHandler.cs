// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.SignalR.Serverless.Protocols.Tests.Examples
{
    internal class InvocationMessageHandler
    {
        #region Snippet:HandleInvocationMessage
        public async Task HandleInvocation(HttpRequest httpRequest, ILogger logger)
        {
            var contentType = httpRequest.Headers["Content-Type"];
            IServerlessProtocol protocol = (string)contentType switch
            {
                "application/json" => new JsonServerlessProtocol(),
                "application/x-msgpack" => new MessagePackServerlessProtocol(),
                _ => throw new NotSupportedException(),
            };

            using var memoryStream = new MemoryStream();
            await httpRequest.Body.CopyToAsync(memoryStream);
            var bytes = new ReadOnlySequence<byte>(memoryStream.ToArray());
            if (protocol.TryParseMessage(ref bytes, out var message))
            {
                if (message is InvocationMessage invocationMessage)
                {
                    var target = invocationMessage.Target;
                    var arguments = invocationMessage.Arguments;
                    logger.LogInformation($"{target},{arguments[0]}");
                }
            }
        }

        public Task Broadcast(object message)
        {
            //do something here.
            return Task.CompletedTask;
        }
        #endregion
    }
}
