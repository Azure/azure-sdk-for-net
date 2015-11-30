// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Container
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    /// <summary>
    ///     Represents a header of the object container.
    /// </summary>
    internal sealed class ObjectContainerHeader
    {
        private const string MetadataSchema = "avro.schema";
        private const string MetadataCodec = "avro.codec";

        private const byte Version = 1;
        private static readonly byte[] Magic = { (byte)'O', (byte)'b', (byte)'j', Version };

        private readonly Dictionary<string, byte[]> metadata;
        private readonly byte[] syncMarker;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObjectContainerHeader" /> class.
        /// </summary>
        /// <param name="syncMarker">The sync marker.</param>
        public ObjectContainerHeader(byte[] syncMarker)
        {
            if (syncMarker == null)
            {
                throw new ArgumentNullException("syncMarker");
            }

            this.metadata = new Dictionary<string, byte[]>();
            this.syncMarker = syncMarker;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObjectContainerHeader" /> class.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="syncMarker">The sync marker.</param>
        private ObjectContainerHeader(Dictionary<string, byte[]> metadata, byte[] syncMarker)
        {
            this.syncMarker = syncMarker;
            this.metadata = metadata;
        }

        /// <summary>
        ///     Gets or sets the name of the codec.
        /// </summary>
        public string CodecName
        {
            get
            {
                if (!this.metadata.ContainsKey(MetadataCodec))
                {
                    return NullCodec.CodecName;
                }

                return Encoding.UTF8.GetString(this.metadata[MetadataCodec]);
            }

            internal set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid codec name."));
                }
                this.AddMetadata(MetadataCodec, Encoding.UTF8.GetBytes(value));
            }
        }

        /// <summary>
        ///     Gets or sets the schema.
        /// </summary>
        public string Schema
        {
            get
            {
                if (!this.metadata.ContainsKey(MetadataSchema))
                {
                    return NullCodec.CodecName;
                }

                return Encoding.UTF8.GetString(this.metadata[MetadataSchema]);
            }

            internal set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid schema."));
                }
                this.AddMetadata(MetadataSchema, Encoding.UTF8.GetBytes(value));
            }
        }

        /// <summary>
        ///     Adds the metadata.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void AddMetadata(string key, byte[] value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("value");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            this.metadata.Add(key, value);
        }

        /// <summary>
        ///     Gets the sync marker.
        /// </summary>
        public byte[] SyncMarker
        {
            get { return this.syncMarker; }
        }

        /// <summary>
        ///     Writes the header to the specified encoder.
        /// </summary>
        /// <param name="encoder">The encoder.</param>
        public void Write(IEncoder encoder)
        {
            if (encoder == null)
            {
                throw new ArgumentNullException("encoder");
            }

            encoder.EncodeFixed(Magic);
            encoder.EncodeMapChunk(this.metadata.Count);
            foreach (var pair in this.metadata)
            {
                encoder.Encode(pair.Key);
                encoder.Encode(pair.Value);
            }

            if (this.metadata.Count != 0)
            {
                encoder.EncodeMapChunk(0);
            }

            encoder.EncodeFixed(this.syncMarker);
        }

        /// <summary>
        ///     Reads the header from the specified decoder.
        /// </summary>
        /// <param name="decoder">The decoder.</param>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown when the object in the stream is not a valid Avro object container.</exception>
        /// <returns>The header.</returns>
        public static ObjectContainerHeader Read(IDecoder decoder)
        {
            if (decoder == null)
            {
                throw new ArgumentNullException("decoder");
            }

            byte[] magic = decoder.DecodeFixed(Magic.Length);
            if (!Magic.SequenceEqual(magic))
            {
                throw new SerializationException("Invalid Avro object container in a stream. The header cannot be recognized.");
            }

            var metadata = new Dictionary<string, byte[]>();
            for (long currentChunkSize = decoder.DecodeMapChunk(); currentChunkSize != 0; currentChunkSize = decoder.DecodeMapChunk())
            {
                for (int i = 0; i < currentChunkSize; ++i)
                {
                    string key = decoder.DecodeString();
                    byte[] value = decoder.DecodeByteArray();
                    metadata.Add(key, value);
                }
            }

            byte[] syncMarker = decoder.DecodeFixed(16);
            return new ObjectContainerHeader(metadata, syncMarker);
        }
    }
}
