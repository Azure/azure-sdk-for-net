// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Management.HDInsight.Tests
{
    public class LocationOperationTests : HDInsightManagementTestBase
    {
        protected override void CreateResources()
        {
        }

        [Fact]
        public void TestGetUsages()
        {
            TestInitialize();

            var usages = HDInsightClient.Locations.ListUsages(CommonData.Location);
            Assert.NotNull(usages);
            Assert.NotNull(usages.Value);
            foreach (var usage in usages.Value)
            {
                Assert.NotNull(usage);
                Assert.NotNull(usage.CurrentValue);
                Assert.NotNull(usage.Limit);
                Assert.NotNull(usage.Name);
                Assert.NotNull(usage.Unit);
            }
        }

        [Fact]
        public void TestGetCapabilities()
        {
            TestInitialize();

            var capabilitiesResult = HDInsightClient.Locations.GetCapabilities(CommonData.Location);
            Assert.NotNull(capabilitiesResult);
            Assert.NotNull(capabilitiesResult.Features);
            Assert.NotNull(capabilitiesResult.Quota);
            Assert.NotNull(capabilitiesResult.Regions);
            Assert.NotNull(capabilitiesResult.Versions);

            foreach (var feature in capabilitiesResult.Features)
            {
                Assert.NotNull(feature);
            }

            foreach (var regionQuota in capabilitiesResult.Quota.RegionalQuotas)
            {
                Assert.NotNull(regionQuota);
            }

            foreach (var region in capabilitiesResult.Regions.Keys)
            {
                Assert.NotNull(capabilitiesResult.Regions[region]);
            }

            foreach (var platform in capabilitiesResult.Versions.Keys)
            {
                Assert.NotNull(capabilitiesResult.Versions[platform]);
            }
        }

        [Fact]
        public void TestCheckNameAvailability()
        {
            TestInitialize();
            var checkNameAvailabilityParameter = new NameAvailabilityCheckRequestParameters()
            {
                Name = "testclustername",
                Type = "clusters"
            };
            var result = HDInsightClient.Locations.CheckNameAvailability(CommonData.Location, checkNameAvailabilityParameter);

            Assert.True(result.NameAvailable);
        }

        [Fact]
        public void TestValidateClusterCreateRequest()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-humboldt");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            ClusterCreateRequestValidationParameters createRequestValidationParameter = new ClusterCreateRequestValidationParameters
            {
                Name = clusterName,
                Type = "clusters",
                Location = createParams.Location,
                Identity = createParams.Identity,
                Properties = createParams.Properties,
                Tags = createParams.Tags
            };

            /*
              The LocationOperationTests overrides the method CreatedResource so there is not real storage account will be created.
              There should be validation errors.
              However now there is a bug in backend, backend returns 400 bad request when finding there are validation errors.
            */
            try
            {
                var result = HDInsightClient.Locations.ValidateClusterCreateRequest(CommonData.Location, createRequestValidationParameter);
            }
            catch(ErrorResponseException ex)
            {
                Assert.Equal(System.Net.HttpStatusCode.BadRequest, ex.Response.StatusCode);
            }
        }

        [Fact]
        public void TestListBillingSpecs()
        {
            TestInitialize();

            string location = "South Central US";
            var billingSpecsResult = HDInsightClient.Locations.ListBillingSpecs(location);
            Assert.NotNull(billingSpecsResult);
            Assert.NotNull(billingSpecsResult.BillingResources);
            Assert.NotNull(billingSpecsResult.VmSizes);
            Assert.NotNull(billingSpecsResult.VmSizeFilters);
            Assert.NotNull(billingSpecsResult.VmSizeProperties);
            Assert.NotNull(billingSpecsResult.VmSizesWithEncryptionAtHost);
        }
    }
}
