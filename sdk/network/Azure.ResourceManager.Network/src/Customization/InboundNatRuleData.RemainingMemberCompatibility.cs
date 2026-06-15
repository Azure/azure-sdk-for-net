// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class InboundNatRuleData
    {
        public ETag? ETag => default;
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource FrontendIPConfiguration
        {
            get => FrontendIPConfigurationId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = FrontendIPConfigurationId };
            set => FrontendIPConfigurationId = value?.Id;
        }
    }
}
