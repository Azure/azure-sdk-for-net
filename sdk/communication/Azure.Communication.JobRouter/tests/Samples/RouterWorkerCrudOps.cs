// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
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
            RouterClient routerClient = new RouterClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateRouterWorker

            string routerWorkerId = "my-router-worker";

            Response<RouterWorker> worker = routerClient.CreateWorker(
                new CreateWorkerOptions(
                        workerId: routerWorkerId,
                        totalCapacity: 100)
                {
                    QueueIds = new Dictionary<string, QueueAssignment>()
                    {
                        ["worker-q-1"] = new QueueAssignment(),
                        ["worker-q-2"] = new QueueAssignment()
                    },
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
                    {
                        ["WebChat"] = new ChannelConfiguration(1),
                        ["WebChatEscalated"] = new ChannelConfiguration(20),
                        ["Voip"] = new ChannelConfiguration(100)
                    },
                    Labels = new Dictionary<string, LabelValue>()
                    {
                        ["Location"] = new LabelValue("NA"),
                        ["English"] = new LabelValue(7),
                        ["O365"] = new LabelValue(true),
                        ["Xbox_Support"] = new LabelValue(false)
                    },
                    Tags = new Dictionary<string, LabelValue>()
                    {
                        ["Name"] = new LabelValue("John Doe"),
                        ["Department"] = new LabelValue("IT_HelpDesk")
                    }
                }
            );

            Console.WriteLine($"Router worker successfully created with id: {worker.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateRouterWorker

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorker

            Response<RouterWorker> queriedWorker = routerClient.GetWorker(routerWorkerId);

            Console.WriteLine($"Successfully fetched worker with id: {queriedWorker.Value.Id}");
            Console.WriteLine($"Worker associated with queues: {queriedWorker.Value.QueueAssignments.Values.ToList()}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorker

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateRouterWorker

            // we are going to
            // 1. Assign the worker to another queue
            // 2. Modify an value of label: `O365`
            // 3. Delete label: `Xbox_Support`
            // 4. Add a new label: `Xbox_Support_EN` and set value true
            // 5. Increase capacityCostPerJob for channel `WebChatEscalated` to 50

            Response<RouterWorker> updateWorker = routerClient.UpdateWorker(
                new UpdateWorkerOptions(routerWorkerId)
                {
                    QueueIds = new Dictionary<string, QueueAssignment?>()
                    {
                        ["worker-q-3"] = new QueueAssignment()
                    },
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration?>()
                    {
                        ["WebChatEscalated"] = new ChannelConfiguration(50),
                    },
                    Labels = new Dictionary<string, LabelValue>()
                    {
                        ["O365"] = new LabelValue("Supported"),
                        ["Xbox_Support"] = new LabelValue(null),
                        ["Xbox_Support_EN"] = new LabelValue(true),
                    }
                });

            Console.WriteLine($"Worker successfully updated with id: {updateWorker.Value.Id}");
            Console.Write($"Worker now associated with {updateWorker.Value.QueueAssignments.Count} queues"); // 3 queues

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateRouterWorker

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_RegisterRouterWorker

            updateWorker = routerClient.UpdateWorker(
                options: new UpdateWorkerOptions(workerId: routerWorkerId) { AvailableForOffers = true, });

            Console.WriteLine($"Worker successfully registered with status set to: {updateWorker.Value.State}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_RegisterRouterWorker

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeregisterRouterWorker

            updateWorker = routerClient.UpdateWorker(
                options: new UpdateWorkerOptions(workerId: routerWorkerId) { AvailableForOffers = false, });

            Console.WriteLine($"Worker successfully de-registered with status set to: {updateWorker.Value.State}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeregisterRouterWorker

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorkers

            Pageable<RouterWorkerItem> workers = routerClient.GetWorkers();
            foreach (Page<RouterWorkerItem> asPage in workers.AsPages(pageSizeHint: 10))
            {
                foreach (RouterWorkerItem? workerPaged in asPage.Values)
                {
                    Console.WriteLine($"Listing exception policy with id: {workerPaged.RouterWorker.Id}");
                }
            }

            // Additionally workers can be queried with several filters like queueId, capacity, state etc.
            workers = routerClient.GetWorkers(new GetWorkersOptions()
            {
                ChannelId = "Voip", Status = WorkerStateSelector.All
            });

            foreach (Page<RouterWorkerItem> asPage in workers.AsPages(pageSizeHint: 10))
            {
                foreach (RouterWorkerItem? workerPaged in asPage.Values)
                {
                    Console.WriteLine($"Listing exception policy with id: {workerPaged.RouterWorker.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorkers

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteRouterWorker

            _ = routerClient.DeleteWorker(routerWorkerId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteRouterWorker
        }
    }
}
