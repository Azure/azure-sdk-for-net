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

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class NewtonSoftTests
    {
        [TestCase("J")]
        [TestCase("W")]
        public void CanRoundTripFutureVersionWithoutLoss(string format)
        {
            Stream stream = new MemoryStream();
            string serviceResponse =
                "{\"latinName\":\"Animalia\",\"weight\":2.5,\"name\":\"Rabbit\",\"isHungry\":false}";

            StringBuilder expectedSerialized = new StringBuilder("{");
            expectedSerialized.Append("\"IsHungry\":false,");
            expectedSerialized.Append("\"Weight\":2.5,");
            if (format == ModelSerializerFormat.Json)
            {
                expectedSerialized.Append("\"LatinName\":\"Animalia\",");
            }
            expectedSerialized.Append("\"Name\":\"Rabbit\"");
            expectedSerialized.Append("}");
            var expectedSerializedString = expectedSerialized.ToString();

            ModelSerializerOptions options = new ModelSerializerOptions(format);

            if (format == ModelSerializerFormat.Wire)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ContractResolver = new IgnoreReadOnlyPropertiesResolver()
                };
                options.TypeResolver = type => type.Equals(typeof(Animal)) ? new NewtonsoftJsonObjectSerializer(settings) : null;
            }
            else
            {
                options.TypeResolver = type => type.Equals(typeof(Animal)) ? new NewtonsoftJsonObjectSerializer() : null;
            }

            var model = ModelSerializer.Deserialize<Animal>(new BinaryData(Encoding.UTF8.GetBytes(serviceResponse)), options: options);

            if (format == ModelSerializerFormat.Json)
            {
                Assert.That(model.LatinName, Is.EqualTo("Animalia"));
            }
            Assert.That(model.Name, Is.EqualTo("Rabbit"));
            Assert.IsFalse(model.IsHungry);
            Assert.That(model.Weight, Is.EqualTo(2.5));

            var data = ModelSerializer.Serialize(model, options);
            string roundTrip = data.ToString();

#if NET6_0_OR_GREATER
            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));
#endif

            var model2 = ModelSerializer.Deserialize<Animal>(new BinaryData(Encoding.UTF8.GetBytes(roundTrip)), options: options);
            VerifyModels.CheckAnimals(model, model2, options);
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
    }
}
