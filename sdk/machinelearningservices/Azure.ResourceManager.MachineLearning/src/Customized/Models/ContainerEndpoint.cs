// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class ContainerEndpoint
    {
        // TODO: Remove this workaround after https://github.com/microsoft/typespec/issues/11696 is fixed.
        /// <summary> The host IP address over which the application is exposed from the container. </summary>
        [CodeGenMember("HostIp")]
        [WirePath("hostIp")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HostIP { get; set; }
    }
}
