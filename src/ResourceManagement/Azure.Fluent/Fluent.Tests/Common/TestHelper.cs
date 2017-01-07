// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Batch.Fluent;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System;
using Xunit.Abstractions;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.Cdn.Fluent;
using Microsoft.Azure.Management.Redis.Fluent;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net.Http;
using Microsoft.Azure.Test.HttpRecorder;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Reflection;
using Microsoft.Rest.Azure;

namespace Fluent.Tests.Common
{
    public static class TestHelper
    {
        public static ITestOutputHelper TestLogger { get; set; }

        private static string authFilePath = Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION");

        public static void Delay(int millisecondsTimeout)
        {
            if(HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                Thread.Sleep(millisecondsTimeout);
            }
        }

        public static void Delay(TimeSpan timeout)
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                Thread.Sleep(timeout);
            }
        }

        public static void WriteLine(string format, params string[] parameters)
        {
            WriteLine(string.Format(format, parameters));
        }

        public static void WriteLine(string message)
        {
            if(TestLogger != null)
            {
                TestLogger.WriteLine(message);
            }
            else
            {
                Console.WriteLine(message);
            }
        }

        public static IAzure CreateRollupClient()
        {
            return CreateMockedManager(c => Microsoft.Azure.Management.Fluent.Azure.Configure()
                .WithDelegatingHandlers(GetHandlers())
                .Authenticate(c)
                .WithSubscription(c.DefaultSubscriptionId));
        }

        public static INetworkManager CreateNetworkManager()
        {
            return CreateMockedManager(c => NetworkManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static IComputeManager CreateComputeManager()
        {
            return CreateMockedManager(c => ComputeManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static IResourceManager CreateResourceManager()
        {
            return CreateMockedManager(c => Microsoft.Azure.Management.Resource.Fluent.ResourceManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(c)
                .WithSubscription(c.DefaultSubscriptionId));
        }

        public static IBatchManager CreateBatchManager()
        {
            return CreateMockedManager(c => BatchManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static ISqlManager CreateSqlManager()
        {
            return CreateMockedManager(c => SqlManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static IAppServiceManager CreateAppServiceManager()
        {
            return CreateMockedManager(c => AppServiceManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(c, c.DefaultSubscriptionId));
        }


        public static IKeyVaultManager CreateKeyVaultManager()
        {
            return CreateMockedManager(c => KeyVaultManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static ICdnManager CreateCdnManager()
        {
            return CreateMockedManager(c => CdnManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static IRedisManager CreateRedisManager()
        {
            return CreateMockedManager(c => RedisManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static IStorageManager CreateStorageManager()
        {
            return CreateMockedManager(c => StorageManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static Microsoft.Azure.Management.Resource.Fluent.ResourceManager.IAuthenticated Authenticate()
        {
            return CreateMockedManager(c => Microsoft.Azure.Management.Resource.Fluent.ResourceManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(c));
        }

        private static T CreateMockedManager<T>(Func<AzureCredentials, T> builder)
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);

            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                credentials = credentials.WithDefaultSubscription(TestEnvironmentFactory.GetTestEnvironment().SubscriptionId);
            }
            else
            {
                HttpMockServer.Variables[ConnectionStringKeys.SubscriptionIdKey] = credentials.DefaultSubscriptionId;
            }

            var manager = builder.Invoke(credentials);


            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                var managersList = new List<object>();
                var managerTraversalStack = new Stack<object>();

                managerTraversalStack.Push(manager);

                while (managerTraversalStack.Count > 0)
                {
                    var stackedObject = managerTraversalStack.Pop();
                    // if not a rollup package
                    if (!(stackedObject is IAzure))
                    {
                        managersList.Add(stackedObject);
                        var resourceManager = stackedObject.GetType().GetProperty("ResourceManager");
                        if (resourceManager != null)
                        {
                            managersList.Add(resourceManager.GetValue(stackedObject));
                        }
                    }

                    foreach (var obj in stackedObject
                        .GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                        .Where(f => f.FieldType.GetInterfaces().Contains(typeof(IManagerBase)))
                        .Select(f => (IManagerBase)f.GetValue(stackedObject)))
                    {
                        managerTraversalStack.Push(obj);
                    }
                }

                foreach (var m in managersList)
                {
                    m.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                            .Where(f => f.FieldType.GetInterfaces().Contains(typeof(IAzureClient)))
                            .Select(f => (IAzureClient)f.GetValue(m))
                            .ToList()
                            .ForEach(c => c.LongRunningOperationRetryTimeout = 0);
                }
            }
            return manager;
        }

        public static DelegatingHandler[] GetHandlers()
        {
            HttpMockServer server;

            try
            {
                server = HttpMockServer.CreateInstance();
            }
            catch (InvalidOperationException)
            {
                // mock server has never been initialized, we will need to initialize it.
                HttpMockServer.Initialize("TestEnvironment", "InitialCreation");
                server = HttpMockServer.CreateInstance();
            }

            var handlers = new List<DelegatingHandler>();
            if (!MockServerInHandlers(handlers))
            {
                handlers.Add(server);
            }

            // TODO - ans - Needs token Credential here to delete the resource group.
            //ResourceGroupCleaner cleaner = new ResourceGroupCleaner(credentials);
            //handlers.Add(cleaner);
            // TODO - ans - We need to add this to clean resource group.
            //undoHandlers.Add(cleaner);

            return handlers.ToArray();
        }

        private static bool MockServerInHandlers(List<DelegatingHandler> handlers)
        {
            var result = false;
            foreach (var handler in handlers)
            {
                if (HandlerContains<HttpMockServer>(handler))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private static bool HandlerContains<T1>(DelegatingHandler handler)
        {
            return (handler is T1 || (handler.InnerHandler != null
                && handler.InnerHandler is DelegatingHandler
                && HandlerContains<T1>(handler.InnerHandler as DelegatingHandler)));
        }
    }
}