// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppConfiguration.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AppConfiguration.Tests
{
    public class SnapshotCollectionTests : AppConfigurationClientBase
    {
        private ResourceGroupResource ResGroup { get; set; }
        private AppConfigurationStoreResource ConfigStore { get; set; }
        private AppConfigurationKeyValueResource KeyValue { get; set; }

        public SnapshotCollectionTests(bool isAsync)
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
                string configurationStoreName = Recording.GenerateAssetName("testapp-");
                AppConfigurationStoreData configurationStoreData = new AppConfigurationStoreData(Location, new AppConfigurationSku("Standard")) { };
                ConfigStore = (await ResGroup.GetAppConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName, configurationStoreData)).Value;

                // Prepare Key Value.
                AppConfigurationKeyValueData keyValueData = new AppConfigurationKeyValueData
                {
                    Value = "myvalue1",
                    ContentType = "the-content-type"
                };
                keyValueData.Tags.Add("t1", "tag-1");
                KeyValue = (await ConfigStore.GetAppConfigurationKeyValues().CreateOrUpdateAsync(WaitUntil.Completed, "key1", keyValueData)).Value;
            }
        }

        [Test]
        public async Task CreateOrUpdateTest()
        {
            string snapshotName = Recording.GenerateAssetName("testapp-");
            SnapshotData snapshotData = new SnapshotData()
            {
                Filters =
                {
                    new KeyValueFilter("key1/*")
                    {
                        Label = "app1"
                    }
                },
                RetentionPeriod = 3600
            };

            SnapshotResource snapshot = (await ConfigStore.GetSnapshots().CreateOrUpdateAsync(WaitUntil.Completed, snapshotName, snapshotData)).Value;

            Assert.IsTrue(snapshot.HasData);
            Assert.IsTrue(snapshot.Data.Name.Equals(snapshotName));
            Assert.IsTrue(snapshot.Data.Filters.FirstOrDefault().Key.Equals("key1/*"));
            Assert.IsTrue(snapshot.Data.RetentionPeriod?.Equals((long)3600));
        }

        [Test]
        public async Task GetTest()
        {
            string snapshotName = Recording.GenerateAssetName("testapp-");
            SnapshotData snapshotData = new SnapshotData()
            {
                Filters =
                {
                    new KeyValueFilter("key1/*")
                    {
                        Label = "app1"
                    }
                },
                RetentionPeriod = 3600
            };

            await ConfigStore.GetSnapshots().CreateOrUpdateAsync(WaitUntil.Completed, snapshotName, snapshotData);

            SnapshotResource snapshot = (await ConfigStore.GetSnapshots().GetAsync(snapshotName)).Value;

            Assert.IsTrue(snapshotName.Equals(snapshot.Data.Name));
            Assert.IsTrue(snapshot.Data.Filters.FirstOrDefault().Key.Equals("key1/*"));
            Assert.IsTrue(snapshot.Data.RetentionPeriod?.Equals((long)3600));
            Assert.IsTrue(snapshot.Data.Status == SnapshotStatus.Ready);
        }

        [Test]
        public async Task ExistsTest()
        {
            string snapshotName = Recording.GenerateAssetName("testapp-");
            SnapshotData snapshotData = new SnapshotData()
            {
                Filters =
                {
                    new KeyValueFilter("key1/*")
                    {
                        Label = "app1"
                    }
                },
                RetentionPeriod = 3600
            };

            await ConfigStore.GetSnapshots().CreateOrUpdateAsync(WaitUntil.Completed, snapshotName, snapshotData);

            SnapshotCollection snapshots = ConfigStore.GetSnapshots();

            string nonExistingSnapshotName = "nonExistingSnapshot";

            Assert.IsTrue((await snapshots.ExistsAsync(snapshotName)).Value);
            Assert.IsFalse((await snapshots.ExistsAsync(nonExistingSnapshotName)).Value);
        }
    }
}
