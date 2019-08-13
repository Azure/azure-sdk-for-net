// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using HDInsightStorageAccount = Microsoft.Azure.Management.HDInsight.Models.StorageAccount;

namespace Management.HDInsight.Tests
{
    /// <summary>
    /// Test utilities 
    /// </summary>
    public static class HDInsightManagementTestUtilities
    {
        /// <summary>
        /// Validate cluster
        /// </summary>
        /// <param name="expectedClustername"></param>
        /// <param name="expectedParameters"></param>
        /// <param name="actualCluster"></param>
        public static void ValidateCluster(string expectedClustername, ClusterCreateParametersExtended expectedParameters, Cluster actualCluster)
        {
            Assert.Equal(expectedClustername, actualCluster.Name);
            Assert.Equal(expectedParameters.Properties.Tier, actualCluster.Properties.Tier);
            Assert.NotNull(actualCluster.Etag);
            Assert.EndsWith(expectedClustername, actualCluster.Id);
            Assert.Equal("Running", actualCluster.Properties.ClusterState);
            Assert.Equal("Microsoft.HDInsight/clusters", actualCluster.Type);
            Assert.Equal(expectedParameters.Location, actualCluster.Location);
            Assert.Equal(expectedParameters.Tags, actualCluster.Tags);
            Assert.Equal(1, actualCluster.Properties.ConnectivityEndpoints.Count(c => c.Name.Equals("HTTPS", StringComparison.OrdinalIgnoreCase)));
            Assert.Equal(1, actualCluster.Properties.ConnectivityEndpoints.Count(c => c.Name.Equals("SSH", StringComparison.OrdinalIgnoreCase)));
            Assert.Equal(expectedParameters.Properties.OsType, actualCluster.Properties.OsType);
            Assert.Null(actualCluster.Properties.Errors);
            Assert.Equal(HDInsightClusterProvisioningState.Succeeded, actualCluster.Properties.ProvisioningState);
            Assert.Equal(expectedParameters.Properties.ClusterDefinition.Kind, actualCluster.Properties.ClusterDefinition.Kind);
            Assert.Equal(expectedParameters.Properties.ClusterVersion, actualCluster.Properties.ClusterVersion.Substring(0, 3));
            Assert.Null(actualCluster.Properties.ClusterDefinition.Configurations);
        }

        /// <summary>
        /// Validate gateway settings
        /// </summary>
        /// <param name="expectedUserName"></param>
        /// <param name="expectedUserPassword"></param>
        /// <param name="actualGatewaySettings"></param>
        public static void ValidateGatewaySettings(string expectedUserName, string expectedUserPassword, GatewaySettings actualGatewaySettings)
        {
            Assert.NotNull(actualGatewaySettings);
            Assert.Equal("true", actualGatewaySettings.IsCredentialEnabled);
            Assert.Equal(expectedUserName, actualGatewaySettings.UserName);
            Assert.Equal(expectedUserPassword, actualGatewaySettings.Password);
        }

        /// <summary>
        /// Validate auto scale configuration
        /// </summary>
        /// <param name="expectedAutoscaleConfiguration"></param>
        /// <param name="actualAutoscaleConfiguration"></param>
        public static void ValidateAutoScaleConfig(Autoscale expectedAutoscaleConfiguration, Autoscale actualAutoscaleConfiguration)
        {
            Assert.NotNull(actualAutoscaleConfiguration);
            if (actualAutoscaleConfiguration.Capacity != null && expectedAutoscaleConfiguration.Capacity != null)
            {
                Assert.Equal(expectedAutoscaleConfiguration.Capacity.MinInstanceCount, actualAutoscaleConfiguration.Capacity.MinInstanceCount);
                Assert.Equal(expectedAutoscaleConfiguration.Capacity.MaxInstanceCount, actualAutoscaleConfiguration.Capacity.MaxInstanceCount);
            }
            else
            {
                Assert.Equal(expectedAutoscaleConfiguration.Capacity, actualAutoscaleConfiguration.Capacity);
            }

            if (actualAutoscaleConfiguration.Recurrence != null && expectedAutoscaleConfiguration.Recurrence != null)
            {
                Assert.Equal(expectedAutoscaleConfiguration.Recurrence.TimeZone, actualAutoscaleConfiguration.Recurrence.TimeZone);
                Assert.NotNull(expectedAutoscaleConfiguration.Recurrence.Schedule);
                Assert.NotNull(actualAutoscaleConfiguration.Recurrence.Schedule);

                Assert.Equal(expectedAutoscaleConfiguration.Recurrence.Schedule.Count, actualAutoscaleConfiguration.Recurrence.Schedule.Count);
                Assert.NotEmpty(expectedAutoscaleConfiguration.Recurrence.Schedule);

                for (int i = 0; i < expectedAutoscaleConfiguration.Recurrence.Schedule.Count; i++)
                {
                    var expectedSchedule = expectedAutoscaleConfiguration.Recurrence.Schedule[i];
                    var actualSchedule = actualAutoscaleConfiguration.Recurrence.Schedule[i];
                    Assert.Equal(expectedSchedule.Days, actualSchedule.Days);
                    Assert.NotNull(expectedSchedule.TimeAndCapacity);
                    Assert.NotNull(actualSchedule.TimeAndCapacity);
                    Assert.Equal(expectedSchedule.TimeAndCapacity.Time, actualSchedule.TimeAndCapacity.Time);
                    Assert.Equal(expectedSchedule.TimeAndCapacity.MinInstanceCount, actualSchedule.TimeAndCapacity.MinInstanceCount);
                    /*
                     * Note: You may find that we don't compare expectedSchedule.TimeAndCapacity.MaxInstanceCount with actualSchedule.TimeAndCapacity.MaxInstanceCount here.
                     * This is not an error. We do this intentionally.
                     * The reason is that now RP will not make use of the parameter "expectedSchedule.TimeAndCapacity.MaxInstanceCount" when create cluster.
                     * And the actualSchedule.TimeAndCapacity.MaxInstanceCount is equal with expectedSchedule.TimeAndCapacity.MinInstanceCount now.
                     * We are not sure whether RP will change this design or not in the future. So We decided not to compare.
                     */
                }
            }
            else
            {
                Assert.Equal(expectedAutoscaleConfiguration.Recurrence, actualAutoscaleConfiguration.Recurrence);
            }
        }

        /// <summary>
        /// Create cluster create parameters for ADLS Gen1 relevant tests.
        /// </summary>
        /// <param name="commonData"></param>
        /// <param name="createParams">
        /// If provided, the method will update the given parameters;
        /// Otherwise, a new create parameters will be created.
        /// </param>
        /// <returns></returns>
        public static ClusterCreateParametersExtended PrepareClusterCreateParamsForADLSv1(this CommonTestFixture commonData, ClusterCreateParametersExtended createParams = null)
        {
            var createParamsForADLSv1 = createParams ?? commonData.PrepareClusterCreateParams();
            var configurations = (Dictionary<string, Dictionary<string, string>>)createParamsForADLSv1.Properties.ClusterDefinition.Configurations;
            string clusterIdentity = "clusterIdentity";
            var clusterIdentityConfig = new Dictionary<string, string>()
            {
                {  "clusterIdentity.applicationId", commonData.DataLakeClientId },
                {  "clusterIdentity.certificate", commonData.CertContent },
                {  "clusterIdentity.aadTenantId", "https://login.windows.net/" + commonData.TenantId },
                {  "clusterIdentity.resourceUri", "https://datalake.azure.net/" },
                {  "clusterIdentity.certificatePassword", commonData.CertPassword }
            };

            configurations.Add(clusterIdentity, clusterIdentityConfig);
            bool isDefault = !createParamsForADLSv1.Properties.StorageProfile.Storageaccounts.Any();
            if (isDefault)
            {
                string coreSite = "core-site";
                var coreConfig = new Dictionary<string, string>()
                {
                    { "fs.defaultFS", "adl://home" },
                    { "dfs.adls.home.hostname", commonData.DataLakeStoreAccountName + ".azuredatalakestore.net" },
                    { "dfs.adls.home.mountpoint", commonData.DataLakeStoreMountpoint }
                };

                configurations.Add(coreSite, coreConfig);
            }

            return createParamsForADLSv1;
        }

        /// <summary>
        /// Create cluster create parameters for ADLS Gen2 relevant tests
        /// </summary>
        /// <param name="commonData"></param>
        /// <param name="storageAccountName"></param>
        /// <param name="storageResourceId"></param>
        /// <param name="msiResourceId"></param>
        /// <param name="createParams"></param>
        /// <returns></returns>
        public static ClusterCreateParametersExtended PrepareClusterCreateParamsForADLSv2(
            this CommonTestFixture commonData,
            string storageAccountName,
            string storageResourceId,
            string msiResourceId,
            ClusterCreateParametersExtended createParams = null)
        {
            var createParamsForADLSv2 = createParams ?? commonData.PrepareClusterCreateParams();
            bool isDefault = !createParamsForADLSv2.Properties.StorageProfile.Storageaccounts.Any();
            createParamsForADLSv2.Properties.StorageProfile.Storageaccounts.Add(
                new HDInsightStorageAccount
                {
                    Name = storageAccountName + commonData.DfsEndpointSuffix,
                    IsDefault = isDefault,
                    FileSystem = commonData.ContainerName.ToLowerInvariant(),
                    ResourceId = storageResourceId,
                    MsiResourceId = msiResourceId
                }
            );

            var identity = new ClusterIdentity
            {
                Type = ResourceIdentityType.UserAssigned,
                UserAssignedIdentities = new Dictionary<string, ClusterIdentityUserAssignedIdentitiesValue>
                {
                    { msiResourceId, new ClusterIdentityUserAssignedIdentitiesValue() }
                }
            };

            if (createParamsForADLSv2.Identity == null)
            {
                createParamsForADLSv2.Identity = identity;
            }
            else
            {
                // At this point, only user-assigned managed identity is supported by HDInsight.
                // So identity type is not checked.
                createParamsForADLSv2.Identity.UserAssignedIdentities.Union(identity.UserAssignedIdentities);
            }

            return createParamsForADLSv2;
        }

        /// <summary>
        /// Create cluster create parameters for WASB relevant tests.
        /// </summary>
        /// <param name="commonData"></param>
        /// <returns></returns>
        public static ClusterCreateParametersExtended PrepareClusterCreateParamsForWasb(this CommonTestFixture commonData)
        {
            return commonData.PrepareClusterCreateParams(commonData.StorageAccountName, commonData.StorageAccountKey);
        }

        /// <summary>
        /// Create cluster create parameters for WASB relevant tests.
        /// </summary>
        /// <param name="commonData"></param>
        /// <param name="storageAccountName"></param>
        /// <param name="storageAccountKey"></param>
        /// <returns></returns>
        private static ClusterCreateParametersExtended PrepareClusterCreateParams(this CommonTestFixture commonData, string storageAccountName = null, string storageAccountKey = null)
        {
            var storageAccounts = new List<HDInsightStorageAccount>();
            if (storageAccountName != null)
            {
                storageAccounts.Add(
                    new HDInsightStorageAccount
                    {
                        Name = storageAccountName + commonData.BlobEndpointSuffix,
                        Key = storageAccountKey,
                        Container = commonData.ContainerName.ToLowerInvariant(),
                        IsDefault =  true
                    }
                );
            }

            return new ClusterCreateParametersExtended
            {
                Location = commonData.Location,
                Properties = new ClusterCreateProperties
                {
                    ClusterVersion = "3.6",
                    OsType = OSType.Linux,
                    Tier = Tier.Standard,
                    ClusterDefinition = new ClusterDefinition
                    {
                        Kind = "Hadoop",
                        Configurations = new Dictionary<string, Dictionary<string, string>>()
                        {
                            { "gateway", new Dictionary<string, string>
                                {
                                    { "restAuthCredential.isEnabled", "true" },
                                    { "restAuthCredential.username", commonData.ClusterUserName },
                                    { "restAuthCredential.password", commonData.ClusterPassword }
                                }
                            }
                        }
                    },
                    ComputeProfile = new ComputeProfile
                    {
                        Roles = new List<Role>
                        {
                            new Role
                            {
                                Name = "headnode",
                                TargetInstanceCount = 2,
                                HardwareProfile = new HardwareProfile
                                {
                                    VmSize = "Large"
                                },
                                OsProfile = new OsProfile
                                {
                                    LinuxOperatingSystemProfile = new LinuxOperatingSystemProfile
                                    {
                                        Username = commonData.SshUsername,
                                        Password = commonData.SshPassword
                                    }
                                }
                            },
                            new Role
                            {
                                Name = "workernode",
                                TargetInstanceCount = 3,
                                HardwareProfile = new HardwareProfile
                                {
                                    VmSize = "Large"
                                },
                                OsProfile = new OsProfile
                                {
                                    LinuxOperatingSystemProfile = new LinuxOperatingSystemProfile
                                    {
                                        Username = commonData.SshUsername,
                                        Password = commonData.SshPassword
                                    }
                                }
                            },
                            new Role
                            {
                                Name = "zookeepernode",
                                TargetInstanceCount = 3,
                                HardwareProfile = new HardwareProfile
                                {
                                    VmSize = "Small"
                                },
                                OsProfile = new OsProfile
                                {
                                    LinuxOperatingSystemProfile = new LinuxOperatingSystemProfile
                                    {
                                        Username = commonData.SshUsername,
                                        Password = commonData.SshPassword
                                    }
                                }
                            }
                        }
                    },
                    StorageProfile = new StorageProfile
                    {
                        Storageaccounts = storageAccounts
                    }
                }
            };
        }

        /// <summary>
        /// Determine whether the current test mode is record mode
        /// </summary>
        /// <returns></returns>
        public static bool IsRecordMode()
        {
            return HttpMockServer.Mode == HttpRecorderMode.Record;
        }

        /// <summary>
        /// Determine whether the current test mode is playback mode
        /// </summary>
        /// <returns></returns>
        public static bool IsPlaybackMode()
        {
            return HttpMockServer.Mode == HttpRecorderMode.Playback;
        }

        /// <summary>
        /// Get current subscription Id from test configurations(Environment variables).
        /// </summary>
        /// <returns></returns>
        public static string GetSubscriptionId()
        {
            string subscriptionId = null;
            if (IsRecordMode())
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                HttpMockServer.Variables[ConnectionStringKeys.SubscriptionIdKey] = environment.SubscriptionId;
                subscriptionId = environment.SubscriptionId;
            }
            else if (IsPlaybackMode())
            {
                subscriptionId = HttpMockServer.Variables[ConnectionStringKeys.SubscriptionIdKey];
            }

            return subscriptionId;
        }

        /// <summary>
        /// Get current tenant Id from test configurations(Environment variables).
        /// </summary>
        /// <returns></returns>
        public static string GetTenantId()
        {
            string tenantId = null;
            if (IsRecordMode())
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                HttpMockServer.Variables[ConnectionStringKeys.AADTenantKey] = environment.Tenant;
                tenantId = environment.Tenant;
            }
            else if (IsPlaybackMode())
            {
                tenantId = HttpMockServer.Variables[ConnectionStringKeys.AADTenantKey];
            }
            return tenantId;
        }

        /// <summary>
        /// Get service principal Id from test configurations(Environment variables).
        /// </summary>
        /// <returns></returns>
        public static string GetServicePrincipalId()
        {
            string servicePrincipalId = null;
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey] = environment.ConnectionString.KeyValuePairs.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.ServicePrincipalKey);
                servicePrincipalId = HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey];
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                servicePrincipalId = HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey];
            }
            return servicePrincipalId;
        }

        /// <summary>
        /// Get service principal secret from test configurations(Environment variables).
        /// </summary>
        /// <returns></returns>
        public static string GetServicePrincipalSecret()
        {
            string servicePrincipalSecret = null;
            if (IsRecordMode())
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                servicePrincipalSecret = environment.ConnectionString.KeyValuePairs.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.ServicePrincipalSecretKey);
            }
            else if (IsPlaybackMode())
            {
                servicePrincipalSecret = "xyz";
            }
            return servicePrincipalSecret;
        }

        /// <summary>
        /// Get service principal object id from test configurations(Environment variables).
        /// </summary>
        /// <returns></returns>
        public static string GetServicePrincipalObjectId()
        {
            string servicePrincipalObjectId = null;
            if (IsRecordMode())
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                HttpMockServer.Variables[ConnectionStringKeys.AADClientIdKey] = environment.ConnectionString.KeyValuePairs.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.AADClientIdKey);
                servicePrincipalObjectId = HttpMockServer.Variables[ConnectionStringKeys.AADClientIdKey];
            }
            else if (IsPlaybackMode())
            {
                servicePrincipalObjectId = HttpMockServer.Variables[ConnectionStringKeys.AADClientIdKey];
            }
            return servicePrincipalObjectId;
        }

        /// <summary>
        /// Create a key vault client
        /// </summary>
        /// <returns></returns>
        public static KeyVaultClient GetKeyVaultClient()
        {
            return new KeyVaultClient(GetAccessToken, GetHandlers());
        }

        /// <summary>
        /// Get access token
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static async Task<string> GetAccessToken(string authority, string resource, string scope)
        {
            string accessToken = null;
            if (IsRecordMode())
            {
                var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
                string authClientId = GetServicePrincipalId();
                string authSecret = GetServicePrincipalSecret();
                var clientCredential = new ClientCredential(authClientId, authSecret);
                var result = await context.AcquireTokenAsync(resource, clientCredential).ConfigureAwait(false);
                accessToken = result.AccessToken;
            }
            else if (IsPlaybackMode())
            {
                accessToken = "fake-token";
            }

            return accessToken;
        }

        /// <summary>
        /// Get delegating handlers
        /// </summary>
        /// <returns></returns>
        public static DelegatingHandler[] GetHandlers()
        {
            HttpMockServer server = HttpMockServer.CreateInstance();
            return new DelegatingHandler[] { server };
        }
    }
}
