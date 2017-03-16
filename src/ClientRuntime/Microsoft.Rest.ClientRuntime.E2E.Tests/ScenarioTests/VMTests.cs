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

    public class VMTests : E2ETestBase
    {
        const string prefix = "e2etests";
        const string resourcePrefix = "res";
        const string storagePrefix = "sto";
        const string networkPrefix = "net";
        const string vmPrefix = "vm";

        /// <summary>
        /// Constructor
        /// </summary>
        public VMTests() : base(prefix)
        {

        }

        [Fact]
        public void UpdateVM_DoNotSerializeProtected()
        {
            string guidString = "f978ade9"; //We need to be under 24 char for storage, so making it shorter for almost all names
            string resourceGroupName = string.Format("{0}-{1}-{2}", prefix, resourcePrefix, guidString);
            string storageName = string.Format("{0}{1}{2}", prefix, storagePrefix, guidString);
            string vmName = string.Format("{0}-{1}-{2}", prefix, vmPrefix, guidString);

            VirtualMachine vm1;
            ResourceGroup resGroup = null;
        
            using (base.MockContext = MockContext.Start(this.GetType().FullName))
            {
                try
                {
                    string newVmId = "5C6F1669-C183-4BFC-9BBB-138E0892E917";
                    string asName = "as5913";
                    resGroup = CreateResourceGroup(resourceGroupName);
                    StorageAccount storageAccount = CreateStorageAccount(resGroup, storageName);
                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                    VirtualMachine vm = CreateVM_NoAsyncTracking(resGroup.Name, vmName, asName, storageAccount, imageRef, out vm1);
                    
                    //Create a new VM and Update VmId protected Property
                    MyVm myNewVm = new MyVm(vm);
                    myNewVm.UpdateVm(newVmId);
                    VirtualMachine updatedVm = myNewVm as VirtualMachine;

                    // Update VM
                    AzureOperationResponse<VirtualMachine> res = Task<AzureOperationResponse<VirtualMachine>>.Run(async () =>
                    {
                        return await ComputeClient.VirtualMachines.BeginCreateOrUpdateWithHttpMessagesAsync(resGroup.Name, updatedVm.Name, updatedVm).ConfigureAwait(false);
                    }).GetAwaiter().GetResult();

                    //Get Request Content and verify it does not contain VmId property
                    string requestContentStr = ComputeClient.GetRequestContent();
                    Assert.False(requestContentStr.Contains("VmId"));

                    //Get VM Object
                    VirtualMachine getVm = res.Body;

                    // Verify the vmPutResponse does not contain updated VmId
                    Assert.NotEqual(newVmId, getVm.VmId);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
                finally
                {
                    ResourceClient.ResourceGroups.Delete(resGroup.Name);
                }
            }
        }
    }
}
