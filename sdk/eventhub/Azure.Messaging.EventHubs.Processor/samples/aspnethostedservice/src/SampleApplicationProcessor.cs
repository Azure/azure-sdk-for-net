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

        /// <summary>
        /// Processes the string representation of an event. The sample behaviour logs the body using a named <see cref="ILogger"/>.
        /// </summary>
        /// <param name="body">The body of an event to process.</param>
        /// <returns></returns>
        public async Task Process(string body)
        {
            _logger.LogInformation("Event body has been processed: {body}", body);
            await Task.CompletedTask.ConfigureAwait(false);
        }
    }

    /// <summary>
    /// An example interface for processing of events.
    /// </summary>
    public interface ISampleApplicationProcessor
    {
        /// <summary>
        /// The default method of the <see cref="ISampleApplicationProcessor"/> interface used for processing of event data. Implement this method in a class definition.
        /// </summary>
        /// <param name="body">The body of an event to process.</param>
        /// <returns></returns>
        Task Process(string body);
    }
}
