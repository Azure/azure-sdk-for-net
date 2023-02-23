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
    /// HTTP libraries should use <see cref="ClientDiagnostics"/> instead.
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
        #endregion

        #region legacy compat attributes
        public const string MessageBusDestination = "message_bus.destination";
        public const string PeerAddress = "peer.address";
        public const string Component = "component";
        #endregion

        public const string DiagnosticIdAttribute = "Diagnostic-Id";

        public MessagingClientDiagnostics(string clientNamespace, string? resourceProviderNamespace, string messagingSystem, string fullyQualifiedNamespace, string entityPath)
        {
            _messagingSystem = messagingSystem;
            _fullyQualifiedNamespace = fullyQualifiedNamespace;
            _entityPath = entityPath;
            _scopeFactory = new DiagnosticScopeFactory(clientNamespace, resourceProviderNamespace, true, false);
        }

        public DiagnosticScope CreateScope(
            string activityName,
            DiagnosticScope.ActivityKind kind,
            MessagingDiagnosticOperation diagnosticOperation)
        {
            DiagnosticScope scope = _scopeFactory.CreateScope(activityName, kind);
            if (ActivityExtensions.SupportsActivitySource())
            {
                scope.AddAttribute(MessagingSystem, _messagingSystem);
                scope.AddAttribute(MessagingOperation, diagnosticOperation.ToString());
                scope.AddAttribute(NetPeerName, _fullyQualifiedNamespace);
                scope.AddAttribute(diagnosticOperation == MessagingDiagnosticOperation.Publish ? DestinationName : SourceName, _entityPath);
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
        ///   Attempts to extract a diagnostic id from a message's properties.
        /// </summary>
        ///
        /// <param name="properties">The properties holding the diagnostic id.</param>
        /// <param name="id">The value of the diagnostics identifier assigned to the event. </param>
        ///
        /// <returns><c>true</c> if the message properties contained the diagnostic id; otherwise, <c>false</c>.</returns>
        public static bool TryExtractDiagnosticId(IReadOnlyDictionary<string, object> properties, out string? id)
        {
            id = null;

            if (properties.TryGetValue(DiagnosticIdAttribute, out var objectId) && objectId is string stringId)
            {
                id = stringId;
                return true;
            }

            return false;
        }

        /// <summary>
        ///   Attempts to extract a diagnostic id from a message's properties.
        /// </summary>
        ///
        /// <param name="properties">The properties holding the diagnostic id.</param>
        /// <param name="id">The value of the diagnostics identifier assigned to the event. </param>
        ///
        /// <returns><c>true</c> if the message properties contained the diagnostic id; otherwise, <c>false</c>.</returns>
        public static bool TryExtractDiagnosticId(IDictionary<string, object> properties, out string? id)
        {
            id = null;

            if (properties.TryGetValue(DiagnosticIdAttribute, out var objectId) && objectId is string stringId)
            {
                id = stringId;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Instrument the message properties for tracing.
        /// </summary>
        /// <param name="properties">The dictionary of application message properties.</param>
        /// <param name="activityName">The activity name to use for the diagnostic scope.</param>
        public void InstrumentMessage(IDictionary<string, object> properties, string activityName)
        {
            if (!properties.ContainsKey(DiagnosticIdAttribute))
            {
                using DiagnosticScope messageScope = CreateScope(
                    activityName,
                    DiagnosticScope.ActivityKind.Producer,
                    MessagingDiagnosticOperation.Publish);
                messageScope.Start();

                Activity activity = Activity.Current;
                if (activity != null)
                {
                    properties[DiagnosticIdAttribute] = activity.Id;
                }
            }
        }
    }
}