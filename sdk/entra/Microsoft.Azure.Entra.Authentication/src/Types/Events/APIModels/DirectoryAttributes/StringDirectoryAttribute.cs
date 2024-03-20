// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// A directory attribute that contains a string value.
    /// </summary>
    public class StringDirectoryAttribute : DirectoryAttributeTyped<string>
    {
        /// <summary>
        /// Odata type name for StringDirectoryAttribute
        /// </summary>
        public static readonly string ODataTypeName = GetODataName(odataPostFix: "stringDirectoryAttributeValue");

        /// <summary>
        /// Default constructor for Json Deserialization
        /// </summary>
        [JsonConstructor]
        public StringDirectoryAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringDirectoryAttribute"/> class.
        /// </summary>
        /// <param name="attributeType">The directory attribute type</param>
        /// <param name="value">The attribute value</param>
        public StringDirectoryAttribute(DirectoryAttributeType attributeType, string value)
            : base(ODataTypeName, attributeType, value)
        {
        }
    }
}
