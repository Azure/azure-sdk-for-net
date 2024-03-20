// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// A directory attribute that contains a boolean value.
    /// </summary>
    public class BooleanDirectoryAttribute : DirectoryAttributeTyped<bool?>
    {
        /// <summary>
        /// The OData type name for BooleanDirectoryAttribute
        /// </summary>
        public static readonly string ODataTypeName = GetODataName(odataPostFix: "booleanDirectoryAttributeValue");

        /// <summary>
        /// Default constructor for Json Deserialization
        /// </summary>
        [JsonConstructor]
        public BooleanDirectoryAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanDirectoryAttribute"/> class.
        /// </summary>
        /// <param name="attributeType">The directory attribute type</param>
        /// <param name="value">The attribute value</param>
        public BooleanDirectoryAttribute(DirectoryAttributeType attributeType, bool? value)
            : base(ODataTypeName, attributeType, value)
        {
        }
    }
}
