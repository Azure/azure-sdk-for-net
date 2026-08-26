// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class StorageSku
{
    private BicepValue<StorageSkuName> _name;

    /// <summary> Gets or sets the SKU name. </summary>
    [CodeGenMember("Name")]
    public BicepValue<StorageSkuName> Name
    {
        get
        {
            Initialize();
            return _name;
        }
        set
        {
            Initialize();
            _name.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        // The create body makes sku.name writable, but the resource model marks sku as read-only. Remove this
        // workaround when resource and create-body model graphs are recursively combined: https://github.com/Azure/azure-sdk-for-net/issues/61011.
        _name = DefineProperty<StorageSkuName>(nameof(Name), new string[] { "name" });
    }
}
