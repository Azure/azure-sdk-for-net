namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
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
        [JsonProperty(PropertyName = "sku")]
        public ApplicationGatewaySku Sku { get; set; }

        /// <summary>
        /// Gets operational state of application gateway resource. Possible
        /// values for this property include: 'Stopped', 'Starting',
        /// 'Running', 'Stopping'
        /// </summary>
        [JsonProperty(PropertyName = "operationalState")]
        public ApplicationGatewayOperationalState? OperationalState { get; set; }

        /// <summary>
        /// Gets or sets subnets of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "gatewayIpConfigurations")]
        public IList<ApplicationGatewayIpConfiguration> GatewayIpConfigurations { get; set; }

        /// <summary>
        /// Gets or sets ssl certificates of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "sslCertificates")]
        public IList<ApplicationGatewaySslCertificate> SslCertificates { get; set; }

        /// <summary>
        /// Gets or sets frontend IP addresses of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "frontendIpConfigurations")]
        public IList<ApplicationGatewayFrontendIpConfiguration> FrontendIpConfigurations { get; set; }

        /// <summary>
        /// Gets or sets frontend ports of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "frontendPorts")]
        public IList<ApplicationGatewayFrontendPort> FrontendPorts { get; set; }

        /// <summary>
        /// Gets or sets backend address pool of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "backendAddressPools")]
        public IList<ApplicationGatewayBackendAddressPool> BackendAddressPools { get; set; }

        /// <summary>
        /// Gets or sets backend http settings of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "backendHttpSettingsCollection")]
        public IList<ApplicationGatewayBackendHttpSettings> BackendHttpSettingsCollection { get; set; }

        /// <summary>
        /// Gets or sets HTTP listeners of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "httpListeners")]
        public IList<ApplicationGatewayHttpListener> HttpListeners { get; set; }

        /// <summary>
        /// Gets or sets request routing rules of application gateway resource
        /// </summary>
        [JsonProperty(PropertyName = "requestRoutingRules")]
        public IList<ApplicationGatewayRequestRoutingRule> RequestRoutingRules { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.Sku != null)
            {
                this.Sku.Validate();
            }
            if (this.GatewayIpConfigurations != null)
            {
                foreach ( var element in this.GatewayIpConfigurations)
            {
                if (element != null)
            {
                element.Validate();
            }
            }
            }
            if (this.SslCertificates != null)
            {
                foreach ( var element1 in this.SslCertificates)
            {
                if (element1 != null)
            {
                element1.Validate();
            }
            }
            }
            if (this.FrontendIpConfigurations != null)
            {
                foreach ( var element2 in this.FrontendIpConfigurations)
            {
                if (element2 != null)
            {
                element2.Validate();
            }
            }
            }
            if (this.FrontendPorts != null)
            {
                foreach ( var element3 in this.FrontendPorts)
            {
                if (element3 != null)
            {
                element3.Validate();
            }
            }
            }
            if (this.BackendAddressPools != null)
            {
                foreach ( var element4 in this.BackendAddressPools)
            {
                if (element4 != null)
            {
                element4.Validate();
            }
            }
            }
            if (this.BackendHttpSettingsCollection != null)
            {
                foreach ( var element5 in this.BackendHttpSettingsCollection)
            {
                if (element5 != null)
            {
                element5.Validate();
            }
            }
            }
            if (this.HttpListeners != null)
            {
                foreach ( var element6 in this.HttpListeners)
            {
                if (element6 != null)
            {
                element6.Validate();
            }
            }
            }
            if (this.RequestRoutingRules != null)
            {
                foreach ( var element7 in this.RequestRoutingRules)
            {
                if (element7 != null)
            {
                element7.Validate();
            }
            }
            }
        }
    }
}
