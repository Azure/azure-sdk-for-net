// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// Base class for directory attributes
    /// </summary>
    public abstract class DirectoryAttribute
    {
        /// <summary>
        /// The OData type of the directory attribute
        /// </summary>
        [JsonProperty(APIModelConstants.ODataType)]
        public string ODataType { get; private set; }

        /// <summary>
        /// Default constructor for Json Deserialization
        /// </summary>
        [JsonConstructor]
        protected DirectoryAttribute()
        {
        }

        /// <summary>
        /// Directory attribute type
        /// </summary>
        [JsonProperty("attributeType")]
        public DirectoryAttributeType AttributeType { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryAttribute"/> class.
        /// </summary>
        /// <param name="odataType">The OData type for attribute</param>
        /// <param name="attributeType">The directory attribute type</param>
        protected DirectoryAttribute(string odataType, DirectoryAttributeType attributeType)
        {
            this.ODataType = odataType;
            this.AttributeType = attributeType;
        }

        /// <summary>
        /// Generate the OData name for the directory attribute
        /// </summary>
        /// <param name="odataPostFix">OData postfix</param>
        /// <returns>The OData type string</returns>
        protected static string GetODataName(string odataPostFix)
        {
            return $"{APIModelConstants.MicrosoftGraphPrefix}{odataPostFix}";
        }
    }
}
