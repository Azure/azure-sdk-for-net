// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS0612, CS0618, CS1591

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSuppress("PathRules")]
    [CodeGenSuppress("RequestRoutingRules")]
    [CodeGenSuppress("TargetUri")]
    [CodeGenSuppress("UrlPathMaps")]
    public partial class ApplicationGatewayRedirectConfiguration
    {
        [Azure.ResourceManager.Network.WirePath("properties.pathRules")] public IList<WritableSubResource> PathRules => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.PathRules);
        [Azure.ResourceManager.Network.WirePath("properties.requestRoutingRules")] public IList<WritableSubResource> RequestRoutingRules => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.RequestRoutingRules);
        [Azure.ResourceManager.Network.WirePath("properties.urlPathMaps")] public IList<WritableSubResource> UrlPathMaps => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.UrlPathMaps);
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

#pragma warning restore CS0612, CS0618, CS1591
