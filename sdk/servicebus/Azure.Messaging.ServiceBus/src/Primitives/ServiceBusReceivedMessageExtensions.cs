// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus.Amqp;

namespace Azure.Messaging.ServiceBus
{
    internal static class ServiceBusReceivedMessageExtensions
    {
        public static BodyScope CreateBodyScope(this ServiceBusReceivedMessage message)
        {
            // necessary to get the body early because it could be replaced by the user
            if (message.AmqpMessage.Body.TryGetData(out var bodyData) &&
                bodyData is MessageBody body)
            {
                return new BodyScope(body);
            }

            return default;
        }

        internal readonly struct BodyScope : IDisposable
        {
            private readonly MessageBody _body;
            public BodyScope(MessageBody body)
            {
                _body = body;
            }

            public void Dispose()
            {
                _body?.Release();
            }
        }
    }
}
