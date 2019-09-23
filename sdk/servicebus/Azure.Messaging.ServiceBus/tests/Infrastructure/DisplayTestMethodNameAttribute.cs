// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.UnitTests
{
    using System.Reflection;
    using Microsoft.Extensions.PlatformAbstractions;
    using Xunit.Sdk;

    public class DisplayTestMethodNameAttribute : BeforeAfterTestAttribute
    {
        public override void Before(MethodInfo methodUnderTest)
        {
            TestUtility.Log($"Begin {methodUnderTest.DeclaringType}.{methodUnderTest.Name} on {PlatformServices.Default.Application.RuntimeFramework}");
            base.Before(methodUnderTest);
        }

        public override void After(MethodInfo methodUnderTest)
        {
            TestUtility.Log($"End {methodUnderTest.DeclaringType}.{methodUnderTest.Name}");
            base.After(methodUnderTest);
        }
    }
}