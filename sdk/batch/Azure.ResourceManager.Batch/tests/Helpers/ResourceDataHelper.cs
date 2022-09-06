// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Batch.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;
using System;
using System.Net.Http.Headers;

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
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
        }

        #region BatchAccountCertificate
        public static BatchAccountCertificateCreateOrUpdateContent GetBatchAccountCertificateData()
        {
            var data = new BatchAccountCertificateCreateOrUpdateContent()
            {
                Format = BatchAccountCertificateFormat.Pfx,
                ThumbprintAlgorithm = "sha1",
                Thumbprint = BinaryData.FromString("\"cff2ab63c8c955aaf71989efa641b906558d9fb7\""),
                Password = "nodesdk",
                Data = BinaryData.FromObjectAsJson("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")
        };
            return data;
        }
        public static void AssertCertificate(BatchAccountCertificateData certificateData1, BatchAccountCertificateData certificateData2)
        {
            AssertResourceData(certificateData1, certificateData2);
            Assert.AreEqual(certificateData1.ETag, certificateData2.ETag);
            Assert.AreEqual(certificateData1.PublicData, certificateData2.PublicData);
            Assert.AreEqual(certificateData1.Format, certificateData2.Format);
            Assert.AreEqual(certificateData1.PreviousProvisioningState, certificateData2.PreviousProvisioningState);
        }
        #endregion

        #region Account
        public static BatchAccountCreateOrUpdateContent GetBatchAccountData()
        {
            var data = new BatchAccountCreateOrUpdateContent(AzureLocation.WestUS)
            {
                AutoStorage = new BatchAccountAutoStorageBaseConfiguration(new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/AutoRestResources2/providers/Microsoft.Storage/storageAccounts/20220725datafactory"))
            };
            return data;
        }
        public static void AssertAccount(BatchAccountData account1, BatchAccountData account2)
        {
            Assert.AreEqual(account1.Tags, account2.Tags);
            Assert.AreEqual(account1.Location, account2.Location);
            Assert.AreEqual(account1.AccountEndpoint, account2.AccountEndpoint);
            Assert.AreEqual(account1.Name, account2.Name);
        }
        #endregion

        #region Pool
        public static BatchAccountPoolData GetBatchAccountPoolData()
        {
            var data = new BatchAccountPoolData()
            {
                DisplayName = "test_pool",
                VmSize = "small",
                DeploymentConfiguration = new BatchDeploymentConfiguration()
                {
                    CloudServiceConfiguration = new BatchCloudServiceConfiguration("2")
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
                /*UserAccounts =
                {
                    //new BatchUserAccount("adminUser", "xyz123"),
                    new BatchUserAccount("testaccount", "randompasswd")
                },*/
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
            Assert.AreEqual(poolData1.ETag, poolData2.ETag);
            Assert.AreEqual(poolData1.AllocationState, poolData2.AllocationState);
            Assert.AreEqual(poolData1.SystemData, poolData2.SystemData);
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
            Assert.AreEqual(applicationData1.ETag, applicationData2.ETag);
            Assert.AreEqual(applicationData1.DisplayName, applicationData2.DisplayName);
            Assert.AreEqual(applicationData1.SystemData, applicationData2.SystemData);
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
            Assert.AreEqual(packageData1.ETag, packageData2.ETag);
            Assert.AreEqual(packageData1.State, packageData2.State);
            Assert.AreEqual(packageData1.SystemData, packageData2.SystemData);
        }
        #endregion
    }
}
