// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class StorageSku
{
    private BicepValue<StorageSkuName> _name;

    // The generator omits writable Name because SKU is writable in the create body but read-only in the resource graph.
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
        // Remove these registrations when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
        _name = DefineProperty<StorageSkuName>(nameof(Name), new string[] { "name" });
    }
}
