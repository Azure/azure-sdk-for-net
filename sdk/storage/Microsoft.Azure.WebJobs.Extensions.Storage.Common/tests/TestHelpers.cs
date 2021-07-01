// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests
{
    public static class TestHelpers
    {
        /// <summary>
        /// Helper that builds a test host to configure the options type specified.
        /// </summary>
        /// <typeparam name="TOptions">The options type to configure.</typeparam>
        /// <param name="configure">Delegate used to configure the target extension.</param>
        /// <param name="configValues">Set of test configuration values to apply.</param>
        /// <returns></returns>
        public static TOptions GetConfiguredOptions<TOptions>(Action<IWebJobsBuilder> configure, Dictionary<string, string> configValues) where TOptions : class, new()
        {
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<TestProgram>(b =>
                {
                    configure(b);
                })
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddInMemoryCollection(configValues);
                })
                .Build();

            TOptions options = host.Services.GetRequiredService<IOptions<TOptions>>().Value;
            return options;
        }

        // Test error if not reached within a timeout
        public static Task<TResult> AwaitWithTimeout<TResult>(this TaskCompletionSource<TResult> taskSource)
        {
            return taskSource.Task;
        }

        // Test error if not reached within a timeout
        public static async Task<TResult> AwaitWithTimeout<TResult>(this Task<TResult> taskSource)
        {
            await Await(() => taskSource.IsCompleted);
            return taskSource.Result;
        }

        public static async Task Await(Func<Task<bool>> condition, int timeout = 60 * 1000, int pollingInterval = 50, bool throwWhenDebugging = false, Func<string> userMessageCallback = null)
        {
            DateTime start = DateTime.Now;
            while (!await condition())
            {
                await Task.Delay(pollingInterval);

                bool shouldThrow = !Debugger.IsAttached || (Debugger.IsAttached && throwWhenDebugging);
                if (shouldThrow && (DateTime.Now - start).TotalMilliseconds > timeout)
                {
                    string error = "Condition not reached within timeout.";
                    if (userMessageCallback != null)
                    {
                        error += " " + userMessageCallback();
                    }
                    throw new ApplicationException(error);
                }
            }
        }

        public static async Task Await(Func<bool> condition, int timeout = 60 * 1000, int pollingInterval = 50, bool throwWhenDebugging = false, Func<string> userMessageCallback = null)
        {
            await Await(() => Task.FromResult(condition()), timeout, pollingInterval, throwWhenDebugging, userMessageCallback);
        }

        // Test that we get an indexing error (FunctionIndexingException)
        // functionName - the function name that has the indexing error.
        // expectedErrorMessage - inner exception's message with details.
        // Invoking func() should cause an indexing error.
        public static void AssertIndexingError(Action func, string functionName, string expectedErrorMessage)
        {
            try
            {
                func(); // expected indexing error
            }
            catch (FunctionIndexingException e)
            {
                Assert.AreEqual("Error indexing method '" + functionName + "'", e.Message);
                StringAssert.StartsWith(expectedErrorMessage, e.InnerException.Message);
                return;
            }
            Assert.True(false, "Invoker should have failed");
        }

        public static IHostBuilder ConfigureDefaultTestHost(this IHostBuilder builder, Action<IWebJobsBuilder> configureWebJobs, params Type[] types)
        {
            return builder
                .ConfigureWebJobs(configureWebJobs)
                .ConfigureAppConfiguration(c =>
                {
                    c.AddTestSettings();
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<ITypeLocator>(new FakeTypeLocator(types));

                    // Register this to fail a test if a background exception is thrown
                    services.AddSingleton<IWebJobsExceptionHandlerFactory, TestExceptionHandlerFactory>();
                })
                .ConfigureTestLogger();
        }

        public static IHostBuilder ConfigureDefaultTestHost<TProgram>(this IHostBuilder builder,
           TProgram instance, Action<IWebJobsBuilder> configureWebJobs)
        {
            return builder.ConfigureDefaultTestHost(configureWebJobs, typeof(TProgram))
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IJobHost, JobHost<TProgram>>();

                    services.AddSingleton<IJobActivator>(new FakeActivator(instance));
                });
        }

        public static IHostBuilder ConfigureDefaultTestHost<TProgram>(this IHostBuilder builder, Action<IWebJobsBuilder> configureWebJobs,
            INameResolver nameResolver = null, IJobActivator activator = null)
        {
            return builder.ConfigureDefaultTestHost(configureWebJobs, typeof(TProgram))
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IJobHost, JobHost<TProgram>>();

                    if (nameResolver != null)
                    {
                        services.AddSingleton<INameResolver>(nameResolver);
                    }

                    if (activator != null)
                    {
                        services.AddSingleton<IJobActivator>(activator);
                    }
                });
        }

        public static IHostBuilder ConfigureTestLogger(this IHostBuilder builder)
        {
            return builder.ConfigureLogging(logging =>
             {
                 logging.AddProvider(new TestLoggerProvider());
             });
        }

        public static TestLoggerProvider GetTestLoggerProvider(this IHost host)
        {
            return host.Services.GetServices<ILoggerProvider>().OfType<TestLoggerProvider>().Single();
        }

        public static JobHost GetJobHost(this IHost host)
        {
            return host.Services.GetService<IJobHost>() as JobHost;
        }

        public static JobHost<TProgram> GetJobHost<TProgram>(this IHost host)
        {
            return host.Services.GetService<IJobHost>() as JobHost<TProgram>;
        }

        public static async Task CallAsync<T>(this JobHost host, string methodName, object arguments)
        {
            await host.CallAsync(typeof(T).GetMethod(methodName), arguments);
        }

        public static async Task CallAsync<T>(this JobHost host, string methodName)
        {
            await host.CallAsync(typeof(T).GetMethod(methodName));
        }

        public static TOptions GetOptions<TOptions>(this IHost host) where TOptions : class, new()
        {
            return host.Services.GetService<IOptions<TOptions>>().Value;
        }

        public static List<string> GetAssemblyReferences(Assembly assembly)
        {
            var assemblyRefs = assembly.GetReferencedAssemblies();
            var names = (from assemblyRef in assemblyRefs
                         orderby assemblyRef.Name.ToLowerInvariant()
                         select assemblyRef.Name).ToList();
            return names;
        }

        public static void AssertPublicTypes(IEnumerable<string> expected, Assembly assembly)
        {
            var publicTypes = (assembly.GetExportedTypes()
                .Select(type => type.Name)
                .OrderBy(n => n));

            AssertPublicTypes(expected.ToArray(), publicTypes.ToArray());
        }

        public static void AssertPublicTypes(string[] expected, string[] actual)
        {
            var newlyIntroducedPublicTypes = actual.Except(expected).ToArray();

            if (newlyIntroducedPublicTypes.Length > 0)
            {
                string message = string.Format(CultureInfo.InvariantCulture, "Found {0} unexpected public type{1}: \r\n{2}",
                    newlyIntroducedPublicTypes.Length,
                    newlyIntroducedPublicTypes.Length == 1 ? "" : "s",
                    string.Join("\r\n", newlyIntroducedPublicTypes));
                Assert.True(false, message);
            }

            var missingPublicTypes = expected.Except(actual).ToArray();

            if (missingPublicTypes.Length > 0)
            {
                string message = string.Format(CultureInfo.InvariantCulture, "missing {0} public type{1}: \r\n{2}",
                    missingPublicTypes.Length,
                    missingPublicTypes.Length == 1 ? "" : "s",
                    string.Join("\r\n", missingPublicTypes));
                Assert.True(false, message);
            }
        }
    }

    public class TestProgram
    {
    }
}
