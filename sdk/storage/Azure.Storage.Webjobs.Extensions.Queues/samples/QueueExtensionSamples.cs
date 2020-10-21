// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.WebJobs.Extensions.Storage.Blobs.Samples.Tests
{
    public class BlobExtensionSamples
    {
        [TestCase(typeof(QueueTriggerFunction_String), "sample message")]
        public async Task Run_QueueFunction(Type programType, string message)
        {
            var queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient();
            await queueServiceClient.GetQueueClient("sample-queue").CreateIfNotExistsAsync();
            await queueServiceClient.GetQueueClient("sample-queue").SendMessageAsync(message);
            await queueServiceClient.GetQueueClient("sample-queue-1").CreateIfNotExistsAsync();
            await queueServiceClient.GetQueueClient("sample-queue-1").SendMessageAsync(message);
            await queueServiceClient.GetQueueClient("sample-queue-2").CreateIfNotExistsAsync();
            await RunTrigger(programType);
        }

        private async Task RunTrigger(Type programType)
        {
            await FunctionalTest.RunTriggerAsync(b => {
                b.Services.AddAzureClients(builder =>
                {
                    builder.ConfigureDefaults(options => options.Transport = AzuriteNUnitFixture.Instance.GetTransport());
                });
                b.AddAzureStorageQueues();
            }, programType,
            settings: new Dictionary<string, string>() {
                // This takes precedence over env variables.
                { "ConnectionStrings:AzureWebJobsStorage", AzuriteNUnitFixture.Instance.GetAzureAccount().ConnectionString }
            });
        }
    }

    #region Snippet:QueueTriggerFunction_String
    public static class QueueTriggerFunction_String
    {
        [FunctionName("QueueTriggerFunction")]
        public static void Run(
            [QueueTrigger("sample-queue")] string message,
            ILogger logger)
        {
            logger.LogInformation("Received message from sample-queue, content={content}", message);
        }
    }
    #endregion
}
