// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    /// <summary>
    /// Happy path tests are in the public test project in the ModelTests class using the JsonInterfaceStrategy.
    /// This class is used for testing the internal properties of ModelWriter.
    /// </summary>
    public class ModelWriterTests
    {
        private static readonly ModelReaderWriterOptions _wireOptions = new ModelReaderWriterOptions("W");
        private const int _modelSize = 156000;
        private static readonly string _json = File.ReadAllText(TestData.GetLocation("ResourceProviderData/ResourceProviderData.json"));
        private static readonly ResourceProviderData _resourceProviderData = ModelReaderWriter.Read<ResourceProviderData>(BinaryData.FromString(_json))!;

        [Test]
        public void ThrowsIfUnsupportedFormat()
        {
            ModelX? model = ModelReaderWriter.Read<ModelX>(BinaryData.FromString(File.ReadAllText(TestData.GetLocation("ModelX/ModelX.json"))));
            Assert.IsNotNull(model);
            Assert.Throws<FormatException>(() => new ModelWriter(model!, new ModelReaderWriterOptions("x")).ExtractReader());
        }

        [Test]
        public async Task HappyPath()
        {
            UnsafeBufferSequence.Reader reader = new ModelWriter(_resourceProviderData, _wireOptions).ExtractReader();
            long length = reader.Length;
            Assert.AreEqual(_modelSize, length);

            MemoryStream stream1 = new MemoryStream((int)length);
            reader.CopyTo(stream1, default);
            Assert.AreEqual(_modelSize, stream1.Length);

            MemoryStream stream2 = new MemoryStream((int)length);
            await reader.CopyToAsync(stream2, default);
            Assert.AreEqual(_modelSize, stream2.Length);

            CollectionAssert.AreEqual(stream1.ToArray(), stream2.ToArray());
        }

        [TestCase("J")]
        [TestCase("W")]
        public void ExceptionsAreBubbledUp(string format)
        {
            ExplodingModel model = new ExplodingModel();
            ModelReaderWriterOptions options = new ModelReaderWriterOptions(format);
            MemoryStream stream = new MemoryStream();

            ModelWriter writer = new ModelWriter(model, options);
            Assert.Throws<NotImplementedException>(() => writer.ExtractReader());
        }

        private class ExplodingModel : IJsonModel<ExplodingModel>
        {
            string IPersistableModel<ExplodingModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotImplementedException();

            ExplodingModel IJsonModel<ExplodingModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                throw new NotImplementedException();
            }

            ExplodingModel IPersistableModel<ExplodingModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                throw new NotImplementedException();
            }

            void IJsonModel<ExplodingModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                throw new NotImplementedException();
            }

            BinaryData IPersistableModel<ExplodingModel>.Write(ModelReaderWriterOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
