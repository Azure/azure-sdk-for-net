// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace PolicyInsights.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.PolicyInsights;
    using Microsoft.Azure.Management.PolicyInsights.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class PolicyMetadataTests : TestBase
    {
        #region Test setup

        private static string PolicyMetadataName = "ACF1041";
        private static string PolicyMetadataId = "Microsoft Managed Control 1041";
        private static string PolicyMetadataCategory = "Access Control";
        private static string PolicyMetadataTitle = "Least Privilege | Privilege Levels For Code Execution";
        private static string PolicyMetadataOwner = "Microsoft Azure Security, Service Engineer Operations, Program Manager";
        private static string PolicyMetadataDescription = "The information system prevents any software except software explicitly documented from executing at higher privilege levels than users executing the software.";
        private static string PolicyMetadataRequirements = "Software execution at a higher privilege level than users executing the software is not applicable for servers and network devices. Microsoft Azure only permits administrator access to server who by default have code execution privileges. Access to tools are only accessible by Microsoft Azure administrators; therefore, no read-only access is provided. These administrators have full access to the system, preventing users being indirectly provided greater privileges than assigned by Microsoft.";
        private static string PolicyMetadataAdditionalContentUrl = string.Empty;

        #endregion

        #region Validation

        private void ValidateCollection(List<SlimPolicyMetadata> policyMetadata)
        {
            // Check that there are no duplicates
            Assert.Equal(policyMetadata.Count, policyMetadata.Select(m => m.Name).Distinct(comparer: StringComparer.OrdinalIgnoreCase).Count());

            // Check that all resources have id and type
            Assert.True(policyMetadata.All(m => m.Id.Equals($"/providers/Microsoft.PolicyInsights/policyMetadata/{m.Name}", StringComparison.OrdinalIgnoreCase)));
            Assert.True(policyMetadata.All(m => m.Type.Equals("Microsoft.PolicyInsights/policyMetadata")));

            var testMetadata = policyMetadata.FirstOrDefault(m => m.Name.Equals(PolicyMetadataTests.PolicyMetadataName));
            Assert.NotNull(testMetadata);
            Assert.Equal(PolicyMetadataTests.PolicyMetadataId, testMetadata.MetadataId);
            Assert.Equal(PolicyMetadataTests.PolicyMetadataCategory, testMetadata.Category);
            Assert.Equal(PolicyMetadataTests.PolicyMetadataTitle, testMetadata.Title);
            Assert.Equal(PolicyMetadataTests.PolicyMetadataOwner, testMetadata.Owner);
            Assert.Equal(PolicyMetadataTests.PolicyMetadataAdditionalContentUrl, testMetadata.AdditionalContentUrl);
        }

        #endregion

        #region Test

        [Fact]
        public void PolicyMetadataTest_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>();

                string nextPageLink = null;
                var results = new List<SlimPolicyMetadata>();
                do
                {
                    var response = nextPageLink == null ? policyInsightsClient.PolicyMetadata.ListAsync().Result : policyInsightsClient.PolicyMetadata.ListNextAsync(nextPageLink: nextPageLink).Result;
                    results.AddRange(response);
                    nextPageLink = response.NextPageLink;

                } while (nextPageLink != null);

                this.ValidateCollection(results);
            }
        }

        [Fact]
        public void PolicyMetadataTest_List_Top()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>();
                var response = policyInsightsClient.PolicyMetadata.ListAsync(queryOptions: new QueryOptions(top: 1)).Result;
                Assert.Single(response);
            }
        }

        [Fact]
        public void PolicyMetadataTest_GetResource()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>();
                var response = policyInsightsClient.PolicyMetadata.GetResourceAsync(resourceName: PolicyMetadataTests.PolicyMetadataName).Result;

                Assert.NotNull(response);
                Assert.Equal(PolicyMetadataTests.PolicyMetadataName, response.Name);
                Assert.Equal($"/providers/Microsoft.PolicyInsights/policyMetadata/{response.Name}", response.Id);
                Assert.Equal($"Microsoft.PolicyInsights/policyMetadata", response.Type);
                Assert.Equal(PolicyMetadataTests.PolicyMetadataId, response.MetadataId);
                Assert.Equal(PolicyMetadataTests.PolicyMetadataCategory, response.Category);
                Assert.Equal(PolicyMetadataTests.PolicyMetadataTitle, response.Title);
                Assert.Equal(PolicyMetadataTests.PolicyMetadataOwner, response.Owner);
                Assert.Equal(PolicyMetadataTests.PolicyMetadataDescription, response.Description);
                Assert.Equal(PolicyMetadataTests.PolicyMetadataRequirements, response.Requirements);
                Assert.Equal(PolicyMetadataTests.PolicyMetadataAdditionalContentUrl, response.AdditionalContentUrl);
            }
        }
        #endregion
    }
}
