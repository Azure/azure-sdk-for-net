// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.StandbyPool.Models
{
    [CodeGenSerialization(nameof(SubnetIds), DeserializationValueHook = nameof(SubnetIdsDeserial))]
    public partial class StandbyContainerGroupProperties
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void SubnetIdsDeserial(JsonProperty property, ref IList<WritableSubResource> subnetIds)
        {
            throw new NotImplementedException();
        }
    }
}
