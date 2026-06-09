// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy property names over generated TypeSpec-normalized names.
    public partial class ContainerEndpoint
    {
        /// <summary> Host IP over which the application is exposed from the container. </summary>
        [WirePath("hostIp")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HostIP
        {
            get => HostIp;
            set => HostIp = value;
        }
    }
}
