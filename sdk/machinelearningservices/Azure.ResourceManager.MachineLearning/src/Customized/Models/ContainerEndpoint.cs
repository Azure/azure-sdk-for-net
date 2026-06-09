// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class ContainerEndpoint
    {
        // Customized: restore legacy casing alias.
        [WirePath("hostIp")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HostIP
        {
            get => HostIp;
            set => HostIp = value;
        }
    }
}
