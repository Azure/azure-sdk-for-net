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
using Azure.Core.Tests.Public.ModelSerializationTests.Models;
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
            options.GenericTypeSerializerCreator = type => type.Equals(typeof(DogListProperty)) ? new NewtonsoftJsonObjectSerializer() : null;

            BinaryData data = ModelSerializer.Serialize(dog, options);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void NewtonSoftDeserialize()
        {
            #region Snippet:NewtonSoft_Deserialize
            ModelSerializerOptions options = new ModelSerializerOptions();
            options.GenericTypeSerializerCreator = type => type.Equals(typeof(DogListProperty)) ? new NewtonsoftJsonObjectSerializer() : null;
            string json = @"[{""LatinName"":""Animalia"",""Weight"":1.1,""Name"":""Doggo"",""IsHungry"":false,""FoodConsumed"":[""kibble"",""egg"",""peanut butter""],""NumberOfLegs"":4}]";

            DogListProperty dog = ModelSerializer.Deserialize<DogListProperty>(BinaryData.FromString(json), options);
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
            options.Converters.Add(new ModelJsonConverter());

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
            options.Converters.Add(new ModelJsonConverter());

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
            options.GenericTypeSerializerCreator = type => type.Equals(typeof(ModelT)) ? new NewtonsoftJsonObjectSerializer() : null;
            BinaryData data = ModelSerializer.Serialize(envelope, options);
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
            options.GenericTypeSerializerCreator = type => type.Equals(typeof(ModelT)) ? new NewtonsoftJsonObjectSerializer() : null;

            Envelope<ModelT> model = ModelSerializer.Deserialize<Envelope<ModelT>>(new BinaryData(Encoding.UTF8.GetBytes(serviceResponse)), options: options);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void IModelSerializableSerialize()
        {
            #region Snippet:ModelSerializer_IModelSerializable_Serialize
            XmlModelForCombinedInterface xmlModel = new XmlModelForCombinedInterface("Color", "Red", "ReadOnly");
            var data = ModelSerializer.Serialize(xmlModel);
            string xmlString = data.ToString();

            JsonModelForCombinedInterface jsonModel = new JsonModelForCombinedInterface("Color", "Red", "ReadOnly");
            data = ModelSerializer.Serialize(jsonModel);
            string jsonString = data.ToString();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void IModelSerializableDeserialize()
        {
            #region Snippet:ModelSerializer_IModelSerializable_Deserialize
            string xmlResponse = "<Tag><Key>Color</Key><Value>Red</Value></Tag>";
            XmlModelForCombinedInterface xmlModel = ModelSerializer.Deserialize<XmlModelForCombinedInterface>(new BinaryData(Encoding.UTF8.GetBytes(xmlResponse)));

            string jsonResponse = "{\"key\":\"Color\",\"value\":\"Red\",\"readOnlyProperty\":\"ReadOnly\",\"x\":\"extra\"}";
            JsonModelForCombinedInterface jsonModel = ModelSerializer.Deserialize<JsonModelForCombinedInterface>(new BinaryData(Encoding.UTF8.GetBytes(jsonResponse)));
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
