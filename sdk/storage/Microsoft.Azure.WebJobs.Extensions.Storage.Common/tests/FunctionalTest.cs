// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests
{
    // $$$  Remove all this. See Blob_IfBoundToCloudBlockBlob_BindsAndCreatesContainerButNotBlob for an example of what it should be.
    public class FunctionalTest
    {
        // $$$ Reconcile with TestJobHost.

        public static async Task<TResult> RunTriggerAsync<TResult>(
            Action<IWebJobsBuilder> configureWebJobsBuilderAction,
            Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource,
            IEnumerable<string> ignoreFailureFunctions = null,
            bool signalOnFirst = false,
            Dictionary<string, string> settings = default)
        {
            TaskCompletionSource<TResult> src = new TaskCompletionSource<TResult>();
            setTaskSource(src);

            var host = new HostBuilder()
              .ConfigureLogging(b => b.AddProvider(new ExpectManualCompletionLoggerProvider<TResult>(src, signalOnFirst, ignoreFailureFunctions)))
              .ConfigureAppConfiguration(cb => cb.AddInMemoryCollection(settings))
              .ConfigureDefaultTestHost(builder => configureWebJobsBuilderAction.Invoke(builder), programType)
              .Build();

            try
            {
                using (JobHost jobHost = host.GetJobHost())
                {
                    try
                    {
                        // start listeners. One of them will set the completition task
                        await jobHost.StartAsync();

                        var result = await src.Task.AwaitWithTimeout(); // blocks

                        return result;
                    } finally
                    {
                        await jobHost.StopAsync();
                    }
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
        public static async Task RunTriggerAsync(Action<IWebJobsBuilder> configureWebJobsBuilderAction, Type programType, Dictionary<string, string> settings = default)
        {
            TaskCompletionSource<bool> src = new TaskCompletionSource<bool>();
            await RunTriggerAsync<bool>(
                configureWebJobsBuilderAction,
                programType,
                (x) => x = src,
                signalOnFirst: true,
                settings: settings);
        }

        public static async Task<Exception> RunTriggerFailureAsync<TResult>(Action<IWebJobsBuilder> configureWebJobsBuilderAction, Type programType, Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            try
            {
                await RunTriggerAsync<TResult>(configureWebJobsBuilderAction, programType, setTaskSource);
            }
            catch (Exception e)
            {
                return e;
            }
            Assert.True(false, "Expected trigger to fail"); // throws
            return null;
        }

        // Call the method, and expect a failure. Return the exception.
        public static async Task<Exception> CallFailureAsync(Action<IWebJobsBuilder> configureWebJobsBuilderAction, Type programType, MethodInfo methodInfo, object arguments)
        {
            var host = new HostBuilder()
                .ConfigureDefaultTestHost(b => configureWebJobsBuilderAction.Invoke(b), programType)
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

        public static async Task CallAsync(Action<IWebJobsBuilder> configureWebJobsBuilderAction, Type programType, MethodInfo methodInfo, object arguments, params Type[] customExtensions)
        {
            var host = new HostBuilder()
                .ConfigureDefaultTestHost(b =>
                {
                    configureWebJobsBuilderAction.Invoke(b);

                    foreach (var extension in customExtensions)
                    {
                        b.AddExtension(extension);
                    }
                }, programType)
                .Build();

            var jobHost = host.GetJobHost();
            await jobHost.CallAsync(methodInfo, arguments);
        }

        public static async Task<TResult> CallAsync<TResult>(Action<IWebJobsBuilder> configureWebJobsBuilderAction, Type programType, MethodInfo methodInfo, IDictionary<string, object> arguments, Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            TaskCompletionSource<TResult> src = new TaskCompletionSource<TResult>();
            setTaskSource(src);

            var host = new HostBuilder()
              .ConfigureDefaultTestHost(builder => configureWebJobsBuilderAction.Invoke(builder), programType)
              .Build();

            var jobHost = host.GetJobHost();
            await jobHost.CallAsync(methodInfo, arguments);

            return src.Task.Result;
        }
    }
}
