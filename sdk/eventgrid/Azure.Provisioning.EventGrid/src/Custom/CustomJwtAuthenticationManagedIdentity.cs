// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

public partial class CustomJwtAuthenticationManagedIdentity
{
    private BicepValue<CustomJwtAuthenticationManagedIdentityType> _identityType;
    private BicepValue<string> _userAssignedIdentity;

    /// <summary> The type of managed identity used. </summary>
    // The generated property is required. Preserve the released optional enum property on the
    // original type wire path.
    [CodeGenMember("IdentityType")]
    public BicepValue<CustomJwtAuthenticationManagedIdentityType> IdentityType
    {
        get
        {
            Initialize();
            return _identityType;
        }
        set
        {
            Initialize();
            _identityType.Assign(value);
        }
    }

    /// <summary> The user-assigned identity to use. </summary>
    // The generated property uses ResourceIdentifier. Preserve the released string property and
    // its original wire path so existing Bicep expressions remain source compatible.
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
        _identityType = DefineProperty<CustomJwtAuthenticationManagedIdentityType>(nameof(IdentityType), ["type"]);
        _userAssignedIdentity = DefineProperty<string>(nameof(UserAssignedIdentity), ["userAssignedIdentity"]);
    }
}
