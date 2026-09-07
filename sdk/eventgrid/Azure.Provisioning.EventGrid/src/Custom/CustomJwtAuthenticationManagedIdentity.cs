// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

public partial class CustomJwtAuthenticationManagedIdentity
{
    private BicepValue<string> _userAssignedIdentity;

    /// <summary> The user-assigned identity to use. </summary>
    // TypeSpec and the management library use ResourceIdentifier. Preserve the released
    // provisioning string type on the same wire path to avoid a breaking API change.
    [CodeGenMember("UserAssignedIdentity")]
    public BicepValue<string> UserAssignedIdentity
    {
        get
        {
            Initialize();
            return _userAssignedIdentity;
        }
        set
        {
            Initialize();
            _userAssignedIdentity.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _userAssignedIdentity = DefineProperty<string>(nameof(UserAssignedIdentity), ["userAssignedIdentity"]);
    }
}
