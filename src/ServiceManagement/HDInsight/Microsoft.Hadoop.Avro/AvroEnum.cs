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
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Represents Avro enumeration.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "Represents Avro enumeration.")]
    public sealed class AvroEnum
    {
        private readonly EnumSchema schema;
        private int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="AvroEnum"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        public AvroEnum(Schema.Schema schema)
        {
            this.schema = schema as EnumSchema;
            if (this.schema == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Enum schema expected."), "schema");
            }
        }

        /// <summary>
        /// Gets the schema.
        /// </summary>
        public EnumSchema Schema
        {
            get { return this.schema; }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value
        {
            get
            {
                return this.schema.GetSymbolByValue(this.value);
            }

            set
            {
                this.value = this.schema.GetValueBySymbol(value);
            }
        }

        /// <summary>
        /// Gets or sets the integer value.
        /// </summary>
        /// <value>
        /// The integer value.
        /// </value>
        internal int IntegerValue
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }
    }
}
