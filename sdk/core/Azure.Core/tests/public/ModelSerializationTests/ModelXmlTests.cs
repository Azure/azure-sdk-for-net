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
        [TestCase(true)]
        [TestCase(false)]
        public void CanRoundTripFutureVersionWithoutLoss(bool ignoreReadonlyProperites)
        {
            ModelSerializerOptions options = new ModelSerializerOptions();
            options.IgnoreReadOnlyProperties = ignoreReadonlyProperites;

            Stream stream = new MemoryStream();

            string serviceResponse =
                "<Tag>"+
                "<Key>Color</Key>"+
                "<Value>Red</Value>"+
                "<ReadOnlyProperty>ReadOnly</ReadOnlyProperty>" +
                "</Tag>";

            var expectedSerializedString = "<Tag>\r\n  <Key>Color</Key>\r\n  <Value>Red</Value>\r\n";
            if (!ignoreReadonlyProperites)
                expectedSerializedString += "  <ReadOnlyProperty>ReadOnly</ReadOnlyProperty>\r\n";
            expectedSerializedString += "</Tag>";

            ModelXml model = ModelSerializer.DeserializeXml<ModelXml>(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), options);

            Assert.AreEqual("Color", model.Key);
            Assert.AreEqual("Red", model.Value);
            Assert.AreEqual("ReadOnly", model.ReadOnlyProperty);
            stream = ModelSerializer.SerializeXml(model, options);
            stream.Position = 0;
            string roundTrip = new StreamReader(stream).ReadToEnd();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            ModelXml model2 = ModelSerializer.DeserializeXml<ModelXml>(new MemoryStream(Encoding.UTF8.GetBytes(roundTrip)), options);
            VerifyModelXml(model, model2, ignoreReadonlyProperites);
        }

        internal static void VerifyModelXml(ModelXml correctModelXml, ModelXml model2, bool ignoreReadOnlyProperties)
        {
            Assert.AreEqual(correctModelXml.Key, model2.Key);
            Assert.AreEqual(correctModelXml.Value, model2.Value);
            if (!ignoreReadOnlyProperties)
                Assert.AreEqual(correctModelXml.ReadOnlyProperty, model2.ReadOnlyProperty);
        }
    }
}
