// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using Azure.Core.Pipeline;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Diagnostics
{
    /// <summary>
    ///   Enables diagnostics instrumentation to be applied to <see cref="ServiceBusMessage" />
    ///   instances.
    /// </summary>
    ///
    internal class EntityScopeFactory
    {
        /// <summary>The namespace used for the Service Bus diagnostic scope.</summary>
        public const string DiagnosticNamespace = "Azure.Messaging.ServiceBus";

        /// <summary>The namespace used for the Azure Resource Manager provider namespace.</summary>
        private const string _resourceProviderNamespace = "Microsoft.ServiceBus";
        private readonly string _entityPath;
        private readonly string _fullyQualifiedNamespace;

        /// <summary>
        ///   The client diagnostics instance responsible for managing scope.
        /// </summary>
        ///
        private static DiagnosticScopeFactory _scopeFactory { get; } = new DiagnosticScopeFactory(DiagnosticNamespace, _resourceProviderNamespace, true, false);

        public EntityScopeFactory(
            string entityPath,
            string fullyQualifiedNamespace)
        {
            _entityPath = entityPath;
            _fullyQualifiedNamespace = fullyQualifiedNamespace;
        }

        /// <summary>
        ///   Extracts a diagnostic id from a message's properties.
        /// </summary>
        ///
        /// <param name="properties">The properties holding the diagnostic id.</param>
        /// <param name="id">The value of the diagnostics identifier assigned to the event. </param>
        ///
        /// <returns><c>true</c> if the event was contained the diagnostic id; otherwise, <c>false</c>.</returns>
        ///
        public static bool TryExtractDiagnosticId(IReadOnlyDictionary<string, object> properties, out string id)
        {
            id = null;

            if (properties.TryGetValue(DiagnosticProperty.DiagnosticIdAttribute, out var objectId) && objectId is string stringId)
            {
                id = stringId;
                return true;
            }

            return false;
        }

        /// <summary>
        ///   Extracts a diagnostic id from a message's properties.
        /// </summary>
        ///
        /// <param name="properties">The properties holding the diagnostic id.</param>
        /// <param name="id">The value of the diagnostics identifier assigned to the event. </param>
        ///
        /// <returns><c>true</c> if the event was contained the diagnostic id; otherwise, <c>false</c>.</returns>
        ///
        public static bool TryExtractDiagnosticId(IDictionary<string, object> properties, out string id)
        {
            id = null;

            if (properties.TryGetValue(DiagnosticProperty.DiagnosticIdAttribute, out var objectId) && objectId is string stringId)
            {
                id = stringId;
                return true;
            }

            return false;
        }

        /// <summary>
        ///   Extracts a diagnostic id from a message's properties.
        /// </summary>
        ///
        /// <param name="properties">The properties holding the diagnostic id.</param>
        /// <param name="id">The value of the diagnostics identifier assigned to the event. </param>
        ///
        /// <returns><c>true</c> if the event was contained the diagnostic id; otherwise, <c>false</c>.</returns>
        ///
        public static bool TryExtractDiagnosticId(PropertiesMap properties, out string id)
        {
            id = null;

            if (properties.TryGetValue<string>(DiagnosticProperty.DiagnosticIdAttribute, out string stringId))
            {
                id = stringId;
                return true;
            }

            return false;
        }

        public DiagnosticScope CreateScope(
            string activityName,
            DiagnosticScope.ActivityKind kind)
        {
            DiagnosticScope scope = _scopeFactory.CreateScope(activityName, kind);
            scope.AddAttribute(
                DiagnosticProperty.ServiceContextAttribute,
                DiagnosticProperty.ServiceBusServiceContext);
            scope.AddAttribute(DiagnosticProperty.EntityAttribute, _entityPath);
            scope.AddAttribute(DiagnosticProperty.EndpointAttribute, _fullyQualifiedNamespace);
            return scope;
        }

        public void InstrumentMessage(ServiceBusMessage message)
        {
            if (!message.ApplicationProperties.ContainsKey(DiagnosticProperty.DiagnosticIdAttribute))
            {
                using DiagnosticScope messageScope = CreateScope(
                    DiagnosticProperty.MessageActivityName,
                    DiagnosticScope.ActivityKind.Producer);
                messageScope.Start();

                Activity activity = Activity.Current;
                if (activity != null)
                {
                    message.ApplicationProperties[DiagnosticProperty.DiagnosticIdAttribute] = activity.Id;
                }
            }
        }
    }
}
