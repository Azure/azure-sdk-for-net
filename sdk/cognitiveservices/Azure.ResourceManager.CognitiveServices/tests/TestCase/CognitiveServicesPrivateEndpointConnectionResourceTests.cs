// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CognitiveServices.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.CognitiveServices.Tests.TestCase
{
    public class CognitiveServicesPrivateEndpointConnectionResourceTests : CognitiveServicesManagementTestBase
    {
        public CognitiveServicesPrivateEndpointConnectionResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<CognitiveServicesPrivateEndpointConnectionResource> CreateCognitiveServicesPrivateEndpointConnectionsAsync(string connectionName)
        {
            var accountContainer = (await CreateResourceGroupAsync()).GetAccounts();
            var accountInput = ResourceDataHelper.GetBasicAccountData(DefaultLocation);
            var lro = await accountContainer.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testAccount-"), accountInput);
            var account = lro.Value;
            var container = account.GetCognitiveServicesPrivateEndpointConnections();
            var input = ResourceDataHelper.GetBasicCognitiveServicesPrivateEndpointConnectionData();
            var lro_connection = await container.CreateOrUpdateAsync(WaitUntil.Completed, connectionName, input);
            return lro_connection.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task CognitiveServicesPrivateEndpointConnectionResourceApiTests()
        {
            //1.Get
            var connectionName = Recording.GenerateAssetName("testCognitiveServicesPrivateEndpointConnection-");
            var connection1 = await CreateCognitiveServicesPrivateEndpointConnectionsAsync(connectionName);
            CognitiveServicesPrivateEndpointConnectionResource connection2 = await connection1.GetAsync();

            ResourceDataHelper.AssertConnection(connection1.Data, connection2.Data);
            //2.Delete
            await connection1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
