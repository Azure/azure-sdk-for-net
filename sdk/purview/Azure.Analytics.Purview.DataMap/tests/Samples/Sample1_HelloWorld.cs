// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Purview.DataMap.Samples
{
    public partial class Samples_TypeDefinition
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void GetTypeByName()
        {
            #region Snippet:CreateDataMapClient
            Uri endpoint = new Uri("<https://accountName.purview.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            DataMapClient dataMapClient = new DataMapClient(endpoint, credential);
            #endregion

            #region Snippet:GetTypeByName
            TypeDefinition client = dataMapClient.GetTypeDefinitionClient();
            Response response = client.GetByName("<name>", null);
            #endregion

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
