// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Logic.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Logic.Tests
{
    internal class IntegrationAccountAssemblyDefinitionTests : LogicManagementTestBase
    {
        private ResourceIdentifier _integrationAccountIdentifier;
        private IntegrationAccountResource _integrationAccount;

        private IntegrationAccountAssemblyDefinitionCollection _assemblyDefinitionCollection => _integrationAccount.GetIntegrationAccountAssemblyDefinitions();

        public IntegrationAccountAssemblyDefinitionTests(bool isAsync) : base(isAsync)
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

        private async Task<IntegrationAccountAssemblyDefinitionResource> CreateAssemblyDefinition(string assemblyDefinitionName)
        {
            byte[] dllDate = File.ReadAllBytes(@"TestData/IntegrationAccountAssemblyContent.dll");
            IntegrationAccountAssemblyProperties properties = new IntegrationAccountAssemblyProperties(assemblyDefinitionName)
            {
                Content = BinaryData.FromObjectAsJson(dllDate),
                ContentType = "application/octet-stream",
            };
            IntegrationAccountAssemblyDefinitionData data = new IntegrationAccountAssemblyDefinitionData(_integrationAccount.Data.Location, properties);
            var assemblyDefinition = await _assemblyDefinitionCollection.CreateOrUpdateAsync(WaitUntil.Completed, assemblyDefinitionName, data);
            return assemblyDefinition.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string assemblyDefinitionName = SessionRecording.GenerateAssetName("assemblyDefinition");
            var assemblyDefinition = await CreateAssemblyDefinition(assemblyDefinitionName);
            Assert.IsNotNull(assemblyDefinition);
            Assert.AreEqual(assemblyDefinitionName,assemblyDefinition.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string assemblyDefinitionName = SessionRecording.GenerateAssetName("assemblyDefinition");
            await CreateAssemblyDefinition(assemblyDefinitionName);
            bool flag = await _assemblyDefinitionCollection.ExistsAsync(assemblyDefinitionName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string assemblyDefinitionName = SessionRecording.GenerateAssetName("assemblyDefinition");
            await CreateAssemblyDefinition(assemblyDefinitionName);
            var assemblyDefinition = await _assemblyDefinitionCollection.GetAsync(assemblyDefinitionName);
            Assert.IsNotNull(assemblyDefinition);
            Assert.AreEqual(assemblyDefinitionName, assemblyDefinition.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string assemblyDefinitionName = SessionRecording.GenerateAssetName("assemblyDefinition");
            await CreateAssemblyDefinition(assemblyDefinitionName);
            var list = await _assemblyDefinitionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string assemblyDefinitionName = SessionRecording.GenerateAssetName("assemblyDefinition");
            var assemblyDefinition = await CreateAssemblyDefinition(assemblyDefinitionName);
            bool flag = await _assemblyDefinitionCollection.ExistsAsync(assemblyDefinitionName);
            Assert.IsTrue(flag);

            await assemblyDefinition.DeleteAsync(WaitUntil.Completed);
            flag = await _assemblyDefinitionCollection.ExistsAsync(assemblyDefinitionName);
            Assert.IsFalse(flag);
        }
    }
}
