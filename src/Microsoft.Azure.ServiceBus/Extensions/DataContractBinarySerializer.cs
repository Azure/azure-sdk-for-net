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
        /// <param name="type"></param>
        public DataContractBinarySerializer(Type type)
        {
            this.dataContractSerializer = new DataContractSerializer(type);
        }

        /// <summary>
        /// Converts from stream to the corresponding object
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>Object corresponding to the stream</returns>
        // <remarks>Override the default (Text) and use Binary Xml Reader instead</remarks>
        public override object ReadObject(Stream stream)
        {
            return this.ReadObject(XmlDictionaryReader.CreateBinaryReader(stream, XmlDictionaryReaderQuotas.Max));
        }

        /// <summary>
        /// Serializes the object into the stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="graph"></param>
        /// <remarks>Override the default (Text) and use Binary Xml Reader instead</remarks>
        public override void WriteObject(Stream stream, object graph)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(stream, null, null, false);
            this.WriteObject(writer, graph);
            writer.Flush();
        }

        /// <summary>
        /// Serializes the object into the stream using the XmlDictionaryWriter
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="graph"></param>
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
        /// <param name="reader"></param>
        /// <returns></returns>
        public override bool IsStartObject(XmlDictionaryReader reader)
        {
            return this.dataContractSerializer.IsStartObject(reader);
        }

        /// <summary>
        /// This method simply delegates to the DataContractSerializer implementation
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="verifyObjectName"></param>
        /// <returns></returns>
        public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
        {
            return this.dataContractSerializer.ReadObject(reader, verifyObjectName);
        }

        /// <summary>
        /// This method simply delegates to the DataContractSerializer implementation
        /// </summary>
        /// <param name="writer"></param>
        public override void WriteEndObject(XmlDictionaryWriter writer)
        {
            this.dataContractSerializer.WriteEndObject(writer);
        }

        /// <summary>
        /// This method simply delegates to the DataContractSerializer implementation
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="graph"></param>
        public override void WriteObjectContent(XmlDictionaryWriter writer, object graph)
        {
            this.dataContractSerializer.WriteObjectContent(writer, graph);
        }

        /// <summary>
        /// This method simply delegates to the DataContractSerializer implementation
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="graph"></param>
        public override void WriteStartObject(XmlDictionaryWriter writer, object graph)
        {
            this.dataContractSerializer.WriteStartObject(writer, graph);
        }
    }

    /// <summary>
    /// Returns a static <see cref="DataContractBinarySerializer"/> instance of type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class DataContractBinarySerializer<T>
    {
        /// <summary>
        /// Initializes a DataContractBinarySerializer instance of type T
        /// </summary>
        public static readonly XmlObjectSerializer Instance = new DataContractBinarySerializer(typeof(T));
    }
}