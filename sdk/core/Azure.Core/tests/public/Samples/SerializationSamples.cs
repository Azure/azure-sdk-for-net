// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core.Experimental.Tests;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Azure.Core.Tests.Public.ModelSerializationTests;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class SerializationSamples
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CastOperations()
        {
            #region Snippet:CastOperations
#if SNIPPET
            DefaultAzureCredential credential = new DefaultAzureCredential();
#else
            MockCredential credential = new();
#endif
            PetStoreClient client = new PetStoreClient(new Uri("http://somewhere.com"), credential);
            Dog dog = new Dog
            {
                Name = "Doggo",
                Age = 7
            };

            // Our models contain an implicit cast to RequestContent so you can pass them directly to protocol methods.
            Response response = client.CreatePet("myPet", dog);

            // Our models also contain an explicit cast to the response type so you can deserialize them easily.
            dog = (Dog)response;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void BaseModelSerializer()
        {
            #region Snippet:BaseModelSerializer
            Dog doggo = new Dog
            {
                Name = "Doggo",
                Age = 7
            };

            BinaryData data = ModelSerializer.Serialize(doggo);

            Dog dog = ModelSerializer.Deserialize<Dog>(data);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ModelSerializerWithFormat()
        {
            #region Snippet:ModelSerializerWithFormat
            Dog doggo = new Dog
            {
                Name = "Doggo",
                Age = 7
            };

            ModelSerializerOptions options = new ModelSerializerOptions(format: ModelSerializerFormat.Wire);

            BinaryData data = ModelSerializer.Serialize(doggo, options);

            Dog dog = ModelSerializer.Deserialize<Dog>(data, options);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void BaseModelConverter()
        {
            #region Snippet:BaseModelConverter
            Dog dog = new Dog
            {
                Name = "Doggo",
                Age = 7
            };

            JsonSerializerOptions options = new JsonSerializerOptions();
            // The ModelJsonConverter is able to serialize and deserialize any model that implements IModelJsonSerializable<T>.
            options.Converters.Add(new ModelJsonConverter());

            string json = JsonSerializer.Serialize(dog, options);

            dog = JsonSerializer.Deserialize<Dog>(json, options);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void BYOMWithNewtonsoft()
        {
            #region Snippet:BYOMWithNewtonsoft
            Envelope<SearchResult> envelope = new Envelope<SearchResult>();
            envelope.ModelA = new Cat();
            envelope.ModelT = new SearchResult { X = "Square", Y = 10 };

            ModelSerializerOptions options = new ModelSerializerOptions();
            options.GenericTypeSerializerCreator = type => type.Equals(typeof(SearchResult)) ? new NewtonsoftJsonObjectSerializer() : null;

            BinaryData data = ModelSerializer.Serialize(envelope, options);

            Envelope<SearchResult> model = ModelSerializer.Deserialize<Envelope<SearchResult>>(data, options: options);
            #endregion
        }

        #region Snippet:Example_Model
        private class SearchResult
        {
            public string X { get; set; }
            public int Y { get; set; }
        }
        #endregion

        #region SerializationModel
        private class Dog : IUtf8JsonSerializable, IModelSerializable<Dog>, IModelJsonSerializable<Dog>
        {
            internal Dog() { }

            internal Dog(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }

            public string Name { get; set; }
            public int Age { get; set; }

            #region Serialization
            void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<Dog>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

            void IModelJsonSerializable<Dog>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => Serialize(writer, options);

            private void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
                writer.WritePropertyName("age"u8);
                writer.WriteNumberValue(Age);
                writer.WriteEndObject();
            }

            internal static Dog DeserializeDog(JsonElement element, ModelSerializerOptions options = default)
            {
                options ??= ModelSerializerOptions.DefaultWireOptions;

                string name = "";
                int age = 0;

                Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
                foreach (var property in element.EnumerateObject())
                {
                    if (property.NameEquals("name"u8))
                    {
                        name = property.Value.GetString();
                        continue;
                    }
                    if (property.NameEquals("age"u8))
                    {
                        age = property.Value.GetInt32();
                        continue;
                    }
                }
                return new Dog(name, age);
            }
            #endregion

            #region InterfaceImplementation
            Dog IModelSerializable<Dog>.Deserialize(BinaryData data, ModelSerializerOptions options)
            {
                return DeserializeDog(JsonDocument.Parse(data.ToString()).RootElement, options);
            }

            BinaryData IModelSerializable<Dog>.Serialize(ModelSerializerOptions options) => ModelSerializer.ConvertToBinaryData(this, options);

            Dog IModelJsonSerializable<Dog>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options) => DeserializeDog(JsonDocument.ParseValue(ref reader).RootElement, options);
            #endregion

            #region CastOperators
            public static explicit operator Dog(Response response)
            {
                using JsonDocument jsonDocument = JsonDocument.Parse(response.ContentStream);
                return DeserializeDog(jsonDocument.RootElement, ModelSerializerOptions.DefaultWireOptions);
            }

            public static implicit operator RequestContent(Dog dog)
            {
                return RequestContent.Create(dog, ModelSerializerOptions.DefaultWireOptions);
            }
            #endregion
        }
        #endregion
    }
}
