// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class RouterWorkerCrudOpsAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task RouterWorkerCrud()
        {
            // create a client
            JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateRouterWorker_Async

            string routerWorkerId = "my-router-worker";

            Response<RouterWorker> worker = await routerClient.CreateWorkerAsync(
                new CreateWorkerOptions(
                    workerId: routerWorkerId,
                    capacity: 100)
                {
                    Queues = { "worker-q-1", "worker-q-2" },
                    Channels =
                    {
                        new RouterChannel("WebChat", 1),
                        new RouterChannel("WebChatEscalated", 20),
                        new RouterChannel("Voip",100)
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

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateRouterWorker_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorker_Async

            Response<RouterWorker> queriedWorker = await routerClient.GetWorkerAsync(routerWorkerId);

            Console.WriteLine($"Successfully fetched worker with id: {queriedWorker.Value.Id}");
            Console.WriteLine($"Worker associated with queues: {queriedWorker.Value.Queues}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorker_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateRouterWorker_Async

            // we are going to
            // 1. Assign the worker to another queue
            // 2. Modify an value of label: `O365`
            // 3. Delete label: `Xbox_Support`
            // 4. Add a new label: `Xbox_Support_EN` and set value true
            // 5. Increase capacityCostPerJob for channel `WebChatEscalated` to 50

            Response<RouterWorker> updateWorker = await routerClient.UpdateWorkerAsync(
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

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateRouterWorker_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_RegisterRouterWorker_Async

            updateWorker = await routerClient.UpdateWorkerAsync(new RouterWorker(routerWorkerId) { AvailableForOffers = true, });

            Console.WriteLine($"Worker successfully registered with status set to: {updateWorker.Value.State}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_RegisterRouterWorker_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeregisterRouterWorker_Async

            updateWorker = await routerClient.UpdateWorkerAsync(new RouterWorker(routerWorkerId) { AvailableForOffers = false, });

            Console.WriteLine($"Worker successfully de-registered with status set to: {updateWorker.Value.State}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeregisterRouterWorker_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorkers_Async

            AsyncPageable<RouterWorker> workers = routerClient.GetWorkersAsync(null, null);
            await foreach (Page<RouterWorker> asPage in workers.AsPages(pageSizeHint: 10))
            {
                foreach (RouterWorker? workerPaged in asPage.Values)
                {
                    Console.WriteLine($"Listing exception policy with id: {workerPaged.Id}");
                }
            }

            // Additionally workers can be queried with several filters like queueId, capacity, state etc.
            workers = routerClient.GetWorkersAsync(channelId: "Voip", state: RouterWorkerStateSelector.All, queueId: null, hasCapacity: null, cancellationToken: default);

            await foreach (Page<RouterWorker> asPage in workers.AsPages(pageSizeHint: 10))
            {
                foreach (RouterWorker? workerPaged in asPage.Values)
                {
                    Console.WriteLine($"Listing exception policy with id: {workerPaged.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorkers_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteRouterWorker_Async

            _ = await routerClient.DeleteWorkerAsync(routerWorkerId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteRouterWorker_Async
        }
    }
}
