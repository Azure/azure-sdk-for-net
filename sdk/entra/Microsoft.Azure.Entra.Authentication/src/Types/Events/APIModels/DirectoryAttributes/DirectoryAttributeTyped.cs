// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// Base class for directory attributes with typed value
    /// </summary>
    /// <typeparam name="TValue">The type of the value</typeparam>
    public abstract class DirectoryAttributeTyped<TValue> : DirectoryAttribute
    {
        /// <summary>
        /// The value of the directory attribute
        /// </summary>
        [JsonProperty("value")]
        public TValue Value { get; private set; }

        /// <summary>
        /// Default constructor for Json Deserialization
        /// </summary>
        [JsonConstructor]
        protected DirectoryAttributeTyped()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryAttributeTyped{TValue}"/> class.
        /// </summary>
        /// <param name="odataType">The OData type for attribute</param>
        /// <param name="attributeType">The directory attribute type</param>
        /// <param name="value">The attribute value</param>
        protected DirectoryAttributeTyped(string odataType, DirectoryAttributeType attributeType, TValue value)
            : base(odataType, attributeType)
        {
            this.Value = value;
        }
    }
}
