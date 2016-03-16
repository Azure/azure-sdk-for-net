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

using Microsoft.Azure.Management.Compute;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using System.Net;
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
        // "name": "2.0",
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

        private class VirtualMachineExtensionImageGetParameters
        {
            public string Location = "westus";
            public string PublisherName = "Microsoft.Compute";
            public string Type = "VMAccessAgent";
            public string FilterExpression = "";
        }

        private static readonly VirtualMachineExtensionImageGetParameters parameters =
            new VirtualMachineExtensionImageGetParameters();

        [Fact]
        public void TestExtImgGet()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                ComputeManagementClient _pirClient =
                    ComputeManagementTestUtilities.GetComputeManagementClient(context,
                        new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK});

                var vmimageext = _pirClient.VirtualMachineExtensionImages.Get(
                    parameters.Location,
                    parameters.PublisherName,
                    parameters.Type,
                    "2.0");

                Assert.True(vmimageext.Name == "2.0");
                Assert.True(vmimageext.Location == "westus");

                Assert.True(vmimageext.OperatingSystem == "Windows");
                Assert.True(vmimageext.ComputeRole == "IaaS");
                Assert.True(vmimageext.HandlerSchema == null);
                Assert.True(vmimageext.VmScaleSetEnabled == false);
                Assert.True(vmimageext.SupportsMultipleExtensions == false);
            }
        }

        [Fact]
        public void TestExtImgListTypes()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                ComputeManagementClient _pirClient =
                    ComputeManagementTestUtilities.GetComputeManagementClient(context,
                        new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK});

                var vmextimg = _pirClient.VirtualMachineExtensionImages.ListTypes(
                    parameters.Location, 
                    parameters.PublisherName);

                Assert.True(vmextimg.Count > 0);
                Assert.True(vmextimg.Count(vmi => vmi.Name == "VMAccessAgent") != 0);
            }
        }

        [Fact]
        public void TestExtImgListVersionsNoFilter()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                ComputeManagementClient _pirClient =
                    ComputeManagementTestUtilities.GetComputeManagementClient(context,
                        new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK});

                var vmextimg = _pirClient.VirtualMachineExtensionImages.ListVersions(
                    parameters.Location,
                    parameters.PublisherName,
                    parameters.Type);

                Assert.True(vmextimg.Count > 0);
                Assert.True(vmextimg.Count(vmi => vmi.Name == "2.0") != 0);
            }
        }

        [Fact]
        public void TestExtImgListVersionsFilters()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                ComputeManagementClient _pirClient =
                    ComputeManagementTestUtilities.GetComputeManagementClient(context,
                        new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Filter: startswith - Positive Test
                parameters.FilterExpression = null;
                var extImages = _pirClient.VirtualMachineExtensionImages.ListVersions(
                    parameters.Location,
                    parameters.PublisherName,
                    parameters.Type);
                Assert.True(extImages.Count > 0);

                string ver = extImages.First().Name;
                var query = new Microsoft.Rest.Azure.OData.ODataQuery<Microsoft.Azure.Management.Compute.Models.VirtualMachineExtensionImage>();

                query.SetFilter(f => f.Name.StartsWith(ver));
                parameters.FilterExpression = "$filter=startswith(name,'" + ver + "')";
                var vmextimg = _pirClient.VirtualMachineExtensionImages.ListVersions(
                    parameters.Location,
                    parameters.PublisherName,
                    parameters.Type,
                    query);
                Assert.True(vmextimg.Count > 0);
                Assert.True(vmextimg.Count(vmi => vmi.Name == "2.0") != 0);

                // Filter: startswith - Negative Test
                query.SetFilter(f => f.Name.StartsWith("1.0"));
                parameters.FilterExpression = "$filter=startswith(name,'1.0')";
                vmextimg = _pirClient.VirtualMachineExtensionImages.ListVersions(
                    parameters.Location,
                    parameters.PublisherName,
                    parameters.Type,
                    query);
                Assert.True(vmextimg.Count == 0);
                Assert.True(vmextimg.Count(vmi => vmi.Name == "2.0") == 0);

                // Filter: top - Positive Test
                query.Filter = null;
                query.Top =1;
                parameters.FilterExpression = "$top=1";
                vmextimg = _pirClient.VirtualMachineExtensionImages.ListVersions(
                    parameters.Location,
                    parameters.PublisherName,
                    parameters.Type,
                    query);
                Assert.True(vmextimg.Count == 1);
                Assert.True(vmextimg.Count(vmi => vmi.Name == "2.0") != 0);

                // Filter: top - Negative Test
                query.Top = 0;
                parameters.FilterExpression = "$top=0";
                vmextimg = _pirClient.VirtualMachineExtensionImages.ListVersions(
                    parameters.Location,
                    parameters.PublisherName,
                    parameters.Type,
                    query);
                Assert.True(vmextimg.Count == 0);
            }
        }
    }
}
