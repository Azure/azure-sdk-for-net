// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core.Experimental.Tests;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Azure.Core.Tests.ModelSerializationTests;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class SerializationSamples
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void TrySerialize()
        {
            #region Snippet:Try_Serialize
            SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = true, IgnoreAdditionalProperties = true };
            using Stream stream = new MemoryStream();
            Animal model = new Animal();
            model.TrySerialize(stream, out long bytesWritten, options: options);
            stream.Position = 0;
            string json = new StreamReader(stream).ReadToEnd();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void TryDeserialize()
        {
            #region Snippet:Try_Deserialize
            using Stream stream = new MemoryStream();
            bool ignoreReadOnly = false;
            bool ignoreUnknown = false;
            string serviceResponse = "{\"latinName\":\"Canis lupus familiaris\",\"weight\":5.5,\"name\":\"Doggo\",\"numberOfLegs\":4}";
            SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = ignoreReadOnly, IgnoreAdditionalProperties = ignoreUnknown };

            Animal model = new Animal();
            model.TryDeserialize(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), out long bytesConsumed, options: options);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void NonTrySerialize()
        {
            #region Snippet:NonTry_Serialize
            SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = true, IgnoreAdditionalProperties = true };
            using Stream stream = new MemoryStream();
            Animal model = new Animal();
            model.Serialize(stream, options: options);
            stream.Position = 0;
            string roundTrip = new StreamReader(stream).ReadToEnd();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void NonTryDeserialize()
        {
            #region Snippet:NonTry_Deserialize
            using Stream stream = new MemoryStream();
            bool ignoreReadOnly = false;
            bool ignoreUnknown = false;
            string serviceResponse = "{\"latinName\":\"Canis lupus familiaris\",\"weight\":5.5,\"name\":\"Doggo\",\"numberOfLegs\":4}";
            SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = ignoreReadOnly, IgnoreAdditionalProperties = ignoreUnknown };

            Animal model = new Animal();
            model.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), options: options);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ExplicitCastSerialize()
        {
            #region Snippet:ExplicitCast_Serialize
            PetStoreClient client = new PetStoreClient(new Uri("http://somewhere.com"), new MockCredential());
            DogListProperty dog = new DogListProperty("myPet");
            Response response = client.CreatePet("myPet", (RequestContent)dog);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ExplicitCastDeserialize()
        {
            #region Snippet:ExplicitCast_Deserialize
            PetStoreClient client = new PetStoreClient(new Uri("http://somewhere.com"), new MockCredential());
            Response response = client.GetPet("myPet");
            DogListProperty dog = (DogListProperty)response;
            Console.WriteLine(dog.IsHungry);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void StjSerialize()
        {
            #region Snippet:Stj_Serialize
            DogListProperty dog = new DogListProperty
            {
                Name = "Doggo",
                IsHungry = false,
                Weight = 1.1,
                FoodConsumed = { "kibble", "egg", "peanut butter" },
            };

            //STJ example
            string json = JsonSerializer.Serialize(dog);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void StjDeserialize()
        {
            #region Snippet:Stj_Deserialize
            string json = "{\"latinName\":\"Animalia\",\"weight\":1.1,\"name\":\"Doggo\",\"isHungry\":false,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"],\"numberOfLegs\":4}";

            //stj example
            DogListProperty dog = JsonSerializer.Deserialize<DogListProperty>(json);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void StaticDeserialize()
        {
            #region Snippet:Static_Deserialize
            SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = false, IgnoreAdditionalProperties = false };
            string serviceResponse =
                "{\"latinName\":\"Animalia\",\"weight\":2.3,\"name\":\"Rabbit\",\"isHungry\":false,\"numberOfLegs\":4}";

            Animal model = Animal.StaticDeserialize(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), options: options);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void NewtonSoftSerialize()
        {
            #region Snippet:NewtonSoft_Serialize
            DogListProperty dog = new DogListProperty
            {
                Name = "Doggo",
                IsHungry = true,
                Weight = 1.1,
                FoodConsumed = { "kibble", "egg", "peanut butter" },
            };
            SerializableOptions options = new SerializableOptions();
            options.Serializers.Add(typeof(DogListProperty), new NewtonsoftJsonObjectSerializer());

            Stream stream = ModelSerializer.Serialize(dog, options);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void NewtonSoftDeserialize()
        {
            #region Snippet:NewtonSoft_Deserialize
            SerializableOptions options = new SerializableOptions();
            options.Serializers.Add(typeof(DogListProperty), new NewtonsoftJsonObjectSerializer());
            string json = @"[{""LatinName"":""Animalia"",""Weight"":1.1,""Name"":""Doggo"",""IsHungry"":false,""FoodConsumed"":[""kibble"",""egg"",""peanut butter""],""NumberOfLegs"":4}]";

            DogListProperty dog = ModelSerializer.Deserialize<DogListProperty>(json, options);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ModelSerializerSerialize()
        {
            #region Snippet:ModelSerializer_Serialize
            DogListProperty dog = new DogListProperty
            {
                Name = "Doggo",
                IsHungry = true,
                Weight = 1.1,
                FoodConsumed = { "kibble", "egg", "peanut butter" },
            };

            Stream stream = ModelSerializer.Serialize(dog);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ModelSerializerDeserialize()
        {
            #region Snippet:ModelSerializer_Deserialize
            string json = @"[{""LatinName"":""Animalia"",""Weight"":1.1,""Name"":""Doggo"",""IsHungry"":false,""FoodConsumed"":[""kibble"",""egg"",""peanut butter""],""NumberOfLegs"":4}]";

            DogListProperty dog = ModelSerializer.Deserialize<DogListProperty>(json);
            #endregion
        }
    }
}
