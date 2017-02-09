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

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.HDInsight.Models;
using Newtonsoft.Json;

namespace HDInsight.Tests.Helpers
{
    public static class GetClusterSpecHelpers
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
        private const string RdpUser = "";
        private const string RdpPassword = "";
        private const string VirtualNetworkId = "";
        private const string SubnetName = "";
        private const string DomainUserName = "";
        private const string DomainUserPassword = "";
        private const string OrganizationalUnitDN = "";
        private static readonly List<string> ClusterUsersGroupDNs = new List<string> {""};
        private static readonly List<string> LdapsUrls = new List<string> { "" };
        private static readonly string[] DomainNameParts = new string[2] { "", "" };

        public static ClusterCreateParametersExtended GetIaasClusterSpec()
        {
            var cluster = new ClusterCreateParametersExtended
            {
                Location = "West US",
                Properties = new ClusterCreateProperties
                {
                    ClusterDefinition = new ClusterDefinition
                    {
                        ClusterType = "Hadoop"
                    },
                    ClusterVersion = "3.2",
                    OperatingSystemType = OSType.Linux
                }
            };

            var coreConfigs = new Dictionary<string, string>
            {
                {"fs.defaultFS", string.Format("wasb://{0}@{1}", DefaultContainer, StorageAccountName)},
                {
                    string.Format("fs.azure.account.key.{0}", StorageAccountName),
                    StorageAccountKey
                }
            };
            var gatewayConfigs = new Dictionary<string, string>
            {
                {"restAuthCredential.isEnabled", "true"},
                {"restAuthCredential.username", HttpUser},
                {"restAuthCredential.password", HttpPassword}
            };
            var configurations = new Dictionary<string, Dictionary<string, string>>
            {
                {"core-site", coreConfigs},
                {"gateway", gatewayConfigs}
            };
            var serializedConfig = JsonConvert.SerializeObject(configurations);
            cluster.Properties.ClusterDefinition.Configurations = serializedConfig;

            cluster.Tags.Add("tag1", "value1");
            cluster.Tags.Add("tag2", "value2");

            var sshPublicKeys = new List<SshPublicKey>();
            var sshPublicKey = new SshPublicKey
            {
                CertificateData =
                    string.Format("ssh-rsa {0}", SshKey)
            };
            sshPublicKeys.Add(sshPublicKey);

            var headNode = new Role
            {
                Name = "headnode",
                TargetInstanceCount = 1,
                HardwareProfile = new HardwareProfile
                {
                    VmSize = "Large"
                },
                OsProfile = new OsProfile
                {
                    LinuxOperatingSystemProfile = new LinuxOperatingSystemProfile
                    {
                        UserName = "sshuser",
                        SshProfile = new SshProfile
                        {
                            SshPublicKeys = sshPublicKeys
                        }
                    }
                },
                VirtualNetworkProfile = new VirtualNetworkProfile
                {
                    Id = "vnetid",
                    SubnetName = "subnetname"
                }
            };

            var workerNode = new Role
            {
                Name = "workernode",
                TargetInstanceCount = 1,
                HardwareProfile = new HardwareProfile
                {
                    VmSize = "Large"
                },
                OsProfile = new OsProfile
                {
                    LinuxOperatingSystemProfile = new LinuxOperatingSystemProfile
                    {
                        UserName = "sshuser",
                        SshProfile = new SshProfile
                        {
                            SshPublicKeys = sshPublicKeys
                        }
                    }
                }
            };
            cluster.Properties.ComputeProfile = new ComputeProfile();
            cluster.Properties.ComputeProfile.Roles.Add(headNode);
            cluster.Properties.ComputeProfile.Roles.Add(workerNode);
            return cluster;
        }

        public static ClusterCreateParametersExtended GetPaasClusterSpec()
        {
            var cluster = new ClusterCreateParametersExtended
            {
                Location = "West US",
                Properties = new ClusterCreateProperties
                {
                    ClusterDefinition = new ClusterDefinition
                    {
                        ClusterType = "Hadoop"
                    },
                    ClusterVersion = "3.1",
                    OperatingSystemType = OSType.Windows
                }
            };

            var coreConfigs = new Dictionary<string, string>
            {
                {"fs.defaultFS", string.Format("wasb://{0}@{1}", DefaultContainer, StorageAccountName)},
                {
                    string.Format("fs.azure.account.key.{0}", StorageAccountName), StorageAccountKey
                }
            };
            var gatewayConfigs = new Dictionary<string, string>
            {
                {"restAuthCredential.isEnabled", "true"},
                {"restAuthCredential.username", HttpUser},
                {"restAuthCredential.password", HttpPassword}
            };

            var configurations = new Dictionary<string, Dictionary<string, string>>
            {
                {"core-site", coreConfigs},
                {"gateway", gatewayConfigs}
            };
            var serializedConfig = JsonConvert.SerializeObject(configurations);
            cluster.Properties.ClusterDefinition.Configurations = serializedConfig;

            cluster.Tags.Add("tag1", "value1");
            cluster.Tags.Add("tag2", "value2");

            var headNode = new Role
            {
                Name = "headnode",
                TargetInstanceCount = 2,
                HardwareProfile = new HardwareProfile
                {
                    VmSize = "ExtraLarge"
                },
                OsProfile = new OsProfile
                {
                    WindowsOperatingSystemProfile = new WindowsOperatingSystemProfile
                    {
                        RdpSettings = new RdpSettings
                        {
                            UserName = RdpUser,
                            Password = RdpPassword,
                            ExpiryDate = new DateTime(2025, 3, 1)
                        }
                    }
                }
            };

            var workerNode = new Role
            {
                Name = "workernode",
                TargetInstanceCount = 5,
                HardwareProfile = new HardwareProfile
                {
                    VmSize = "Large"
                }
            };
            cluster.Properties.ComputeProfile = new ComputeProfile();
            cluster.Properties.ComputeProfile.Roles.Add(headNode);
            cluster.Properties.ComputeProfile.Roles.Add(workerNode);
            return cluster;
        }

        public static ClusterCreateParameters GetCustomCreateParametersPaas()
        {
            var clusterparams = new ClusterCreateParameters
            {
                ClusterSizeInNodes = 3,
                ClusterType = "Hadoop",
                WorkerNodeSize = "Large",
                DefaultStorageInfo = GetDefaultAzureStorageInfo(),
                OSType = OSType.Windows,
                UserName = HttpUser,
                Password = HttpPassword,
                Location = "East US",
                Version = "3.2"
            };
            var actions = new List<ScriptAction>();
            var action = new ScriptAction("action", new Uri("https://uri.com"), "params");
            actions.Add(action);
            clusterparams.ScriptActions.Add(ClusterNodeType.WorkerNode, actions);
            clusterparams.ScriptActions.Add(ClusterNodeType.HeadNode, actions);

            return clusterparams;
        }

        public static ClusterCreateParameters GetCustomCreateParametersIaas()
        {
            var clusterparams = new ClusterCreateParameters
            {
                ClusterSizeInNodes = 3,
                ClusterType = "Hadoop",
                WorkerNodeSize = "Large",
                DefaultStorageInfo = GetDefaultAzureStorageInfo(),
                OSType = OSType.Linux,
                UserName = HttpUser,
                Password = HttpPassword,
                Location = "East US",
                SshUserName = SshUser,
                SshPassword = SshPassword,
                Version = "3.2"
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
            var storageInfo = GetDefaultAzureStorageInfo(specifyDefaultContainer);
            return GetDefaultFsCreateParametersIaas(storageInfo);
        }

        private static ClusterCreateParameters GetDefaultFsCreateParametersIaas(StorageInfo defaultStorageInfo)
        {
            var clusterparams = new ClusterCreateParameters
            {
                ClusterSizeInNodes = 3,
                ClusterType = "Hadoop",
                WorkerNodeSize = "Large",
                DefaultStorageInfo = defaultStorageInfo,
                OSType = OSType.Linux,
                UserName = HttpUser,
                Password = HttpPassword,
                Location = "East US",
                SshUserName = SshUser,
                SshPassword = SshPassword,
                Version = "3.5"
            };

            return clusterparams;
        }

        public static ClusterCreateParameters GetCustomVmSizesCreateParametersIaas()
        {
            var clusterparams = new ClusterCreateParameters
            {
                ClusterSizeInNodes = 1,
                ClusterType = "HBase",
                WorkerNodeSize = "Large",
                DefaultStorageInfo = GetDefaultAzureStorageInfo(),
                OSType = OSType.Linux,
                UserName = HttpUser,
                Password = HttpPassword,
                Location = "East US",
                SshUserName = SshUser,
                SshPassword = SshPassword,
                Version = "3.2",
                HeadNodeSize = "ExtraLarge",
                ZookeeperNodeSize = "Large",
            };
            return clusterparams;
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

        public static ClusterCreateParameters GetCustomCreateParametersSparkIaas()
        {
            var clusterparams = GetCustomCreateParametersIaas();
            clusterparams.Version = "3.5";
            clusterparams.ClusterType = "Spark";
            clusterparams.ComponentVersion.Add("Spark", "2.0");
            return clusterparams;
        }

        public static ClusterCreateParametersExtended AddConfigurations(ClusterCreateParametersExtended cluster, string configurationKey, Dictionary<string, string> configs)
        {
            string configurations = cluster.Properties.ClusterDefinition.Configurations;
            var config = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<String, string>>>(configurations);
            config.Add(configurationKey, configs);

            var serializedConfig = JsonConvert.SerializeObject(config);
            cluster.Properties.ClusterDefinition.Configurations = serializedConfig;

            return cluster;
        }

        /// <summary>
        /// Returns appropriate AzureStorageInfo based on test-mode.
        /// </summary>
        /// <returns></returns>
        private static StorageInfo GetDefaultAzureStorageInfo(bool specifyDefaultContainer=true)
        {
            bool recordMode = HDInsightManagementTestUtilities.IsRecordMode();

            if(recordMode)
            {
                return (specifyDefaultContainer) 
                    ? new AzureStorageInfo(StorageAccountName, StorageAccountKey, DefaultContainer) 
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
