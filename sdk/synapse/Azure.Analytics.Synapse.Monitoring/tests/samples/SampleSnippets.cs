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
        //[Test] - https://github.com/Azure/azure-sdk-for-net/issues/17455
        public void MonitoringSample()
        {
            #region Snippet:CreateMonitoringClient
            // Replace the string below with your actual workspace url.
            string workspaceUrl = "<my-workspace-url>";
            /*@@*/workspaceUrl = TestEnvironment.WorkspaceUrl;
            MonitoringClient client = new MonitoringClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());
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
