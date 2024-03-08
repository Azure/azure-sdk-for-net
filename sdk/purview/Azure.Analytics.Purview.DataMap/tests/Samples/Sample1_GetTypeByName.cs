// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Purview.DataMap.Tests
{
    internal class Sample1_GetTypeByName : SamplesBase<PurviewDataMapTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GetTypeByName()
        {
            #region Snippet:CreateDataMapClient
            Uri endpoint = TestEnvironment.Endpoint;
            TokenCredential credential = new DefaultAzureCredential();
            DataMapClient dataMapClient = new DataMapClient(endpoint, credential);
            #endregion

            #region Snippet:GetTypeByName
            TypeDefinition client = dataMapClient.GetTypeDefinitionClient();
            Response response = client.GetByName("AtlasGlossary", null);
            #endregion
        }
    }
}
