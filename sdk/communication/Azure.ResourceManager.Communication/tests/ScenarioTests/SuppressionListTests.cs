// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Communication.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using static Azure.Core.HttpHeader;

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
            : base(isAsync, RecordedTestMode.Record)
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

            //var patch = new CommunicationServiceResourcePatch();
            //patch.LinkedDomains.Add(_domainResource.Id.ToString());
            //await _communicationService.UpdateAsync(patch);
        }

        [TearDown]
        public async Task TearDown()
        {
            await foreach (var username in _domainResource.GetSenderUsernameResources().GetAllAsync())
            {
                if (!StringComparer.OrdinalIgnoreCase.Equals(username.Data.Name, "donotreply"))
                {
                    await username.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [Test]
        public async Task CreateOrUpdate()
        {
            var listName = "donotreply";
            var suppressionList = await CreateDefaultSuppressionListResource(_domainResource, listName);

            Assert.IsNotNull(suppressionList);
            Assert.AreEqual(listName, suppressionList.Data.ListName);
        }

        [Test]
        public async Task Delete()
        {
            var listName = "listToDelete";
            var suppressionList = await CreateDefaultSuppressionListResource(_domainResource, listName);
            var collection = _domainResource.GetSuppressionListResources();

            var exists = await collection.ExistsAsync(suppressionList.Id.Name);
            Assert.IsTrue(exists);

            await suppressionList.DeleteAsync(WaitUntil.Completed);

            collection = _domainResource.GetSuppressionListResources();
            exists = await collection.ExistsAsync(suppressionList.Id.Name);
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task Get()
        {
            var listName = "donotreply";
            var suppressionList = await CreateDefaultSuppressionListResource(_domainResource, listName);
            var collection = _domainResource.GetSuppressionListResources();
            var actualSuppressionList = await collection.GetAsync(suppressionList.Data.Name);

            Assert.IsNotNull(actualSuppressionList);
            Assert.AreEqual(actualSuppressionList.Value.Data.ListName, listName);
        }

        [Test]
        public async Task GetAll()
        {
            var listNames = new string[] { "list1", "list2", "list3" };
            var resourceNames = new Dictionary<string, string>();

            foreach (var listName in listNames)
            {
                var suppressionList = await CreateDefaultSuppressionListResource(_domainResource, listName);
                resourceNames[suppressionList.Data.Name] = listName;
            }

            var suppressionLists = await _domainResource.GetSuppressionListResources().GetAllAsync().ToEnumerableAsync();

            Assert.IsNotNull(suppressionLists);
            Assert.IsTrue(suppressionLists.Count() >= listNames.Length);

            foreach (var resourceName in resourceNames)
            {
                var resource = suppressionLists.Where(s => s.Data.Name == resourceName.Key).FirstOrDefault();

                Assert.IsNotNull(resource);
                Assert.AreEqual(resource.Data.ListName, resourceName.Value);
            }
        }

        [Test]
        public async Task AddAddresses()
        {
            var listName = "addressList";
            var suppressionList = await CreateDefaultSuppressionListResource(_domainResource, listName);

            Assert.IsNotNull(suppressionList);

            var addresses = new string[] { "user1@email.com", "user2@email.com", "user3@email.com" };
            var resourceNames = new Dictionary<string, string>();

            foreach (var address in addresses)
            {
                var resource = await CreateDefaultSuppressionListResource(_domainResource, address);
                resourceNames[resource.Data.Name] = address;
            }

            var suppressionListAddresses = await suppressionList.GetSuppressionListAddressResources().GetAllAsync().ToEnumerableAsync();

            Assert.IsNotNull(suppressionListAddresses);
            Assert.IsTrue(suppressionListAddresses.Count() >= addresses.Length);

            foreach (var resourceName in resourceNames)
            {
                var resource = suppressionListAddresses.Where(s => s.Data.Name == resourceName.Key).FirstOrDefault();

                Assert.IsNotNull(resource);
                Assert.AreEqual(resource.Data.Email, resourceName.Value);
            }
        }

        [Test]
        public async Task UpdateAddress()
        {
            var listName = "addressList";
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
        }
    }
}
