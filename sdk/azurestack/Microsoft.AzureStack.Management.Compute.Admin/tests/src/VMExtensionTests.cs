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
    public class VMExtensionTests : ComputeTestBase
    {

        private string publisher = "Microsoft";
        private string type = "MicroExtension";
        private string version = "0.2.0";

        // Helper
        private VMExtensionParameters Create() {
            return new VMExtensionParameters()
            {
                ComputeRole = "N/A",
                VmScaleSetEnabled = false,
                SourceBlob = new AzureBlob("https://test.blob.local.azurestack.external/test/Microsoft.Powershell.DSC_2.19.0.0.zip"),
                IsSystemExtension = false,
                SupportMultipleExtensions = true,
                VmOsType = OsType.Linux
            };
        }


        private void ValidateVMExtension(VMExtension image) {
            //AssertValidResource(image);
            Assert.NotNull(image);
        }

        private void AssertSame(VMExtension expected, VMExtension given, bool resourceToo = true) {
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
                Assert.Equal(expected.ComputeRole, given.ComputeRole);
                Assert.Equal(expected.IsSystemExtension, given.IsSystemExtension);
                Assert.Equal(expected.ProvisioningState, given.ProvisioningState);
                Assert.Equal(expected.SupportMultipleExtensions, given.SupportMultipleExtensions);
                Assert.Equal(expected.VmOsType, given.VmOsType);
                Assert.Equal(expected.VmScaleSetEnabled, given.VmScaleSetEnabled);
            }
        }

        [Fact]
        public void TestListVMExtensions() {
            RunTest((client) => {
                var list = client.VMExtensions.List("local");
                list.ForEach(ValidateVMExtension);
            });
        }

        [Fact]
        public void TestGetVMExtension() {
            RunTest((client) => {
                var ext = client.VMExtensions.List("local").First();
                var parts = ext.Id.Split(new[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
                var publisher = parts[9];
                var type = parts[11];
                var version = parts[13];
                var result = client.VMExtensions.Get("local", publisher, type, version);
                AssertSame(ext, result);
            });
        }

        [Fact]
        public void TestGetAllVMExtensions() {
            RunTest((client) => {
                var exts = client.VMExtensions.List("local");
                exts.ForEach((ext) => {
                    var parts = ext.Id.Split(new[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
                    var publisher = parts[9];
                    var type = parts[11];
                    var version = parts[13];
                    var result = client.VMExtensions.Get("local", publisher, type, version);
                    AssertSame(ext, result);
                });
            });
        }

        [Fact]

        public void TestCreateAndDeleteVMExtension() {
            RunTest((client) => {
                // Setup
                var extension = client.VMExtensions.Create(Location, publisher, type, version, Create());

                untilFalse(() => client.VMExtensions.Get(Location, publisher, type, version).ProvisioningState == ProvisioningState.Creating);

                // Do
                client.VMExtensions.Delete(Location, publisher, type, version);

                // Validate
                ValidateExpectedReturnCode(
                    () => client.VMExtensions.Get(Location, publisher, type, version),
                    HttpStatusCode.NotFound
                    );
            });
        }

        [Fact]
        public void TestCreateUpdateVMExtension() {
            void setupCleanup() {
                IgnoreExceptions(() => client.VMExtensions.Delete(Location, publisher, type, version));
            };

            RunTest((client) => {
                IgnoreExceptions(() => client.VMExtensions.Delete(Location, publisher, type, version));

                var c = Create();
                var extension = client.VMExtensions.Create(Location, publisher, type, version, c);

                untilFalse(() => client.VMExtensions.Get(Location, publisher, type, version).ProvisioningState == ProvisioningState.Creating);

                c.SupportMultipleExtensions = false;
                c.VmScaleSetEnabled= true;
                c.VmOsType= OsType.Windows;
                var updated = client.VMExtensions.Create(Location, publisher, type, version, c);

                Assert.True(updated.SupportMultipleExtensions);
                Assert.False(updated.VmScaleSetEnabled);
                Assert.Equal<OsType?>(OsType.Linux, updated.VmOsType);

            }, setupCleanup, setupCleanup);
        }
    }
}
