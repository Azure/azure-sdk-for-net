// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.FunctionalTests.TestDoubles;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    // $$$  Remove all this. See Blob_IfBoundToCloudBlockBlob_BindsAndCreatesContainerButNotBlob for an example of what it should be. 
    internal class FunctionalTest
    {
        // $$$ Reconcile with TestJobHost.

        internal static async Task<TResult> RunTriggerAsync<TResult>(
            StorageAccount account,
            Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource,
            IEnumerable<string> ignoreFailureFunctions = null,
            bool signalOnFirst = false)
        {
            TaskCompletionSource<TResult> src = new TaskCompletionSource<TResult>();
            setTaskSource(src);

            var host = new HostBuilder()
              .ConfigureDefaultTestHost(builder =>
              {
                  builder.AddAzureStorage()
                      .UseStorage(account)
                      .ConfigureCatchFailures(src, signalOnFirst, ignoreFailureFunctions);

                  builder.Services.AddSingleton<IConfigureOptions<QueuesOptions>, FakeQueuesOptionsSetup>();
              }, programType)
              .Build();

            try
            {
                using (var jobHost = host.GetJobHost())
                {
                    // start listeners. One of them will set the completition task
                    await jobHost.StartAsync();

                    var result = src.Task.AwaitWithTimeout(); // blocks

                    await jobHost.StopAsync();

                    return result;
                }
            }
            catch (Exception exception)
            {
                // Unwrap 
                var e = exception;
                while (e != null)
                {
                    if (e is InvalidOperationException)
                    {
                        throw e;
                    }
                    e = e.InnerException;
                }
                throw;
            }
        }

        // Caller has already setup a trigger.
        // Runs the first triggered function and then returns. 
        // Expected that this instance provided some side-effect (ie, wrote to storage)
        // that the caller can monitor.
        internal static async Task RunTriggerAsync(StorageAccount account, Type programType)
        {
            TaskCompletionSource<bool> src = new TaskCompletionSource<bool>();
            await RunTriggerAsync<bool>(
                account,
                programType,
                (x) => x = src,
                signalOnFirst: true);
        }

        internal static object CreateConfigurationForCallFailure(StorageAccount account, Type type, TaskCompletionSource<object> backgroundTaskSource)
        {
            throw new NotImplementedException();
        }

        internal static async Task<Exception> RunTriggerFailureAsync<TResult>(StorageAccount account, Type programType, Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            try
            {
                await RunTriggerAsync<TResult>(account, programType, setTaskSource);
            }
            catch (Exception e)
            {
                return e;
            }
            Assert.True(false, "Expected trigger to fail"); // throws
            return null;
        }

        // Call the method, and expect a failure. Return the exception. 
        internal static async Task<Exception> CallFailureAsync(StorageAccount account, Type programType, MethodInfo methodInfo, object arguments)
        {
            var host = new HostBuilder()
                .ConfigureDefaultTestHost(b =>
                {
                    b.AddAzureStorage()
                    .UseStorage(account);
                }, programType)
                .Build();

            var jobHost = host.GetJobHost();

            try
            {
                await jobHost.CallAsync(methodInfo, arguments);
            }
            catch (Exception e)
            {
                return e;
            }
            Assert.True(false, "Expected trigger to fail"); // throws
            return null;
        }

        internal static async Task CallAsync(StorageAccount account, Type programType, MethodInfo methodInfo, object arguments, params Type[] customExtensions)
        {
            var host = new HostBuilder()
                .ConfigureDefaultTestHost(b =>
                {
                    b.AddAzureStorage()
                    .UseStorage(account);

                    foreach (var extension in customExtensions)
                    {
                        b.AddExtension(extension);
                    }
                }, programType)
                .Build();

            var jobHost = host.GetJobHost();
            await jobHost.CallAsync(methodInfo, arguments);
        }

        internal static async Task<TResult> CallAsync<TResult>(StorageAccount account, Type programType, MethodInfo methodInfo, IDictionary<string, object> arguments, Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            TaskCompletionSource<TResult> src = new TaskCompletionSource<TResult>();
            setTaskSource(src);

            var host = new HostBuilder()
              .ConfigureDefaultTestHost(builder =>
              {
                  builder.AddAzureStorage()
                  .UseStorage(account);
              }, programType)
              .Build();

            var jobHost = host.GetJobHost();
            await jobHost.CallAsync(methodInfo, arguments);

            return src.Task.Result;
        }
    }
}