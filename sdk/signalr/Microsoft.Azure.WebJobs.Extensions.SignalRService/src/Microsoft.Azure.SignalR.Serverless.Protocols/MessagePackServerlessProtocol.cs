// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Buffers;

using MessagePack;

namespace Microsoft.Azure.SignalR.Serverless.Protocols
{
    public class MessagePackServerlessProtocol : IServerlessProtocol
    {
        public int Version => 1;

        public bool TryParseMessage(ref ReadOnlySequence<byte> input, out ServerlessMessage message)
        {
            var array = input.ToArray();
            var startOffset = 0;
            _ = MessagePackBinary.ReadArrayHeader(array, startOffset, out var readSize);
            startOffset += readSize;
            var messageType = MessagePackHelper.ReadInt32(array, ref startOffset, "messageType");
            switch (messageType)
            {
                case ServerlessProtocolConstants.InvocationMessageType:
                    message = ConvertInvocationMessage(array, ref startOffset);
                    break;
                default:
                    // TODO:OpenConnectionMessage and CloseConnectionMessage only will be sent in JSON format. It can be added later.
                    message = null;
                    break;
            }

            return message != null;
        }

        private static InvocationMessage ConvertInvocationMessage(byte[] input, ref int offset)
        {
            var invocationMessage = new InvocationMessage()
            {
                Type = ServerlessProtocolConstants.InvocationMessageType,
            };

            MessagePackHelper.SkipHeaders(input, ref offset);
            invocationMessage.InvocationId = MessagePackHelper.ReadInvocationId(input, ref offset);
            invocationMessage.Target = MessagePackHelper.ReadTarget(input, ref offset);
            invocationMessage.Arguments = MessagePackHelper.ReadArguments(input, ref offset);
            return invocationMessage;
        }
    }
}