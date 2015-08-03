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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Used to determine type alternatives for field or property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    [SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments", Justification = "Types are not exposed.")]
    public sealed class AvroUnionAttribute : Attribute
    {
        private readonly Type[] typeAlternatives;

        /// <summary>
        /// Initializes a new instance of the <see cref="AvroUnionAttribute"/> class.
        /// </summary>
        /// <param name="typeAlternatives">
        /// The type alternatives.
        /// </param>
        public AvroUnionAttribute(params Type[] typeAlternatives)
        {
            this.typeAlternatives = typeAlternatives;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvroUnionAttribute"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public AvroUnionAttribute(Type type) : this(new[] { type })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvroUnionAttribute"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="type2">The type2.</param>
        public AvroUnionAttribute(Type type, Type type2) : this(new[] { type, type2 })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvroUnionAttribute"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="type2">The type2.</param>
        /// <param name="type3">The type3.</param>
        public AvroUnionAttribute(Type type, Type type2, Type type3)
            : this(new[] { type, type2, type3 })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvroUnionAttribute"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="type2">The type2.</param>
        /// <param name="type3">The type3.</param>
        /// <param name="type4">The type4.</param>
        public AvroUnionAttribute(Type type, Type type2, Type type3, Type type4)
            : this(new[] { type, type2, type3, type4 })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvroUnionAttribute"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="type2">The type2.</param>
        /// <param name="type3">The type3.</param>
        /// <param name="type4">The type4.</param>
        /// <param name="type5">The type5.</param>
        public AvroUnionAttribute(Type type, Type type2, Type type3, Type type4, Type type5)
            : this(new[] { type, type2, type3, type4, type5 })
        {
        }

        /// <summary>
        /// Gets the type alternatives.
        /// </summary>
        /// <value>
        /// The type alternatives.
        /// </value>
        public IEnumerable<Type> TypeAlternatives
        {
            get
            {
                return this.typeAlternatives;
            }
        }
    }
}
