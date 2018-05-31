using System.Linq;
using Microsoft.AzureStack.Management.Storage.Admin;
using Microsoft.AzureStack.Management.Storage.Admin.Models;
using Xunit;

namespace Storage.Tests
{
    public class SharesTests : StorageTestBase
    {
        private void AssertAreEqual(Share expected, Share found) {
            if (expected == null)
            {
                Assert.NotNull(found);
            }
            else
            {
                ValidateShare(found);
                Assert.Equal(expected.FreeCapacity, found.FreeCapacity);
                Assert.Equal(expected.HealthStatus, found.HealthStatus);
                Assert.Equal(expected.Id, found.Id);
                Assert.Equal(expected.Location, found.Location);
                Assert.Equal(expected.Name, found.Name);
                Assert.Equal(expected.ShareName, found.ShareName);
                if (expected.Tags != null)
                {
                    Assert.NotNull(found.Tags);
                    foreach (var expectedTag in expected.Tags)
                    {
                        Assert.True(found.Tags.ContainsKey(expectedTag.Key));
                    }
                } else
                {
                    Assert.Null(found.Tags);
                }
                Assert.Equal(expected.TotalCapacity, found.TotalCapacity);
                Assert.Equal(expected.Type, found.Type);
                Assert.Equal(expected.UncPath, found.UncPath);
                Assert.Equal(expected.UsedCapacity, found.UsedCapacity);
            }
        }

        private void ValidateShare(Share share) {
            Assert.NotNull(share);
            Assert.NotNull(share.FreeCapacity);
            Assert.NotNull(share.HealthStatus);
            Assert.NotNull(share.Id);
            Assert.NotNull(share.Location);
            Assert.NotNull(share.Name);
            Assert.NotNull(share.ShareName);
            Assert.NotNull(share.TotalCapacity);
            Assert.NotNull(share.Type);
            Assert.NotNull(share.UncPath);
            Assert.NotNull(share.UsedCapacity);
        }

        [Fact]
        public void GetShare() {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var shares = client.Shares.List(ResourceGroupName, fName);
                    foreach (var share in shares)
                    {
                        var sName = ExtractName(share.Name);
                        var result = client.Shares.Get(ResourceGroupName, fName, sName);
                        AssertAreEqual(share, result);
                        return;
                    }
                }
            });
        }

        [Fact]
        public void GetAllShares() {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var shares = client.Shares.List(ResourceGroupName, fName);
                    foreach (var share in shares)
                    {
                        var sName = ExtractName(share.Name);
                        var result = client.Shares.Get(ResourceGroupName, fName, sName);
                        AssertAreEqual(share, result);
                    }
                }
            });
        }

        [Fact]
        public void ListShares() {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var shares = client.Shares.List(ResourceGroupName, fName);
                    shares.ForEach(ValidateShare);
                }
            });
        }

        [Fact]
        public void ListAllShareMetricDefinitions() {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var shares = client.Shares.List(ResourceGroupName, fName);
                    foreach (var share in shares)
                    {
                        var sName = ExtractName(share.Name);
                        var metricDefinitions = client.Shares.ListMetricDefinitions(ResourceGroupName, fName, sName);
                    }
                }
            });
        }


        [Fact]
        public void ListAllShareMetrics() {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var shares = client.Shares.List(ResourceGroupName, fName);
                    foreach (var share in shares)
                    {
                        var sName = ExtractName(share.Name);
                        var metrics = client.Shares.ListMetrics(ResourceGroupName, fName, sName);
                    }
                }
            });
        }
    }
}
