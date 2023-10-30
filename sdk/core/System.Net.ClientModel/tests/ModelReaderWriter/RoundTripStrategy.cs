// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net.ClientModel.Core;
using System.Text;
using System.Text.Json;

#pragma warning disable SA1402 // File may only contain a single type
namespace System.Net.ClientModel.Tests.ModelReaderWriterTests
{
    public abstract class RoundTripStrategy<T>
    {
        public abstract object Read(string payload, object model, ModelReaderWriterOptions options);
        public abstract BinaryData Write(T model, ModelReaderWriterOptions options);
        public abstract bool IsExplicitJsonWrite { get; }
        public abstract bool IsExplicitJsonRead { get; }
    }

    public class ModelReaderWriterStrategy<T> : RoundTripStrategy<T> where T : IModel<T>
    {
        public override bool IsExplicitJsonWrite => false;
        public override bool IsExplicitJsonRead => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Write(model, options);
        }
        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Read<T>(new BinaryData(Encoding.UTF8.GetBytes(payload)), options) ?? throw new InvalidOperationException($"Reading model of type {model.GetType().Name} resulted in null");
        }
    }

    public class ModelReaderWriterFormatOverloadStrategy<T> : RoundTripStrategy<T> where T : IModel<T>
    {
        public override bool IsExplicitJsonWrite => false;
        public override bool IsExplicitJsonRead => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Write(model, options.Format);
        }
        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Read<T>(new BinaryData(Encoding.UTF8.GetBytes(payload)), options.Format) ?? throw new InvalidOperationException($"Reading model of type {model.GetType().Name} resulted in null");
        }
    }

    public class ModelReaderWriterNonGenericStrategy<T> : RoundTripStrategy<T> where T : IModel<T>
    {
        public override bool IsExplicitJsonWrite => false;
        public override bool IsExplicitJsonRead => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Write((object)model, options);
        }

        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Read(new BinaryData(Encoding.UTF8.GetBytes(payload)), typeof(T), options) ?? throw new InvalidOperationException($"Reading model of type {model.GetType().Name} resulted in null");
        }
    }

    public class ModelInterfaceStrategy<T> : RoundTripStrategy<T> where T : IModel<T>
    {
        public override bool IsExplicitJsonWrite => false;
        public override bool IsExplicitJsonRead => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            return model.Write(options);
        }

        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            return ((IModel<T>)model).Read(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class ModelInterfaceNonGenericStrategy<T> : RoundTripStrategy<T> where T : IModel<T>
    {
        public override bool IsExplicitJsonWrite => false;
        public override bool IsExplicitJsonRead => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            return ((IModel<object>)model).Write(options);
        }

        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            return ((IModel<object>)model).Read(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class JsonInterfaceStrategy<T> : RoundTripStrategy<T> where T : IJsonModel<T>
    {
        public override bool IsExplicitJsonWrite => true;
        public override bool IsExplicitJsonRead => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            model.Write(writer, options);
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

        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            return ((IJsonModel<T>)model).Read(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class JsonModelWriterStrategy<T> : RoundTripStrategy<T> where T : IJsonModel<object>
    {
        public override bool IsExplicitJsonWrite => true;
        public override bool IsExplicitJsonRead => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.WriteCore(model, options);
        }

        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            return ((IJsonModel<object>)model).Read(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class JsonInterfaceNonGenericStrategy<T> : RoundTripStrategy<T> where T : IJsonModel<T>
    {
        public override bool IsExplicitJsonWrite => true;
        public override bool IsExplicitJsonRead => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.WriteCore((IJsonModel<object>)model, options);
        }

        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            return ((IJsonModel<object>)model).Read(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class JsonInterfaceUtf8ReaderStrategy<T> : RoundTripStrategy<T> where T : IJsonModel<T>
    {
        public override bool IsExplicitJsonWrite => true;
        public override bool IsExplicitJsonRead => true;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            model.Write(writer, options);
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

        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            var reader = new Utf8JsonReader(new BinaryData(Encoding.UTF8.GetBytes(payload)));
            return ((IJsonModel<T>)model).Read(ref reader, options);
        }
    }

    public class JsonInterfaceUtf8ReaderNonGenericStrategy<T> : RoundTripStrategy<T> where T : IJsonModel<T>
    {
        public override bool IsExplicitJsonWrite => true;
        public override bool IsExplicitJsonRead => true;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.WriteCore((IJsonModel<object>)model, options);
        }

        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            var reader = new Utf8JsonReader(new BinaryData(Encoding.UTF8.GetBytes(payload)));
            return ((IJsonModel<object>)model).Read(ref reader, options);
        }
    }

    public class CastStrategy<T> : RoundTripStrategy<T> where T : IModel<T>
    {
        private Func<T, MessageBody> _toPipelineContent;
        private Func<Result, T> _fromResult;

        public CastStrategy(Func<T, MessageBody> toPipelineContent, Func<Result, T> fromResponse)
        {
            _toPipelineContent = toPipelineContent;
            _fromResult = fromResponse;
        }

        public override bool IsExplicitJsonWrite => false;
        public override bool IsExplicitJsonRead => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            MessageBody content = _toPipelineContent(model);
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

        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            var result = new MockResult(200, new BinaryData(Encoding.UTF8.GetBytes(payload)));
            return _fromResult(result);
        }
        private class MockPipelineResponse : PipelineResponse
        {
            public MockPipelineResponse(int status, BinaryData content)
            {
                Status = status;
                Content = MessageBody.CreateBody(content);
            }

            public override int Status { get; }

            public override string ReasonPhrase => throw new NotImplementedException();

            public override MessageHeaders Headers => throw new NotImplementedException();

            public override MessageBody? Content { get; protected set; }

            public override void Dispose()
            {
                Content?.Dispose();
            }
        }

        private class MockResult : Result
        {
            private PipelineResponse _response;

            public MockResult(int status, BinaryData content)
            {
                _response = new MockPipelineResponse(status, content);
            }

            public override PipelineResponse GetRawResponse() => _response;
        }
    }

    public class ModelJsonConverterStrategy<T> : RoundTripStrategy<T> where T : IJsonModel<T>
    {
        public override bool IsExplicitJsonWrite => true;
        public override bool IsExplicitJsonRead => true;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.Converters.Add(new ModelJsonConverter(options));
            return BinaryData.FromString(JsonSerializer.Serialize(model, jsonSerializerOptions));
        }
        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.Converters.Add(new ModelJsonConverter(options));
            return JsonSerializer.Deserialize<T>(payload, jsonSerializerOptions) ?? throw new InvalidOperationException($"Reading model of type {model.GetType().Name} resulted in null");
        }
    }
}
#pragma warning restore SA1402 // File may only contain a single type
