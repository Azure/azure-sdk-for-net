// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests
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