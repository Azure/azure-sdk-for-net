// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ConvertVirtualMachineToManagedDisks
{
    public class Program
    {
        private static string userName = "tirekicker";
        private static string password = "12NewPA$$w0rd!";
        private static Region region = Region.USWestCentral;

        /**
         * Azure Compute sample for managing virtual machines -
         *   - Create a virtual machine with un-managed OS and data disks
         *   - Deallocate the virtual machine
         *   - Migrate the virtual machine to use managed disk.
         */
        public static void RunSample(IAzure azure)
        {
            var linuxVmName = Utilities.CreateRandomName("VM1");
            var rgName = Utilities.CreateRandomName("rgCOMV");
            try
            {
                //=============================================================
                // Create a Linux VM using a PIR image with un-managed OS and data disks

                Utilities.Log("Creating an un-managed Linux VM");

                var linuxVM = azure.VirtualMachines.Define(linuxVmName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(userName)
                        .WithRootPassword(password)
                        .WithUnmanagedDisks()
                        .DefineUnmanagedDataDisk("disk-1")
                            .WithNewVhd(100)
                            .WithLun(1)
                            .Attach()
                        .DefineUnmanagedDataDisk("disk-2")
                            .WithNewVhd(50)
                            .WithLun(2)
                            .Attach()
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                Utilities.Log("Created a Linux VM with un-managed OS and data disks: " + linuxVM.Id);
                Utilities.PrintVirtualMachine(linuxVM);

                //=============================================================
                // Deallocate the virtual machine
                Utilities.Log("Deallocate VM: " + linuxVM.Id);

                linuxVM.Deallocate();

                Utilities.Log("De-allocated VM: " + linuxVM.Id + "; state = " + linuxVM.PowerState);

                //=============================================================
                // Migrate the virtual machine
                Utilities.Log("Migrate VM: " + linuxVM.Id);

                linuxVM.ConvertToManaged();

                Utilities.Log("Migrated VM: " + linuxVM.Id);

                Utilities.PrintVirtualMachine(linuxVM);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception g)
                {
                    Utilities.Log(g);
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
