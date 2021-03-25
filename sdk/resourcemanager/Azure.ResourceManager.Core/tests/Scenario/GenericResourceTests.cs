using System.Runtime.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class GenericResourceTests : ResourceManagerTestBase
    {   
        private string _rgName;

        private readonly string _location = "southcentralus";

        protected AzureResourceManagerClient _client;

        private SubscriptionOperations _subscriptionOperations;
        public GenericResourceTests(bool isAsync)
            : base(isAsync)
        {
        }
        
        [OneTimeSetUp]
        public void OneTimeSetup()
        {   
            TestContext.Progress.WriteLine("here");
            _client = GetArmClient();
            _rgName = Recording.GenerateAssetName("testRg-");
            _subscriptionOperations = _client.GetSubscriptionOperations(TestEnvironment.SubscriptionId);
            _ = _subscriptionOperations.GetResourceGroupContainer().Construct(_location).CreateOrUpdate(_rgName);
            StopSessionRecording();
        }

        [TestCase]
        [RecordedTest]
        public void GetGenerics()
        {
            var asetid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}/providers/Microsoft.Compute/availabilitySets/testavset";
            //var genericResourceOperations = new GenericResourceOperations(_subscriptionOperations, asetid);
            //Assert.Throws<RequestFailedException>(async () => await genericResourceOperations.GetAsync());
        }
        
        [TestCase]
        [RecordedTest]
        public async Task GenericsConfirmException()
        {
            var asetid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}/providers/Microsoft.Compute/availabilitySets/testavset";
            var genericResourceOperations = new GenericResourceOperations(_subscriptionOperations, asetid);
            try
            {
              await genericResourceOperations.GetAsync();
            }
            catch(RequestFailedException ex)
            {
                Assert.Equals(ex.Status, 404);
            }
        }
    }
}
