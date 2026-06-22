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
    // Customized: restore GA property name. A client.tsp @@clientName decorator for this output
    // property was tested, but the generated declaration still emits Type.
    public partial class MachineLearningWorkspaceQuotaUpdate
    {
        /// <summary> Specifies the resource type. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UpdateWorkspaceQuotasType => Type;
    }
}
