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

namespace Microsoft.Azure.Search.Tests.Utilities
{
    public abstract class SearchTestBase<TTestFixture> : TestBase where TTestFixture : IResourceFixture, new()
    {
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
                testBody();
            }
        }
    }
}
