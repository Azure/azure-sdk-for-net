// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests.Utilities
{
    using System;
    using System.Runtime.CompilerServices;
    using Microsoft.Azure.Management.Search;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

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
        
        protected void Run(
            Action testBody, 
            [CallerMemberName]
            string methodName = "unknown_caller")
        {
            using (var mockContext = MockContext.Start(this.GetType().FullName, methodName))
            {
                _currentContext = mockContext;
                Data = new TTestFixture();
                Data.Initialize(mockContext);

                Func<JsonSerializerSettings> oldDefault = JsonConvert.DefaultSettings;

                // This should ensure that the SDK doesn't depend on global JSON.NET settings.
                JsonConvert.DefaultSettings = () =>
                    new JsonSerializerSettings() 
                    {
                        Converters = new[] { new InvalidJsonConverter() },
                        ContractResolver = new InvalidContractResolver()
                    };

                try
                {
                    testBody();
                }
                finally
                {
                    Data.Cleanup();
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

        private class InvalidJsonConverter : JsonConverter
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
        }
    }
}
