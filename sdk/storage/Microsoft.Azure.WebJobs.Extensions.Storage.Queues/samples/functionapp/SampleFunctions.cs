// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Samples.Function.App
{
    /// <summary>
    /// A pair of sample functions. First that produces messages on schedule and second that consumes them.
    /// </summary>
    public static class SampleFunctions
    {
        /// <summary>
        /// This function executes on schedule, produces a message and inserts it into the queue.
        /// </summary>
        [FunctionName("SampleQueueMessageProducer")]
        [return: Queue("sample-queue")]
        public static string ProduceSampleQueueMessage([TimerTrigger("*/10 * * * * *")] TimerInfo timerInfo, ILogger logger)
        {
            if (timerInfo.IsPastDue)
            {
                logger.LogInformation("Timer is running late!");
            }
            var now = DateTime.Now;
            logger.LogInformation($"C# Timer trigger function executed at: {now}");

            return $"Sample queue message produced at: {now}";
        }

        /// <summary>
        /// This functions is executed as new messages appear on the queue and consumes them.
        /// </summary>
        [FunctionName("SampleQueueMessageConsumer")]
        public static void ConsumeSampleQueueMessage([QueueTrigger("sample-queue")] string message, ILogger logger)
        {
            logger.LogInformation("Queue message received: {message}", message);
        }
    }
}
