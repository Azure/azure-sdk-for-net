// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Processor;

namespace Azure.Messaging.EventHubs.Diagnostics
{
    /// <summary>
    ///   The set of well-known properties associated with Event Hubs diagnostics.
    /// </summary>
    ///
    internal static class DiagnosticProperty
    {
        /// <summary>The common root for activity names in the Event Hubs context.</summary>
        public const string BaseActivityName = "Azure.Messaging.EventHubs";

        /// <summary>The attribute which represents a unique identifier for the diagnostics context.</summary>
        public const string DiagnosticIdAttribute = "Diagnostic-Id";

        /// <summary>The attribute which represents the type of diagnostics information.</summary>
        public const string TypeAttribute = "kind";

        /// <summary>The attribute which represents the Azure service to associate with diagnostics information.</summary>
        public const string ServiceContextAttribute = "component";

        /// <summary>The attribute which represents the Event Hub instance to associate with diagnostics information.</summary>
        public const string EventHubAttribute = "message_bus.destination";

        /// <summary>The attribute which represents the fully-qualified endpoint address of the Event Hubs namespace to associate with diagnostics information.</summary>
        public const string EndpointAttribute = "peer.address";

        /// <summary>The value which identifies the Event Hubs diagnostics context.</summary>
        public const string EventHubsServiceContext = "eventhubs";

        /// <summary>The value which identifies an Event Hub producer as the type associated with the diagnostics information.</summary>
        public const string EventHubProducerType = "producer";

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
        ///   The activity name associated with Event Hub producers.
        /// </summary>
        ///
        public static string ProducerActivityName { get; } = $"{ BaseActivityName }.{ nameof(EventHubProducerClient) }.Send";

        /// <summary>
        ///   The activity name associated with EventProcessor processing a list of events.
        /// </summary>
        ///
        public static string EventProcessorProcessingActivityName { get; } = $"{ BaseActivityName }.{ nameof(EventProcessorClient) }.Process";

        /// <summary>
        ///   The activity name associated with EventProcessor creating a checkpoint.
        /// </summary>
        ///
        public static string EventProcessorCheckpointActivityName { get; } = $"{ BaseActivityName }.{ nameof(EventProcessorClient) }.Checkpoint";
    }
}
