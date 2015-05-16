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
using Microsoft.Azure.Search.Tests.Utilities;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Test;

namespace Microsoft.Azure.Search.Tests
{
    public static class SearchServiceFixtureExtensions
    {
        public static SearchServiceClient GetSearchServiceClient(this SearchServiceFixture fixture)
        {
            var factory = new CSMTestEnvironmentFactory();
            TestEnvironment currentEnvironment = factory.GetTestEnvironment();
            Uri baseUri = currentEnvironment.GetBaseSearchUri(ExecutionMode.CSM, fixture.SearchServiceName);

            SearchServiceClient client =
                new SearchServiceClient(new SearchCredentials(fixture.PrimaryApiKey), baseUri);

            return TestBaseCopy.AddMockHandler<SearchServiceClient>(ref client);
        }
    }
}
