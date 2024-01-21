// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor.Samples.HostedService
{
    /// <summary>
    /// Implementation of the <see cref="ISampleApplicationProcessor"/> interface that logs events to show example usage of a downstream process.
    /// </summary>
    public class SampleApplicationProcessor : ISampleApplicationProcessor
    {
        private readonly ILogger<SampleApplicationProcessor> _logger;

        /// <summary>
        /// Initializes an instance of the <see cref="SampleApplicationProcessor"/> class.
        /// </summary>
        /// <param name="logger">A named <see cref="ILogger"/> used for logging within the <see cref="SampleApplicationProcessor"/> class.</param>
        public SampleApplicationProcessor(ILogger<SampleApplicationProcessor> logger)
        {
            _logger = logger;
        }

        /// <returns></returns>
        public Task Process(string body)
        {
            _logger.LogInformation("Event body has been processed: {body}", body);
            return Task.CompletedTask;
        }
    }
}
