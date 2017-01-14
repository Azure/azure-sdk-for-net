// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace CreateVMsUsingCustomImageOrSpecializedVHD
{
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
    public class Program
    {
        private static readonly string rgName = ResourceNamer.RandomResourceName("rgCOMV", 10);
        private static readonly string linuxVmName1 = ResourceNamer.RandomResourceName("VM1", 10);
        private static readonly string linuxVmName2 = ResourceNamer.RandomResourceName("VM2", 10);
        private static readonly string linuxVmName3 = ResourceNamer.RandomResourceName("VM3", 10);
        private static readonly string publicIpDnsLabel = ResourceNamer.RandomResourceName("pip", 10);
        private static readonly string userName = "tirekicker";
        private static readonly string password = "12NewPA$$w0rd!";
        private readonly static List<string> apacheInstallScriptUris = new List<string>()
        {
            "https://raw.githubusercontent.com/Azure/azure-sdk-for-java/master/azure-samples/src/main/resources/install_apache.sh"
        };
        private static readonly string apacheInstallCommand = "bash install_apache.sh";

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials = AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Console.WriteLine("Selected subscription: " + azure.SubscriptionId);

                try
                {
                    //=============================================================
                    // Create a Linux VM using an image from PIR (Platform Image Repository)

                    Console.WriteLine("Creating a Linux VM");

                    var linuxVM = azure.VirtualMachines.Define(linuxVmName1)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithNewPrimaryPublicIpAddress(publicIpDnsLabel)
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                            .WithRootUsername(userName)
                            .WithRootPassword(password)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .DefineNewExtension("CustomScriptForLinux")
                                .WithPublisher("Microsoft.OSTCExtensions")
                                .WithType("CustomScriptForLinux")
                                .WithVersion("1.4")
                                .WithMinorVersionAutoUpgrade()
                                .WithPublicSetting("fileUris", apacheInstallScriptUris)
                                .WithPublicSetting("commandToExecute", apacheInstallCommand)
                                .Attach()
                            .Create();

                    Console.WriteLine("Created a Linux VM: " + linuxVM.Id);
                    Utilities.PrintVirtualMachine(linuxVM);

                    Console.WriteLine("SSH into the VM [" + linuxVM.GetPrimaryPublicIpAddress().Fqdn + "]");
                    Console.WriteLine("and run 'sudo waagent -deprovision+user' to prepare it for capturing");
                    Console.WriteLine("after that press 'Enter' to continue.");
                    Console.ReadKey();

                    //=============================================================
                    // Deallocate the virtual machine
                    Console.WriteLine("Deallocate VM: " + linuxVM.Id);

                    linuxVM.Deallocate();

                    Console.WriteLine("Deallocated VM: " + linuxVM.Id + "; state = " + linuxVM.PowerState);

                    //=============================================================
                    // Generalize the virtual machine
                    Console.WriteLine("Generalize VM: " + linuxVM.Id);

                    linuxVM.Generalize();

                    Console.WriteLine("Generalized VM: " + linuxVM.Id);

                    //=============================================================
                    // Capture the virtual machine to get a 'Generalized image' with Apache
                    Console.WriteLine("Capturing VM: " + linuxVM.Id);

                    var capturedResultJson = linuxVM.Capture("capturedvhds", "img", true);

                    Console.WriteLine("Captured VM: " + linuxVM.Id);

                    //=============================================================
                    // Create a Linux VM using captured image (Generalized image)
                    JObject o = JObject.Parse(capturedResultJson);
                    JToken resourceToken = o.SelectToken("$.resources[?(@.properties.storageProfile.osDisk.image.uri != null)]");
                    if (resourceToken == null)
                    {
                        throw new Exception("Could not locate image uri under expected section in the capture result -" + capturedResultJson);
                    }
                    string capturedImageUri = (string)(resourceToken["properties"]["storageProfile"]["osDisk"]["image"]["uri"]);

                    Console.WriteLine("Creating a Linux VM using captured image - " + capturedImageUri);

                    var linuxVM2 = azure.VirtualMachines.Define(linuxVmName2)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithoutPrimaryPublicIpAddress()
                            .WithStoredLinuxImage(capturedImageUri) // Note: A Generalized Image can also be an uploaded VHD prepared from an on-premise generalized VM.
                            .WithRootUsername(userName)
                            .WithRootPassword(password)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .Create();

                    Utilities.PrintVirtualMachine(linuxVM2);

                    var specializedVhd = linuxVM2.OsDiskVhdUri;
                    //=============================================================
                    // Deleting the virtual machine
                    Console.WriteLine("Deleting VM: " + linuxVM2.Id);

                    azure.VirtualMachines.DeleteById(linuxVM2.Id); // VM required to be deleted to be able to attach it's
                                                                       // OS Disk VHD to another VM (Deallocate is not sufficient)

                    Console.WriteLine("Deleted VM");

                    //=============================================================
                    // Create a Linux VM using 'specialized VHD' of previous VM

                    Console.WriteLine("Creating a new Linux VM by attaching OS Disk vhd - "
                            + specializedVhd
                            + " of deleted VM");

                    var linuxVM3 = azure.VirtualMachines.Define(linuxVmName3)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithoutPrimaryPublicIpAddress()
                            .WithOsDisk(specializedVhd, OperatingSystemTypes.Linux) // New user credentials cannot be specified
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)         // when attaching a specialized VHD
                            .Create();

                    Utilities.PrintVirtualMachine(linuxVM3);
                }
                catch (Exception f)
                {
                    Console.WriteLine(f);
                }
                finally
                {
                    try
                    {
                        Console.WriteLine("Deleting Resource Group: " + rgName);
                        azure.ResourceGroups.DeleteByName(rgName);
                        Console.WriteLine("Deleted Resource Group: " + rgName);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Did not create any resources in Azure. No clean up is necessary");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
