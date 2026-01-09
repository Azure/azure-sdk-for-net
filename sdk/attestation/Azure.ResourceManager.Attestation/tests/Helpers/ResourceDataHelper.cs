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
            Assert.Multiple(() =>
            {
                Assert.That(r2.Name, Is.EqualTo(r1.Name));
                Assert.That(r2.Id, Is.EqualTo(r1.Id));
                Assert.That(r2.ResourceType, Is.EqualTo(r1.ResourceType));
            });
        }

        public static void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.Multiple(() =>
            {
                Assert.That(r2.Name, Is.EqualTo(r1.Name));
                Assert.That(r2.Id, Is.EqualTo(r1.Id));
                Assert.That(r2.ResourceType, Is.EqualTo(r1.ResourceType));
                Assert.That(r2.Location, Is.EqualTo(r1.Location));
                Assert.That(r2.Tags, Is.EqualTo(r1.Tags));
            });
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
            Assert.Multiple(() =>
            {
                Assert.That(data2.Status, Is.EqualTo(data1.Status));
                Assert.That(data2.Description, Is.EqualTo(data1.Description));
            });
        }
        public static void AssetPrivateEndpointConnection(AttestationPrivateEndpointConnectionData data1, AttestationPrivateEndpointConnectionData data2)
        {
            AssertResource(data1, data2);
            AssetConnectionState(data1.ConnectionState, data2.ConnectionState);
            Assert.That(data2.ProvisioningState, Is.EqualTo(data1.ProvisioningState));
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
            Assert.Multiple(() =>
            {
                Assert.That(data2.Status, Is.EqualTo(data1.Status));
                Assert.That(data2.AttestUri, Is.EqualTo(data1.AttestUri));
                Assert.That(data2.PublicNetworkAccess, Is.EqualTo(data1.PublicNetworkAccess));
                Assert.That(data2.TrustModel, Is.EqualTo(data1.TrustModel));
            });
        }
        #endregion
    }
}
