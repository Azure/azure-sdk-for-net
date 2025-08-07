// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Support.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Support.Tests
{
    internal class SupportTicketCommunicationTests : SupportManagementTestBase
    {
        private SupportTicketCommunicationCollection _supportTicketCommunicationCollection;
        private SubscriptionSupportTicketResource _subscriptionSupportTicketResource;
        private const string _existSupportTicketCommunicationName = "2310190040011036-lnyu3pmk";
        private const string _subscriptionId = "cca0326c-4c31-46d8-8fcb-c67023a46f4b";
        private const string _existSupportTicketName = "E2ETest638333338893197306";

        public SupportTicketCommunicationTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var supportTicket = await DefaultSubscription.GetSubscriptionSupportTicketAsync(_existSupportTicketName);
            _subscriptionSupportTicketResource = supportTicket.Value;
            _supportTicketCommunicationCollection = _subscriptionSupportTicketResource.GetSupportTicketCommunications();
        }

        [RecordedTest]
        public async Task Exist()
        {
            var flag = await _supportTicketCommunicationCollection.ExistsAsync(_existSupportTicketCommunicationName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task CheckCommunicationNameAvailability()
        {
            var communicationName = $"dotnet_sdk_test_check_communication_name";
            var content = new SupportNameAvailabilityContent(communicationName, SupportResourceType.MicrosoftSupportCommunications);
            var result = await _subscriptionSupportTicketResource.CheckCommunicationNameAvailabilityAsync(content);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Value.IsNameAvailable, true);
        }

        [RecordedTest]
        public async Task Get()
        {
            var supportTicketCommunication = await _supportTicketCommunicationCollection.GetAsync(_existSupportTicketCommunicationName);
            ValidateSupportTicketCommunicationData(supportTicketCommunication.Value.Data, _existSupportTicketCommunicationName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _supportTicketCommunicationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateSupportTicketCommunicationData(list.FirstOrDefault(item => item.Data.Name == _existSupportTicketCommunicationName).Data, _existSupportTicketCommunicationName);
        }

        [RecordedTest]
        public async Task Create()
        {
            var assetName = Recording.GenerateAssetName("test");
            var communicationName = $"dotnet_sdk_test_new_communication_name_{assetName}";
            var resource = SupportTicketCommunicationResource.CreateResourceIdentifier(_subscriptionId, _existSupportTicketName, communicationName);
            var communicationData = new SupportTicketCommunicationData(resource, communicationName, resource.ResourceType, new ResourceManager.Models.SystemData(), SupportTicketCommunicationType.Web, SupportTicketCommunicationDirection.Outbound, "dotnet sdk test", "dotnet sdk test", "dotnet sdk test", DateTimeOffset.UtcNow, null);
            await _supportTicketCommunicationCollection.CreateOrUpdateAsync(WaitUntil.Completed, communicationName, communicationData);
            var supportTicketFileWorkspace = await _supportTicketCommunicationCollection.GetAsync(communicationName);
            ValidateSupportTicketCommunicationData(supportTicketFileWorkspace.Value.Data, communicationName);
        }

        private void ValidateSupportTicketCommunicationData(SupportTicketCommunicationData supportTicketCommunication, string comunicationName)
        {
            Assert.IsNotNull(supportTicketCommunication);
            Assert.IsNotEmpty(supportTicketCommunication.Id);
            Assert.AreEqual(supportTicketCommunication.Name, comunicationName);
        }
    }
}
