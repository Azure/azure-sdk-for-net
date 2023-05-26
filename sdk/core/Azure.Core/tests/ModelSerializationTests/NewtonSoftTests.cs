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

namespace Azure.Core.Tests.ModelSerializationTests
{
    internal class NewtonSoftTests
    {
        private readonly SerializableOptions _wireOptions = new SerializableOptions { IgnoreReadOnlyProperties = false };
        private readonly SerializableOptions _objectOptions = new SerializableOptions();

        [TestCase(true)]
        [TestCase(false)]
        public void CanRoundTripFutureVersionWithoutLoss(bool ignoreReadOnly)
        {
            Stream stream = new MemoryStream();
            string serviceResponse =
                "{\"latinName\":\"Animalia\",\"weight\":2.3,\"name\":\"Rabbit\",\"isHungry\":false}";

            StringBuilder expectedSerialized = new StringBuilder("{");
            expectedSerialized.Append("\"IsHungry\":false,");
            expectedSerialized.Append("\"Weight\":2.3,");
            if (!ignoreReadOnly)
            {
                expectedSerialized.Append("\"LatinName\":\"Animalia\",");
            }
            expectedSerialized.Append("\"Name\":\"Rabbit\"");
            expectedSerialized.Append("}");
            var expectedSerializedString = expectedSerialized.ToString();

            SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = ignoreReadOnly };

            if (ignoreReadOnly)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ContractResolver = new IgnoreReadOnlyPropertiesResolver()
                };
                options.Serializer = new NewtonsoftJsonObjectSerializer(settings);
            }
            else
                options.Serializer = new NewtonsoftJsonObjectSerializer();

            var model = ModelSerializer.Deserialize<Animal>(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), options: options);

            if (!ignoreReadOnly)
            {
                Assert.That(model.LatinName, Is.EqualTo("Animalia"));
            }
            Assert.That(model.Name, Is.EqualTo("Rabbit"));
            Assert.IsFalse(model.IsHungry);

#if NET6_0_OR_GREATER
            Assert.That(model.Weight, Is.EqualTo(2.3));
#endif

            stream = ModelSerializer.Serialize<Animal>(model, options);
            stream.Position = 0;
            string roundTrip = new StreamReader(stream).ReadToEnd();

#if NET6_0_OR_GREATER
            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));
#endif

            var model2 = ModelSerializer.Deserialize<Animal>(new MemoryStream(Encoding.UTF8.GetBytes(roundTrip)), options: options);
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
