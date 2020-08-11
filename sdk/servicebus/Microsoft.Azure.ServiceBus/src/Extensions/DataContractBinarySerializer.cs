// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.InteropExtensions
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml;

    /// <summary>
    /// This class describes a serializer class used to serialize and deserialize an Object.
    /// This class is almost identical to DataContractSerializer; only difference is that
    /// ReadObject(Stream) and WriteObject(Stream, object) pick Binary Xml Reader/Writer
    /// instead of text.
    /// </summary>
    sealed class DataContractBinarySerializer : XmlObjectSerializer
    {
        readonly DataContractSerializer dataContractSerializer;

        /// <summary>
        /// Initializes a new DataContractBinarySerializer instance
        /// </summary>
        public DataContractBinarySerializer(Type type)
        {
            this.dataContractSerializer = new DataContractSerializer(type);
        }

        /// <summary>
        /// Converts from stream to the corresponding object
        /// </summary>
        /// <returns>Object corresponding to the stream</returns>
        /// <remarks>Override the default (Text) and use Binary Xml Reader instead</remarks>
        public override object ReadObject(Stream stream)
        {
            return this.ReadObject(XmlDictionaryReader.CreateBinaryReader(stream, XmlDictionaryReaderQuotas.Max));
        }

        /// <summary>
        /// Serializes the object into the stream
        /// </summary>
        /// <remarks>Override the default (Text) and use Binary Xml Reader instead</remarks>
        public override void WriteObject(Stream stream, object graph)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var xmlDictionaryWriter = XmlDictionaryWriter.CreateBinaryWriter(stream, null, null, false);
            this.WriteObject(xmlDictionaryWriter, graph);
            xmlDictionaryWriter.Flush();
        }

        /// <summary>
        /// Serializes the object into the stream using the XmlDictionaryWriter
        /// </summary>
        public override void WriteObject(XmlDictionaryWriter writer, object graph)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            this.dataContractSerializer.WriteObject(writer, graph);
        }

        /// <summary>
        /// This method simply delegates to the DataContractSerializer implementation
        /// </summary>
        public override bool IsStartObject(XmlDictionaryReader reader)
        {
            return this.dataContractSerializer.IsStartObject(reader);
        }

        /// <summary>
        /// This method simply delegates to the DataContractSerializer implementation
        /// </summary>
        public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
        {
            return this.dataContractSerializer.ReadObject(reader, verifyObjectName);
        }

        /// <summary>
        /// This method simply delegates to the DataContractSerializer implementation
        /// </summary>
        public override void WriteEndObject(XmlDictionaryWriter writer)
        {
            this.dataContractSerializer.WriteEndObject(writer);
        }

        /// <summary>
        /// This method simply delegates to the DataContractSerializer implementation
        /// </summary>
        public override void WriteObjectContent(XmlDictionaryWriter writer, object graph)
        {
            this.dataContractSerializer.WriteObjectContent(writer, graph);
        }

        /// <summary>
        /// This method simply delegates to the DataContractSerializer implementation
        /// </summary>
        public override void WriteStartObject(XmlDictionaryWriter writer, object graph)
        {
            this.dataContractSerializer.WriteStartObject(writer, graph);
        }
    }

    /// <summary>
    /// Returns a static <see cref="DataContractBinarySerializer"/> instance of type T
    /// </summary>
    public static class DataContractBinarySerializer<T>
    {
        /// <summary>
        /// Initializes a DataContractBinarySerializer instance of type T
        /// </summary>
        public static readonly XmlObjectSerializer Instance = new DataContractBinarySerializer(typeof(T));
    }
}