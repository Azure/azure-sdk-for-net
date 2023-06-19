// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using Azure.Core.Serialization;
using NUnit.Framework;
using Newtonsoft.Json;
using Azure.Core.Tests.Public.ModelSerializationTests.Models;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class ModelXmlTests
    {
        private readonly ModelSerializerOptions _wireOptions = new ModelSerializerOptions { IgnoreReadOnlyProperties = false };
        private readonly ModelSerializerOptions _objectOptions = new ModelSerializerOptions();

        [TestCase(true)]
        [TestCase(false)]
        public void CanRoundTripFutureVersionWithoutLoss(bool ignoreReadOnly)
        {
            Stream stream = new MemoryStream();
            string serviceResponse =
                "{" +
                "\"modelXml\":{\"key\":\"color\",\"value\":\"red\"}" +
                "}";

            StringBuilder expectedSerialized = new StringBuilder("{");
            expectedSerialized.Append("\"modelXml\":{\"key\":\"color\",\"value\":\"red\"}"); //using XmlSerializer
            expectedSerialized.Append("}");
            var expectedSerializedString = expectedSerialized.ToString();

            ModelSerializerOptions options = new ModelSerializerOptions();

            ModelXml model = ModelSerializer.DeserializeXml<ModelXml>(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)));

            ModelXml modelXml = new ModelXml("Color", "Red");

            Assert.AreEqual("color", model.Key);
            Assert.AreEqual("red", model.Value);
            stream = ModelSerializer.SerializeXml<ModelXml>(model, options);
            stream.Position = 0;
            string roundTrip = new StreamReader(stream).ReadToEnd();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            ModelXml model2 = ModelSerializer.DeserializeXml<ModelXml>(new MemoryStream(Encoding.UTF8.GetBytes(roundTrip)));
            ModelXml correctModelXml = new ModelXml("color", "red");
            ModelXml.VerifyModelXml(correctModelXml, model2);
        }
    }
}
