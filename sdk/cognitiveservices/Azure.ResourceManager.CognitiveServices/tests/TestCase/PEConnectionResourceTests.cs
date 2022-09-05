// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CognitiveServices.Tests.Helpers;
using NUnit.Framework;
using System.Linq;

namespace Azure.ResourceManager.CognitiveServices.Tests
{
    public class PEConnectionResourceTests : CognitiveServicesManagementTestBase
    {
        public PEConnectionResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<CognitiveServicesPrivateEndpointConnectionCollection> GetCognitiveServicesPrivateEndpointConnectionCollectionAsync()
        {
            var container = (await CreateResourceGroupAsync()).GetCognitiveServicesAccounts();
            var input = ResourceDataHelper.GetBasicAccountData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testAccount-"), input);
            var account = lro.Value;
            return account.GetCognitiveServicesPrivateEndpointConnections();
        }

        [TestCase]
        public async Task PEConnectionResourceApiTests()
        {
            //1.Get
            var collection = await GetCognitiveServicesPrivateEndpointConnectionCollectionAsync();
            var list = await collection.GetAllAsync().ToEnumerableAsync();

            if (list.Count > 0)
            {
                var connection1 = list.FirstOrDefault();
                var connection2 = (await connection1.GetAsync()).Value;
                ResourceDataHelper.AssertConnection(connection1.Data, connection2.Data);

                //2.Delete
                await connection1.DeleteAsync(WaitUntil.Completed);
            }
        }
    }
}
