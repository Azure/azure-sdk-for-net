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
#pragma warning disable IDE1006 // Naming Styles
        private MonitoringClient client;
#pragma warning restore IDE1006 // Naming Styles

        [OneTimeSetUp]
        public void CreateClient()
        {
            // Environment variable with the Synapse workspace endpoint.
            string workspaceUrl = TestEnvironment.WorkspaceUrl;

            #region Snippet:CreateMonitoringClient
            // Create a new monitoring client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            MonitoringClient client = new MonitoringClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());
            #endregion

            this.client = client;
        }

        [Test]
        public void GetSparkJobList()
        {
            #region Snippet:GetSparkJobList
            SparkJobListViewResponse sparkJobList = client.GetSparkJobList();
            #endregion
        }

        [Test]
        public void GetSqlJobQueryString()
        {
            #region Snippet:GetSqlJobQueryString
            SqlQueryStringDataModel sqlQuery = client.GetSqlJobQueryString();
            #endregion
        }
    }
}
