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
    /// The Template interface.
    /// </summary>
    public interface ITemplate
    {
        /// <summary>
        /// Gets or sets the user defined namespace.
        /// </summary>
        /// <value>
        /// The user defined namespace.
        /// </value>
        string UserDefinedNamespace { get; set; }

        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        /// <value>
        /// The schema.
        /// </value>
        NamedSchema Schema { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the namespace is enforced.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the namespace is enforced; otherwise, <c>false</c>.
        /// </value>
        bool ForceNamespace { get; set; }
    }
}
