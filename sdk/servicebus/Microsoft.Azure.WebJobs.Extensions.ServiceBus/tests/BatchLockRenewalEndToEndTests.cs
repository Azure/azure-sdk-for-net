// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Azure.Messaging.ServiceBus.Tests;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    [NonParallelizable]
    [LiveOnly(alwaysRunLocally: true)]
    public class BatchLockRenewalEndToEndTests
    {
        private static TimeSpan s_processingTime;
        private static TaskCompletionSource<bool> s_completed;

        [TestCase(false, 15, 25, 0)]
        [TestCase(true, 15, 25, 0)]
        [TestCase(false, 300, 310, 30)]
        public async Task BatchRenewsAndSettlesAfterOriginalExpiry(bool sessions, int lockSeconds, int processingSeconds, int batchWaitSeconds)
        {
            string connection = ServiceBusTestEnvironment.Instance.ServiceBusConnectionString;
            var administration = new ServiceBusAdministrationClient(connection);
            string queueName = $"batch-renewal-{Guid.NewGuid():N}";
            await administration.CreateQueueAsync(new CreateQueueOptions(queueName)
            {
                RequiresSession = sessions,
                LockDuration = TimeSpan.FromSeconds(lockSeconds)
            });
            try
            {
                QueueProperties queue = await administration.GetQueueAsync(queueName);
                Assert.AreEqual(TimeSpan.FromSeconds(lockSeconds), queue.LockDuration);
                s_processingTime = TimeSpan.FromSeconds(processingSeconds);
                s_completed = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                await using var client = new ServiceBusClient(connection);
                await using var sender = client.CreateSender(queueName);
                await sender.SendMessageAsync(new ServiceBusMessage("batch-renewal")
                {
                    SessionId = sessions ? "batch-renewal-session" : null
                });
                using var host = BuildHost(sessions, connection, queueName, batchWaitSeconds);
                await host.StartAsync();
                try
                {
                    await s_completed.Task.TimeoutAfter(TimeSpan.FromSeconds(processingSeconds + batchWaitSeconds + 60));
                }
                finally
                {
                    await host.StopAsync();
                }

                QueueRuntimeProperties runtime = await administration.GetQueueRuntimePropertiesAsync(queueName);
                Assert.AreEqual(0, runtime.ActiveMessageCount);
                Assert.AreEqual(0, runtime.DeadLetterMessageCount);
            }
            finally
            {
                await administration.DeleteQueueAsync(queueName);
            }
        }

        internal static IHost BuildHost(bool sessions, string connection, string queueName, int batchWaitSeconds, bool disableTrigger = false)
        {
            var builder = new HostBuilder().ConfigureAppConfiguration(configuration => configuration.AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    ["AzureWebJobsServiceBus"] = connection,
                    ["batch-renewal-queue"] = queueName,
                    ["AzureWebJobs.RunAsync.Disabled"] = disableTrigger.ToString()
                }));
            Action<IWebJobsBuilder> configure = webJobs => webJobs.AddServiceBus(options =>
            {
                options.AutoCompleteMessages = false;
                options.MaxMessageBatchSize = 2;
                options.MinMessageBatchSize = batchWaitSeconds > 0 ? 2 : 1;
                options.MaxBatchWaitTime = TimeSpan.FromSeconds(Math.Max(1, batchWaitSeconds));
                options.PrefetchCount = 0;
            });
            if (sessions)
            {
                builder.ConfigureDefaultTestHost<SessionBatchJob>(configure);
            }
            else
            {
                builder.ConfigureDefaultTestHost<BatchJob>(configure);
            }

            return builder.Build();
        }

        public class BatchJob
        {
            public static Task RunAsync(
                [ServiceBusTrigger("%batch-renewal-queue%")] ServiceBusReceivedMessage[] messages,
                ServiceBusMessageActions messageActions,
                CancellationToken cancellationToken)
                => ProcessAsync(messages, messageActions, cancellationToken);
        }

        public class SessionBatchJob
        {
            public static Task RunAsync(
                [ServiceBusTrigger("%batch-renewal-queue%", IsSessionsEnabled = true)] ServiceBusReceivedMessage[] messages,
                ServiceBusSessionMessageActions sessionActions,
                CancellationToken cancellationToken)
                => ProcessAsync(messages, sessionActions, cancellationToken);
        }

        private static async Task ProcessAsync(ServiceBusReceivedMessage[] messages, ServiceBusMessageActions actions, CancellationToken cancellationToken)
        {
            try
            {
                var initialExpiry = messages.Min(message => message.LockedUntil);
                await Task.Delay(s_processingTime, cancellationToken);
                if (actions is not ServiceBusSessionMessageActions)
                {
                    Assert.Greater(messages.Min(message => message.LockedUntil), initialExpiry);
                }

                Assert.IsTrue(messages.All(message => message.DeliveryCount == 1));
                foreach (var message in messages)
                {
                    await actions.CompleteMessageAsync(message, cancellationToken);
                }

                s_completed.TrySetResult(true);
            }
            catch (Exception exception)
            {
                s_completed.TrySetException(exception);
                throw;
            }
        }
    }
}
