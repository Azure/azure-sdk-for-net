// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor.Samples.HostedService
{
    public interface ISampleApplicationProcessor
    {
        Task Process(string body);
    }
}
