// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Logic.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Logic.Tests
{
    internal class IntegrationAccountSessionTests : LogicManagementTestBase
    {
        private ResourceIdentifier _integrationAccountIdentifier;
        private IntegrationAccountResource _integrationAccount;

        private IntegrationAccountSessionCollection _sessionCollection => _integrationAccount.GetIntegrationAccountSessions();

        public IntegrationAccountSessionTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.CentralUS));
            var integrationAccount = await CreateIntegrationAccount(rgLro.Value, SessionRecording.GenerateAssetName("intergrationAccount"));
            _integrationAccountIdentifier = integrationAccount.Data.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _integrationAccount = await Client.GetIntegrationAccountResource(_integrationAccountIdentifier).GetAsync();
        }

        private async Task<IntegrationAccountSessionResource> CreateSession(string sessionName)
        {
            IntegrationAccountSessionData data = new IntegrationAccountSessionData(_integrationAccount.Data.Location)
            {
                Content = new BinaryData("456")
            };
            var session = await _sessionCollection.CreateOrUpdateAsync(WaitUntil.Completed, sessionName, data);
            return session.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string sessionName = Recording.GenerateAssetName("session");
            var session = await CreateSession(sessionName);
            Assert.IsNotNull(session);
            Assert.AreEqual(sessionName, session.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string sessionName = Recording.GenerateAssetName("session");
            await CreateSession(sessionName);
            bool flag = await _sessionCollection.ExistsAsync(sessionName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string sessionName = Recording.GenerateAssetName("session");
            await CreateSession(sessionName);
            var session = await _sessionCollection.GetAsync(sessionName);
            Assert.IsNotNull(session);
            Assert.AreEqual(sessionName, session.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string sessionName = Recording.GenerateAssetName("session");
            await CreateSession(sessionName);
            var list = await _sessionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string sessionName = Recording.GenerateAssetName("session");
            var session = await CreateSession(sessionName);
            bool flag = await _sessionCollection.ExistsAsync(sessionName);
            Assert.IsTrue(flag);

            await session.DeleteAsync(WaitUntil.Completed);
            flag = await _sessionCollection.ExistsAsync(sessionName);
            Assert.IsFalse(flag);
        }
    }
}
