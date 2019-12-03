// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An introduction to publishing events, using an <see cref="EventHubProducerClient" /> that is associated with a specific partition.
    /// </summary>
    ///
    public class Sample06_PublishEventsToSpecificPartitions : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; } = nameof(Sample06_PublishEventsToSpecificPartitions);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description { get; } = "An introduction to publishing events, using an Event Hub producer that is associated with a specific partition.";

        /// <summary>
        ///   Runs the sample using the specified Event Hubs connection information.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string for the Event Hubs namespace that the sample should target.</param>
        /// <param name="eventHubName">The name of the Event Hub, sometimes known as its path, that she sample should run against.</param>
        ///
        public async Task RunAsync(string connectionString,
                                   string eventHubName)
        {
            // This sample has been temporarily deprecated due to some work
            // in progress intended to simplify this scenario.
            //
            // It will be available again in the near future when the associated
            // changes have been completed.  We apologize for the inconvenience.

            await Task.Delay(15);
            Console.WriteLine("Temporarily disabled due to pending work.");
        }
    }
}
