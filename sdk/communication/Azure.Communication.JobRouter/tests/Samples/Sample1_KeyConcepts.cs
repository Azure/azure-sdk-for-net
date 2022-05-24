// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
using Azure.Communication.JobRouter.Models;
#endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class Sample1_KeyConcepts : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public void BasicScenario()
        {
            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient

            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D
            var distributionPolicy = routerClient.SetDistributionPolicy(
                id: "distribution-policy-1",
                name: "My Distribution Policy",
                offerTtlSeconds: 24 * 60 * 60,
                mode: new LongestIdleMode()
            );
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue
            var queue = routerClient.SetQueue(
                id: "queue-1",
                name: "My Queue",
                distributionPolicyId: distributionPolicy.Value.Id
            );
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign
            var job = routerClient.SetJob(
                id: "jobId-2",
                channelId: "my-channel",
                channelReference: "12345",
                queueId: queue.Value.Id,
                priority: 1,
                workerSelectors: new List<WorkerSelector>
                {
                    new WorkerSelector("Some-Skill", LabelOperator.GreaterThan, 10)
                });
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker
            var worker = routerClient.SetWorker(
                id: "worker-1",
                queueIds: new[] { queue.Value.Id },
                totalCapacity: 1,
                labels: new LabelCollection()
                {
                    ["Some-Skill"] = 11
                },
                channelConfigurations: new Dictionary<string, ChannelConfiguration>()
                {
                    ["my-channel"] = new ChannelConfiguration(1)
                },
                availableForOffers: true
            );
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker
            var result = routerClient.GetWorker(worker.Value.Id);
            foreach (var offer in result.Value.Offers)
            {
                Console.WriteLine($"Worker {worker.Value.Id} has an active offer for job {offer.JobId}");
            }
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker
        }
    }
}
