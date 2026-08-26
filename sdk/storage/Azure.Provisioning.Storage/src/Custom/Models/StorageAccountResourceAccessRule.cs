// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class StorageAccountResourceAccessRule
{
    private BicepValue<Guid> _tenantId;
    private BicepValue<ResourceIdentifier> _resourceId;

    /// <summary> Gets or sets the tenant ID. </summary>
    [CodeGenMember("TenantId")]
    public BicepValue<Guid> TenantId
    {
        get { Initialize(); return _tenantId; }
        set { Initialize(); _tenantId.Assign(value); }
    }

    /// <summary> Gets or sets the resource ID. </summary>
    [CodeGenMember("ResourceId")]
    public BicepValue<ResourceIdentifier> ResourceId
    {
        get { Initialize(); return _resourceId; }
        set { Initialize(); _resourceId.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // The create body makes these properties writable, but the resource model marks their parent as read-only. Remove this
        // workaround when resource and create-body model graphs are recursively combined: https://github.com/Azure/azure-sdk-for-net/issues/61011.
        _tenantId = DefineProperty<Guid>(nameof(TenantId), new string[] { "tenantId" });
        _resourceId = DefineProperty<ResourceIdentifier>(nameof(ResourceId), new string[] { "resourceId" });
    }
}
