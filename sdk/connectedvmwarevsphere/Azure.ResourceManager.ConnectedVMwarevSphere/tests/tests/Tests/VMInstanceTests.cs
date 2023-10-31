// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.ConnectedVMwarevSphere.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests.tests.Tests
{
    public partial class Test_VirtualMachineInstanceResource
    {
        [TestCase]
        [RecordedTest]
        public async Task CreateDelete()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/CreateVirtualMachineInstance.json
            // this example is just showing the usage of "VirtualMachineInstances_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VirtualMachineInstanceResource created on azure
            // for more information of creating VirtualMachineInstanceResource, please refer to the document of VirtualMachineInstanceResource
            string resourceUri = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.HybridCompute/machines/test-machine-dotnet";
            ResourceIdentifier virtualMachineInstanceResourceId = VMwareVmInstanceResource.CreateResourceIdentifier(resourceUri);
            VMwareVmInstanceResource vMwareVmInstance = client.GetVMwareVmInstanceResource(virtualMachineInstanceResourceId);

            // invoke the operation
            VMwareVmInstanceData data = new VMwareVmInstanceData()
            {
                ExtendedLocation = new ExtendedLocation()
                {
                    Name = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/azcli-test-rg/providers/microsoft.extendedlocation/customlocations/azcli-test-cl",
                    ExtendedLocationType = "CustomLocation",
                },
                PlacementProfile = new PlacementProfile()
                {
                    ResourcePoolId = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.ConnectedVMwarevSphere/ResourcePools/azcli-test-rp",
                },
                HardwareProfile = new VmInstanceHardwareProfile()
                {
                    MemorySizeMB = 4196,
                    NumCpus = 4,
                },
                InfrastructureProfile = new VCenterInfrastructureProfile()
                {
                    TemplateId = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.ConnectedVMwarevSphere/VirtualMachineTemplates/azcli-test-linux-tmpl",
                    VCenterId = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc",
                },
            };
            ArmOperation<VMwareVmInstanceResource> lro = await vMwareVmInstance.CreateOrUpdateAsync(WaitUntil.Completed, data);
            VMwareVmInstanceResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            VMwareVmInstanceData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // GetVirtualMachine
        [TestCase]
        [RecordedTest]
        public async Task Get_GetVirtualMachine()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/GetVirtualMachineInstance.json
            // this example is just showing the usage of "VirtualMachineInstances_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VirtualMachineInstanceResource created on azure
            // for more information of creating VirtualMachineInstanceResource, please refer to the document of VirtualMachineInstanceResource
            string resourceUri = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.HybridCompute/machines/test-machine-dotnet";
            ResourceIdentifier virtualMachineInstanceResourceId = VMwareVmInstanceResource.CreateResourceIdentifier(resourceUri);
            VMwareVmInstanceResource virtualMachineInstance = client.GetVMwareVmInstanceResource(virtualMachineInstanceResourceId);

            // invoke the operation
            VMwareVmInstanceResource result = await virtualMachineInstance.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            VMwareVmInstanceData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // UpdateVirtualMachine
        [TestCase]
        [RecordedTest]
        public async Task Update_UpdateVirtualMachine()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/UpdateVirtualMachineInstance.json
            // this example is just showing the usage of "VirtualMachineInstances_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VirtualMachineInstanceResource created on azure
            // for more information of creating VirtualMachineInstanceResource, please refer to the document of VirtualMachineInstanceResource
            string resourceUri = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.HybridCompute/machines/test-machine-dotnet";
            ResourceIdentifier virtualMachineInstanceResourceId = VMwareVmInstanceResource.CreateResourceIdentifier(resourceUri);
            VMwareVmInstanceResource vMwareVmInstance = client.GetVMwareVmInstanceResource(virtualMachineInstanceResourceId);

            // invoke the operation
            VMwareVmInstancePatch patch = new VMwareVmInstancePatch()
            {
                HardwareProfile = new VmInstanceHardwareProfile()
                {
                    MemorySizeMB = 4196,
                    NumCpus = 4,
                },
            };
            ArmOperation<VMwareVmInstanceResource> lro = await vMwareVmInstance.UpdateAsync(WaitUntil.Completed, patch);
            VMwareVmInstanceResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            VMwareVmInstanceData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // StopVirtualMachine
        [TestCase]
        [RecordedTest]
        public async Task Stop_StopVirtualMachine()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/StopVirtualMachineInstance.json
            // this example is just showing the usage of "VirtualMachineInstances_Stop" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VirtualMachineInstanceResource created on azure
            // for more information of creating VirtualMachineInstanceResource, please refer to the document of VirtualMachineInstanceResource
            string resourceUri = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.HybridCompute/machines/test-machine-dotnet";
            ResourceIdentifier virtualMachineInstanceResourceId = VMwareVmInstanceResource.CreateResourceIdentifier(resourceUri);
            VMwareVmInstanceResource virtualMachineInstance = client.GetVMwareVmInstanceResource(virtualMachineInstanceResourceId);

            // invoke the operation
            StopVirtualMachineContent content = new StopVirtualMachineContent()
            {
                SkipShutdown = true,
            };
            await virtualMachineInstance.StopAsync(WaitUntil.Completed, content: content);

            Console.WriteLine($"Succeeded");
        }

        // StartVirtualMachine
        [TestCase]
        [RecordedTest]
        public async Task Start_StartVirtualMachine()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/StartVirtualMachineInstance.json
            // this example is just showing the usage of "VirtualMachineInstances_Start" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VirtualMachineInstanceResource created on azure
            // for more information of creating VirtualMachineInstanceResource, please refer to the document of VirtualMachineInstanceResource
            string resourceUri = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.HybridCompute/machines/test-machine-dotnet";
            ResourceIdentifier virtualMachineInstanceResourceId = VMwareVmInstanceResource.CreateResourceIdentifier(resourceUri);
            VMwareVmInstanceResource virtualMachineInstance = client.GetVMwareVmInstanceResource(virtualMachineInstanceResourceId);

            // invoke the operation
            await virtualMachineInstance.StartAsync(WaitUntil.Completed);

            Console.WriteLine($"Succeeded");
        }

        // RestartVirtualMachine
        [TestCase]
        [RecordedTest]
        public async Task Restart_RestartVirtualMachine()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/RestartVirtualMachineInstance.json
            // this example is just showing the usage of "VirtualMachineInstances_Restart" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VirtualMachineInstanceResource created on azure
            // for more information of creating VirtualMachineInstanceResource, please refer to the document of VirtualMachineInstanceResource
            string resourceUri = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.HybridCompute/machines/test-machine-dotnet";
            ResourceIdentifier virtualMachineInstanceResourceId = VMwareVmInstanceResource.CreateResourceIdentifier(resourceUri);
            VMwareVmInstanceResource virtualMachineInstance = client.GetVMwareVmInstanceResource(virtualMachineInstanceResourceId);

            // invoke the operation
            await virtualMachineInstance.RestartAsync(WaitUntil.Completed);

            Console.WriteLine($"Succeeded");
        }
    }
}
