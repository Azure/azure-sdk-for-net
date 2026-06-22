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
    // Customized: restore GA acronym casing. The generated name remains ServerlessComputeNoPublicIP;
    // clientName cannot force the final C# acronym to stay IP instead of Ip for the alias name.
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
