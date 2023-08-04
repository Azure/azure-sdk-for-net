// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.Core.Serialization;
using Azure.Core.Tests.Common;
using Azure.Core.Tests.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.Core.Tests.ModelSerialization
{
    /// <summary>
    /// Happy path tests are in the public test project in the ModelTests class using the JsonInterfaceStrategy.
    /// This class is used for testing the internal properties of ModelWriter.
    /// </summary>
    public class ModelWriterTests
    {
        [Test]
        public void DisposeWhileSerializing()
        {
            string json = File.ReadAllText(TestData.GetLocation("ResourceProviderData.json"));
            ResourceProviderData resourceProviderData = ModelSerializer.Deserialize<ResourceProviderData>(BinaryData.FromString(json));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void ExceptionsAreBubbledUp(string format)
        {
            ExplodingModel model = new ExplodingModel();
            ModelSerializerOptions options = new ModelSerializerOptions(format);
            MemoryStream stream = new MemoryStream();

            using ModelWriter writer = new ModelWriter(model, options);
            Assert.Throws<NotImplementedException>(() => writer.TryComputeLength(out var length));
            Assert.Throws<NotImplementedException>(() => writer.CopyTo(stream, default));
            Assert.ThrowsAsync<NotImplementedException>(async () => await writer.CopyToAsync(stream, default));
            Assert.Throws<NotImplementedException>(() => writer.ToBinaryData());
        }

        private class ExplodingModel : IModelJsonSerializable<ExplodingModel>
        {
            ExplodingModel IModelJsonSerializable<ExplodingModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            ExplodingModel IModelSerializable<ExplodingModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            void IModelJsonSerializable<ExplodingModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            BinaryData IModelSerializable<ExplodingModel>.Serialize(ModelSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
