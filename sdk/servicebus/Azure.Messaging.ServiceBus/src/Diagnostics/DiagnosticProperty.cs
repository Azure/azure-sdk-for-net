// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Diagnostics
{
    /// <summary>
    ///   The set of well-known properties associated with Service Bus diagnostics.
    /// </summary>
    ///
    internal static class DiagnosticProperty
    {
        /// <summary>The common root for activity names in the Service Bus context.</summary>
        public const string BaseActivityName = "Azure.Messaging.ServiceBus";

        /// <summary>The attribute which represents a unique identifier for the diagnostics context.</summary>
        public const string DiagnosticIdAttribute = "Diagnostic-Id";

        /// <summary>The attribute which represents the type of diagnostics information.</summary>
        public const string TypeAttribute = "kind";

        /// <summary>The attribute which represents the Azure service to associate with diagnostics information.</summary>
        public const string ServiceContextAttribute = "component";

        /// <summary>The attribute which represents the Service Bus entity instance to associate with diagnostics information.</summary>
        public const string ServiceBusAttribute = "message_bus.destination";

        /// <summary>The attribute which represents the fully-qualified endpoint address of the Service Bus namespace to associate with diagnostics information.</summary>
        public const string EndpointAttribute = "peer.address";

        /// <summary>The value which identifies the Service Bus diagnostics context.</summary>
        public const string ServiceBusServiceContext = "servicebus";

        /// <summary>The value which identifies an Service Bus entity producer as the type associated with the diagnostics information.</summary>
        public const string ServiceBusSenderType = "sender";

        /// <summary>The attribute which represents the kind of diagnostic scope.</summary>
        public const string KindAttribute = "kind";

        /// <summary>The value which identifies the Event Processor scope kind.</summary>
        public const string ServerKind = "server";

        /// <summary>The value which identifies the message instrumentation scope kind.</summary>
        public const string InternalKind = "internal";

        /// <summary>
        ///   The activity name associated with events.
        /// </summary>
        ///
        public static string EventActivityName { get; } = $"{ BaseActivityName }.Message";

        /// <summary>
        ///   The activity name associated with Service Bus entity producers.
        /// </summary>
        ///
        public static string SenderActivityName { get; } = $"{ BaseActivityName }.ServiceBusSenderClient.Send";
    }
}
