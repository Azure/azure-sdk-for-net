// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventHubs.Models
{
    /// <summary>
    /// Preserves the old type name for backward compatibility.
    /// The new generator creates UnknownEventHubsApplicationGroupPolicy but the old GA API
    /// exposed [PersistableModelProxy(typeof(UnknownApplicationGroupPolicy))] on the base class.
    /// </summary>
    [CodeGenType("UnknownEventHubsApplicationGroupPolicy")]
    internal partial class UnknownApplicationGroupPolicy : EventHubsApplicationGroupPolicy
    {
    }
}
