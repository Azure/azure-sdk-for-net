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
    internal class TenantSupportTicketCommunicationTests : SupportManagementTestBase
    {
        private SupportTicketNoSubCommunicationCollection _supportTicketNoSubCommunicationCollection;
        private const string _existSupportTicketNoSubCommunicationName = "0b60e9a8-98bd-ed11-83ff-000d3a18b532";

        public TenantSupportTicketCommunicationTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            string existSupportTicketName = "517f2da6-d0f16bf7-ba3a83b0-4552-4551-9e74-f434c37cc06f";
            var supportTicket = await DefaultTenant.GetTenantSupportTicketAsync(existSupportTicketName);
            _supportTicketNoSubCommunicationCollection = supportTicket.Value.GetSupportTicketNoSubCommunications();
        }

        [RecordedTest]
        public async Task Exist()
        {
            var flag = await _supportTicketNoSubCommunicationCollection.ExistsAsync(_existSupportTicketNoSubCommunicationName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var supportTicketCommunication = await _supportTicketNoSubCommunicationCollection.GetAsync(_existSupportTicketNoSubCommunicationName);
            ValidateSupportTicketCommunicationData(supportTicketCommunication.Value.Data);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _supportTicketNoSubCommunicationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateSupportTicketCommunicationData(list.FirstOrDefault(item => item.Data.Name == _existSupportTicketNoSubCommunicationName).Data);
        }

        private void ValidateSupportTicketCommunicationData(SupportTicketCommunicationData supportTicketCommunication)
        {
            Assert.IsNotNull(supportTicketCommunication);
            Assert.IsNotEmpty(supportTicketCommunication.Id);
            Assert.AreEqual(supportTicketCommunication.Name, _existSupportTicketNoSubCommunicationName);
        }
    }
}
