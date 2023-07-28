// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;

#pragma warning disable SA1402 // File may only contain a single type
namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    public abstract class RoundTripStrategy<T> where T : class, IModelSerializable<T>
    {
        public abstract object Deserialize(string payload, object model, ModelSerializerOptions options);
        public abstract BinaryData Serialize(T model, ModelSerializerOptions options);
    }

    public class ModelSerializerStrategy<T> : RoundTripStrategy<T> where T : class, IModelSerializable<T>
    {
        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return ModelSerializer.Serialize(model, options);
        }
        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ModelSerializer.Deserialize<T>(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class ModelSerializerNonGenericStrategy<T> : RoundTripStrategy<T> where T : class, IModelSerializable<T>
    {
        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return ModelSerializer.Serialize((object)model, options);
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ModelSerializer.Deserialize(new BinaryData(Encoding.UTF8.GetBytes(payload)), typeof(T), options);
        }
    }

    public class XmlInterfaceStrategy<T> : RoundTripStrategy<T> where T : class, IModelSerializable<T>
    {
        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            ((IModelXmlSerializable<T>)model).Serialize(writer, options);
            writer.Flush();
            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ((IModelXmlSerializable<T>)model).Deserialize(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class XmlInterfaceNonGenericStrategy<T> : RoundTripStrategy<T> where T : class, IModelSerializable<T>
    {
        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            ((IModelXmlSerializable<object>)model).Serialize(writer, options);
            writer.Flush();
            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ((IModelXmlSerializable<object>)model).Deserialize(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class ModelInterfaceStrategy<T> : RoundTripStrategy<T> where T : class, IModelSerializable<T>
    {
        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return model.Serialize(options);
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ((IModelSerializable<T>)model).Deserialize(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class ModelInterfaceNonGenericStrategy<T> : RoundTripStrategy<T> where T : class, IModelSerializable<T>
    {
        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return ((IModelSerializable<object>)model).Serialize(options);
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ((IModelSerializable<object>)model).Deserialize(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class JsonInterfaceStrategy<T> : RoundTripStrategy<T> where T : class, IModelSerializable<T>
    {
        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return ((IModelJsonSerializable<T>)model).Serialize(options);
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ((IModelJsonSerializable<T>)model).Deserialize(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class JsonInterfaceNonGenericStrategy<T> : RoundTripStrategy<T> where T : class, IModelSerializable<T>
    {
        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return ((IModelJsonSerializable<object>)model).Serialize(options);
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ((IModelJsonSerializable<object>)model).Deserialize(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class JsonInterfaceUtf8ReaderStrategy<T> : RoundTripStrategy<T> where T : class, IModelSerializable<T>
    {
        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return ((IModelJsonSerializable<T>)model).Serialize(options);
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            var reader = new Utf8JsonReader(new BinaryData(Encoding.UTF8.GetBytes(payload)));
            return ((IModelJsonSerializable<T>)model).Deserialize(ref reader, options);
        }
    }

    public class JsonInterfaceSequenceWriterStrategy<T> : RoundTripStrategy<T> where T : class, IModelSerializable<T>
    {
        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            using var sequenceWriter = new SequenceWriter();
            using var writer = new Utf8JsonWriter(sequenceWriter);
            ((IModelJsonSerializable<T>)model).Serialize(writer, options);
            writer.Flush();
            sequenceWriter.TryComputeLength(out var length);
            var stream = new MemoryStream((int)length);
            sequenceWriter.WriteTo(stream, default);
            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ((IModelJsonSerializable<T>)model).Deserialize(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class JsonInterfaceSequenceWriterNonGenericStrategy<T> : RoundTripStrategy<T> where T : class, IModelSerializable<T>
    {
        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            using var sequenceWriter = new SequenceWriter();
            using var writer = new Utf8JsonWriter(sequenceWriter);
            ((IModelJsonSerializable<object>)model).Serialize(writer, options);
            writer.Flush();
            sequenceWriter.TryComputeLength(out var length);
            var stream = new MemoryStream((int)length);
            sequenceWriter.WriteTo(stream, default);
            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            return ((IModelJsonSerializable<object>)model).Deserialize(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class JsonInterfaceUtf8ReaderNonGenericStrategy<T> : RoundTripStrategy<T> where T : class, IModelSerializable<T>
    {
        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return ((IModelJsonSerializable<object>)model).Serialize(options);
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            var reader = new Utf8JsonReader(new BinaryData(Encoding.UTF8.GetBytes(payload)));
            return ((IModelJsonSerializable<object>)model).Deserialize(ref reader, options);
        }
    }

    public class CastStrategy<T> : RoundTripStrategy<T> where T : class, IModelSerializable<T>
    {
        private Func<T, RequestContent> _toRequestContent;
        private Func<Response, T> _fromResponse;

        public CastStrategy(Func<T, RequestContent> toRequestContent, Func<Response, T> fromResponse)
        {
            _toRequestContent = toRequestContent;
            _fromResponse = fromResponse;
        }

        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            RequestContent content = _toRequestContent(model);
            content.TryComputeLength(out var length);
            using var stream = new MemoryStream((int)length);
            content.WriteTo(stream, default);
            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            var response = new MockResponse(200);
            response.ContentStream = new MemoryStream(Encoding.UTF8.GetBytes(payload));
            return _fromResponse(response);
        }
    }

    public class XmlInterfaceXElementStrategy<T> : RoundTripStrategy<T> where T : class, IModelSerializable<T>
    {
        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return ((IModelXmlSerializable<T>)model).Serialize(options);
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(payload));
            return ((IModelXmlSerializable<T>)model).Deserialize(XElement.Load(stream), options);
        }
    }

    public class XmlInterfaceXElementNonGenericStrategy<T> : RoundTripStrategy<T> where T : class, IModelSerializable<T>
    {
        public override BinaryData Serialize(T model, ModelSerializerOptions options)
        {
            return ((IModelXmlSerializable<object>)model).Serialize(options);
        }

        public override object Deserialize(string payload, object model, ModelSerializerOptions options)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(payload));
            return ((IModelXmlSerializable<object>)model).Deserialize(XElement.Load(stream), options);
        }
    }
}
#pragma warning restore SA1402 // File may only contain a single type
