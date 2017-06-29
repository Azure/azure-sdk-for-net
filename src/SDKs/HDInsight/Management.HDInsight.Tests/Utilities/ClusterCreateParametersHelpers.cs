//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Management.HDInsight.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.HDInsight.Models;
    using Newtonsoft.Json;
    using Microsoft.HDInsight.Models;
    using Microsoft.HDInsight;

    public static class ClusterCreateParametersHelpers
    {
        private const string ADLDefaultStorageAccountName = "";
        private const string DefaultContainer = "";
        private const string StorageAccountName = "";
        private const string StorageAccountKey = "";
        private const string SshKey = "";
        private const string SshUser = "";
        private const string SshPassword = "";
        private const string HttpUser = "";
        private const string HttpPassword = "";
        private const string VirtualNetworkId = "";
        private const string SubnetName = "";
        private const string DomainUserName = "";
        private const string DomainUserPassword = "";
        private const string OrganizationalUnitDN = "";
        private static readonly List<string> ClusterUsersGroupDNs = new List<string> { "" };
        private static readonly List<string> LdapsUrls = new List<string> { "" };
        private static readonly string[] DomainNameParts = new string[2] { "", "" };

        public static ClusterCreateParameters GetCustomCreateParametersIaas()
        {
            var clusterparams = new ClusterCreateParameters
            {
                ClusterSizeInNodes = 3,
                ClusterType = "Hadoop",
                WorkerNodeSize = "Large",
                DefaultStorageInfo = GetDefaultAzureStorageInfo(DefaultContainer),
                UserName = HttpUser,
                Password = HttpPassword,
                Location = "East US",
                SshUserName = SshUser,
                SshPassword = SshPassword,
                Version = "3.5"
            };
            return clusterparams;
        }

        /// <summary>
        /// Returns appropriate AzureStorageInfo based on test-mode.
        /// </summary>
        private static StorageInfo GetDefaultAzureStorageInfo(string containerName, bool specifyDefaultContainer = true)
        {
            if (HDInsightManagementTestUtilities.IsRecordMode())
            {
                return (specifyDefaultContainer)
                    ? new AzureStorageInfo(StorageAccountName.ToLowerInvariant(), StorageAccountKey, containerName)
                    : new AzureStorageInfo(StorageAccountName, StorageAccountKey);
            }
            else
            {
                string testStorageAccountName = "tmp.blob.core.windows.net";
                string testStorageAccountKey = "teststorageaccountkey";
                string testContainer = "testdefaultcontainer";

                return (specifyDefaultContainer)
                    ? new AzureStorageInfo(testStorageAccountName, testStorageAccountKey, testContainer)
                    : new AzureStorageInfo(testStorageAccountName, testStorageAccountKey);
            }
        }

        public static ClusterCreateParametersExtended GetIaasClusterSpec(string containerName)
        {
            AzureStorageInfo storageInfo = GetDefaultAzureStorageInfo(containerName) as AzureStorageInfo;
            var cluster = new ClusterCreateParametersExtended
            {
                Location = "East US",
                Tags = new Dictionary<string, string>(),
                Properties = new ClusterCreateProperties
                {
                    ClusterVersion = "3.5",
                    OsType = OSType.Linux,
                    ClusterDefinition = new ClusterDefinition
                    {
                        Kind = "Hadoop",
                        ComponentVersion = new Dictionary<string, string>(),
                        Configurations = new Dictionary<string, Dictionary<string, string>>()
                        {
                            {"core-site", new Dictionary<string, string>
                            {
                                { Constants.StorageConfigurations.DefaultFsKey, string.Format("wasb://{0}@{1}", storageInfo.StorageContainer, storageInfo.StorageAccountName.ToLowerInvariant())},
                                { string.Format(Constants.StorageConfigurations.WasbStorageAccountKeyFormat, storageInfo.StorageAccountName.ToLowerInvariant()), storageInfo.StorageAccountKey}
                            }
                            },
                            {"gateway", new Dictionary<string, string>
                            {
                                {"restAuthCredential.isEnabled", "true" },
                                { "restAuthCredential.username", "admin"},
                                { "restAuthCredential.password", "Password1!"}
                            }
                        }
                        }
                    },
                    Tier = Tier.Standard,
                    ComputeProfile = new ComputeProfile
                    {
                        Roles = new List<Role>{
                            new Role
                            {
                                Name = "headnode",
                                TargetInstanceCount = 2,
                                HardwareProfile = new HardwareProfile
                                {
                                    VmSize = DefaultVmSizes.HeadNode.GetSize("Hadoop")
                                },
                                OsProfile = new OsProfile
                                {
                                    LinuxOperatingSystemProfile = new LinuxOperatingSystemProfile
                                    {
                                        Username = SshUser,
                                        Password = SshPassword
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
                                        Username = SshUser,
                                        Password = SshPassword
                                    }
                                }
                            },
                            new Role
                            {
                                Name = "zookeepernode",
                                TargetInstanceCount = 3,
                                HardwareProfile = new HardwareProfile
                                {
                                    VmSize = DefaultVmSizes.ZookeeperNode.GetSize("Hadoop")
                                },
                                OsProfile = new OsProfile
                                {
                                    LinuxOperatingSystemProfile = new LinuxOperatingSystemProfile
                                    {
                                        Username = SshUser,
                                        Password = SshPassword
                                    }
                                }
                            }
                        }
                    }
                }
            };
            
            return cluster;
        }

        private static ClusterCreateParameters GetDefaultFsCreateParametersIaas(StorageInfo defaultStorageInfo)
        {
            var clusterparams = new ClusterCreateParameters
            {
                ClusterSizeInNodes = 3,
                ClusterType = "Hadoop",
                WorkerNodeSize = "Large",
                DefaultStorageInfo = defaultStorageInfo,
                UserName = HttpUser,
                Password = HttpPassword,
                Location = "East US",
                SshUserName = SshUser,
                SshPassword = SshPassword,
                Version = "3.5"
            };

            return clusterparams;
        }

        public static ClusterCreateParameters GetDataLakeDefaultFsCreateParametersIaas()
        {
            var storageInfo = GetDefaultAzureDataLakeStoreInfo();
            return GetDefaultFsCreateParametersIaas(storageInfo);
        }

        public static ClusterCreateParameters GetAzureBlobDefaultFsCreateParametersIaas(bool specifyDefaultContainer = true)
        {
            var storageInfo = GetDefaultAzureStorageInfo(DefaultContainer, specifyDefaultContainer);
            return GetDefaultFsCreateParametersIaas(storageInfo);
        }

        public static ClusterCreateParameters GetAdJoinedCreateParametersIaas()
        {
            var clusterparams = GetCustomCreateParametersIaas();
            clusterparams.Version = "3.5";
            clusterparams.Location = "East US 2";
            clusterparams.VirtualNetworkId = VirtualNetworkId;
            clusterparams.SubnetName = SubnetName;
            clusterparams.SecurityProfile = new SecurityProfile
            {
                DirectoryType = DirectoryType.ActiveDirectory,
                Domain = string.Format("{0}.{1}", DomainNameParts[0], DomainNameParts[1]),
                DomainUserPassword = DomainUserPassword,
                DomainUsername = DomainUserName,
                LdapsUrls = LdapsUrls,
                OrganizationalUnitDN = OrganizationalUnitDN,
                ClusterUsersGroupDNs = ClusterUsersGroupDNs
            };
            return clusterparams;
        }

        public static ClusterCreateParameters GetCustomCreateParametersKafkaIaas()
        {
            var clusterparams = GetCustomCreateParametersIaas();
            clusterparams.Version = "3.5";
            clusterparams.ClusterType = "Kafka";
            clusterparams.Location = "Central US";
            return clusterparams;
        }


        public static ClusterCreateParametersExtended AddConfigurations(ClusterCreateParametersExtended cluster, string configurationKey, Dictionary<string, string> configs)
        {
            string configurations = cluster.Properties.ClusterDefinition.Configurations.ToString();
            var config = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<String, string>>>(configurations);
            config.Add(configurationKey, configs);

            var serializedConfig = JsonConvert.SerializeObject(config);
            cluster.Properties.ClusterDefinition.Configurations = serializedConfig;

            return cluster;
        }


        /// <summary>
        /// Returns appropriate AzureDataLakeStoreInfo based on test-mode.
        /// </summary>
        /// <returns></returns>
        private static StorageInfo GetDefaultAzureDataLakeStoreInfo()
        {
            bool recordMode = HDInsightManagementTestUtilities.IsRecordMode();
            string ADLClusterRootPath = "/Clusters/SDK";

            return recordMode
               ? new AzureDataLakeStoreInfo(ADLDefaultStorageAccountName, ADLClusterRootPath)
               : new AzureDataLakeStoreInfo("tmp.azuredatalakestore.net", ADLClusterRootPath);
        }
    }
}
