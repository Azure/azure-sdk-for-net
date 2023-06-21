// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using NUnit.Framework;
using Azure.Core.Tests.Public.ModelSerializationTests.Models;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class ModelXmlTests
    {
        [Test]
        public void CanRoundTripFutureVersionWithoutLoss()
        {
            Stream stream = new MemoryStream();

            string serviceResponse =
                "<Tag>"+
                "<Key>Color</Key>"+
                "<Value>Red</Value>"+
                "</Tag>";

            var expectedSerializedString = "<Tag>\r\n  <Key>Color</Key>\r\n  <Value>Red</Value>\r\n</Tag>";

            ModelXml model = ModelSerializer.DeserializeXml<ModelXml>(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)));

            ModelXml modelXml = new ModelXml("Color", "Red");

            Assert.AreEqual("Color", model.Key);
            Assert.AreEqual("Red", model.Value);
            stream = ModelSerializer.SerializeXml<ModelXml>(modelXml);
            stream.Position = 0;
            string roundTrip = new StreamReader(stream).ReadToEnd();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            ModelXml model2 = ModelSerializer.DeserializeXml<ModelXml>(new MemoryStream(Encoding.UTF8.GetBytes(roundTrip)));
            ModelXml correctModelXml = new ModelXml("Color", "Red");
            ModelXml.VerifyModelXml(correctModelXml, model2);
        }
    }
}
