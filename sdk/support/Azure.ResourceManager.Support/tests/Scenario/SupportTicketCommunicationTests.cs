// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Support.Tests
{
    internal class SupportTicketCommunicationTests : SupportManagementTestBase
    {
        private SupportTicketCommunicationCollection _supportTicketCommunicationCollection;
        private const string _existSupportTicketCommunicationName = "0b60e9a8-98bd-ed11-83ff-000d3a18b532";

        public SupportTicketCommunicationTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            string existSupportTicketName = "2303060030001646";
            var supportTicket = await DefaultSubscription.GetSupportTickets().GetAsync(existSupportTicketName);
            _supportTicketCommunicationCollection = supportTicket.Value.GetSupportTicketCommunications();
        }

        [RecordedTest]
        public async Task Exist()
        {
            var flag = await _supportTicketCommunicationCollection.ExistsAsync(_existSupportTicketCommunicationName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var supportTicketCommunication = await _supportTicketCommunicationCollection.GetAsync(_existSupportTicketCommunicationName);
            ValidateSupportTicketCommunicationData(supportTicketCommunication.Value.Data);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _supportTicketCommunicationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateSupportTicketCommunicationData(list.FirstOrDefault(item => item.Data.Name == _existSupportTicketCommunicationName).Data);
        }

        private void ValidateSupportTicketCommunicationData(SupportTicketCommunicationData supportTicketCommunication)
        {
            Assert.IsNotNull(supportTicketCommunication);
            Assert.IsNotEmpty(supportTicketCommunication.Id);
            Assert.AreEqual(supportTicketCommunication.Name, _existSupportTicketCommunicationName);
        }
    }
}
