// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DataFactory.Tests.ScenarioTests
{
    public class PipelineRunScenarioTests : ScenarioTestBase<PipelineRunScenarioTests>
    {
        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public async Task CancelPipelineRun()
        {
            Func<DataFactoryManagementClient, Task> action = async (client) =>
            {
                Factory createResponse = client.Factories.CreateOrUpdate(this.ResourceGroupName, this.DataFactoryName, new Factory(location: FactoryLocation));
                CloudException exception = await Assert.ThrowsAsync<CloudException>(async () =>
                {
                    await client.PipelineRuns.CancelWithHttpMessagesAsync(this.ResourceGroupName, this.DataFactoryName, "efbe5443-9879-4495-94a6-4d7c394133ad");
                });

                Assert.Equal(HttpStatusCode.BadRequest, exception.Response.StatusCode);
            };

            Func<DataFactoryManagementClient, Task> finallyAction = async (client) =>
            {
                await client.Factories.DeleteAsync(this.ResourceGroupName, this.DataFactoryName);
            };
            await this.RunTest(action, finallyAction);
        }
    }
}
