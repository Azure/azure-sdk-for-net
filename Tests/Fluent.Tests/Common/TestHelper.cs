// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Batch.Fluent;
using Microsoft.Azure.Management.Cdn.Fluent;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.ContainerRegistry.Fluent;
using Microsoft.Azure.Management.CosmosDB.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Redis.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Search.Fluent;
using Microsoft.Azure.Management.ServiceBus.Fluent;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;

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

        public static string ReadLine()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                // NOTE: This test requires a manual action to be performed before it can continue recording.
                // Please go up the execution stack (or check test output window) to see what steps needs 
                // to be performed before you can continue execution.
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                    return "[Running in interactive mode]";
                }

                throw new NotSupportedException(
                    "This test requires a manual action to be performed before it can continue recording. " + 
                    "Please run it with a debugger attached to be able to perform required steps in the Record mode.");
            }

            return "[Running in non interactive mode]";
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

        public static Microsoft.Azure.Management.Fluent.Azure.IAuthenticated CreateAuthenticatedClient()
        {
            return CreateMockedManager(c => Microsoft.Azure.Management.Fluent.Azure.Configure()
                .WithDelegatingHandlers(GetHandlers())
                .Authenticate(c));
        }


        public static INetworkManager CreateNetworkManager()
        {
            return CreateMockedManager(c => NetworkManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static IComputeManager CreateComputeManager()
        {
            return CreateMockedManager(c => ComputeManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static IResourceManager CreateResourceManager()
        {
            return CreateMockedManager(c => Microsoft.Azure.Management.ResourceManager.Fluent.ResourceManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                .Authenticate(c)
                .WithSubscription(c.DefaultSubscriptionId));
        }

        public static IBatchManager CreateBatchManager()
        {
            return CreateMockedManager(c => BatchManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static ISqlManager CreateSqlManager()
        {
            return CreateMockedManager(c => SqlManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static IAppServiceManager CreateAppServiceManager()
        {
            return CreateMockedManager(c => AppServiceManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                .Authenticate(c, c.DefaultSubscriptionId));
        }


        public static IKeyVaultManager CreateKeyVaultManager()
        {
            return CreateMockedManager(c => KeyVaultManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static ICdnManager CreateCdnManager()
        {
            return CreateMockedManager(c => CdnManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static IRedisManager CreateRedisManager()
        {
            return CreateMockedManager(c => RedisManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static IStorageManager CreateStorageManager()
        {
            return CreateMockedManager(c => StorageManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static ISearchManager CreateSearchManager()
        {
            return CreateMockedManager(c => SearchManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static IServiceBusManager CreateServiceBusManager()
        {
            return CreateMockedManager(c => ServiceBusManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static IRegistryManager CreateRegistryManager()
        {
            return CreateMockedManager(c => RegistryManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static ICosmosDBManager CreateCosmosDB()
        {
            return CreateMockedManager(c => CosmosDBManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                .Authenticate(c, c.DefaultSubscriptionId));
        }

        public static IGraphRbacManager CreateGraphRbacManager()
        {
            return CreateMockedManager(c => GraphRbacManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                .Authenticate(c, c.TenantId));
        }

        public static Microsoft.Azure.Management.ResourceManager.Fluent.ResourceManager.IAuthenticated Authenticate()
        {
            return CreateMockedManager(c => Microsoft.Azure.Management.ResourceManager.Fluent.ResourceManager
                .Configure()
                .WithDelegatingHandlers(GetHandlers())
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                .Authenticate(c));
        }

        private static T CreateMockedManager<T>(Func<AzureCredentials, T> builder)
        {
            AzureCredentials credentials = SdkContext.AzureCredentialsFactory.FromFile(authFilePath);

            var manager = builder.Invoke(credentials);

            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                // In Playback mode set all the LongRunning timeouts to 0 
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

                    m.GetType().GetProperties().Where(n => n.Name.Equals("Inner"))
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

        public static void DeprovisionAgentInLinuxVM(string host, int port, string userName, string password)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                return;
            }

            Console.WriteLine("Trying to de-provision: " + host);
            Console.WriteLine("ssh connection status: " + TrySsh(
                host,
                port,
                userName,
                password,
                "sudo waagent -deprovision+user --force"));
        }

        public static async Task<HttpResponseMessage> CheckAddress(string url)
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                using (var client = new HttpClient())
                {
                    return await client.GetAsync(url);
                }
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                        {
                            Content = new StringContent("Hello world from linux 4")
                        };
        }

        public static string TrySsh(
            string host, 
            int port, 
            string userName, 
            string password,
            string commandToExecute)
        {
            string commandOutput = null;
            var backoffTime = 30 * 1000;
            var retryCount = 3;

            while (retryCount > 0)
            {
                using (var sshClient = new SshClient(host, port, userName, password))
                {
                    try
                    {
                        sshClient.Connect();
                        if (commandToExecute != null)
                        {
                            using (var command = sshClient.CreateCommand(commandToExecute))
                            {
                                commandOutput = command.Execute();
                            }
                        }
                        break;
                    }
                    catch (Exception exception)
                    {
                        retryCount--;
                        if (retryCount == 0)
                        {
                            throw exception;
                        }
                    }
                    finally
                    {
                        try
                        {
                            sshClient.Disconnect();
                        }
                        catch { }
                    }
                }
                TestHelper.Delay(backoffTime);
            }

            return commandOutput;
        }
    }
}