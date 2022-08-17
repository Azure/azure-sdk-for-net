// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests.VMScaleSetTests
{
    public class VMScaleSetApplicationTests : VMScaleSetTestsBase
    {
        [Fact]
        public void VMScaleSetApplicationController_Test()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                // use existing rg and vmss for testing
                var rgName = "bhbrahma_testing";
                string vmssName = "win10-vmss";

                // when re-recording the test ensure that you use a valid packageReferenceId
                // refer to https://microsoft.sharepoint.com/:w:/t/ComputeVM/EcYeD-HHrLZHpYyxo3iRCtkB-VeO8BuWE4dq4hoX9tlzEg?e=nOTgTu
                // for how to create a valid VMApplication
                (string applicationName, VMGalleryApplication v1, VMGalleryApplication v2) golang =
                (
                    "golang",
                    new VMGalleryApplication("/subscriptions/a53f7094-a16c-47af-abe4-b05c05d0d79a/resourceGroups/bhbrahma_testing/providers/Microsoft.Compute/galleries/gallery1/applications/golang/versions/1.15.8", treatFailureAsDeploymentFailure: true),
                    new VMGalleryApplication("/subscriptions/a53f7094-a16c-47af-abe4-b05c05d0d79a/resourceGroups/bhbrahma_testing/providers/Microsoft.Compute/galleries/gallery1/applications/golang/versions/1.19.0", treatFailureAsDeploymentFailure: true)
                );
                (string applicationName, VMGalleryApplication v1) firefox =
                (
                    "firefox",
                    new VMGalleryApplication("/subscriptions/a53f7094-a16c-47af-abe4-b05c05d0d79a/resourceGroups/bhbrahma_testing/providers/Microsoft.Compute/galleries/gallery1/applications/firefox/versions/103.0.2", treatFailureAsDeploymentFailure: true)
                );

                VirtualMachineScaleSet testVMSS;
                testVMSS = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                ApplicationProfile applicationProfileForVmss = new ApplicationProfile(new List<VMGalleryApplication>() { golang.v1 });

                m_CrpClient.VirtualMachineScaleSets.Update(rgName, testVMSS.Name, new VirtualMachineScaleSetUpdate(virtualMachineProfile: new VirtualMachineScaleSetUpdateVMProfile(applicationProfile: applicationProfileForVmss)));

                // test list
                VirtualMachineApplicationsListResult listResult = m_CrpClient.VirtualMachineScaleSetApplications.List(rgName, testVMSS.Name);
                Assert.Single(listResult.Value);
                Assert.Equal(golang.v1.PackageReferenceId, listResult.Value[0].PackageReferenceId);

                // add app 
                VMGalleryApplication putResult = m_CrpClient.VirtualMachineScaleSetApplications.Put(rgName, testVMSS.Name, firefox.applicationName, firefox.v1);
                Assert.Equal(firefox.v1.PackageReferenceId, putResult.PackageReferenceId);
                listResult = m_CrpClient.VirtualMachineScaleSetApplications.List(rgName, testVMSS.Name);
                Assert.Equal(2, listResult.Value.Count);

                // update app
                m_CrpClient.VirtualMachineScaleSetApplications.Put(rgName, testVMSS.Name, golang.applicationName, golang.v2);
                listResult = m_CrpClient.VirtualMachineScaleSetApplications.List(rgName, testVMSS.Name);
                Assert.Equal(2, listResult.Value.Count);

                // test get
                VMGalleryApplication firefoxInstanceView = m_CrpClient.VirtualMachineScaleSetApplications.Get(rgName, testVMSS.Name, firefox.applicationName);
                Assert.Equal(firefox.v1.PackageReferenceId, firefoxInstanceView.PackageReferenceId);

                // test delete
                m_CrpClient.VirtualMachineScaleSetApplications.Delete(rgName, testVMSS.Name, golang.applicationName);
                m_CrpClient.VirtualMachineScaleSetApplications.Delete(rgName, testVMSS.Name, firefox.applicationName);
                testVMSS = m_CrpClient.VirtualMachineScaleSets.Get(rgName, testVMSS.Name);
                Assert.Equal(0, testVMSS.VirtualMachineProfile?.ApplicationProfile?.GalleryApplications.Count ?? 0 );
            }
        }
    }
}
