// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Test.HttpRecorder;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    /// <summary>
    /// A coordinator for tracking and undoing WAML operations.  Usage pattern is
    /// using(MockContext.Create())
    /// {
    ///   maml stuff
    /// }
    /// You can also manually call the Dispose() or UndoAll() methods to undo all 'undoable' operations since the
    /// UndoContext was created.
    /// Call: MockContext.Commit() to remove all undo information
    /// </summary>
    public class MockContext : IDisposable
    {
        //prevent multiple dispose events
        protected bool disposed = false;
        private List<ResourceGroupCleaner> undoHandlers = new List<ResourceGroupCleaner>();

        static MockContext()
        {
            ServiceClientTracing.AddTracingInterceptor(
                new TestingTracingInterceptor());
        }

        /// <summary>
        /// Return a new UndoContext
        /// </summary>
        /// <returns></returns>
        public static MockContext Start(int currentMethodStackDepth = 2)
        {
            var className = TestUtilities.GetCallingClass(currentMethodStackDepth);
            var methodName = TestUtilities.GetCurrentMethodName(currentMethodStackDepth);
            return Start(className, methodName);
        }

        /// <summary>
        /// Return a new UndoContext
        /// </summary>
        /// <returns></returns>
        public static MockContext Start(string className, string methodName)
        {
            var context = new MockContext();

            HttpMockServer.Initialize(className, methodName);
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                context.disposed = false;
            }

            return context;
        }

        /// <summary>
        /// Get a test environment using default options
        /// </summary>
        /// <typeparam name="T">The type of the service client to return</typeparam>
        /// <returns>A Service client using credentials and base uri from the current environment</returns>
        public T GetServiceClient<T>(params DelegatingHandler[] handlers)
            where T : ServiceClient<T>, IAzureClient
        {
            return GetServiceClient<T>(TestEnvironmentFactory.GetTestEnvironment(), handlers);
        }

        /// <summary>
        /// Get a test environment, allowing the test to customize the creation options
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handlers">Delegating existingHandlers</param>
        /// <returns></returns>
        public T GetServiceClient<T>(TestEnvironment currentEnvironment, params DelegatingHandler[] handlers)
            where T : ServiceClient<T>, IAzureClient
        {
            T client;
            handlers = AddHandlers(currentEnvironment, handlers);

            if (currentEnvironment.UsesCustomUri())
            {
                ConstructorInfo constructor = typeof(T).GetConstructor(new Type[]
                {
                    typeof(Uri),
                    typeof(ServiceClientCredentials),
                    typeof(DelegatingHandler[])
                });
                client = constructor.Invoke(new object[]
                {
                    currentEnvironment.BaseUri,
                    currentEnvironment.Credentials,
                    handlers
                }) as T;
            }
            else
            {
                ConstructorInfo constructor = typeof(T).GetConstructor(new Type[]
                {
                    typeof(ServiceClientCredentials),
                    typeof(DelegatingHandler[])
                });
                client = constructor.Invoke(new object[]
                {
                    currentEnvironment.Credentials,
                    handlers
                }) as T;
            }

            var subscriptionId = typeof(T).GetProperty("SubscriptionId");
            if (subscriptionId != null && currentEnvironment.SubscriptionId != null)
            {
                subscriptionId.SetValue(client, currentEnvironment.SubscriptionId);
            }

            var tenantId = typeof(T).GetProperty("TenantId");
            if (tenantId != null && currentEnvironment.Tenant != null)
            {
                tenantId.SetValue(client, currentEnvironment.Tenant);
            }
            SetLongRunningOperationTimeouts(client);
            return client;
        }

        private void SetLongRunningOperationTimeouts<T>(T client) where T : class
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                PropertyInfo retryTimeout = typeof(T).GetProperty("LongRunningOperationRetryTimeout");
                if (retryTimeout != null)
                {
                    retryTimeout.SetValue(client, 0);
                }
            }
        }

        protected DelegatingHandler[] AddHandlers(TestEnvironment currentEnvironment, 
            params DelegatingHandler[] existingHandlers)
        {
            HttpMockServer server;

            try
            {
                server = HttpMockServer.CreateInstance();
            }
            catch (ApplicationException)
            {
                // mock server has never been initialized, we will need to initialize it.
                HttpMockServer.Initialize("TestEnvironment", "InitialCreation");
                server = HttpMockServer.CreateInstance();
            }

            var handlers = new List<DelegatingHandler>(existingHandlers);
            if (!MockServerInHandlers(handlers))
            {
                handlers.Add(server);
            }

            ResourceGroupCleaner cleaner = new ResourceGroupCleaner(currentEnvironment.Credentials);
            handlers.Add(cleaner);
            undoHandlers.Add(cleaner);

            return handlers.ToArray();
        }

        /// <summary>
        /// Stop recording and Discard all undo information
        /// </summary>
        public void Stop()
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                foreach(var undoHandler in undoHandlers)
                {
                    undoHandler.DeleteResourceGroups().ConfigureAwait(false).GetAwaiter().GetResult();
                }
            }

            HttpMockServer.Flush();
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
        
        /// <summary>
        /// Dispose only if we have not previously been disposed
        /// </summary>
        /// <param name="disposing">true if we should dispose, otherwise false</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !this.disposed)
            {
                this.Stop();
                this.disposed = true;
            }
        }

        /// <summary>
        /// Dispose the object
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }        
    }
}
