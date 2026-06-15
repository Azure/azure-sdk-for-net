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

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSuppress("Locations")]
    public partial class ServiceAssociationLink
    {
        public IList<AzureLocation> Locations { get; } = new ChangeTrackingList<AzureLocation>();
    }
}
