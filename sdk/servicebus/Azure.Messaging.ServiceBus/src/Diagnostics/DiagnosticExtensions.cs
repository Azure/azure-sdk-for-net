// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Core.Pipeline;
using System.Linq;
using System.Collections.Generic;

namespace Azure.Messaging.ServiceBus.Diagnostics
{
    internal static class DiagnosticExtensions
    {
        public static string GetAsciiString(this ArraySegment<byte> arraySegment)
        {
            return arraySegment.Array == null ? string.Empty : Encoding.ASCII.GetString(arraySegment.Array, arraySegment.Offset, arraySegment.Count);
        }

        public static void SetMessageData(this DiagnosticScope scope, IEnumerable<ServiceBusReceivedMessage> messages)
        {
            scope.AddLinkedDiagnostics(messages);
        }

        public static void SetMessageData(this DiagnosticScope scope, IEnumerable<ServiceBusMessage> messages)
        {
            scope.AddLinkedDiagnostics(messages);
        }

        private static void AddLinkedDiagnostics(this DiagnosticScope scope, IEnumerable<ServiceBusReceivedMessage> messages)
        {
            if (scope.IsEnabled)
            {
                foreach (ServiceBusReceivedMessage message in messages)
                {
                    AddLinkedDiagnostics(scope, message.AmqpMessage.ApplicationProperties);
                }
            }
        }

        private static void AddLinkedDiagnostics(this DiagnosticScope scope, IEnumerable<ServiceBusMessage> messages)
        {
            if (scope.IsEnabled)
            {
                foreach (ServiceBusMessage message in messages)
                {
                    AddLinkedDiagnostics(scope, message.ApplicationProperties);
                }
            }
        }

        private static void AddLinkedDiagnostics(this DiagnosticScope scope, IDictionary<string, object> properties)
        {
            if (EntityScopeFactory.TryExtractDiagnosticId(
                properties,
                out string diagnosticId))
            {
                scope.AddLink(diagnosticId);
            }
        }
    }
}
