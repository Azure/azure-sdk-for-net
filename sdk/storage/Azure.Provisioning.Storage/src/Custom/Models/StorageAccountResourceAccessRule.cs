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

    // The generator omits writable TenantId because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the tenant ID. </summary>
    [CodeGenMember("TenantId")]
    public BicepValue<Guid> TenantId
    {
        get { Initialize(); return _tenantId; }
        set { Initialize(); _tenantId.Assign(value); }
    }

    // The generator omits writable ResourceId because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the resource ID. </summary>
    [CodeGenMember("ResourceId")]
    public BicepValue<ResourceIdentifier> ResourceId
    {
        get { Initialize(); return _resourceId; }
        set { Initialize(); _resourceId.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // Remove these registrations when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
        _tenantId = DefineProperty<Guid>(nameof(TenantId), new string[] { "tenantId" });
        _resourceId = DefineProperty<ResourceIdentifier>(nameof(ResourceId), new string[] { "resourceId" });
    }
}
