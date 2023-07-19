// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AgFoodPlatform.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.AgFoodPlatform.Tests.Helpers
{
    public static class ResourceDataHelpers
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

        public static void AssertResource(ResourceData r1, ResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
        }

        #region AgFoodPlatformPrivateEndpointConnectionData
        public static AgFoodPlatformPrivateEndpointConnectionData GetPrivateEndpointConnectionData()
        {
            var data = new AgFoodPlatformPrivateEndpointConnectionData()
            {
                ConnectionState = new AgFoodPlatformPrivateLinkServiceConnectionState()
                {
                    Status = AgFoodPlatformPrivateEndpointServiceConnectionStatus.Approved,
                    Description = "Approved by johndoe@contoso.com"
                },
            };
            return data;
        }
        public static void AssertPrivateEndpointConnection(AgFoodPlatformPrivateEndpointConnectionData data1, AgFoodPlatformPrivateEndpointConnectionData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.ConnectionState, data2.ConnectionState);
            Assert.AreEqual(data1.ProvisioningState, data2.ProvisioningState);
            Assert.AreEqual(data1.PrivateEndpointId, data2.PrivateEndpointId);
        }
        #endregion

        #region FarmBeatData
        public static FarmBeatData GetFarmBeatData(AzureLocation location)
        {
            var data = new FarmBeatData(location)
            {
                Tags =
                {
                    ["key1"] = "value1",
                    ["key2"] = "value2",
                },
            };
            return data;
        }
        public static void AssertFarmBeat(FarmBeatData data1, FarmBeatData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Location, data2.Location);
            Assert.AreEqual(data1.InstanceUri, data2.InstanceUri);
            Assert.AreEqual(data1.SensorIntegration, data2.SensorIntegration);
        }
        #endregion

        #region Extension
        public static void AssertExtension(ExtensionData data1, ExtensionData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.ETag, data2.ETag);
            Assert.AreEqual(data1.ExtensionId, data2.ExtensionId);
            Assert.AreEqual(data1.ExtensionApiDocsLink, data2.ExtensionApiDocsLink);
        }
        #endregion
    }
}
