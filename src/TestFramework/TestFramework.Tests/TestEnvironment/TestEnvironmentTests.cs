// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace TestFramework.Tests.TestEnvironment
{
    using Xunit;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class TestEnvironmentTests
    {
        [Fact]
        public void EmptyTestEnvironment()
        {
            TestEnvironment env = new TestEnvironment();
            Assert.Equal<int>(4, env.EnvEndpoints.Count);
        }
    }
}
