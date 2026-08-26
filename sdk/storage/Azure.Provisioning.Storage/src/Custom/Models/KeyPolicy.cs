// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

internal partial class KeyPolicy
{
    private BicepValue<int> _keyExpirationPeriodInDays;

    [CodeGenMember("KeyExpirationPeriodInDays")]
    public BicepValue<int> KeyExpirationPeriodInDays
    {
        get { Initialize(); return _keyExpirationPeriodInDays; }
        set { Initialize(); _keyExpirationPeriodInDays.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // The create body makes this property writable, but the resource model marks its parent as read-only. Remove this
        // workaround when resource and create-body model graphs are recursively combined: https://github.com/Azure/azure-sdk-for-net/issues/61011.
        _keyExpirationPeriodInDays = DefineProperty<int>(nameof(KeyExpirationPeriodInDays), new string[] { "keyExpirationPeriodInDays" });
    }
}
