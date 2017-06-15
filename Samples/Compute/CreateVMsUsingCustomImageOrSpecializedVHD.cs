// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Newtonsoft.Json.Linq;
using Renci.SshNet;
using System;
using System.Collections.Generic;

namespace CreateVMsUsingCustomImageOrSpecializedVHD
{
    public class Program
    {
        private static readonly string UserName = "tirekicker";
        private static readonly string Password = "12NewPA$$w0rd!";
        private readonly static List<string> ApacheInstallScriptUris = new List<string>()
        {
            "https://raw.githubusercontent.com/Azure/azure-sdk-for-java/master/azure-samples/src/main/resources/install_apache.sh"
        };
        private static readonly string ApacheInstallCommand = "bash install_apache.sh";

        /**
         * Azure Compute sample for managing virtual machines -
         *  - Create a virtual machine
         *  - Deallocate the virtual machine
         *  - Generalize the virtual machine
         *  - Capture the virtual machine to create a generalized image
         *  - Create a second virtual machine using the generalized image
         *  - Delete the second virtual machine
         *  - Create a new virtual machine by attaching OS disk of deleted VM to it.
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgCOMV", 10);
            string linuxVmName1 = SdkContext.RandomResourceName("VM1", 10);
            string linuxVmName2 = SdkContext.RandomResourceName("VM2", 10);
            string linuxVmName3 = SdkContext.RandomResourceName("VM3", 10);
            string publicIpDnsLabel = SdkContext.RandomResourceName("pip", 10);

            try
            {
                //=============================================================
                // Create a Linux VM using an image from PIR (Platform Image Repository)

                Utilities.Log("Creating a Linux VM");

                var linuxVM = azure.VirtualMachines.Define(linuxVmName1)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(publicIpDnsLabel)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(UserName)
                        .WithRootPassword(Password)
                        .WithUnmanagedDisks()
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .DefineNewExtension("CustomScriptForLinux")
                            .WithPublisher("Microsoft.OSTCExtensions")
                            .WithType("CustomScriptForLinux")
                            .WithVersion("1.4")
                            .WithMinorVersionAutoUpgrade()
                            .WithPublicSetting("fileUris", ApacheInstallScriptUris)
                            .WithPublicSetting("commandToExecute", ApacheInstallCommand)
                            .Attach()
                        .Create();

                Utilities.Log("Created a Linux VM: " + linuxVM.Id);
                Utilities.PrintVirtualMachine(linuxVM);

                // De-provision the virtual machine
                Utilities.DeprovisionAgentInLinuxVM(linuxVM.GetPrimaryPublicIPAddress().Fqdn, 22, UserName, Password);

                //=============================================================
                // Deallocate the virtual machine
                Utilities.Log("Deallocate VM: " + linuxVM.Id);

                linuxVM.Deallocate();

                Utilities.Log("Deallocated VM: " + linuxVM.Id + "; state = " + linuxVM.PowerState);

                //=============================================================
                // Generalize the virtual machine
                Utilities.Log("Generalize VM: " + linuxVM.Id);

                linuxVM.Generalize();

                Utilities.Log("Generalized VM: " + linuxVM.Id);

                //=============================================================
                // Capture the virtual machine to get a 'Generalized image' with Apache
                Utilities.Log("Capturing VM: " + linuxVM.Id);

                var capturedResultJson = linuxVM.Capture("capturedvhds", "img", true);

                Utilities.Log("Captured VM: " + linuxVM.Id);

                //=============================================================
                // Create a Linux VM using captured image (Generalized image)
                JObject o = JObject.Parse(capturedResultJson);
                JToken resourceToken = o.SelectToken("$.resources[?(@.properties.storageProfile.osDisk.image.uri != null)]");
                if (resourceToken == null)
                {
                    throw new Exception("Could not locate image uri under expected section in the capture result -" + capturedResultJson);
                }
                string capturedImageUri = (string)(resourceToken["properties"]["storageProfile"]["osDisk"]["image"]["uri"]);

                Utilities.Log("Creating a Linux VM using captured image - " + capturedImageUri);

                var linuxVM2 = azure.VirtualMachines.Define(linuxVmName2)
                        .WithRegion(Region.USWest)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithStoredLinuxImage(capturedImageUri) // Note: A Generalized Image can also be an uploaded VHD prepared from an on-premise generalized VM.
                        .WithRootUsername(UserName)
                        .WithRootPassword(Password)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                Utilities.PrintVirtualMachine(linuxVM2);

                var specializedVhd = linuxVM2.OSUnmanagedDiskVhdUri;
                //=============================================================
                // Deleting the virtual machine
                Utilities.Log("Deleting VM: " + linuxVM2.Id);

                azure.VirtualMachines.DeleteById(linuxVM2.Id); // VM required to be deleted to be able to attach it's
                                                               // OS Disk VHD to another VM (Deallocate is not sufficient)

                Utilities.Log("Deleted VM");

                //=============================================================
                // Create a Linux VM using 'specialized VHD' of previous VM

                Utilities.Log("Creating a new Linux VM by attaching OS Disk vhd - "
                        + specializedVhd
                        + " of deleted VM");

                var linuxVM3 = azure.VirtualMachines.Define(linuxVmName3)
                        .WithRegion(Region.USWest)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithSpecializedOSUnmanagedDisk(specializedVhd, OperatingSystemTypes.Linux) // New user credentials cannot be specified
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)         // when attaching a specialized VHD
                        .Create();

                Utilities.PrintVirtualMachine(linuxVM3);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
            }
        }
        
        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure);
            }
            catch (Exception e)
            {
                Utilities.Log(e);
            }
        }
    }
}
