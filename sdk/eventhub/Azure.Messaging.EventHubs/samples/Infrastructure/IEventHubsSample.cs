// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Samples.Infrastructure
{
    /// <summary>
    ///   Designates a class as a sample
    /// </summary>
    ///
    public interface IEventHubsSample
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
    }
}
