// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class ReportTests : TestBase
    {
        [Fact]
        public async Task Query()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();
                
                var byApiResponse = testBase.client.Reports.ListByApi(
                    new Microsoft.Rest.Azure.OData.ODataQuery<ReportRecordContract>
                    {
                        Filter = "timestamp ge datetime'2017-06-22T00:00:00'"
                    },
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(byApiResponse);
                Assert.Equal(1, byApiResponse.Count());
                Assert.NotNull(byApiResponse.First().ApiId);

                var byGeoResponse = testBase.client.Reports.ListByGeo(
                    testBase.rgName,
                    testBase.serviceName,
                    new Microsoft.Rest.Azure.OData.ODataQuery<ReportRecordContract>
                    {
                        Filter = "timestamp ge datetime'2017-06-22T00:00:00'"
                    });

                Assert.NotNull(byGeoResponse);
                Assert.Equal(0, byGeoResponse.Count());                

                var byOperationResponse = testBase.client.Reports.ListByOperation(
                    new Microsoft.Rest.Azure.OData.ODataQuery<ReportRecordContract>
                    {
                        Filter = "timestamp ge datetime'2017-06-22T00:00:00'"
                    },
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(byOperationResponse);
                Assert.Equal(6, byOperationResponse.Count());

                var byProductResponse = testBase.client.Reports.ListByProduct(
                    new Microsoft.Rest.Azure.OData.ODataQuery<ReportRecordContract>
                    {
                        Filter = "timestamp ge datetime'2017-06-22T00:00:00'"
                    },
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(byProductResponse);
                Assert.Equal(2, byProductResponse.Count());
                Assert.NotNull(byProductResponse.First().ProductId);

                var bySubscriptionResponse = testBase.client.Reports.ListBySubscription(
                    testBase.rgName,
                    testBase.serviceName,
                    new Microsoft.Rest.Azure.OData.ODataQuery<ReportRecordContract>
                    {
                        Filter = "timestamp ge datetime'2017-06-22T00:00:00'"
                    });

                Assert.NotNull(bySubscriptionResponse);
                Assert.Equal(2, bySubscriptionResponse.Count());
                Assert.NotNull(bySubscriptionResponse.First().SubscriptionId);

                var byTimeResponse = testBase.client.Reports.ListByTime(
                    testBase.rgName,
                    testBase.serviceName,
                    TimeSpan.FromMinutes(30),
                    new Microsoft.Rest.Azure.OData.ODataQuery<ReportRecordContract>
                    {
                        Filter = "timestamp ge datetime'2017-06-22T00:00:00'"
                    });

                Assert.NotNull(byTimeResponse);
                Assert.Equal(0, byTimeResponse.Count());

                var byUserResponse = testBase.client.Reports.ListByUser(
                    new Microsoft.Rest.Azure.OData.ODataQuery<ReportRecordContract>()
                    {
                        Filter = "timestamp ge datetime'2017-06-22T00:00:00'"
                    },
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(byUserResponse);
                Assert.Equal(2, byUserResponse.Count());
                Assert.NotNull(byUserResponse.First().UserId);

                var byRequestResponse = testBase.client.Reports.ListByRequest(
                    new Microsoft.Rest.Azure.OData.ODataQuery<RequestReportRecordContract>
                    {
                        Filter = "timestamp ge datetime'2017-06-22T00:00:00'"
                    },
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(byRequestResponse);
                Assert.Equal(2, byRequestResponse.Count());
                Assert.NotNull(byRequestResponse.First().RequestId);
            }
        }
    }
}
