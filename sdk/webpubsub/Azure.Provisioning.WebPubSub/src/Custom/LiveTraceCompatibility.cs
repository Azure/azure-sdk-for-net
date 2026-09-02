// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.WebPubSub;

public partial class LiveTraceCategory
{
    private BicepValue<string> _compatibilityIsEnabled;

    /// <summary> Gets or sets whether this live trace category is enabled. </summary>
    [CodeGenMember("IsEnabled")]
    public BicepValue<string> IsEnabled
    {
        get { Initialize(); return _compatibilityIsEnabled; }
        set { Initialize(); _compatibilityIsEnabled.Assign(value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityIsEnabled = DefineProperty<string>(nameof(IsEnabled), new string[] { "enabled" });
}

public partial class LiveTraceConfiguration
{
    private BicepValue<string> _compatibilityIsEnabled;

    /// <summary> Gets or sets whether live trace is enabled. </summary>
    [CodeGenMember("IsEnabled")]
    public BicepValue<string> IsEnabled
    {
        get { Initialize(); return _compatibilityIsEnabled; }
        set { Initialize(); _compatibilityIsEnabled.Assign(value); }
    }

    partial void DefineAdditionalProperties() =>
        _compatibilityIsEnabled = DefineProperty<string>(nameof(IsEnabled), new string[] { "enabled" });
}
