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
using System.Net.Http;
using System.Reflection;
using Microsoft.Azure.Test.HttpRecorder;

namespace Microsoft.Azure.Search.Tests
{
    internal static class TestBaseCopy
    {
        // TODO: This is copied from Test.Framework. Remove when we come up with a better way.
        public static T AddMockHandler<T>(ref T client) where T : class
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
