// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Tests.ManagedPrivateEndpoints
{
    /// <summary>
    /// The suite of tests for the <see cref="ManagedPrivateEndpointsClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class ManagedPrivateEndpointsClientLiveTests : ManagedPrivateEndpointsClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedPrivateEndpointsClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public ManagedPrivateEndpointsClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        //[Test]
        //public async Task TestListSparkApplications()
        //{
        //    SparkJobListViewResponse sparkJobList = await MonitoringClient.GetSparkJobListAsync();
        //    Assert.NotNull(sparkJobList);
        //    CollectionAssert.IsNotEmpty(sparkJobList.SparkJobs);
        //}

        //[Test]
        //public async Task TestSqlQuery()
        //{
        //    SqlQueryStringDataModel sqlQuery = await MonitoringClient.GetSqlJobQueryStringAsync();
        //    Assert.NotNull(sqlQuery);
        //    Assert.IsNotNull(sqlQuery.Query);
        //}
    }
}
