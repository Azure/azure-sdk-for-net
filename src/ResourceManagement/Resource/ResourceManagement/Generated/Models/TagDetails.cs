namespace Microsoft.Azure.Management.Resources.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class TagDetails
    {
        /// <summary>
        /// Gets or sets the tag ID.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the tag name.
        /// </summary>
        [JsonProperty(PropertyName = "tagName")]
        public string TagName { get; set; }

        /// <summary>
        /// Gets or sets the tag count.
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public TagCount Count { get; set; }

        /// <summary>
        /// Gets or sets the list of tag values.
        /// </summary>
        [JsonProperty(PropertyName = "values")]
        public IList<TagValue> Values { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.Values != null)
            {
                foreach ( var element in this.Values)
            {
                if (element != null)
            {
                element.Validate();
            }
            }
            }
        }
    }
}
