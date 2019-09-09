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
        public static readonly string BaseActivityName = "Azure.Messaging.EventHubs";

        /// <summary>The activity name associated with events.</summary>
        public static readonly string EventActivityName = $"{ BaseActivityName }.Message";

        /// <summary>The activity name associated with Event Hub producers.</summary>
        public static readonly string ProducerActivityName = $"{ BaseActivityName }.{ nameof(EventHubProducer) }.Send";

        /// <summary>The activity name associated with EventProcessor processing a list of events.</summary>
        public static readonly string EventProcessorProcessingActivityName = $"{ BaseActivityName }.{ typeof(EventProcessor<>).Name }.Process";

        /// <summary>The activity name associated with EventProcessor creating a checkpoint.</summary>
        public static readonly string EventProcessorCheckpointActivityName = $"{ BaseActivityName }.{ typeof(EventProcessor<>).Name }.Checkpoint";

        /// <summary>The attribute which represents a unique identifier for the diagnostics context.</summary>
        public static string DiagnosticIdAttribute = "Diagnostic-Id";

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
    }
}
