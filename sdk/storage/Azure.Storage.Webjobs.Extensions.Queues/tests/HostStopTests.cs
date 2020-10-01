// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;
using Azure.Storage.Queues;
using Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    [Collection(AzuriteCollection.Name)]
    public class HostStopTests
    {
        private const string QueueName = "input-hoststoptests";
        private static readonly TaskCompletionSource<object> _functionStarted = new TaskCompletionSource<object>();
        private static readonly TaskCompletionSource<object> _stopHostCalled = new TaskCompletionSource<object>();
        private static readonly TaskCompletionSource<bool> _testTaskSource = new TaskCompletionSource<bool>();
        private readonly StorageAccount account;

        public HostStopTests(AzuriteFixture azuriteFixture)
        {
            account = azuriteFixture.GetAccount();
            account.CreateQueueServiceClient().GetQueueClient(QueueName).DeleteIfExists();
        }

        [Fact]
        public async Task Stop_TriggersCancellationToken()
        {
            QueueClient queue = await CreateQueueAsync(account, QueueName);
            await queue.SendMessageAsync("ignore");

            var host = new HostBuilder()
                .ConfigureDefaultTestHost<CallbackCancellationTokenProgram>(c =>
                {
                    c.AddAzureStorageBlobs().AddAzureStorageQueues();
                    c.Services.AddSingleton<StorageAccountProvider>(_ => new FakeStorageAccountProvider(account));
                })
                .Build();

            using (host)
            {
                int secondsToWait = 5;

                // Start and wait for the function to be invoked.
                await host.StartAsync();
                bool completed = _functionStarted.Task.WaitUntilCompleted(secondsToWait * 1000);
                Assert.True(completed, $"Function did not start in {secondsToWait} seconds.");

                // Stop the host and let the function know it can continue.
                Task stopTask = host.StopAsync();
                _stopHostCalled.TrySetResult(null);

                completed = _testTaskSource.Task.WaitUntilCompleted(secondsToWait * 1000);
                Assert.True(completed, $"Host did not shut down in {secondsToWait} seconds.");

                // Give a nicer test failure message for faulted tasks.
                if (_testTaskSource.Task.Status == TaskStatus.Faulted)
                {
                    await _testTaskSource.Task;
                }

                Assert.Equal(TaskStatus.RanToCompletion, _testTaskSource.Task.Status);

                stopTask.WaitUntilCompleted(3 * 1000);
                Assert.Equal(TaskStatus.RanToCompletion, stopTask.Status);
            }
        }

        private static async Task<QueueClient> CreateQueueAsync(StorageAccount account, string queueName)
        {
            var client = account.CreateQueueServiceClient();
            var queue = client.GetQueueClient(queueName);
            await queue.CreateIfNotExistsAsync();
            return queue;
        }

        private class CallbackCancellationTokenProgram
        {
            public static void CallbackCancellationToken([QueueTrigger(QueueName)] string ignore,
                CancellationToken cancellationToken)
            {
                // Signal that we've entered the function.
                _functionStarted.TrySetResult(null);

                // Wait to continue until the StopHost has been called.
                bool started = _stopHostCalled.Task.WaitUntilCompleted(3 * 1000);
                Assert.True(started); // Guard

                // Signal the test is complete with the actual value.
                _testTaskSource.TrySetResult(cancellationToken.IsCancellationRequested);
            }
        }
    }
}
