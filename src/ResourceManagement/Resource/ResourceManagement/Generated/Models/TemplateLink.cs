namespace Microsoft.Azure.Management.Resources.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Entity representing the reference to the template.
    /// </summary>
    public partial class TemplateLink
    {
        /// <summary>
        /// URI referencing the template.
        /// </summary>
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        /// <summary>
        /// If included it must match the ContentVersion in the template.
        /// </summary>
        [JsonProperty(PropertyName = "contentVersion")]
        public string ContentVersion { get; set; }

    }
}
