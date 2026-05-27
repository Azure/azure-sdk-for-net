// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.DevTestLabs.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DevTestLabs.Samples
{
    public partial class Sample_LabVirtualmachineScheduleResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_VirtualMachineSchedulesGet()
        {
            // Generated from example definition: 2018-09-15/VirtualMachineSchedules_Get.json
            // this example is just showing the usage of "VirtualMachineSchedules_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DevTestLabVmScheduleResource created on azure
            // for more information of creating DevTestLabVmScheduleResource, please refer to the document of DevTestLabVmScheduleResource
            string subscriptionId = "{subscriptionId}";
            string resourceGroupName = "resourceGroupName";
            string labName = "{labName}";
            string virtualMachineName = "{vmName}";
            string name = "LabVmsShutdown";
            ResourceIdentifier labVirtualmachineScheduleResourceId = DevTestLabVmScheduleResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, labName, virtualMachineName, name);
            DevTestLabVmScheduleResource labVirtualmachineSchedule = client.GetDevTestLabVmScheduleResource(labVirtualmachineScheduleResourceId);

            // invoke the operation
            DevTestLabVmScheduleResource result = await labVirtualmachineSchedule.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DevTestLabScheduleData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_VirtualMachineSchedulesDelete()
        {
            // Generated from example definition: 2018-09-15/VirtualMachineSchedules_Delete.json
            // this example is just showing the usage of "VirtualMachineSchedules_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DevTestLabVmScheduleResource created on azure
            // for more information of creating DevTestLabVmScheduleResource, please refer to the document of DevTestLabVmScheduleResource
            string subscriptionId = "{subscriptionId}";
            string resourceGroupName = "resourceGroupName";
            string labName = "{labName}";
            string virtualMachineName = "{vmName}";
            string name = "LabVmsShutdown";
            ResourceIdentifier labVirtualmachineScheduleResourceId = DevTestLabVmScheduleResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, labName, virtualMachineName, name);
            DevTestLabVmScheduleResource labVirtualmachineSchedule = client.GetDevTestLabVmScheduleResource(labVirtualmachineScheduleResourceId);

            // invoke the operation
            await labVirtualmachineSchedule.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_VirtualMachineSchedulesUpdate()
        {
            // Generated from example definition: 2018-09-15/VirtualMachineSchedules_Update.json
            // this example is just showing the usage of "VirtualMachineSchedules_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DevTestLabVmScheduleResource created on azure
            // for more information of creating DevTestLabVmScheduleResource, please refer to the document of DevTestLabVmScheduleResource
            string subscriptionId = "{subscriptionId}";
            string resourceGroupName = "resourceGroupName";
            string labName = "{labName}";
            string virtualMachineName = "{vmName}";
            string name = "LabVmsShutdown";
            ResourceIdentifier labVirtualmachineScheduleResourceId = DevTestLabVmScheduleResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, labName, virtualMachineName, name);
            DevTestLabVmScheduleResource labVirtualmachineSchedule = client.GetDevTestLabVmScheduleResource(labVirtualmachineScheduleResourceId);

            // invoke the operation
            DevTestLabSchedulePatch patch = new DevTestLabSchedulePatch
            {
                Tags =
{
["tagName1"] = "tagValue1"
},
            };
            DevTestLabVmScheduleResource result = await labVirtualmachineSchedule.UpdateAsync(patch);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DevTestLabScheduleData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Execute_VirtualMachineSchedulesExecute()
        {
            // Generated from example definition: 2018-09-15/VirtualMachineSchedules_Execute.json
            // this example is just showing the usage of "VirtualMachineSchedules_Execute" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DevTestLabVmScheduleResource created on azure
            // for more information of creating DevTestLabVmScheduleResource, please refer to the document of DevTestLabVmScheduleResource
            string subscriptionId = "{subscriptionId}";
            string resourceGroupName = "resourceGroupName";
            string labName = "{labName}";
            string virtualMachineName = "{vmName}";
            string name = "LabVmsShutdown";
            ResourceIdentifier labVirtualmachineScheduleResourceId = DevTestLabVmScheduleResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, labName, virtualMachineName, name);
            DevTestLabVmScheduleResource labVirtualmachineSchedule = client.GetDevTestLabVmScheduleResource(labVirtualmachineScheduleResourceId);

            // invoke the operation
            await labVirtualmachineSchedule.ExecuteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }
    }
}
