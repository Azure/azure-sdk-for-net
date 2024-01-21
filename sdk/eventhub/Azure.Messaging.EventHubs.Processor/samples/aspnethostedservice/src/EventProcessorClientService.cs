// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Consumer;

namespace Azure.Messaging.EventHubs.Processor.Samples.HostedService
{
    /// <summary>
    /// Implementation of the <see cref="IHostedService"/> interface for processing events.
    /// </summary>
    public class EventProcessorClientService : IHostedService
    {
        private readonly ILogger<EventProcessorClientService> _logger;
        private readonly EventProcessorClient _processorClient;
        private readonly ISampleApplicationProcessor _appProcessor;

        /// <summary>
        /// Initializes an instance of the <see cref="EventProcessorClientService"/> class.
        /// </summary>
        /// <param name="logger">A named <see cref="ILogger"/> used for logging within the <see cref="EventProcessorClientService"/> class.</param>
        /// <param name="processorClient"><see cref="EventProcessorClient"/> used for consuming and processing events within the <see cref="EventProcessorClientService"/> class.</param>
        /// <param name="appProcessor">A named <see cref="ISampleApplicationProcessor"/> used as an example to show how to pass events to a downstream service for further processing.</param>
        public EventProcessorClientService(
            ILogger<EventProcessorClientService> logger,
            EventProcessorClient processorClient,
            ISampleApplicationProcessor appProcessor)
        {
            _logger = logger;
            _processorClient = processorClient;
            _appProcessor = appProcessor;
        }

        /// <summary>
        /// Implementation of the <see cref="IHostedService"/> StartAsync interface method.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                // Initialize the client event handlers.
                _processorClient.PartitionInitializingAsync += InitializeEventHandler;
                _processorClient.ProcessEventAsync += ProcessEventHandler;
                _processorClient.ProcessErrorAsync += ProcessErrorHandler;

                //Start processing events.
                await _processorClient.StartProcessingAsync(cancellationToken).ConfigureAwait(false);
            }
            catch
            {
                // It is important that you guard against exceptions in
                // your handler code; the processor does not have enough
                // understanding of your code to determine the correct action to take.
                // Any exceptions from your handlers go uncaught by the processor and
                // will NOT be redirected to the error handler.
                //
                // If unhandled, the partition processing task will fault and be restarted
                // from the last recorded checkpoint.  On some hosts, an unhandled
                // exception here may crash the process.
            }
        }

        private Task InitializeEventHandler(PartitionInitializingEventArgs args)
        {
            try
            {
                // Respecting cancellation tokens is an application based decision, and can be ignored based on your specific processing requirements.
                if (args.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                // Example: set the default position to latest, so that only new events are processed.
                args.DefaultStartingPosition = EventPosition.Latest;
            }
            catch
            {
                // It is important that you guard against exceptions in
                // your handler code; the processor does not have enough
                // understanding of your code to determine the correct action to take.
                // Any exceptions from your handlers go uncaught by the processor and
                // will NOT be redirected to the error handler.
                //
                // If unhandled, the partition processing task will fault and be restarted
                // from the last recorded checkpoint.  On some hosts, an unhandled
                // exception here may crash the process.
            }

            return Task.CompletedTask;
        }

        private Task ProcessEventHandler(ProcessEventArgs args)
        {
            try
            {
                // Respecting cancellation tokens is an application based decision, and can be ignored based on your specific processing requirements.
                if (args.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                // Example: process the body of the event to a event processing class.
                // Replace this code with your application specific requirements
                // for event handling.
                var body = args.Data.EventBody.ToString();

                _appProcessor.Process(body);
            }
            catch
            {
                // It is important that you guard against exceptions in
                // your handler code; the processor does not have enough
                // understanding of your code to determine the correct action to take.
                // Any exceptions from your handlers go uncaught by the processor and
                // will NOT be redirected to the error handler.
                //
                // If unhandled, the partition processing task will fault and be restarted
                // from the last recorded checkpoint.  On some hosts, an unhandled
                // exception here may crash the process.
            }

            return Task.CompletedTask;
        }

        private Task ProcessErrorHandler(ProcessErrorEventArgs args)
        {
            try
            {
                // Respecting cancellation tokens is an application based decision, and can be ignored based on your specific processing requirements.
                if (args.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                // Example: log the error.
                // Replace this code with your application specific requirements
                // for error handling.
                _logger.LogError(args.Exception, "Error in the EventProcessorClient \tOperation: {Operation}", args.Operation);
            }
            catch
            {
                // It is important that you guard against exceptions in
                // your handler code; the processor does not have enough
                // understanding of your code to determine the correct action to take.
                // Any exceptions from your handlers go uncaught by the processor and
                // will NOT be redirected to the error handler.
                //
                // If unhandled, the partition processing task will fault and be restarted
                // from the last recorded checkpoint.  On some hosts, an unhandled
                // exception here may crash the process.
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Implementation of the <see cref="IHostedService"/> StopAsync interface method.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                // The hosted service is being stopped, stop processing events
                await _processorClient.StopProcessingAsync(cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                // The hosted service is being stopped, clean-up event handlers
                _processorClient.PartitionInitializingAsync -= InitializeEventHandler;
                _processorClient.ProcessEventAsync -= ProcessEventHandler;
                _processorClient.ProcessErrorAsync -= ProcessErrorHandler;
            }
        }
    }
}
