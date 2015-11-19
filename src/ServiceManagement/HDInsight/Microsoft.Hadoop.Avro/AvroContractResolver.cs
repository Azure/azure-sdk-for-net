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

    /// <summary>
    ///     Provides a mechanism for dynamically mapping C# types to and from Avro schema.
    ///     Using derived contract resolvers, the <see cref="Microsoft.Hadoop.Avro.IAvroSerializer{T}"/> can identify what fields should be
    ///     included in the schema and consequently serialized.
    /// </summary>
    /// <remarks>
    ///     <see cref="Microsoft.Hadoop.Avro.AvroDataContractResolver"/> is used to serialize classes according to Data Contract attributes.
    /// </remarks>
    public abstract class AvroContractResolver : IEquatable<AvroContractResolver>
    {
        /// <summary>
        /// Gets the known types of an abstract type or interface that could be present in the tree of
        /// objects serialized with this contract resolver.
        /// </summary>
        /// <param name="type">The abstract type.</param>
        /// <returns>An enumerable of known types.</returns>
        public virtual IEnumerable<Type> GetKnownTypes(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            return new List<Type>();
        }

        /// <summary>
        /// Gets the serialization information about the type.
        /// This information is used for creation of the corresponding schema node.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        /// <returns>
        /// Serialization information about the type.
        /// </returns>
        public abstract TypeSerializationInfo ResolveType(Type type);

        /// <summary>
        /// Gets the serialization information about the type members.
        /// This information is used for creation of the corresponding schema nodes.
        /// </summary>
        /// <param name="type">Type containing members which should be serialized.</param>
        /// <returns>
        /// Serialization information about the fields/properties.
        /// </returns>
        public abstract MemberSerializationInfo[] ResolveMembers(Type type);

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///     True, if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public virtual bool Equals(AvroContractResolver other)
        {
            if (other == null)
            {
                return false;
            }

            return other.GetType() == this.GetType();
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">
        ///     <see cref="System.Object" /> to compare with this instance.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as AvroContractResolver);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return this.GetType().GetHashCode();
        }

        /// <summary>
        /// Strips Avro all non-compatible characters from a string.
        /// </summary>
        /// <param name="value">Input String.</param>
        /// <returns>A string containing Avro compatible characters.</returns>
        protected string StripAvroNonCompatibleCharacters(string value)
        {
            return TypeExtensions.StripAvroNonCompatibleCharacters(value);
        }
    }
}
