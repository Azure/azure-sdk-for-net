// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

internal partial class KeyPolicy
{
    private BicepValue<int> _keyExpirationPeriodInDays;

    // The generator omits writable KeyExpirationPeriodInDays because this model is reached through both the create body and a read-only resource graph.
    [CodeGenMember("KeyExpirationPeriodInDays")]
    public BicepValue<int> KeyExpirationPeriodInDays
    {
        get { Initialize(); return _keyExpirationPeriodInDays; }
        set { Initialize(); _keyExpirationPeriodInDays.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // Remove these registrations when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
        _keyExpirationPeriodInDays = DefineProperty<int>(nameof(KeyExpirationPeriodInDays), new string[] { "keyExpirationPeriodInDays" });
    }
}
