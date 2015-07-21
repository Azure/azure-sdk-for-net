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
namespace Microsoft.Hadoop.Avro
{
    using System;
    using System.Globalization;
    using System.IO;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Class for serializing avro objects.
    /// </summary>
    /// <typeparam name="T">Type of serialized objects.</typeparam>
    internal sealed class AvroSerializer<T> : IAvroSerializer<T>
    {
        private readonly GeneratedSerializer serializer;
        private readonly Action<IEncoder, T> serialize;
        private readonly Func<IDecoder, T> deserialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="AvroSerializer{T}" /> class.
        /// Prevents a default instance of the <see cref="AvroSerializer{T}" /> class from being created.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        internal AvroSerializer(GeneratedSerializer serializer)
        {
            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            this.serializer = serializer;
            this.serialize = (Action<IEncoder, T>)serializer.Serialize;
            this.deserialize = (Func<IDecoder, T>)serializer.Deserialize;
        }

        /// <summary>
        /// Gets the reader schema as object.
        /// </summary>
        public TypeSchema ReaderSchema
        {
            get { return this.serializer.ReaderSchema; }
        }

        /// <summary>
        /// Gets the writer schema as object.
        /// </summary>
        /// <value>
        /// The writer schema.
        /// </value>
        public TypeSchema WriterSchema
        {
            get { return this.serializer.WriterSchema; }
        }

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="obj">The object.</param>
        public void Serialize(Stream stream, T obj)
        {
            using (var encoder = new BinaryEncoder(stream))
            {
                this.Serialize(encoder, obj);
            }
        }

        /// <summary>
        /// Serializes the specified object using the specified encoder.
        /// </summary>
        /// <param name="encoder">The encoder.</param>
        /// <param name="obj">The object.</param>
        public void Serialize(IEncoder encoder, T obj)
        {
            if (encoder == null)
            {
                throw new ArgumentNullException("encoder");
            }

            if (this.serialize == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Serialization is not supported. Please change the serialization settings."));
            }

            this.serialize(encoder, obj);
        }

        /// <summary>
        /// Deserializes an object from the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>
        /// The deserialized object.
        /// </returns>
        public T Deserialize(Stream stream)
        {
            using (var decoder = new BinaryDecoder(stream))
            {
                return this.Deserialize(decoder);
            }
        }

        /// <summary>
        /// Deserializes the object using the specified decoder.
        /// </summary>
        /// <param name="decoder">The decoder.</param>
        /// <returns>
        /// Deserialized object.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown if the decoder is null.</exception>
        public T Deserialize(IDecoder decoder)
        {
            if (decoder == null)
            {
                throw new ArgumentNullException("decoder");
            }

            if (this.deserialize == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Deserialization is not supported. Please change the serialization settings."));
            }

            return this.deserialize(decoder);
        }
    }
}
