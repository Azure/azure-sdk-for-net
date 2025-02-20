// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Diagnostics
{
    /// <summary>
    ///   The set of well-known properties associated with Event Hubs diagnostics.
    /// </summary>
    ///
    internal static class DiagnosticProperty
    {
        /// <summary>The namespace used for the Event Hubs diagnostic scope.</summary>
        public const string DiagnosticNamespace = "Azure.Messaging.EventHubs";

        /// <summary>The namespace used for the Azure Resource Manager provider namespace.</summary>
        public const string ResourceProviderNamespace = "Microsoft.EventHub";

        /// <summary>The attribute which represents the UNIX Epoch enqueued time of an event to associate with diagnostics information.</summary>
        public const string EnqueuedTimeAttribute = "enqueuedTime";

        /// <summary>The value which identifies the Event Hubs diagnostics context.</summary>
        public const string EventHubsServiceContext = "eventhubs";

        /// <summary>The attribute which represents the kind of diagnostic scope.</summary>
        public const string KindAttribute = "kind";

        /// <summary>The value which identifies the message instrumentation scope kind.</summary>
        public const string ProducerKind = "producer";

        /// <summary>The value which identifies the message client scope kind.</summary>
        public const string ClientKind = "client";

        /// <summary>The value which identifies the processor scope kind.</summary>
        public const string ConsumerKind = "consumer";

        /// <summary>
        ///   The activity name associated with events.
        /// </summary>
        ///
        public static string EventActivityName { get; } = "Message";

        /// <summary>
        ///   The activity name associated with Event Hub producers.
        /// </summary>
        ///
        public static string ProducerActivityName { get; } = "EventHubProducerClient.Send";

        /// <summary>
        ///   The activity name associated with EventProcessor processing a list of events.
        /// </summary>
        ///
        public static string EventProcessorProcessingActivityName { get; } = "EventProcessor.Process";

        /// <summary>
        ///   The activity name associated with EventProcessor creating a checkpoint.
        /// </summary>
        ///
        public static string EventProcessorCheckpointActivityName { get; } = "EventProcessor.Checkpoint";
    }
}
