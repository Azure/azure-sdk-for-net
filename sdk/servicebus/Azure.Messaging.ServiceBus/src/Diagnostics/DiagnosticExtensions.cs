﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Core.Pipeline;
using System.Collections.Generic;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Diagnostics
{
    internal static class DiagnosticExtensions
    {
        public static string GetAsciiString(this ArraySegment<byte> arraySegment)
        {
            return arraySegment.Array == null ? string.Empty : Encoding.ASCII.GetString(arraySegment.Array, arraySegment.Offset, arraySegment.Count);
        }

        public static void SetMessageData(this DiagnosticScope scope, ServiceBusReceivedMessage message)
        {
            scope.AddLinkedDiagnostics(message);
        }

        public static void SetMessageData(this DiagnosticScope scope, IReadOnlyCollection<ServiceBusReceivedMessage> messages)
        {
            scope.AddLinkedDiagnostics(messages);
        }

        public static void SetMessageData(this DiagnosticScope scope, IReadOnlyCollection<ServiceBusMessage> messages)
        {
            scope.AddLinkedDiagnostics(messages);
        }

        public static void SetMessageData(this DiagnosticScope scope, IReadOnlyCollection<AmqpMessage> messages)
        {
            scope.AddLinkedDiagnostics(messages);
        }

        /// <summary>
        /// For operations like receive and peek, we are not able to add the message links to the scope before the operation is performed, as we don't
        /// have the messages yet. However, links must be present in the scope before the scope is started, so we need to defer starting the scope until
        /// after the messages are returned, and backdate the start time to right before the operation started.
        /// </summary>
        /// <param name="scope">The scope to start.</param>
        /// <param name="startTime">The Utc instant associated with the start of the operation that the scope is intended to wrap.</param>
        public static void BackdateStart(this DiagnosticScope scope, DateTime startTime)
        {
            scope.SetStartTime(startTime);
            scope.Start();
        }

        private static void AddLinkedDiagnostics(this DiagnosticScope scope, IReadOnlyCollection<ServiceBusReceivedMessage> messages)
        {
            if (scope.IsEnabled)
            {
                foreach (ServiceBusReceivedMessage message in messages)
                {
                    AddLinkedDiagnostics(scope, message.ApplicationProperties);
                }
            }
        }

        private static void AddLinkedDiagnostics(this DiagnosticScope scope, IReadOnlyCollection<AmqpMessage> messages)
        {
            if (scope.IsEnabled)
            {
                foreach (AmqpMessage message in messages)
                {
                    AddLinkedDiagnostics(scope, message.ApplicationProperties.Map);
                }
            }
        }

        private static void AddLinkedDiagnostics(this DiagnosticScope scope, ServiceBusReceivedMessage message)
        {
            if (scope.IsEnabled)
            {
                AddLinkedDiagnostics(scope, message.ApplicationProperties);
            }
        }

        private static void AddLinkedDiagnostics(this DiagnosticScope scope, IReadOnlyCollection<ServiceBusMessage> messages)
        {
            if (scope.IsEnabled)
            {
                foreach (ServiceBusMessage message in messages)
                {
                    AddLinkedDiagnostics(scope, message.ApplicationProperties);
                }
            }
        }

        private static void AddLinkedDiagnostics(this DiagnosticScope scope, IReadOnlyDictionary<string, object> properties)
        {
            if (EntityScopeFactory.TryExtractDiagnosticId(
                    properties,
                    out string diagnosticId))
            {
                scope.AddLink(diagnosticId, null);
            }
        }

        private static void AddLinkedDiagnostics(this DiagnosticScope scope, PropertiesMap properties)
        {
            if (EntityScopeFactory.TryExtractDiagnosticId(
                    properties,
                    out string diagnosticId))
            {
                scope.AddLink(diagnosticId, null);
            }
        }

        private static void AddLinkedDiagnostics(this DiagnosticScope scope, IDictionary<string, object> properties)
        {
            if (EntityScopeFactory.TryExtractDiagnosticId(
                properties,
                out string diagnosticId))
            {
                scope.AddLink(diagnosticId, null);
            }
        }
    }
}
