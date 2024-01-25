// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System.Collections.Generic;
using ApiManagementManagement.Tests.Helpers;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ApiManagement.Tests.ResourceProviderTests
{
    public partial class ApiManagementServiceTests : TestBase
    {
        private void ValidateService(
            ApiManagementServiceResource service,
            string expectedServiceName,
            string expectedResourceGroupName,
            string expectedSubId,
            string expectedLocation,
            string expectedPublisherEmail,
            string expectedPublisherName,
            string expectedSkuName,
            Dictionary<string, string> expectedTags,
            string platformVersion)
        {
            Assert.NotNull(service);

            string resourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.ApiManagement/service/{2}";
            string expectedResourceId = string.Format(resourceIdFormat, expectedSubId, expectedResourceGroupName, expectedServiceName);

            Assert.Equal(expectedResourceId, service.Id);
            Assert.Equal(expectedLocation.ToLowerAndRemoveWhiteSpaces(), service.Location.ToLowerAndRemoveWhiteSpaces());
            Assert.Equal(expectedSkuName, service.Sku.Name, true);
            Assert.Equal(expectedServiceName, service.Name);
            Assert.True(expectedTags.DictionaryEqual(service.Tags));
            Assert.NotNull(service.GatewayUrl);
            // No Portal, Management URL and SCM endpoint for Consumption SKU.
            if (service.Sku.Name != SkuType.Consumption)
            {
                Assert.NotNull(service.PortalUrl);
                Assert.NotNull(service.ManagementApiUrl);
                Assert.NotNull(service.DeveloperPortalUrl);
                Assert.NotNull(service.ScmUrl);
                Assert.NotNull(service.PublicIPAddresses);
                Assert.NotNull(service.OutboundPublicIPAddresses);
                Assert.Equal("Enabled", service.PublicNetworkAccess);
                Assert.Equal("Disabled", service.NatGatewayState);
            }
            Assert.Equal(expectedPublisherName, service.PublisherName);
            Assert.Equal(expectedPublisherEmail, service.PublisherEmail);
            Assert.Equal(platformVersion, service.PlatformVersion);
            Assert.NotNull(service.SystemData);
            Assert.NotNull(service.SystemData.CreatedAt);
            Assert.NotNull(service.SystemData.CreatedBy);
            Assert.Equal("Application", service.SystemData.CreatedByType);
            Assert.NotNull(service.SystemData.LastModifiedAt);
            Assert.NotNull(service.SystemData.LastModifiedBy);
            Assert.Equal("Application", service.SystemData.LastModifiedByType);
        }
    }
}
