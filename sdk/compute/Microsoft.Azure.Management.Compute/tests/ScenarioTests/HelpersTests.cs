// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests
{
    public class HelpersTests
    {
        [Fact]
        public void TestUtilityFunctions()
        {
            Assert.Equal("Compute.Tests.HelpersTests", this.GetType().FullName);
#if NET46
            Assert.Equal("TestUtilityFunctions", TestUtilities.GetCurrentMethodName(1));
#else
            Assert.Equal("TestUtilityFunctions", TestUtilities.GetCurrentMethodName());
#endif
        }
    }
}

