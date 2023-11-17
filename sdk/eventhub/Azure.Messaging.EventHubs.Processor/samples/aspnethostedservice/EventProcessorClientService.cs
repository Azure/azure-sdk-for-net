// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;

namespace Azure.Messaging.EventHubs.Samples.Processor.HostedService
{
    public class EventProcessorClientService : IHostedService
    {
        private readonly ILogger<EventProcessorClientService> _logger;
        private readonly EventProcessorClient _processorClient;
        private readonly ISampleApplicationProcessor _appProcessor;
        public EventProcessorClientService(
            ILogger<EventProcessorClientService> logger,
            EventProcessorClient processorClient,
            ISampleApplicationProcessor appProcessor)
        {
            _logger = logger;
            _processorClient = processorClient;
            _appProcessor = appProcessor;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                //Initialize the client event handlers.
                _processorClient.PartitionInitializingAsync += initializeEventHandler;
                _processorClient.ProcessEventAsync += processEventHandler;
                _processorClient.ProcessErrorAsync += processErrorHandler;

                //Start processing events.
                await _processorClient.StartProcessingAsync(cancellationToken);
            }
            catch
            {
                //Handle exceptions.
            }
        }

        private Task initializeEventHandler(PartitionInitializingEventArgs args)
        {
            try
            {
                if (args.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                //Example: set the default position to latest, so that only new events are processed.
                args.DefaultStartingPosition = EventPosition.Latest;
            }
            catch
            {
                //Handle exceptions.
            }

            return Task.CompletedTask;
        }

        private Task processEventHandler(ProcessEventArgs args)
        {
            try
            {
                if (args.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                //Example: process the body of the event to a event processing class.
                //Replace this code with your application specific requirements
                //for event handling.
                var body = args.Data.EventBody.ToString();

                _appProcessor.Process(body);
            }
            catch
            {
                //Handle exceptions.
            }

            return Task.CompletedTask;
        }

        private Task processErrorHandler(ProcessErrorEventArgs args)
        {
            try
            {
                if (args.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                //Example: log the error.
                //Replace this code with your application specific requirements
                //for error handling.
                _logger.LogError(args.Exception, "Error in the EventProcessorClient \tOperation: {Operation}", args.Operation);
            }
            catch
            {
                //Handle exceptions.
            }

            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                //The hosted service is being stopped, stop processing events
                await _processorClient.StopProcessingAsync(cancellationToken);
            }
            finally
            {
                //The hosted service is being stopped, clean-up event handlers
                _processorClient.PartitionInitializingAsync -= initializeEventHandler;
                _processorClient.ProcessEventAsync -= processEventHandler;
                _processorClient.ProcessErrorAsync -= processErrorHandler;
            }
        }
    }
}
