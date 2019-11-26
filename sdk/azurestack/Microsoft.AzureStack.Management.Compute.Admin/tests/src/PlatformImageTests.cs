// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Compute.Admin;
using Microsoft.AzureStack.Management.Compute.Admin.Models;
using System.Net;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class PlatformImageTests : ComputeTestBase
    {
        private const string VHDUri = "https://test.blob.local.azurestack.external/test/xenial-server-cloudimg-amd64-disk1.vhd";
        private const string TinyVHD = "https://test.blob.local.azurestack.external/test/tiny.vhd";
        private const string MediumVHD = "https://test.blob.local.azurestack.external/test/medium.vhd";

        // Helper
        private PlatformImageParameters Create(string URI = VHDUri) {
            return new PlatformImageParameters()
            {
                OsDisk = new OsDisk()
                {
                    OsType = OsType.Linux,
                    Uri = URI
                }
            };
        }


        private void ValidatePlatformImage(PlatformImage image) {
            Assert.NotNull(image.Id);
            Assert.NotNull(image.Type);
            Assert.NotNull(image.Location);

            Assert.NotNull(image);
            Assert.NotNull(image.OsDisk);
            Assert.NotNull(image.ProvisioningState);
        }

        private void AssertSame(PlatformImage expected, PlatformImage given, bool resourceToo = true) {
            if (resourceToo)
            {
                AssertSameResource(expected, given);
            }
            if (expected == null)
            {
                Assert.Null(given);
            }
            else
            {
                Assert.NotNull(given);
            }
        }

        [Fact]
        public void TestListPlatformImages() {
            RunTest((client) => {
                var platformImages = client.PlatformImages.List("local");
                platformImages.ForEach(ValidatePlatformImage);
            });
        }

        [Fact]
        public void TestGetPlatformImage() {
            RunTest((client) => {
                var platformImage = client.PlatformImages.List("local").FirstOrDefault();
                if (platformImage != null)
                {
                    var items = platformImage.Id.Split(new[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
                    var publisher = items[9];
                    var offer = items[11];
                    var sku = items[13];
                    var version = items[15];
                    client.PlatformImages.Get("local", publisher, offer, sku, version);
                }
            });
        }

        [Fact]
        public void TestGetAllPlatformImages() {
            RunTest((client) => {
                var platformImages = client.PlatformImages.List("local");
                platformImages.ForEach((platformImage) => {
                    var items = platformImage.Id.Split(new[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
                    var publisher = items[9];
                    var offer = items[11];
                    var sku = items[13];
                    var version = items[15];
                    client.PlatformImages.Get("local", publisher, offer, sku, version);
                });
            });
        }

        [Fact]
        public void TestCreateAndDeletePlatformImage() {
            RunTest((client) => {

                var Location = "local";
                var Publisher = "Test";
                var Offer = "UbuntuServer";
                var Sku = "16.04-LTS";
                var Version = "1.0.0";

                DeletePlatformImage(client, Location, Publisher, Offer, Sku, Version);

                // Create
                var image = client.PlatformImages.Create(Location, Publisher, Offer, Sku, Version, Create(TinyVHD));
                Assert.NotNull(image);
                Assert.Equal(TinyVHD, image.OsDisk.Uri);

                untilFalse(() => client.PlatformImages.Get(Location, Publisher, Offer, Sku, Version).ProvisioningState == ProvisioningState.Creating);

                var result = client.PlatformImages.Get(Location, Publisher, Offer, Sku, Version);
                Assert.Equal(ProvisioningState.Succeeded, result.ProvisioningState);

                // Delete
                client.PlatformImages.Delete(Location, Publisher, Offer, Sku, Version);
                ValidateExpectedReturnCode(
                    () => client.PlatformImages.Get(Location, Publisher, Offer, Sku, Version),
                    HttpStatusCode.NotFound
                    );
            });
        }

        [Fact]
        public void TestCreateUpdatePlatformImage() {
            RunTest((client) => {

                var Location = "local";
                var Publisher = "Test";
                var Offer = "UbuntuServer";
                var Sku = "16.04-LTS";
                var Version = "1.0.0";

                DeletePlatformImage(client, Location, Publisher, Offer, Sku, Version);

                // Create
                var image = client.PlatformImages.Create(Location, Publisher, Offer, Sku, Version, Create(MediumVHD));
                Assert.NotNull(image);
                Assert.Equal(MediumVHD, image.OsDisk.Uri);

                untilFalse(() => client.PlatformImages.Get(Location, Publisher, Offer, Sku, Version).ProvisioningState == ProvisioningState.Creating);

                var result = client.PlatformImages.Get(Location, Publisher, Offer, Sku, Version);
                Assert.Equal(ProvisioningState.Succeeded, result.ProvisioningState);

                var tinyImage = client.PlatformImages.Create(Location, Publisher, Offer, Sku, Version, Create(TinyVHD));
                untilFalse(() => client.PlatformImages.Get(Location, Publisher, Offer, Sku, Version).ProvisioningState == ProvisioningState.Creating);

                Assert.Equal(MediumVHD, tinyImage.OsDisk.Uri);

                // Delete
                client.PlatformImages.Delete(Location, Publisher, Offer, Sku, Version);
                ValidateExpectedReturnCode(
                    () => client.PlatformImages.Get(Location, Publisher, Offer, Sku, Version),
                    HttpStatusCode.NotFound
                    );
            });
        }
    }
}
