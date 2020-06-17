// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class ExtImgTests:ComputeClientBase
    {
        public ExtImgTests(bool isAsync)
           : base(isAsync)
        {
        }
        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        private class VirtualMachineExtensionImageGetParameters
        {
            public string Location = "westus";
            public string PublisherName = "Microsoft.Compute";
            public string Type = "VMAccessAgent";
            public string FilterExpression = "";
        }

        private static readonly string existingVersion = "2.4.5";
        private static readonly VirtualMachineExtensionImageGetParameters parameters =
            new VirtualMachineExtensionImageGetParameters();

        [Test]
        public async Task TestExtImgGet()
        {
            var vmimageext = await VirtualMachineExtensionImagesOperations.GetAsync(
                parameters.Location,
                parameters.PublisherName,
                parameters.Type,
                existingVersion);

            Assert.True(vmimageext.Value.Name == existingVersion);
            Assert.True(vmimageext.Value.Location == "westus");

            Assert.True(vmimageext.Value.OperatingSystem == "Windows");
            Assert.True(vmimageext.Value.ComputeRole == "IaaS");
            Assert.True(vmimageext.Value.HandlerSchema == null);
            Assert.True(vmimageext.Value.VmScaleSetEnabled == false);
            Assert.True(vmimageext.Value.SupportsMultipleExtensions == false);
        }

        [Test]
        public async Task TestExtImgListTypes()
        {
            var vmextimg =await VirtualMachineExtensionImagesOperations.ListTypesAsync(
                parameters.Location,
                parameters.PublisherName);
            Assert.True(vmextimg.Value.Count > 0);
            Assert.True(vmextimg.Value.Count(vmi => vmi.Name == "VMAccessAgent") != 0);
        }

        [Test]
        public async Task TestExtImgListVersionsNoFilter()
        {
            var vmextimg = await VirtualMachineExtensionImagesOperations.ListVersionsAsync(
                parameters.Location,
                parameters.PublisherName,
                parameters.Type);

            Assert.True(vmextimg.Value.Count > 0);
            Assert.True(vmextimg.Value.Count(vmi => vmi.Name == existingVersion) != 0);
        }

        [Test]
        [Ignore("TRACK2: compute team will help to record because of different provided version of different locations and subscriptions")]
        public async Task TestExtImgListVersionsFilters()
        {
            string existingVersionPrefix = existingVersion.Substring(0, existingVersion.LastIndexOf('.'));

            parameters.FilterExpression = null;
            var extImages = await VirtualMachineExtensionImagesOperations.ListVersionsAsync(
                parameters.Location,
                parameters.PublisherName,
                parameters.Type);
            Assert.True(extImages.Value.Count > 0);

            string ver = extImages.Value.First().Name;
            string query = "startswith(name,'" + ver + "')";
            var vmextimg = await VirtualMachineExtensionImagesOperations.ListVersionsAsync(
                parameters.Location,
                parameters.PublisherName,
                parameters.Type,
                query);
            Assert.True(vmextimg.Value.Count > 0);
            Assert.True(vmextimg.Value.Count(vmi => vmi.Name != existingVersionPrefix) != 0);

            query = "startswith(name,'" + existingVersionPrefix + "')";
            parameters.FilterExpression = string.Format("$filter=startswith(name,'{0}')", existingVersionPrefix);
            vmextimg = await VirtualMachineExtensionImagesOperations.ListVersionsAsync(
                parameters.Location,
                parameters.PublisherName,
                parameters.Type,
                query);
            Assert.True(vmextimg.Value.Count > 0);
            Assert.True(vmextimg.Value.Count(vmi => vmi.Name == existingVersionPrefix) == 0);

            parameters.FilterExpression = "$top=1";
            vmextimg = await VirtualMachineExtensionImagesOperations.ListVersionsAsync(
                parameters.Location,
                parameters.PublisherName,
                parameters.Type,
                null,
                1);
            Assert.True(vmextimg.Value.Count == 1);
            Assert.True(vmextimg.Value.Count(vmi => vmi.Name == existingVersion) != 0);

            parameters.FilterExpression = "$top=0";
            vmextimg = await VirtualMachineExtensionImagesOperations.ListVersionsAsync(
                parameters.Location,
                parameters.PublisherName,
                parameters.Type,
                null,
                0);
            Assert.True(vmextimg.Value.Count == 0);
        }
    }
}
