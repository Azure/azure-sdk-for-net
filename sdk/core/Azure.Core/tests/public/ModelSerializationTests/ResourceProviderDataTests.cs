// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Azure.Core.Serialization;
using Azure.Core.Tests.Public.ResourceManager.Compute;
using Azure.Core.Tests.Public.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class ResourceProviderDataTests
    {
        [Test]
        public void RoundTripTest() =>
            RoundTripTest(SerializeWithModelSerializer);

        [Test]
        public void BufferTest() =>
            RoundTripTest(SerializeWithBuffer);

        private void RoundTripTest(Func<ResourceProviderData, string> serialize)
        {
            string serviceResponse = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "ModelSerializationTests", "TestData", "ResourceProviderData.json")).TrimEnd();

            var expectedSerializedString = serviceResponse;

            ResourceProviderData model = ModelSerializer.Deserialize<ResourceProviderData>(new BinaryData(Encoding.UTF8.GetBytes(serviceResponse)));

            string roundTrip = serialize(model);

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            ResourceProviderData model2 = ModelSerializer.Deserialize<ResourceProviderData>(new BinaryData(Encoding.UTF8.GetBytes(roundTrip)));
        }

        private string SerializeWithModelSerializer(ResourceProviderData model)
        {
            var data = ModelSerializer.Serialize(model);
            return data.ToString();
        }

        private string SerializeWithBuffer(ResourceProviderData model)
        {
            using var multiBufferRequestContent = new MultiBufferRequestContent(bufferSize: 4048);
            var writer = new Utf8JsonWriter(multiBufferRequestContent);
            model.Serialize(writer);
            writer.Flush();
            RequestContent content = multiBufferRequestContent;
            using var stream = new MemoryStream();
            content.WriteTo(stream, default);
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
