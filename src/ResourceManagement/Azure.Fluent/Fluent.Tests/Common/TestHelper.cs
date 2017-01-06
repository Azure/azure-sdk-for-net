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
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return Microsoft.Azure.Management.Fluent.Azure.Configure()
                .WithDelegatingHandlers(GetHandlers())
                .Authenticate(credentials)
                .WithSubscription(credentials.DefaultSubscriptionId);
        }

        public static INetworkManager CreateNetworkManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return NetworkManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        public static IComputeManager CreateComputeManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return ComputeManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        public static IResourceManager CreateResourceManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            IResourceManager resourceManager = Microsoft.Azure.Management.Resource.Fluent.ResourceManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials)
                .WithSubscription(credentials.DefaultSubscriptionId);
            return resourceManager;
        }

        public static IBatchManager CreateBatchManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return BatchManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        public static ISqlManager CreateSqlManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);

            return SqlManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        public static IAppServiceManager CreateAppServiceManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return AppServiceManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }


        public static IKeyVaultManager CreateKeyVaultManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return KeyVaultManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        public static ICdnManager CreateCdnManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return CdnManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        public static IRedisManager CreateRedisManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return RedisManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        public static IStorageManager CreateStorageManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return StorageManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        // TODO - ans - context is not required here as we are getting the handler directly from HttpMockServer.
        public static Microsoft.Azure.Management.Resource.Fluent.ResourceManager.IAuthenticated Authenticate(MockContext context)
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return Microsoft.Azure.Management.Resource.Fluent.ResourceManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials);
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