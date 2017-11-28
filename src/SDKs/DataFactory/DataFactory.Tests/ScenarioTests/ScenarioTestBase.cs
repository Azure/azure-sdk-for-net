﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xunit;

namespace DataFactory.Tests.ScenarioTests
{
    public abstract class ScenarioTestBase<T>
    {
        private const string ResourceGroupNamePrefix = "sdktestingadfrg";
        protected const string DataFactoryNamePrefix = "sdktestingfactory";
        protected const string FactoryLocation = "East US 2";
        protected static string ClassName = typeof(T).FullName;

        protected string ResourceGroupName { get; private set; }
        protected string DataFactoryName { get; private set; }

        protected DataFactoryManagementClient Client { get; private set; }

        protected async Task RunTest(Func<DataFactoryManagementClient, Task> initialAction, Func<DataFactoryManagementClient, Task> finallyAction, [CallerMemberName] string methodName = "")
        {
            using (MockContext mockContext = MockContext.Start(ClassName, methodName))
            {
                this.ResourceGroupName = TestUtilities.GenerateName(ResourceGroupNamePrefix);
                this.DataFactoryName = TestUtilities.GenerateName(DataFactoryNamePrefix);
                this.Client = mockContext.GetServiceClient<DataFactoryManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
                ResourceManagementClient resourceManagementClient = mockContext.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());

                try
                {
                    resourceManagementClient.ResourceGroups.CreateOrUpdate(this.ResourceGroupName, new ResourceGroup() { Location = FactoryLocation });
                    await initialAction(this.Client);
                }
                finally
                {
                    if (finallyAction != null)
                    {
                        await finallyAction(this.Client);
                    }

                    resourceManagementClient.ResourceGroups.Delete(this.ResourceGroupName);
                }
            }
        }

        protected void ValidateSubResource(Microsoft.Azure.Management.DataFactory.Models.SubResource actual, string expectedDataFactoryName, string expectedName, string expectedSubResourceType)
        {
            string expectedResourceID = $"/subscriptions/{this.Client.SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.DataFactory/factories/{expectedDataFactoryName}/{expectedSubResourceType}/{expectedName}";
            Assert.Equal(expectedResourceID, actual.Id);
            Assert.Equal(expectedName, actual.Name);
            Assert.NotNull(actual.Etag);
        }
    }
}
