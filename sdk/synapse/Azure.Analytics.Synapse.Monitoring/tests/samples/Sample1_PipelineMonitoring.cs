// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Core.TestFramework;
using Azure.Analytics.Synapse.Tests;
using Azure.Analytics.Synapse.Monitoring;
using Azure.Analytics.Synapse.Monitoring.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Monitoring.Samples
{
    /// <summary>
    /// This sample demonstrates how to monitor pipeline runs using synchronous methods of <see cref="MonitoringClient"/>.
    /// </summary>
    public partial class Sample1_PipelineMonitoring : SamplesBase<SynapseTestEnvironment>
    {
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18832 - Fails on nightly lane due to unreproducable NRE")]
        [Test]
        public void MonitorPipelineRuns()
        {
            #region Snippet:CreateMonitoringClient
            string endpoint = TestEnvironment.EndpointUrl;
            MonitoringClient client = new MonitoringClient(endpoint, new DefaultAzureCredential());
            #endregion

            #region Snippet:GetSparkJobList
            SparkJobListViewResponse sparkJobList = client.GetSparkJobList();
            foreach (var sparkJob in sparkJobList.SparkJobs)
            {
                if (sparkJob.State == "Running")
                {
                    Console.WriteLine ($"{sparkJob.Name} has been running for {sparkJob.RunningDuration}");
                }
                else
                {
                    Console.WriteLine ($"{sparkJob.Name} has been in {sparkJob.State} for {sparkJob.QueuedDuration}");
                }
            }
            #endregion

            #region Snippet:GetSqlJobQueryString
            SqlQueryStringDataModel sqlQuery = client.GetSqlJobQueryString();
            #endregion
        }
    }
}
