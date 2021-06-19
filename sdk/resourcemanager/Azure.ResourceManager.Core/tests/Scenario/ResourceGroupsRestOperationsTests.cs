using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class ResourceGroupsRestOperationsTests : ResourceManagerTestBase
    {
        private ResourceGroupsRestOperations _restClient;
        private string _rgName;

        public ResourceGroupsRestOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _rgName = Recording.GenerateAssetName("testRg");
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(_rgName);
            _restClient = new ResourceGroupsRestOperations(rg.Diagnostics, rg.Pipeline, TestEnvironment.SubscriptionId);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckExistence()
        {
            var response = await _restClient.CheckExistenceAsync(_rgName);
            Assert.IsTrue(response.Value);

            response = await _restClient.CheckExistenceAsync("fakeName");
            Assert.IsFalse(response.Value);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await _restClient.CheckExistenceAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public void CreateOrUpdate()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await _restClient.CreateOrUpdateAsync(null, new ResourceGroupData(LocationData.WestUS)));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await _restClient.CreateOrUpdateAsync(_rgName + "test", null));
        }

        [TestCase]
        [RecordedTest]
        public void Delete()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await _restClient.DeleteAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public void Update()
        {
            var parameters = new ResourceGroupPatchable
            {
                Name = _rgName + "test"
            };
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await _restClient.UpdateAsync(null, parameters));
        }

        [TestCase]
        [RecordedTest]
        public void ExportTemplate()
        {
            var parameters = new ExportTemplateRequest();
            parameters.Resources.Add("*");
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await _restClient.ExportTemplateAsync(null, parameters));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await _restClient.ExportTemplateAsync(_rgName, null));
        }
    }
}
