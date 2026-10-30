// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class BlobAccessPointPrivateLinkConnectionSerializationTests
    {
        [TestCase("eastus")]
        [TestCase("future-region")]
        public void PrivateLinkLocationRoundTrips(string region)
        {
            AzureLocation location = new AzureLocation(region);
            var model = new BlobAccessPointPrivateLinkConnectionProperties(
                BlobAccessPointPrivateLinkIdType.ResourceId,
                new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.Network/privateLinkServices/test"),
                location,
                "Test connection",
                new Uri("https://example.com"));

            Assert.AreEqual(location.Name, model.PrivateLinkLocation.Name);

            BinaryData json = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json);
            using JsonDocument document = JsonDocument.Parse(json);
            Assert.AreEqual(region, document.RootElement.GetProperty("privateLinkLocation").GetString());

            BlobAccessPointPrivateLinkConnectionProperties result =
                ModelReaderWriter.Read<BlobAccessPointPrivateLinkConnectionProperties>(json, ModelReaderWriterOptions.Json);

            Assert.AreEqual(location, result.PrivateLinkLocation);
            Assert.AreEqual(region, result.PrivateLinkLocation.Name);
        }
    }
}
