// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.DataFactory;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Runtime.CompilerServices;

namespace DataFactory.Tests.ScenarioTests
{
    public abstract class ScenarioTestBase<T>
    {
        protected const string ResourceGroupName = "sdktesting";
        protected const string DataFactoryName = "sdktestingfactory";
        protected const string FactoryLocation = "East US 2";
        protected static string ClassName = typeof(T).FullName;

        protected void RunTest(Action<DataFactoryManagementClient> initialAction, Action<DataFactoryManagementClient> finallyAction = null, [CallerMemberName] string methodName = "")
        {
            using (MockContext mockContext = MockContext.Start(ClassName, methodName))
            {
                DataFactoryManagementClient client = mockContext.GetServiceClient<DataFactoryManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
                try
                {
                    initialAction.Invoke(client);
                }
                finally
                {
                    if (finallyAction != null)
                    {
                        finallyAction.Invoke(client);
                    }
                }
            }
        }
    }
}
