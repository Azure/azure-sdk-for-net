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
    public partial class DeploymentPropertiesExtended
    {
        /// <summary>
        /// Gets or sets the state of the provisioning.
        /// </summary>
        [JsonProperty(PropertyName = "provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets the correlation ID of the deployment.
        /// </summary>
        [JsonProperty(PropertyName = "correlationId")]
        public string CorrelationId { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the template deployment.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Gets or sets key/value pairs that represent deploymentoutput.
        /// </summary>
        [JsonProperty(PropertyName = "outputs")]
        public object Outputs { get; set; }

        /// <summary>
        /// Gets the list of resource providers needed for the deployment.
        /// </summary>
        [JsonProperty(PropertyName = "providers")]
        public IList<Provider> Providers { get; set; }

        /// <summary>
        /// Gets the list of deployment dependencies.
        /// </summary>
        [JsonProperty(PropertyName = "dependencies")]
        public IList<Dependency> Dependencies { get; set; }

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

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
        }
    }
}
