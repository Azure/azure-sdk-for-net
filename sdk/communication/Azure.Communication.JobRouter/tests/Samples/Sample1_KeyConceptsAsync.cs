// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements_Async
using Azure.Communication.JobRouter;
using Azure.Communication.JobRouter.Models;
#endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements_Async
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class Sample1_KeyConceptsAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task BasicScenario()
        {
            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient_Async

            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D_Async
            var distributionPolicy = await routerClient.SetDistributionPolicyAsync(
                id: "distribution-policy-1",
                name: "My Distribution Policy",
                offerTTL: TimeSpan.FromDays(1),
                mode: new LongestIdleMode()
            );
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateDistributionPolicyLongestIdleTTL1D_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue_Async
            var queue = await routerClient.SetQueueAsync(
                id: "queue-1",
                name: "My Queue",
                distributionPolicyId: distributionPolicy.Value.Id
            );
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateQueue_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign_Async
            var job = await routerClient.CreateJobAsync(
                channelId: "my-channel",
                channelReference: "12345",
                queueId: queue.Value.Id,
                priority: 1,
                workerSelectors: new List<LabelSelector>
                {
                    new LabelSelector("Some-Skill", LabelOperator.GreaterThan, 10)
                });
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateJobDirectQAssign_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker_Async
            var worker = await routerClient.RegisterWorkerAsync(
                id: "worker-1",
                queueIds: new[] { queue.Value.Id },
                totalCapacity: 1,
                labels: new LabelCollection()
                {
                    ["Some-Skill"] = 11
                },
                channelConfigurations: new List<ChannelConfiguration>
                {
                    new ChannelConfiguration("my-channel", 1)
                }
            );
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_RegisterWorker_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker_Async
            var result = await routerClient.GetWorkerAsync(worker.Value.Id);
            foreach (var offer in result.Value.Offers)
            {
                Console.WriteLine($"Worker {worker.Value.Id} has an active offer for job {offer.JobId}");
            }
            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker_Async
        }
    }
}
