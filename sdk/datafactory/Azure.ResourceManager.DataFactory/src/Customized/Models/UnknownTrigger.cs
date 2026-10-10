// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataFactory.Models
{
    // ApiCompat back-compat: the GA package shipped [PersistableModelProxy(typeof(UnknownTrigger))] on
    // DataFactoryTriggerProperties, but the current generator names the discriminator fallback after the C#
    // client name (UnknownDataFactoryTriggerProperties). [CodeGenType] renames the generated fallback back to
    // the GA name so the public PersistableModelProxy attribute value stays binary-compatible.
    [CodeGenType("UnknownDataFactoryTriggerProperties")]
    internal partial class UnknownTrigger : DataFactoryTriggerProperties
    {
    }
}
