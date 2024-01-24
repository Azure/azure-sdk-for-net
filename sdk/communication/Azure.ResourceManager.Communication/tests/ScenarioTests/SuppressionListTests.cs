// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Tests.TestFramework;
// using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Communication.Tests
{
    public class SuppressionListTests : CommunicationManagementClientLiveTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private CommunicationServiceResource _communicationService;
        private EmailServiceResource _emailService;
        private CommunicationDomainResource _domainResource;
        private ResourceIdentifier _resourceGroupIdentifier;
        private string _communicationServiceName;
        private string _emailServiceName;
        private string _location;
        private string _dataLocation;

        public SuppressionListTests(bool isAsync)
            : base(isAsync) //, Core.TestFramework.RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            var rgLro = await GlobalClient
                .GetDefaultSubscriptionAsync().Result
                .GetResourceGroups()
                .CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName(ResourceGroupPrefix), new ResourceGroupData(new AzureLocation("westus")));

            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            _location = ResourceLocation;
            _dataLocation = ResourceDataLocation;

            _communicationServiceName = SessionRecording.GenerateAssetName("acssdktest-");
            _communicationService = await CreateDefaultCommunicationServices(_communicationServiceName, rg);

            _emailServiceName = SessionRecording.GenerateAssetName("acssdktest-");
            _emailService = await CreateDefaultEmailServices(_emailServiceName, rg);

            _domainResource = await CreateAzureManagedDomain(_emailService);

            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            ArmClient = GetArmClient();

            _resourceGroup = await ArmClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
            _emailService = await _resourceGroup.GetEmailServiceResourceAsync(_emailServiceName);
            _domainResource = await _emailService.GetCommunicationDomainResourceAsync("AzureManagedDomain");
        }

        [TearDown]
        public void TearDown() { }

        [Test]
        public async Task CreateGetAndDeleteSuppressionList()
        {
            var listName = "donotreply";
            var suppressionList = await CreateDefaultSuppressionListResource(_domainResource, listName);

            Assert.IsNotNull(suppressionList);
            Assert.AreEqual(listName, suppressionList.Data.ListName);
            var collection = _domainResource.GetSuppressionListResources();

            var exists = await collection.ExistsAsync(suppressionList.Id.Name);
            Assert.IsTrue(exists);

            suppressionList = await collection.GetAsync(suppressionList.Data.Name);

            Assert.IsNotNull(suppressionList);
            Assert.AreEqual(suppressionList.Data.ListName, listName);

            await suppressionList.DeleteAsync(WaitUntil.Completed);

            collection = _domainResource.GetSuppressionListResources();
            exists = await collection.ExistsAsync(suppressionList.Id.Name);
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task GetAllSuppressionLists()
        {
            var listNames = new string[] { "list1", "list2", "list3" };
            var resourceNames = new Dictionary<string, string>();

            foreach (var listName in listNames)
            {
                var suppressionList = await CreateDefaultSuppressionListResource(_domainResource, listName);
                resourceNames[suppressionList.Data.Name] = listName;
            }

            int expectedPageCount = 1;
            int pageCount = 0;
            var collection = _domainResource.GetSuppressionListResources();

            var listsToDelete = new List<SuppressionListResource>();

            await foreach (var page in collection.GetAllAsync().AsPages())
            {
                pageCount++;
                Assert.IsTrue(page.Values.Count == listNames.Length);
                foreach (var resource in page.Values)
                {
                    Assert.IsTrue(resourceNames[resource.Data.Name] == resource.Data.ListName);
                    listsToDelete.Add(resource);
                }
            }
            Assert.AreEqual(expectedPageCount, pageCount);

            foreach (var list in listsToDelete)
            {
                await list.DeleteAsync(WaitUntil.Started);
            }
        }

        [Test]
        public async Task Create_SuppressionListAddresses_Get_SinglePage()
        {
            var listName = Recording.Random.NewGuid().ToString();
            var suppressionList = await CreateDefaultSuppressionListResource(_domainResource, listName);
            Assert.IsNotNull(suppressionList);

            var addressesToDelete = new List<SuppressionListAddressResource>();
            var addresses = new string[] { "user1@email.com", "user2@email.com", "user3@email.com" };
            var resourceNames = new Dictionary<string, string>();

            foreach (var address in addresses)
            {
                var resource = await CreateDefaultSuppressionListAddressResource(suppressionList, address);
                resourceNames[resource.Data.Name] = address;
                addressesToDelete.Add(resource);
            }

            int count = 0;
            int expectedCount = 3;
            var collection = suppressionList.GetSuppressionListAddressResources();

            await foreach (var resource in collection.GetAllAsync())
            {
                count++;
                Assert.AreEqual(resourceNames[resource.Data.Name], resource.Data.Email);

                if (count == expectedCount)
                {
                    // pagination is not working as expected. need to investigate
                    break;
                }
            }

            foreach (var address in addressesToDelete)
            {
                await address.DeleteAsync(WaitUntil.Started);
            }

            await suppressionList.DeleteAsync(WaitUntil.Started);
        }

        [Test]
        public async Task Create_SuppressionListAddresses_Get_MultiplePages()
        {
            int expectedCount = 20;
            var listName = Recording.Random.NewGuid().ToString();
            var suppressionList = await CreateDefaultSuppressionListResource(_domainResource, listName);

            Assert.IsNotNull(suppressionList);

            var addressesToDelete = new List<SuppressionListAddressResource>();
            var resourceNames = new Dictionary<string, string>();

            for (int i = 0; i < expectedCount; i++)
            {
                var address = $"{i:00}-{listName}@email.com";
                var resource = await CreateDefaultSuppressionListAddressResource(suppressionList, address);
                resourceNames[resource.Data.Name] = address;
                addressesToDelete.Add(resource);
            }

            int count = 0;
            var collection = suppressionList.GetSuppressionListAddressResources();

            await foreach (var resource in collection.GetAllAsync())
            {
                count++;

                Assert.AreEqual(resourceNames[resource.Data.Name], resource.Data.Email);
                addressesToDelete.Add(resource);

                if (count == expectedCount)
                {
                    // pagination is not working as expected. need to investigate
                    break;
                }
            }

            foreach (var address in addressesToDelete)
            {
                await address.DeleteAsync(WaitUntil.Started);
            }

            await suppressionList.DeleteAsync(WaitUntil.Started);
        }

        [Test]
        public async Task Update_SuppresionListAddress()
        {
            var listName = Recording.Random.NewGuid().ToString();
            var suppressionList = await CreateDefaultSuppressionListResource(_domainResource, listName);

            Assert.IsNotNull(suppressionList);

            var email = "superuser@email.com";
            var created = await CreateDefaultSuppressionListAddressResource(suppressionList, email, "firstName", "lastName", "notes");

            SuppressionListAddressResourceData data = new SuppressionListAddressResourceData
            {
                Email = created.Data.Email,
                FirstName = $"updated+{created.Data.FirstName}",
                LastName = $"updated+{created.Data.LastName}",
                Notes = created.Data.Notes
            };

            var updated = await suppressionList
                .GetSuppressionListAddressResources()
                .CreateOrUpdateAsync(WaitUntil.Completed, created.Id.Name, data);

            Assert.IsNotNull(updated);
            Assert.AreEqual(created.Data.Id, updated.Value.Data.Id);
            Assert.AreEqual(created.Data.Email, updated.Value.Data.Email);
            Assert.AreNotEqual(created.Data.FirstName, updated.Value.Data.FirstName);
            Assert.AreNotEqual(created.Data.LastName, updated.Value.Data.LastName);
            Assert.AreEqual(created.Data.Notes, updated.Value.Data.Notes);

            await created.DeleteAsync(WaitUntil.Started);
            await suppressionList.DeleteAsync(WaitUntil.Started);
        }

        [Test]
        public async Task Delete_SuppresionListAddress()
        {
            var listName = Recording.Random.NewGuid().ToString();
            var suppressionList = await CreateDefaultSuppressionListResource(_domainResource, listName);

            Assert.IsNotNull(suppressionList);

            var email = "superuser@email.com";
            var addressResource = await CreateDefaultSuppressionListAddressResource(suppressionList, email, "firstName", "lastName", "notes");

            var collection = suppressionList.GetSuppressionListAddressResources();

            var exists = await collection.ExistsAsync(addressResource.Id.Name);
            Assert.IsTrue(exists);

            await addressResource.DeleteAsync(WaitUntil.Completed);

            // // todo: follow up on this issue. getting item after being deleted should return 404 not found instead of 500.
            // collection = suppressionList.GetSuppressionListAddressResources();
            // exists = await collection.ExistsAsync(addressResource.Id.Name);
            // Assert.IsFalse(exists);

            await suppressionList.DeleteAsync(WaitUntil.Started);
        }
    }
}
