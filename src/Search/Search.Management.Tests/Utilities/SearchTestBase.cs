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
using Microsoft.Azure.Test;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.Search.Tests.Utilities
{
    public abstract class SearchTestBase<TTestFixture> : TestBase where TTestFixture : new()
    {
        protected TTestFixture Data { get; private set; }

        protected static SearchManagementClient GetSearchManagementClient()
        {
            return GetServiceClient<SearchManagementClient>(new CSMTestEnvironmentFactory());
        }
        
        protected void Run(Action testBody)
        {
            const int TestNameStackFrameDepth = 4;
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start(TestNameStackFrameDepth);

                Data = new TTestFixture();

                Func<JsonSerializerSettings> oldDefault = JsonConvert.DefaultSettings;

                // This should ensure that the SDK doesn't depend on global JSON.NET settings.
                JsonConvert.DefaultSettings = () =>
                    new JsonSerializerSettings() { Converters = new[] { new InvalidJsonConverter() } };

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

        private class InvalidJsonConverter : JsonConverter
        {
            private const string ErrorMessage = "Some part of the SDK is using JsonConvert.DefaultSettings!";

            public override bool CanConvert(Type objectType)
            {
                throw new InvalidOperationException(ErrorMessage);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new InvalidOperationException(ErrorMessage);
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new InvalidOperationException(ErrorMessage);
            }
        }
    }
}
