// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml;

    // This class is almost identical to DataContractSerializer; only difference is that
    // ReadObject(Stream) and WriteObject(Stream, object) pick Binary Xml Reader/Writer instead of text.
    sealed class DataContractBinarySerializer : XmlObjectSerializer
    {
        readonly DataContractSerializer dataContractSerializer;

        public DataContractBinarySerializer(Type type)
        {
            this.dataContractSerializer = new DataContractSerializer(type);
        }

        // Override the default (Text) and use Binary Xml Reader instead
        public override object ReadObject(Stream stream)
        {
            if (stream == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(stream));
            }

            return this.ReadObject(XmlDictionaryReader.CreateBinaryReader(stream, XmlDictionaryReaderQuotas.Max));
        }

        // Override the default (Text) and use Binary Xml Writer instead
        public override void WriteObject(Stream stream, object graph)
        {
            if (stream == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(stream));
            }

            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(stream, null, null, false);
            this.WriteObject(writer, graph);
            writer.Flush();
        }

        public override void WriteObject(XmlDictionaryWriter writer, object graph)
        {
            if (writer == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(writer));
            }

            this.dataContractSerializer.WriteObject(writer, graph);
        }

        // All the methods below this point simply delegate to the DataContractSerializer implementation
        public override bool IsStartObject(XmlDictionaryReader reader)
        {
            return this.dataContractSerializer.IsStartObject(reader);
        }

        public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
        {
            return this.dataContractSerializer.ReadObject(reader, verifyObjectName);
        }

        public override void WriteEndObject(XmlDictionaryWriter writer)
        {
            this.dataContractSerializer.WriteEndObject(writer);
        }

        public override void WriteObjectContent(XmlDictionaryWriter writer, object graph)
        {
            this.dataContractSerializer.WriteObjectContent(writer, graph);
        }

        public override void WriteStartObject(XmlDictionaryWriter writer, object graph)
        {
            this.dataContractSerializer.WriteStartObject(writer, graph);
        }
    }
}