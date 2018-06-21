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
            Assert.True(string.Equals("Compute.Tests.HelpersTests", this.GetType().FullName));
            Assert.True(string.Equals("TestUtilityFunctions", TestUtilities.GetCurrentMethodName()));
        }
    }
}
