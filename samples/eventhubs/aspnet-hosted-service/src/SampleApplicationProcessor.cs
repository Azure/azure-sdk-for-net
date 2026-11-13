// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor.Samples.HostedService
{
    public class SampleApplicationProcessor : ISampleApplicationProcessor
    {
        private readonly ILogger<SampleApplicationProcessor> _logger;

        public SampleApplicationProcessor(ILogger<SampleApplicationProcessor> logger)
        {
            _logger = logger;
        }

        public Task Process(string body)
        {
            _logger.LogInformation("Event body has been processed: {body}", body);
            return Task.CompletedTask;
        }
    }
}
