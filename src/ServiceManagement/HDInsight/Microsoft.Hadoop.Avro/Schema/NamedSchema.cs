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
namespace Microsoft.Hadoop.Avro.Schema
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    ///     Class representing an named schema: record, enumeration or fixed.
    ///     For more details please see <a href="http://avro.apache.org/docs/current/spec.html#Names">the specification</a>.
    /// </summary>
    public abstract class NamedSchema : TypeSchema
    {
        private readonly NamedEntityAttributes attributes;

        /// <summary>
        /// Initializes a new instance of the <see cref="NamedSchema" /> class.
        /// </summary>
        /// <param name="nameAttributes">The name attributes.</param>
        /// <param name="runtimeType">Type of the runtime.</param>
        /// <param name="attributes">The attributes.</param>
        internal NamedSchema(
            NamedEntityAttributes nameAttributes,
            Type runtimeType,
            Dictionary<string, string> attributes)
            : base(runtimeType, attributes)
        {
            if (nameAttributes == null)
            {
                throw new ArgumentNullException("nameAttributes");
            }

            this.attributes = nameAttributes;
        }

        /// <summary>
        ///     Gets the full name.
        /// </summary>
        public string FullName
        {
            get { return this.attributes.Name.FullName; }
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        public string Name
        {
            get { return this.attributes.Name.Name; }
        }

        /// <summary>
        ///     Gets the namespace.
        /// </summary>
        public string Namespace
        {
            get { return this.attributes.Name.Namespace; }
        }

        /// <summary>
        ///     Gets the aliases.
        /// </summary>
        public ReadOnlyCollection<string> Aliases
        {
            get { return this.attributes.Aliases.AsReadOnly(); }
        }

        /// <summary>
        ///     Gets the doc.
        /// </summary>
        public string Doc
        {
            get { return this.attributes.Doc; }
        }

        /// <summary>
        /// Gets the type of the schema as string.
        /// </summary>
        internal override string Type
        {
            get { return this.FullName; }
        }
    }
}
