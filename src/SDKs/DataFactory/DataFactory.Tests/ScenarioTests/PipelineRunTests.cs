using DataFactory.Tests.Utils;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataFactory.Tests.ScenarioTests
{
    public class PipelineRunTests : ScenarioTestBase<DataFactoryScenarioTests>
    {
        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public void CancelPipelineRun()
        {
            var expectedFactory = new Factory(location: FactoryLocation);

            Action<DataFactoryManagementClient> action = async (client) =>
            {
                Factory createResponse = client.Factories.CreateOrUpdate(ResourceGroupName, DataFactoryName, expectedFactory);
                AzureOperationResponse result = await client.Factories.CancelPipelineRunWithHttpMessagesAsync(ResourceGroupName, DataFactoryName, "efbe5443-9879-4495-94a6-4d7c394133ad");
                Assert.Equal(result.Response.StatusCode, HttpStatusCode.BadRequest);
            };

            Action<DataFactoryManagementClient> finallyAction = (client) =>
            {
                client.Factories.Delete(ResourceGroupName, DataFactoryName);
            };
            this.RunTest(action, finallyAction);
        }
    }
}
