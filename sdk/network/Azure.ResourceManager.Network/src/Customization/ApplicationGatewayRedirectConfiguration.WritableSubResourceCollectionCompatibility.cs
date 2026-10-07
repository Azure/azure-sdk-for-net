// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayRedirectConfiguration type. </summary>
    [CodeGenSuppress("TargetUri")]
    public partial class ApplicationGatewayRedirectConfiguration
    {
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
