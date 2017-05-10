// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.E2E.Tests.ScenarioTests
{
    using Microsoft.Azure.Management.Compute;
    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.Storage.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Rest.ClientRuntime.E2E.Tests.TestAssets;
    using Rest.Azure;
    using System.Net;
    using Xunit;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System;
    using System.Net.Http;
    using Microsoft.Azure.Test.HttpRecorder;
    using System.Reflection;
    using System.IO;

    public class VMTests : E2ETestBase
    {
        const string prefix = "e2etests";
        const string resourcePrefix = "res";
        const string storagePrefix = "sto";
        const string networkPrefix = "net";
        const string vmPrefix = "vm";

        /// <summary>
        /// Constructor for Test class
        /// </summary>
        public VMTests() : base(prefix)
        { }

        [Fact]
        public void UpdateVM_DoNotSerializeProtected()
        {
            string guidString = "f978ade9"; //We need to be under 24 char for storage, so making it shorter for almost all names
            string resourceGroupName = string.Format("{0}-{1}-{2}", prefix, resourcePrefix, guidString);
            string storageName = string.Format("{0}{1}{2}", prefix, storagePrefix, guidString);
            string vmName = string.Format("{0}-{1}-{2}", prefix, vmPrefix, guidString);
            
            VirtualMachine vm1;
            ResourceGroup resGroup = null;            
            //string executingAssemblyPath = typeof(Microsoft.Rest.ClientRuntime.E2E.Tests.ScenarioTests.VMTests).GetTypeInfo().Assembly.Location;
            //HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            try
            {
                using (base.MockContext = MockContext.Start(this.GetType().FullName))
                {
                    //Type.GetType("System.Int32").GetTypeInfo().Assembly.Location
                    string newVmId = "5C6F1669-C183-4BFC-9BBB-138E0892E917";
                    string asName = "as5913";
                    resGroup = CreateResourceGroup(resourceGroupName);
                    StorageAccount storageAccount = CreateStorageAccount(resGroup, storageName);
                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                    VirtualMachine vm = CreateVirtualMachine(resGroup.Name, vmName, asName, storageAccount.Name, imageRef, out vm1);

                    //Create a new VM and Update VmId protected Property
                    MyVm myNewVm = new MyVm(vm);
                    myNewVm.UpdateVm(newVmId);
                    VirtualMachine updatedVm = myNewVm as VirtualMachine;

                    // Update VM
                    AzureOperationResponse<VirtualMachine> putResponse = Task<AzureOperationResponse<VirtualMachine>>.Run(async () =>
                    {
                        return await ComputeClient.VirtualMachines.BeginCreateOrUpdateWithHttpMessagesAsync(resGroup.Name, updatedVm.Name, updatedVm).ConfigureAwait(false);
                    }).GetAwaiter().GetResult();

                    //Get Request Content and verify it does not contain VmId property
                    string requestContentStr = ComputeClient.GetRequestContent();
                    Assert.False(requestContentStr.Contains("VmId"));

                    //Get VM Object
                    VirtualMachine getVm = putResponse.Body;

                    // Verify the vmPutResponse does not contain updated VmId
                    Assert.NotEqual(newVmId, getVm.VmId);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                ResourceClient.ResourceGroups.Delete(resGroup.Name);
            }
        }
    }
}
