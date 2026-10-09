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
    // Changing the released BicepValue<string> property to BicepValue<ResourceIdentifier>
    // fails ApiCompat with CP0002. The C# alternate type is shared with the management
    // library, where ResourceIdentifier is the existing API, so preserve the provisioning
    // string type on the same wire path with custom code.
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
