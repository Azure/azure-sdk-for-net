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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     Specifies Avro serializer settings.
    /// </summary>
    public sealed class AvroSerializerSettings : IEquatable<AvroSerializerSettings>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AvroSerializerSettings" /> class.
        /// </summary>
        public AvroSerializerSettings()
        {
            this.GenerateDeserializer = true;
            this.GenerateSerializer = true;
            this.Resolver = new AvroDataContractResolver();
            this.MaxItemsInSchemaTree = 1024;
            this.UsePosixTime = false;
            this.KnownTypes = new List<Type>();
        }

        /// <summary>
        ///     Gets or sets a value indicating whether to generate a serializer.
        /// </summary>
        /// <value>
        ///     <c>True</c> if the serializer should be generated; otherwise, <c>false</c>.
        /// </value>
        public bool GenerateSerializer { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether to generate a deserializer.
        /// </summary>
        /// <value>
        ///     <c>True</c> if the deserializer should be generated; otherwise, <c>false</c>.
        /// </value>
        public bool GenerateDeserializer { get; set; }

        /// <summary>
        ///     Gets or sets a contract resolver.
        /// </summary>
        public AvroContractResolver Resolver { get; set; }

        /// <summary>
        /// Gets or sets a serialization surrogate.
        /// </summary>
        public IAvroSurrogate Surrogate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether DateTime values will be serialized in the Posix format (as a number
        /// of seconds passed from the start of the Unix epoch) or as a number of ticks.
        /// </summary>
        /// <value>
        ///   <c>True</c> if to use Posix format; otherwise, <c>false</c>.
        /// </value>
        public bool UsePosixTime { get; set; }

        /// <summary>
        ///     Gets or sets the maximum number of items in the schema tree.
        /// </summary>
        /// <value>
        ///     The maximum number of items in the schema tree.
        /// </value>
        public int MaxItemsInSchemaTree { get; set; }

        /// <summary>
        ///     Gets or sets the known types.
        /// </summary>
        public IEnumerable<Type> KnownTypes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use a cache of precompiled serializers.
        /// </summary>
        /// <value>
        ///   <c>True</c> if to use the cache; otherwise, <c>false</c>.
        /// </value>
        public bool UseCache { get; set; }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///     True if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(AvroSerializerSettings other)
        {
            if (other == null)
            {
                return false;
            }

            return this.GenerateSerializer == other.GenerateSerializer
                && this.GenerateDeserializer == other.GenerateDeserializer
                && this.UsePosixTime == other.UsePosixTime
                && this.MaxItemsInSchemaTree == other.MaxItemsInSchemaTree
                && this.Surrogate == other.Surrogate
                && this.UseCache == other.UseCache
                && this.Resolver.Equals(other.Resolver)
                && this.KnownTypes.SequenceEqual(other.KnownTypes);
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">
        ///     The <see cref="System.Object" /> to compare with this instance.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as AvroSerializerSettings);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashcode = 83;
                hashcode = (hashcode * 89) + this.GenerateSerializer.GetHashCode();
                hashcode = (hashcode * 89) + this.GenerateDeserializer.GetHashCode();
                hashcode = (hashcode * 89) + this.UsePosixTime.GetHashCode();
                hashcode = (hashcode * 89) + this.MaxItemsInSchemaTree.GetHashCode();
                hashcode = (hashcode * 89) + (this.Resolver != null ? this.Resolver.GetHashCode() : 0);
                hashcode = (hashcode * 89) + (this.Surrogate != null ? this.Surrogate.GetHashCode() : 0);
                hashcode = (hashcode * 89) + this.UseCache.GetHashCode();
                if (this.KnownTypes != null)
                {
                    hashcode = (hashcode * 89) + this.KnownTypes.Count();
                    foreach (var knownType in this.KnownTypes)
                    {
                        hashcode = (hashcode * 89) + (knownType != null ? knownType.GetHashCode() : 0);
                    }
                }
                return hashcode;
            }
        }
    }
}
