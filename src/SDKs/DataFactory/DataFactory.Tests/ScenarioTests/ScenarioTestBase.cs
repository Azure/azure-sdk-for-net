// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xunit;

namespace DataFactory.Tests.ScenarioTests
{
    public abstract class ScenarioTestBase<T>
    {
        protected const string ResourceGroupName = "sdktesting";
        protected const string DataFactoryName = "sdktestingfactory";
        protected const string FactoryLocation = "East US 2";
        protected static string ClassName = typeof(T).FullName;

        protected DataFactoryManagementClient Client { get; private set; }

        protected async Task RunTest(Func<DataFactoryManagementClient, Task> initialAction, Func<DataFactoryManagementClient, Task> finallyAction, [CallerMemberName] string methodName = "")
        {
            using (MockContext mockContext = MockContext.Start(ClassName, methodName))
            {
                this.Client = mockContext.GetServiceClient<DataFactoryManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
                try
                {
                    await initialAction(this.Client);
                }
                finally
                {
                    if (finallyAction != null)
                    {
                        await finallyAction(this.Client);
                    }
                }
            }
        }

        protected void ValidateSubResource(SubResource actual, string expectedName, string expectedSubResourceType)
        {
            string expectedResourceID = $"/subscriptions/{this.Client.SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.DataFactory/factories/{DataFactoryName}/{expectedSubResourceType}/{expectedName}";
            Assert.Equal(expectedResourceID, actual.Id);
            Assert.Equal(expectedName, actual.Name);
            Assert.NotNull(actual.Etag);
        }
    }
}
