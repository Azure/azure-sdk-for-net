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

                testBody();
            }
        }
    }
}
