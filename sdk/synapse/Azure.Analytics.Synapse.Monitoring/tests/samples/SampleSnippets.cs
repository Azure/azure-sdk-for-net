// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Analytics.Synapse.Monitoring.Models;
using Azure.Analytics.Synapse.Samples;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Monitoring.Samples
{
    public partial class Snippets : SampleFixture
    {
        [Test]
        public void MonitoringSample()
        {
            #region Snippet:CreateMonitoringClient
            // Replace the string below with your actual endpoint url.
            string endpoint = "<my-endpoint-url>";
            /*@@*/endpoint = TestEnvironment.EndpointUrl;
            MonitoringClient client = new MonitoringClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:GetSparkJobList
            SparkJobListViewResponse sparkJobList = client.GetSparkJobList();
            #endregion

            #region Snippet:GetSqlJobQueryString
            SqlQueryStringDataModel sqlQuery = client.GetSqlJobQueryString();
            #endregion
        }
    }
}
