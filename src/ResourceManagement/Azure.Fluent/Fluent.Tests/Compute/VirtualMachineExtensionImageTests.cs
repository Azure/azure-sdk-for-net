// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System;
using System.Linq;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;

namespace Fluent.Tests.Compute
{
    public class VirtualMachineExtensionImageTests
    {
        [Fact]
        public void CanListExtensionImages()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();
                int maxListing = 20;
                var extensionImages = azure.VirtualMachineExtensionImages
                                .ListByRegion(Region.US_EAST);
                // Lazy listing
                var firstTwenty = extensionImages.Take(maxListing);
                Assert.Equal(firstTwenty.Count(), maxListing);
                Assert.False(firstTwenty.Any(image => image == null));
            }
        }


        [Fact]
        public void CanGetExtensionTypeVersionAndImage()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
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

                IVirtualMachinePublisher azureDockerExtensionPublisher = publishers
                    .Where(publisher => publisher.Name.Equals(dockerExtensionPublisherName, StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault();
                Assert.NotNull(azureDockerExtensionPublisher);

                // Lookup Azure docker extension type
                //
                var extensionImageTypes = azureDockerExtensionPublisher.ExtensionTypes;
                Assert.True(extensionImageTypes.List().Count() > 0);
                var dockerExtensionImageType = extensionImageTypes
                    .List()
                    .Where(imageType => imageType.Name.Equals(dockerExtensionImageTypeName, StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault();
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

                IVirtualMachineExtensionImageVersion extensionImageFirstVersion = extensionImageVersions.List().FirstOrDefault();
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
}
