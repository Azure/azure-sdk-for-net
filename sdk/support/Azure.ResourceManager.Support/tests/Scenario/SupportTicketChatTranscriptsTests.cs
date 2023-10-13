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
    internal class SupportTicketChatTranscriptsTests : SupportManagementTestBase
    {
        private SupportTicketChatTranscriptCollection _supportTicketChatTranscriptCollection;
        private const string _existSupportTicketChatTranscriptsName = "0b60e9a8-98bd-ed11-83ff-000d3a18b532";

        public SupportTicketChatTranscriptsTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void SetUp()
        {
            string existSupportTicketName = "2303060030001646";
            var supportTicket = DefaultSubscription.GetSubscriptionSupportTicket(existSupportTicketName);
            _supportTicketChatTranscriptCollection = supportTicket.Value.GetSupportTicketChatTranscripts();
        }

        [RecordedTest]
        public async Task Exist()
        {
            var flag = await _supportTicketChatTranscriptCollection.ExistsAsync(_existSupportTicketChatTranscriptsName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var supportTicketChatTranscripts = await _supportTicketChatTranscriptCollection.GetAsync(_existSupportTicketChatTranscriptsName);
            ValidateSupportTicketChatTranscriptsData(supportTicketChatTranscripts.Value.Data);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _supportTicketChatTranscriptCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateSupportTicketChatTranscriptsData(list.FirstOrDefault(item => item.Data.Name == _existSupportTicketChatTranscriptsName).Data);
        }

        private void ValidateSupportTicketChatTranscriptsData(ChatTranscriptDetailData supportTicketChatTranscript)
        {
            Assert.IsNotNull(supportTicketChatTranscript);
            Assert.IsNotEmpty(supportTicketChatTranscript.Id);
            Assert.AreEqual(supportTicketChatTranscript.Name, _existSupportTicketChatTranscriptsName);
        }
    }
}
