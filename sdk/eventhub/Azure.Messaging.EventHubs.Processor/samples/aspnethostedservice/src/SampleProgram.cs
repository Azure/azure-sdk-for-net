// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;

namespace Azure.Messaging.EventHubs.Processor.Samples.HostedService
{
    /// <summary>
    /// The <see cref="SampleProgram" /> class.
    /// </summary>
    public class SampleProgram
    {
        /// <summary>
        /// The entry point to the application.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adds an EventProcessorClient for use for the lifetime of the application
            builder.Services.AddSingleton(GetEventProcessorClient(builder.Configuration));

            // Adds a class to process the event body. Substitute this for your own application event processing needs.
            builder.Services.AddTransient<ISampleApplicationProcessor, SampleApplicationProcessor>();

            builder.Services.Configure<HostOptions>(options =>
            {
                // Extend the host shutdown to ensure that the processor infrastructure has
                // time to cleanly shut down.
                //
                // Applications which do not support cancellation in their processing handler
                // advised to extend this to ensure that adequate time is allowed to complete
                // processing for an event that in-flight when stopping was requested.
                options.ShutdownTimeout = TimeSpan.FromSeconds(30);
            });

            // Adds the hosted service to the service collection.
            builder.Services.AddHostedService<EventProcessorClientService>();

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }

        private static EventProcessorClient GetEventProcessorClient(IConfiguration configuration)
        {
            // Replace configuration values in appsettings.json
            var storageConnectionString = configuration.GetValue<string>("Storage:ConnectionString");
            var containerName = configuration.GetValue<string>("Storage:ContainerName");

            var consumerGroup = configuration.GetValue<string>("EventHub:ConsumerGroup");
            var eventHubConnectionString = configuration.GetValue<string>("EventHub:ConnectionString");
            var eventHubName = configuration.GetValue<string>("EventHub:HubName");

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                containerName);

            return new EventProcessorClient(
                storageClient,
                consumerGroup,
                eventHubConnectionString,
                eventHubName);
        }
    }
}
