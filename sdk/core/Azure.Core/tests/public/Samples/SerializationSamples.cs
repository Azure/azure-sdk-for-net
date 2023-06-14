// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core.Experimental.Tests;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Azure.Core.Tests.Public.ModelSerializationTests;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class SerializationSamples
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ExplicitCastSerialize()
        {
            #region Snippet:ExplicitCast_Serialize
            PetStoreClient client = new PetStoreClient(new Uri("http://somewhere.com"), new MockCredential());
            DogListProperty dog = new DogListProperty("myPet");
            Response response = client.CreatePet("myPet", (RequestContent)dog);
            var response2 = client.CreatePet("myPet", RequestContent.Create(dog));
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
            string json = System.Text.Json.JsonSerializer.Serialize(dog);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void StjDeserialize()
        {
            #region Snippet:Stj_Deserialize
            string json = "{\"latinName\":\"Animalia\",\"weight\":1.1,\"name\":\"Doggo\",\"isHungry\":false,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"],\"numberOfLegs\":4}";

            //stj example
            DogListProperty dog = System.Text.Json.JsonSerializer.Deserialize<DogListProperty>(json);
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
            ModelSerializerOptions options = new ModelSerializerOptions();
            options.Serializers.Add(typeof(DogListProperty), new NewtonsoftJsonObjectSerializer());

            Stream stream = ModelSerializer.Serialize(dog, options);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void NewtonSoftDeserialize()
        {
            #region Snippet:NewtonSoft_Deserialize
            ModelSerializerOptions options = new ModelSerializerOptions();
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

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ModelConverterSerialize()
        {
            #region Snippet:ModelConverter_Serialize
            DogListProperty dog = new DogListProperty
            {
                Name = "Doggo",
                IsHungry = true,
                Weight = 1.1,
                FoodConsumed = { "kibble", "egg", "peanut butter" },
            };

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter(false));

            string json = System.Text.Json.JsonSerializer.Serialize(dog, options);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ModelConverterDeserialize()
        {
            #region Snippet:ModelConverter_Deserialize
            string json = @"[{""LatinName"":""Animalia"",""Weight"":1.1,""Name"":""Doggo"",""IsHungry"":false,""FoodConsumed"":[""kibble"",""egg"",""peanut butter""],""NumberOfLegs"":4}]";

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter(false));

            DogListProperty dog = System.Text.Json.JsonSerializer.Deserialize<DogListProperty>(json, options);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void BYOMWithNewtonsoftSerialize()
        {
            #region Snippet:BYOMWithNewtonsoftSerialize
            Envelope<ModelT> envelope = new Envelope<ModelT>();
            envelope.ModelA = new CatReadOnlyProperty();
            envelope.ModelT = new ModelT { Name = "Fluffy", Age = 10 };

            ModelSerializerOptions options = new ModelSerializerOptions();
            options.Serializers.Add(typeof(ModelT), new NewtonsoftJsonObjectSerializer());

            Stream stream = ModelSerializer.Serialize(envelope, options);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void BYOMWithNewtonsoftDeserialize()
        {
            #region Snippet:BYOMWithNewtonsoftDeserialize
            string serviceResponse =
                "{\"readOnlyProperty\":\"read\"," +
                "\"modelA\":{\"name\":\"Cat\",\"isHungry\":false,\"weight\":2.5}," +
                "\"modelT\":{\"Name\":\"hello\",\"Age\":1}" +
                "}";

            ModelSerializerOptions options = new ModelSerializerOptions();
            options.Serializers.Add(typeof(ModelT), new NewtonsoftJsonObjectSerializer());

            Envelope<ModelT> model = ModelSerializer.Deserialize<Envelope<ModelT>>(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), options: options);
            #endregion
        }

        #region Snippet:Example_Model
        private class ModelT
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        #endregion
    }
}
