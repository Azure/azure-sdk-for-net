// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor.Samples.HostedService
{
    /// <summary>
    /// An example interface for processing of events.
    /// </summary>
    public interface ISampleApplicationProcessor
    {
        /// <returns></returns>
        Task Process(string body);
    }
}
