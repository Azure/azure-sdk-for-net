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

    /// <summary> Gets or sets the SAS expiration period. </summary>
    [CodeGenMember("SasExpirationPeriod")]
    public BicepValue<string> SasExpirationPeriod
    {
        get { Initialize(); return _sasExpirationPeriod; }
        set { Initialize(); _sasExpirationPeriod.Assign(value); }
    }

    /// <summary> Gets or sets the expiration action. </summary>
    [CodeGenMember("ExpirationAction")]
    public BicepValue<ExpirationAction> ExpirationAction
    {
        get { Initialize(); return _expirationAction; }
        set { Initialize(); _expirationAction.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // The create body makes these properties writable, but the resource model marks their parent as read-only. Remove this
        // workaround when resource and create-body model graphs are recursively combined: https://github.com/Azure/azure-sdk-for-net/issues/61011.
        _sasExpirationPeriod = DefineProperty<string>(nameof(SasExpirationPeriod), new string[] { "sasExpirationPeriod" });
        _expirationAction = DefineProperty<ExpirationAction>(nameof(ExpirationAction), new string[] { "expirationAction" });
    }
}
