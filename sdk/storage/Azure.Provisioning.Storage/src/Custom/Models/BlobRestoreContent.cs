// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class BlobRestoreContent
{
    private BicepValue<DateTimeOffset> _timeToRestore;
    private BicepList<BlobRestoreRange> _blobRanges;

    /// <summary> Gets or sets the restore time. </summary>
    [CodeGenMember("TimeToRestore")]
    public BicepValue<DateTimeOffset> TimeToRestore
    {
        get { Initialize(); return _timeToRestore; }
        set { Initialize(); _timeToRestore.Assign(value); }
    }

    /// <summary> Gets or sets the blob ranges to restore. </summary>
    [CodeGenMember("BlobRanges")]
    public BicepList<BlobRestoreRange> BlobRanges
    {
        get { Initialize(); return _blobRanges; }
        set { Initialize(); _blobRanges.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // The generator omits writable TimeToRestore and BlobRanges because this request model is also reachable
        // through an output model graph. Remove this workaround when input and output models are analyzed coherently:
        // https://github.com/Azure/azure-sdk-for-net/issues/61011.
        _timeToRestore = DefineProperty<DateTimeOffset>(nameof(TimeToRestore), new string[] { "timeToRestore" }, format: "O");
        _blobRanges = DefineListProperty<BlobRestoreRange>(nameof(BlobRanges), new string[] { "blobRanges" });
    }
}
