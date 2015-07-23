// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace HttpRecorder.Tests
{
    public class UtilitiesTests
    {
        [Fact]
        public void GetCurrentMethodNameReturnsName()
        {
            Assert.Equal("GetCurrentMethodNameReturnsName", TestUtilities.GetCurrentMethodName(1));
        }

        [Fact]
        public void GetCurrentMethodNameReturnsNameWithIndex()
        {
            Assert.Equal("GetCurrentMethodNameReturnsNameWithIndex", GetName());
        }

        private string GetName()
        {
            return TestUtilities.GetCurrentMethodName(2);
        }
    }
}
