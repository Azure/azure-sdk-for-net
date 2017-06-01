// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using DataFactory.Tests.Framework;
using Microsoft.Azure.Management.DataFactories.Core;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace DataFactory.Tests.ScenarioTests
{
   public class GatewayAuthKeyTests : TestBase
    {
        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public void GatewayAuthKeyTest()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                string resourceGroupName = TestUtilities.GenerateName("resourcegroup");
                string factoryName = TestUtilities.GenerateName("dataFactory");
                string serverLocation = TestHelper.GetDefaultLocation();
                string gatewayName = TestUtilities.GenerateName("gateway");

                var client = TestHelper.GetDataFactoryManagementClient(handler);
                var resourceClient = TestHelper.GetResourceClient(handler);

                ResourceGroup resourceGroup = new ResourceGroup() { Location = serverLocation };
                resourceClient.ResourceGroups.CreateOrUpdate(resourceGroupName, resourceGroup);

                // create a data factory
                var df = new Microsoft.Azure.Management.DataFactories.Models.DataFactory()
                {
                    Name = factoryName,
                    Location = serverLocation
                };

                client.DataFactories.CreateOrUpdate(resourceGroupName, new DataFactoryCreateOrUpdateParameters()
                {
                    DataFactory = df,
                });

                var gatewayParam = new Gateway()
                {
                    Name = gatewayName,
                    Properties = new GatewayProperties()
                };

                var createGatewayParam = new GatewayCreateOrUpdateParameters()
                {
                    Gateway = gatewayParam
                };

                // create gateway
                var gateway = client.Gateways.CreateOrUpdate(resourceGroupName, factoryName, createGatewayParam);
                Assert.True(gateway.Gateway.Name == gatewayName);

                // retrieve key
                var key1 = client.Gateways.ListAuthKeys(resourceGroupName, factoryName, gatewayName);
                Assert.False(string.IsNullOrEmpty(key1.Key1));
                Assert.False(string.IsNullOrEmpty(key1.Key2));

                // regenerate key2
                var param = new GatewayRegenerateAuthKeyParameters("key2");
                var key2 = client.Gateways.RegenerateAuthKey(resourceGroupName, factoryName, gatewayName, param);
                Assert.True(string.IsNullOrEmpty(key2.Key1));
                Assert.False(string.IsNullOrEmpty(key2.Key2));
                Assert.True(key2.Key2 != key1.Key2);

                // retrieve key again
                var key3 = client.Gateways.ListAuthKeys(resourceGroupName, factoryName, gatewayName);
                Assert.False(string.IsNullOrEmpty(key3.Key1));
                Assert.False(string.IsNullOrEmpty(key3.Key2));
                Assert.True(key1.Key1 == key3.Key1);
                Assert.True(key2.Key2 == key3.Key2);

                // regenerate key1
                param = new GatewayRegenerateAuthKeyParameters("key1");
                var key4 = client.Gateways.RegenerateAuthKey(resourceGroupName, factoryName, gatewayName, param);
                Assert.False(string.IsNullOrEmpty(key4.Key1));
                Assert.True(string.IsNullOrEmpty(key4.Key2));
                Assert.True(key4.Key1 != key3.Key1);
            }
        }
    }
}