// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;

namespace Azure.Management.Storage.Samples
{
    public static class Program
    {
        public static async Task Main()
        {
            var serviceClient = new StorageAccountsClient("faa080af-c1d8-40ad-9cce-e1a450ca5b57", new DefaultAzureCredential());
            await foreach (var account in serviceClient.ListAsync())
            {
                Console.WriteLine(account.Name);
            }
        }
    }
}