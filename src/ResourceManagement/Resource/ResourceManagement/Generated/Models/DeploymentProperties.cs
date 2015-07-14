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
    public partial class DeploymentProperties
    {
        /// <summary>
        /// Gets or sets the template content. Use only one of Template or
        /// TemplateLink.
        /// </summary>
        [JsonProperty(PropertyName = "template")]
        public object Template { get; set; }

        /// <summary>
        /// Gets or sets the URI referencing the template. Use only one of
        /// Template or TemplateLink.
        /// </summary>
        [JsonProperty(PropertyName = "templateLink")]
        public TemplateLink TemplateLink { get; set; }

        /// <summary>
        /// Deployment parameters. Use only one of Parameters or
        /// ParametersLink.
        /// </summary>
        [JsonProperty(PropertyName = "parameters")]
        public object Parameters { get; set; }

        /// <summary>
        /// Gets or sets the URI referencing the parameters. Use only one of
        /// Parameters or ParametersLink.
        /// </summary>
        [JsonProperty(PropertyName = "parametersLink")]
        public ParametersLink ParametersLink { get; set; }

        /// <summary>
        /// Gets or sets the deployment mode. Possible values for this
        /// property include: 'Incremental'
        /// </summary>
        [JsonProperty(PropertyName = "mode")]
        public DeploymentMode? Mode { get; set; }

    }
}
