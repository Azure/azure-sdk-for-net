// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace Azure.Core.Tests.ModelSerializationTests
{
    internal class EnvelopeTests
    {
        private readonly SerializableOptions _wireOptions = new SerializableOptions { IgnoreReadOnlyProperties = false };
        private readonly SerializableOptions _objectOptions = new SerializableOptions();

        [TestCase(true)]
        [TestCase(false)]
        public void CanRoundTripFutureVersionWithoutLoss(bool ignoreReadOnly)
        {
            Stream stream = new MemoryStream();
            string serviceResponse =
                "{\"readOnlyProperty\":\"read\"," +
                "\"modelA\":{\"name\":\"Cat\",\"isHungry\":false,\"weight\":2.5}," +
                "\"modelC\":{\"x\":\"hello\",\"y\":\"bye\"}" +
                "}";

            StringBuilder expectedSerialized = new StringBuilder("{");
            if (!ignoreReadOnly)
            {
                expectedSerialized.Append("\"readOnlyProperty\":\"read\",");
            }
            expectedSerialized.Append("\"modelA\":{");
            if (!ignoreReadOnly)
            {
                expectedSerialized.Append("\"latinName\":\"Felis catus\",\"hasWhiskers\":false,");
            }
            expectedSerialized.Append("\"name\":\"Cat\",\"isHungry\":false,\"weight\":2.5},");
            expectedSerialized.Append("\"modelC\":{\"X\":\"hello\",\"Y\":\"bye\"}"); //using NewtonSoft Serializer
            expectedSerialized.Append("}");
            var expectedSerializedString = expectedSerialized.ToString();

            SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = ignoreReadOnly };

            if (ignoreReadOnly)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ContractResolver = new IgnoreReadOnlyPropertiesResolver()
                };
                options.Serializers.Add(typeof(ModelC), new NewtonsoftJsonObjectSerializer(settings));
            }
            else
                options.Serializers.Add(typeof(ModelC), new NewtonsoftJsonObjectSerializer());

            Envelope<ModelC> m = new Envelope<ModelC>();
            m.Deserialize(
                new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)),
                options: options);
            Envelope<ModelC> model = ModelSerializer.Deserialize<Envelope<ModelC>>(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), options: options);

            if (!ignoreReadOnly)
            {
                Assert.That(model.ReadOnlyProperty, Is.EqualTo("read"));
            }

            CatReadOnlyProperty correctCat = new CatReadOnlyProperty(2.5, default, "Cat", false, default);
            VerifyModels.CheckAnimals(correctCat, model.ModelA, options);
            Assert.AreEqual("hello", model.ModelC.X);
            Assert.AreEqual("bye", model.ModelC.Y);
            stream = ModelSerializer.Serialize(model, options);
            stream.Position = 0;
            string roundTrip = new StreamReader(stream).ReadToEnd();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            var model2 = ModelSerializer.Deserialize<Envelope<ModelC>>(new MemoryStream(Encoding.UTF8.GetBytes(roundTrip)), options: options);
            ModelC correctModelC = new ModelC("hello", "bye");
            ModelC.VerifyModelC(correctModelC, model2.ModelC);
        }

        // Generate a class that implements the NewtonSoft default contract resolver so that ReadOnly properties are not serialized
        // This is used to verify that the ReadOnly properties are not serialized when IgnoreReadOnlyProperties is set to true
        private class IgnoreReadOnlyPropertiesResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
        {
            protected override Newtonsoft.Json.Serialization.JsonProperty CreateProperty(System.Reflection.MemberInfo member, MemberSerialization memberSerialization)
            {
                Newtonsoft.Json.Serialization.JsonProperty property = base.CreateProperty(member, memberSerialization);

                if (!property.Writable)
                {
                    property.ShouldSerialize = obj => false;
                }

                return property;
            }
        }

        private class ModelC
        {
            public ModelC(string x1, string y1)
            {
                X = x1;
                Y = y1;
            }

            public string X { get; set; }
            public string Y { get; set; }

            public static void VerifyModelC(ModelC c1, ModelC c2)
            {
                Assert.That(c1.X == c2.X);
                Assert.That(c1.Y == c2.Y);
            }
        }
    }
}
