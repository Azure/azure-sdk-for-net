// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Management.Storage.Models;


namespace Azure.Management.Storage.Samples
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var subscriptionId = args[0];
            var accountName = args[1];
            var resourceGroupName = args[2];

            var storageAccountsClient = new StorageAccountsClient(subscriptionId, new DefaultAzureCredential());
            var createOperation = storageAccountsClient.StartCreate(resourceGroupName, accountName, new StorageAccountCreateParameters(new Sku("Standard_LRS"), Kind.StorageV2, "eastus"));

            StorageAccount account = await createOperation.WaitForCompletionAsync();
            Console.WriteLine($"{account.Id} {account.Location} {account.Name}");

            StorageAccountListKeysResult keys = await storageAccountsClient.ListKeysAsync(resourceGroupName, accountName);
            StorageAccountKey lastKey = null;

            foreach (StorageAccountKey storageAccountKey in keys.Keys)
            {
                Console.WriteLine($"{storageAccountKey.KeyName}={storageAccountKey.Value}");
                lastKey = storageAccountKey;
            }

            await storageAccountsClient.RegenerateKeyAsync(resourceGroupName, accountName, lastKey.KeyName);

            account = await storageAccountsClient.UpdateAsync(resourceGroupName, accountName, new StorageAccountUpdateParameters()
            {
                Encryption = new Encryption(KeySource.MicrosoftStorage)
                {
                    Services = new EncryptionServices()
                    {
                        Blob = new EncryptionService()
                        {
                            Enabled = true
                        }
                    }
                }
            });

            Console.WriteLine($"Encryption:\n" +
                              $"Blob {account.Encryption.Services.Blob.Enabled}\n"+
                              $"File {account.Encryption.Services.File.Enabled}\n"+
                              $"Queue {account.Encryption.Services.Queue?.Enabled ?? false}\n"+
                              $"Table {account.Encryption.Services.Table?.Enabled ?? false}");

            await storageAccountsClient.DeleteAsync(resourceGroupName, accountName);
        }
    }
}