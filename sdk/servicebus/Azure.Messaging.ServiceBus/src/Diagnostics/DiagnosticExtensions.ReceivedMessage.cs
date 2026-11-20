// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Amqp;
using Azure.Core.Shared;

namespace Azure.Messaging.ServiceBus.Diagnostics
{
    internal static partial class DiagnosticExtensions
    {
        /// <summary>
        ///   Extracts the trace context from a received message's application properties without allocating
        ///   a read-only wrapper over them, or creating the underlying dictionary if the message has none.
        /// </summary>
        private static partial bool TryExtractTraceContext(ServiceBusReceivedMessage message, out string traceparent, out string tracestate)
        {
            AmqpAnnotatedMessage amqpMessage = message.AmqpMessage;

            if (!amqpMessage.HasSection(AmqpMessageSection.ApplicationProperties))
            {
                traceparent = null;
                tracestate = null;
                return false;
            }

            return MessagingClientDiagnostics.TryExtractTraceContext(
                amqpMessage.ApplicationProperties,
                out traceparent,
                out tracestate);
        }
    }
}
