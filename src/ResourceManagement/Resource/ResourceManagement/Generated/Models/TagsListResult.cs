using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Rest;
using Microsoft.Azure;

namespace Microsoft.Azure.Management.Resources.Models
{
    /// <summary>
    /// </summary>
    public partial class TagsListResult
    {
        /// <summary>
        /// Gets or sets the list of tags.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<TagDetails> Value { get; set; }

        /// <summary>
        /// Gets or sets the URL to get the next set of results.
        /// </summary>
        [JsonProperty(PropertyName = "@odata.nextLink")]
        public string OdatanextLink { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.Value != null)
            {
                foreach ( var element in this.Value)
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
