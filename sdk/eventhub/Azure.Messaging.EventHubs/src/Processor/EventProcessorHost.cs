// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO.
    /// </summary>
    ///
    public class EventProcessorHost
    {
        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public string Name { get; }

        /// <summary>
        ///   TODO. (client? CG? options optional)
        /// </summary>
        ///
        public EventProcessorHost(EventHubClient eventHubClient,
                                    string consumerGroupName,
                                    IEventProcessorFactory eventProcessorFactory,
                                    CheckpointManager checkpointManager,
                                    EventProcessorHostOptions options)
        {
            Name = "I am unique";
        }

        /// <summary>
        ///   TODO. (make it async)
        /// </summary>
        ///
        public void start() { }

        /// <summary>
        ///   TODO. (make it async)
        /// </summary>
        ///
        public void stop() { }
    }
}
