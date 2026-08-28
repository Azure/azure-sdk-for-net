// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewayBackendSettings
    {
        // TODO: Remove this workaround after https://github.com/microsoft/typespec/issues/11696 is fixed.
        /// <summary> Whether to send Proxy Protocol header to backend servers over TCP or TLS protocols. Default value is false. </summary>
        [CodeGenMember("EnableL4ClientIPPreservation")]
        public bool? EnableL4ClientIpPreservation
        {
            get => Properties?.EnableL4ClientIPPreservation;
            set
            {
                Properties ??= new ApplicationGatewayBackendSettingsPropertiesFormat();
                Properties.EnableL4ClientIPPreservation = value;
            }
        }
    }
}
