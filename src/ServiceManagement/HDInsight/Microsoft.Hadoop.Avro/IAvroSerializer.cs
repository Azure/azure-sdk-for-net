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
    using System.IO;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Serializes and deserializes an instance of a type into a stream using Avro binary format.
    /// Can be used for serialization of C# types attributed with Data Contract/Member attributes
    /// as well as AvroRecord with a manually specified schema.
    /// </summary>
    /// <typeparam name="T">Type of objects to serialize, deserialize.</typeparam>
    public interface IAvroSerializer<T>
    {
        /// <summary>
        /// Gets the schema tree of the reader.
        /// Can be different from the writer schema, if some schema update occurred between reading and writing.
        /// </summary>
        TypeSchema ReaderSchema { get; }

        /// <summary>
        /// Gets the schema tree of the writer.
        /// Can be different from the reader schema, if some schema update occurred between reading and writing.
        /// </summary>
        TypeSchema WriterSchema { get; }

        /// <summary>
        /// Serializes the object into the <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The output stream.</param>
        /// <param name="value">The object to serialize.</param>
        void Serialize(Stream stream, T value);

        /// <summary>
        /// Serializes the object using the specified <paramref name="encoder"/>.
        /// </summary>
        /// <param name="encoder">The encoder.</param>
        /// <param name="value">The object to serialize.</param>
        void Serialize(IEncoder encoder, T value);

        /// <summary>
        /// Deserializes an object from the <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>The deserialized object.</returns>
        T Deserialize(Stream stream);

        /// <summary>
        /// Deserializes an object from the specified <paramref name="decoder"/>.
        /// </summary>
        /// <param name="decoder">The decoder.</param>
        /// <returns>The deserialized object.</returns>
        T Deserialize(IDecoder decoder);
    }
}
