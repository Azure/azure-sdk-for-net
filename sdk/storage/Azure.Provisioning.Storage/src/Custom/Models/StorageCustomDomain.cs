// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class StorageCustomDomain
{
    private BicepValue<string> _name;
    private BicepValue<bool> _isUseSubDomainNameEnabled;

    /// <summary> Gets or sets the custom domain name. </summary>
    [CodeGenMember("Name")]
    public BicepValue<string> Name
    {
        get { Initialize(); return _name; }
        set { Initialize(); _name.Assign(value); }
    }

    /// <summary> Gets or sets whether indirect CNAME validation is enabled. </summary>
    [CodeGenMember("IsUseSubDomainNameEnabled")]
    public BicepValue<bool> IsUseSubDomainNameEnabled
    {
        get { Initialize(); return _isUseSubDomainNameEnabled; }
        set { Initialize(); _isUseSubDomainNameEnabled.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // The create body makes these properties writable, but the resource model marks their parent as read-only. Remove this
        // workaround when resource and create-body model graphs are recursively combined: https://github.com/Azure/azure-sdk-for-net/issues/61011.
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" });
        _isUseSubDomainNameEnabled = DefineProperty<bool>(nameof(IsUseSubDomainNameEnabled), new string[] { "useSubDomainName" });
    }
}
