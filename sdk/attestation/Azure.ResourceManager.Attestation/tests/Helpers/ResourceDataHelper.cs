// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Attestation.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Attestation.Tests.Helpers
{
    public static class ResourceDataHelper
    {
        public static void AssertResource(ResourceData r1, ResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
        }

        public static void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
            Assert.AreEqual(r1.Location, r2.Location);
            Assert.AreEqual(r1.Tags, r2.Tags);
        }

        #region PrivateEndpointConnection
        public static AttestationPrivateEndpointConnectionData GetPrivateEndpointConnectionData()
        {
            return new AttestationPrivateEndpointConnectionData()
            {
                ConnectionState = new AttestationPrivateLinkServiceConnectionState()
                {
                    Status = AttestationPrivateEndpointServiceConnectionStatus.Approved,
                    Description = "Auto-Approved",
                },
            };
        }
        public static void AssetConnectionState(AttestationPrivateLinkServiceConnectionState data1, AttestationPrivateLinkServiceConnectionState data2)
        {
            Assert.AreEqual(data1.Status, data2.Status);
            Assert.AreEqual(data1.Description, data2.Description);
        }
        public static void AssetPrivateEndpointConnection(AttestationPrivateEndpointConnectionData data1, AttestationPrivateEndpointConnectionData data2)
        {
            AssertResource(data1, data2);
            AssetConnectionState(data1.ConnectionState, data2.ConnectionState);
            Assert.AreEqual(data1.ProvisioningState, data2.ProvisioningState);
        }
        #endregion

        #region Provider
        public static AttestationProviderCreateOrUpdateContent GetProviderData(AzureLocation location)
        {
            return new AttestationProviderCreateOrUpdateContent(location, new AttestationServiceCreationSpecificParams()
            {
                PublicNetworkAccess = PublicNetworkAccessType.Enabled,
            })
            {
                Tags =
                {
                    ["Property1"] = "Value1",
                    ["Property2"] = "Value2",
                    ["Property3"] = "Value3",
                }
            };
        }
        public static void AssertProvider(AttestationProviderData data1, AttestationProviderData data2)
        {
            AssertTrackedResource(data1, data2);
            Assert.AreEqual(data1.Status, data2.Status);
            Assert.AreEqual(data1.AttestUri, data2.AttestUri);
            Assert.AreEqual(data1.PublicNetworkAccess, data2.PublicNetworkAccess);
            Assert.AreEqual(data1.TrustModel, data2.TrustModel);
        }
        #endregion
    }
}
