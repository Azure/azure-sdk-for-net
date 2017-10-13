// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;
using System;
using System.Linq;
using Xunit;

namespace DataFactory.Tests.ScenarioTests
{
    public class DataFactoryScenarioTests : ScenarioTestBase<DataFactoryScenarioTests>
    {
        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public void DataFactoryCrud()
        {
            var expectedFactory = new Factory(location: FactoryLocation);

            Action<DataFactoryManagementClient> action = (client) =>
            {
                Factory createResponse = client.Factories.CreateOrUpdate(ResourceGroupName, DataFactoryName, expectedFactory);
                this.ValidateFactory(createResponse);

                Factory getResponse = client.Factories.Get(ResourceGroupName, DataFactoryName);
                this.ValidateFactory(getResponse);

                IPage<Factory> listByResourceGroupResponse = client.Factories.ListByResourceGroup(ResourceGroupName);
                this.ValidateFactory(listByResourceGroupResponse.First());
            };

            Action<DataFactoryManagementClient> finallyAction = (client) =>
            {
                client.Factories.Delete(ResourceGroupName, DataFactoryName);
            };

            this.RunTest(action, finallyAction);
        }

        private void ValidateFactory(Factory actualFactory)
        {
            Assert.Equal(DataFactoryName, actualFactory.Name);
            Assert.Equal(FactoryLocation, actualFactory.Location);
            Assert.Equal("Succeeded", actualFactory.ProvisioningState);
        }
    }
}
