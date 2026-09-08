// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.CosmosDB;

internal partial class ThroughputSettingsProperties
{
    private ThroughputSettingsResourceInfo _resource;

    // CUSTOMIZATION: The TypeSpec GET response uses ExtendedThroughputSettingsResourceInfo, but the
    // released Resource property on all throughput-setting resources used
    // ThroughputSettingsResourceInfo. Preserve the released type temporarily to avoid a breaking
    // change while response model flattening is fixed.
    /// <summary> Gets or sets the Resource. </summary>
    [CodeGenMember("Resource")]
    public global::Azure.Provisioning.CosmosDB.ThroughputSettingsResourceInfo Resource
    {
        get
        {
            Initialize();
            return _resource;
        }
        set
        {
            Initialize();
            AssignOrReplace(ref _resource, value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _resource = DefineModelProperty<ThroughputSettingsResourceInfo>(nameof(Resource), new string[] { "resource" });
    }
}
