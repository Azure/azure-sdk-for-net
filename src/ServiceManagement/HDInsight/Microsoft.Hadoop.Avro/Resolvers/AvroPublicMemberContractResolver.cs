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
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;

    /// <summary>
    ///     This contract resolver serializes all public properties/fields of the type.
    ///     The type should has a parameterless constructor.
    /// </summary>
    public class AvroPublicMemberContractResolver : AvroContractResolver
    {
        private readonly bool allowNullable;

        /// <summary>
        /// Initializes a new instance of the <see cref="AvroPublicMemberContractResolver"/> class.
        /// </summary>
        public AvroPublicMemberContractResolver() : this(false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvroPublicMemberContractResolver"/> class.
        /// </summary>
        /// <param name="allowNullable">If set to <c>true</c>, null values are allowed.</param>
        public AvroPublicMemberContractResolver(bool allowNullable)
        {
            this.allowNullable = allowNullable;
        }

        /// <summary>
        /// Gets the serialization information about the type.
        /// This information is used for creation of the corresponding schema node.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        /// <returns>
        /// Serialization information about the type.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown, if the type argument is null.</exception>
        public override TypeSerializationInfo ResolveType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (type.IsUnsupported())
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Type '{0}' is not supported by the resolver.", type));
            }

            return new TypeSerializationInfo
            {
                Name = StripAvroNonCompatibleCharacters(type.Name),
                Namespace = StripAvroNonCompatibleCharacters(type.Namespace),
                Nullable = this.allowNullable && type.CanContainNull()
            };
        }

        /// <summary>
        /// Gets the serialization information about the type members.
        /// This information is used for creation of the corresponding schema nodes.
        /// </summary>
        /// <param name="type">Type containing members which should be serialized.</param>
        /// <returns>
        /// Serialization information about the fields/properties.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown, if the type argument is null.</exception>
        public override MemberSerializationInfo[] ResolveMembers(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            var fields = type
                .GetAllFields()
                .Where(f => (f.Attributes & FieldAttributes.Public) != 0 &&
                            (f.Attributes & FieldAttributes.Static) == 0);

            var properties =
                type.GetAllProperties()
                    .Where(p =>
                           p.DeclaringType.IsAnonymous() ||
                           p.DeclaringType.IsKeyValuePair() ||
                           (p.CanRead && p.CanWrite && p.GetSetMethod() != null && p.GetGetMethod() != null));

            var serializedProperties = TypeExtensions.RemoveDuplicates(properties);
            return fields
                .Concat<MemberInfo>(serializedProperties)
                .Select(m => new MemberSerializationInfo { Name = m.Name, MemberInfo = m, Nullable = m.GetCustomAttributes(false).OfType<NullableSchemaAttribute>().Any() })
                .ToArray();
        }
    }
}
