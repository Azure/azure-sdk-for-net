// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ClientAbstractionTests
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.Storage;
    using Microsoft.Hadoop.Client.WebHCatRest;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.Configuration;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.AzureManagementClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;
    using Configuration = Management.Configuration.Data;

    [TestClass]
    public class PocoClientTests : IntegrationTestBase
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        internal IRetryPolicy GetRetryPolicy()
        {
            return RetryPolicyFactory.CreateExponentialRetryPolicy(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(100), 3, 0.2);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        public async Task ICanPerformA_ListNonExistingContainer_Using_PocoClientAbstraction()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            using (var client = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(credentials, GetAbstractionContext(), false))
            {
                var result = await client.ListContainer(GetRandomClusterName());
                Assert.IsNull(result);
            }
        }
      
        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [ExpectedException(typeof(HDInsightClusterDoesNotExistException))]
        public async Task ICanPerformA_DeleteNonExistingContainer_Using_PocoClientAbstraction()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            await ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>()
                                   .Create(credentials, GetAbstractionContext(), false)
                                   .DeleteContainer(GetRandomClusterName());
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [ExpectedException(typeof(HttpLayerException))]
        public async Task ICanPerformA_DeleteNonExistingContainerInternal_Using_PocoClientAbstraction()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            await ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>()
                                   .Create(credentials, GetAbstractionContext(), false)
                                   .DeleteContainer(GetRandomClusterName(), "East US");
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [ExpectedException(typeof(HttpLayerException))]
        public async Task ICanPerformA_DeleteContainerInvalidLocationInternal_Using_PocoClientAbstraction()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            await ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>()
                                   .Create(credentials, GetAbstractionContext(), false)
                                   .DeleteContainer(TestCredentials.WellKnownCluster.DnsName, "Nowhere");
        }
        
        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("NegativeTest")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICanNotPerformA_DeleteContainer_WithAnInvalidCertificate_PocoClientAbstraction()
        {
            var creds = GetInvalidCertificateCredentials();
            var clusterName = TestCredentials.WellKnownCluster.DnsName;
            try
            {
                using (var client = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(creds, GetAbstractionContext(), false))
                {
                    await client.DeleteContainer(clusterName);
                }
                Assert.Fail("This call was expected to receive a failure, but did not.");
            }
            catch (HttpLayerException ex)
            {
                Assert.IsTrue(ex.RequestStatusCode == HttpStatusCode.Forbidden);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("NegativeTest")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICanNotPerformA_GetContainer_WithAnInvalidCertificate_PocoClientAbstraction()
        {
            var creds = GetInvalidCertificateCredentials();
            var clusterName = TestCredentials.WellKnownCluster.DnsName;
            try
            {
                using (var client = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(creds, GetAbstractionContext(), false))
                {
                    await client.ListContainer(clusterName);
                }
                Assert.Fail("This call was expected to receive a failure, but did not.");
            }
            catch (HttpLayerException ex)
            {
                Assert.IsTrue(ex.RequestStatusCode == HttpStatusCode.Forbidden);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("NegativeTest")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5*60*1000)] // ms
        public async Task ICanNotPerformA_CreateCreateContainer_WithAnInvalidCertificate_PocoClientAbstraction()
        {
            var creds = GetInvalidCertificateCredentials();
            var cluster = GetRandomCluster();
            try
            {
                using (
                    var client = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>()
                        .Create(creds, GetAbstractionContext(), false))
                {
                    await client.CreateContainer(cluster);
                }
                Assert.Fail("This call was expected to receive a failure, but did not.");
            }
            catch (HttpLayerException ex)
            {
                Assert.IsTrue(ex.RequestStatusCode == HttpStatusCode.Forbidden);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("NegativeTest")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICanNotPerformA_DeleteContainer_WithAnInvalidSubscriptionId_PocoClientAbstraction()
        {
            var creds = GetInvalidSubscriptionIdCredentials();
            var clusterName = TestCredentials.WellKnownCluster.DnsName;
            try
            {
                using (var client = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(creds, GetAbstractionContext(), false))
                {
                    await client.DeleteContainer(clusterName);
                }
                Assert.Fail("This call was expected to receive a failure, but did not.");
            }
            catch (HttpLayerException ex)
            {
                Assert.IsTrue(ex.RequestStatusCode == HttpStatusCode.Forbidden);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("NegativeTest")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICanNotPerformA_GetContainer_WithAnInvalidSubscriptionId_PocoClientAbstraction()
        {
            var creds = GetInvalidSubscriptionIdCredentials();
            var clusterName = TestCredentials.WellKnownCluster.DnsName;
            try
            {
                using (var client = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(creds, GetAbstractionContext(), false))
                {
                    await client.ListContainer(clusterName);
                }
                Assert.Fail("This call was expected to receive a failure, but did not.");
            }
            catch (HttpLayerException ex)
            {
                Assert.IsTrue(ex.RequestStatusCode == HttpStatusCode.Forbidden);
            }
        }
        
        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("NegativeTest")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICanNotPerformA_CreateCreateContainer_WithAnInvalidSubscriptionId_PocoClientAbstraction()
        {
            var creds = GetInvalidSubscriptionIdCredentials();
            var cluster = GetRandomCluster();
            try
            {
                using (var client = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(creds, GetAbstractionContext(), false))
                {
                    await client.CreateContainer(cluster);
                }
                Assert.Fail("This call was expected to receive a failure, but did not.");
            }
            catch (HttpLayerException ex)
            {
                Assert.IsTrue(ex.RequestStatusCode == HttpStatusCode.Forbidden);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICanPerformA_BasicCreateDeleteContainers_Using_PocoClientAbstraction()
        {
            var cluster = GetRandomCluster();
            await ValidateCreateClusterSucceeds(cluster);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [TestCategory("RestAsvClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICanPerformA_BasicCreateDeleteContainersOnUnregisteredLocation_Using_PocoClient()
        {
            // ADD SUBSCRIPTION VALIDATOR
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();

            // Unregisters subscription (just in case)
            var location = "North Europe";
            var registrationClient = ServiceLocator.Instance.Locate<ISubscriptionRegistrationClientFactory>().Create(credentials, GetAbstractionContext(), false);
            if (await registrationClient.ValidateSubscriptionLocation(location))
            {
                await registrationClient.UnregisterSubscriptionLocation(location);
            }

            var storageAccountsInLocation = from creationDetails in IntegrationTestBase.TestCredentials.Environments
                                            where creationDetails.Location == location
                                            select creationDetails;
            var storageAccount = storageAccountsInLocation.FirstOrDefault();
            Assert.IsNotNull(storageAccount, "could not find any storage accounts in location {0}", location);

            var cluster = GetRandomCluster();
            cluster.Location = location;
            cluster.DefaultStorageAccountName = storageAccount.DefaultStorageAccount.Name;
            cluster.DefaultStorageAccountKey = storageAccount.DefaultStorageAccount.Key;
            cluster.DefaultStorageContainer = storageAccount.DefaultStorageAccount.Container;
            await ValidateCreateClusterSucceeds(cluster);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICanPerformA_AdvancedCreateDeleteContainers_Using_PocoClient()
        {
            var cluster = GetRandomCluster();
            cluster.AdditionalStorageAccounts.Add(new WabStorageAccountConfiguration(TestCredentials.Environments[0].AdditionalStorageAccounts[0].Name,
                                                                TestCredentials.Environments[0].AdditionalStorageAccounts[0].Key));
            cluster.OozieMetastore = new Metastore(TestCredentials.Environments[0].OozieStores[0].SqlServer,
                                                            TestCredentials.Environments[0].OozieStores[0].Database,
                                                            TestCredentials.AzureUserName,
                                                            TestCredentials.AzurePassword);
            cluster.HiveMetastore = new Metastore(TestCredentials.Environments[0].HiveStores[0].SqlServer,
                                                           TestCredentials.Environments[0].HiveStores[0].Database,
                                                           TestCredentials.AzureUserName,
                                                           TestCredentials.AzurePassword);
            cluster.Location = cluster.Location.ToUpperInvariant();

            await ValidateCreateClusterSucceeds(cluster);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICannotCreateACluster_WithNonOverridableConfigurationOptions()
        {
            var cluster = GetRandomCluster();
            cluster.CoreConfiguration.Add(new KeyValuePair<string, string>("fs.default.name", Constants.WabsProtocolSchemeName + "nonexistantaccount"));
            cluster.Location = cluster.Location.ToUpperInvariant();

            await this.ValidateCreateClusterFailsWithError(cluster);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICanCreateACluster_WithCoreConfigurationOptions()
        {
            var cluster = GetRandomCluster();
            cluster.CoreConfiguration.Add(new KeyValuePair<string, string>("hadoop.filelogs.size", ""));
            cluster.Location = cluster.Location.ToUpperInvariant();
            Action<ClusterDetails> validateConfigOptions = (testCluster) =>
            {
                ValidateClusterConfiguration(testCluster, cluster);
            };

            await ValidateCreateClusterSucceeds(cluster, validateConfigOptions);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICanCreateACluster_WithHdfsConfigurationOptions()
        {
            var cluster = GetRandomCluster();
            cluster.HdfsConfiguration.Add(new KeyValuePair<string, string>("hadoop.filelogs.size", ""));
            cluster.Location = cluster.Location.ToUpperInvariant();
            Action<ClusterDetails> validateConfigOptions = (testCluster) =>
            {
                ValidateClusterConfiguration(testCluster, cluster);
            };

            await ValidateCreateClusterSucceeds(cluster, validateConfigOptions);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICanCreateACluster_WithMapReduceConfigurationOptions()
        {
            var cluster = GetRandomCluster();
            cluster.MapReduceConfiguration.ConfigurationCollection.Add(new KeyValuePair<string, string>("hadoop.filelogs.size", ""));
            cluster.Location = cluster.Location.ToUpperInvariant();
            Action<ClusterDetails> validateConfigOptions = (testCluster) =>
            {
                ValidateClusterConfiguration(testCluster, cluster);
            };

            await ValidateCreateClusterSucceeds(cluster, validateConfigOptions);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICanCreateACluster_WithHiveConfigurationOptions()
        {
            var cluster = GetRandomCluster();
            cluster.HiveConfiguration.ConfigurationCollection.Add(new KeyValuePair<string, string>("hadoop.filelogs.size", ""));
            cluster.Location = cluster.Location.ToUpperInvariant();
            Action<ClusterDetails> validateConfigOptions = (testCluster) =>
            {
                ValidateClusterConfiguration(testCluster, cluster);
            };

            await ValidateCreateClusterSucceeds(cluster, validateConfigOptions);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICanCreateACluster_WithOozieConfigurationOptions()
        {
            var cluster = GetRandomCluster();
            cluster.OozieConfiguration.ConfigurationCollection.Add(new KeyValuePair<string, string>("hadoop.filelogs.size", ""));
            cluster.Location = cluster.Location.ToUpperInvariant();
            Action<ClusterDetails> validateConfigOptions = (testCluster) =>
            {
                ValidateClusterConfiguration(testCluster, cluster);
            };

            await ValidateCreateClusterSucceeds(cluster, validateConfigOptions);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICanCreateACluster_WithHBaseConfigurationOptions()
        {
            var cluster = GetRandomCluster();
            cluster.HBaseConfiguration.ConfigurationCollection.Add(new KeyValuePair<string, string>("zookeeper.session.timeout", "120"));
            cluster.Location = cluster.Location.ToUpperInvariant();
            Action<ClusterDetails> validateConfigOptions = (testCluster) =>
            {
                ValidateClusterConfiguration(testCluster, cluster);
            };

            await ValidateCreateClusterSucceeds(cluster, validateConfigOptions);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICanCreateACluster_WithStormConfigurationOptions()
        {
            var cluster = GetRandomCluster();
            cluster.StormConfiguration.Add(new KeyValuePair<string, string>("storm.messaging.netty.max_retries", "11"));
            cluster.Location = cluster.Location.ToUpperInvariant();
            Action<ClusterDetails> validateConfigOptions = (testCluster) =>
            {
                ValidateClusterConfiguration(testCluster, cluster);
            };

            await ValidateCreateClusterSucceeds(cluster, validateConfigOptions);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [Timeout(5 * 60 * 1000)] // ms
        public async Task ICanCreateACluster_WithSparkConfigurationOptions()
        {
            var cluster = GetRandomCluster();
            cluster.SparkConfiguration.Add(new KeyValuePair<string, string>("spark.shuffle.memoryFraction", "0.3"));
            cluster.Location = cluster.Location.ToUpperInvariant();
            Action<ClusterDetails> validateConfigOptions = (testCluster) =>
            {
                ValidateClusterConfiguration(testCluster, cluster);
            };

            await ValidateCreateClusterSucceeds(cluster, validateConfigOptions);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [TestCategory("Defect")]
        public void ICanResolveProductionStorageAccountsWithName()
        {
            var resolvedAcccountName = AsvValidationHelper.GetFullyQualifiedStorageAccountName("storageaccountaname");
            Assert.AreEqual("storageaccountaname.blob.core.windows.net", resolvedAcccountName);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [TestCategory("Defect")]
        public void ICanResolveStagingStorageAccountsWithFQDN()
        {
            var internalAccountName = "storageaccountaname.blob.core.windows-cint.net";
            var resolvedAcccountName = AsvValidationHelper.GetFullyQualifiedStorageAccountName(internalAccountName);
            Assert.AreEqual(internalAccountName, resolvedAcccountName);
        }


        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [TestCategory("Defect")]
        public void ICanStopPollingWhenErrorIsDetected()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            using (var client = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(credentials, GetAbstractionContext(), false))
            {
                var test = new ClusterDetails("TestCluster", ClusterState.Unknown.ToString());
                test.Error = new ClusterErrorStatus(400, "Hit an error", "Create");
                var result = client.PollSignal(test, ClusterState.Operational, ClusterState.Running);
                Assert.AreEqual(result, IHDInsightManagementPocoClientExtensions.PollResult.Stop);
                test.State = ClusterState.ClusterStorageProvisioned;
                result = client.PollSignal(test, ClusterState.Operational, ClusterState.Running);
                Assert.AreEqual(result, IHDInsightManagementPocoClientExtensions.PollResult.Stop);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [TestCategory("Defect")]
        public void ICanPossibleErrorPollingWhenClusterStateIsUnknown()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            using (var client = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(credentials, GetAbstractionContext(), false))
            {
                var result = client.PollSignal(null, ClusterState.Operational, ClusterState.Running);
                Assert.AreEqual(result, IHDInsightManagementPocoClientExtensions.PollResult.Null);

                var test = new ClusterDetails("TestCluster", ClusterState.Unknown.ToString());
                result = client.PollSignal(test, ClusterState.Operational, ClusterState.Running);
                Assert.AreEqual(result, IHDInsightManagementPocoClientExtensions.PollResult.Unknown);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        [TestCategory("Defect")]
        public void ICanContinuePollingWhenClusterStateIsValid()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            using (var client = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(credentials, GetAbstractionContext(), false))
            {
                var test = new ClusterDetails("TestCluster", ClusterState.ReadyForDeployment.ToString());
                var result = client.PollSignal(test, ClusterState.Operational, ClusterState.Running);
                Assert.AreEqual(result, IHDInsightManagementPocoClientExtensions.PollResult.Continue);
            }
        }

        internal static void ValidateClusterConfiguration(ClusterDetails testCluster, ClusterCreateParametersV2 cluster)
        {
            var remoteCreds = new BasicAuthCredential()
            {
                Server = GatewayUriResolver.GetGatewayUri(new Uri(testCluster.ConnectionUrl).Host),
                UserName = testCluster.HttpUserName,
                Password = testCluster.HttpPassword
            };

            var configurationAccessor =
                ServiceLocator.Instance.Locate<IAzureHDInsightClusterConfigurationAccessorFactory>().Create(remoteCreds);

            var coreConfiguration = configurationAccessor.GetCoreServiceConfiguration().WaitForResult();
            ValidateConfiguration(cluster.CoreConfiguration, coreConfiguration);

            var hdfsConfiguration = configurationAccessor.GetHdfsServiceConfiguration().WaitForResult();
            ValidateConfiguration(cluster.HdfsConfiguration, hdfsConfiguration);

            var mapReduceConfiguration = configurationAccessor.GetMapReduceServiceConfiguration().WaitForResult();
            ValidateConfiguration(cluster.MapReduceConfiguration.ConfigurationCollection, mapReduceConfiguration);

            var hiveConfiguration = configurationAccessor.GetHiveServiceConfiguration().WaitForResult();
            ValidateConfiguration(cluster.HiveConfiguration.ConfigurationCollection, hiveConfiguration);

            var oozieConfiguration = configurationAccessor.GetOozieServiceConfiguration().WaitForResult();
            ValidateConfiguration(cluster.OozieConfiguration.ConfigurationCollection, oozieConfiguration);
        }

        private static void ValidateConfiguration(IEnumerable<KeyValuePair<string, string>> expected, Configuration.ConfigurationPropertyCollection actual)
        {
            foreach (var coreConfig in expected)
            {
                var configUnderTest = actual.FirstOrDefault(c => c.Key == coreConfig.Key);
                Assert.IsNotNull(configUnderTest, "Unable to find config option with name '{0}'", coreConfig.Key);
                Assert.AreEqual(coreConfig.Value, configUnderTest.Value, "value doesn't match for config option with name '{0}'", coreConfig.Key);
            }
        }

        private async Task ValidateCreateClusterSucceeds(ClusterCreateParametersV2 cluster)
        {
            await ValidateCreateClusterSucceeds(cluster, null);
        }

        private async Task ValidateCreateClusterSucceeds(ClusterCreateParametersV2 cluster, Action<ClusterDetails> postCreateValidation)
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            using (var client = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(credentials, GetAbstractionContext(), false))
            {
                client.CreateContainer(cluster).Wait();
                await client.WaitForClusterInConditionOrError(null, cluster.Name, cluster.Location, TimeSpan.FromMinutes(30), HDInsightClient.DefaultPollingInterval, GetAbstractionContext(), this.CreatingStates);

                var task = client.ListContainer(cluster.Name);
                task.WaitForResult();
                var container = task.Result;
                Assert.IsNotNull(container);
                if (container.Error.IsNotNull())
                {
                    Assert.Fail("The Container was not expected to return an error but returned ({0}) ({1})", container.Error.HttpCode, container.Error.Message);
                }

                if (postCreateValidation != null)
                {
                    postCreateValidation(container);
                }

                await client.DeleteContainer(cluster.Name);
                await client.WaitForClusterNullOrError(cluster.Name, cluster.Location, TimeSpan.FromMinutes(10), IntegrationTestBase.GetAbstractionContext().CancellationToken);

                Assert.IsNull(container.Error);
                Assert.IsNull(client.ListContainer(cluster.Name).WaitForResult());
            }
        }

        private readonly ClusterState[] CreatingStates = new ClusterState
            []
        {
            ClusterState.AzureVMConfiguration,
            ClusterState.ClusterStorageProvisioned,
            ClusterState.HDInsightConfiguration,
            ClusterState.Operational,
            ClusterState.Running,
        };

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        public async Task NegativeTest_InvalidAsvConfig_Using_PocoClientAbstraction()
        {
            var cluster = GetRandomCluster();
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            cluster.DefaultStorageAccountKey = "invalid";

            try
            {
                await ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(credentials, GetAbstractionContext(), false).CreateContainer(cluster);
            }
            catch (ConfigurationErrorsException e)
            {
                // NEIN: This needs to validate at least one parameter of the exception.
                Console.WriteLine("THIS TEST SUCCEDED because the expected negative result was found");
                Console.WriteLine("ASV Validation failed. Details: {0}", e.ToString());
                return;
            }
            catch (Exception e)
            {
                Assert.Fail("Expected exception 'ConfigurationErrorsException'; found '{0}'. Message:{1}", e.GetType(), e.Message);
            }

            Assert.Fail("ASV Validation should have failed.");
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        public async Task NegativeTest_InvalidLocation_Using_PocoClient()
        {
            var cluster = GetRandomCluster();
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            cluster.Location = "nowhere";

            try
            {
                await ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(credentials, GetAbstractionContext(), false).CreateContainer(cluster);
                Assert.Fail("Location Validation should have failed.");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("THIS TEST SUCCEDED because the expected negative result was found");
            }
            catch (Exception e)
            {
                Assert.Fail("Expected exception 'InvalidOperationException'; found '{0}'. Message:{1}", e.GetType(), e.Message);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        public async Task NegativeTest_RepeatedAsvConfig_Using_PocoClientAbstraction()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var cluster = GetRandomCluster();
            cluster.AdditionalStorageAccounts.Add(new WabStorageAccountConfiguration(cluster.DefaultStorageAccountName, cluster.DefaultStorageAccountKey));

            try
            {
                await ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(credentials, GetAbstractionContext(), false).CreateContainer(cluster);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("THIS TEST SUCCEDED because the expected negative result was found");
                Console.WriteLine("ASV Validation failed. Details: {0}", e.ToString());
                return;
            }
            catch (Exception e)
            {
                Assert.Fail("Expected exception 'InvalidOperationException'; found '{0}'. Message:{1}", e.GetType(), e.Message);
            }

            Assert.Fail("ASV Validation should have failed.");
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        public async Task NegativeTest_ExistingCluster_Using_PocoClient()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var cluster = GetRandomCluster();
            cluster.Name = TestCredentials.WellKnownCluster.DnsName;
            try
            {
                await ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(credentials, GetAbstractionContext(), false).CreateContainer(cluster);
            }
            catch (HttpLayerException e)
            {
                Assert.IsTrue(e.RequestContent.Contains(HDInsightClient.ClusterAlreadyExistsError));
                Assert.AreEqual(e.RequestStatusCode, HttpStatusCode.BadRequest);
            }
        }

        private async Task ValidateCreateClusterFailsWithError(ClusterCreateParametersV2 cluster)
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(credentials, GetAbstractionContext(), false);
            await client.CreateContainer(cluster);
            await client.WaitForClusterNotNull(cluster.Name, cluster.Location, TimeSpan.FromMinutes(10), GetAbstractionContext().CancellationToken);

            var result = await client.ListContainer(cluster.Name);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Error);

            await client.DeleteContainer(cluster.Name);
            await client.WaitForClusterNull(cluster.Name, cluster.Location, TimeSpan.FromMinutes(10), GetAbstractionContext().CancellationToken);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        public async Task NegativeTest_InvalidMetastore_Using_PocoClient()
        {
            var cluster = GetRandomCluster();
            cluster.OozieMetastore = new Metastore(TestCredentials.Environments[0].OozieStores[0].SqlServer,
                                                            TestCredentials.Environments[0].OozieStores[0].Database,
                                                            TestCredentials.AzureUserName,
                                                            TestCredentials.AzurePassword);
            cluster.HiveMetastore = new Metastore(TestCredentials.Environments[0].HiveStores[0].SqlServer,
                                                            TestCredentials.Environments[0].HiveStores[0].Database,
                                                            TestCredentials.AzureUserName,
                                                            "NOT-THE-REAL-PASSWORD");

            await ValidateCreateClusterFailsWithError(cluster);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("PocoClient")]
        public async Task PositiveTest_OnlyOneMetastore_Using_PocoClient()
        {
            var cluster = GetRandomCluster();
            cluster.OozieMetastore = new Metastore(TestCredentials.Environments[0].OozieStores[0].SqlServer,
                                                            TestCredentials.Environments[0].OozieStores[0].Database,
                                                            TestCredentials.AzureUserName,
                                                            TestCredentials.AzurePassword);

            await this.ValidateCreateClusterSucceeds(cluster);
        }
        
        private string FormatHeaders(IHttpResponseHeadersAbstraction httpResponseHeadersAbstraction)
        {
            StringBuilder sbLog = new StringBuilder();
            foreach (var header in httpResponseHeadersAbstraction)
            {
                if (header.Value is IEnumerable<string>)
                {
                    sbLog.Append(header.Key + "  ");
                    sbLog.Append(string.Join(",", header.Value as IEnumerable<string>));
                }
                else
                {
                    sbLog.Append(header.Key + " " + header.Value);
                }
                sbLog.Append(Environment.NewLine);
            }

            return sbLog.ToString();
        }
    }
}