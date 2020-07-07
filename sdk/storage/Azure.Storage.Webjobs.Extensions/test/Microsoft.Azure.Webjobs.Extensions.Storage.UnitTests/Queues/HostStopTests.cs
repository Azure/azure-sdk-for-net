// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Storage.Queue;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    public class HostStopTests
    {
        private const string QueueName = "input";
        private static readonly TaskCompletionSource<object> _functionStarted = new TaskCompletionSource<object>();
        private static readonly TaskCompletionSource<object> _stopHostCalled = new TaskCompletionSource<object>();
        private static readonly TaskCompletionSource<bool> _testTaskSource = new TaskCompletionSource<bool>();

        [Fact]
        public async Task Stop_TriggersCancellationToken()
        {
            StorageAccount account = new FakeStorageAccount();
            CloudQueue queue = await CreateQueueAsync(account, QueueName);
            CloudQueueMessage message = new CloudQueueMessage("ignore");
            await queue.AddMessageAsync(message);

            var host = new HostBuilder()
                .ConfigureDefaultTestHost<CallbackCancellationTokenProgram>(c =>
                {
                    c.AddAzureStorage();
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

        private static async Task<CloudQueue> CreateQueueAsync(StorageAccount account, string queueName)
        {
            CloudQueueClient client = account.CreateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(queueName);
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