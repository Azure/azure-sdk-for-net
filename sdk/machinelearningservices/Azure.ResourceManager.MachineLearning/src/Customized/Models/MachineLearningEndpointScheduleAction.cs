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
    [CodeGenSuppress("EndpointInvocationDefinition")]
    public partial class MachineLearningEndpointScheduleAction
    {
        /// <summary>
        /// [Required] Defines Schedule action definition details.
        /// <see href="TBD" />
        /// </summary>
        [WirePath("endpointInvocationDefinition")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BinaryData EndpointInvocationDefinition { get; set; }
    }
}
