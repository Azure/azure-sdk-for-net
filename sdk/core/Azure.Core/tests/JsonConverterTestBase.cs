// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Azure.Core.Serialization;
using NUnit.Framework;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Azure.Core.Tests
{
    [TestFixture(JsonSerializerType.SystemTextJson)]
    [TestFixture(JsonSerializerType.NewtonsoftJson)]
    public abstract class JsonConverterTestBase
    {
        public JsonSerializerType Serializer { get; }

        protected JsonConverterTestBase(JsonSerializerType serializer)
        {
            Serializer = serializer;
        }

        public enum JsonSerializerType
        {
            SystemTextJson,
            NewtonsoftJson
        }

        protected string Serialize<T>(T o)
        {
            return Serializer switch
            {
                JsonSerializerType.NewtonsoftJson => Newtonsoft.Json.JsonConvert.SerializeObject(o, CreateJsonSerializerSettings()),
                JsonSerializerType.SystemTextJson => Encoding.UTF8.GetString(JsonSerializer.SerializeToUtf8Bytes(o, CreateJsonSerializerOptions())),
                _ => throw new NotSupportedException()
            };
        }

        protected T Deserialize<T>(string json)
        {
            return Serializer switch
            {
                JsonSerializerType.NewtonsoftJson => Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json, CreateJsonSerializerSettings()),
                JsonSerializerType.SystemTextJson => JsonSerializer.Deserialize<T>(json, CreateJsonSerializerOptions()),
                _ => throw new NotSupportedException()
            };
        }

        private Newtonsoft.Json.JsonSerializerSettings CreateJsonSerializerSettings()
        {
            var options = NewtonsoftJsonObjectSerializer.CreateJsonSerializerSettings();

            var converter = CreateNewtonsoftJsonConverter();
            if (converter != null)
            {
                options.Converters.Add(converter);
            }

            return options;
        }

        private JsonSerializerOptions CreateJsonSerializerOptions()
        {
            var options = new JsonSerializerOptions();
            options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            var converter = CreateSystemTextJsonConverter();
            if (converter != null)
            {
                options.Converters.Add(converter);
            }

            return options;
        }

        protected virtual Newtonsoft.Json.JsonConverter CreateNewtonsoftJsonConverter()
        {
            return null;
        }

        protected virtual JsonConverter CreateSystemTextJsonConverter()
        {
            return null;
        }

        protected string ToJsonString(string value) => value != null ? Newtonsoft.Json.JsonConvert.ToString(value) : "null";
    }
}