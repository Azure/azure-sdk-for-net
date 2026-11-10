// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.RedisEnterprise.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.RedisEnterprise.Tests
{
    [NonParallelizable]
    public class CreateUpdateDeleteFunctionalTests : RedisEnterpriseManagementTestBase
    {
        public CreateUpdateDeleteFunctionalTests(bool isAsync)
                    : base(isAsync /*,RecordedTestMode.Record*/)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private RedisEnterpriseClusterCollection Collection { get; set; }

        private AzureLocation KeyspaceNotificationsLocation => new("centralindia");

        private async Task SetCollectionsAsync(AzureLocation? location = null)
        {
            ResourceGroup = await CreateResourceGroupAsync(location);
            Collection = ResourceGroup.GetRedisEnterpriseClusters();
        }

        private RedisEnterpriseClusterData CreateFirewallClusterData(params FirewallRule[] rules)
        {
            var data = new RedisEnterpriseClusterData(
                DefaultLocation,
                new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB1))
            {
                PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled
            };
            foreach (FirewallRule rule in rules)
            {
                data.FirewallRules.Add(rule);
            }
            return data;
        }

        private static void AssertFirewallRules(RedisEnterpriseClusterResource cluster, params FirewallRule[] expected)
        {
            Assert.That(cluster.Data.FirewallRules, Is.Not.Null);
            Assert.That(
                cluster.Data.FirewallRules.Select(rule => new { rule.Name, rule.SourceAddressPrefix }),
                Is.EquivalentTo(expected.Select(rule => new { rule.Name, rule.SourceAddressPrefix })));
        }

        [Test]
        public async Task CreateUpdateDeleteTest()
        {
            await SetCollectionsAsync();

            string redisEnterpriseCacheName = Recording.GenerateAssetName("RedisEnterpriseBegin");
            var data = new RedisEnterpriseClusterData(
                DefaultLocation,
                new RedisEnterpriseSku(RedisEnterpriseSkuName.EnterpriseE10)
                {
                    Capacity = 2
                })
            {
                MinimumTlsVersion = RedisEnterpriseTlsVersion.Tls1_2,
                HighAvailability = RedisEnterpriseHighAvailability.Enabled,
                PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled,
                Zones = { "1", "2", "3" }
            };

            var clusterResponse = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName, data)).Value;
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.EnterpriseE10, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(RedisEnterpriseHighAvailability.Enabled, clusterResponse.Data.HighAvailability);
            Assert.AreEqual(RedisEnterpriseRedundancyMode.ZR, clusterResponse.Data.RedundancyMode);
            Assert.AreEqual(2, clusterResponse.Data.Sku.Capacity);

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.EnterpriseE10, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(RedisEnterpriseHighAvailability.Enabled, clusterResponse.Data.HighAvailability);
            Assert.AreEqual(RedisEnterpriseRedundancyMode.ZR, clusterResponse.Data.RedundancyMode);
            Assert.AreEqual(2, clusterResponse.Data.Sku.Capacity);

            var databaseCollection = clusterResponse.GetRedisEnterpriseDatabases();
            string databaseName = "default";
            var databaseData = new RedisEnterpriseDatabaseData()
            {
                ClientProtocol = RedisEnterpriseClientProtocol.Encrypted,
                ClusteringPolicy = RedisEnterpriseClusteringPolicy.EnterpriseCluster,
                EvictionPolicy = RedisEnterpriseEvictionPolicy.NoEviction,
                Persistence = new RedisPersistenceSettings()
                {
                    IsAofEnabled = true,
                    AofFrequency = PersistenceSettingAofFrequency.OneSecond
                },
                Modules =
                {
                    new RedisEnterpriseModule("RedisBloom")
                    {
                        Args = "ERROR_RATE 0.01 INITIAL_SIZE 400"
                    },
                    new RedisEnterpriseModule("RedisTimeSeries")
                    {
                        Args = "RETENTION_POLICY 20"
                    },
                    new RedisEnterpriseModule(name: "RediSearch")
                }
            };

            var databaseResponse = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.EnterpriseCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);
            Assert.AreEqual(3, databaseResponse.Data.Modules.Count);

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.EnterpriseCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);
            Assert.AreEqual(3, databaseResponse.Data.Modules.Count);

            await databaseResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await databaseCollection.ExistsAsync(databaseName)).Value;
            Assert.IsFalse(falseResult);

            await clusterResponse.DeleteAsync(WaitUntil.Completed);
            falseResult = (await Collection.ExistsAsync(redisEnterpriseCacheName)).Value;
            Assert.IsFalse(falseResult);
        }

        // Preserve the recording name while making the method's coverage explicit.
        [TestCase(TestName = "CreateUpdateDeleteTest2")]
        public async Task CreateUpdateDeleteWithMaintenanceWindowsAndKeyspaceNotifications()
        {
            await SetCollectionsAsync(KeyspaceNotificationsLocation);

            string redisEnterpriseCacheName = Recording.GenerateAssetName("RedisEnterpriseBegin");
            var data = new RedisEnterpriseClusterData(
                DefaultLocation,
                new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB1)
                {
                })
            {
                MinimumTlsVersion = RedisEnterpriseTlsVersion.Tls1_2,
                HighAvailability = RedisEnterpriseHighAvailability.Disabled,
                PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled,
                MaintenanceWindows =
                {
                    new RedisEnterpriseMaintenanceWindow(RedisEnterpriseMaintenanceWindowType.Weekly, System.TimeSpan.FromHours(6), 3)
                    {
                        ScheduleDayOfWeek = RedisEnterpriseMaintenanceDayOfWeek.Monday
                    },
                    new RedisEnterpriseMaintenanceWindow(RedisEnterpriseMaintenanceWindowType.Weekly, System.TimeSpan.FromHours(6), 3)
                    {
                        ScheduleDayOfWeek = RedisEnterpriseMaintenanceDayOfWeek.Tuesday
                    },
                    new RedisEnterpriseMaintenanceWindow(RedisEnterpriseMaintenanceWindowType.Weekly, System.TimeSpan.FromHours(6), 3)
                    {
                        ScheduleDayOfWeek = RedisEnterpriseMaintenanceDayOfWeek.Wednesday
                    }
                }
            };

            var clusterResponse = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName, data)).Value;
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.BalancedB1, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(RedisEnterpriseHighAvailability.Disabled, clusterResponse.Data.HighAvailability);
            Assert.AreEqual(3, clusterResponse.Data.MaintenanceWindows.Count);
            Assert.That(
                clusterResponse.Data.MaintenanceWindows.Select(window => window.ScheduleDayOfWeek),
                Is.EquivalentTo(new[]
                {
                    RedisEnterpriseMaintenanceDayOfWeek.Monday,
                    RedisEnterpriseMaintenanceDayOfWeek.Tuesday,
                    RedisEnterpriseMaintenanceDayOfWeek.Wednesday
                }));

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.BalancedB1, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(RedisEnterpriseHighAvailability.Disabled, clusterResponse.Data.HighAvailability);
            Assert.AreEqual(3, clusterResponse.Data.MaintenanceWindows.Count);
            Assert.That(
                clusterResponse.Data.MaintenanceWindows.Select(window => window.StartHourUtc),
                Is.All.EqualTo(3));

            var databaseCollection = clusterResponse.GetRedisEnterpriseDatabases();
            string databaseName = "default";
            var databaseData = new RedisEnterpriseDatabaseData()
            {
                ClientProtocol = RedisEnterpriseClientProtocol.Encrypted,
                ClusteringPolicy = RedisEnterpriseClusteringPolicy.OssCluster,
                EvictionPolicy = RedisEnterpriseEvictionPolicy.NoEviction,
                NotifyKeyspaceEvents = "KEA",
            };

            var databaseResponse = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.OssCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);
            Assert.AreEqual("KEA", databaseResponse.Data.NotifyKeyspaceEvents);

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.OssCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);
            Assert.AreEqual("KEA", databaseResponse.Data.NotifyKeyspaceEvents);

            databaseData.NotifyKeyspaceEvents = "KEm";
            databaseResponse = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.AreEqual("KEm", databaseResponse.Data.NotifyKeyspaceEvents);

            databaseResponse = await databaseResponse.GetAsync();
            Assert.AreEqual("KEm", databaseResponse.Data.NotifyKeyspaceEvents);

            // Disabling high availability
            data.HighAvailability = RedisEnterpriseHighAvailability.Enabled;
            data.MaintenanceWindows.Clear();
            data.MaintenanceWindows.Add(
                new RedisEnterpriseMaintenanceWindow(RedisEnterpriseMaintenanceWindowType.Weekly, System.TimeSpan.FromHours(6), 12)
                {
                    ScheduleDayOfWeek = RedisEnterpriseMaintenanceDayOfWeek.Friday
                });
            data.MaintenanceWindows.Add(
                new RedisEnterpriseMaintenanceWindow(RedisEnterpriseMaintenanceWindowType.Weekly, System.TimeSpan.FromHours(6), 12)
                {
                    ScheduleDayOfWeek = RedisEnterpriseMaintenanceDayOfWeek.Saturday
                });
            data.MaintenanceWindows.Add(
                new RedisEnterpriseMaintenanceWindow(RedisEnterpriseMaintenanceWindowType.Weekly, System.TimeSpan.FromHours(6), 12)
                {
                    ScheduleDayOfWeek = RedisEnterpriseMaintenanceDayOfWeek.Sunday
                });

            clusterResponse = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName, data)).Value;
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.BalancedB1, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(RedisEnterpriseHighAvailability.Enabled, clusterResponse.Data.HighAvailability);
            Assert.AreEqual(3, clusterResponse.Data.MaintenanceWindows.Count);
            Assert.That(
                clusterResponse.Data.MaintenanceWindows.Select(window => window.ScheduleDayOfWeek),
                Is.EquivalentTo(new[]
                {
                    RedisEnterpriseMaintenanceDayOfWeek.Friday,
                    RedisEnterpriseMaintenanceDayOfWeek.Saturday,
                    RedisEnterpriseMaintenanceDayOfWeek.Sunday
                }));

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.BalancedB1, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(RedisEnterpriseHighAvailability.Enabled, clusterResponse.Data.HighAvailability);
            Assert.AreEqual(3, clusterResponse.Data.MaintenanceWindows.Count);
            Assert.That(
                clusterResponse.Data.MaintenanceWindows.Select(window => window.StartHourUtc),
                Is.All.EqualTo(12));

            await databaseResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await databaseCollection.ExistsAsync(databaseName)).Value;
            Assert.IsFalse(falseResult);

            await clusterResponse.DeleteAsync(WaitUntil.Completed);
            falseResult = (await Collection.ExistsAsync(redisEnterpriseCacheName)).Value;
            Assert.IsFalse(falseResult);
        }

        [Test]
        public async Task CreateUpdateDeleteWithFirewallRules()
        {
            await SetCollectionsAsync();

            try
            {
                string clusterName = Recording.GenerateAssetName("RedisFirewall");
                var initialRules = new[]
                {
                    new FirewallRule("allow-ip", "203.0.113.1"),
                    new FirewallRule("allow-subnet", "203.0.113.0/24"),
                    new FirewallRule("allow-service", "AzureCloud")
                };
                var data = CreateFirewallClusterData(initialRules);
                var cluster = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data)).Value;
                AssertFirewallRules(cluster, initialRules);

                cluster = (await cluster.GetAsync()).Value;
                AssertFirewallRules(cluster, initialRules);

                var listedCluster = (await Collection.GetAllAsync().ToEnumerableAsync())
                    .Single(item => item.Data.Name == clusterName);
                AssertFirewallRules(listedCluster, initialRules);

                var replacementRules = new[]
                {
                    new FirewallRule("allow-ip", "203.0.113.2"),
                    new FirewallRule("allow-new-subnet", "198.51.100.0/24")
                };
                var replacement = new RedisEnterpriseClusterPatch();
                foreach (FirewallRule rule in replacementRules)
                {
                    replacement.FirewallRules.Add(rule);
                }
                cluster = (await cluster.UpdateAsync(WaitUntil.Completed, replacement)).Value;
                AssertFirewallRules(cluster, replacementRules);
                cluster = (await cluster.GetAsync()).Value;
                AssertFirewallRules(cluster, replacementRules);

                var preserveRules = new RedisEnterpriseClusterPatch
                {
                    PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled
                };
                cluster = (await cluster.UpdateAsync(WaitUntil.Completed, preserveRules)).Value;
                AssertFirewallRules(cluster, replacementRules);
                cluster = (await cluster.GetAsync()).Value;
                Assert.AreEqual(RedisEnterprisePublicNetworkAccess.Enabled, cluster.Data.PublicNetworkAccess);
                AssertFirewallRules(cluster, replacementRules);

                var clearRules = new RedisEnterpriseClusterPatch();
                clearRules.FirewallRules.Clear();
                cluster = (await cluster.UpdateAsync(WaitUntil.Completed, clearRules)).Value;
                AssertFirewallRules(cluster);
                cluster = (await cluster.GetAsync()).Value;
                AssertFirewallRules(cluster);
                Assert.AreEqual(RedisEnterprisePublicNetworkAccess.Enabled, cluster.Data.PublicNetworkAccess);

                await cluster.DeleteAsync(WaitUntil.Completed);
                Assert.IsFalse((await Collection.ExistsAsync(clusterName)).Value);
            }
            finally
            {
                await ResourceGroup.DeleteAsync(WaitUntil.Completed);
            }
        }

        [TestCase(false, TestName = "ClearFirewallRulesWithExplicitNullUsingProperties")]
        [TestCase(true, TestName = "ClearFirewallRulesWithExplicitNullUsingFactory")]
        public async Task ClearFirewallRulesWithExplicitNull(bool useFactory)
        {
            await SetCollectionsAsync();

            try
            {
                string clusterName = Recording.GenerateAssetName("RedisFirewallNull");
                var initialRules = new[]
                {
                    new FirewallRule("allow-ip", "203.0.113.1"),
                    new FirewallRule("allow-subnet", "203.0.113.0/24")
                };
                var cluster = (await Collection.CreateOrUpdateAsync(
                    WaitUntil.Completed, clusterName, CreateFirewallClusterData(initialRules))).Value;
                AssertFirewallRules(cluster, initialRules);

                var omittedRules = useFactory
                    ? ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterPatch(
                        publicNetworkAccess: RedisEnterprisePublicNetworkAccess.Enabled)
                    : new RedisEnterpriseClusterPatch
                    {
                        PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled
                    };
                cluster = (await cluster.UpdateAsync(WaitUntil.Completed, omittedRules)).Value;
                AssertFirewallRules(cluster, initialRules);

                var nullRules = useFactory
                    ? ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterPatch(firewallRules: null)
                    : new RedisEnterpriseClusterPatch { FirewallRules = null };
                cluster = (await cluster.UpdateAsync(WaitUntil.Completed, nullRules)).Value;
                cluster = (await cluster.GetAsync()).Value;
                AssertFirewallRules(cluster);
                Assert.AreEqual(RedisEnterprisePublicNetworkAccess.Enabled, cluster.Data.PublicNetworkAccess);

                cluster = (await cluster.UpdateAsync(
                    WaitUntil.Completed, new RedisEnterpriseClusterPatch { FirewallRules = initialRules })).Value;
                AssertFirewallRules(cluster, initialRules);

                var nullPut = useFactory
                    ? ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterData(
                        location: DefaultLocation,
                        sku: new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB1),
                        publicNetworkAccess: RedisEnterprisePublicNetworkAccess.Enabled,
                        firewallRules: null)
                    : CreateFirewallClusterData(initialRules);
                if (!useFactory)
                {
                    nullPut.FirewallRules = null;
                }
                cluster = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, nullPut)).Value;
                cluster = (await cluster.GetAsync()).Value;
                AssertFirewallRules(cluster);
                Assert.AreEqual(RedisEnterprisePublicNetworkAccess.Enabled, cluster.Data.PublicNetworkAccess);

                var disablePublicAccess = useFactory
                    ? ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterPatch(
                        publicNetworkAccess: RedisEnterprisePublicNetworkAccess.Disabled, firewallRules: null)
                    : new RedisEnterpriseClusterPatch
                    {
                        PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Disabled,
                        FirewallRules = null
                    };
                cluster = (await cluster.UpdateAsync(WaitUntil.Completed, disablePublicAccess)).Value;
                cluster = (await cluster.GetAsync()).Value;
                AssertFirewallRules(cluster);
                Assert.AreEqual(RedisEnterprisePublicNetworkAccess.Disabled, cluster.Data.PublicNetworkAccess);

                cluster = (await cluster.UpdateAsync(WaitUntil.Completed,
                    new RedisEnterpriseClusterPatch
                    {
                        PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled
                    })).Value;
                cluster = (await cluster.GetAsync()).Value;
                AssertFirewallRules(cluster);
                Assert.AreEqual(RedisEnterprisePublicNetworkAccess.Enabled, cluster.Data.PublicNetworkAccess);
            }
            finally
            {
                await ResourceGroup.DeleteAsync(WaitUntil.Completed);
            }
        }

        [TestCase(false, TestName = "ReplaceAndClearFirewallRulesWithEmptyPut")]
        [TestCase(true, TestName = "ReplaceAndClearFirewallRulesWithOmittedPut")]
        public async Task ReplaceAndClearFirewallRulesWithPut(bool omitFirewallRules)
        {
            await SetCollectionsAsync();

            try
            {
                string clusterName = Recording.GenerateAssetName("RedisFirewall");
                var data = CreateFirewallClusterData(
                    new FirewallRule("allow-ip", "203.0.113.1"),
                    new FirewallRule("allow-subnet", "203.0.113.0/24"));
                var cluster = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data)).Value;
                AssertFirewallRules(cluster, data.FirewallRules.ToArray());

                var replacementRule = new FirewallRule("allow-ip", "198.51.100.1");
                data.FirewallRules.Clear();
                data.FirewallRules.Add(replacementRule);
                cluster = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data)).Value;
                AssertFirewallRules(cluster, replacementRule);
                cluster = (await cluster.GetAsync()).Value;
                AssertFirewallRules(cluster, replacementRule);

                if (omitFirewallRules)
                {
                    data = CreateFirewallClusterData();
                }
                else
                {
                    data.FirewallRules.Clear();
                }
                cluster = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data)).Value;
                AssertFirewallRules(cluster);
                cluster = (await cluster.GetAsync()).Value;
                AssertFirewallRules(cluster);
                Assert.AreEqual(RedisEnterprisePublicNetworkAccess.Enabled, cluster.Data.PublicNetworkAccess);
            }
            finally
            {
                await ResourceGroup.DeleteAsync(WaitUntil.Completed);
            }
        }

        [TestCase(false, TestName = "DisablingPublicNetworkAccessClearsFirewallRules")]
        [TestCase(true, TestName = "UpdatingPublicNetworkAccessWithExplicitFirewallRules")]
        public async Task UpdatePublicNetworkAccessWithFirewallRules(bool specifyFirewallRules)
        {
            await SetCollectionsAsync();

            try
            {
                string clusterName = Recording.GenerateAssetName("RedisFirewall");
                var rule = new FirewallRule("allow-ip", "203.0.113.1");
                var data = CreateFirewallClusterData(rule);
                var cluster = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data)).Value;
                AssertFirewallRules(cluster, rule);

                var conflictingRules = new RedisEnterpriseClusterPatch
                {
                    PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Disabled,
                    FirewallRules = { rule }
                };
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(
                    async () => await cluster.UpdateAsync(WaitUntil.Completed, conflictingRules));
                Assert.AreEqual(400, exception.Status);
                cluster = (await cluster.GetAsync()).Value;
                Assert.AreEqual(RedisEnterprisePublicNetworkAccess.Enabled, cluster.Data.PublicNetworkAccess);
                AssertFirewallRules(cluster, rule);

                var disablePublicNetworkAccess = new RedisEnterpriseClusterPatch
                {
                    PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Disabled
                };
                if (specifyFirewallRules)
                {
                    disablePublicNetworkAccess.FirewallRules.Clear();
                }
                cluster = (await cluster.UpdateAsync(WaitUntil.Completed, disablePublicNetworkAccess)).Value;
                AssertFirewallRules(cluster);
                cluster = (await cluster.GetAsync()).Value;
                Assert.AreEqual(RedisEnterprisePublicNetworkAccess.Disabled, cluster.Data.PublicNetworkAccess);
                AssertFirewallRules(cluster);

                var enablePublicNetworkAccess = new RedisEnterpriseClusterPatch
                {
                    PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled
                };
                if (specifyFirewallRules)
                {
                    enablePublicNetworkAccess.FirewallRules.Add(new FirewallRule("allow-new-ip", "198.51.100.1"));
                }
                FirewallRule[] expectedRules = enablePublicNetworkAccess.FirewallRules.ToArray();
                cluster = (await cluster.UpdateAsync(WaitUntil.Completed, enablePublicNetworkAccess)).Value;
                AssertFirewallRules(cluster, expectedRules);
                cluster = (await cluster.GetAsync()).Value;
                Assert.AreEqual(RedisEnterprisePublicNetworkAccess.Enabled, cluster.Data.PublicNetworkAccess);
                AssertFirewallRules(cluster, expectedRules);
            }
            finally
            {
                await ResourceGroup.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task CreateUpdateTestWithNoClusterPolicy()
        {
            await SetCollectionsAsync();

            string redisEnterpriseCacheName = Recording.GenerateAssetName("RedisEnterpriseBegin");
            var data = new RedisEnterpriseClusterData(
                DefaultLocation,
                new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB1))
            {
                MinimumTlsVersion = RedisEnterpriseTlsVersion.Tls1_2,
                HighAvailability = RedisEnterpriseHighAvailability.Enabled,
                PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled
            };

            var clusterResponse = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName, data)).Value;
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.BalancedB1, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(RedisEnterpriseHighAvailability.Enabled, clusterResponse.Data.HighAvailability);

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.BalancedB1, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(RedisEnterpriseHighAvailability.Enabled, clusterResponse.Data.HighAvailability);

            var databaseCollection = clusterResponse.GetRedisEnterpriseDatabases();
            string databaseName = "default";
            var databaseData = new RedisEnterpriseDatabaseData()
            {
                ClientProtocol = RedisEnterpriseClientProtocol.Encrypted,
                ClusteringPolicy = RedisEnterpriseClusteringPolicy.NoCluster,
                EvictionPolicy = RedisEnterpriseEvictionPolicy.NoEviction,
                Persistence = new RedisPersistenceSettings()
                {
                    IsAofEnabled = true,
                    AofFrequency = PersistenceSettingAofFrequency.OneSecond
                },
            };

            var databaseResponse = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.NoCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.NoCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);

            // Updating Cluster policy
            databaseData.ClusteringPolicy = RedisEnterpriseClusteringPolicy.EnterpriseCluster;

            databaseResponse = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.EnterpriseCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.EnterpriseCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);

            // Delete database and cluster
            await databaseResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await databaseCollection.ExistsAsync(databaseName)).Value;
            Assert.IsFalse(falseResult);

            await clusterResponse.DeleteAsync(WaitUntil.Completed);
            falseResult = (await Collection.ExistsAsync(redisEnterpriseCacheName)).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
