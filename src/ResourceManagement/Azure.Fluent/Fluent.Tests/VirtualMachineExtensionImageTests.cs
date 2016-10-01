using Fluent.Tests;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Fluent.Compute;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests
{
    public class VirtualMachineExtensionImageTests
    {
        [Fact]
        public void CanListExtensionImages()
        {
            var azure = TestHelper.CreateRollupClient();
            int maxListing = 20;
            int count = 0;
            var extensionImages = azure.VirtualMachineExtensionImages
                            .ListByRegion(Region.US_EAST);
            // Lazy listing
            foreach (var extensionImage in extensionImages)
            {
                Assert.NotNull(extensionImage);
                count++;
                if (count >= maxListing)
                {
                    break;
                }
            }
            Assert.True(count == maxListing);
        }


        [Fact]
        public void CanGetExtensionTypeVersionAndImage()
        {
            var azure = TestHelper.CreateRollupClient();
            var extensionImages =
                    azure.VirtualMachineExtensionImages
                            .ListByRegion(Region.US_EAST);

            string dockerExtensionPublisherName = "Microsoft.Azure.Extensions";
            string dockerExtensionImageTypeName = "DockerExtension";

            // Lookup Azure docker extension publisher
            //
            var publishers =
                    azure.VirtualMachineExtensionImages
                            .Publishers
                            .ListByRegion(Region.US_EAST);

            IVirtualMachinePublisher azureDockerExtensionPublisher = null;
            foreach (var publisher in publishers)
            {
                if (publisher.Name.Equals(dockerExtensionPublisherName, StringComparison.OrdinalIgnoreCase))
                {
                    azureDockerExtensionPublisher = publisher;
                    break;
                }
            }
            Assert.NotNull(azureDockerExtensionPublisher);

            // Lookup Azure docker extension type
            //
            var extensionImageTypes = azureDockerExtensionPublisher.ExtensionTypes;
            Assert.True(extensionImageTypes.List().Count() > 0);

            IVirtualMachineExtensionImageType dockerExtensionImageType = null;
            foreach (var extensionImageType in extensionImageTypes.List())
            {
                if (extensionImageType.Name.Equals(dockerExtensionImageTypeName, StringComparison.OrdinalIgnoreCase))
                {
                    dockerExtensionImageType = extensionImageType;
                    break;
                }
            }
            Assert.NotNull(dockerExtensionImageType);

            Assert.NotNull(dockerExtensionImageType.Id);
            Assert.True(dockerExtensionImageType.Name.Equals(dockerExtensionImageTypeName, StringComparison.OrdinalIgnoreCase));
            Assert.True(dockerExtensionImageType.RegionName.Equals("eastus", StringComparison.OrdinalIgnoreCase));
            Assert.True(dockerExtensionImageType.Id
                    .ToLower()
                    .EndsWith("/Providers/Microsoft.Compute/Locations/eastus/Publishers/Microsoft.Azure.Extensions/ArtifactTypes/VMExtension/Types/DockerExtension".ToLower()));
            Assert.NotNull(dockerExtensionImageType.Publisher);
            Assert.True(dockerExtensionImageType.Publisher.Name.Equals(dockerExtensionPublisherName, StringComparison.OrdinalIgnoreCase));

            // Fetch Azure docker extension versions
            //
            var extensionImageVersions = dockerExtensionImageType.Versions;
            Assert.True(extensionImageVersions.List().Count() > 0);

            IVirtualMachineExtensionImageVersion extensionImageFirstVersion = null;
            foreach (var extensionImageVersion in extensionImageVersions.List())
            {
                extensionImageFirstVersion = extensionImageVersion;
                break;
            }

            Assert.NotNull(extensionImageFirstVersion);
            String versionName = extensionImageFirstVersion.Name;
            Assert.True(extensionImageFirstVersion.Id
                    .ToLower()
                    .EndsWith(("/Providers/Microsoft.Compute/Locations/eastus/Publishers/Microsoft.Azure.Extensions/ArtifactTypes/VMExtension/Types/DockerExtension/Versions/" + versionName).ToLower()));
            Assert.NotNull(extensionImageFirstVersion.Type);

            // Fetch the Azure docker extension image
            //
            var dockerExtensionImage = extensionImageFirstVersion.GetImage();

            Assert.True(dockerExtensionImage.RegionName.Equals("eastus", StringComparison.OrdinalIgnoreCase));
            Assert.True(dockerExtensionImage.PublisherName.Equals(dockerExtensionPublisherName, StringComparison.OrdinalIgnoreCase));
            Assert.True(dockerExtensionImage.TypeName.Equals(dockerExtensionImageTypeName, StringComparison.OrdinalIgnoreCase));
            Assert.True(dockerExtensionImage.VersionName.Equals(versionName, StringComparison.OrdinalIgnoreCase));
            Assert.True(dockerExtensionImage.OsType == OperatingSystemTypes.Linux || dockerExtensionImage.OsType == OperatingSystemTypes.Windows);
        }
    }
}
