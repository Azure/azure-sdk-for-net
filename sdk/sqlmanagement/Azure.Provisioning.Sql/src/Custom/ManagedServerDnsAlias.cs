// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;

namespace Azure.Provisioning.Sql;

public partial class ManagedServerDnsAlias
{
    private BicepValue<bool> _createDnsRecord;

    // TypeSpec models createDnsRecord only on the separate PUT body, so the provisioning
    // generator does not merge it into the response resource model. Preserve the property
    // shipped before the migration until https://github.com/Azure/azure-sdk-for-net/issues/61011
    // is resolved.
    /// <summary> Gets or sets whether a DNS record should be created for this alias. </summary>
    public BicepValue<bool> CreateDnsRecord
    {
        get
        {
            Initialize();
            return _createDnsRecord;
        }
        set
        {
            Initialize();
            _createDnsRecord.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _createDnsRecord = DefineProperty<bool>(nameof(CreateDnsRecord), new string[] { "createDnsRecord" });
    }

    // Preserve API versions shipped by the reflection-based generator that are not emitted
    // by the TypeSpec-based generator when targeting only the current stable API version.
    public static partial class ResourceVersions
    {
        /// <summary> API version "2021-11-01". </summary>
        public static readonly string V2021_11_01 = "2021-11-01";
        /// <summary> API version "2023-08-01". </summary>
        public static readonly string V2023_08_01 = "2023-08-01";
    }
}
