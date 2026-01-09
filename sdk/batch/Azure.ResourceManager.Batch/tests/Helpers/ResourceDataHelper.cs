// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Batch.Models;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;
using System;
using System.Net.Http.Headers;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Batch.Tests.Helpers
{
    public static class ResourceDataHelper
    {
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }

        public static void AssertResourceData(ResourceData r1, ResourceData r2)
        {
            Assert.Multiple(() =>
            {
                Assert.That(r2.Name, Is.EqualTo(r1.Name));
                Assert.That(r2.Id, Is.EqualTo(r1.Id));
                Assert.That(r2.ResourceType, Is.EqualTo(r1.ResourceType));
            });
        }

        #region BatchAccountCertificate
        public static BatchAccountCertificateCreateOrUpdateContent GetBatchAccountCertificateData()
        {
            var data = new BatchAccountCertificateCreateOrUpdateContent()
            {
                Format = BatchAccountCertificateFormat.Pfx,
                ThumbprintAlgorithm = "sha1",
                ThumbprintString = "cff2ab63c8c955aaf71989efa641b906558d9fb7",
                Password = "nodesdk",
                Data = BinaryData.FromObjectAsJson("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")
        };
            return data;
        }
        public static void AssertCertificate(BatchAccountCertificateData certificateData1, BatchAccountCertificateData certificateData2)
        {
            AssertResourceData(certificateData1, certificateData2);
            Assert.Multiple(() =>
            {
                Assert.That(certificateData2.ETag, Is.EqualTo(certificateData1.ETag));
                Assert.That(certificateData2.PublicData, Is.EqualTo(certificateData1.PublicData));
                Assert.That(certificateData2.ThumbprintAlgorithm, Is.EqualTo(certificateData1.ThumbprintAlgorithm));
                Assert.That(certificateData2.Format, Is.EqualTo(certificateData1.Format));
                Assert.That(certificateData2.PreviousProvisioningState, Is.EqualTo(certificateData1.PreviousProvisioningState));
            });
        }
        #endregion

        #region Account
        public static BatchAccountCreateOrUpdateContent GetBatchAccountData(ResourceIdentifier id)
        {
            var data = new BatchAccountCreateOrUpdateContent(AzureLocation.EastUS)
            {
                AutoStorage = new BatchAccountAutoStorageBaseConfiguration(id)
            };
            return data;
        }
        public static void AssertAccount(BatchAccountData account1, BatchAccountData account2)
        {
            Assert.Multiple(() =>
            {
                Assert.That(account2.Tags, Is.EqualTo(account1.Tags));
                Assert.That(account2.Location, Is.EqualTo(account1.Location));
                Assert.That(account2.AccountEndpoint, Is.EqualTo(account1.AccountEndpoint));
                Assert.That(account2.Name, Is.EqualTo(account1.Name));
                Assert.That(account2.NodeManagementEndpoint, Is.EqualTo(account1.NodeManagementEndpoint));
                Assert.That(account2.DedicatedCoreQuota, Is.EqualTo(account1.DedicatedCoreQuota));
                Assert.That(account2.LowPriorityCoreQuota, Is.EqualTo(account1.LowPriorityCoreQuota));
                Assert.That(account2.IsDedicatedCoreQuotaPerVmFamilyEnforced, Is.EqualTo(account1.IsDedicatedCoreQuotaPerVmFamilyEnforced));
            });
        }
        #endregion

        #region Storage Acccount
        public static StorageAccountCreateOrUpdateContent GetStorageAccountData()
        {
            var sku = new StorageSku("Standard_RAGRS");
            var kind = StorageKind.StorageV2;
            var storageAccount = new StorageAccountCreateOrUpdateContent(sku, kind, AzureLocation.EastUS)
            {
                MinimumTlsVersion = StorageMinimumTlsVersion.Tls1_2,
                AllowBlobPublicAccess = true,
                AllowSharedKeyAccess = true,
                NetworkRuleSet = new StorageAccountNetworkRuleSet(StorageNetworkDefaultAction.Allow)
                {
                    Bypass = StorageNetworkBypass.AzureServices,
                    VirtualNetworkRules =
                    {
                    }
                },
                EnableHttpsTrafficOnly = true,
                Encryption = new StorageAccountEncryption()
                {
                    Services = new StorageAccountEncryptionServices()
                    {
                        File = new StorageEncryptionService()
                        {
                            IsEnabled = true,
                        },
                        Blob = new StorageEncryptionService()
                        {
                            IsEnabled = true
                        }
                    },
                    KeySource = StorageAccountKeySource.Storage
                },
                AccessTier = StorageAccountAccessTier.Hot,
            };
            return storageAccount;
        }
        #endregion

        #region Pool
        public static BatchAccountPoolData GetBatchAccountPoolData()
        {
            var data = new BatchAccountPoolData()
            {
                DisplayName = "test_pool",
                VmSize = "Standard_d4s_v3",
                DeploymentConfiguration = new BatchDeploymentConfiguration()
                {
                    VmConfiguration = new BatchVmConfiguration(
                        new BatchImageReference()
                        {
                            Publisher = "Canonical",
                            Offer = "UbuntuServer",
                            Sku = "18.04-LTS",
                            Version = "latest",
                        },
                        "batch.node.ubuntu 18.04"
                    ),
                },
                StartTask = new BatchAccountPoolStartTask()
                {
                    CommandLine = "cmd.exe /c \"echo hello world\"",
                    ResourceFiles =
                    {
                        new BatchResourceFile()
                        {
                            HttpUri = new Uri("https://blobsource.com"),
                            FilePath = "filename.txt",
                            Identity = new ComputeNodeIdentityReference()
                            {
                                ResourceId = new ResourceIdentifier("refUserId123")
                            }
                        }
                    },
                    EnvironmentSettings =
                    {
                        new BatchEnvironmentSetting("ENV_VAR")
                        {
                            Value = "env_value"
                        }
                    },
                    UserIdentity = new BatchUserIdentity()
                    {
                        AutoUser = new BatchAutoUserSpecification()
                        {
                            ElevationLevel = BatchUserAccountElevationLevel.Admin,
                        }
                    }
                },
                ScaleSettings = new BatchAccountPoolScaleSettings()
                {
                    FixedScale = new BatchAccountFixedScaleSettings()
                    {
                        TargetDedicatedNodes = 0,
                        TargetLowPriorityNodes = 0
                    }
                }
            };
            return data;
        }
        public static void AssertPoolData(BatchAccountPoolData poolData1, BatchAccountPoolData poolData2)
        {
            AssertResourceData(poolData1, poolData2);
            Assert.Multiple(() =>
            {
                Assert.That(poolData2.ETag, Is.EqualTo(poolData1.ETag));
                //Assert.AreEqual(poolData1.AllocationState, poolData2.AllocationState);
                Assert.That(poolData2.DisplayName, Is.EqualTo(poolData1.DisplayName));
                Assert.That(poolData2.VmSize, Is.EqualTo(poolData1.VmSize));
                Assert.That(poolData2.ProvisioningState, Is.EqualTo(poolData1.ProvisioningState));
            });
        }
        #endregion

        #region Application
        public static BatchApplicationData GetBatchApplicationData()
        {
            return new BatchApplicationData()
            {
                AllowUpdates = true,
                DisplayName = "displayName",
                //DefaultVersion = "blah"
            };
        }
        public static void AssertApplicationData(BatchApplicationData applicationData1, BatchApplicationData applicationData2)
        {
            AssertResourceData(applicationData1, applicationData2);
            Assert.Multiple(() =>
            {
                Assert.That(applicationData2.ETag, Is.EqualTo(applicationData1.ETag));
                Assert.That(applicationData2.DisplayName, Is.EqualTo(applicationData1.DisplayName));
                Assert.That(applicationData2.DefaultVersion, Is.EqualTo(applicationData1.DefaultVersion));
                Assert.That(applicationData2.AllowUpdates, Is.EqualTo(applicationData1.AllowUpdates));
            });
        }
        #endregion

        #region ApplicationPackage
        public static BatchApplicationPackageData GetBatchApplicationPackageData()
        {
            var packageData = new BatchApplicationPackageData()
            {
            };
            return packageData;
        }
        public static void AssertApplicationPckageData(BatchApplicationPackageData packageData1, BatchApplicationPackageData packageData2)
        {
            AssertResourceData(packageData1, packageData2);
            Assert.Multiple(() =>
            {
                Assert.That(packageData2.ETag, Is.EqualTo(packageData1.ETag));
                Assert.That(packageData2.State, Is.EqualTo(packageData1.State));
                Assert.That(packageData2.Format, Is.EqualTo(packageData1.Format));
                Assert.That(packageData2.LastActivatedOn, Is.EqualTo(packageData1.LastActivatedOn));
            });
            //Because StorageUriExpireOn is a DateTimeOffset type, and Uri ends with a timestamp, the value is always different, so it is commented out
            //Assert.AreEqual(packageData1.StorageUriExpireOn, packageData2.StorageUriExpireOn);
            //Assert.AreEqual(packageData1.StorageUri, packageData2.StorageUri);
        }
        #endregion
    }
}
