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
    [CodeGenSuppress("Identity")]
    public partial class MachineLearningServerlessEndpointPatch
    {
        /// <summary> Managed service identity (system assigned and/or user assigned identities). </summary>
        [WirePath("identity")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningPartialManagedServiceIdentity Identity { get; set; }
    }
}
