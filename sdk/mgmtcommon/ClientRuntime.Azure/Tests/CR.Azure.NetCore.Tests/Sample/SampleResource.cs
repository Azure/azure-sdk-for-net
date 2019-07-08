// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Newtonsoft.Json;
using CR.Azure.NetCore.Tests.Redis;
using Microsoft.Rest.Azure;
using Microsoft.Rest;

namespace CR.Azure.NetCore.Tests
{
    /// <summary>
    /// Information for resource.
    /// </summary>
    public partial class SampleResource : IResource
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
        /// Optional. Gets or sets the size of the resource.
        /// </summary>
        [JsonProperty("properties.size")]
        public string Size { get; set; }

        /// <summary>
        /// Optional. Gets or sets the child resource.
        /// </summary>
        [JsonProperty("properties.child")]
        public SampleResourceChild Child { get; set; }

        /// <summary>
        /// Optional. Gets or sets the details.
        /// </summary>
        [JsonProperty("properties.name")]
        public dynamic Details { get; set; }

        /// <summary>
        /// Optional. Gets or sets the plan.
        /// </summary>
        [JsonProperty("plan")]
        public string Plan { get; set; }

        /// <summary>
        /// Optional. Gets or sets the provisioning state.
        /// </summary>
        [JsonProperty("properties.provisioningState")]
        public string ProvisioningState { get; set; }

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

    /// <summary>
    /// Information for resource.
    /// </summary>
    public abstract class SampleResourceChild : IResource
    {
        /// <summary>
        /// Gets the ID of the resource.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }
    }

    /// <summary>
    /// Information for resource.
    /// </summary>
    public partial class SampleResourceChild1 : SampleResourceChild
    {
        /// <summary>
        /// Optional. Gets or sets the Id of the resource.
        /// </summary>
        [JsonProperty("properties.name1")]
        public string ChildName1 { get; set; }
    }

    /// <summary>
    /// Information for resource.
    /// </summary>
    public partial class SampleResourceChild2 : SampleResourceChild
    {
        /// <summary>
        /// Optional. Gets or sets the Id of the resource.
        /// </summary>
        [JsonProperty("properties.name2")]
        public string ChildName2 { get; set; }
    }

    /// <summary>
    /// Information for resource.
    /// </summary>
    public partial class SampleResourceWithConflict : IResource
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
        /// Optional. Gets or sets the special location of the resource.
        /// </summary>
        [JsonProperty("properties.location")]
        public string SampleResourceWithConflictLocation { get; set; }

        /// <summary>
        /// Optional. Gets or sets the special id resource.
        /// </summary>
        [JsonProperty("properties.id")]
        public string SampleResourceWithConflictId { get; set; }
    }
}
