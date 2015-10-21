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

using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Compute.Tests
{
    public class ExtImgTests
    {
        // ##############
        //  SETUP
        // ##############
        // 0- For recording data froim local host, change RunMe.cmd as follows:
        // :Record
        // set TEST_CONNECTION_STRING=ManagementCertificate=76ddb456d73ae935a3aef20d6a1db0eb14bc6daf;SubscriptionId=84fffc2f-5d77-449a-bc7f-58c363f2a6b9;BaseUri=http://localhost:449

        // Note: Make sure whatever cert thumprint you used above is installed in you Cert *User* Store

        // 1- Create a publisher
        //
        // PUT http://localhost:449/Providers/Microsoft.Compute/Publishers/Microsoft.Windows
        // {
        //  "Properties": {
        //    "State": "Registered",
        //    "Type": "All",
        //    "IsHidden": false
        //  },
        //  "Name": "Microsoft.Windows"
        // }

        // 2- Put a VM Image Extension
        //PUT http://localhost:449/providers/Microsoft.Compute/locations/westus/publishers/Microsoft.Windows/artifacttypes/vmextension/types/vmaccess/versions/1.1.0?api-version=2014-12-01-preview HTTP/1.1
        //{
        // "name": "1.1.0",
        //  "location": "westus",

        //  "properties": {
        //    "publishLocations": [
        //      "all"
        //    ],
        //    "allowDeploymentTo": {
        //      "group": "MSDN"
        //    },
        //    "sourcePackageUri": "http://fake.com",
        //    "attributes":
        //     {
        //         "operatingSystem":"Windows",
        //         "computeRole":"PaaS",
        //         "handlerSchema":"",
        //         "vmScaleSetEnabled":"",
        //         "supportMultipleExtensions":""
        //     }
        //  }
        //}

        private static readonly VirtualMachineExtensionImageGetParameters parameters = new VirtualMachineExtensionImageGetParameters()
        {
            Location = "westus",
            PublisherName = "Microsoft.Windows",
            Type = "vmaccess",
            Version = "1.1.0"
        };

        [Fact]
        public void TestExtImgGet()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                ComputeManagementClient _pirClient =
                    ComputeManagementTestUtilities.GetComputeManagementClient(new RDFETestEnvironmentFactory(),
                        new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK});

                var vmimageext = _pirClient.VirtualMachineExtensionImages.Get(parameters);

                Assert.True(vmimageext.VirtualMachineExtensionImage.Name == "1.1.0");
                Assert.True(vmimageext.VirtualMachineExtensionImage.Location == "westus");

                Assert.True(vmimageext.VirtualMachineExtensionImage.OperatingSystem == "Windows");
                Assert.True(vmimageext.VirtualMachineExtensionImage.ComputeRole == "PaaS");
                Assert.True(string.IsNullOrEmpty(vmimageext.VirtualMachineExtensionImage.HandlerSchema));
                Assert.True(vmimageext.VirtualMachineExtensionImage.VMScaleSetEnabled == false);
                Assert.True(vmimageext.VirtualMachineExtensionImage.SupportsMultipleExtensions == false);
            }
        }

        [Fact]
        public void TestExtImgListTypes()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                ComputeManagementClient _pirClient =
                    ComputeManagementTestUtilities.GetComputeManagementClient(new RDFETestEnvironmentFactory(),
                        new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK});

                var vmextimg = _pirClient.VirtualMachineExtensionImages.ListTypes(parameters);

                Assert.True(vmextimg.Resources.Count > 0);
                Assert.True(vmextimg.Resources.Count(vmi => vmi.Name == "vmaccess") != 0);
            }
        }

        [Fact]
        public void TestExtImgListVersionsNoFilter()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                ComputeManagementClient _pirClient =
                    ComputeManagementTestUtilities.GetComputeManagementClient(new RDFETestEnvironmentFactory(),
                        new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK});

                var vmextimg = _pirClient.VirtualMachineExtensionImages.ListVersions(parameters);

                Assert.True(vmextimg.Resources.Count > 0);
                Assert.True(vmextimg.Resources.Count(vmi => vmi.Name == "1.1.0") != 0);
            }
        }

        [Fact]
        public void TestExtImgListVersionsFilters()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                ComputeManagementClient _pirClient =
                    ComputeManagementTestUtilities.GetComputeManagementClient(new RDFETestEnvironmentFactory(),
                        new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                VirtualMachineExtensionImageListVersionsParameters listVersionsParamers = new VirtualMachineExtensionImageListVersionsParameters()
                {
                    Location = parameters.Location,
                    Type = parameters.Type,
                    PublisherName = parameters.PublisherName,
                };

                // Filter: startswith - Positive Test
                listVersionsParamers.FilterExpression = "$filter=startswith(name,'1.1')";
                var vmextimg = _pirClient.VirtualMachineExtensionImages.ListVersions(listVersionsParamers);
                Assert.True(vmextimg.Resources.Count > 0);
                Assert.True(vmextimg.Resources.Count(vmi => vmi.Name == "1.1.0") != 0);

                // Filter: startswith - Negative Test
                listVersionsParamers.FilterExpression = "$filter=startswith(name,'1.0')";
                vmextimg = _pirClient.VirtualMachineExtensionImages.ListVersions(listVersionsParamers);
                Assert.True(vmextimg.Resources.Count == 0);
                Assert.True(vmextimg.Resources.Count(vmi => vmi.Name == "1.1.0") == 0);

                // Filter: top - Positive Test
                listVersionsParamers.FilterExpression = "$top=1";
                vmextimg = _pirClient.VirtualMachineExtensionImages.ListVersions(listVersionsParamers);
                Assert.True(vmextimg.Resources.Count == 1);
                Assert.True(vmextimg.Resources.Count(vmi => vmi.Name == "1.1.0") != 0);

                // Filter: top - Negative Test
                listVersionsParamers.FilterExpression = "$top=0";
                vmextimg = _pirClient.VirtualMachineExtensionImages.ListVersions(listVersionsParamers);
                Assert.True(vmextimg.Resources.Count == 0);
            }
        }
    }
}
