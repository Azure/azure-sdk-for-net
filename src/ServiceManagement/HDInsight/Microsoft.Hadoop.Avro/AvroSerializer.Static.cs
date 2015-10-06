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
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;
    using Microsoft.Hadoop.Avro.Serializers;

    /// <summary>
    /// A factory class to create <see cref="Microsoft.Hadoop.Avro.IAvroSerializer{T}"/>.
    /// </summary>
    public static class AvroSerializer
    {
        private static readonly Cache<Tuple<string, Type, AvroSerializerSettings>, GeneratedSerializer> TypedSerializers
            = new Cache<Tuple<string, Type, AvroSerializerSettings>, GeneratedSerializer>();

        private static readonly Cache<Tuple<string, string>, GeneratedSerializer> UntypedSerializers
            = new Cache<Tuple<string, string>, GeneratedSerializer>();

        /// <summary>
        /// Creates a serializer that allows serializing types attributed with <see cref="T:System.Runtime.Serialization.DataContractAttribute" />.
        /// </summary>
        /// <typeparam name="T">The type of objects to serialize.</typeparam>
        /// <returns>
        /// A serializer.
        /// </returns>
        /// <remarks>
        /// This function can cause in-memory runtime code generation if the type <typeparamref name="T"/> has not been used before.
        /// Otherwise, a cached version of the serializer is given to the user.
        /// </remarks>
        public static IAvroSerializer<T> Create<T>()
        {
            return Create<T>(new AvroSerializerSettings());
        }

        /// <summary>
        /// Creates a serializer that allows serializing types attributed with <see cref="T:System.Runtime.Serialization.DataContractAttribute" />.
        /// </summary>
        /// <typeparam name="T">The type of objects to serialize.</typeparam>
        /// <param name="settings">The serialization settings.</param>
        /// <returns> A serializer. </returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="settings"/> is null.</exception>
        /// <remarks>
        /// This function can cause in-memory runtime code generation if the type <typeparamref name="T"/> has not used seen before.
        /// Otherwise, a cached version of the serializer is given to the user.
        /// </remarks>
        public static IAvroSerializer<T> Create<T>(AvroSerializerSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            return CreateForCore<T>(string.Empty, settings);
        }

        /// <summary>
        /// Creates a deserializer for the data that was written with the specified <paramref name="writerSchema">schema</paramref>.
        /// </summary>
        /// <typeparam name="T">The type of objects to deserialize.</typeparam>
        /// <param name="writerSchema">The writer schema.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>
        /// A serializer.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="settings" /> is null.</exception>
        /// <remarks>
        /// This function can cause in-memory runtime code generation if the type <typeparamref name="T"/> has not been used before.
        /// Otherwise, a cached version of the serializer is given to the user.
        /// </remarks>
        public static IAvroSerializer<T> CreateDeserializerOnly<T>(string writerSchema, AvroSerializerSettings settings)
        {
            if (string.IsNullOrEmpty(writerSchema))
            {
                throw new ArgumentNullException("writerSchema");
            }

            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            return CreateForCore<T>(writerSchema, settings);
        }

        /// <summary>
        /// Creates a generic serializer for the specified schema.
        /// A resulted serializer can serialize data in AvroRecord hierarchy. For more details, please see <b>Remarks</b> section of
        /// <see cref="Microsoft.Hadoop.Avro.IAvroSerializer{T}"/> interface.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <returns>A serializer.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="schema"/> is null.</exception>
        public static IAvroSerializer<object> CreateGeneric(string schema)
        {
            if (string.IsNullOrEmpty(schema))
            {
                throw new ArgumentNullException("schema");
            }

            return CreateForCore<object>(string.Empty, schema);
        }

        /// <summary>
        ///     Creates a generic deserializer for the data that was written with the specified <paramref name="writerSchema">schema</paramref>.
        ///     Should be used, when reading the data written using an older version of the schema.
        /// </summary>
        /// <param name="writerSchema">The writer schema.</param>
        /// <param name="readerSchema">The reader schema.</param>
        /// <returns> A deserializer.</returns>
        /// <exception cref="System.ArgumentNullException"> Thrown if <paramref name="writerSchema"/> or <paramref name="readerSchema"/> is null.</exception>
        public static IAvroSerializer<object> CreateGenericDeserializerOnly(string writerSchema, string readerSchema)
        {
            if (string.IsNullOrEmpty(writerSchema))
            {
                throw new ArgumentNullException("writerSchema");
            }

            if (string.IsNullOrEmpty(readerSchema))
            {
                throw new ArgumentNullException("readerSchema");
            }

            return CreateForCore<object>(writerSchema, readerSchema);
        }

        private static AvroSerializer<T> CreateForCore<T>(string writerSchema, AvroSerializerSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            var key = Tuple.Create(writerSchema, typeof(T), settings);
            var serializer = TypedSerializers.Get(key);
            if (serializer != null && settings.UseCache)
            {
                return new AvroSerializer<T>(serializer);
            }

            var reader = new ReflectionSchemaBuilder(settings).BuildSchema(typeof(T));
            var generator = new SerializerGenerator();
            var builderGenerator = new SerializerAssigningVisitor(settings);

            if (string.IsNullOrEmpty(writerSchema))
            {
                builderGenerator.Visit(reader);
                serializer = new GeneratedSerializer
                {
                    WriterSchema = reader,
                    ReaderSchema = reader,
                    Serialize = settings.GenerateSerializer
                        ? generator.GenerateSerializer<T>(reader)
                        : null,
                    Deserialize = settings.GenerateDeserializer
                        ? generator.GenerateDeserializer<T>(reader)
                        : null
                };
            }
            else
            {
                var writer = new JsonSchemaBuilder().BuildSchema(writerSchema);
                var matchedSchema = new EvolutionSchemaBuilder().Build(writer, reader);
                if (matchedSchema == null)
                {
                    throw new SerializationException(string.Format(CultureInfo.InvariantCulture, "Writer schema does not match reader schema."));
                }

                builderGenerator.Visit(matchedSchema);
                serializer = new GeneratedSerializer
                {
                    WriterSchema = writer,
                    ReaderSchema = reader,
                    Deserialize = generator.GenerateDeserializer<T>(matchedSchema)
                };
            }

            if (settings.UseCache)
            {
                TypedSerializers.Add(key, serializer);
            }
            return new AvroSerializer<T>(serializer);
        }

        private static AvroSerializer<T> CreateForCore<T>(string writerSchema, string readerSchema)
        {
            var key = Tuple.Create(writerSchema, readerSchema);
            var serializer = UntypedSerializers.Get(key);
            if (serializer != null)
            {
                return new AvroSerializer<T>(serializer);
            }

            var reader = new JsonSchemaBuilder().BuildSchema(readerSchema);
            var builderGenerator = new SerializerAssigningVisitor(new AvroSerializerSettings());

            if (string.IsNullOrEmpty(writerSchema))
            {
                builderGenerator.Visit(reader);
                Action<IEncoder, T> s = (e, obj) => reader.Serializer.Serialize(e, obj);
                Func<IDecoder, T> d = decode =>
                {
                    return (T)reader.Serializer.Deserialize(decode);
                };
                serializer = new GeneratedSerializer
                {
                    WriterSchema = reader,
                    ReaderSchema = reader,
                    Serialize = s,
                    Deserialize = d
                };
            }
            else
            {
                var writer = new JsonSchemaBuilder().BuildSchema(writerSchema);
                var matchedSchema = new EvolutionSchemaBuilder().Build(writer, reader);
                if (matchedSchema == null)
                {
                    throw new SerializationException(string.Format(CultureInfo.InvariantCulture, "Writer schema does not match reader schema."));
                }

                builderGenerator.Visit(matchedSchema);

                Func<IDecoder, T> d = decode => (T)matchedSchema.Serializer.Deserialize(decode);
                serializer = new GeneratedSerializer
                {
                    WriterSchema = writer,
                    ReaderSchema = reader,
                    Deserialize = d
                };
            }

            UntypedSerializers.Add(key, serializer);
            return new AvroSerializer<T>(serializer);
        }

        internal static int CacheEntriesCount
        {
            get { return TypedSerializers.Count; }
        }
    }
}
