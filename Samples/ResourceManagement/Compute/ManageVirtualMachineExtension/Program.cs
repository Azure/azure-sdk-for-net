// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System;
using System.Collections.Generic;

namespace ManageVirtualMachineExtension
{
    /**
     * Azure Compute sample for managing virtual machine extensions. -
     *  - Create a Linux and Windows virtual machine
     *  - Add three users (user names and passwords for windows, SSH keys for Linux)
     *  - Resets user credentials
     *  - Remove a user
     *  - Install MySQL on Linux | something significant on Windows
     *  - Remove extensions
     */

    public class Program
    {
        readonly static string rgName = ResourceNamer.RandomResourceName("rgCOVE", 15);
        readonly static string linuxVmName = ResourceNamer.RandomResourceName("lVM", 10);
        readonly static string windowsVmName = ResourceNamer.RandomResourceName("wVM", 10);
        readonly static string pipDnsLabelLinuxVM = ResourceNamer.RandomResourceName("rgPip1", 25);
        readonly static string pipDnsLabelWindowsVM = ResourceNamer.RandomResourceName("rgPip2", 25);

        // Linux configurations
        //
        readonly static string firstLinuxUserName = "tirekicker";
        readonly static string firstLinuxUserPassword = "12NewPA$$w0rd!";
        readonly static string firstLinuxUserNewPassword = "muy!234OR";

        readonly static string secondLinuxUserName = "seconduser";
        readonly static string secondLinuxUserPassword = "B12a6@12xyz!";
        readonly static string secondLinuxUserExpiration = "2020-12-31";

        readonly static string thirdLinuxUserName = "thirduser";
        readonly static string thirdLinuxUserPassword = "12xyz!B12a6@";
        readonly static string thirdLinuxUserExpiration = "2020-12-31";

        readonly static string linuxCustomScriptExtensionName = "CustomScriptForLinux";
        readonly static string linuxCustomScriptExtensionPublisherName = "Microsoft.OSTCExtensions";
        readonly static string linuxCustomScriptExtensionTypeName = "CustomScriptForLinux";
        readonly static string linuxCustomScriptExtensionVersionName = "1.4";

        readonly static string mySqlScriptLinuxInstallCommand = "bash install_mysql_server_5.6.sh Abc.123x(";
        readonly static List<string> mySQLLinuxInstallScriptFileUris = new List<string>()
        {
            "https://raw.githubusercontent.com/Azure/azure-quickstart-templates/4397e808d07df60ff3cdfd1ae40999f0130eb1b3/mysql-standalone-server-ubuntu/scripts/install_mysql_server_5.6.sh"
        };

        readonly static string windowsCustomScriptExtensionName = "CustomScriptExtension";
        readonly static string windowsCustomScriptExtensionPublisherName = "Microsoft.Compute";
        readonly static string windowsCustomScriptExtensionTypeName = "CustomScriptExtension";
        readonly static string windowsCustomScriptExtensionVersionName = "1.7";

        readonly static string mySqlScriptWindowsInstallCommand = "powershell.exe -ExecutionPolicy Unrestricted -File installMySQL.ps1";
        readonly static List<string> mySQLWindowsInstallScriptFileUris = new List<string>()
        {
            "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/Fluent/Samples/ResourceManagement/Compute/ManageVirtualMachineExtension/Assets/installMySQL.ps1"
        };

        readonly static string linuxVmAccessExtensionName = "VMAccessForLinux";
        readonly static string linuxVmAccessExtensionPublisherName = "Microsoft.OSTCExtensions";
        readonly static string linuxVmAccessExtensionTypeName = "VMAccessForLinux";
        readonly static string linuxVmAccessExtensionVersionName = "1.4";

        // Windows configurations
        //
        readonly static string firstWindowsUserName = "tirekicker";
        readonly static string firstWindowsUserPassword = "12NewPA$$w0rd!";
        readonly static string firstWindowsUserNewPassword = "muy!234OR";

        readonly static string secondWindowsUserName = "seconduser";
        readonly static string secondWindowsUserPassword = "B12a6@12xyz!";

        readonly static string thirdWindowsUserName = "thirduser";
        readonly static string thirdWindowsUserPassword = "12xyz!B12a6@";

        readonly static string windowsVmAccessExtensionName = "VMAccessAgent";
        readonly static string windowsVmAccessExtensionPublisherName = "Microsoft.Compute";
        readonly static string windowsVmAccessExtensionTypeName = "VMAccessAgent";
        readonly static string windowsVmAccessExtensionVersionName = "2.3";

        public static void Main(string[] args)
        {

            try
            {
                //=============================================================
                // Authenticate
                AzureCredentials credentials = AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

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
                    // Create a Linux VM with root (sudo) user
                    Console.WriteLine("Creating a Linux VM");

                    IVirtualMachine linuxVM = azure.VirtualMachines.Define(linuxVmName)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithNewPrimaryPublicIpAddress(pipDnsLabelLinuxVM)
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_14_04_LTS)
                            .WithRootUserName(firstLinuxUserName)
                            .WithPassword(firstLinuxUserPassword)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .Create();

                    Console.WriteLine("Created a Linux VM:" + linuxVM.Id);
                    Utilities.PrintVirtualMachine(linuxVM);

                    //=============================================================
                    // Add a second sudo user to Linux VM using VMAccess extension

                    linuxVM.Update()
                            .DefineNewExtension(linuxVmAccessExtensionName)
                                .WithPublisher(linuxVmAccessExtensionPublisherName)
                                .WithType(linuxVmAccessExtensionTypeName)
                                .WithVersion(linuxVmAccessExtensionVersionName)
                                .WithProtectedSetting("username", secondLinuxUserName)
                                .WithProtectedSetting("password", secondLinuxUserPassword)
                                .WithProtectedSetting("expiration", secondLinuxUserExpiration)
                                .Attach()
                            .Apply();
                    
                    Console.WriteLine("Added a second sudo user to the Linux VM");

                    //=============================================================
                    // Add a third sudo user to Linux VM by updating VMAccess extension

                    linuxVM.Update()
                            .UpdateExtension(linuxVmAccessExtensionName)
                                .WithProtectedSetting("username", thirdLinuxUserName)
                                .WithProtectedSetting("password", thirdLinuxUserPassword)
                                .WithProtectedSetting("expiration", thirdLinuxUserExpiration)
                            .Parent()
                            .Apply();

                    Console.WriteLine("Added a third sudo user to the Linux VM");


                    //=============================================================
                    // Reset ssh password of first user of Linux VM by updating VMAccess extension

                    linuxVM.Update()
                            .UpdateExtension(linuxVmAccessExtensionName)
                                .WithProtectedSetting("username", firstLinuxUserName)
                                .WithProtectedSetting("password", firstLinuxUserNewPassword)
                                .WithProtectedSetting("reset_ssh", "true")
                            .Parent()
                            .Apply();

                    Console.WriteLine("Password of first user of Linux VM has been updated");

                    //=============================================================
                    // Removes the second sudo user from Linux VM using VMAccess extension

                    linuxVM.Update()
                            .UpdateExtension(linuxVmAccessExtensionName)
                                .WithProtectedSetting("remove_user", secondLinuxUserName)
                            .Parent()
                            .Apply();

                    //=============================================================
                    // Install MySQL in Linux VM using CustomScript extension

                    linuxVM.Update()
                            .DefineNewExtension(linuxCustomScriptExtensionName)
                                .WithPublisher(linuxCustomScriptExtensionPublisherName)
                                .WithType(linuxCustomScriptExtensionTypeName)
                                .WithVersion(linuxCustomScriptExtensionVersionName)
                                .WithAutoUpgradeMinorVersionEnabled()
                                .WithPublicSetting("fileUris", mySQLLinuxInstallScriptFileUris)
                                .WithPublicSetting("commandToExecute", mySqlScriptLinuxInstallCommand)
                            .Attach()
                            .Apply();

                    Console.WriteLine("Installed MySql using custom script extension");
                    Utilities.PrintVirtualMachine(linuxVM);

                    //=============================================================
                    // Removes the extensions from Linux VM

                    linuxVM.Update()
                            .WithoutExtension(linuxCustomScriptExtensionName)
                            .WithoutExtension(linuxVmAccessExtensionName)
                            .Apply();
                    Console.WriteLine("Removed the custom script and VM Access extensions from Linux VM");
                    Utilities.PrintVirtualMachine(linuxVM);

                    //=============================================================
                    // Create a Windows VM with admin user

                    Console.WriteLine("Creating a Windows VM");

                    IVirtualMachine windowsVM = azure.VirtualMachines.Define(windowsVmName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithNewPrimaryPublicIpAddress(pipDnsLabelWindowsVM)
                            .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WINDOWS_SERVER_2012_R2_DATACENTER)
                            .WithAdminUserName(firstWindowsUserName)
                            .WithPassword(firstWindowsUserPassword)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .DefineNewExtension(windowsCustomScriptExtensionName)
                                .WithPublisher(windowsCustomScriptExtensionPublisherName)
                                .WithType(windowsCustomScriptExtensionTypeName)
                                .WithVersion(windowsCustomScriptExtensionVersionName)
                                .WithAutoUpgradeMinorVersionEnabled()
                                .WithPublicSetting("fileUris", mySQLWindowsInstallScriptFileUris)
                                .WithPublicSetting("commandToExecute", mySqlScriptWindowsInstallCommand)
                            .Attach()
                            .Create();

                    Console.WriteLine("Created a Windows VM:" + windowsVM.Id);
                    Utilities.PrintVirtualMachine(windowsVM);

                    //=============================================================
                    // Add a second admin user to Windows VM using VMAccess extension

                    windowsVM.Update()
                            .DefineNewExtension(windowsVmAccessExtensionName)
                                .WithPublisher(windowsVmAccessExtensionPublisherName)
                                .WithType(windowsVmAccessExtensionTypeName)
                                .WithVersion(windowsVmAccessExtensionVersionName)
                                .WithProtectedSetting("username", secondWindowsUserName)
                                .WithProtectedSetting("password", secondWindowsUserPassword)
                            .Attach()
                            .Apply();

                    Console.WriteLine("Added a second admin user to the Windows VM");

                    //=============================================================
                    // Add a third admin user to Windows VM by updating VMAccess extension

                    windowsVM.Update()
                            .UpdateExtension(windowsVmAccessExtensionName)
                                .WithProtectedSetting("username", thirdWindowsUserName)
                                .WithProtectedSetting("password", thirdWindowsUserPassword)
                            .Parent()
                            .Apply();

                    Console.WriteLine("Added a third admin user to the Windows VM");

                    //=============================================================
                    // Reset admin password of first user of Windows VM by updating VMAccess extension

                    windowsVM.Update()
                            .UpdateExtension(windowsVmAccessExtensionName)
                                .WithProtectedSetting("username", firstWindowsUserName)
                                .WithProtectedSetting("password", firstWindowsUserNewPassword)
                            .Parent()
                            .Apply();

                    Console.WriteLine("Password of first user of Windows VM has been updated");

                    //=============================================================
                    // Removes the extensions from Linux VM

                    windowsVM.Update()
                            .WithoutExtension(windowsVmAccessExtensionName)
                            .Apply();
                    Console.WriteLine("Removed the VM Access extensions from Windows VM");
                    Utilities.PrintVirtualMachine(windowsVM);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    Console.WriteLine($"Deleting resource group : {rgName}");
                    azure.ResourceGroups.Delete(rgName);
                    Console.WriteLine($"Deleted resource group : {rgName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
