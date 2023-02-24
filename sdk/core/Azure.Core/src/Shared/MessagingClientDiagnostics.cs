// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using Azure.Core.Pipeline;

#nullable enable

namespace Azure.Core.Shared
{
    /// <summary>
    /// Client Diagnostics support for messaging clients. Currently, this is only used for AMQP clients.
    /// HTTP libraries should use the ClientDiagnostics type instead.
    /// </summary>
    internal class MessagingClientDiagnostics
    {
        private readonly string _fullyQualifiedNamespace;
        private readonly string _entityPath;
        private readonly string _messagingSystem;
        private readonly DiagnosticScopeFactory _scopeFactory;

        #region OTel-specific messaging attributes
        public const string MessagingSystem = "messaging.system";
        public const string DestinationName = "messaging.destination.name";
        public const string SourceName = "messaging.source.name";
        public const string MessagingOperation = "messaging.operation";
        public const string NetPeerName = "net.peer.name";
        public const string BatchCount = "messaging.batch.message_count";
        public const string TraceParent = "traceparent";
        public const string TraceState = "tracestate";
        #endregion

        #region legacy compat attributes
        public const string MessageBusDestination = "message_bus.destination";
        public const string PeerAddress = "peer.address";
        public const string Component = "component";
        #endregion

        public const string DiagnosticIdAttribute = "Diagnostic-Id";

        public MessagingClientDiagnostics(string clientNamespace, string? resourceProviderNamespace, string messagingSystem, string fullyQualifiedNamespace, string entityPath)
        {
            Argument.AssertNotNull(messagingSystem, nameof(messagingSystem));
            Argument.AssertNotNull(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNull(entityPath, nameof(entityPath));

            _messagingSystem = messagingSystem;
            _fullyQualifiedNamespace = fullyQualifiedNamespace;
            _entityPath = entityPath;
            _scopeFactory = new DiagnosticScopeFactory(clientNamespace, resourceProviderNamespace, true, false);
        }

        public DiagnosticScope CreateScope(
            string activityName,
            DiagnosticScope.ActivityKind kind,
            MessagingDiagnosticOperation operation = default)
        {
            DiagnosticScope scope = _scopeFactory.CreateScope(activityName, kind);
            if (ActivityExtensions.SupportsActivitySource())
            {
                scope.AddAttribute(MessagingSystem, _messagingSystem);
                if (operation != default)
                {
                    scope.AddAttribute(MessagingOperation, operation.ToString());
                }

                scope.AddAttribute(NetPeerName, _fullyQualifiedNamespace);
                scope.AddAttribute(operation == MessagingDiagnosticOperation.Receive ? SourceName : DestinationName, _entityPath);
            }
            else
            {
                scope.AddAttribute(Component, _messagingSystem);
                scope.AddAttribute(PeerAddress, _fullyQualifiedNamespace);
                scope.AddAttribute(MessageBusDestination, _entityPath);
            }

            return scope;
        }

        /// <summary>
        ///   Attempts to extract the trace context from a message's properties.
        /// </summary>
        ///
        /// <param name="properties">The properties holding the trace context.</param>
        /// <param name="traceparent">The trace parent of the message.</param>
        /// <param name="tracestate">The trace state of the message.</param>
        /// <returns><c>true</c> if the message properties contained the diagnostic id; otherwise, <c>false</c>.</returns>
        public static bool TryExtractTraceContext(IReadOnlyDictionary<string, object> properties, out string? traceparent, out string? tracestate)
        {
            traceparent = null;
            tracestate = null;

            if (properties.TryGetValue(TraceParent, out var traceParent) && traceParent is string traceParentString)
            {
                traceparent = traceParentString;
                if (properties.TryGetValue(TraceState, out object state) && state is string stateString)
                {
                    tracestate = stateString;
                }
                return true;
            }

            // trace state is not valid without trace parent, so we don't need to check for it for the legacy attribute
            if (properties.TryGetValue(DiagnosticIdAttribute, out var diagnosticId) && diagnosticId is string diagnosticIdString)
            {
                traceparent = diagnosticIdString;
                return true;
            }
            return false;
        }

        /// <summary>
        ///   Attempts to extract the trace context from a message's properties.
        /// </summary>
        ///
        /// <param name="properties">The properties holding the trace context.</param>
        /// <param name="traceparent">The trace parent of the message.</param>
        /// <param name="tracestate">The trace state of the message.</param>
        /// <returns><c>true</c> if the message properties contained the diagnostic id; otherwise, <c>false</c>.</returns>
        public static bool TryExtractTraceContext(IDictionary<string, object> properties, out string? traceparent, out string? tracestate)
        {
            traceparent = null;
            tracestate = null;

            if (properties.TryGetValue(TraceParent, out var traceParent) && traceParent is string traceParentString)
            {
                traceparent = traceParentString;
                if (properties.TryGetValue(TraceState, out object state) && state is string stateString)
                {
                    tracestate = stateString;
                }
                return true;
            }

            // trace state is not valid without trace parent, so we don't need to check for it for the legacy attribute
            if (properties.TryGetValue(DiagnosticIdAttribute, out var diagnosticId) && diagnosticId is string diagnosticIdString)
            {
                traceparent = diagnosticIdString;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Instrument the message properties for tracing. If tracing is enabled, a diagnostic id will be added to the message properties,
        /// which alters the message size.
        /// </summary>
        /// <param name="properties">The dictionary of application message properties.</param>
        /// <param name="activityName">The activity name to use for the diagnostic scope.</param>
        public void InstrumentMessage(IDictionary<string, object> properties, string activityName)
        {
            if (!properties.ContainsKey(DiagnosticIdAttribute) && !properties.ContainsKey(TraceParent))
            {
                using DiagnosticScope messageScope = CreateScope(
                    activityName,
                    DiagnosticScope.ActivityKind.Producer);
                messageScope.Start();

                Activity activity = Activity.Current;
                if (activity != null)
                {
                    properties[DiagnosticIdAttribute] = activity.Id;
                    properties[TraceParent] = activity.Id;
                    if (activity.TraceStateString != null)
                        properties[TraceState] = activity.TraceStateString;
                }
            }
        }
    }
}