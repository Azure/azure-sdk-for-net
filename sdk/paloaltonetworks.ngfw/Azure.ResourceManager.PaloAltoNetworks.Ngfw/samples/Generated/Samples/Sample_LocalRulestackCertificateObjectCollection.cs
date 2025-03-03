// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw.Samples
{
    public partial class Sample_LocalRulestackCertificateObjectCollection
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CreateOrUpdate_CertificateObjectLocalRulestackCreateOrUpdateMaximumSetGen()
        {
            // Generated from example definition: specification/paloaltonetworks/resource-manager/PaloAltoNetworks.Cloudngfw/stable/2023-09-01/examples/CertificateObjectLocalRulestack_CreateOrUpdate_MaximumSet_Gen.json
            // this example is just showing the usage of "CertificateObjectLocalRulestack_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this LocalRulestackResource created on azure
            // for more information of creating LocalRulestackResource, please refer to the document of LocalRulestackResource
            string subscriptionId = "2bf4a339-294d-4c25-b0b2-ef649e9f5c27";
            string resourceGroupName = "rgopenapi";
            string localRulestackName = "lrs1";
            ResourceIdentifier localRulestackResourceId = LocalRulestackResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, localRulestackName);
            LocalRulestackResource localRulestack = client.GetLocalRulestackResource(localRulestackResourceId);

            // get the collection of this LocalRulestackCertificateObjectResource
            LocalRulestackCertificateObjectCollection collection = localRulestack.GetLocalRulestackCertificateObjects();

            // invoke the operation
            string name = "armid1";
            LocalRulestackCertificateObjectData data = new LocalRulestackCertificateObjectData(FirewallBooleanType.True)
            {
                CertificateSignerResourceId = "",
                AuditComment = "comment",
                Description = "description",
                ETag = new ETag("2bf4a339-294d-4c25-b0b2-ef649e9f5c27"),
            };
            ArmOperation<LocalRulestackCertificateObjectResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            LocalRulestackCertificateObjectResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            LocalRulestackCertificateObjectData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CreateOrUpdate_CertificateObjectLocalRulestackCreateOrUpdateMinimumSetGen()
        {
            // Generated from example definition: specification/paloaltonetworks/resource-manager/PaloAltoNetworks.Cloudngfw/stable/2023-09-01/examples/CertificateObjectLocalRulestack_CreateOrUpdate_MinimumSet_Gen.json
            // this example is just showing the usage of "CertificateObjectLocalRulestack_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this LocalRulestackResource created on azure
            // for more information of creating LocalRulestackResource, please refer to the document of LocalRulestackResource
            string subscriptionId = "2bf4a339-294d-4c25-b0b2-ef649e9f5c27";
            string resourceGroupName = "rgopenapi";
            string localRulestackName = "lrs1";
            ResourceIdentifier localRulestackResourceId = LocalRulestackResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, localRulestackName);
            LocalRulestackResource localRulestack = client.GetLocalRulestackResource(localRulestackResourceId);

            // get the collection of this LocalRulestackCertificateObjectResource
            LocalRulestackCertificateObjectCollection collection = localRulestack.GetLocalRulestackCertificateObjects();

            // invoke the operation
            string name = "armid1";
            LocalRulestackCertificateObjectData data = new LocalRulestackCertificateObjectData(FirewallBooleanType.True);
            ArmOperation<LocalRulestackCertificateObjectResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            LocalRulestackCertificateObjectResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            LocalRulestackCertificateObjectData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_CertificateObjectLocalRulestackGetMaximumSetGen()
        {
            // Generated from example definition: specification/paloaltonetworks/resource-manager/PaloAltoNetworks.Cloudngfw/stable/2023-09-01/examples/CertificateObjectLocalRulestack_Get_MaximumSet_Gen.json
            // this example is just showing the usage of "CertificateObjectLocalRulestack_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this LocalRulestackResource created on azure
            // for more information of creating LocalRulestackResource, please refer to the document of LocalRulestackResource
            string subscriptionId = "2bf4a339-294d-4c25-b0b2-ef649e9f5c27";
            string resourceGroupName = "rgopenapi";
            string localRulestackName = "lrs1";
            ResourceIdentifier localRulestackResourceId = LocalRulestackResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, localRulestackName);
            LocalRulestackResource localRulestack = client.GetLocalRulestackResource(localRulestackResourceId);

            // get the collection of this LocalRulestackCertificateObjectResource
            LocalRulestackCertificateObjectCollection collection = localRulestack.GetLocalRulestackCertificateObjects();

            // invoke the operation
            string name = "armid1";
            LocalRulestackCertificateObjectResource result = await collection.GetAsync(name);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            LocalRulestackCertificateObjectData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_CertificateObjectLocalRulestackGetMinimumSetGen()
        {
            // Generated from example definition: specification/paloaltonetworks/resource-manager/PaloAltoNetworks.Cloudngfw/stable/2023-09-01/examples/CertificateObjectLocalRulestack_Get_MinimumSet_Gen.json
            // this example is just showing the usage of "CertificateObjectLocalRulestack_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this LocalRulestackResource created on azure
            // for more information of creating LocalRulestackResource, please refer to the document of LocalRulestackResource
            string subscriptionId = "2bf4a339-294d-4c25-b0b2-ef649e9f5c27";
            string resourceGroupName = "rgopenapi";
            string localRulestackName = "lrs1";
            ResourceIdentifier localRulestackResourceId = LocalRulestackResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, localRulestackName);
            LocalRulestackResource localRulestack = client.GetLocalRulestackResource(localRulestackResourceId);

            // get the collection of this LocalRulestackCertificateObjectResource
            LocalRulestackCertificateObjectCollection collection = localRulestack.GetLocalRulestackCertificateObjects();

            // invoke the operation
            string name = "armid1";
            LocalRulestackCertificateObjectResource result = await collection.GetAsync(name);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            LocalRulestackCertificateObjectData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_CertificateObjectLocalRulestackListByLocalRulestacksMaximumSetGen()
        {
            // Generated from example definition: specification/paloaltonetworks/resource-manager/PaloAltoNetworks.Cloudngfw/stable/2023-09-01/examples/CertificateObjectLocalRulestack_ListByLocalRulestacks_MaximumSet_Gen.json
            // this example is just showing the usage of "CertificateObjectLocalRulestack_ListByLocalRulestacks" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this LocalRulestackResource created on azure
            // for more information of creating LocalRulestackResource, please refer to the document of LocalRulestackResource
            string subscriptionId = "2bf4a339-294d-4c25-b0b2-ef649e9f5c27";
            string resourceGroupName = "rgopenapi";
            string localRulestackName = "lrs1";
            ResourceIdentifier localRulestackResourceId = LocalRulestackResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, localRulestackName);
            LocalRulestackResource localRulestack = client.GetLocalRulestackResource(localRulestackResourceId);

            // get the collection of this LocalRulestackCertificateObjectResource
            LocalRulestackCertificateObjectCollection collection = localRulestack.GetLocalRulestackCertificateObjects();

            // invoke the operation and iterate over the result
            await foreach (LocalRulestackCertificateObjectResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                LocalRulestackCertificateObjectData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_CertificateObjectLocalRulestackListByLocalRulestacksMinimumSetGen()
        {
            // Generated from example definition: specification/paloaltonetworks/resource-manager/PaloAltoNetworks.Cloudngfw/stable/2023-09-01/examples/CertificateObjectLocalRulestack_ListByLocalRulestacks_MinimumSet_Gen.json
            // this example is just showing the usage of "CertificateObjectLocalRulestack_ListByLocalRulestacks" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this LocalRulestackResource created on azure
            // for more information of creating LocalRulestackResource, please refer to the document of LocalRulestackResource
            string subscriptionId = "2bf4a339-294d-4c25-b0b2-ef649e9f5c27";
            string resourceGroupName = "rgopenapi";
            string localRulestackName = "lrs1";
            ResourceIdentifier localRulestackResourceId = LocalRulestackResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, localRulestackName);
            LocalRulestackResource localRulestack = client.GetLocalRulestackResource(localRulestackResourceId);

            // get the collection of this LocalRulestackCertificateObjectResource
            LocalRulestackCertificateObjectCollection collection = localRulestack.GetLocalRulestackCertificateObjects();

            // invoke the operation and iterate over the result
            await foreach (LocalRulestackCertificateObjectResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                LocalRulestackCertificateObjectData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Exists_CertificateObjectLocalRulestackGetMaximumSetGen()
        {
            // Generated from example definition: specification/paloaltonetworks/resource-manager/PaloAltoNetworks.Cloudngfw/stable/2023-09-01/examples/CertificateObjectLocalRulestack_Get_MaximumSet_Gen.json
            // this example is just showing the usage of "CertificateObjectLocalRulestack_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this LocalRulestackResource created on azure
            // for more information of creating LocalRulestackResource, please refer to the document of LocalRulestackResource
            string subscriptionId = "2bf4a339-294d-4c25-b0b2-ef649e9f5c27";
            string resourceGroupName = "rgopenapi";
            string localRulestackName = "lrs1";
            ResourceIdentifier localRulestackResourceId = LocalRulestackResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, localRulestackName);
            LocalRulestackResource localRulestack = client.GetLocalRulestackResource(localRulestackResourceId);

            // get the collection of this LocalRulestackCertificateObjectResource
            LocalRulestackCertificateObjectCollection collection = localRulestack.GetLocalRulestackCertificateObjects();

            // invoke the operation
            string name = "armid1";
            bool result = await collection.ExistsAsync(name);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Exists_CertificateObjectLocalRulestackGetMinimumSetGen()
        {
            // Generated from example definition: specification/paloaltonetworks/resource-manager/PaloAltoNetworks.Cloudngfw/stable/2023-09-01/examples/CertificateObjectLocalRulestack_Get_MinimumSet_Gen.json
            // this example is just showing the usage of "CertificateObjectLocalRulestack_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this LocalRulestackResource created on azure
            // for more information of creating LocalRulestackResource, please refer to the document of LocalRulestackResource
            string subscriptionId = "2bf4a339-294d-4c25-b0b2-ef649e9f5c27";
            string resourceGroupName = "rgopenapi";
            string localRulestackName = "lrs1";
            ResourceIdentifier localRulestackResourceId = LocalRulestackResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, localRulestackName);
            LocalRulestackResource localRulestack = client.GetLocalRulestackResource(localRulestackResourceId);

            // get the collection of this LocalRulestackCertificateObjectResource
            LocalRulestackCertificateObjectCollection collection = localRulestack.GetLocalRulestackCertificateObjects();

            // invoke the operation
            string name = "armid1";
            bool result = await collection.ExistsAsync(name);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetIfExists_CertificateObjectLocalRulestackGetMaximumSetGen()
        {
            // Generated from example definition: specification/paloaltonetworks/resource-manager/PaloAltoNetworks.Cloudngfw/stable/2023-09-01/examples/CertificateObjectLocalRulestack_Get_MaximumSet_Gen.json
            // this example is just showing the usage of "CertificateObjectLocalRulestack_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this LocalRulestackResource created on azure
            // for more information of creating LocalRulestackResource, please refer to the document of LocalRulestackResource
            string subscriptionId = "2bf4a339-294d-4c25-b0b2-ef649e9f5c27";
            string resourceGroupName = "rgopenapi";
            string localRulestackName = "lrs1";
            ResourceIdentifier localRulestackResourceId = LocalRulestackResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, localRulestackName);
            LocalRulestackResource localRulestack = client.GetLocalRulestackResource(localRulestackResourceId);

            // get the collection of this LocalRulestackCertificateObjectResource
            LocalRulestackCertificateObjectCollection collection = localRulestack.GetLocalRulestackCertificateObjects();

            // invoke the operation
            string name = "armid1";
            NullableResponse<LocalRulestackCertificateObjectResource> response = await collection.GetIfExistsAsync(name);
            LocalRulestackCertificateObjectResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine("Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                LocalRulestackCertificateObjectData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetIfExists_CertificateObjectLocalRulestackGetMinimumSetGen()
        {
            // Generated from example definition: specification/paloaltonetworks/resource-manager/PaloAltoNetworks.Cloudngfw/stable/2023-09-01/examples/CertificateObjectLocalRulestack_Get_MinimumSet_Gen.json
            // this example is just showing the usage of "CertificateObjectLocalRulestack_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this LocalRulestackResource created on azure
            // for more information of creating LocalRulestackResource, please refer to the document of LocalRulestackResource
            string subscriptionId = "2bf4a339-294d-4c25-b0b2-ef649e9f5c27";
            string resourceGroupName = "rgopenapi";
            string localRulestackName = "lrs1";
            ResourceIdentifier localRulestackResourceId = LocalRulestackResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, localRulestackName);
            LocalRulestackResource localRulestack = client.GetLocalRulestackResource(localRulestackResourceId);

            // get the collection of this LocalRulestackCertificateObjectResource
            LocalRulestackCertificateObjectCollection collection = localRulestack.GetLocalRulestackCertificateObjects();

            // invoke the operation
            string name = "armid1";
            NullableResponse<LocalRulestackCertificateObjectResource> response = await collection.GetIfExistsAsync(name);
            LocalRulestackCertificateObjectResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine("Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                LocalRulestackCertificateObjectData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }
    }
}
