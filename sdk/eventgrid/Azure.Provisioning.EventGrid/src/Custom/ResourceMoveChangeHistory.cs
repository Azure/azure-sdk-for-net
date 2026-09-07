// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

public partial class ResourceMoveChangeHistory
{
    private BicepValue<DateTimeOffset> _changedTimeUtc;

    /// <summary> The UTC timestamp of the resource move state change. </summary>
    // The generated property applies the "O" format, which normalizes values to UTC during Bicep
    // serialization. Preserve the released behavior that retains the supplied offset.
    [CodeGenMember("ChangedTimeUtc")]
    public BicepValue<DateTimeOffset> ChangedTimeUtc
    {
        get
        {
            Initialize();
            return _changedTimeUtc;
        }
        set
        {
            Initialize();
            _changedTimeUtc.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _changedTimeUtc = DefineProperty<DateTimeOffset>(nameof(ChangedTimeUtc), ["changedTimeUtc"]);
    }
}
