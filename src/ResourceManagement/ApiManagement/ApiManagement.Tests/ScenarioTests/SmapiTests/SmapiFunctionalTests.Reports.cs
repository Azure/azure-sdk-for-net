//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
namespace Microsoft.Azure.Management.ApiManagement.Tests.ScenarioTests.SmapiTests
{
    using System;
    using System.Xml;
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void ReportsQuery()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "ReportsQuery");

            try
            {
                var byApiResponse = ApiManagementClient.Reports.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    ReportsAggregation.ByApi,
                    new QueryParameters
                    {
                        Filter = "timestamp ge datetime'2015-05-18T00:00:00'"
                    },
                    null);

                Assert.NotNull(byApiResponse);
                Assert.NotNull(byApiResponse.Result);
                Assert.NotNull(byApiResponse.Result.Values);
                Assert.Equal(1, byApiResponse.Result.TotalCount);
                Assert.Equal(1, byApiResponse.Result.Values.Count);

                var byGeoResponse = ApiManagementClient.Reports.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    ReportsAggregation.ByGeo,
                    new QueryParameters
                    {
                        Filter = "timestamp ge datetime'2015-05-18T00:00:00'"
                    },
                    null);

                Assert.NotNull(byGeoResponse);
                Assert.NotNull(byGeoResponse.Result);
                Assert.NotNull(byGeoResponse.Result.Values);
                Assert.Equal(0, byGeoResponse.Result.TotalCount);
                Assert.Equal(0, byGeoResponse.Result.Values.Count);

                var byOperationResponse = ApiManagementClient.Reports.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    ReportsAggregation.ByOperation,
                    new QueryParameters
                    {
                        Filter = "timestamp ge datetime'2015-05-18T00:00:00'"
                    },
                    null);

                Assert.NotNull(byOperationResponse);
                Assert.NotNull(byOperationResponse.Result);
                Assert.NotNull(byOperationResponse.Result.Values);
                Assert.Equal(6, byOperationResponse.Result.TotalCount);
                Assert.Equal(6, byOperationResponse.Result.Values.Count);

                var byProductResponse = ApiManagementClient.Reports.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    ReportsAggregation.ByProduct,
                    new QueryParameters
                    {
                        Filter = "timestamp ge datetime'2015-05-18T00:00:00'"
                    },
                    null);

                Assert.NotNull(byProductResponse);
                Assert.NotNull(byProductResponse.Result);
                Assert.NotNull(byProductResponse.Result.Values);
                Assert.Equal(2, byProductResponse.Result.TotalCount);
                Assert.Equal(2, byProductResponse.Result.Values.Count);

                var bySubscriptionResponse = ApiManagementClient.Reports.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    ReportsAggregation.BySubscription,
                    new QueryParameters
                    {
                        Filter = "timestamp ge datetime'2015-05-18T00:00:00'"
                    },
                    null);

                Assert.NotNull(bySubscriptionResponse);
                Assert.NotNull(bySubscriptionResponse.Result);
                Assert.NotNull(bySubscriptionResponse.Result.Values);
                Assert.Equal(2, bySubscriptionResponse.Result.TotalCount);
                Assert.Equal(2, bySubscriptionResponse.Result.Values.Count);

                var byTimeResponse = ApiManagementClient.Reports.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    ReportsAggregation.ByTime,
                    new QueryParameters
                    {
                        Filter = "timestamp ge datetime'2015-05-18T00:00:00'"
                    },
                    XmlConvert.ToString(TimeSpan.FromMinutes(30)));

                Assert.NotNull(byTimeResponse);
                Assert.NotNull(byTimeResponse.Result);
                Assert.NotNull(byTimeResponse.Result.Values);
                Assert.Equal(0, byTimeResponse.Result.TotalCount);
                Assert.Equal(0, byTimeResponse.Result.Values.Count);

                var byUserResponse = ApiManagementClient.Reports.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    ReportsAggregation.ByUser,
                    new QueryParameters
                    {
                        Filter = "timestamp ge datetime'2015-05-18T00:00:00'"
                    },
                    null);

                Assert.NotNull(byUserResponse);
                Assert.NotNull(byUserResponse.Result);
                Assert.NotNull(byUserResponse.Result.Values);
                Assert.Equal(1, byUserResponse.Result.TotalCount); // TODO: this is a bug in API - should be 2
                Assert.Equal(2, byUserResponse.Result.Values.Count);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}