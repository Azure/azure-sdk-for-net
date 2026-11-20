// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.FrontDoor.Tests
{
    public class FrontDoorDataSerializationTests
    {
        [Test]
        public void WritesInheritedTrackedResourceAndFrontDoorProperties()
        {
            var data = new FrontDoorData(new AzureLocation("global")) { FriendlyName = "front-door" };
            data.Tags.Add("team", "sdk");

            BinaryData content = ModelReaderWriter.Write(data, new ModelReaderWriterOptions("W"));
            using var json = JsonDocument.Parse(content.ToMemory());
            JsonElement root = json.RootElement;
            Assert.That(root.GetProperty("location").GetString(), Is.EqualTo("global"));
            Assert.That(root.GetProperty("tags").GetProperty("team").GetString(), Is.EqualTo("sdk"));
            Assert.That(root.GetProperty("properties").GetProperty("friendlyName").GetString(), Is.EqualTo("front-door"));
        }
    }
}
