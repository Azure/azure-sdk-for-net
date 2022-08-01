// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;
using System;

namespace Azure.ResourceManager.CognitiveServices.Tests.Helpers
{
    public static class ResourceDataHelper
    {
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";

        // Temporary solution since the one in Azure.ResourceManager.CognitiveServices is internal
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }

        public static void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
            Assert.AreEqual(r1.Location, r2.Location);
            Assert.AreEqual(r1.Tags, r2.Tags);
        }

        #region Account
        public static void AssertAccount(AccountData account1, AccountData account2)
        {
            AssertTrackedResource(account1, account2);
            Assert.AreEqual(account1.ETag, account2.ETag);
        }

        public static AccountData GetBasicAccountData(AzureLocation location)
        {
            var data = new AccountData(location)
            {
                Sku = new CognitiveServicesSku("S0"),
                Kind = "LUIS",
                Properties = new AccountProperties()
            };
            return data;
        }
        #endregion

        #region CommitmentPlan
        public static void AssertCommitmentPlan(CommitmentPlanData plan1, CommitmentPlanData plan2)
        {
            //AssertTrackedResource(plan1, plan2);
            Assert.AreEqual(plan1.Name, plan2.Name);
            Assert.AreEqual(plan1.Id, plan2.Id);
            Assert.AreEqual(plan1.ResourceType, plan2.ResourceType);
            Assert.AreEqual(plan1.ETag, plan2.ETag);
        }

        public static CommitmentPlanData GetBasicCommitmentPlanData()
        {
            var data = new CommitmentPlanData()
            {
                Properties = new CommitmentPlanProperties()
                {
                    HostingModel = new HostingModel("Web"),
                    PlanType = "TA",
                    AutoRenew = false
                }
            };
            return data;
        }
        #endregion

        #region Deployment
        public static void AssertDeployment(DeploymentData d1, DeploymentData d2)
        {
            Assert.AreEqual(d1.Name, d2.Name);
            Assert.AreEqual(d1.Id, d2.Id);
            Assert.AreEqual(d1.ResourceType, d2.ResourceType);
            Assert.AreEqual(d1.ETag, d2.ETag);
        }

        public static DeploymentData GetBasicDeploymentData()
        {
            var data = new DeploymentData()
            {
                Properties = new DeploymentProperties
                {
                    Model = new DeploymentModel()
                    {
                        Name = "ada",
                        Format = "OpenAI",
                        Version = "1"
                    },
                    ScaleSettings = new DeploymentScaleSettings()
                    {
                         ScaleType = new DeploymentScaleType("Manual"),
                         Capacity = 1
                    }
                }
            };
            return data;
        }
        #endregion

        #region CognitiveServicesPrivateEndpointConnection
        public static void AssertConnection(CognitiveServicesPrivateEndpointConnectionData c1, CognitiveServicesPrivateEndpointConnectionData c2)
        {
            Assert.AreEqual(c1.Name, c2.Name);
            Assert.AreEqual(c1.Id, c2.Id);
            Assert.AreEqual(c1.ResourceType, c2.ResourceType);
            Assert.AreEqual(c1.ETag, c2.ETag);
        }
        public static CognitiveServicesPrivateEndpointConnectionData GetBasicCognitiveServicesPrivateEndpointConnectionData()
        {
            var data = new CognitiveServicesPrivateEndpointConnectionData()
            {
                Properties = new PrivateEndpointConnectionProperties(new CognitiveServicesPrivateLinkServiceConnectionState()
                {
                    Status = "Approved",
                    Description = "Auto-Approved"
                }),
                Location = AzureLocation.EastUS2
            };
            return data;
        }
        #endregion
    }
}
