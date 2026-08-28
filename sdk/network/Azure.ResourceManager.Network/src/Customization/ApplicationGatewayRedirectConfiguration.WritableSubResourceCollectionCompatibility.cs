// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayRedirectConfiguration type. </summary>
    [CodeGenSuppress("PathRules")]
    [CodeGenSuppress("RequestRoutingRules")]
    [CodeGenSuppress("TargetUri")]
    [CodeGenSuppress("UrlPathMaps")]
    public partial class ApplicationGatewayRedirectConfiguration
    {
        /// <summary> Gets or sets the TargetUri compatibility property. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.pathRules")]
        public IList<WritableSubResource> PathRules => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.PathRules);
        /// <summary> Gets or sets the RequestRoutingRules compatibility property. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.requestRoutingRules")]
        public IList<WritableSubResource> RequestRoutingRules => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.RequestRoutingRules);
        /// <summary> Gets or sets the UrlPathMaps compatibility property. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.urlPathMaps")]
        public IList<WritableSubResource> UrlPathMaps => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.UrlPathMaps);
        /// <summary> Gets or sets the TargetUri compatibility property. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.targetUrl")]
        public Uri TargetUri
        {
            get => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.ParseUri(Properties?.TargetUri);
            set
            {
                if (Properties is null)
                {
                    Properties = new ApplicationGatewayRedirectConfigurationPropertiesFormat();
                }
                Properties.TargetUri = Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.FormatUri(value);
            }
        }
    }
}
