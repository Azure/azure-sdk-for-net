// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;

#pragma warning disable SA1402 // File may only contain a single type
namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    public abstract class RoundTripStrategy<T>
    {
        public abstract object Deserialize(string payload, object model, ModelSerializerOptions options);
        public abstract BinaryData Serialize(T model, ModelSerializerOptions options);
        public abstract bool IsExplicitJsonSerialize { get; }
        public abstract bool IsExplicitJsonDeserialize { get; }
    }

    public class ModelSerializerStrategy<T> : RoundTripStrategy<T> where T : IModelSerializable<T>
    {
        public override bool IsExplicitJsonSerialize => false;
        public override bool IsExplicitJsonDeserialize => false;

        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return ModelSerializer.Serialize(model, options);
        }
        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ModelSerializer.Deserialize<T>(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class ModelSerializerFormatOverloadStrategy<T> : RoundTripStrategy<T> where T : IModelSerializable<T>
    {
        public override bool IsExplicitJsonSerialize => false;
        public override bool IsExplicitJsonDeserialize => false;

        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return ModelSerializer.Serialize(model, options.Format);
        }
        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ModelSerializer.Deserialize<T>(new BinaryData(Encoding.UTF8.GetBytes(payload)), options.Format);
        }
    }

    public class ModelSerializerNonGenericStrategy<T> : RoundTripStrategy<T> where T : IModelSerializable<T>
    {
        public override bool IsExplicitJsonSerialize => false;
        public override bool IsExplicitJsonDeserialize => false;

        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return ModelSerializer.Serialize((object)model, options);
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ModelSerializer.Deserialize(new BinaryData(Encoding.UTF8.GetBytes(payload)), typeof(T), options);
        }
    }

    public class ModelInterfaceStrategy<T> : RoundTripStrategy<T> where T : IModelSerializable<T>
    {
        public override bool IsExplicitJsonSerialize => false;
        public override bool IsExplicitJsonDeserialize => false;

        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return model.Serialize(options);
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ((IModelSerializable<T>)model).Deserialize(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class ModelInterfaceNonGenericStrategy<T> : RoundTripStrategy<T> where T : IModelSerializable<T>
    {
        public override bool IsExplicitJsonSerialize => false;
        public override bool IsExplicitJsonDeserialize => false;

        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return ((IModelSerializable<object>)model).Serialize(options);
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ((IModelSerializable<object>)model).Deserialize(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class JsonInterfaceStrategy<T> : RoundTripStrategy<T> where T : IModelJsonSerializable<T>
    {
        public override bool IsExplicitJsonSerialize => true;
        public override bool IsExplicitJsonDeserialize => false;

        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            model.Serialize(writer, options);
            writer.Flush();
            if (stream.Position > int.MaxValue)
            {
                return BinaryData.FromStream(stream);
            }
            else
            {
                return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
            }
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ((IModelJsonSerializable<T>)model).Deserialize(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class JsonModelWriterStrategy<T> : RoundTripStrategy<T> where T : IModelJsonSerializable<object>
    {
        public override bool IsExplicitJsonSerialize => true;
        public override bool IsExplicitJsonDeserialize => false;

        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return ModelSerializer.SerializeCore(model, options);
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ((IModelJsonSerializable<object>)model).Deserialize(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class JsonInterfaceNonGenericStrategy<T> : RoundTripStrategy<T> where T : IModelJsonSerializable<T>
    {
        public override bool IsExplicitJsonSerialize => true;
        public override bool IsExplicitJsonDeserialize => false;

        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return ModelSerializer.SerializeCore((IModelJsonSerializable<object>)model, options);
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ((IModelJsonSerializable<object>)model).Deserialize(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class JsonInterfaceUtf8ReaderStrategy<T> : RoundTripStrategy<T> where T : IModelJsonSerializable<T>
    {
        public override bool IsExplicitJsonSerialize => true;
        public override bool IsExplicitJsonDeserialize => true;

        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            model.Serialize(writer, options);
            writer.Flush();
            if (stream.Position > int.MaxValue)
            {
                return BinaryData.FromStream(stream);
            }
            else
            {
                return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
            }
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            var reader = new Utf8JsonReader(new BinaryData(Encoding.UTF8.GetBytes(payload)));
            return ((IModelJsonSerializable<T>)model).Deserialize(ref reader, options);
        }
    }

    public class JsonInterfaceUtf8ReaderNonGenericStrategy<T> : RoundTripStrategy<T> where T : IModelJsonSerializable<T>
    {
        public override bool IsExplicitJsonSerialize => true;
        public override bool IsExplicitJsonDeserialize => true;

        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return ModelSerializer.SerializeCore((IModelJsonSerializable<object>)model, options);
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            var reader = new Utf8JsonReader(new BinaryData(Encoding.UTF8.GetBytes(payload)));
            return ((IModelJsonSerializable<object>)model).Deserialize(ref reader, options);
        }
    }

    public class CastStrategy<T> : RoundTripStrategy<T> where T : IModelSerializable<T>
    {
        private Func<T, RequestContent> _toRequestContent;
        private Func<Response, T> _fromResponse;

        public CastStrategy(Func<T, RequestContent> toRequestContent, Func<Response, T> fromResponse)
        {
            _toRequestContent = toRequestContent;
            _fromResponse = fromResponse;
        }

        public override bool IsExplicitJsonSerialize => false;
        public override bool IsExplicitJsonDeserialize => false;

        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            RequestContent content = _toRequestContent(model);
            content.TryComputeLength(out var length);
            using var stream = new MemoryStream((int)length);
            content.WriteTo(stream, default);
            if (stream.Position > int.MaxValue)
            {
                return BinaryData.FromStream(stream);
            }
            else
            {
                return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
            }
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            var response = new MockResponse(200);
            response.ContentStream = new MemoryStream(Encoding.UTF8.GetBytes(payload));
            return _fromResponse(response);
        }
    }

    public class ModelJsonConverterStrategy<T> : RoundTripStrategy<T> where T : IModelJsonSerializable<T>
    {
        public override bool IsExplicitJsonSerialize => true;
        public override bool IsExplicitJsonDeserialize => true;

        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.Converters.Add(new ModelJsonConverter(options));
            return BinaryData.FromString(JsonSerializer.Serialize(model, jsonSerializerOptions));
        }
        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.Converters.Add(new ModelJsonConverter(options));
            return JsonSerializer.Deserialize<T>(payload, jsonSerializerOptions);
        }
    }
}
#pragma warning restore SA1402 // File may only contain a single type
