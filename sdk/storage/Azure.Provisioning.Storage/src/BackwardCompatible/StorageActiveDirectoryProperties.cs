// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Storage;

public partial class StorageActiveDirectoryProperties : ProvisionableConstruct
{
    /// <summary>
    /// Specifies the domain GUID.
    ///
    /// This property is obsoleted and will be removed in future versions. Please use
    /// <see cref="StorageActiveDirectoryProperties.ActiveDirectoryDomainGuid"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<Guid> DomainGuid
    {
        get { Initialize(); return _domainGuid!; }
        set { Initialize(); _domainGuid!.Assign(value); }
    }
    private BicepValue<Guid>? _domainGuid;

    private partial void DefineAdditionalProperties()
    {
        _domainGuid = DefineProperty<Guid>("DomainGuid", ["domainGuid"]);
    }
}
