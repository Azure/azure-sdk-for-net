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
using Microsoft.Azure.Management.Search;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.Search.Tests.Utilities
{
    public abstract class SearchTestBase<TTestFixture> : TestBase where TTestFixture : IResourceFixture, new()
    {
        private const string JsonErrorMessage = "Some part of the SDK is using JsonConvert.DefaultSettings!";

        private MockContext _currentContext; // Changes as each test runs.

        protected TTestFixture Data { get; private set; }

        protected SearchManagementClient GetSearchManagementClient()
        {
            if (_currentContext == null)
            {
                throw new InvalidOperationException("GetSearchManagementClient() can only be called from a running test.");
            }

            return _currentContext.GetServiceClient<SearchManagementClient>();
        }
        
        protected void Run(Action testBody)
        {
            const int TestNameStackFrameDepth = 3;
            using (var mockContext = MockContext.Start(TestNameStackFrameDepth))
            {
                _currentContext = mockContext;
                Data = new TTestFixture();
                Data.Initialize(mockContext);

                Func<JsonSerializerSettings> oldDefault = JsonConvert.DefaultSettings;

                // This should ensure that the SDK doesn't depend on global JSON.NET settings.
                JsonConvert.DefaultSettings = () =>
                    new JsonSerializerSettings() 
                    {
                        // TODO: Bring this back once AutoRest stops using JsonConvert directly.
                        // See GitHub issue: https://github.com/Azure/autorest/issues/372
                        //Converters = new[] { new InvalidJsonConverter() },
                        ContractResolver = new InvalidContractResolver()
                    };

                try
                {
                    testBody();
                }
                finally
                {
                    JsonConvert.DefaultSettings = oldDefault;
                }
            }
        }

        private class InvalidContractResolver : IContractResolver
        {
            public JsonContract ResolveContract(Type type)
            {
                throw new InvalidOperationException(JsonErrorMessage);
            }
        }

        // TODO: Bring this back once AutoRest stops using JsonConvert directly.
        // See GitHub issue: https://github.com/Azure/autorest/issues/372
        /*private class InvalidJsonConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                throw new InvalidOperationException(JsonErrorMessage);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new InvalidOperationException(JsonErrorMessage);
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new InvalidOperationException(JsonErrorMessage);
            }
        }*/
    }
}
