// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// A directory attribute that contains a string collection value.
    /// </summary>
    public class StringCollectionDirectoryAttribute : DirectoryAttributeTyped<IList<string>>
    {
        /// <summary>
        /// Odata type name for StringCollectionDirectoryAttribute
        /// </summary>
        public static readonly string ODataTypeName = GetODataName(odataPostFix: "stringCollectionDirectoryAttributeValue");

        /// <summary>
        /// Default constructor for Json Deserialization
        /// </summary>
        [JsonConstructor]
        public StringCollectionDirectoryAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringCollectionDirectoryAttribute"/> class.
        /// </summary>
        /// <param name="attributeType">The directory attribute type</param>
        /// <param name="value">The attribute value</param>
        public StringCollectionDirectoryAttribute(DirectoryAttributeType attributeType, IList<string> value)
            : base(ODataTypeName, attributeType, value)
        {
        }
    }
}
