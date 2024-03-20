// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// A directory attribute that contains a int64 value.
    /// </summary>
    public class Int64DirectoryAttribute : DirectoryAttributeTyped<Int64?>
    {
        /// <summary>
        /// The OData type name for Int64DirectoryAttribute
        /// </summary>
        public static readonly string ODataTypeName = GetODataName(odataPostFix: "int64DirectoryAttributeValue");

        /// <summary>
        /// Default constructor for Json Deserialization
        /// </summary>
        [JsonConstructor]
        public Int64DirectoryAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Int64DirectoryAttribute"/> class.
        /// </summary>
        /// <param name="attributeType">The directory attribute type</param>
        /// <param name="value">The attribute value</param>
        public Int64DirectoryAttribute(DirectoryAttributeType attributeType, Int64? value)
            : base(ODataTypeName, attributeType, value)
        {
        }
    }
}
