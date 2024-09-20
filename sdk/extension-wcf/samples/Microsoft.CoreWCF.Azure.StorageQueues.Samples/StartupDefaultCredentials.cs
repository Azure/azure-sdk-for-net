// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CoreWCF.Configuration;
using CoreWCF.Queue.Common.Configuration;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Samples
{
    public class StartupDefaultCredentials
    {
        #region Snippet:Configure_CoreWCF_QueueTransport
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceModelServices()
                    .AddQueueTransport();
        }
        #endregion

        #region Snippet:CoreWCF_Azure_Storage_Queues_Sample_DefaultAzureCredential
        public void Configure(IApplicationBuilder app)
        {
            app.UseServiceModel(serviceBuilder =>
            {
                // Configure CoreWCF to dispatch to service type Service
                serviceBuilder.AddService<Service>();

                // Create a binding instance to use Azure Queue Storage, passing an optional queue name for the dead letter queue
                // The default client credential type is Default, which uses DefaultAzureCredential
                var aqsBinding = new AzureQueueStorageBinding("DEADLETTERQUEUENAME");

                // Add a service endpoint using the AzureQueueStorageBinding
                string queueEndpointString = "https://MYSTORAGEACCOUNT.queue.core.windows.net/QUEUENAME";
                serviceBuilder.AddServiceEndpoint<Service, IService>(aqsBinding, queueEndpointString);
            });
        }
        #endregion
    }
}
