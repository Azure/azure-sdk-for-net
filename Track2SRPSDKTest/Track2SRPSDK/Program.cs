using System;
using System.Diagnostics;
using System.Text;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;

namespace Track2SRPSDK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = armClient.GetSubscriptions().Get("45b60d85-fd72-427a-a708-f994d26e593e");

            //string rgName = "weitry";
            string rgName = "weitry";
            AzureLocation location = AzureLocation.WestUS2;
            //ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            //ResourceGroupResource resourceGroup = operation.Value;
            ResourceGroupResource resourceGroup = subscription.GetResourceGroups().Get(rgName);

            //first we need to define the StorageAccountCreateParameters
            //StorageSku sku = new StorageSku(StorageSkuName.StandardGrs);
            //StorageKind kind = StorageKind.Storage;
            //string location = "westus2";
            //StorageAccountCreateOrUpdateContent parameters = new StorageAccountCreateOrUpdateContent(sku, kind, location);
            //now we can create a storage account with defined account name and parameters
            StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
            string accountName = "weirp1";
            //ArmOperation<StorageAccountResource> accountCreateOperation = await accountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters);
            //StorageAccountResource storageAccount = accountCreateOperation.Value;
            StorageAccountResource storageAccount = accountCollection.Get(accountName);

            // first create counter with Admin by run :
            // logman create counter -n Track2SRPSDK -c \Memory\* \Processor(_Total)\* \Process(Track2SRPSDK)\* "\Network Interface(*)\*"  -o c:\Track2SRPSDKperflog\Track2SRPSDKperflog
            //TestHelper.RunCmd("logman", @"create counter -n Track2SRPSDK -c \Memory\* \Processor(_Total)\* \Process(Track2SRPSDK)\* ""\Network Interface(*)\*""  -o c:\Track2SRPSDKperflog\Track2SRPSDKperflog");
            TestHelper.RunCmd("logman", "stop Track2SRPSDK");
            TestHelper.RunCmd("logman", "start Track2SRPSDK");
            for (int i = 0; i < 2000; i++)
            {
                StorageAccountGetKeysResult keys = storageAccount.GetKeys().Value;
                Console.WriteLine("key:" + i);
            }
            TestHelper.RunCmd("logman", "stop Track2SRPSDK");

            System.Threading.Thread.Sleep(10000);

            TestHelper.RunCmd("logman", "start Track2SRPSDK");

            string s = null;
            for (int i = 0; i < 2000; i++)
            {
                Pageable<StorageAccountResource> response = accountCollection.GetAll();
                foreach (StorageAccountResource account in response)
                {
                    s = account.Id.Name;
                    //Console.WriteLine(account.Id.Name);
                }
                Console.WriteLine("listaccounts:" + i);
            }
            TestHelper.RunCmd("logman", "stop Track2SRPSDK");

        }
    }
}
