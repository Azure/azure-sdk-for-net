// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;

#pragma warning disable SA1402 // File may only contain a single type
namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    public abstract class RoundTripStrategy<T>
    {
        public abstract object Read(string payload, object model, ModelReaderWriterOptions options);
        public abstract BinaryData Write(T model, ModelReaderWriterOptions options);
        public virtual void Write(Stream stream, T model, ModelReaderWriterOptions options)
            => throw new NotImplementedException();
        public abstract bool IsExplicitJsonWrite { get; }
        public abstract bool IsExplicitJsonRead { get; }
        public abstract bool SupportsStreaming { get; }

        protected BinaryData WriteWithJsonInterface<U>(IJsonModel<U> model, ModelReaderWriterOptions options)
        {
            using MemoryStream stream = new MemoryStream();
            WriteWithJsonInterface(model, stream, options);
            if (stream.Position > int.MaxValue)
            {
                return BinaryData.FromStream(stream);
            }
            else
            {
                return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
            }
        }

        protected void WriteWithJsonInterface<U>(IJsonModel<U> model, Stream stream, ModelReaderWriterOptions options)
        {
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            model.Write(writer, options);
            writer.Flush();
        }
    }

    public class ModelReaderWriterStrategy<T> : RoundTripStrategy<T> where T : IPersistableModel<T>
    {
        public override bool IsExplicitJsonWrite => false;
        public override bool IsExplicitJsonRead => false;
        public override bool SupportsStreaming => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Write(model, options);
        }
        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Read<T>(new BinaryData(Encoding.UTF8.GetBytes(payload)), options) ?? throw new InvalidOperationException($"Reading model of type {model.GetType().Name} resulted in null");
        }
    }

    public class ModelReaderWriterNonGenericStrategy<T> : RoundTripStrategy<T> where T : IPersistableModel<T>
    {
        public override bool IsExplicitJsonWrite => false;
        public override bool IsExplicitJsonRead => false;
        public override bool SupportsStreaming => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Write((object)model, options);
        }

        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Read(new BinaryData(Encoding.UTF8.GetBytes(payload)), typeof(T), options) ?? throw new InvalidOperationException($"Reading model of type {model.GetType().Name} resulted in null");
        }
    }

    public class ModelInterfaceStrategy<T> : RoundTripStrategy<T> where T : IPersistableModel<T>
    {
        public override bool IsExplicitJsonWrite => false;
        public override bool IsExplicitJsonRead => false;
        public override bool SupportsStreaming => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            return model.Write(options);
        }

        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<T>)model).Create(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class ModelInterfaceAsObjectStrategy<T> : RoundTripStrategy<T> where T : IPersistableModel<T>
    {
        public override bool IsExplicitJsonWrite => false;
        public override bool IsExplicitJsonRead => false;
        public override bool SupportsStreaming => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<object>)model).Write(options);
        }

        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<object>)model).Create(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class ModelReaderWriterStreamableStrategy<T> : ModelReaderWriterStrategy<T> where T : IStreamModel<T>
    {
        public override bool SupportsStreaming => true;

        public override void Write(Stream stream, T model, ModelReaderWriterOptions options)
        {
            ModelReaderWriter.Write(model, stream, options);
        }
    }

    public class ModelReaderWriterStreamableNonGenericStrategy<T> : ModelReaderWriterNonGenericStrategy<T> where T : IStreamModel<T>
    {
        public override bool SupportsStreaming => true;

        public override void Write(Stream stream, T model, ModelReaderWriterOptions options)
        {
            ModelReaderWriter.Write((object)model, stream, options);
        }
    }

    public class ModelInterfaceStreamableStrategy<T> : ModelInterfaceStrategy<T> where T : IStreamModel<T>
    {
        public override bool SupportsStreaming => true;

        public override void Write(Stream stream, T model, ModelReaderWriterOptions options)
        {
            model.Write(stream, options);
        }
    }

    public class ModelInterfaceAsObjectStreamableStrategy<T> : ModelInterfaceAsObjectStrategy<T> where T : IStreamModel<T>
    {
        public override bool SupportsStreaming => true;

        public override void Write(Stream stream, T model, ModelReaderWriterOptions options)
        {
            ((IStreamModel<object>)model).Write(stream, options);
        }
    }

    public class JsonStreamableInterfaceStrategy<T> : JsonInterfaceStrategy<T> where T : IStreamModel<T>, IJsonModel<T>
    {
        public override bool SupportsStreaming => true;

        public override void Write(Stream stream, T model, ModelReaderWriterOptions options)
        {
            WriteWithJsonInterface(model, stream, options);
        }
    }

    public class JsonStreamableInterfaceAsObjectStrategy<T> : JsonInterfaceAsObjectStrategy<T> where T : IStreamModel<T>, IJsonModel<T>
    {
        public override bool SupportsStreaming => true;

        public override void Write(Stream stream, T model, ModelReaderWriterOptions options)
        {
            WriteWithJsonInterface((IJsonModel<object>)model, stream, options);
        }
    }

    public class JsonStreamableInterfaceUtf8ReaderStrategy<T> : JsonInterfaceUtf8ReaderStrategy<T> where T : IStreamModel<T>, IJsonModel<T>
    {
        public override bool SupportsStreaming => true;

        public override void Write(Stream stream, T model, ModelReaderWriterOptions options)
        {
            WriteWithJsonInterface(model, stream, options);
        }
    }

    public class JsonStreamableInterfaceUtf8ReaderAsObjectStrategy<T> : JsonInterfaceUtf8ReaderAsObjectStrategy<T> where T : IStreamModel<T>, IJsonModel<T>
    {
        public override bool SupportsStreaming => true;

        public override void Write(Stream stream, T model, ModelReaderWriterOptions options)
        {
            WriteWithJsonInterface((IJsonModel<object>)model, stream, options);
        }
    }

    public class JsonInterfaceStrategy<T> : RoundTripStrategy<T> where T : IJsonModel<T>
    {
        public override bool IsExplicitJsonWrite => true;
        public override bool IsExplicitJsonRead => false;
        public override bool SupportsStreaming => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            return WriteWithJsonInterface(model, options);
        }

        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            return ((IJsonModel<T>)model).Create(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class JsonInterfaceAsObjectStrategy<T> : RoundTripStrategy<T> where T : IJsonModel<T>
    {
        public override bool IsExplicitJsonWrite => true;
        public override bool IsExplicitJsonRead => false;
        public override bool SupportsStreaming => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            return WriteWithJsonInterface((IJsonModel<object>)model, options);
        }

        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            return ((IJsonModel<object>)model).Create(new BinaryData(Encoding.UTF8.GetBytes(payload)), options);
        }
    }

    public class JsonInterfaceUtf8ReaderStrategy<T> : RoundTripStrategy<T> where T : IJsonModel<T>
    {
        public override bool IsExplicitJsonWrite => true;
        public override bool IsExplicitJsonRead => true;
        public override bool SupportsStreaming => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            return WriteWithJsonInterface(model, options);
        }

        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            var reader = new Utf8JsonReader(new BinaryData(Encoding.UTF8.GetBytes(payload)));
            return ((IJsonModel<T>)model).Create(ref reader, options);
        }
    }

    public class JsonInterfaceUtf8ReaderAsObjectStrategy<T> : RoundTripStrategy<T> where T : IJsonModel<T>
    {
        public override bool IsExplicitJsonWrite => true;
        public override bool IsExplicitJsonRead => true;
        public override bool SupportsStreaming => false;

        public override BinaryData Write(T model, ModelReaderWriterOptions options)
        {
            return WriteWithJsonInterface((IJsonModel<object>)model, options);
        }

        public override object Read(string payload, object model, ModelReaderWriterOptions options)
        {
            var reader = new Utf8JsonReader(new BinaryData(Encoding.UTF8.GetBytes(payload)));
            return ((IJsonModel<object>)model).Create(ref reader, options);
        }
    }
}
#pragma warning restore SA1402 // File may only contain a single type
