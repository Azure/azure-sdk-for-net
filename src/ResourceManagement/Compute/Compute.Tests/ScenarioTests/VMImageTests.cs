//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Compute.Tests
{
    public class VMImagesTests : VMTestBase
    {
        private static readonly string[] AvailableWindowsServerImageVersions = new string[] { "4.0.201506", "4.0.201505", "4.0.201504"};

        private VirtualMachineImageGetParameters parameters;
        private VirtualMachineImageListParameters listParameters;

        private void Initialize()
        {
            ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

            parameters = new VirtualMachineImageGetParameters()
            {
                Location = ComputeManagementTestUtilities.DefaultLocation,
                PublisherName = imageRef.Publisher,
                Offer = imageRef.Offer,
                Skus = imageRef.Sku,
                Version = imageRef.Version
            };

            listParameters = new VirtualMachineImageListParameters()
            {
                Location = ComputeManagementTestUtilities.DefaultLocation,
                PublisherName = imageRef.Publisher,
                Offer = imageRef.Offer,
                Skus = imageRef.Sku
            };
        }

        [Fact]
        public void TestVMImageGet()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();
                Initialize();

                var vmimage = m_CrpClient.VirtualMachineImages.Get(parameters);

                Assert.Equal(parameters.Version, vmimage.VirtualMachineImage.Name);
                Assert.Equal(parameters.Location, vmimage.VirtualMachineImage.Location, StringComparer.OrdinalIgnoreCase);

                Assert.True(vmimage.VirtualMachineImage.OSDiskImage.OperatingSystem == "Windows");
            }
        }

        [Fact]
        public void TestVMImageListNoFilter()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();
                Initialize();

                var vmimages = m_CrpClient.VirtualMachineImages.List(listParameters);

                Assert.True(vmimages.Resources.Count > 0);
                Assert.True(vmimages.Resources.Count(vmi => vmi.Name == AvailableWindowsServerImageVersions[0]) != 0);
                Assert.True(vmimages.Resources.Count(vmi => vmi.Name == AvailableWindowsServerImageVersions[1]) != 0);
            }
        }

        [Fact]
        public void TestVMImageListFilters()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();
                Initialize();

                VirtualMachineImageListParameters listParametersWithFilter = new VirtualMachineImageListParameters()
                {
                    Location = listParameters.Location,
                    PublisherName = listParameters.PublisherName,
                    Offer = listParameters.Offer,
                    Skus = listParameters.Skus,
                };

                // Filter: top - Negative Test
                listParametersWithFilter.FilterExpression = "$top=0";
                var vmimages = m_CrpClient.VirtualMachineImages.List(listParametersWithFilter);
                Assert.True(vmimages.Resources.Count == 0);

                // Filter: top - Positive Test
                listParametersWithFilter.FilterExpression = "$top=1";
                vmimages = m_CrpClient.VirtualMachineImages.List(listParametersWithFilter);
                Assert.True(vmimages.Resources.Count == 1);

                // Filter: top - Positive Test
                listParametersWithFilter.FilterExpression = "$top=2";
                vmimages = m_CrpClient.VirtualMachineImages.List(listParametersWithFilter);
                Assert.True(vmimages.Resources.Count == 2);
                Assert.True(vmimages.Resources.Count(vmi => vmi.Name == AvailableWindowsServerImageVersions[1]) != 0);

                // Filter: orderby - Positive Test
                listParametersWithFilter.FilterExpression = "$orderby=name desc";
                vmimages = m_CrpClient.VirtualMachineImages.List(listParametersWithFilter);
                Assert.Equal(AvailableWindowsServerImageVersions.Length, vmimages.Resources.Count);
                for (int i = 0; i < AvailableWindowsServerImageVersions.Length; i++)
                {
                    Assert.Equal(AvailableWindowsServerImageVersions[i], vmimages.Resources[i].Name);
                }

                // Filter: orderby - Positive Test
                listParametersWithFilter.FilterExpression = "$top=2&$orderby=name asc";
                vmimages = m_CrpClient.VirtualMachineImages.List(listParametersWithFilter);
                Assert.True(vmimages.Resources.Count == 2);
                Assert.True(vmimages.Resources[0].Name == AvailableWindowsServerImageVersions.Last());
                Assert.True(vmimages.Resources[1].Name == AvailableWindowsServerImageVersions.Reverse().Skip(1).First());

                // Filter: top orderby - Positive Test
                listParametersWithFilter.FilterExpression = "$top=1&$orderby=name desc";
                vmimages = m_CrpClient.VirtualMachineImages.List(listParametersWithFilter);
                Assert.True(vmimages.Resources.Count == 1);
                Assert.True(vmimages.Resources[0].Name == AvailableWindowsServerImageVersions[0]);

                // Filter: top orderby - Positive Test
                listParametersWithFilter.FilterExpression = "$top=1&$orderby=name asc";
                vmimages = m_CrpClient.VirtualMachineImages.List(listParametersWithFilter);
                Assert.True(vmimages.Resources.Count == 1);
                Assert.True(vmimages.Resources[0].Name == AvailableWindowsServerImageVersions.Last());
            }
        }

        [Fact]
        public void TestVMImageListPublishers()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();
                Initialize();

                var publishers = m_CrpClient.VirtualMachineImages.ListPublishers(parameters);

                Assert.True(publishers.Resources.Count > 0);
                Assert.True(publishers.Resources.Count(pub => pub.Name == parameters.PublisherName) != 0);
            }
        }

        [Fact]
        public void TestVMImageListOffers()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();
                Initialize();

                var offers = m_CrpClient.VirtualMachineImages.ListOffers(parameters);

                Assert.True(offers.Resources.Count > 0);
                Assert.True(offers.Resources.Count(offer => offer.Name == parameters.Offer) != 0);
            }
        }

        [Fact]
        public void TestVMImageListSkus()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();
                Initialize();

                var skus = m_CrpClient.VirtualMachineImages.ListSkus(parameters);

                Assert.True(skus.Resources.Count > 0);
                Assert.True(skus.Resources.Count(sku => sku.Name == parameters.Skus) != 0);
            }
        }
    }
}
