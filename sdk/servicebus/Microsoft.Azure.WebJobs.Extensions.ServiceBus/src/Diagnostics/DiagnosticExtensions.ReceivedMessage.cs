// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Shared;

namespace Azure.Messaging.ServiceBus.Diagnostics
{
    internal static partial class DiagnosticExtensions
    {
        /// <summary>
        ///   Extracts the trace context from a received message's application properties. The internal AMQP message
        ///   is not accessible from this assembly, so the public application properties are used instead.
        /// </summary>
        private static partial bool TryExtractTraceContext(ServiceBusReceivedMessage message, out string traceparent, out string tracestate) =>
            MessagingClientDiagnostics.TryExtractTraceContext(
                message.ApplicationProperties,
                out traceparent,
                out tracestate);
    }
}
