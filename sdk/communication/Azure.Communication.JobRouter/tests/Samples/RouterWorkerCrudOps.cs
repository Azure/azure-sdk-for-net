// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class RouterWorkerCrudOps : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public void RouterWorkerCrud()
        {
            // create a client
            JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
            JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");
            // Create a distribution policy
            string distributionPolicyId = "distribution-policy";
            var createDistributionPolicyOptions = new CreateDistributionPolicyOptions(distributionPolicyId, TimeSpan.FromMinutes(5), new LongestIdleMode());
            Response<DistributionPolicy> distributionPolicy = routerAdministrationClient.CreateDistributionPolicy(createDistributionPolicyOptions);
            Console.WriteLine($"Distribution policy created with id: {distributionPolicy.Value.Id}");

            // Create queues
            string[] queueIds = { "worker-q-1", "worker-q-2", "worker-q-3" };
            foreach (string queueId in queueIds)
            {
                CreateQueueOptions createQueueOptions = new CreateQueueOptions(queueId, distributionPolicyId);
                Response<RouterQueue> queue = routerAdministrationClient.CreateQueue(createQueueOptions);
                Console.WriteLine($"Queue created with id: {queue.Value.Id}");
            }
            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateRouterWorker

            string routerWorkerId = "my-router-worker";

            Response<RouterWorker> worker = routerClient.CreateWorker(
                new CreateWorkerOptions(workerId: routerWorkerId, capacity: 100)
                {
                    Queues = { "worker-q-1", "worker-q-2" },
                    Channels =
                    {
                        new RouterChannel("WebChat", 1),
                        new RouterChannel("WebChatEscalated", 20),
                        new RouterChannel("Voip", 100)
                    },
                    Labels =
                    {
                        ["Location"] = new RouterValue("NA"),
                        ["English"] = new RouterValue(7),
                        ["O365"] = new RouterValue(true),
                        ["Xbox_Support"] = new RouterValue(false)
                    },
                    Tags =
                    {
                        ["Name"] = new RouterValue("John Doe"),
                        ["Department"] = new RouterValue("IT_HelpDesk")
                    }
                }
            );

            Console.WriteLine($"Router worker successfully created with id: {worker.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateRouterWorker

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorker

            Response<RouterWorker> queriedWorker = routerClient.GetWorker(routerWorkerId);

            Console.WriteLine($"Successfully fetched worker with id: {queriedWorker.Value.Id}");
            Console.WriteLine($"Worker associated with queues: {queriedWorker.Value.Queues}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorker

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateRouterWorker

            // we are going to
            // 1. Assign the worker to another queue
            // 2. Modify an value of label: `O365`
            // 3. Delete label: `Xbox_Support`
            // 4. Add a new label: `Xbox_Support_EN` and set value true
            // 5. Increase capacityCostPerJob for channel `WebChatEscalated` to 50

            Response<RouterWorker> updateWorker = routerClient.UpdateWorker(
                new RouterWorker(routerWorkerId)
                {
                    Queues = { "worker-q-3", },
                    Channels = { new RouterChannel("WebChatEscalated", 50), },
                    Labels =
                    {
                        ["O365"] = new RouterValue("Supported"),
                        ["Xbox_Support"] = new RouterValue(null),
                        ["Xbox_Support_EN"] = new RouterValue(true),
                    }
                });

            Console.WriteLine($"Worker successfully updated with id: {updateWorker.Value.Id}");
            Console.Write($"Worker now associated with {updateWorker.Value.Queues.Count} queues"); // 3 queues

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateRouterWorker

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_RegisterRouterWorker

            updateWorker = routerClient.UpdateWorker(new RouterWorker(routerWorkerId) { AvailableForOffers = true, });

            Console.WriteLine($"Worker successfully registered with status set to: {updateWorker.Value.State}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_RegisterRouterWorker

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeregisterRouterWorker

            updateWorker = routerClient.UpdateWorker(new RouterWorker(routerWorkerId) { AvailableForOffers = false, });

            Console.WriteLine($"Worker successfully de-registered with status set to: {updateWorker.Value.State}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeregisterRouterWorker

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorkers

            Pageable<RouterWorker> workers = routerClient.GetWorkers(null, null);
            foreach (Page<RouterWorker> asPage in workers.AsPages(pageSizeHint: 10))
            {
                foreach (RouterWorker? workerPaged in asPage.Values)
                {
                    Console.WriteLine($"Listing exception policy with id: {workerPaged.Id}");
                }
            }

            // Additionally workers can be queried with several filters like queueId, capacity, state etc.
            workers = routerClient.GetWorkers(null, channelId: "Voip", state: RouterWorkerStateSelector.All);

            foreach (Page<RouterWorker> asPage in workers.AsPages(pageSizeHint: 10))
            {
                foreach (RouterWorker? workerPaged in asPage.Values)
                {
                    Console.WriteLine($"Listing exception policy with id: {workerPaged.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorkers

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteRouterWorker

            _ = routerClient.DeleteWorker(routerWorkerId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteRouterWorker
        }
    }
}
