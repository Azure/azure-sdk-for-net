// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AVS;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System.Linq;

namespace Avs.Tests
{
    public class AvsTests : TestBase
    {
        [Fact]
        public void AvsCrud()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var testBase = new AvsTestBase(context))
                {
                    var client = testBase.AvsClient;
                    var clouds = client.PrivateClouds.List("myrg");
                    Assert.True(clouds.Count() == 0);
                }
            }
        }
    }
}


