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

        public static void SetMessageTags(this DiagnosticScope scope, IEnumerable<ServiceBusReceivedMessage> messages)
        {
            // set the message Ids on the scope
            var messageIds = messages.Where(m => m.MessageId != null).Select(m => m.MessageId).ToArray();
            var sessionIds = messages.Where(m => m.SessionId != null).Select(m => m.SessionId).Distinct().ToArray();
            scope.SetMessageTags(messageIds, sessionIds);
        }

        private static void SetMessageTags(this DiagnosticScope scope, IEnumerable<ServiceBusMessage> messages)
        {
            var messageIds = messages.Where(m => m.MessageId != null).Select(m => m.MessageId).ToArray();
            var sessionIds = messages.Where(m => m.SessionId != null).Select(m => m.SessionId).Distinct().ToArray();
            scope.SetMessageTags(messageIds, sessionIds);
        }

        private static void SetMessageTags(this DiagnosticScope scope, string[] messageIds, string[] sessionIds)
        {
            // set the message Ids on the scope
            if (messageIds.Any())
            {
                scope.AddAttribute(DiagnosticProperty.MessageIdAttribute, string.Join(",", messageIds));
            }

            // set any session Ids on the scope
            if (sessionIds.Any())
            {
                scope.AddAttribute(DiagnosticProperty.SessionIdAttribute, string.Join(",", sessionIds));
            }
        }

        public static void SetMessageData(this DiagnosticScope scope, IEnumerable<ServiceBusReceivedMessage> messages)
        {
            scope.AddLinkedDiagnostics(messages);
            scope.SetMessageTags(messages);
        }

        public static void SetMessageData(this DiagnosticScope scope, IEnumerable<ServiceBusMessage> messages)
        {
            scope.AddLinkedDiagnostics(messages);
            scope.SetMessageTags(messages);
        }

        private static void AddLinkedDiagnostics(this DiagnosticScope scope, IEnumerable<ServiceBusReceivedMessage> messages)
        {
            if (scope.IsEnabled)
            {
                foreach (ServiceBusReceivedMessage message in messages)
                {
                    AddLinkedDiagnostics(scope, message.SentMessage.Properties);
                }
            }
        }

        private static void AddLinkedDiagnostics(this DiagnosticScope scope, IEnumerable<ServiceBusMessage> messages)
        {
            if (scope.IsEnabled)
            {
                foreach (ServiceBusMessage message in messages)
                {
                    AddLinkedDiagnostics(scope, message.Properties);
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
