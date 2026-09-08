// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.CosmosDB;

internal partial class ClientEncryptionKeyGetProperties
{
    private CosmosDBSqlClientEncryptionKeyResourceInfo _resource;

    // CUSTOMIZATION: The TypeSpec GET response uses CosmosDBSqlClientEncryptionKeyProperties, but
    // the released CosmosDBSqlClientEncryptionKey.Resource property used
    // CosmosDBSqlClientEncryptionKeyResourceInfo. Preserve the released type temporarily to avoid
    // a breaking change while response model flattening is fixed.
    /// <summary> Gets or sets the Resource. </summary>
    [CodeGenMember("Resource")]
    public global::Azure.Provisioning.CosmosDB.CosmosDBSqlClientEncryptionKeyResourceInfo Resource
    {
        get
        {
            Initialize();
            return _resource;
        }
        set
        {
            Initialize();
            AssignOrReplace(ref _resource, value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _resource = DefineModelProperty<CosmosDBSqlClientEncryptionKeyResourceInfo>(nameof(Resource), new string[] { "resource" });
    }
}
