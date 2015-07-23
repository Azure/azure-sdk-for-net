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
namespace Microsoft.Hadoop.Avro.Utils.Templates
{
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// The enumeration template.
    /// </summary>
    internal partial class EnumTemplate : ITemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumTemplate"/> class.
        /// </summary>
        /// <param name="enumSchema">The enum schema.</param>
        /// <param name="userDefinedNamespace">The default namespace.</param>
        /// <param name="forceNamespace">Determines whether the UserDefinedNamespace should be used.</param>
        public EnumTemplate(EnumSchema enumSchema, string userDefinedNamespace, bool forceNamespace)
        {
            this.Schema = enumSchema;
            this.UserDefinedNamespace = userDefinedNamespace;
            this.ForceNamespace = forceNamespace;
        }

        /// <summary>
        /// Gets or sets the user defined namespace.
        /// </summary>
        /// <value>
        /// The user defined namespace.
        /// </value>
        public string UserDefinedNamespace { get; set; }

        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        /// <value>
        /// The schema.
        /// </value>
        public NamedSchema Schema { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the namespace is enforced.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the namespace is enforced; otherwise, <c>false</c>.
        /// </value>
        public bool ForceNamespace { get; set; }
    }
}