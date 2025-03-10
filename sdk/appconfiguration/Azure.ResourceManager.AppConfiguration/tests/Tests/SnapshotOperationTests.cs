// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppConfiguration.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AppConfiguration.Tests
{
    public class SnapshotOperationTests : AppConfigurationClientBase
    {
        private ResourceGroupResource ResGroup { get; set; }
        private AppConfigurationStoreResource ConfigStore { get; set; }
        private string ConfigurationStoreName { get; set; }
        private AppConfigurationSnapshotResource Snapshot { get; set; }
        private string SnapshotName { get; set; }

        public SnapshotOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
                string groupName = Recording.GenerateAssetName(ResourceGroupPrefix);
                ResGroup = (await ArmClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, groupName, new ResourceGroupData(Location))).Value;

                ConfigurationStoreName = Recording.GenerateAssetName("testapp-");
                AppConfigurationStoreData configurationStoreData = new AppConfigurationStoreData(Location, new AppConfigurationSku("Standard")) { };
                ConfigStore = (await ResGroup.GetAppConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, ConfigurationStoreName, configurationStoreData)).Value;

                // Prepare Key Value.
                AppConfigurationKeyValueData keyValueData = new AppConfigurationKeyValueData
                {
                    Value = "myvalue1",
                    ContentType = "the-content-type"
                };
                keyValueData.Tags.Add("t1", "tag-1");
                AppConfigurationKeyValueResource KeyValue = (await ConfigStore.GetAppConfigurationKeyValues().CreateOrUpdateAsync(WaitUntil.Completed, "key1", keyValueData)).Value;

                // Prepare Snapshot.
                SnapshotName = Recording.GenerateAssetName("testapp-snapshot");
                AppConfigurationSnapshotData snapshotData = new AppConfigurationSnapshotData()
                {
                    Filters =
                    {
                        new SnapshotKeyValueFilter("key1/*")
                        {
                            Label = "app1"
                        }
                    },
                    RetentionPeriod = 3600,
                };
                Snapshot = (await ConfigStore.GetAppConfigurationSnapshots().CreateOrUpdateAsync(WaitUntil.Completed, SnapshotName, snapshotData)).Value;
            }
        }

        [Test]
        public async Task GetTest()
        {
            AppConfigurationSnapshotResource snapshot = await Snapshot.GetAsync();

            Assert.IsTrue(snapshot.Data.Name.Equals(SnapshotName));
            Assert.IsTrue(snapshot.Data.Filters.FirstOrDefault().Key.Equals("key1/*"));
        }
    }
}
