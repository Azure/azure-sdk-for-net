// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.Network;

public partial class FirewallPolicyRuleCollectionGroupDraft
{
    // The generator fixes this singleton name and removes the released setter.
    // Preserve source compatibility and expression assignment while retaining the
    // required "default" value; the service still expects the singleton name.
    /// <summary> The resource name. The singleton name is "default". </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name; }
        set { Initialize(); _name.Assign(value); }
    }
    private BicepValue<string> _name;

    partial void DefineAdditionalProperties()
    {
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isRequired: true, defaultValue: "default");
    }
}
