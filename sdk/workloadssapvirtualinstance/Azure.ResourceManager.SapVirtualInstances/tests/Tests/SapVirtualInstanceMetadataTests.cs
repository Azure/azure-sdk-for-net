﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SapVirtualInstances.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SapVirtualInstances.Tests.Tests
{
    public class SapVirtualInstanceMetadataTests : WorkloadsManagementTestBase
    {
        public SapVirtualInstanceMetadataTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TestMetadataOperations()
        {
            await sapAvailabilityZoneDetails();
            await sapDiskConfigurations();
            await sapSupportedSkus();
            await sapSizingRecommendations();
        }

        private async Task sapAvailabilityZoneDetails()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            Response<SapAvailabilityZoneDetailsResult> response =
                await subscription.GetAvailabilityZoneDetailsSapVirtualInstanceAsync(
                    AzureLocation.EastUS2,
                    new SapAvailabilityZoneDetailsContent(
                        AzureLocation.EastUS2, SapProductType.S4HANA, SapDatabaseType.HANA));
            Assert.NotNull(response);
            Console.WriteLine("Sap Availability Zone Details Response : " + getObjectAsString(response.Value));
        }

        private async Task sapDiskConfigurations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            Response<SapDiskConfigurationsResult> response =
                await subscription.GetDiskConfigurationsSapVirtualInstanceAsync(
                    AzureLocation.EastUS2,
                    new SapDiskConfigurationsContent(
                        AzureLocation.EastUS2,
                        SapEnvironmentType.NonProd,
                        SapProductType.S4HANA,
                        SapDatabaseType.HANA,
                        SapDeploymentType.ThreeTier,
                        "Standard_M32ts"));
            Assert.NotNull(response);
            Console.WriteLine("sap Disk Configurations Response : " + getObjectAsString(response.Value));
        }

        private async Task sapSupportedSkus()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            SapSupportedSkusContent request = new SapSupportedSkusContent(
                AzureLocation.EastUS2,
                SapEnvironmentType.Prod,
                SapProductType.S4HANA,
                SapDeploymentType.ThreeTier,
                SapDatabaseType.HANA);
            request.HighAvailabilityType = "AvailabilitySet";
            Response<SapSupportedResourceSkusResult> response =
                await subscription.GetSapSupportedSkuSapVirtualInstanceAsync(
                    AzureLocation.EastUS2,
                    request);
            Assert.NotNull(response);
            Console.WriteLine("sap Supported Skus Response : " + getObjectAsString(response.Value));
        }

        private async Task sapSizingRecommendations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            var request = new SapSizingRecommendationContent(
                AzureLocation.EastUS2,
                SapEnvironmentType.Prod,
                SapProductType.S4HANA,
                SapDeploymentType.ThreeTier,
                23622,
                1024,
                SapDatabaseType.HANA);
            request.DbScaleMethod = "ScaleUp";
            request.HighAvailabilityType = "AvailabilitySet";
            Response<SapSizingRecommendationResult> response =
                await subscription.GetSizingRecommendationsSapVirtualInstanceAsync(
                    AzureLocation.EastUS2,
                    request);
            Assert.NotNull(response);
            Console.WriteLine("sap Sizing Recommendations Response : " + getObjectAsString(response.Value));
        }
    }
}
