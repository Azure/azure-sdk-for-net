// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using NUnit.Framework;
using Azure.Core.Tests.Public.ModelSerializationTests.Models;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class CombinedInterfaceTests
    {
        [Test]
        public void CanRoundTripFutureVersionWithoutLossXml()
        {
            Stream stream = new MemoryStream();

            string serviceResponse =
                "<Tag>"+
                "<Key>Color</Key>"+
                "<Value>Red</Value>"+
                "</Tag>";

            var expectedSerializedString = "<Tag>\r\n  <Key>Color</Key>\r\n  <Value>Red</Value>\r\n</Tag>";

            XmlModelForCombinedInterface model = ModelSerializer.DeserializeXml<ModelXml>(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)));

            XmlModelForCombinedInterface modelXml = new XmlModelForCombinedInterface("Color", "Red");

            Assert.AreEqual("Color", model.Key);
            Assert.AreEqual("Red", model.Value);
            stream = modelXml.Serialize(new ModelSerializerOptions());
            stream.Position = 0;
            string roundTrip = new StreamReader(stream).ReadToEnd();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            XmlModelForCombinedInterface model2 = ModelSerializer.DeserializeXml<XmlModelForCombinedInterface>(new MemoryStream(Encoding.UTF8.GetBytes(roundTrip)));
            XmlModelForCombinedInterface correctModelXml = new XmlModelForCombinedInterface("Color", "Red");
            XmlModelForCombinedInterface.VerifyModelXmlModelForCombinedInterface(correctModelXml, model2);
        }

        [Test]
        public void CanRoundTripFutureVersionWithoutLossJson()
        {
            Stream stream = new MemoryStream();

            string serviceResponse =
                "{\"key\":\"Color\"," +
                "\"value\":\"Red\"," +
                "}";

            var expectedSerializedString = "{\"key\":\"Color\",\"value\":\"Red\"}";

            JsonModelForCombinedInterface model = ModelSerializer.Deserialize<JsonModelForCombinedInterface>(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)));

            JsonModelForCombinedInterface modelJson = new JsonModelForCombinedInterface("color", "red");

            Assert.AreEqual("color", model.Key);
            Assert.AreEqual("red", model.Value);
            //stream = modelJson.Serialize(new ModelSerializerOptions());
            //stream.Position = 0;
            //string roundTrip = new StreamReader(stream).ReadToEnd();

            //Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            //JsonModelForCombinedInterface model2 = Deserialize<JsonModelForCombinedInterface>(new MemoryStream(Encoding.UTF8.GetBytes(roundTrip)));
            //JsonModelForCombinedInterface correctModelJson = new JsonModelForCombinedInterface("Color", "Red");
            //JsonModelForCombinedInterface.VerifyModelJsonModelForCombinedInterface(correctModelJson, model2);
        }
    }
}
