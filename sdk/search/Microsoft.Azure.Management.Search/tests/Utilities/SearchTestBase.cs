// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests.Utilities
{
    using System;
    using System.Runtime.CompilerServices;
    using Microsoft.Azure.Management.Search;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

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
        
        protected void Run(
            Action testBody, 
            [CallerMemberName]
            string methodName = "unknown_caller")
        {
            using (var mockContext = MockContext.Start(this.GetType(), methodName))
            {
                _currentContext = mockContext;
                Data = new TTestFixture();
                Data.Initialize(mockContext);

                try
                {
                    testBody();
                }
                finally
                {
                    Data.Cleanup();
                }
            }
        }
    }
}
