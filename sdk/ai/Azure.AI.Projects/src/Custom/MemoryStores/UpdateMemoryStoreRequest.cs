// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Projects;

internal partial class UpdateMemoryStoreRequest
{
    /// <summary> Initializes a new instance of <see cref="UpdateMemoryStoreRequest"/>. </summary>
    /// <param name="description"> A human-readable description of the memory store. </param>
    /// <param name="metadata"> Arbitrary key-value metadata to associate with the memory store. </param>
    /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
    internal UpdateMemoryStoreRequest(string description, IDictionary<string, string> metadata, IDictionary<string, BinaryData> additionalBinaryDataProperties)
    {
        Description = description;
        Metadata = metadata ?? new ChangeTrackingDictionary<string, string>();
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}
