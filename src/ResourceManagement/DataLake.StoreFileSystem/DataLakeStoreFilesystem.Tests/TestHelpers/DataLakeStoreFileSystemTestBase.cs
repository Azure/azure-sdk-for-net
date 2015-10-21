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
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;

namespace DataLakeStoreFileSystem.Tests
{
    public class DataLakeStoreFileSystemTestBase : TestBase
    {
        /// <summary>
        /// Gets DataLakeStoreFileSystem client for the current test environment 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static T GetDataLakeStoreFileSystemServiceClient<T>(
            TestEnvironmentFactory factory)
            where T : class
        {
            TestEnvironment currentEnvironment = factory.GetTestEnvironment();
            T client = null;

            ConstructorInfo constructor = typeof(T).GetConstructor(new Type[] 
                    { 
                        typeof(SubscriptionCloudCredentials), 
                        typeof(string) 
                    });
            client = constructor.Invoke(new object[] 
                    { 
                        currentEnvironment.Credentials as SubscriptionCloudCredentials, 
                        
                        // Have to remove the https:// since this is a suffix
                        currentEnvironment.Endpoints.DataLakeStoreServiceUri.OriginalString.Replace("https://","") }) as T;

            return TestBase.AddMockHandler<T>(ref client);
        }
    }
}
