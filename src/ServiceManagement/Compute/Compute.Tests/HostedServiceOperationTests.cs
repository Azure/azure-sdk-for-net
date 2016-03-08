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

using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Testing;

namespace Microsoft.WindowsAzure.Management.Compute.Testing
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.WindowsAzure.Management.Compute.Models;
    using Microsoft.WindowsAzure.Management.Storage.Models;
    using Microsoft.Azure.Test;
    using Xunit;

    public class HostedServiceOperationTests : TestBase, IUseFixture<TestFixtureData>
    {
        private TestFixtureData fixture;

        public void SetFixture(TestFixtureData data)
        {
            data.Instantiate(TestUtilities.GetCallingClass());
            fixture = data;
        }

        [Fact]
        public void CanCreateServiceDeployments()
        {
            TestLogTracingInterceptor.Current.Start();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var mgmt = fixture.GetManagementClient();
                var compute = fixture.GetComputeManagementClient();
                var storage = fixture.GetStorageManagementClient();

                try
                {
                    var storageAccountName = HttpMockServer.GetAssetName("teststorage1234", "teststorage").ToLower();
                    string serviceName = TestUtilities.GenerateName("testsvc");
                    string deploymentName = string.Format("{0}Prod", serviceName);
                    string location = mgmt.GetDefaultLocation("Storage", "Compute");

                    const string usWestLocStr = "West US";
                    if (mgmt.Locations.List().Any(
                        c => string.Equals(c.Name, usWestLocStr, StringComparison.OrdinalIgnoreCase)))
                    {
                        location = usWestLocStr;
                    }

                    var st1 = storage.StorageAccounts.Create(
                        new StorageAccountCreateParameters
                        {
                            Location = location,
                            Label = storageAccountName,
                            Name = storageAccountName,
                            AccountType = "Standard_LRS"
                        });

                    var st2 = compute.HostedServices.Create(
                        new HostedServiceCreateParameters
                        {
                            Location = location,
                            Label = serviceName,
                            ServiceName = serviceName
                        });

                    var cfgFilePath = "OneWebOneWorker.cscfg";
                    var containerStr = TestUtilities.GenerateName("cspkg");
                    var pkgFileName = "OneWebOneWorker.cspkg";
                    var pkgFilePath = ".\\" + pkgFileName;
                    var blobUri = StorageTestUtilities.UploadFileToBlobStorage(
                        storageAccountName,
                        containerStr,
                        pkgFilePath);
                    var blobUriStr = blobUri.ToString();
                    var containerUriStr = blobUriStr.Substring(0, blobUriStr.IndexOf("/" + pkgFileName));
                    containerUriStr = containerUriStr.Replace("https", "http");
                    var containerUri = new Uri(containerUriStr);

                    var st3 = compute.Deployments.Create(
                        serviceName,
                        DeploymentSlot.Production,
                        new DeploymentCreateParameters
                        {
                            Configuration = File.ReadAllText(cfgFilePath),
                            PackageUri = blobUri,
                            Name = deploymentName,
                            Label = serviceName,
                            ExtendedProperties = null,
                            StartDeployment = true,
                            TreatWarningsAsError = false,
                            ExtensionConfiguration = null
                        });

                    Assert.True(st3.StatusCode == HttpStatusCode.OK);

                    var st4 = compute.Deployments.GetPackageByName(
                        serviceName,
                        deploymentName,
                        new DeploymentGetPackageParameters
                        {
                            OverwriteExisting = true,
                            ContainerUri = containerUri
                        });

                    Assert.True(st4.StatusCode == HttpStatusCode.OK);

                    var roles = compute.Deployments
                                       .GetBySlot(serviceName, DeploymentSlot.Production)
                                       .Roles.ToList();

                    Assert.True(roles.TrueForAll(r => !string.IsNullOrEmpty(r.OSVersion)));

                    var roleInstanceNames = compute.Deployments
                                                   .GetBySlot(serviceName, DeploymentSlot.Production)
                                                   .RoleInstances.Select(r => r.InstanceName).ToList();

                    Assert.True(roleInstanceNames.Any(r => r.StartsWith("WebRole1"))
                             && roleInstanceNames.Any(r => r.StartsWith("WorkerRole1")));

                    // Check Rebuild Role Instance APIs
                    var instName1 = roleInstanceNames.First(r => r.StartsWith("WebRole1"));
                    var instName2 = roleInstanceNames.First(r => r.StartsWith("WorkerRole1"));

                    WaitForReadyRoleInstance(compute, serviceName, deploymentName, instName1);
                    var modifiedTimeBefore = compute.Deployments.GetByName(serviceName, deploymentName)
                                                    .LastModifiedTime;
                    compute.Deployments.RebuildRoleInstanceByDeploymentName(
                        serviceName,
                        deploymentName,
                        instName1,
                        RoleInstanceRebuildResourceTypes.AllLocalDrives);
                    var inStatus = compute.Deployments.GetByName(serviceName, deploymentName)
                                          .RoleInstances.First(r => r.InstanceName == instName1)
                                          .InstanceStatus;
                    WaitForReadyRoleInstance(compute, serviceName, deploymentName, instName1);
                    var modifiedTimeAfter = compute.Deployments.GetByName(serviceName, deploymentName)
                                                   .LastModifiedTime;
                    Assert.True(!modifiedTimeAfter.Equals(modifiedTimeBefore));

                    WaitForReadyRoleInstance(compute, serviceName, deploymentName, instName2);
                    modifiedTimeBefore = compute.Deployments.GetByName(serviceName, deploymentName)
                                                .LastModifiedTime;
                    compute.Deployments.RebuildRoleInstanceByDeploymentSlot(
                        serviceName,
                        DeploymentSlot.Production.ToString(),
                        instName2,
                        RoleInstanceRebuildResourceTypes.AllLocalDrives);
                    inStatus = compute.Deployments.GetByName(serviceName, deploymentName)
                                      .RoleInstances.First(r => r.InstanceName == instName2)
                                      .InstanceStatus;
                    Assert.True(inStatus != RoleInstanceStatus.ReadyRole);
                    WaitForReadyRoleInstance(compute, serviceName, deploymentName, instName2);
                    modifiedTimeAfter = compute.Deployments.GetByName(serviceName, deploymentName)
                                               .LastModifiedTime;
                    Assert.True(!modifiedTimeAfter.Equals(modifiedTimeBefore));

                    // Check Upgrade Deployment API
                    compute.Deployments.UpgradeByName(
                        serviceName,
                        deploymentName,
                        new DeploymentUpgradeParameters
                        {
                            Configuration = File.ReadAllText(cfgFilePath),
                            PackageUri = blobUri,
                            Force = true,
                            Label = "UpgradeByName",
                            Mode = DeploymentUpgradeMode.Auto,
                            RoleToUpgrade = null,
                            ExtendedProperties = null,
                            ExtensionConfiguration = null
                        });
                    Assert.True(compute.Deployments.GetByName(serviceName, deploymentName).Label == "UpgradeByName");

                    compute.Deployments.UpgradeBySlot(
                        serviceName,
                        DeploymentSlot.Production,
                        new DeploymentUpgradeParameters
                        {
                            Configuration = File.ReadAllText(cfgFilePath),
                            PackageUri = blobUri,
                            Force = true,
                            Label = "UpgradeBySlot",
                            Mode = DeploymentUpgradeMode.Auto,
                            RoleToUpgrade = null,
                            ExtendedProperties = null,
                            ExtensionConfiguration = null
                        });
                    Assert.True(compute.Deployments.GetByName(serviceName, deploymentName).Label == "UpgradeBySlot");

                    // Check Delete Role Instance APIs
                    compute.Deployments.DeleteRoleInstanceByDeploymentName(
                        serviceName,
                        deploymentName,
                        new DeploymentDeleteRoleInstanceParameters
                        {
                            Name = new List<string> { instName1 }
                        });

                    compute.Deployments.DeleteRoleInstanceByDeploymentSlot(
                        serviceName,
                        DeploymentSlot.Production.ToString(),
                        new DeploymentDeleteRoleInstanceParameters
                        {
                            Name = new List<string> { instName2 }
                        });

                    roleInstanceNames = compute.Deployments
                                               .GetBySlot(serviceName, DeploymentSlot.Production)
                                               .RoleInstances.Select(r => r.InstanceName).ToList();

                    Assert.True(!roleInstanceNames.Any(r => r == instName1 || r == instName2));
                }
                finally
                {
                    undoContext.Dispose();
                    mgmt.Dispose();
                    compute.Dispose();
                    storage.Dispose();
                    TestLogTracingInterceptor.Current.Stop();
                }
            }
        }

        private void WaitForReadyRoleInstance(
            ComputeManagementClient compute,
            string serviceName,
            string deploymentName,
            string instanceName)
        {
            string inStatus = null;
            bool isReady = false;
            int iteration = 0;
            const int NUM_ITERATIONS = 100;

            while (!isReady && iteration < NUM_ITERATIONS)
            {
                TestUtilities.Wait(TimeSpan.FromSeconds(30));
                inStatus = compute.Deployments.GetByName(serviceName, deploymentName)
                                  .RoleInstances.First(r => r.InstanceName == instanceName)
                                  .InstanceStatus;
                isReady = inStatus == RoleInstanceStatus.ReadyRole;
            }
        }
    }
}
