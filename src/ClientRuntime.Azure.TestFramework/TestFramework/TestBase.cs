// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework.HttpRecorder;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    public partial class TestBase
    {
        static TestBase()
        {
            ServiceClientTracing.AddTracingInterceptor(
                new TestingTracingInterceptor());
        }

        /// <summary>
        /// Get a test environment using default options
        /// </summary>
        /// <typeparam name="T">The type of the service client to return</typeparam>
        /// <returns>A Service client using credentials and base uri from the current environment</returns>
        public static T GetServiceClient<T>(params DelegatingHandler[] handlers) 
            where T : ServiceClient<T>, IAzureClient
        {
            return TestBase.GetServiceClient<T>(TestEnvironmentFactory.GetTestEnvironment(), handlers);
        }

        /// <summary>
        /// Get a test environment, allowing the test to customize the creation options
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handlers">Delegating existingHandlers</param>
        /// <returns></returns>
        public static T GetServiceClient<T>(TestEnvironment currentEnvironment, params DelegatingHandler[] handlers) 
            where T : ServiceClient<T>, IAzureClient
        {
            T client;
            handlers = AddMockHandler(handlers);

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

        private static void SetLongRunningOperationTimeouts<T>(T client) where T : class
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

        protected static DelegatingHandler[] AddMockHandler(params DelegatingHandler[] existingHandlers)
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
            handlers.Add(server);
            return handlers.ToArray();
        }
    }
}
