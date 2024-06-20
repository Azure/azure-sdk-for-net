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
    internal class SupportTicketTests : SupportManagementTestBase
    {
        private SubscriptionSupportTicketCollection _supportAzureServiceCollection => DefaultSubscription.GetSubscriptionSupportTickets();

        private const string _existSupportTicketName = "dotnet_sdk_test_638333917418076091";
        private const string _subscriptionId = "cca0326c-4c31-46d8-8fcb-c67023a46f4b";

        public SupportTicketTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task Exist()
        {
            var flag = await _supportAzureServiceCollection.ExistsAsync(_existSupportTicketName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task CheckSupportTicketNameAvailability()
        {
            var assetName = Recording.GenerateAssetName("test");
            var supportTicketName = $"dotnet_{assetName}";
            var supportTicket = await _supportAzureServiceCollection.GetAsync(_existSupportTicketName);
            var content = new SupportNameAvailabilityContent(supportTicketName, SupportResourceType.MicrosoftSupportSupportTickets);
            var result = await supportTicket.Value.CheckCommunicationNameAvailabilityAsync(content);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Value.IsNameAvailable, true);
        }

        [RecordedTest]
        public async Task Get()
        {
            var supportTicket = await _supportAzureServiceCollection.GetAsync(_existSupportTicketName);
            ValidateGetSupportTicket(supportTicket.Value.Data, _existSupportTicketName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _supportAzureServiceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateGetSupportTicket(list.FirstOrDefault(item => item.Data.Name == _existSupportTicketName).Data, _existSupportTicketName);
        }

        [RecordedTest]
        public async Task Create()
        {
            var assetName = Recording.GenerateAssetName("test");
            var supportTicketName = $"dotnet_sdk_test_new_ticket_name_{assetName}";
            await _supportAzureServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, supportTicketName, BuildSupportTicketData());
            var supportTicket = await _supportAzureServiceCollection.GetAsync(supportTicketName);
            Assert.IsNotNull(supportTicket);
            Assert.IsNotEmpty(supportTicket.Value.Data.Id);
            Assert.AreEqual(supportTicket.Value.Data.Name, supportTicketName);
            Assert.AreEqual(supportTicket.Value.Data.Title, "dotnet sdk unit test, please close");
        }

        [RecordedTest]
        public async Task Update()
        {
            var supportTicket = await _supportAzureServiceCollection.GetAsync(_existSupportTicketName);
            var firstName = supportTicket.Value.Data.ContactDetails.FirstName;
            await supportTicket.Value.UpdateAsync(BuildUpdateSupportTicket(supportTicket.Value.Data));
            supportTicket = await _supportAzureServiceCollection.GetAsync(_existSupportTicketName);
            Assert.IsNotNull(supportTicket);
            Assert.IsNotEmpty(supportTicket.Value.Data.Id);
            Assert.AreEqual(supportTicket.Value.Data.Name, _existSupportTicketName);
            Assert.AreNotEqual(supportTicket.Value.Data.ContactDetails.FirstName, firstName);
        }

        private void ValidateGetSupportTicket(SupportTicketData supportTicket, string supportTicketName)
        {
            Assert.IsNotNull(supportTicket);
            Assert.IsNotEmpty(supportTicket.Id);
            Assert.AreEqual(supportTicket.Name, supportTicketName);
        }

        private SupportTicketData BuildSupportTicketData()
        {
            var ticket = new SupportTicketData("dotnet sdk unit test, please close",
                                "/providers/microsoft.support/services/376afb21-6bd3-91aa-fd58-39fd84d8c201/problemclassifications/03014459-4572-f8f0-32b0-88833f234f25",
                                "Minimal",
                                "No",
                                new SupportContactProfile("test", "test", PreferredContactMethod.Email, "test@microsoft.com", "Dateline Standard Time", "USA", "en-us"),
                                "dotnet sdk unit test, please close",
                                "/providers/microsoft.support/services/376afb21-6bd3-91aa-fd58-39fd84d8c201");
            ticket.ProblemStartOn = new DateTimeOffset(2023, 10, 23, 0, 0, 0, new TimeSpan(0));
            ticket.Require24X7Response = false;
            return ticket;
        }

        private UpdateSupportTicket BuildUpdateSupportTicket(SupportTicketData supportTicket)
        {
            var assetName = Recording.GenerateAssetName("test");
            var updateSupportTicket = new UpdateSupportTicket()
            {
                ContactDetails = new SupportContactProfileContent()
                {
                    FirstName = $"firstName_{assetName}"
                }
            };
            return updateSupportTicket;
        }
    }
}
