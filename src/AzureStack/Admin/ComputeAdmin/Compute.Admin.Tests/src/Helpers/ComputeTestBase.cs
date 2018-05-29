// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Compute.Admin;
using Microsoft.AzureStack.Management.Compute.Admin.Models;
using Xunit;

namespace Compute.Tests
{

    public class ComputeTestBase : AzureStackTestBase<ComputeAdminClient>
    {
        public ComputeTestBase() {
            // Empty
        }

        private static int sleepTime = 30 * 1000; // for live runs

        protected void untilFalse(System.Func<bool> func) {
            while (func()) System.Threading.Thread.Sleep(sleepTime);
        }

        protected void AssertValidResource(Resource resource) {
            Assert.NotNull(resource);
            Assert.NotNull(resource.Id);
            Assert.NotNull(resource.Location);
            Assert.NotNull(resource.Name);
            Assert.NotNull(resource.Type);
        }

        protected void AssertSameResource(Resource expected, Resource found) {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.NotNull(found);
                Assert.Equal(expected.Id, found.Id);
                Assert.Equal(expected.Location, found.Location);
                Assert.Equal(expected.Name, found.Name);
                Assert.Equal(expected.Type, found.Type);
            }
        }

        protected void DeletePlatformImage(ComputeAdminClient client, string Location, string Publisher, string Offer, string Sku, string Version) {
            Common.RetryExceptionExpected(() =>
                client.PlatformImages.Delete(Location, Publisher, Offer, Sku, Version), 1);
        }

        protected override void ValidateClient(ComputeAdminClient client) {
            // validate creation
            Assert.NotNull(client);

            // validate objects
            Assert.NotNull(client.PlatformImages);
            Assert.NotNull(client.Quotas);
            Assert.NotNull(client.PlatformImages);
            Assert.NotNull(client.VMExtensions);
        }
    }
}
