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

using System;
using System.IO;
using System.Net;
using DataFactory.Tests.Framework;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Common.Models;
using Microsoft.Azure.Management.DataFactories.Core;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace DataFactory.Tests.ScenarioTests
{
    public class OAuthTests : TestBase
    {
        [Fact]
        [Trait(TraitName.TestType, TestType.Scenario)]
        public void OAuthAuthorizationSessionTest()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                const string oAuthType = "AzureDataLake";
                string resourceGroupName = TestUtilities.GenerateName("resourcegroup");
                string factoryName = TestUtilities.GenerateName("DataFactory");
                string serverLocation = TestHelper.GetDefaultLocation();

                var resourceClient = TestHelper.GetResourceClient(handler);
                var client = TestHelper.GetDataFactoryManagementClient(handler);

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

                AuthorizationSessionGetResponse response = client.OAuth.Get(resourceGroupName, factoryName, oAuthType);
                
                Assert.True(response.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(response.AuthorizationSession.Endpoint);
                Assert.NotNull(response.AuthorizationSession.SessionId);
            }
        }
    }
}
