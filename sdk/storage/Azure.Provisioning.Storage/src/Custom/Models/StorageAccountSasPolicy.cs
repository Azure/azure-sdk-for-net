// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class StorageAccountSasPolicy
{
    private BicepValue<string> _sasExpirationPeriod;
    private BicepValue<ExpirationAction> _expirationAction;

    // The generator omits writable SasExpirationPeriod because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the SAS expiration period. </summary>
    [CodeGenMember("SasExpirationPeriod")]
    public BicepValue<string> SasExpirationPeriod
    {
        get { Initialize(); return _sasExpirationPeriod; }
        set { Initialize(); _sasExpirationPeriod.Assign(value); }
    }

    // The generator omits writable ExpirationAction because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the expiration action. </summary>
    [CodeGenMember("ExpirationAction")]
    public BicepValue<ExpirationAction> ExpirationAction
    {
        get { Initialize(); return _expirationAction; }
        set { Initialize(); _expirationAction.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // Remove these registrations when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
        _sasExpirationPeriod = DefineProperty<string>(nameof(SasExpirationPeriod), new string[] { "sasExpirationPeriod" });
        _expirationAction = DefineProperty<ExpirationAction>(nameof(ExpirationAction), new string[] { "expirationAction" });
    }
}
