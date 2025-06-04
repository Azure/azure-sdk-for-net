// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage;
using CoreWCF.Configuration;
using CoreWCF.Queue.Common.Configuration;
using System.Web.Services.Description;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Samples
{
    public class StartupStorageSharedKey
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceModelServices()
                    .AddQueueTransport();
        }

        #region Snippet:CoreWCF_Azure_Storage_Queus_Sample_StorageSharedKey
        public void Configure(IApplicationBuilder app)
        {
            app.UseServiceModel(serviceBuilder =>
            {
                // Configure CoreWCF to dispatch to service type Service
                serviceBuilder.AddService<Service>();

                // Create a binding instance to use Azure Queue Storage, passing an optional queue name for the dead letter queue
                var aqsBinding = new AzureQueueStorageBinding("DEADLETTERQUEUENAME");

                // Configure the client credential type to use StorageSharedKeyCredential
                aqsBinding.Security.Transport.ClientCredentialType = AzureClientCredentialType.StorageSharedKey;

                // Add a service endpoint using the AzureQueueStorageBinding
                string queueEndpointString = "https://MYSTORAGEACCOUNT.queue.core.windows.net/QUEUENAME";
                serviceBuilder.AddServiceEndpoint<Service, IService>(aqsBinding, queueEndpointString);

                // Use extension method to configure CoreWCF to use AzureServiceCredentials and set the
                // StorageSharedKeyCredential instance.
                serviceBuilder.UseAzureCredentials<Service>(credentials =>
                {
                    credentials.StorageSharedKey = GetStorageSharedKey();
                });
            });
        }

        public StorageSharedKeyCredential GetStorageSharedKey()
        {
            // Fetch shared key using a secure mechanism such as Azure Key Vault
            // and construct an instance of StorageSharedKeyCredential to return;
            return default;
        }
        #endregion
    }
}
