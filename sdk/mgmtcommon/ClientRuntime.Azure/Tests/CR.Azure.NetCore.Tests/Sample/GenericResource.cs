// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Rest;
using Newtonsoft.Json;
using Microsoft.Rest.Azure;

namespace CR.Azure.NetCore.Tests
{
    /// <summary>
    /// Information for resource.
    /// </summary>
    public partial class GenericResource : IResource
    {
        /// <summary>
        /// Gets the ID of the resource.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the type of the resource.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; private set; }

        /// <summary>
        /// Required. Gets or sets the location of the resource.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Optional. Gets or sets the tags attached to the resource.
        /// </summary>
        [JsonProperty("tags")]
        public IDictionary<string, string> Tags { get; set; }
        
        /// <summary>
        /// Optional. Gets or sets the resource properties.
        /// </summary>
        [JsonProperty("properties")]
        public object Properties { get; set; }
        
        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Location == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Location");
            }
        }
    }
}
