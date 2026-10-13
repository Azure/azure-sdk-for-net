// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.AppConfiguration
{
    [CodeGenSuppress("Type")]
    // The legacy generator intentionally omitted this ARM resource type alias from the public API.
    public partial class AppConfigurationPrivateEndpointConnectionReference
    {
        private SystemData _systemData;

        /// <summary> Gets the system metadata associated with this resource. </summary>
        public SystemData SystemData
        {
            get { Initialize(); return _systemData; }
        }

        partial void DefineAdditionalProperties()
        {
            _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
        }
    }
}
