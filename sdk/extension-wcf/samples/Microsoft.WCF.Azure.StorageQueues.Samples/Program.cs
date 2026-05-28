// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage;
using System.ServiceModel;

namespace Microsoft.WCF.Azure.StorageQueues.Samples
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            await UseAqsBindingWithDefaultCredentials();
        }

        private static async Task UseAqsBindingWithDefaultCredentials()
        {
            #region Snippet:WCF_Azure_Storage_Queues_Sample_DefaultAzureCredential
            // Create a binding instance to use Azure Queue Storage.
            // The default client credential type is Default, which uses DefaultAzureCredential
            var aqsBinding = new AzureQueueStorageBinding();

            // Create a ChannelFactory to using the binding and endpoint address, open it, and create a channel
            string queueEndpointString = "https://MYSTORAGEACCOUNT.queue.core.windows.net/QUEUENAME";
            var factory = new ChannelFactory<IService>(aqsBinding, new EndpointAddress(queueEndpointString));
            factory.Open();
            IService channel = factory.CreateChannel();

            // IService dervies from IChannel so you can call channel.Open without casting
            channel.Open();
            await channel.SendDataAsync(42);
            #endregion

            channel.Close();
            await (factory as IAsyncDisposable).DisposeAsync();
        }

        private static async Task UseAqsBindingWithStorageSharedKey()
        {
            #region Snippet:WCF_Azure_Storage_Queus_Sample_StorageSharedKey
            // Create a binding instance to use Azure Queue Storage.
            var aqsBinding = new AzureQueueStorageBinding();

            // Configure the client credential type to use StorageSharedKeyCredential
            aqsBinding.Security.Transport.ClientCredentialType = AzureClientCredentialType.StorageSharedKey;

            // Create a ChannelFactory to using the binding and endpoint address
            string queueEndpointString = "https://MYSTORAGEACCOUNT.queue.core.windows.net/QUEUENAME";
            var factory = new ChannelFactory<IService>(aqsBinding, new EndpointAddress(queueEndpointString));

            // Use extension method to configure WCF to use AzureClientCredentials and set the
            // StorageSharedKeyCredential instance.
            factory.UseAzureCredentials(credentials =>
            {
                credentials.StorageSharedKey = GetStorageSharedKey();
            });

            // Local function to get the StorageSharedKey
            StorageSharedKeyCredential GetStorageSharedKey()
            {
                // Fetch shared key using a secure mechanism such as Azure Key Vault
                // and construct an instance of StorageSharedKeyCredential to return;
                return default;
            }

            // Open the factory and create a channel
            factory.Open();
            IService channel = factory.CreateChannel();

            // IService dervies from IChannel so you can call channel.Open without casting
            channel.Open();
            await channel.SendDataAsync(42);
            #endregion

            channel.Close();
            await (factory as IAsyncDisposable).DisposeAsync();
        }
    }
}
