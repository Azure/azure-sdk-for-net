// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;

namespace Azure.Messaging.EventHubs.Samples.Processor.HostedService
{
    /// <summary>
    /// Test
    /// </summary>
    public class SampleProgram
    {
        /// <summary>
        /// Test
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Adds an EventProcessorClient for use for the lifetime of the application
            builder.Services.AddSingleton(GetEventProcessorClient(builder.Configuration));

            //Adds a class to process the event body. Substitute this for your own application event processing needs.
            builder.Services.AddTransient<ISampleApplicationProcessor, SampleApplicationProcessor>();

            //Adds the hosted service to the service collection.
            builder.Services.AddHostedService<EventProcessorClientService>();

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }

        private static EventProcessorClient GetEventProcessorClient(IConfiguration configuration)
        {
            //replace configuration values in appsettings.json
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
