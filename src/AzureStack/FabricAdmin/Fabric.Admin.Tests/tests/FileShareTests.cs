

using System;
using System.Linq;

using Xunit;

using Microsoft.AzureStack.TestFramework;

using Microsoft.AzureStack.Management.Fabric.Admin;
using Microsoft.AzureStack.Management.Fabric.Admin.Models;

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
                Assert.True(Common.CountElements(fileShares) > 0);

                Common.MapOverIEnumerable(fileShares, ValidateFileShare);
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
                Common.MapOverIEnumerable(fileShares, ((share) => {
                    var retrieved = client.FileShares.Get(Location, share.Name);
                    AssertFileSharesEqual(share, retrieved);
                }));
            });
        }

    }
}
