namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// ApplicationGateways resource
    /// </summary>
    public partial class ApplicationGateway : Resource
    {
        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets sku of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "properties.sku")]
        public ApplicationGatewaySku Sku { get; set; }

        /// <summary>
        /// Gets operational state of application gateway resource. Possible
        /// values for this property include: 'Stopped', 'Starting',
        /// 'Running', 'Stopping'
        /// </summary>
        [JsonProperty(PropertyName = "properties.operationalState")]
        public ApplicationGatewayOperationalState? OperationalState { get; set; }

        /// <summary>
        /// Gets or sets subnets of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "properties.gatewayIpConfigurations")]
        public IList<ApplicationGatewayIpConfiguration> GatewayIpConfigurations { get; set; }

        /// <summary>
        /// Gets or sets ssl certificates of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "properties.sslCertificates")]
        public IList<ApplicationGatewaySslCertificate> SslCertificates { get; set; }

        /// <summary>
        /// Gets or sets frontend IP addresses of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "properties.frontendIpConfigurations")]
        public IList<ApplicationGatewayFrontendIpConfiguration> FrontendIpConfigurations { get; set; }

        /// <summary>
        /// Gets or sets frontend ports of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "properties.frontendPorts")]
        public IList<ApplicationGatewayFrontendPort> FrontendPorts { get; set; }

        /// <summary>
        /// Gets or sets backend address pool of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "properties.backendAddressPools")]
        public IList<ApplicationGatewayBackendAddressPool> BackendAddressPools { get; set; }

        /// <summary>
        /// Gets or sets backend http settings of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "properties.backendHttpSettingsCollection")]
        public IList<ApplicationGatewayBackendHttpSettings> BackendHttpSettingsCollection { get; set; }

        /// <summary>
        /// Gets or sets HTTP listeners of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "properties.httpListeners")]
        public IList<ApplicationGatewayHttpListener> HttpListeners { get; set; }

        /// <summary>
        /// Gets or sets request routing rules of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "properties.requestRoutingRules")]
        public IList<ApplicationGatewayRequestRoutingRule> RequestRoutingRules { get; set; }

        /// <summary>
        /// Gets or sets Provisioning state of the ApplicationGateway resource
        /// Updating/Deleting/Failed
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
