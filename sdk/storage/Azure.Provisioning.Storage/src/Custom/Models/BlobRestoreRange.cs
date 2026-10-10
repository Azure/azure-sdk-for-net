// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class BlobRestoreRange
{
    private BicepValue<string> _startRange;
    private BicepValue<string> _endRange;

    // The generator omits writable StartRange because BlobRestoreRange is also reachable through an output model graph.
    /// <summary> Gets or sets the start of the blob range. </summary>
    [CodeGenMember("StartRange")]
    public BicepValue<string> StartRange
    {
        get { Initialize(); return _startRange; }
        set { Initialize(); _startRange.Assign(value); }
    }

    // The generator omits writable EndRange because BlobRestoreRange is also reachable through an output model graph.
    /// <summary> Gets or sets the end of the blob range. </summary>
    [CodeGenMember("EndRange")]
    public BicepValue<string> EndRange
    {
        get { Initialize(); return _endRange; }
        set { Initialize(); _endRange.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // Remove these registrations when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
        _startRange = DefineProperty<string>(nameof(StartRange), new string[] { "startRange" });
        _endRange = DefineProperty<string>(nameof(EndRange), new string[] { "endRange" });
    }
}
