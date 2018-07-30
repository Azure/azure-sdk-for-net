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
    using System.Collections.Generic;
    using Microsoft.Azure.Management.HDInsight.Models;
    using Microsoft.Azure.Management.HDInsight;
    using System;

    public static class ClusterCreateParametersHelpers
    {
        // Secret values to update while recording tests. Do NOT commit any changes to these values.
        private const string StorageAccountName = "";
        private const string StorageAccountKey = "";
        private const string ApplicationId = "";
        private const string AadTenantId = "";
        private const string CertificatePassword = "";
        private const string ResourceUri = "";
        private const string CertificateFile = @"";
        private const string AdlDefaultStorageAccountName = "";



        // These can be set to anything but all created clusters should be deleted after usage so these aren't secret.
        private const string DefaultContainer = "default";
        private const string SshUser = "sshuser";
        private const string SshPassword = "Password1!";
        private const string HttpUser = "admin";
        private const string HttpPassword = "Password1!";
        private const string AdlStorageRootPath = "/clusters/hdi";
        private const string Location = "North Central US";

        public static ClusterCreateParameters GetCustomCreateParametersIaas(string testName, bool adlStorage = false)
        {
            ClusterCreateParameters clusterparams = new ClusterCreateParameters
            {
                ClusterSizeInNodes = 3,
                ClusterType = "Hadoop",
                WorkerNodeSize = "Large",
                DefaultStorageInfo = adlStorage ? GetDefaultDataLakeStorageInfo() : GetDefaultAzureStorageInfo(testName.ToLowerInvariant()),
                UserName = HttpUser,
                Password = HttpPassword,
                Location = Location,
                SshUserName = SshUser,
                SshPassword = SshPassword,
                Version = "3.6"
            };
            return clusterparams;
        }

        public static ClusterCreateParameters GetCustomCreateParametersForAdl(string clusterName)
        {
            ClusterCreateParameters createParams = GetCustomCreateParametersIaas(clusterName, true);

            Guid appId = string.IsNullOrEmpty(ApplicationId) ? Guid.NewGuid() : new Guid(ApplicationId);
            Guid tenantId = string.IsNullOrEmpty(AadTenantId) ? Guid.NewGuid(): new Guid(AadTenantId);
            byte[] certContents = string.IsNullOrEmpty(CertificateFile) ? new byte[1] : System.IO.File.ReadAllBytes(CertificateFile);
            createParams.Principal = new ServicePrincipal(appId, tenantId, certContents, CertificatePassword);
            return createParams;
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

        private static StorageInfo GetDefaultDataLakeStorageInfo()
        {
            string storageAccountName = HDInsightManagementTestUtilities.IsRecordMode() ? AdlDefaultStorageAccountName : "tmp.azuredatalakestore.net";

            return new AzureDataLakeStoreInfo(storageAccountName, AdlStorageRootPath);
        }

        private static Dictionary<string, string> GetCoreConfigsForStorageInfo(StorageInfo storageInfo)
        {
            if (storageInfo is AzureDataLakeStoreInfo adlStore)
            {
                return new Dictionary<string, string>
                {
                    { Constants.DataLakeConfigurations.ApplicationIdKey, ApplicationId },
                    { Constants.DataLakeConfigurations.TenantIdKey, AadTenantId },
                    { Constants.DataLakeConfigurations.CertificateKey, Convert.ToBase64String(System.IO.File.ReadAllBytes(CertificateFile)) },
                    { Constants.DataLakeConfigurations.CertificatePasswordKey, CertificatePassword },
                    { Constants.DataLakeConfigurations.ResourceUriKey, ResourceUri }
                };
            }
            if (storageInfo is AzureStorageInfo wasbStorage)
            {
                return new Dictionary<string, string>
                {
                    { Constants.StorageConfigurations.DefaultFsKey, string.Format("wasb://{0}@{1}", wasbStorage.StorageContainer, wasbStorage.StorageAccountName.ToLowerInvariant())},
                    { string.Format(Constants.StorageConfigurations.WasbStorageAccountKeyFormat, wasbStorage.StorageAccountName.ToLowerInvariant()), wasbStorage.StorageAccountKey}
                };
            }
            return null;
        }

        public static ClusterCreateParametersExtended GetIaasClusterSpec(string containerName = DefaultContainer, bool adlStorage = false)
        {
            StorageInfo storageInfo = adlStorage ? GetDefaultDataLakeStorageInfo() : GetDefaultAzureStorageInfo(containerName);
            var cluster = new ClusterCreateParametersExtended
            {
                Location = Location,
                Tags = new Dictionary<string, string>(),
                Properties = new ClusterCreateProperties
                {
                    ClusterVersion = "3.6",
                    OsType = OSType.Linux,
                    ClusterDefinition = new ClusterDefinition
                    {
                        Kind = "Hadoop",
                        ComponentVersion = new Dictionary<string, string>(),
                        Configurations = new Dictionary<string, Dictionary<string, string>>()
                        {
                            { "core-site", GetCoreConfigsForStorageInfo(storageInfo) },
                            { "gateway", new Dictionary<string, string>
                                {
                                    { "restAuthCredential.isEnabled", "true" },
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
    }
}
