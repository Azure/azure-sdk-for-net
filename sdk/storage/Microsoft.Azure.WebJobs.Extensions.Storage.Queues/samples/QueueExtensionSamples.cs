// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Samples.Tests
{
    public class BlobExtensionSamples
    {
        [TestCase(typeof(QueueTriggerFunction_String), "sample message")]
        [TestCase(typeof(QueueTriggerFunction_CustomObject), "{ \"content\": \"sample message\"}")]
        [TestCase(typeof(QueueTriggerFunction_JObject), "{ \"content\": \"sample message\"}")]
        [TestCase(typeof(QueueSenderFunction_String_Return), "sample message")]
        [TestCase(typeof(QueueSenderFunction_CustomObject_OutParamter), "{ \"content\": \"sample message\"}")]
        [TestCase(typeof(QueueSenderFunction_CustomObject_Collector), "{ \"content\": \"sample message\"}")]
        public async Task Run_QueueFunction(Type programType, string message)
        {
            var queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient();
            await queueServiceClient.GetQueueClient("sample-queue").DeleteIfExistsAsync();
            await queueServiceClient.GetQueueClient("sample-queue").CreateIfNotExistsAsync();
            await queueServiceClient.GetQueueClient("sample-queue").SendMessageAsync(message);
            await queueServiceClient.GetQueueClient("sample-queue-1").DeleteIfExistsAsync();
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

    #region Snippet:QueueTriggerFunction_CustomObject
    public static class QueueTriggerFunction_CustomObject
    {
        public class CustomMessage
        {
            public string Content { get; set; }
        }

        [FunctionName("QueueTriggerFunction")]
        public static void Run(
            [QueueTrigger("sample-queue")] CustomMessage message,
            ILogger logger)
        {
            logger.LogInformation("Received message from sample-queue, content={content}", message.Content);
        }
    }
    #endregion

    #region Snippet:QueueTriggerFunction_JObject
    public static class QueueTriggerFunction_JObject
    {
        [FunctionName("QueueTriggerFunction")]
        public static void Run(
            [QueueTrigger("sample-queue")] JObject message,
            ILogger logger)
        {
            logger.LogInformation("Received message from sample-queue, content={content}", message["content"]);
        }
    }
    #endregion

    #region Snippet:QueueSenderFunction_String_Return
    public static class QueueSenderFunction_String_Return
    {
        [FunctionName("QueueFunction")]
        [return: Queue("sample-queue-2")]
        public static string Run(
            [QueueTrigger("sample-queue-1")] string message,
            ILogger logger)
        {
            logger.LogInformation("Received message from sample-queue-1, content={content}", message);
            logger.LogInformation("Dispatching message to sample-queue-2");
            return message;
        }
    }
    #endregion

    #region Snippet:QueueSenderFunction_CustomObject_OutParamter
    public static class QueueSenderFunction_CustomObject_OutParamter
    {
        public class CustomMessage
        {
            public string Content { get; set; }
        }

        [FunctionName("QueueFunction")]
        public static void Run(
            [QueueTrigger("sample-queue-1")] CustomMessage incomingMessage,
            [Queue("sample-queue-2")] out CustomMessage outgoingMessage,
            ILogger logger)
        {
            logger.LogInformation("Received message from sample-queue-1, content={content}", incomingMessage.Content);
            logger.LogInformation("Dispatching message to sample-queue-2");
            outgoingMessage = incomingMessage;
        }
    }
    #endregion

    #region Snippet:QueueSenderFunction_CustomObject_Collector
    public static class QueueSenderFunction_CustomObject_Collector
    {
        public class CustomMessage
        {
            public string Content { get; set; }
        }

        [FunctionName("QueueFunction")]
        public static void Run(
            [QueueTrigger("sample-queue-1")] CustomMessage incomingMessage,
            [Queue("sample-queue-2")] ICollector<CustomMessage> collector,
            ILogger logger)
        {
            logger.LogInformation("Received message from sample-queue-1, content={content}", incomingMessage.Content);
            logger.LogInformation("Dispatching message to sample-queue-2");
            collector.Add(incomingMessage);
        }
    }
    #endregion
}
