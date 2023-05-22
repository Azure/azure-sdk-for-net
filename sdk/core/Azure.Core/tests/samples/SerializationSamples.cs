// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Experimental.Tests;
using Azure.Core.TestFramework;
using Azure.Core.Tests.ModelSerializationTests;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
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

            //stj example
            string json = JsonSerializer.Serialize(dog);

            //modelSerializer example
            Stream stream = ModelSerializer.Serialize(dog);
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

            //modelSerializer example
            DogListProperty dog2 = ModelSerializer.Deserialize<DogListProperty>(json);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void StaticSerialize()
        {
            #region Snippet:Static_Serialize
            //TODO
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void StaticDeserialize()
        {
            #region Snippet:Static_Deserialize
            //TODO
            #endregion
        }
    }
}
