using System.Linq;
using Microsoft.AzureStack.Management.Storage.Admin;
using Microsoft.AzureStack.Management.Storage.Admin.Models;
using Xunit;

namespace Storage.Tests
{
    public class ContainersTests : StorageTestBase
    {

        private void ValidateContainer(Container container) {
            Assert.NotNull(container);
            Assert.NotNull(container.Accountid);
            Assert.NotNull(container.Accountname);
            Assert.NotNull(container.Containerid);
            Assert.NotNull(container.Containername);
            Assert.NotNull(container.ContainerState);
            Assert.NotNull(container.Sharename);
            Assert.NotNull(container.UsedBytesInPrimaryVolume);
        }

        private void ValidateDestinationShare(Share share)
        {
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
        public void ListContainers()
        {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach(var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var shares = client.Shares.List(ResourceGroupName, fName);
                    foreach(var share in shares)
                    {
                        var sName = ExtractName(share.Name);
                        var intent = "Migration";
                        var containers = client.Containers.List(ResourceGroupName, fName, sName, intent, 10, 0);
                        containers.ForEach(ValidateContainer);
                    }
                }
            });
        }
        
        [Fact]
        public void ListDestinationShares()
        {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var shares = client.Shares.List(ResourceGroupName, fName);
                    foreach (var share in shares)
                    {
                        var sName = ExtractName(share.Name);
                        var destinationShares = client.Containers.ListDestinationShares(ResourceGroupName, fName, sName);
                        destinationShares.ForEach(ValidateDestinationShare);
                    }
                }
            });
        }

        [Fact(Skip = "No way to migrate a share currently.")]
        public void MigrateThenCancelShare()
        {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var shares = client.Shares.List(ResourceGroupName, fName);
                    foreach (var share in shares)
                    {
                        var shareName = "";
                        var storageAccountName = "";
                        var containerName= "";
                        var destinationShareUNCPath= "";
                        var migrationParameters = new MigrationParameters(storageAccountName, containerName, destinationShareUNCPath);
                        var operationId = client.Containers.Migrate(ResourceGroupName, fName, shareName, migrationParameters);
                        client.Containers.CancelMigration(ResourceGroupName, fName, operationId.JobId);
                    }
                }
            });
        }
    }
}
