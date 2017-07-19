// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Net.Http;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Newtonsoft.Json.Linq;

namespace Fluent.Tests.Compute.VirtualMachine
{
    public class Extension
    {
        [Fact]
        public void CanResetPasswordUsingVMAccessExtension()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("vmexttest");
                string location = "eastus";
                string vmName = "javavm";

                var azure = TestHelper.CreateRollupClient();
                var vm = azure.VirtualMachines
                    .Define(vmName)
                    .WithRegion(location)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer14_04_Lts)
                    .WithRootUsername("Foo12")
                    .WithRootPassword("BaR@12abc!")
                    .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                    .Create();

                var availableSizes = vm.AvailableSizes();

                vm.Update()
                    .DefineNewExtension("VMAccessForLinux")
                        .WithPublisher("Microsoft.OSTCExtensions")
                        .WithType("VMAccessForLinux")
                        .WithVersion("1.4")
                        .WithProtectedSetting("username", "Foo12")
                        .WithProtectedSetting("password", "B12a6@12xyz!")
                        .WithProtectedSetting("reset_ssh", "true")
                    .Attach()
                    .Apply();

                Assert.True(vm.ListExtensions().Count() > 0);
                Assert.True(vm.ListExtensions().ContainsKey("VMAccessForLinux"));

                vm.Update()
                        .UpdateExtension("VMAccessForLinux")
                            .WithProtectedSetting("username", "Foo12")
                            .WithProtectedSetting("password", "muy!234OR")
                            .WithProtectedSetting("reset_ssh", "true")
                        .Parent()
                        .Apply();
            }
        }

        [Fact]
        public void CanInstallUninstallCustomExtension()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("vmexttest");
                string location = "eastus";
                string vmName = "javavm";

                string mySqlInstallScript = "https://raw.githubusercontent.com/Azure/azure-quickstart-templates/4397e808d07df60ff3cdfd1ae40999f0130eb1b3/mysql-standalone-server-ubuntu/scripts/install_mysql_server_5.6.sh";
                string installCommand = "bash install_mysql_server_5.6.sh Abc.123x(";
                List<string> fileUris = new List<string>()
            {
                mySqlInstallScript
            };

                var azure = TestHelper.CreateRollupClient();
                // Create Linux VM with a custom extension to install MySQL
                //
                var vm = azure.VirtualMachines
                        .Define(vmName)
                        .WithRegion(location)
                        .WithNewResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer14_04_Lts)
                        .WithRootUsername("Foo12")
                        .WithRootPassword("BaR@12abc!")
                        .WithSize(VirtualMachineSizeTypes.StandardDS3V2)
                        .DefineNewExtension("CustomScriptForLinux")
                            .WithPublisher("Microsoft.OSTCExtensions")
                            .WithType("CustomScriptForLinux")
                            .WithVersion("1.4")
                            .WithMinorVersionAutoUpgrade()
                            .WithPublicSetting("fileUris", fileUris)
                            .WithPublicSetting("commandToExecute", installCommand)
                        .Attach()
                        .Create();

                Assert.True(vm.ListExtensions().Count > 0);
                Assert.True(vm.ListExtensions().ContainsKey("CustomScriptForLinux"));
                IVirtualMachineExtension customScriptExtension;
                Assert.True(vm.ListExtensions().TryGetValue("CustomScriptForLinux", out customScriptExtension));
                Assert.NotNull(customScriptExtension);
                Assert.Equal(customScriptExtension.PublisherName, "Microsoft.OSTCExtensions");
                Assert.Equal(customScriptExtension.TypeName, "CustomScriptForLinux");
                Assert.Equal(customScriptExtension.AutoUpgradeMinorVersionEnabled, true);

                // Ensure the public settings are accessible, the protected settings won't be returned from the service.
                //
                var publicSettings = customScriptExtension.PublicSettings;
                Assert.NotNull(publicSettings);
                Assert.Equal(2, publicSettings.Count);
                Assert.True(publicSettings.ContainsKey("fileUris"));
                Assert.True(publicSettings.ContainsKey("commandToExecute"));
                string commandToExecute = (string)publicSettings["commandToExecute"];
                Assert.NotNull(commandToExecute);
                Assert.True(commandToExecute.Equals(installCommand, StringComparison.OrdinalIgnoreCase));

                // Remove the custom extension
                //
                vm.Update()
                        .WithoutExtension("CustomScriptForLinux")
                        .Apply();

                Assert.True(vm.ListExtensions().Count() == 0);
            }
        }

        [Fact]
        public void CanHandleExtensionReference()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("vmexttest");
                string location = "eastus";
                string vmName = "javavm";

                var azure = TestHelper.CreateRollupClient();

                // Create a Linux VM
                //
                var vm = azure.VirtualMachines
                    .Define(vmName)
                    .WithRegion(location)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer14_04_Lts)
                    .WithRootUsername("Foo12")
                    .WithRootPassword("BaR@12abc!")
                    .WithSize(VirtualMachineSizeTypes.StandardDS3V2)
                    .DefineNewExtension("VMAccessForLinux")
                        .WithPublisher("Microsoft.OSTCExtensions")
                        .WithType("VMAccessForLinux")
                        .WithVersion("1.4")
                        .WithProtectedSetting("username", "Foo12")
                        .WithProtectedSetting("password", "B12a6@12xyz!")
                        .WithProtectedSetting("reset_ssh", "true")
                    .Attach()
                    .Create();

                Assert.True(vm.ListExtensions().Count() > 0);

                // Get the created virtual machine via VM List not by VM GET
                var virtualMachines = azure.VirtualMachines
                    .ListByResourceGroup(rgName);
                IVirtualMachine vmWithExtensionReference = null;
                foreach (var virtualMachine in virtualMachines)
                {
                    if (virtualMachine.Name.Equals(vmName, StringComparison.OrdinalIgnoreCase))
                    {
                        vmWithExtensionReference = virtualMachine;
                        break;
                    }
                }
                // The VM retrieved from the list will contain extensions as reference (i.e. with only id)
                Assert.NotNull(vmWithExtensionReference);

                // Update the extension
                var vmWithExtensionUpdated = vmWithExtensionReference.Update()
                    .UpdateExtension("VMAccessForLinux")
                    .WithProtectedSetting("username", "Foo12")
                    .WithProtectedSetting("password", "muy!234OR")
                    .WithProtectedSetting("reset_ssh", "true")
                    .Parent()
                    .Apply();

                // Again getting VM with extension reference
                virtualMachines = azure.VirtualMachines
                    .ListByResourceGroup(rgName);
                vmWithExtensionReference = null;
                foreach (var virtualMachine in virtualMachines)
                {
                    vmWithExtensionReference = virtualMachine;
                }

                Assert.NotNull(vmWithExtensionReference);

                IVirtualMachineExtension accessExtension = null;
                foreach (var extension in vmWithExtensionReference.ListExtensions().Values)
                {
                    if (extension.Name.Equals("VMAccessForLinux", StringComparison.OrdinalIgnoreCase))
                    {
                        accessExtension = extension;
                        break;
                    }
                }

                // Even though VM's inner contain just extension reference VirtualMachine::extensions()
                // should resolve the reference and get full extension.
                Assert.NotNull(accessExtension);
                Assert.NotNull(accessExtension.PublisherName);
                Assert.NotNull(accessExtension.TypeName);
                Assert.NotNull(accessExtension.VersionName);
            }
        }

        [Fact]
        public void CanUpdateExtensionPublicPrivateSettings()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                Region region = Region.USEast2;
                string rgName = TestUtilities.GenerateName("javacsmrg");
                string stgName = TestUtilities.GenerateName("stg");
                string vmName = TestUtilities.GenerateName("extvm");

                var azure = TestHelper.CreateRollupClient();

                var storageAccount = azure.StorageAccounts
                    .Define(stgName)
                    .WithRegion(Region.USEast2)
                    .WithNewResourceGroup(rgName)
                    .Create();

                /*** CREATE VIRTUAL MACHINE WITH AN EXTENSION **/

                var keys = storageAccount.GetKeys();
                Assert.NotNull(keys);
                Assert.True(keys.Count() > 0);
                var storageAccountKey = keys.First();
                string uri = prepareCustomScriptStorageUri(storageAccount.Name, storageAccountKey.Value, "scripts");

                List<string> fileUris = new List<string>();
                fileUris.Add(uri);
                string commandToExecute = "bash install_apache.sh";

                var vm = azure.VirtualMachines
                    .Define(vmName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer14_04_Lts)
                    .WithRootUsername("Foo12")
                    .WithRootPassword("BaR@12abc!")
                    .WithSize(VirtualMachineSizeTypes.StandardDS3V2)
                    .DefineNewExtension("CustomScriptForLinux")
                        .WithPublisher("Microsoft.OSTCExtensions")
                        .WithType("CustomScriptForLinux")
                        .WithVersion("1.4")
                        .WithMinorVersionAutoUpgrade()
                        .WithPublicSetting("fileUris", fileUris)
                        .WithProtectedSetting("commandToExecute", commandToExecute)
                        .WithProtectedSetting("storageAccountName", storageAccount.Name)
                        .WithProtectedSetting("storageAccountKey", storageAccountKey.Value)
                        .Attach()
                    .Create();

                Assert.True(vm.ListExtensions().Count > 0);
                Assert.True(vm.ListExtensions().ContainsKey("CustomScriptForLinux"));
                IVirtualMachineExtension customScriptExtension;
                Assert.True(vm.ListExtensions().TryGetValue("CustomScriptForLinux", out customScriptExtension));
                Assert.NotNull(customScriptExtension);
                Assert.Equal(customScriptExtension.PublisherName, "Microsoft.OSTCExtensions");
                Assert.Equal(customScriptExtension.TypeName, "CustomScriptForLinux");
                Assert.Equal(customScriptExtension.AutoUpgradeMinorVersionEnabled, true);

                // Special check for C# implementation, seems runtime changed the actual type
                // of public settings from dictionary to Newtonsoft.Json.Linq.JObject.
                // In future such changes needs to be catched before attemptting inner conversion
                // hence the below special validation (not applicable for Java)
                //
                Assert.NotNull(customScriptExtension.Inner);
                Assert.NotNull(customScriptExtension.Inner.Settings);
                bool isJObject = customScriptExtension.Inner.Settings is JObject;
                bool isDictionary = customScriptExtension.Inner.Settings is IDictionary<string, object>;
                Assert.True(isJObject || isDictionary);

                // Ensure the public settings are accessible, the protected settings won't be returned from the service.
                //
                var publicSettings = customScriptExtension.PublicSettings;
                Assert.NotNull(publicSettings);
                Assert.Equal(1, publicSettings.Count);
                Assert.True(publicSettings.ContainsKey("fileUris"));
                string fileUrisString = (publicSettings["fileUris"]).ToString();
                if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                {
                    Assert.True(fileUrisString.Contains(uri));
                }

                /*** UPDATE THE EXTENSION WITH NEW PUBLIC AND PROTECTED SETTINGS **/

                // Regenerate the storage account key
                //
                storageAccount.RegenerateKey(storageAccountKey.KeyName);
                keys = storageAccount.GetKeys();
                Assert.NotNull(keys);
                Assert.True(keys.Count() > 0);
                var updatedStorageAccountKey = keys.FirstOrDefault(key => key.KeyName.Equals(storageAccountKey.KeyName, StringComparison.OrdinalIgnoreCase));
                Assert.NotNull(updatedStorageAccountKey);
                Assert.NotEqual(updatedStorageAccountKey.Value, storageAccountKey.Value);

                // Upload the script to a different container ("scripts2") in the same storage account
                //
                var uri2 = prepareCustomScriptStorageUri(storageAccount.Name, updatedStorageAccountKey.Value, "scripts2");
                List<string> fileUris2 = new List<string>();
                fileUris2.Add(uri2);
                string commandToExecute2 = "bash install_apache.sh";

                vm.Update()
                    .UpdateExtension("CustomScriptForLinux")
                        .WithPublicSetting("fileUris", fileUris2)
                        .WithProtectedSetting("commandToExecute", commandToExecute2)
                        .WithProtectedSetting("storageAccountName", storageAccount.Name)
                        .WithProtectedSetting("storageAccountKey", updatedStorageAccountKey.Value)
                        .Parent()
                    .Apply();

                Assert.True(vm.ListExtensions().Count > 0);
                Assert.True(vm.ListExtensions().ContainsKey("CustomScriptForLinux"));
                IVirtualMachineExtension customScriptExtension2;
                Assert.True(vm.ListExtensions().TryGetValue("CustomScriptForLinux", out customScriptExtension2));
                Assert.NotNull(customScriptExtension2);
                Assert.Equal(customScriptExtension2.PublisherName, "Microsoft.OSTCExtensions");
                Assert.Equal(customScriptExtension2.TypeName, "CustomScriptForLinux");
                Assert.Equal(customScriptExtension2.AutoUpgradeMinorVersionEnabled, true);

                var publicSettings2 = customScriptExtension2.PublicSettings;
                Assert.NotNull(publicSettings2);
                Assert.Equal(1, publicSettings2.Count);
                Assert.True(publicSettings2.ContainsKey("fileUris"));

                string fileUris2String = (publicSettings2["fileUris"]).ToString();
                if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                {
                    Assert.True(fileUris2String.Contains(uri2));
                }
            }
        }

        private string prepareCustomScriptStorageUri(string storageAccountName, string storageAccountKey, string containerName)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                return "http://nonexisting.blob.core.windows.net/scripts2/install_apache.sh";
            }
            var storageConnectionString = $"DefaultEndpointsProtocol=http;AccountName={storageAccountName};AccountKey={storageAccountKey}";
            CloudStorageAccount account = CloudStorageAccount.Parse(storageConnectionString);
            CloudBlobClient cloudBlobClient = account.CreateCloudBlobClient();
            CloudBlobContainer container = cloudBlobClient.GetContainerReference(containerName);
            bool createdNew = container.CreateIfNotExistsAsync().Result;
            CloudBlockBlob blob = container.GetBlockBlobReference("install_apache.sh");
            using (HttpClient client = new HttpClient())
            {
                blob.UploadFromStreamAsync(client.GetStreamAsync("https://raw.githubusercontent.com/Azure/azure-sdk-for-net/Fluent/Tests/Fluent.Tests/Assets/install_apache.sh").Result).Wait();
            }
            return blob.Uri.ToString();
        }
    }
}
