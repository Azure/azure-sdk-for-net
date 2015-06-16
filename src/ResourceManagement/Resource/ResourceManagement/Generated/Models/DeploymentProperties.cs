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
        /// Gets or sets the deployment mode.
        /// </summary>
        [JsonProperty(PropertyName = "mode")]
        public string Mode { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.TemplateLink != null)
            {
                this.TemplateLink.Validate();
            }
            if (this.ParametersLink != null)
            {
                this.ParametersLink.Validate();
            }
        }
    }
}
