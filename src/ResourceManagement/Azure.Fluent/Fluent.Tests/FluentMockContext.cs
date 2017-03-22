// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Runtime.CompilerServices;

namespace Azure.Tests
{
    public class FluentMockContext : IDisposable
    {
        public MockContext mockContext { get; private set; }
        public static FluentMockContext Start(string className, [CallerMemberName] string methodName = "testframework_failed")
        {
            var fluentMockContext = new FluentMockContext();
            fluentMockContext.mockContext = MockContext.Start(className, methodName);

            SdkContext.CreateResourceNamer = new SdkContext.ResourceNamerCreator((name) => new TestResourceNamer(name, methodName));
            SdkContext.AzureCredentialsFactory = new TestAzureCredentialsFactory();
            SdkContext.DelayProvider = new TestDelayProvider();

            return fluentMockContext;
        }

        public void Dispose()
        {
            mockContext.Dispose();
        }
    }
}
