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
        private const string DefaultContainer = "hdinsightxplatteststore";
        private const string StorageAccountName = "hdinsightxplatteststore.blob.core.windows.net";
        private const string StorageAccountKey = "Ax0K4yWikwbWXx6+bX/KJ9af2NNN14oiTn9YQFuFbHpc8TbXDLbJI6PkZvaMGWLR1WzfUKjIrzT0E9TyaLpB0w==";
        private const string SshKey = "AAAAB3NzaC1yc2EAAAADAQABAAABAQDQdxir92ao4neLuSJH9eOqYF+8GaOhhfmqGKBd4dEuqyrd6ppXmihWZHY/HzMSfkRqQuYJsaJFRFo3P0ExasQoiBbnNOfsxOVrtjoW9NxG5JXeQrFatuYkhLnpLwjL+hNtZ9UWJPMJE2+xSO6Nb7QaOgY1ADfvK2eISAbbuMm1PM/zCQVg3Io2bSlD+DW4rLZZ389VHfzUSd6HNz4oS7czWLpOI/v0faMFMWTcimcN73vJSB5etTf7/JPqwNLq49ZCj0FddjjfeFeCK7z1eYQyfdJ/+wLInSsddfcJ6rXlQourQZfI0BvIn4x+XYpqMNtK6UnQylzwZ5NCu6oxx/c9";
        private const string HttpUser = "hadoopuser";
        private const string HttpPassword = "Password1!";
        private const string RdpUser = "hdirp";
        private const string RdpPassword = "Passw0rd!321";

        private const string SshUser = "ahosny";
        private const string SshPassword = "CsharpJava@12";
   
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
                Location = "East US",
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
                DefaultStorageAccountName = StorageAccountName,
                DefaultStorageAccountKey = StorageAccountKey,
                OSType = OSType.Windows,
                UserName = HttpUser,
                Password = HttpPassword,
                DefaultStorageContainer = DefaultContainer,
                Location =  "East US"
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
                DefaultStorageAccountName = StorageAccountName,
                DefaultStorageAccountKey = StorageAccountKey,
                OSType = OSType.Linux,
                UserName = HttpUser,
                Password = HttpPassword,
                DefaultStorageContainer = DefaultContainer,
                Location = "East US",
                SshUserName = SshUser,
                SshPassword = SshPassword,
                Version = "3.2"
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
                DefaultStorageAccountName = StorageAccountName,
                DefaultStorageAccountKey = StorageAccountKey,
                OSType = OSType.Linux,
                UserName = HttpUser,
                Password = HttpPassword,
                DefaultStorageContainer = DefaultContainer,
                Location = "East US",
                SshUserName = SshUser,
                SshPassword = SshPassword,
                Version = "3.2",
                HeadNodeSize = "ExtraLarge",
                ZookeeperNodeSize = "Large",
            };
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
    }
}
