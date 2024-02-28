// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Consumer;

namespace Azure.Messaging.EventHubs.Processor.Samples.HostedService
{
    public class EventProcessorClientService : IHostedService
    {
        private readonly ILogger<EventProcessorClientService> _logger;
        private readonly EventProcessorClient _processorClient;
        private readonly ISampleApplicationProcessor _applicationProcessor;

        public EventProcessorClientService(
            ILogger<EventProcessorClientService> logger,
            EventProcessorClient processorClient,
            ISampleApplicationProcessor applicationProcessor)
        {
            _logger = logger;
            _processorClient = processorClient;
            _applicationProcessor = applicationProcessor;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Initialize the client event handlers and begin processing events.

            _processorClient.PartitionInitializingAsync += InitializeEventHandler;
            _processorClient.ProcessEventAsync += ProcessEventHandler;
            _processorClient.ProcessErrorAsync += ProcessErrorHandler;

            await _processorClient.StartProcessingAsync(cancellationToken).ConfigureAwait(false);
        }

        private Task InitializeEventHandler(PartitionInitializingEventArgs args)
        {
            try
            {
                // Respecting cancellation tokens is an application based decision, and can be
                // ignored based on your specific processing requirements.

                if (args.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                // Example: set the default position to latest, so that only new events are
                // processed.

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
                // Respecting cancellation tokens is an application based decision, and can be
                // ignored based on your specific processing requirements.

                if (args.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                // Example: process the body of the event to a event processing class.
                // Replace this code with your application specific requirements
                // for event handling.

                var body = args.Data.EventBody.ToString();
                _applicationProcessor.Process(body);
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
                // Respecting cancellation tokens is an application based decision, and can be
                // ignored based on your specific processing requirements.

                if (args.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                // Replace this code with your application-specific requirements for
                // error handling.
                //
                // For more information on error handling, see:
                // https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample03_EventProcessorHandlers.md#reacting-to-processor-errors

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

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                // The hosted service is being stopped, stop processing events.

                await _processorClient.StopProcessingAsync(cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                // The hosted service is being stopped, clean-up event handlers.

                _processorClient.PartitionInitializingAsync -= InitializeEventHandler;
                _processorClient.ProcessEventAsync -= ProcessEventHandler;
                _processorClient.ProcessErrorAsync -= ProcessErrorHandler;
            }
        }
    }
}
