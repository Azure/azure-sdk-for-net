// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class RedisCache : Samples.Tests.TestBase
    {
        public RedisCache(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "RedisCache")]
        public void ManageRedisTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageRedis.Program.RunSample(rollUpClient);
            }
        }
    }
}
