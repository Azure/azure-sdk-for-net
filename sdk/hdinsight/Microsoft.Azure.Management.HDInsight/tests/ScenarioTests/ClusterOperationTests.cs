// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;
using static Management.HDInsight.Tests.HDInsightManagementTestUtilities;
using Permissions = Microsoft.Azure.Management.KeyVault.Models.Permissions;
using StorageAccount = Microsoft.Azure.Management.HDInsight.Models.StorageAccount;

namespace Management.HDInsight.Tests
{
    public class ClusterOperationTests : HDInsightManagementTestBase
    {
        [Fact]
        public void TestCreateHumboldtCluster()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-humboldt");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);
        }

        [Fact]
        public void TestCreateHumboldtClusterWithPremiumTier()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-premium");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            createParams.Properties.Tier = Tier.Premium;
            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);
        }

        [Fact]
        public void TestCreateWithEmptyExtendedParameters()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-cluster");
            var ex = Assert.Throws<ErrorResponseException>(() => HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, new ClusterCreateParametersExtended()));
            Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);
        }

        [Fact]
        public void TestCreateHumboldtClusterWithCustomVMSizes()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-customvmsizes");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            var headNode = createParams.Properties.ComputeProfile.Roles.First(role => role.Name == "headnode");
            headNode.HardwareProfile.VmSize = "ExtraLarge";
            var zookeeperNode = createParams.Properties.ComputeProfile.Roles.First(role => role.Name == "zookeepernode");
            zookeeperNode.HardwareProfile.VmSize = "Medium";
            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);
        }

        [Fact]
        public void TestCreateLinuxSparkClusterWithComponentVersion()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-sparkcomponentversions");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            createParams.Properties.ClusterDefinition.Kind = "Spark";
            createParams.Properties.ClusterDefinition.ComponentVersion = new Dictionary<string, string>()
            {
                { "Spark", "2.2" }
            };

            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);
        }

        [Fact]
        public void TestCreateKafkaClusterWithManagedDisks()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-kafka");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            createParams.Properties.ClusterDefinition.Kind = "Kafka";
            var workerNode = createParams.Properties.ComputeProfile.Roles.First(role => role.Name == "workernode");
            workerNode.DataDisksGroups = new List<DataDisksGroups>
            {
                new DataDisksGroups
                {
                     DisksPerNode = 8
                }
            };

            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);
        }

        [Fact]
        public void TestCreateKafkaClusterWithDiskEncryption()
        {
            TestInitialize();

            string mockedTenantId = TestUtilities.GenerateGuid().ToString();
            CommonData.TenantId = GetTenantId();
            this.Context.AddTextReplacementRule(CommonData.TenantId, mockedTenantId);

            string mockedClientObjectId = TestUtilities.GenerateGuid().ToString();
            CommonData.ClientObjectId = GetServicePrincipalObjectId();
            this.Context.AddTextReplacementRule(CommonData.ClientObjectId, mockedClientObjectId);

            Vault vault = null;
            try
            {
                // create key vault with soft delete enabled
                vault = CreateVault(CommonData.VaultName, true);

                // create managed identities for Azure resources.
                var msi = CreateMsi(CommonData.ManagedIdentityName);

                // add managed identity to vault
                var requiredPermissions = new Permissions
                {
                    Keys = new List<string>() { KeyPermissions.Get, KeyPermissions.WrapKey, KeyPermissions.UnwrapKey },
                    Secrets = new List<string>() { SecretPermissions.Get, SecretPermissions.Set, SecretPermissions.Delete }
                };

                vault = SetVaultPermissions(vault, msi.PrincipalId.ToString(), requiredPermissions);
                Assert.NotNull(vault);

                // create key
                string keyName = TestUtilities.GenerateName("hdicsharpkey1");
                var keyIdentifier = GenerateVaultKey(vault, keyName);

                // create HDInsight cluster with Kafka disk encryption
                string clusterName = TestUtilities.GenerateName("hdisdk-kafka-byok");
                var createParams = CommonData.PrepareClusterCreateParamsForWasb();
                createParams.Properties.ClusterDefinition.Kind = "Kafka";
                var workerNode = createParams.Properties.ComputeProfile.Roles.First(role => role.Name == "workernode");
                workerNode.DataDisksGroups = new List<DataDisksGroups>
                {
                    new DataDisksGroups
                    {
                         DisksPerNode = 8
                    }
                };

                createParams.Identity = new ClusterIdentity
                {
                    Type = ResourceIdentityType.UserAssigned,
                    UserAssignedIdentities = new Dictionary<string, ClusterIdentityUserAssignedIdentitiesValue>
                    {
                        { msi.Id, new ClusterIdentityUserAssignedIdentitiesValue() }
                    }
                };

                createParams.Properties.DiskEncryptionProperties = new DiskEncryptionProperties
                {
                    VaultUri = keyIdentifier.Vault,
                    KeyName = keyIdentifier.Name,
                    KeyVersion = keyIdentifier.Version,
                    MsiResourceId = msi.Id
                };

                var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
                ValidateCluster(clusterName, createParams, cluster);

                // check disk encryption properties
                var diskEncryptionProperties = cluster.Properties.DiskEncryptionProperties;
                var diskEncryptionPropertiesParams = createParams.Properties.DiskEncryptionProperties;
                Assert.NotNull(diskEncryptionProperties);
                Assert.Equal(diskEncryptionPropertiesParams.VaultUri, diskEncryptionProperties.VaultUri);
                Assert.Equal(diskEncryptionPropertiesParams.KeyName, diskEncryptionProperties.KeyName);
                Assert.Equal(diskEncryptionPropertiesParams.KeyVersion, diskEncryptionProperties.KeyVersion);
                Assert.Equal(msi.Id, diskEncryptionProperties.MsiResourceId, true);

                keyName = TestUtilities.GenerateName("hdicsharpkey2");
                var secondKeyIdentifier = GenerateVaultKey(vault, keyName);

                // rotate cluster key
                var rotateParams = new ClusterDiskEncryptionParameters
                {
                    VaultUri = secondKeyIdentifier.Vault,
                    KeyName = secondKeyIdentifier.Name,
                    KeyVersion = secondKeyIdentifier.Version
                };

                HDInsightClient.Clusters.RotateDiskEncryptionKey(CommonData.ResourceGroupName, clusterName, rotateParams);
                cluster = HDInsightClient.Clusters.Get(CommonData.ResourceGroupName, clusterName);

                // check disk encryption properties
                diskEncryptionProperties = cluster.Properties.DiskEncryptionProperties;
                Assert.NotNull(diskEncryptionProperties);
                Assert.Equal(rotateParams.VaultUri, diskEncryptionProperties.VaultUri);
                Assert.Equal(rotateParams.KeyName, diskEncryptionProperties.KeyName);
                Assert.Equal(rotateParams.KeyVersion, diskEncryptionProperties.KeyVersion);
                Assert.Equal(msi.Id, diskEncryptionProperties.MsiResourceId, true);
            }
            finally
            {
                if (vault != null)
                {
                    DeleteVault(vault);
                }
            }
        }

        [Fact]
        public void TestCreateKafkaClusterWithRestProxyProperties()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-kafka-restproxy");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            createParams.Properties.ClusterVersion = "4.0";
            createParams.Properties.ClusterDefinition.Kind = "kafka";
            createParams.Properties.ClusterDefinition.ComponentVersion = new Dictionary<string, string>{ { "Kafka", "2.1"} };
            createParams.Location = "South Central US";

            var workerNode = createParams.Properties.ComputeProfile.Roles.First(role => role.Name == "workernode");
            workerNode.DataDisksGroups = new List<DataDisksGroups>
            {
                new DataDisksGroups
                {
                     DisksPerNode = 8
                }
            };

            //KafkaManagementNode must be defined for Kafka Rest Proxy to be provisioned
            createParams.Properties.ComputeProfile.Roles.Add(new Role
            {
                Name = "kafkamanagementnode",
                TargetInstanceCount = 2,
                HardwareProfile = new HardwareProfile
                {
                    VmSize = "Standard_D4_v2"
                },
                OsProfile = new OsProfile
                {
                    LinuxOperatingSystemProfile = new LinuxOperatingSystemProfile
                    {
                        Username = CommonData.SshUsername,
                        Password = CommonData.SshPassword
                    }
                }
            });
            //only kafaka cluster with hdi 4.0 and above with kafaka version 2.1 and above can be deployed with rest proxy.
            createParams.Properties.KafkaRestProperties = new KafkaRestProperties
            {
                ClientGroupInfo = new ClientGroupInfo
                {
                    GroupId = "7bef90fa-0aa3-4bb4-b4d2-2ae7c14cfe41",
                    GroupName = "KafakaRestProperties"
                }
            };

            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);
            Assert.NotNull(cluster.Properties.KafkaRestProperties);
        }

        [Fact]
        public void TestCreateWithADLSv1() {

            TestInitialize();

            // This test case require ADLS gen1 storage account created beforehand
            if (IsPartialRecordMode())
            {
                return;
            }

            string mockedTenantId = TestUtilities.GenerateGuid().ToString();
            CommonData.TenantId = GetTenantId();
            this.Context.AddTextReplacementRule(CommonData.TenantId, mockedTenantId);

            string mockedDataLakeClientId = TestUtilities.GenerateGuid().ToString();
            CommonData.DataLakeClientId = TestConfigurationManager.Instance.AppSettings.DataLakeClientId;
            this.Context.AddTextReplacementRule(CommonData.DataLakeClientId, mockedDataLakeClientId);

            string mockedDataLakeStoreAccountName = TestUtilities.GenerateName("fakehdiadlsaccount");
            CommonData.DataLakeStoreAccountName = TestConfigurationManager.Instance.AppSettings.DataLakeStoreAccountName;
            this.Context.AddTextReplacementRule(CommonData.DataLakeStoreAccountName, mockedDataLakeStoreAccountName);

            string clusterName = TestUtilities.GenerateName("hdisdk-adlgen1");
            var createParams = CommonData.PrepareClusterCreateParamsForADLSv1();

            // Add additional storage account
            var secondaryStorageAccountName = TestUtilities.GenerateName("hdicsharpstorage2");
            var secondaryStorageAccountKey = CreateStorageAccount(secondaryStorageAccountName);
            createParams.Properties.StorageProfile.Storageaccounts.Add(
                new StorageAccount
                {
                    Name = CommonData.StorageAccountName + CommonData.BlobEndpointSuffix,
                    Key = CommonData.StorageAccountKey,
                    Container = CommonData.ContainerName.ToLower(),
                    IsDefault = false
                }
            );

            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);
        }

        [Fact]
        public void TestCreateWithADLSv2()
        {
            TestInitialize();

            string mockedTenantId = TestUtilities.GenerateGuid().ToString();
            CommonData.TenantId = GetTenantId();
            this.Context.AddTextReplacementRule(CommonData.TenantId, mockedTenantId);

            string mockedClientObjectId = TestUtilities.GenerateGuid().ToString();
            CommonData.ClientObjectId = GetServicePrincipalObjectId();
            this.Context.AddTextReplacementRule(CommonData.ClientObjectId, mockedClientObjectId);

            // Create an Azure storage account with Data Lake Storage Gen 2.
            string adlsV2AccountName = TestUtilities.GenerateName("hdicsharpadlsv2");
            var storageV2AccountAccessKey = HDInsightManagementHelper.CreateStorageAccount(
                CommonData.ResourceGroupName,
                adlsV2AccountName,
                CommonData.Location,
                out string storageAccountSuffix,
                Kind.StorageV2,
                true);
            string storageResourceId = HDInsightManagementHelper.GetStorageAccountId(CommonData.ResourceGroupName, adlsV2AccountName);

            // Create a user assigned managed identity.
            var msi = CreateMsi(CommonData.ManagedIdentityName);

            // Wait some time in order to improve robustness
            TestUtilities.Wait(TimeSpan.FromMinutes(1));

            // Assign Storage Blob Data Contributor access to the created managed identity on Azure Storage.
            string assignmentName = TestUtilities.GenerateGuid().ToString();
            HDInsightManagementHelper.AddRoleAssignment(storageResourceId, CommonData.AdlsGen2RequiredRoleName, assignmentName, msi.PrincipalId?.ToString());

            string clusterName = TestUtilities.GenerateName("hdisdk-adlgen2");
            var createParams = CommonData.PrepareClusterCreateParamsForADLSv2(adlsV2AccountName, storageResourceId, msi.Id);

            // Add additional storage account
            createParams.Properties.StorageProfile.Storageaccounts.Add(
                new StorageAccount
                {
                    Name = CommonData.StorageAccountName + CommonData.BlobEndpointSuffix,
                    Key = CommonData.StorageAccountKey,
                    Container = CommonData.ContainerName.ToLower(),
                    IsDefault = false
                }
            );

            // Create a HDInsight cluster
            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);
        }

        [Fact]
        public void TestCreateWithAdditionalStorageAccount()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-additional");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();

            // Add additional storage account
            var secondaryStorageAccountName = TestUtilities.GenerateName("hdicsharpstorage2");
            var secondaryStorageAccountKey = CreateStorageAccount(secondaryStorageAccountName);
            createParams.Properties.StorageProfile.Storageaccounts.Add(
                new StorageAccount
                {
                    Name = secondaryStorageAccountName + CommonData.BlobEndpointSuffix,
                    Key = secondaryStorageAccountKey,
                    Container = CommonData.ContainerName.ToLower(),
                    IsDefault = false
                }
            );

            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);
        }

        [Fact]
        public void TestCreateClusterWithAutoScaleLoadBasedType()
        {
            TestInitialize();
            string clusterName = TestUtilities.GenerateName("hdisdk-loadbased");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            var workerNode = createParams.Properties.ComputeProfile.Roles.First(role => role.Name.Equals("workernode"));

            //Add auto scale configuration Load-based type
            workerNode.AutoscaleConfiguration = new Autoscale
            {
                Capacity = new AutoscaleCapacity
                {
                    MinInstanceCount = 4,
                    MaxInstanceCount = 5
                }
            };

            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateAutoScaleConfig(workerNode.AutoscaleConfiguration,
                cluster.Properties.ComputeProfile.Roles.First(role => role.Name.Equals("workernode")).AutoscaleConfiguration);
        }

        [Fact]
        public void TestCreateClusterWithAutoScaleScheduleBasedType()
        {
            TestInitialize();
            string clusterName = TestUtilities.GenerateName("hdisdk-schedulebased");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            var workerNode = createParams.Properties.ComputeProfile.Roles.First(role => role.Name.Equals("workernode"));

            //Add auto scale configuration.
            workerNode.AutoscaleConfiguration = new Autoscale
            {
                Recurrence = new AutoscaleRecurrence
                {
                    //"China Standard Time", "Central Standard Time","Central American Standard Time"
                    TimeZone = "China Standard Time",
                    Schedule = new List<AutoscaleSchedule>
                    {
                        new AutoscaleSchedule
                        {
                            Days = new List<DaysOfWeek?>
                            {
                                DaysOfWeek.Thursday
                            },
                            TimeAndCapacity = new AutoscaleTimeAndCapacity
                            {
                                Time = "16:00",
                                MinInstanceCount = 4,
                                MaxInstanceCount = 4
                            }
                        }
                    }
                }
            };

            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateAutoScaleConfig(workerNode.AutoscaleConfiguration,
                cluster.Properties.ComputeProfile.Roles.First(role => role.Name.Equals("workernode")).AutoscaleConfiguration);
        }

        [Fact]
        public void TestCreateRServerCluster()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-rserver");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            createParams.Properties.ClusterDefinition.Kind = "RServer";
            createParams.Properties.ComputeProfile.Roles.Add(
                new Role
                {
                    Name = "edgenode",
                    TargetInstanceCount = 1,
                    HardwareProfile = new HardwareProfile
                    {
                        VmSize = "Standard_D4_v2"
                    },
                    OsProfile = new OsProfile
                    {
                        LinuxOperatingSystemProfile = new LinuxOperatingSystemProfile
                        {
                            Username = CommonData.SshUsername,
                            Password = CommonData.SshPassword
                        }
                    }
                }
            );

            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);
        }

        [Fact]
        public void TestCreateMLServicesCluster()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-mlservices");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            createParams.Properties.ClusterDefinition.Kind = "MLServices";
            createParams.Properties.ClusterVersion = "3.6";
            createParams.Properties.ComputeProfile.Roles.Add(
                new Role
                {
                    Name = "edgenode",
                    TargetInstanceCount = 1,
                    HardwareProfile = new HardwareProfile
                    {
                        VmSize = "Standard_D4_v2"
                    },
                    OsProfile = new OsProfile
                    {
                        LinuxOperatingSystemProfile = new LinuxOperatingSystemProfile
                        {
                            Username = CommonData.SshUsername,
                            Password = CommonData.SshPassword
                        }
                    }
                }
            );

            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);
        }

        [Fact]
        public void TestListClustersInResourceGroup()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-cluster-rg1");
            var clusterPage = HDInsightClient.Clusters.ListByResourceGroup(CommonData.ResourceGroupName);
            var clusterList = new List<Cluster>(clusterPage);
            while (!string.IsNullOrEmpty(clusterPage.NextPageLink))
            {
                clusterPage = HDInsightClient.Clusters.ListByResourceGroupNext(clusterPage.NextPageLink);
            }

            Assert.DoesNotContain(clusterList, c => c.Name.Equals(clusterName, StringComparison.OrdinalIgnoreCase));

            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);

            clusterPage = HDInsightClient.Clusters.ListByResourceGroup(CommonData.ResourceGroupName);
            clusterList = new List<Cluster>(clusterPage);
            while (!string.IsNullOrEmpty(clusterPage.NextPageLink))
            {
                clusterPage = HDInsightClient.Clusters.ListByResourceGroupNext(clusterPage.NextPageLink);
            }

            Assert.Contains(clusterList, c => c.Name.Equals(clusterName, StringComparison.OrdinalIgnoreCase));
        }

        [Fact(Skip = "Test case will list all clusters under a subscription.")]
        public void TestListClustersInSubscription()
        {
            string clusterName = TestUtilities.GenerateName("hdisdk-cluster-rg1");
            var clusterPage = HDInsightClient.Clusters.List();
            var clusterList = new List<Cluster>(clusterPage);
            while (!string.IsNullOrEmpty(clusterPage.NextPageLink))
            {
                clusterPage = HDInsightClient.Clusters.ListNext(clusterPage.NextPageLink);
            }

            Assert.DoesNotContain(clusterList, c => c.Name.Equals(clusterName, StringComparison.OrdinalIgnoreCase));

            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);

            clusterPage = HDInsightClient.Clusters.List();
            clusterList = new List<Cluster>(clusterPage);
            while (!string.IsNullOrEmpty(clusterPage.NextPageLink))
            {
                clusterPage = HDInsightClient.Clusters.ListNext(clusterPage.NextPageLink);
            }

            Assert.Contains(clusterList, c => c.Name.Equals(clusterName, StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        public void TestResizeCluster()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-clusterresize");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            var workerNodeParams = createParams.Properties.ComputeProfile.Roles.First(role => role.Name == "workernode");
            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);

            cluster = HDInsightClient.Clusters.Get(CommonData.ResourceGroupName, clusterName);
            var workerNode = cluster.Properties.ComputeProfile.Roles.First(role => role.Name == "workernode");
            Assert.Equal(workerNodeParams.TargetInstanceCount, workerNode.TargetInstanceCount);

            HDInsightClient.Clusters.Resize(CommonData.ResourceGroupName, clusterName, workerNodeParams.TargetInstanceCount.Value + 1);
            cluster = HDInsightClient.Clusters.Get(CommonData.ResourceGroupName, clusterName);
            workerNode = cluster.Properties.ComputeProfile.Roles.First(role => role.Name == "workernode");
            Assert.Equal(workerNodeParams.TargetInstanceCount.Value + 1, workerNode.TargetInstanceCount);
        }

        [Fact]
        public void TestGetOrUpdateGatewaySettings()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-gateway");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);

            string expectedUserName = CommonData.ClusterUserName;
            string expectedPassword = CommonData.ClusterPassword;
            var gatewaySettings = HDInsightClient.Clusters.GetGatewaySettings(CommonData.ResourceGroupName, clusterName);
            ValidateGatewaySettings(expectedUserName, expectedPassword, gatewaySettings);

            // Disable gateway settings is not allowed.
            var updateParams = new UpdateGatewaySettingsParameters
            {
                IsCredentialEnabled = false
            };

            try
            {
                HDInsightClient.Clusters.UpdateGatewaySettings(CommonData.ResourceGroupName, clusterName, updateParams);
                Assert.True(false, "Disable gateway settings should fail");
            }
            catch(ErrorResponseException ex)
            {
                Assert.Equal(HttpStatusCode.MethodNotAllowed, ex.Response.StatusCode);
            }

            // Make sure anything stay unchanged after attempting to disable gateway settings.
            gatewaySettings = HDInsightClient.Clusters.GetGatewaySettings(CommonData.ResourceGroupName, clusterName);
            ValidateGatewaySettings(expectedUserName, expectedPassword, gatewaySettings);

            string newExpectedPassword = "NewPassword1!";
            updateParams = new UpdateGatewaySettingsParameters
            {
                IsCredentialEnabled = true,
                UserName = expectedUserName,
                Password = newExpectedPassword
            };

            HDInsightClient.Clusters.UpdateGatewaySettings(CommonData.ResourceGroupName, clusterName, updateParams);
            gatewaySettings = HDInsightClient.Clusters.GetGatewaySettings(CommonData.ResourceGroupName, clusterName);
            ValidateGatewaySettings(expectedUserName, newExpectedPassword, gatewaySettings);
        }

        [Fact]
        public void TestCreateClusterWithTLS12()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-tls12");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            createParams.Properties.MinSupportedTlsVersion = "1.2";
            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            Assert.Equal("1.2", cluster.Properties.MinSupportedTlsVersion);
            ValidateCluster(clusterName, createParams, cluster);
        }

        [Fact]
        public void TestCreateClusterWithPrivateLink()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-privatelink");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            createParams.Location = "South Central US";

            var networkSetting = new NetworkSettings(PublicNetworkAccess.OutboundOnly, OutboundOnlyPublicNetworkAccessType.PublicLoadBalancer);
            createParams.Properties.NetworkSettings = networkSetting;

            //Create Virturl Network
            string virtualNetworkName= TestUtilities.GenerateName("hdisdkvnet");
            var vnet = CreateVnetForPrivateLink(createParams.Location, virtualNetworkName);

            foreach (var role in createParams.Properties.ComputeProfile.Roles)
            {
               role.VirtualNetworkProfile = new VirtualNetworkProfile(vnet.Id, vnet.Subnets.First().Id);
            }

            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);

            var result = HDInsightClient.Clusters.Get(CommonData.ResourceGroupName, clusterName);
            ValidateCluster(clusterName, createParams, result);
        }

        [Fact]
        public void TestCreateClusterWithEncryptionInTransit()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-encryption");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            createParams.Location = "South Central US";
            createParams.Properties.EncryptionInTransitProperties = new EncryptionInTransitProperties
            {
                IsEncryptionInTransitEnabled = true
            };

            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);

            var result = HDInsightClient.Clusters.Get(CommonData.ResourceGroupName, clusterName);
            ValidateCluster(clusterName, createParams, result);
        }

        [Fact]
        public void TestUpdateAutoScaleConfiguration()
        {
            TestInitialize();

            //create a cluster without autoscale config
            string clusterName = TestUtilities.GenerateName("hdisdk-updateautoscale");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            createParams.Location = "South Central US";

            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);

            var clusterWithoutAutoscale = HDInsightClient.Clusters.Get(CommonData.ResourceGroupName, clusterName);
            Assert.Null(cluster.Properties.ComputeProfile.Roles.First(role => role.Name.Equals("workernode")).AutoscaleConfiguration);

            // enable autoscale
            AutoscaleConfigurationUpdateParameter loadBasedAutoScaleConfig = new AutoscaleConfigurationUpdateParameter
            {
                Autoscale = new Autoscale
                {
                    Capacity = new AutoscaleCapacity
                    {
                        MinInstanceCount = 3,
                        MaxInstanceCount = 4
                    }
                }
            };
            HDInsightClient.Clusters.UpdateAutoScaleConfiguration(CommonData.ResourceGroupName, clusterName, loadBasedAutoScaleConfig);
            var clusterEnabledAutoScale = HDInsightClient.Clusters.Get(CommonData.ResourceGroupName, clusterName);

            ValidateAutoScaleConfig(loadBasedAutoScaleConfig.Autoscale, clusterEnabledAutoScale.Properties.ComputeProfile.Roles.First(role => role.Name.Equals("workernode")).AutoscaleConfiguration);

            // disable autoscale
            loadBasedAutoScaleConfig.Autoscale = null;
            HDInsightClient.Clusters.UpdateAutoScaleConfiguration(CommonData.ResourceGroupName, clusterName, loadBasedAutoScaleConfig);
            var clusterDisabledAutoScale = HDInsightClient.Clusters.Get(CommonData.ResourceGroupName, clusterName);

            Assert.Null(clusterDisabledAutoScale.Properties.ComputeProfile.Roles.First(role => role.Name.Equals("workernode")).AutoscaleConfiguration);
        }
    }
}
