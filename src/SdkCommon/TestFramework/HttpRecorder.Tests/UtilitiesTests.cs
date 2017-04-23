// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace HttpRecorder.Tests
{
    [Collection("SerialCollection1")]
    public class UtilitiesTests
    {
        [Fact]
        public void GetCurrentMethodNameReturnsName()
        {
            Assert.Equal("GetCurrentMethodNameReturnsName", TestUtilities.GetCurrentMethodName());
        }
    }
}
