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
                        UserName = "hadoop",
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
                        UserName = "hadoop",
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
                ClusterType = HDInsightClusterType.Hadoop,
                WorkerNodeSize = "Large",
                DefaultStorageAccountName = StorageAccountName,
                DefaultStorageAccountKey = StorageAccountKey,
                OSType = OSType.Windows,
                UserName = HttpUser,
                Password = HttpPassword,
                DefaultStorageContainer = DefaultContainer,
                Location =  "West US"
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
                ClusterType = HDInsightClusterType.Hadoop,
                WorkerNodeSize = "Large",
                DefaultStorageAccountName = StorageAccountName,
                DefaultStorageAccountKey = StorageAccountKey,
                OSType = OSType.Linux,
                UserName = HttpUser,
                Password = HttpPassword,
                DefaultStorageContainer = DefaultContainer,
                Location = "West US",
                SshUserName = SshUser,
                SshPassword = SshPassword,
                Version = "3.2"
            };
            return clusterparams;
        }
    }
}
