// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Monitor.Slis.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Slis.Samples
{
    public partial class Sample_MonitorSliResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetSli()
        {
            // Generated from example definition: 2025-03-01-preview/Slis_Get.json
            // this example is just showing the usage of "Sli_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MonitorSliResource created on azure
            // for more information of creating MonitorSliResource, please refer to the document of MonitorSliResource
            string serviceGroupName = "testSG";
            string sliName = "testSli";
            ResourceIdentifier sliResourceId = MonitorSliResource.CreateResourceIdentifier(serviceGroupName, sliName);
            MonitorSliResource sli = client.GetMonitorSliResource(sliResourceId);

            // invoke the operation
            MonitorSliResource result = await sli.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MonitorSliData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_DeleteSli()
        {
            // Generated from example definition: 2025-03-01-preview/Slis_Delete.json
            // this example is just showing the usage of "Sli_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MonitorSliResource created on azure
            // for more information of creating MonitorSliResource, please refer to the document of MonitorSliResource
            string serviceGroupName = "testSG";
            string sliName = "testSli";
            ResourceIdentifier sliResourceId = MonitorSliResource.CreateResourceIdentifier(serviceGroupName, sliName);
            MonitorSliResource sli = client.GetMonitorSliResource(sliResourceId);

            // invoke the operation
            await sli.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_CreateSli()
        {
            // Generated from example definition: 2025-03-01-preview/Slis_CreateOrUpdate.json
            // this example is just showing the usage of "Sli_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MonitorSliResource created on azure
            // for more information of creating MonitorSliResource, please refer to the document of MonitorSliResource
            string serviceGroupName = "testSG";
            string sliName = "testSli";
            ResourceIdentifier sliResourceId = MonitorSliResource.CreateResourceIdentifier(serviceGroupName, sliName);
            MonitorSliResource sli = client.GetMonitorSliResource(sliResourceId);

            // invoke the operation
            MonitorSliData data = new MonitorSliData
            {
                Properties = new MonitorSliProperties(
                "Measures the performance characteristics of the GetContosoUsers() API. ",
                SliCategory.Latency,
                SliEvaluationType.WindowBased,
                new SliAmwAccount[]
            {
new SliAmwAccount(new ResourceIdentifier("/subscriptions/<subId>/resourcegroups/<rgId>/providers/microsoft.monitor/accounts/<dest>"), new ResourceIdentifier("/subscriptions/<subId>/resourcegroups/<rgId>/providers/Microsoft.ManagedIdentity/userAssignedIdentities/<idName>"))
            },
                new SliBaseline(99F, 30, SliEvaluationCalculationType.CalendarDays),
                true,
                new SliProperties
                {
                    Signals = new SliSignal(new SliSignalSource[]
            {
new SliSignalSource(
    "A",
    new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myIdentity"),
    new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/microsoft.monitor/accounts/myAccount"),
    "ContosoMetricsWest",
    "Stamp1Latency",
    new SliCondition[]
{
new SliCondition(SliConditionOperator.Equal, "GetContosoUsers")
{
DimensionName = "ApiName",
}
},
    new SliSpatialAggregation(SliSpatialAggregationType.Average, new string[]{"Region", "ResponseCode"}),
    new SliTemporalAggregation(SliTemporalAggregationType.Average)
{
WindowSizeMinutes = 5,
}),
new SliSignalSource(
    "B",
    new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myIdentity"),
    new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/microsoft.monitor/accounts/myAccount"),
    "ContosoMetricsEast",
    "Stamp2Latency",
    new SliCondition[]
{
new SliCondition(SliConditionOperator.Equal, "GetContosoUsers")
{
DimensionName = "ApiName",
}
},
    new SliSpatialAggregation(SliSpatialAggregationType.Average, new string[]{"Region", "ResponseCode"}),
    new SliTemporalAggregation(SliTemporalAggregationType.Average)
{
WindowSizeMinutes = 5,
})
            }, "(A + B) /2"),
                    WindowUptimeCriteria = new WindowUptimeCriteria(95F, WindowUptimeCriteriaComparator.GreaterThanOrEqual),
                }),
            };
            ArmOperation<MonitorSliResource> lro = await sli.UpdateAsync(WaitUntil.Completed, data);
            MonitorSliResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MonitorSliData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
