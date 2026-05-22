// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid.Models
{
    // The TypeSpec-emitted discriminator fallback name is "UnknownEventGridFilter", but
    // the previously shipped SDK (1.1.0) exposed the matching type as "UnknownFilter"
    // through [PersistableModelProxy] metadata. Rename via [CodeGenType] so the
    // generated class keeps the original name and ApiCompat passes without a baseline.
    [CodeGenType("UnknownEventGridFilter")]
    internal partial class UnknownFilter : EventGridFilter
    {
    }
}
