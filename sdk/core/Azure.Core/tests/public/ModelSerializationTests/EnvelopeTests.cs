// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using Azure.Core.Serialization;
using NUnit.Framework;
using Newtonsoft.Json;
using System;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class EnvelopeTests
    {
        [TestCase("J")]
        [TestCase("W")]
        public void CanRoundTripFutureVersionWithoutLoss(string format)
        {
            string serviceResponse =
                "{\"readOnlyProperty\":\"read\"," +
                "\"modelA\":{\"name\":\"Cat\",\"isHungry\":false,\"weight\":2.5}," +
                "\"modelC\":{\"x\":\"hello\",\"y\":\"bye\"}" +
                "}";

            StringBuilder expectedSerialized = new StringBuilder("{");
            if (format.Equals(ModelSerializerFormat.Json))
            {
                expectedSerialized.Append("\"readOnlyProperty\":\"read\",");
            }
            expectedSerialized.Append("\"modelA\":{");
            if (format.Equals(ModelSerializerFormat.Json))
            {
                expectedSerialized.Append("\"latinName\":\"Felis catus\",\"hasWhiskers\":false,");
            }
            expectedSerialized.Append("\"name\":\"Cat\",\"isHungry\":false,\"weight\":2.5},");
            expectedSerialized.Append("\"modelC\":{\"X\":\"hello\",\"Y\":\"bye\"}"); //using NewtonSoft Serializer
            expectedSerialized.Append("}");
            var expectedSerializedString = expectedSerialized.ToString();

            ModelSerializerOptions options = new ModelSerializerOptions(format);

            if (format == ModelSerializerFormat.Wire)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ContractResolver = new IgnoreReadOnlyPropertiesResolver()
                };
                options.Serializers.Add(typeof(ModelC), new NewtonsoftJsonObjectSerializer(settings));
            }
            else
                options.Serializers.Add(typeof(ModelC), new NewtonsoftJsonObjectSerializer());

            Envelope<ModelC> model = ModelSerializer.Deserialize<Envelope<ModelC>>(new BinaryData(Encoding.UTF8.GetBytes(serviceResponse)), options: options);

            if (format.Equals(ModelSerializerFormat.Json))
            {
                Assert.That(model.ReadOnlyProperty, Is.EqualTo("read"));
            }

            CatReadOnlyProperty correctCat = new CatReadOnlyProperty(2.5, default, "Cat", false, default);
            VerifyModels.CheckAnimals(correctCat, model.ModelA, options);
            Assert.AreEqual("hello", model.ModelT.X);
            Assert.AreEqual("bye", model.ModelT.Y);
            var data = ModelSerializer.Serialize(model, options);
            string roundTrip = data.ToString();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            var model2 = ModelSerializer.Deserialize<Envelope<ModelC>>(new BinaryData(Encoding.UTF8.GetBytes(roundTrip)), options: options);
            ModelC correctModelC = new ModelC("hello", "bye");
            ModelC.VerifyModelC(correctModelC, model2.ModelT);
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
