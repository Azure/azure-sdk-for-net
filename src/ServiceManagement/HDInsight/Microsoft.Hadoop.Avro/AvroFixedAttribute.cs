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

    /// <summary>
    /// This attribute determines the size of the Avro fixed byte array.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class AvroFixedAttribute : Attribute
    {
        private readonly int size;
        private readonly string name;
        private readonly string @namespace;

        /// <summary>
        /// Initializes a new instance of the <see cref="AvroFixedAttribute"/> class. 
        /// </summary>
        /// <param name="size">
        /// The size of the byte array.
        /// </param>
        /// <param name="name">
        /// The name of the fixed schema.
        /// </param>
        /// <exception cref="ArgumentException">
        /// If the size is not larger than zero.
        /// </exception>
        public AvroFixedAttribute(int size, string name)
            : this(size, name, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvroFixedAttribute"/> class. 
        /// </summary>
        /// <param name="size">
        /// The size of the byte array.
        /// </param>
        /// <param name="name">
        /// The name of the fixed schema.
        /// </param>
        /// <param name="namespace">
        /// The name space.
        /// </param>
        /// <exception cref="ArgumentException">
        /// If the size is not larger than zero.
        /// </exception>
        public AvroFixedAttribute(int size, string name, string @namespace)
        {
            if (size <= 0)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Size of fixed must be larger than zero"));
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Name is not valid"));
            }
            this.size = size;
            this.name = name;
            this.@namespace = @namespace;
        }

        /// <summary>
        /// Gets the size of the fixed bytes.
        /// </summary>
        public int Size
        {
            get { return this.size; }
        }

        /// <summary>
        /// Gets the name of the fixed.
        /// </summary>
        /// <value>
        /// The name of the fixed.
        /// </value>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets the fixed name space.
        /// </summary>
        /// <value>
        /// The fixed name space.
        /// </value>
        public string Namespace
        {
            get { return this.@namespace; }
        }
    }
}
