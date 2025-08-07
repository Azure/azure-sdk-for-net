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
        private const string _existSupportTicketChatTranscriptsName = "0c948886-cae4-4752-9e3a-9a1eca5ccf07";

        public SupportTicketChatTranscriptsTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            string existSupportTicketName = "2310200010003188";
            var supportTicket = await DefaultSubscription.GetSubscriptionSupportTicketAsync(existSupportTicketName);
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
