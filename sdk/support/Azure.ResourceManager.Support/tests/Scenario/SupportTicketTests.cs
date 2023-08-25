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
    internal class SupportTicketTests : SupportManagementTestBase
    {
        private SupportTicketCollection _supportAzureServiceCollection => DefaultSubscription.GetSupportTickets();
        private const string _existSupportTicketName = "2303060030001646";

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
        public async Task Get()
        {
            var supportTicket = await _supportAzureServiceCollection.GetAsync(_existSupportTicketName);
            ValidateSupportTicket(supportTicket.Value.Data);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _supportAzureServiceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateSupportTicket(list.FirstOrDefault(item => item.Data.Name == _existSupportTicketName).Data);
        }

        private void ValidateSupportTicket(SupportTicketData supportTicket)
        {
            Assert.IsNotNull(supportTicket);
            Assert.IsNotEmpty(supportTicket.Id);
            Assert.AreEqual(supportTicket.Name, _existSupportTicketName);
        }
    }
}
