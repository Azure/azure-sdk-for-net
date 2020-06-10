// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace AVS.Tests
{
    public class AvsTests : TestBase
    {
        [Fact]
        public void CustomProvider_CRUD()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testFixture = new AvsTestBase(context))
                {
                    var client = testFixture.AvsClient;
                    var clouds = client.PrivateClouds.ListByResourceGroup();
                    Assert.True(clouds.Count() == 0);
                }
            }
        }
    }
}


