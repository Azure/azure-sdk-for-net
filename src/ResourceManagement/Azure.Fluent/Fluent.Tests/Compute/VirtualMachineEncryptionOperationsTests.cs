// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests.Compute
{
    public class VirtualMachineEncryptionOperationsTests
    {
        [Fact(Skip = "Manual only: Requires ServicePrincipal, KeyVault creation and association, requires SSH to vm and perform mounting")]
        public void CanEncryptVirtualMachine()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgstg");
                try
                {
                    // https://docs.microsoft.com/en-us/azure/security/azure-security-disk-encryption
                    //
                    // KeyVault Resource ID
                    string  keyVaultId = "KEY_VAULT_ID_HERE";
                    // Azure AD service principal client (application) ID
                    string aadClientId = "AAD_APPLICATION_ID_HERE";
                    // Azure AD service principal client secret
                    string aadSecret = "AAD_CLIENT_SECRET_HERE";

                    // Create
                    IComputeManager computeManager = TestHelper.CreateComputeManager();
                    var publicIpDnsLabel = TestUtilities.GenerateName("pip");
                    var vmName1 = "myvm1";
                    var uname = "juser";
                    var password = "123tEst!@|ac";
                    var virtualMachine = computeManager.VirtualMachines
                            .Define(vmName1)
                                .WithRegion(Region.USEast2)
                                .WithNewResourceGroup(rgName)
                                .WithNewPrimaryNetwork("10.0.0.0/28")
                                .WithPrimaryPrivateIPAddressDynamic()
                                .WithNewPrimaryPublicIPAddress(publicIpDnsLabel)
                                .WithLatestLinuxImage("RedHat", "RHEL", "7.2")
                                .WithRootUsername(uname)
                                .WithRootPassword(password)
                                .WithSize(VirtualMachineSizeTypes.StandardD5V2)
                                .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .Create();

                    // Check inital encryption status
                    //
                    var monitor = virtualMachine.DiskEncryption.GetMonitor();
                    Assert.NotNull(monitor);
                    Assert.NotNull(monitor.OsDiskStatus);
                    Assert.NotNull(monitor.DataDiskStatus);
                    Assert.True(monitor.OsDiskStatus.Equals(EncryptionStatus.NotEncrypted));
                    Assert.True(monitor.DataDiskStatus.Equals(EncryptionStatus.NotEncrypted));
                    // Check monitor refresh
                    //
                    var monitor1 = monitor.Refresh();
                    Assert.NotNull(monitor1);
                    Assert.NotNull(monitor1.OsDiskStatus);
                    Assert.NotNull(monitor1.DataDiskStatus);
                    Assert.True(monitor.OsDiskStatus.Equals(EncryptionStatus.NotEncrypted));
                    Assert.True(monitor.DataDiskStatus.Equals(EncryptionStatus.NotEncrypted));

                    var monitor2 = virtualMachine
                        .DiskEncryption
                        .Enable(keyVaultId, aadClientId, aadSecret);

                    Assert.NotNull(monitor2);
                    Assert.NotNull(monitor2.OsDiskStatus);
                    Assert.NotNull(monitor2.DataDiskStatus);
                    monitor1.Refresh();
                    Assert.True(monitor1.OsDiskStatus.Equals(monitor2.OsDiskStatus));
                    Assert.True(monitor1.DataDiskStatus.Equals(monitor2.DataDiskStatus));
                    monitor2.Refresh();
                    Assert.True(monitor2.OsDiskStatus.Equals(EncryptionStatus.EncryptionInProgress));
                    Console.WriteLine(virtualMachine.Id);
                }
                finally
                {
                    try
                    {
                        var resourceManager = TestHelper.CreateResourceManager();
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }
    }
}
