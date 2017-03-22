// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Newtonsoft.Json;

    /// <summary>
    /// </summary>
    public partial class SubResource : Rest.Azure.IResource
    {
        /// <summary>
        /// Initializes a new instance of the SubResource class.
        /// </summary>
        public SubResource() { }

        /// <summary>
        /// Initializes a new instance of the SubResource class.
        /// </summary>
        public SubResource(string id = default(string))
        {
            Id = id;
        }

        /// <summary>
        /// Resource Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

    }
}