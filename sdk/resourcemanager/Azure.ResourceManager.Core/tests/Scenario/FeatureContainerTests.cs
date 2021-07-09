using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class FeatureContainerTests : ResourceManagerTestBase
    {
        public FeatureContainerTests(bool isAsync)
           : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task List()
        {
            Provider provider = await Client.DefaultSubscription.GetProviders().GetAsync("Microsoft.Compute");
            Feature testFeature = null;
            await foreach (var feature in provider.GetFeatures().ListAsync())
            {
                testFeature = feature;
                break;
            }
            Assert.IsNotNull(testFeature);
            Assert.IsNotNull(testFeature.Data.Id);
            Assert.IsNotNull(testFeature.Data.Name);
            Assert.IsNotNull(testFeature.Data.Properties);
            Assert.IsNotNull(testFeature.Data.Type);
        }

        [RecordedTest]
        public async Task Get()
        {
            Provider provider = await Client.DefaultSubscription.GetProviders().GetAsync("Microsoft.Compute");
            Feature feature = await provider.GetFeatures().GetAsync("AHUB");
            Assert.IsNotNull(feature);
            Assert.IsNotNull(feature.Data.Id);
            Assert.AreEqual("Microsoft.Compute/AHUB", feature.Data.Name);
            Assert.IsNotNull(feature.Data.Properties);
            Assert.IsNotNull(feature.Data.Type);
        }

        [RecordedTest]
        public async Task TryGet()
        {
            Provider provider = await Client.DefaultSubscription.GetProviders().GetAsync("Microsoft.Compute");
            Feature feature = await provider.GetFeatures().TryGetAsync("AHUB");
            Assert.IsNotNull(feature);
            Assert.IsNotNull(feature.Data.Id);
            Assert.AreEqual("Microsoft.Compute/AHUB", feature.Data.Name);
            Assert.IsNotNull(feature.Data.Properties);
            Assert.IsNotNull(feature.Data.Type);
        }

        [RecordedTest]
        public async Task DoesExist()
        {
            Provider provider = await Client.DefaultSubscription.GetProviders().GetAsync("Microsoft.Compute");
            Assert.IsTrue(await provider.GetFeatures().DoesExistAsync("AHUB"));
        }
    }
}
