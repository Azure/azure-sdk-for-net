// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Fabric.Admin;
using Microsoft.AzureStack.Management.Fabric.Admin.Models;
using System;
using System.Linq;
using Xunit;

namespace Fabric.Tests {

    public class FileShareTests : FabricTestBase {
        private void AssertFileSharesEqual(FileShare expected, FileShare found) {
            if (expected == null) {
                Assert.Null(found);
            } else {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));

                Assert.Equal(expected.AssociatedVolume, found.AssociatedVolume);
                Assert.Equal(expected.UncPath, found.UncPath);
            }
        }

        private void ValidateFileShare(FileShare share) {
            FabricCommon.ValidateResource(share);
            Assert.NotNull(share.AssociatedVolume);
            Assert.NotNull(share.UncPath);
        }
        [Fact]
        public void TestListFileShares() {
            RunTest((client) => {
                var fileShares = client.FileShares.List(Location);

                Assert.NotNull(fileShares);
                Assert.True(fileShares.Count() > 0);
                fileShares.ForEach(ValidateFileShare);
                Common.WriteIEnumerableToFile(fileShares, "ListFileShares.txt", (fileShare) => fileShare.Name);
            });
        }

        [Fact]
        public void TestGetFileShare() {
            RunTest((client) => {
                var share = client.FileShares.List(Location).First();
                if (share != null) {
                    var retrieved = client.FileShares.Get(Location, share.Name);
                    AssertFileSharesEqual(share, retrieved);
                }
            });
        }

        [Fact]
        public void TestGetAllFileShares() {
            RunTest((client) => {
                var fileShares = client.FileShares.List(Location);
                Assert.NotNull(fileShares);
                fileShares.ForEach(((share) => {
                    var retrieved = client.FileShares.Get(Location, share.Name);
                    AssertFileSharesEqual(share, retrieved);
                }));
            });
        }

    }
}
