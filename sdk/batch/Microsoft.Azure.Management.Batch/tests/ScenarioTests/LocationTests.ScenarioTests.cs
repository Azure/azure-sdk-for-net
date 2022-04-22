// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Batch.Tests.ScenarioTests
{
    public class LocationTests : BatchScenarioTestBase
    {
        [Fact]
        public async Task GetLocationQuotasAsync()
        {
            using (MockContext context = StartMockContextAndInitializeClients(GetType()))
            {
                BatchLocationQuota quotas = await BatchManagementClient.Location.GetQuotasAsync(Location);

                Assert.NotNull(quotas.AccountQuota);
                Assert.True(quotas.AccountQuota.Value > 0);
            }
        }

        [Fact]
        public async Task ListSupportedCloudServiceSkusAsync()
        {
            using (MockContext context = StartMockContextAndInitializeClients(GetType()))
            {
                IPage<SupportedSku> result;

                List<SupportedSku> skus = new List<SupportedSku>();
                string nextPageLink = null;
                do
                {
                    result = await BatchManagementClient.Location.ListSupportedCloudServiceSkusAsync(Location);
                    skus.AddRange(result.ToList());
                    nextPageLink = result.NextPageLink;
                }
                while (nextPageLink != null);

                Assert.True(skus.Count() > 0);
            }
        }

        [Fact]
        public async Task ListSupportedCloudServiceSkusMaxResultsAsync()
        {
            using (MockContext context = StartMockContextAndInitializeClients(GetType()))
            {
                int maxresult = 5;
                IPage<SupportedSku> result = await BatchManagementClient.Location.ListSupportedCloudServiceSkusAsync(Location, maxresults: maxresult);

                int count = result.Count();
                Assert.True(count == maxresult);
            }
        }

        [Fact]
        public async Task ListSupportedCloudServiceSkusFilterFamilyNameAsync()
        {
            using (MockContext context = StartMockContextAndInitializeClients(GetType()))
            {
                string filterValue = "standardD";
                string filterExpression = $"startswith(familyName,'{filterValue}')"; // Select family names beginning with 'basic'.
                IPage<SupportedSku> result;

                List<SupportedSku> skus = new List<SupportedSku>();
                string nextPageLink = null;
                do
                {
                    result = await BatchManagementClient.Location.ListSupportedCloudServiceSkusAsync(Location, filter: filterExpression);
                    skus.AddRange(result.ToList());
                    nextPageLink = result.NextPageLink;
                }
                while (nextPageLink != null);

                var matched = skus.Where(s => s.FamilyName.StartsWith(filterValue));
                var unmatched = skus.Where(s => s.FamilyName.StartsWith(filterValue) == false);
                Assert.True(matched.Count() > 0);
                Assert.True(unmatched.Count() == 0);
            }
        }
    }
}
