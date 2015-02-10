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
    using System.Collections.Generic;

    /// <summary>
    ///     Represents serialization information about a C# type.
    /// </summary>
    public sealed class TypeSerializationInfo
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TypeSerializationInfo" /> class.
        /// </summary>
        public TypeSerializationInfo()
        {
            this.Aliases = new List<string>();
            this.Doc = string.Empty;
            this.Nullable = false;
        }

        /// <summary>
        ///     Gets or sets the Avro name of the type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the Avro namespace of the type.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        ///     Gets the aliases.
        /// </summary>
        public ICollection<string> Aliases { get; private set; }

        /// <summary>
        ///     Gets or sets the doc attribute.
        /// </summary>
        public string Doc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this type can represent null values.
        /// </summary>
        /// <value>
        ///   <c>True</c> if nullable; otherwise, <c>false</c>.
        /// </value>
        public bool Nullable { get; set; }
    }
}
