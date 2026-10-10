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

    // The generator omits writable Name because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the custom domain name. </summary>
    [CodeGenMember("Name")]
    public BicepValue<string> Name
    {
        get { Initialize(); return _name; }
        set { Initialize(); _name.Assign(value); }
    }

    // The generator omits writable IsUseSubDomainNameEnabled because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets whether indirect CNAME validation is enabled. </summary>
    [CodeGenMember("IsUseSubDomainNameEnabled")]
    public BicepValue<bool> IsUseSubDomainNameEnabled
    {
        get { Initialize(); return _isUseSubDomainNameEnabled; }
        set { Initialize(); _isUseSubDomainNameEnabled.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // Remove these registrations when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" });
        _isUseSubDomainNameEnabled = DefineProperty<bool>(nameof(IsUseSubDomainNameEnabled), new string[] { "useSubDomainName" });
    }
}
