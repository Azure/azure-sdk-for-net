﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
#if !SNIPPET
            // create a client
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateRouterWorker_Async

            var routerWorkerId = "my-router-worker";

            var worker = await routerClient.CreateWorkerAsync(
                id: routerWorkerId,
                totalCapacity: 100,
                new CreateWorkerOptions() // this is optional
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
                    Labels = new LabelCollection()
                    {
                        ["Location"] = new LabelValue("NA"),
                        ["English"] = new LabelValue(7),
                        ["O365"] = new LabelValue(true),
                        ["Xbox_Support"] = new LabelValue(false)
                    },
                    Tags = new LabelCollection()
                    {
                        ["Name"] = new LabelValue("John Doe"),
                        ["Department"] = new LabelValue("IT_HelpDesk")
                    }
                }
            );

            Console.WriteLine($"Router worker successfully created with id: {worker.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateRouterWorker_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorker_Async

            var queriedWorker = await routerClient.GetWorkerAsync(routerWorkerId);

            Console.WriteLine($"Successfully fetched worker with id: {queriedWorker.Value.Id}");
            Console.WriteLine($"Worker associated with queues: {queriedWorker.Value.QueueAssignments.Values.ToList()}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorker_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateRouterWorker_Async

            // we are going to
            // 1. Assign the worker to another queue
            // 2. Modify an value of label: `O365`
            // 3. Delete label: `Xbox_Support`
            // 4. Add a new label: `Xbox_Support_EN` and set value true
            // 5. Increase capacityCostPerJob for channel `WebChatEscalated` to 50

            var updateWorker = await routerClient.UpdateWorkerAsync(
                routerWorkerId,
                new UpdateWorkerOptions()
                {
                    QueueIds = new Dictionary<string, QueueAssignment?>()
                    {
                        ["worker-q-3"] = new QueueAssignment()
                    },
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
                    {
                        ["WebChatEscalated"] = new ChannelConfiguration(50),
                    },
                    Labels = new LabelCollection()
                    {
                        ["O365"] = new LabelValue("Supported"),
                        ["Xbox_Support"] = null,
                        ["Xbox_Support_EN"] = new LabelValue(true),
                    }
                });

            Console.WriteLine($"Worker successfully updated with id: {updateWorker.Value.Id}");
            Console.Write($"Worker now associated with {updateWorker.Value.QueueAssignments.Count} queues"); // 3 queues

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateRouterWorker_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_RegisterRouterWorker_Async

            updateWorker = await routerClient.UpdateWorkerAsync(
                id: routerWorkerId,
                options: new UpdateWorkerOptions() { AvailableForOffers = true, });

            Console.WriteLine($"Worker successfully registered with status set to: {updateWorker.Value.State}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_RegisterRouterWorker_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeregisterRouterWorker_Async

            updateWorker = await routerClient.UpdateWorkerAsync(
                id: routerWorkerId,
                options: new UpdateWorkerOptions() { AvailableForOffers = false, });

            Console.WriteLine($"Worker successfully de-registered with status set to: {updateWorker.Value.State}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeregisterRouterWorker_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorkers_Async

            var workers = routerClient.GetWorkersAsync();
            await foreach (var asPage in workers.AsPages(pageSizeHint: 10))
            {
                foreach (var workerPaged in asPage.Values)
                {
                    Console.WriteLine($"Listing exception policy with id: {workerPaged.Id}");
                }
            }

            // Additionally workers can be queried with several filters like queueId, capacity, state etc.
            workers = routerClient.GetWorkersAsync(new GetWorkersOptions()
            {
                ChannelId = "Voip", Status = WorkerStateSelector.All
            });

            await foreach (var asPage in workers.AsPages(pageSizeHint: 10))
            {
                foreach (var workerPaged in asPage.Values)
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
