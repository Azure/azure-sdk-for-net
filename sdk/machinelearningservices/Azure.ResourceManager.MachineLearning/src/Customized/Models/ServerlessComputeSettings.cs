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
    public partial class ServerlessComputeSettings
    {
        /// <summary> Whether serverless compute nodes have no public IP. </summary>
        [WirePath("serverlessComputeNoPublicIP")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? HasNoPublicIP
        {
            get => ServerlessComputeNoPublicIP;
            set => ServerlessComputeNoPublicIP = value;
        }
    }
}
