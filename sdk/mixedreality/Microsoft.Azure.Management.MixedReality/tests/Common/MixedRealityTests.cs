// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics;
using Microsoft.Azure.Management.MixedReality;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace MixedReality.Tests
{
    public abstract class MixedRealityTests
    {
        private bool initialized = false;
        private object o = new object();

        protected ResourceManagementClient ArmClient { get; private set; }
        protected MixedRealityClient Client { get; private set; }

        protected MockContext StartTest()
        {
            var frame = new StackTrace().GetFrame(1);
            var callingClassType = frame.GetMethod().ReflectedType;
            var callingMethodName = frame.GetMethod().Name;

            var context = MockContext.Start(callingClassType, callingMethodName);

            EnsureClientsInitialized(context);

            return context;
        }

        private void EnsureClientsInitialized(MockContext context)
        {
            if (initialized == false)
            {
                lock (o)
                {
                    if (initialized == false)
                    {
                        var environment = TestEnvironmentFactory.GetTestEnvironment();

                        ArmClient = context.GetServiceClient<ResourceManagementClient>();

                        Client = context.GetServiceClient<MixedRealityClient>(environment);

                        initialized = true;
                    }
                }
            }
        }
    }
}
