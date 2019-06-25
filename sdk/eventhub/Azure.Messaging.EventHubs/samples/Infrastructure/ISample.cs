// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Samples.Infrastructure
{
    /// <summary>
    ///   Designates a class as a sample and provides a well-known means
    ///   of executing the sample.
    /// </summary>
    ///
    ///
    public interface ISample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; }

        /// <summary>
        ///   A short description of the associated sample.
        /// </summary>
        ///
        public string Description { get; }

        /// <summary>
        ///   Allows for executing the sample.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string for the Event Hubs namespace that the sample should target.</param>
        /// <param name="eventHubName">The name of the Event Hub, sometimes known as its path, that the sample should run against.</param>
        ///
        public Task RunAsync(string connectionString,
                             string eventHubName);
    }
}
