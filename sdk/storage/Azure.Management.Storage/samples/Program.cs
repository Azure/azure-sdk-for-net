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
        public static async Task Main()
        {
            var storageAccountsClient = new StorageAccountsClient("faa080af-c1d8-40ad-9cce-e1a450ca5b57", new DefaultAzureCredential());

            var accountName = "my0account3";
            var resourceGroupName = "pakrym-resources";

            var createOperation = storageAccountsClient.StartCreate(resourceGroupName, accountName, new StorageAccountCreateParameters()
            {
                Sku = new Sku() { Name = "Standard_LRS" },
                Location = "eastus",
                Kind = Kind.StorageV2
            });

            StorageAccount account = await createOperation.WaitForCompletionAsync();
            Console.WriteLine($"{account.Id} {account.Location} {account.Name}");

            StorageAccountListKeysResult keys = await storageAccountsClient.ListKeysAsync(resourceGroupName, accountName);
            StorageAccountKey lastKey = null;

            foreach (StorageAccountKey storageAccountKey in keys.Keys)
            {
                Console.WriteLine($"{storageAccountKey.KeyName}={storageAccountKey.Value}");
                lastKey = storageAccountKey;
            }

            // TODO: This call succeeds but throws because server responds with 202 while the swagger only defines 200
            // await storageAccountsClient.RegenerateKeyAsync(resourceGroupName, accountName, new StorageAccountRegenerateKeyParameters()
            // {
            //     KeyName = lastKey.Value
            // });

            account = await storageAccountsClient.UpdateAsync(resourceGroupName, accountName, new StorageAccountUpdateParameters()
            {
                Encryption =
                {
                    Services =
                    {
                        Blob =
                        {
                            Enabled = true
                        }
                    }
                }
            });

            Console.WriteLine($"Encryption:\n" +
                              $"Blob {account.Encryption.Services.Blob.Enabled}\n"+
                              $"File {account.Encryption.Services.File.Enabled}\n"+
                              $"Queue {account.Encryption.Services.Queue.Enabled}\n"+
                              $"Table {account.Encryption.Services.Table.Enabled}");

            await storageAccountsClient.DeleteAsync(resourceGroupName, accountName);
        }
    }
}