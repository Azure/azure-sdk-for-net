// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.ConfidentialLedger.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ConfidentialLedger.Samples
{
    public partial class ManagedCcfsTest
    {
        // ManagedCCFGet
        [NUnit.Framework.Test]
        public async Task Get_ManagedCCFGet()
        {
            // Generated from example definition: specification/confidentialledger/resource-manager/Microsoft.ConfidentialLedger/preview/2023-01-26-preview/examples/ManagedCCF_Get.json
            // this example is just showing the usage of "ManagedCCF_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ManagedCCFResource created on azure
            // for more information of creating ManagedCCFResource, please refer to the document of ManagedCCFResource
            string subscriptionId = "027da7f8-2fc6-46d4-9be9-560706b60fec";
            string resourceGroupName = "pratik-rg";
            string appName = "prMccf";
            ResourceIdentifier managedCCFResourceId = ManagedCCFResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, appName);
            ManagedCCFResource managedCCF = client.GetManagedCCFResource(managedCCFResourceId);

            // invoke the operation
            ManagedCCFResource result = await managedCCF.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            ManagedCCFData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // ManagedCCFListBySub
        [NUnit.Framework.Test]
        public async Task GetManagedCCFs_ManagedCCFListBySub()
        {
            // Generated from example definition: specification/confidentialledger/resource-manager/Microsoft.ConfidentialLedger/preview/2023-01-26-preview/examples/ManagedCCF_ListBySub.json
            // this example is just showing the usage of "ManagedCCF_ListBySubscription" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "027da7f8-2fc6-46d4-9be9-560706b60fec";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation and iterate over the result
            await foreach (ManagedCCFResource item in subscriptionResource.GetManagedCCFsAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                ManagedCCFData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }

        // ManagedCCFCreateOrUpdate
        [NUnit.Framework.Test]
        public async Task CreateOrUpdate_ManagedCCFCreate()
        {
            // Generated from example definition: specification/confidentialledger/resource-manager/Microsoft.ConfidentialLedger/preview/2023-01-26-preview/examples/ManagedCCF_Create.json
            // this example is just showing the usage of "ManagedCCF_Create" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "027da7f8-2fc6-46d4-9be9-560706b60fec";
            string resourceGroupName = "pratik-rg";
            string appName = "weuMccfNew2";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this ManagedCCFResource
            ManagedCCFCollection collection = resourceGroupResource.GetManagedCCFs();

            ManagedCCFData data = new ManagedCCFData(new AzureLocation("westeurope"))
            {
                Properties = new ManagedCCFProperties()
                {
                    MemberIdentityCertificates =
                    {
                        new MemberIdentityCertificate()
                        {
                            Certificate = "-----BEGIN CERTIFICATE-----\nMIIBvzCCAUSgAwIBAgIUUYG5m2lzI5X88E3XLxMaVwJqolMwCgYIKoZIzj0EAwMw\nFjEUMBIGA1UEAwwLcGV0ZXJ3YWxrZXIwHhcNMjMwNTAxMTk1NjU3WhcNMjQwNDMw\nMTk1NjU3WjAWMRQwEgYDVQQDDAtwZXRlcndhbGtlcjB2MBAGByqGSM49AgEGBSuB\nBAAiA2IABH0CJdl/ZvmaLLDlkNU6gX56kKVP2pQDIr4NUVRe31Aycqa9Q5md1sBl\nE+e3c9hd5bz+Rjfok4uOaYvOWsr9EKbofzU4ztGWD5r2a6yvdbnmw7sjjoy2NN/N\nIOd0yW4pIKNTMFEwHQYDVR0OBBYEFEdO7YFlqF76lPXDwGOukMf9EVDFMB8GA1Ud\nIwQYMBaAFEdO7YFlqF76lPXDwGOukMf9EVDFMA8GA1UdEwEB/wQFMAMBAf8wCgYI\nKoZIzj0EAwMDaQAwZgIxAIv8BymJGDm4vQW/H6UvjXHfa6AA8+BhBUWYjq6vnRbj\nPP1phtfbnXOh3+6ACXMSZgIxANzw0ofI6ZMe36URpjiaRrAd9ubf9aG1sLMN3Amx\nr/CZgiIZe7uZuvi0UYtf0ZoeNw==\n-----END CERTIFICATE-----",
                            Encryptionkey = ""
                        }
                    },
                    DeploymentType = new DeploymentType()
                    {
                        LanguageRuntime = LanguageRuntime.CPP,
                        AppSourceUri = "sample",
                    }
                }
            };
            ArmOperation<ManagedCCFResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, appName, data);
            ManagedCCFResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            ManagedCCFData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // ConfidentialLedgerDelete
        [NUnit.Framework.Test]
        public async Task Delete_ConfidentialLedgerDelete()
        {
            // Generated from example definition: specification/confidentialledger/resource-manager/Microsoft.ConfidentialLedger/preview/2023-01-26-preview/examples/ManagedCCF_Delete.json
            // this example is just showing the usage of "ManagedCCF_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ManagedCCFResource created on azure
            // for more information of creating ManagedCCFResource, please refer to the document of ManagedCCFResource
            string subscriptionId = "027da7f8-2fc6-46d4-9be9-560706b60fec";
            string resourceGroupName = "pratik-rg";
            string appName = "pythonMccf14";
            ResourceIdentifier managedCCFResourceId = ManagedCCFResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, appName);
            ManagedCCFResource managedCCF = client.GetManagedCCFResource(managedCCFResourceId);

            // invoke the operation
            await managedCCF.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine($"Succeeded");
        }
    }
}
