// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.AppConfiguration
{
    // CUSTOM:
    // - Renamed.
    // - Convert to extensible enum.
    /// <summary> The composition type describes how the key-values within the snapshot are composed. The 'key' composition type ensures there are no two key-values containing the same key. The 'key_label' composition type ensures there are no two key-values containing the same key and label. </summary>
    [CodeGenType("CompositionType")]
    public readonly partial struct SnapshotComposition { }
}
