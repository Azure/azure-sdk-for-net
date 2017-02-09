﻿// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Management.HDInsight
{
    internal partial class ClusterOperations : IClusterOperations
    {
        private static string _wasbStorageAccountKeyFormat = "fs.azure.account.key.{0}";

        /// <summary>
        /// Creates a new HDInsight cluster with the specified parameters.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='clusterCreateParameters'>
        /// Required. The cluster create request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The GetCluster operation response.
        /// </returns>
        public async Task<ClusterGetResponse> CreateAsync(string resourceGroupName, string clusterName, ClusterCreateParameters clusterCreateParameters, CancellationToken cancellationToken)
        {
            try
            {
                var createParamsExtended = GetExtendedClusterCreateParameters(clusterName, clusterCreateParameters);
                return await CreateAsync(resourceGroupName, clusterName, createParamsExtended, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new CloudException(ex.Message);
            }
        }

        /// <summary>
        /// Begins creating a new HDInsight cluster with the specified
        /// parameters.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='clusterCreateParameters'>
        /// Required. The cluster create request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The CreateCluster operation response.
        /// </returns>
        public async Task<ClusterCreateResponse> BeginCreatingAsync(string resourceGroupName, string clusterName, ClusterCreateParameters clusterCreateParameters, CancellationToken cancellationToken)
        {
            try
            {
                var createParamsExtended = GetExtendedClusterCreateParameters(clusterName, clusterCreateParameters);
                return await BeginCreatingAsync(resourceGroupName, clusterName, createParamsExtended, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new CloudException(ex.Message);
            }
        }

        internal ClusterCreateParametersExtended GetExtendedClusterCreateParameters(
            string clusterName, ClusterCreateParameters clusterCreateParameters)
        {
            var createParamsExtended = new ClusterCreateParametersExtended
            {
                Location = clusterCreateParameters.Location,
                Properties = new ClusterCreateProperties
                {
                    ClusterDefinition = new ClusterDefinition
                    {
                        ClusterType = clusterCreateParameters.ClusterType
                    },
                    ClusterVersion = clusterCreateParameters.Version,
                    OperatingSystemType = clusterCreateParameters.OSType,
                    ClusterTier = clusterCreateParameters.ClusterTier 
                }
            };

            createParamsExtended.Properties.ClusterDefinition.ComponentVersion = new Dictionary<string, string>(clusterCreateParameters.ComponentVersion);

            var configurations = GetConfigurations(clusterName, clusterCreateParameters);

            if (clusterCreateParameters.HiveMetastore != null)
            {
                var metastoreConfig = GetMetastoreConfig(clusterCreateParameters.HiveMetastore, clusterCreateParameters.OSType, "Hive");
                foreach (var configSet in metastoreConfig)
                {
                    if (configurations.ContainsKey(configSet.Key))
                    {
                        foreach (var config in configSet.Value)
                        {
                            configurations[configSet.Key].Add(config.Key, config.Value);
                        }
                    }
                    else
                    {
                        configurations.Add(configSet.Key, configSet.Value);
                    }
                }
            }
            if (clusterCreateParameters.OozieMetastore != null)
            {
                var metastoreConfig = GetMetastoreConfig(clusterCreateParameters.OozieMetastore, clusterCreateParameters.OSType, "oozie");
                foreach (var configSet in metastoreConfig)
                {
                    if (configurations.ContainsKey(configSet.Key))
                    {
                        foreach (var config in configSet.Value)
                        {
                            configurations[configSet.Key].Add(config.Key, config.Value);
                        }
                    }
                    else
                    {
                        configurations.Add(configSet.Key, configSet.Value);
                    }
                }
            }

            var serializedConfig = JsonConvert.SerializeObject(configurations);
            createParamsExtended.Properties.ClusterDefinition.Configurations = serializedConfig;

            if (clusterCreateParameters.SecurityProfile != null)
            {
                createParamsExtended.Properties.SecurityProfile = clusterCreateParameters.SecurityProfile;
            }

            var roles = GetRoleCollection(clusterCreateParameters);

            createParamsExtended.Properties.ComputeProfile = new ComputeProfile();
            foreach (var role in roles)
            {
                createParamsExtended.Properties.ComputeProfile.Roles.Add(role);
            }

            return createParamsExtended;
        }

        internal static Dictionary<string, Dictionary<string, string>> GetMetastoreConfig(Metastore metastore,
            OSType osType, string metastoreType)
        {
            var server = "";
            if (metastore.Server != null)
            {
                server = metastore.Server;
            }

            var index = server.LastIndexOf(".database.windows.net", StringComparison.OrdinalIgnoreCase);
            if (index > 0)
            {
                server = server.Substring(0, index);
            }

            var connectionUrl =
                string.Format(
                    "jdbc:sqlserver://{0}.database.windows.net;database={1};encrypt=true;trustServerCertificate=true;create=false;loginTimeout=300;sendStringParametersAsUnicode=true;prepareSQL=0",
                    server, metastore.Database);
            var configurations = new Dictionary<string, Dictionary<string, string>>();
            if (metastoreType.Equals("hive", StringComparison.OrdinalIgnoreCase))
            {
                configurations.Add(ConfigurationKey.HiveSite, new Dictionary<string, string>
                {
                    {"javax.jdo.option.ConnectionURL", connectionUrl},
                    {"javax.jdo.option.ConnectionUserName", metastore.User},
                    {"javax.jdo.option.ConnectionPassword", metastore.Password},
                    {"javax.jdo.option.ConnectionDriverName", "com.microsoft.sqlserver.jdbc.SQLServerDriver"}
                });

                if (osType == OSType.Windows)
                {
                    return configurations;
                }

                configurations.Add(ConfigurationKey.HiveEnv, new Dictionary<string, string>
                    {
                        {"hive_database", "Existing MSSQL Server database with SQL authentication"},
                        {"hive_database_name", metastore.Database},
                        {"hive_database_type", "mssql"},
                        {"hive_existing_mssql_server_database", metastore.Database},
                        {"hive_existing_mssql_server_host", string.Format("{0}.database.windows.net", server)},
                        {"hive_hostname", string.Format("{0}.database.windows.net", server)}
                    });
            }
            else
            {
                configurations.Add(ConfigurationKey.OozieSite, new Dictionary<string, string>
                {
                    {"oozie.service.JPAService.jdbc.url", connectionUrl},
                    {"oozie.service.JPAService.jdbc.username", metastore.User},
                    {"oozie.service.JPAService.jdbc.password", metastore.Password},
                    {"oozie.service.JPAService.jdbc.driver", "com.microsoft.sqlserver.jdbc.SQLServerDriver"}
                });

                if (osType == OSType.Windows)
                {
                    return configurations;
                }

                configurations[ConfigurationKey.OozieSite].Add("oozie.db.schema.name", "oozie");
                configurations.Add(ConfigurationKey.OozieEnv, new Dictionary<string, string>
                {
                    {"oozie_database", "Existing MSSQL Server database with SQL authentication"},
                    {"oozie_database_name", metastore.Database},
                    {"oozie_database_type", "mssql"},
                    {"oozie_existing_mssql_server_database", metastore.Database},
                    {"oozie_existing_mssql_server_host", string.Format("{0}.database.windows.net", server)},
                    {"oozie_hostname", string.Format("{0}.database.windows.net", server)}
                });
            }
            return configurations;
        }

        private static Dictionary<string, Dictionary<string, string>> GetConfigurations(string clusterName,
            ClusterCreateParameters clusterCreateParameters)
        {
            var configurations = clusterCreateParameters.Configurations;

            //Core Config
            var coreConfigExists = true;
            Dictionary<string, string> coreConfig;
            configurations.TryGetValue(ConfigurationKey.CoreSite, out coreConfig);

            if (coreConfig == null)
            {
                coreConfigExists = false;
                coreConfig = new Dictionary<string, string>();
            }

            AddDefaultStorageAccountToCoreConfig(clusterName, clusterCreateParameters, coreConfig);

            AddWasbStorageAccountKeyToCoreConfig(clusterCreateParameters, coreConfig);

            AddAdditionalStorageAcountsToCoreConfig(clusterCreateParameters, coreConfig);

            if (!coreConfigExists)
            {
                configurations.Add(ConfigurationKey.CoreSite, coreConfig);
            }
            else
            {
                configurations[ConfigurationKey.CoreSite] = coreConfig;
            }

            //Gateway Config
            Dictionary<string, string> gatewayConfig;
            configurations.TryGetValue(ConfigurationKey.Gateway, out gatewayConfig);

            if (gatewayConfig == null)
            {
                gatewayConfig = new Dictionary<string, string>();
            }

            if (!string.IsNullOrEmpty(clusterCreateParameters.UserName))
            {
                gatewayConfig.Add("restAuthCredential.isEnabled", "true");
                gatewayConfig.Add("restAuthCredential.username", clusterCreateParameters.UserName);
                gatewayConfig.Add("restAuthCredential.password", clusterCreateParameters.Password);
            }
            else
            {
                gatewayConfig.Add("restAuthCredential.isEnabled", "false");
            }

            configurations.Add(ConfigurationKey.Gateway, gatewayConfig);

            //datalake configs
            var datalakeConfigExists = true;
            Dictionary<string, string> datalakeConfig;
            configurations.TryGetValue(ConfigurationKey.ClusterIdentity, out datalakeConfig);

            if (datalakeConfig == null)
            {
                datalakeConfigExists = false;
            }

            //Add/override datalake config if principal is provided by user
            if (clusterCreateParameters.Principal != null)
            {
                datalakeConfig = new Dictionary<string, string>();
                ServicePrincipal servicePrincipalObj = (ServicePrincipal)clusterCreateParameters.Principal;

                datalakeConfig.Add("clusterIdentity.applicationId", servicePrincipalObj.ApplicationId.ToString());
                // converting the tenant Id to URI as RP expects this to be URI
                datalakeConfig.Add("clusterIdentity.aadTenantId", "https://login.windows.net/" + servicePrincipalObj.AADTenantId.ToString());
                datalakeConfig.Add("clusterIdentity.certificate", Convert.ToBase64String(servicePrincipalObj.CertificateFileBytes));
                datalakeConfig.Add("clusterIdentity.certificatePassword", servicePrincipalObj.CertificatePassword);
                datalakeConfig.Add("clusterIdentity.resourceUri", servicePrincipalObj.ResourceUri.ToString());

                if (!datalakeConfigExists)
                {
                    configurations.Add(ConfigurationKey.ClusterIdentity, datalakeConfig);
                }
                else
                {
                    configurations[ConfigurationKey.ClusterIdentity] = datalakeConfig;
                }
            }
            return configurations;
        }

        private static void AddAdditionalStorageAcountsToCoreConfig(ClusterCreateParameters clusterCreateParameters, Dictionary<string, string> coreConfig)
        {
            foreach (var storageAccount in clusterCreateParameters.AdditionalStorageAccounts)
            {
                var configKey = string.Format(_wasbStorageAccountKeyFormat, storageAccount.Key);
                if (!string.IsNullOrEmpty(storageAccount.Value) && !coreConfig.ContainsKey(configKey))
                {
                    coreConfig.Add(configKey, storageAccount.Value);
                }
            }
        }

        private static void AddWasbStorageAccountKeyToCoreConfig(ClusterCreateParameters clusterCreateParameters, Dictionary<string, string> coreConfig)
        {
            var storageAccountInfo = clusterCreateParameters.DefaultStorageInfo as AzureStorageInfo;
            if (storageAccountInfo != null)
            {
                string defaultStorageConfigKey = string.Format(_wasbStorageAccountKeyFormat, clusterCreateParameters.DefaultStorageInfo.StorageAccountName);
                string storageAccountKey = storageAccountInfo.StorageAccountKey;

                if (!string.IsNullOrEmpty(storageAccountKey) && !coreConfig.ContainsKey(defaultStorageConfigKey))
                {
                    coreConfig.Add(defaultStorageConfigKey, storageAccountKey);
                }
            }
        }

        private static void AddDefaultStorageAccountToCoreConfig(string clusterName, ClusterCreateParameters clusterCreateParameters, Dictionary<string, string> coreConfig)
        {
            string coreConfigDefaultFSKey = "fs.defaultFS";
            string coreConfigDefaultFSKeyFor_2_1_Clusters = "fs.default.name";

            var defaultStorageAccountKey = (clusterCreateParameters.Version != null && clusterCreateParameters.Version.Equals("2.1"))
                                                ? coreConfigDefaultFSKeyFor_2_1_Clusters
                                                : coreConfigDefaultFSKey;

            var azureStorageAccountInfo = clusterCreateParameters.DefaultStorageInfo as AzureStorageInfo;
            var azureDataLakeStorageInfo = clusterCreateParameters.DefaultStorageInfo as AzureDataLakeStoreInfo;

            if(azureStorageAccountInfo != null)
            {
                if (string.IsNullOrWhiteSpace(azureStorageAccountInfo.StorageContainer))
                {
                    var storageInfoWithContainerName = new AzureStorageInfo(azureStorageAccountInfo.StorageAccountName, azureStorageAccountInfo.StorageAccountKey, clusterName);
                    clusterCreateParameters.DefaultStorageInfo = storageInfoWithContainerName;
                    coreConfig[defaultStorageAccountKey] = storageInfoWithContainerName.StorageAccountUri;
                }
                else
                {
                    coreConfig[defaultStorageAccountKey] = azureStorageAccountInfo.StorageAccountUri;
                }
            }
            else if (azureDataLakeStorageInfo != null)
            {
                // setup the parameters required for DataLake containers
                coreConfig[defaultStorageAccountKey] = "adl://home";
                coreConfig["dfs.adls.home.hostname"] = azureDataLakeStorageInfo.StorageAccountName;
                coreConfig["dfs.adls.home.mountpoint"] = azureDataLakeStorageInfo.StorageRootPath;
            }
        }

        private static IEnumerable<Role> GetRoleCollection(ClusterCreateParameters clusterCreateParameters)
        {
            //OS Profile
            var osProfile = new OsProfile();
            if (clusterCreateParameters.OSType == OSType.Windows)
            {
                RdpSettings rdpSettings = null;
                if (!string.IsNullOrEmpty(clusterCreateParameters.RdpUsername))
                {
                    rdpSettings = new RdpSettings
                    {
                        UserName = clusterCreateParameters.RdpUsername,
                        Password = clusterCreateParameters.RdpPassword,
                        ExpiryDate = clusterCreateParameters.RdpAccessExpiry
                    };
                }

                osProfile = new OsProfile
                {
                    WindowsOperatingSystemProfile = new WindowsOperatingSystemProfile
                    {
                        RdpSettings = rdpSettings
                    }
                };
            }
            else if (clusterCreateParameters.OSType == OSType.Linux)
            {
                var sshPublicKeys = new List<SshPublicKey>();
                if (!string.IsNullOrEmpty(clusterCreateParameters.SshPublicKey))
                {
                    var sshPublicKey = new SshPublicKey
                    {
                        CertificateData = clusterCreateParameters.SshPublicKey
                    };
                    sshPublicKeys.Add(sshPublicKey);
                }

                SshProfile sshProfile;
                if (sshPublicKeys.Count > 0)
                {
                    sshProfile = new SshProfile
                    {
                        SshPublicKeys = sshPublicKeys
                    };
                }
                else
                {
                    sshProfile = null;
                }

                osProfile = new OsProfile
                {
                    LinuxOperatingSystemProfile = new LinuxOperatingSystemProfile
                    {
                        UserName = clusterCreateParameters.SshUserName,
                        Password = clusterCreateParameters.SshPassword,
                        SshProfile = sshProfile
                    }
                };
            }

            //VNet Profile
            var vnetProfile = new VirtualNetworkProfile();
            if (!string.IsNullOrEmpty(clusterCreateParameters.VirtualNetworkId))
            {
                vnetProfile.Id = clusterCreateParameters.VirtualNetworkId;
            }
            if (!string.IsNullOrEmpty(clusterCreateParameters.SubnetName))
            {
                vnetProfile.SubnetName = clusterCreateParameters.SubnetName;
            }
            if (string.IsNullOrEmpty(vnetProfile.Id) && string.IsNullOrEmpty(vnetProfile.SubnetName))
            {
                vnetProfile = null;
            }

            List<ScriptAction> workernodeactions = null;
            List<ScriptAction> headnodeactions = null;
            List<ScriptAction> zookeepernodeactions = null;
            //Script Actions
            foreach (var scriptAction in clusterCreateParameters.ScriptActions)
            {
                if (scriptAction.Key.ToString().ToLower().Equals("workernode"))
                {
                    workernodeactions = scriptAction.Value;
                }
                else if (scriptAction.Key.ToString().ToLower().Equals("headnode"))
                {
                    headnodeactions = scriptAction.Value;
                }
                else if (scriptAction.Key.ToString().ToLower().Equals("zookeepernode"))
                {
                    zookeepernodeactions = scriptAction.Value;
                }
            }

            //Roles
            var roles = new List<Role>();
            var headNodeSize = GetHeadNodeSize(clusterCreateParameters);
            var headNode = new Role
            {
                Name = "headnode",
                TargetInstanceCount = 2,
                HardwareProfile = new HardwareProfile
                {
                    VmSize = headNodeSize
                },
                OsProfile = osProfile,
                VirtualNetworkProfile = vnetProfile,
                ScriptActions = headnodeactions
            };
            roles.Add(headNode);

            var workerNodeSize = GetWorkerNodeSize(clusterCreateParameters);
            var workerNode = new Role
            {
                Name = "workernode",
                TargetInstanceCount = clusterCreateParameters.ClusterSizeInNodes,
                HardwareProfile = new HardwareProfile
                {
                    VmSize = workerNodeSize
                },
                OsProfile = osProfile,
                ScriptActions = workernodeactions
            };
            roles.Add(workerNode);

            if (clusterCreateParameters.OSType == OSType.Windows)
            {
                if (clusterCreateParameters.ClusterType.Equals("Hadoop", StringComparison.OrdinalIgnoreCase) ||
                    clusterCreateParameters.ClusterType.Equals("Spark", StringComparison.OrdinalIgnoreCase))
                {
                    return roles;
                }
            }

            if (clusterCreateParameters.OSType == OSType.Linux)
            {
                if (clusterCreateParameters.ClusterType.Equals("Hadoop", StringComparison.OrdinalIgnoreCase) ||
                    clusterCreateParameters.ClusterType.Equals("Spark", StringComparison.OrdinalIgnoreCase))
                {
                    clusterCreateParameters.ZookeeperNodeSize = "Small";
                }
            }

            string zookeeperNodeSize = clusterCreateParameters.ZookeeperNodeSize ?? "Medium";
            var zookeepernode = new Role
            {
                Name = "zookeepernode",
                ScriptActions = zookeepernodeactions,
                TargetInstanceCount = 3,
                OsProfile = osProfile,
                HardwareProfile = new HardwareProfile
                {
                    VmSize = zookeeperNodeSize
                }
            };

            roles.Add(zookeepernode);

            return roles;
        }

        private static readonly Dictionary<string, string> HeadNodeDefaultSizes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) { 
                    {"hadoop", "Standard_D3" },
                    {"spark", "Standard_D12"},
                    {"InteractiveHive", "Standard_D13_v2"},
                };

        internal static string GetHeadNodeSize(ClusterCreateParameters clusterCreateParameters)
        {
            string headNodeSize;
            if (clusterCreateParameters.HeadNodeSize != null)
            {
                headNodeSize = clusterCreateParameters.HeadNodeSize;
            }
            else
            {
                if (! HeadNodeDefaultSizes.TryGetValue(clusterCreateParameters.ClusterType, out headNodeSize))
                {
                    headNodeSize = "Large";
                }
            }

            return headNodeSize;
        }

        private static readonly Dictionary<string, string> WorkerNodeDefaultSizes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) { 
                    {"spark", "Standard_D12"},
                    {"InteractiveHive", "Standard_D13_v2"},
                };

        internal static string GetWorkerNodeSize(ClusterCreateParameters clusterCreateParameters)
        {
            string workerNodeSize;
            if (clusterCreateParameters.WorkerNodeSize != null)
            {
                workerNodeSize = clusterCreateParameters.WorkerNodeSize;
            }
            else
            {
                if (!WorkerNodeDefaultSizes.TryGetValue(clusterCreateParameters.ClusterType, out workerNodeSize))
                {
                    workerNodeSize = "Standard_D3";
                }
            }

            return workerNodeSize;
        }
    }
}
