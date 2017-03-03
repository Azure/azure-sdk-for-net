//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;
using System.Reflection;
using Microsoft.Azure;
using System.Net.Http;

namespace Microsoft.Azure.Management.Automation.Testing
{
    public class HyakMockContext : MockContext
    {
        public static HyakMockContext Start(
            string className,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName = "testframework_failed")
        {
            var context = new HyakMockContext();
            if (HttpMockServer.FileSystemUtilsObject == null)
            {
                HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();
            }

            HttpMockServer.Initialize(className, methodName);

            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                context.disposed = false;
            }

            return context;
        }

        public T GetServiceClient<T>() where T : class
        {
            TestEnvironment currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            T client;
            var credentials = new CredentialAdapter(
                currentEnvironment.TokenInfo[TokenAudience.Management],
                currentEnvironment.SubscriptionId);

            if (currentEnvironment.BaseUri != null)
            {
                ConstructorInfo constructor = typeof(T).GetConstructor(new Type[] { typeof(SubscriptionCloudCredentials), typeof(Uri) });
                client = constructor.Invoke(new object[] { credentials, currentEnvironment.BaseUri }) as T;
            }
            else
            {
                ConstructorInfo constructor = typeof(T).GetConstructor(new Type[] { typeof(SubscriptionCloudCredentials) });
                client = constructor.Invoke(new object[] { credentials }) as T;
            }

            return AddMockHandler<T>(ref client);
        }

        public T GetServiceClient<T>(string apiVersion) where T : class
        {
            TestEnvironment currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            T client;
            var credentials = new CredentialAdapter(
                currentEnvironment.TokenInfo[TokenAudience.Management],
                currentEnvironment.SubscriptionId);

            if (currentEnvironment.BaseUri != null)
            {
                ConstructorInfo constructor = typeof(T).GetConstructor(new Type[] { typeof(Uri), typeof(SubscriptionCloudCredentials), typeof(string) });
                client = constructor.Invoke(new object[] { currentEnvironment.BaseUri, credentials, apiVersion }) as T;
            }
            else
            {
                ConstructorInfo constructor = typeof(T).GetConstructor(new Type[] { typeof(SubscriptionCloudCredentials), typeof(string) });
                client = constructor.Invoke(new object[] { credentials, apiVersion }) as T;
            }

            return AddMockHandler<T>(ref client);
        }

        protected static T AddMockHandler<T>(ref T client) where T : class
        {
            HttpMockServer server;

            try
            {
                server = HttpMockServer.CreateInstance();
            }
            catch(Exception)
            {
                HttpMockServer.Initialize("TestEnvironment", "InitialCreation");
                server = HttpMockServer.CreateInstance();
            }

            MethodInfo method = typeof(T).GetMethod("WithHandler", new Type[] { typeof(DelegatingHandler) });
            client = method.Invoke(client, new object[] { server }) as T;
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                PropertyInfo initialTimeout = typeof(T).GetProperty("LongRunningOperationInitialTimeout", typeof(int));
                PropertyInfo retryTimeout = typeof(T).GetProperty("LongRunningOperationRetryTimeout", typeof(int));
                if (initialTimeout != null && retryTimeout != null)
                {
                    initialTimeout.SetValue(client, 0);
                    retryTimeout.SetValue(client, 0);
                }
            }

            return client;
        }
    }
}
